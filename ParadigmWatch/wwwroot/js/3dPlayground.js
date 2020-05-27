
﻿

import { GLTFLoader } from './GLTFLoader.js';


//initializing dynamic variables, these are later populated by the populateStandardShader() function

let BackgroundsTexture, BackgroundsNormal, BackSidesTexture, BackSidesNormal, BasesTexture, BasesNormal, DecorationsTexture, DecorationsNormal, RingsTexture, RingsNormal, SleevesTexture, SleevesNormal
 

//init animation 
let animatable 
let GUI = document.getElementById('GUI')
//local path of generated Json object
let path = './js/WatchPartsJSON.js'
//init local copy of json object (for modifications)
let dataList = []
//list of items which are currently selected - this is passed to back-end to redirect to custom page
let selectedItems = []
//init loading variables
let loading = 1
let sum = 0
//Load from generated Json
    function JsonLoader(path) {
        fetch(path)
            .then(response => response.json())
            .then(data => {
                //collecting type ids, allowing duplicates
                let typeIds = []

                data.forEach(element => {
                    dataList.push(element)
                    typeIds.push(element.TypeId)
                })
                //reoving duplicates from the list of allowed 3D object types (e.g. sleeves = [0], glass = [1] )
                let uniqueTypeIDs = [...new Set(typeIds)]
                //sum of allowed types. This is used for the loading bar
                sum = uniqueTypeIDs.length
                //for Each type generate the UI and load the model
                uniqueTypeIDs.forEach(item => {
                    //Big container
                    let GuiContent = document.createElement('li')

                    //3D object type name
                    let currentGuiName = document.createElement('div')
                    currentGuiName.classList.add('GUIlist')

                    let currentName = document.createElement('h2')
                    currentName.textContent = data[item-1].Type
                    currentName.classList.add('guiPartType')

                    let arrow = document.createElement('div')
                    arrow.textContent = '>'
                    arrow.classList.add('arrow')

                    currentGuiName.appendChild(currentName)
                    currentGuiName.appendChild(arrow)



                    //list of 3D objects of type

                    let currentGuiItem = document.createElement('div')
                    currentGuiItem.classList.add('GuiOption')

                    let GuiListItem = data.filter((type) => {
                        return type.TypeId == item;
                    })
                    //forEach Object in a certain Object type
                    GuiListItem.forEach(listItem => {
                        let currentListItem = document.createElement('div')
                        currentListItem.textContent = `${listItem.Name} - ${listItem.Price}$`
                        currentListItem.classList.add('GuiItem')
                        //if the Object is set to a default of this watch load it
                        if (listItem.isSelected) {
                            currentListItem.classList.toggle('activeOption')
                            selectedItems.push(listItem.WatchPartId)
                            loadModel(listItem)
                         //else add it to the inactive class   
                        } else {
                            currentListItem.classList.toggle('inactiveOption')
                        }
                        currentGuiItem.appendChild(currentListItem)
                    })

                    GuiContent.appendChild(currentGuiName)
                    GuiContent.appendChild(currentGuiItem)

                    GUI.appendChild(GuiContent)
                    
                })
                //calling the functionalities of the UI. This allows us to fill up the new list with functions
                GuiFunctionality()
            })
    }
//time for rendering
let clock = new THREE.Clock();

//This is neccessary for the animations
let mixer = new THREE.AnimationMixer(animatable)

//Setting up Three.js scene, camera and renderer
var scene = new THREE.Scene();
var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
var renderer = new THREE.WebGLRenderer({ antialias: true });


let e, HDRIBG, enviroment, enviromentFlipped
// get the initial bacground image - we call this function and set it's values on background change event
function initBackground() {
    e = document.getElementById("bgDropDown");
     HDRIBG = e.options[e.selectedIndex].value;

    enviroment = new THREE.CubeTextureLoader()
        .setPath(`models/${HDRIBG}/`)
        .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);
    //Three.js applies the HDRI flipped on the scene and on the material. so we need to flip one of them back (Three.js bug)
    enviromentFlipped = new THREE.CubeTextureLoader()
        .setPath(`models/${HDRIBG}Flipped/`)
        .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);
}

initBackground()

//glass has unique values and never changes, therefore has it's own static shader
var glass = new THREE.MeshPhongMaterial({
    color: 0xffffff,
    envMap: enviroment,
    refractionRatio: 0.9,
    depthWrite: false,
    opacity: 0.4,
    transparent: true
})

glass.envMap.mapping = THREE.CubeRefractionMapping;

let dropdownElement = document.getElementById('bgDropDown');

let oddClick = false;
dropdownElement.addEventListener('click', () => {
    //on second click
    if (oddClick) {
        //init bg
        initBackground()
        //updating background image
        scene.background = enviroment;
        //we need to delete the old models on background load because the 
        //reflections are baked into the shaders, so if we wouldn't the object would reflect the old background
        deleteJson()
        //now we reload the models which are currently selected
        ReloadModels()
         
         

        oddClick = false;
    } else {
        oddClick = true;
    }

})
//Delete all models
function deleteJson() {
    scene.children.forEach(e => {
        if (e.name != '') {
            scene.remove(e)
        }
    })
}
//Reload those models with updated textures
function ReloadModels() {
    dataList.forEach(e => {
        if (e.isSelected) {
            //special condition for glass because it can not be dynamically updated with the other shaders since it's static
            if (e.Name == 'Crystal Glass') {
                glass = new THREE.MeshPhongMaterial({
                    color: 0xffffff,
                    envMap: enviromentFlipped,
                    refractionRatio: 0.9,
                    depthWrite: false,
                    opacity: 0.4,
                    transparent: true
                })

            }
            loadModel(e)
        }
            
    })
}

// Create a shader with the assigned parameters
function populateStandardShader(elementTypeRaw, textureMap = undefined, normalMap = undefined, metallnessProp = 0, normalIntensity = 0, roughnessProp = 0, EnvMapInt = 1, color = 0xffffff) {
    let elementType = elementTypeRaw.toString()
    let hasTexture = false;
    //If the loaded element has a texture or a normal map we create a shader which can handle these parameters
    if (textureMap != undefined || normalMap != undefined) {
        //filling up our dynamic variables which we declared in the beginning.
        let tempText = `${elementType}Texture = new THREE.TextureLoader().load('${textureMap}')`
        let flipingBug = `${elementType}Texture.flipY = false`
        let tempNorm = `${elementType}Normal = new THREE.TextureLoader().load('${normalMap}')`
        //with eval we execute the variable and fill up the target variables
        let texture = eval(tempText)
        let normal = eval(tempNorm)
        eval(flipingBug)
        //we set the texture to true so it will sort it into that shader Builder in the next function
        hasTexture = true
        return ShaderBuilder(texture, normal, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color)
    } else {
        //if we don't have a texture we create a different, simple material 
        return ShaderBuilder(textureMap, normalMap, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color)
    }
}
//takes in the sorted variables from populateStandardShader
function ShaderBuilder(texture, normal, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color) {

    if (hasTexture) {
        //Textured materials
        var currentMat = new THREE.MeshStandardMaterial({
            color: 0xffffff,
            map: texture,
            bumpMap: normal,
            bumpScale: normalIntensity,
            metalness: metallnessProp,
            envMap: enviroment,
            envMapIntensity: EnvMapInt,
            roughness: roughnessProp
        })
        currentMat.envMap.mapping = THREE.CubeRefractionMapping;
        //returns the expected input for a mesh.material property of three.js Object3D
        return currentMat
    } else {
        //Simple materials
        var currentMat = new THREE.MeshStandardMaterial({
            color: color,
            metalness: metallnessProp,
            envMap: enviroment,
            envMapIntensity: 5,
            roughness: roughnessProp,

        })
        currentMat.envMap.mapping = THREE.CubeRefractionMapping;

        return currentMat
    }

}
//initializing other parts of three.js renderer
let canvas = document.getElementById('canvas')
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.toneMapping = THREE.ReinhardToneMapping;
canvas.appendChild(renderer.domElement)


async function init() {
    //init default background
    scene.background = enviromentFlipped

   //init camera position and orientation
    camera.position.z = 3;
    camera.position.set(-2, -2, 5);
    camera.up = new THREE.Vector3(0, 0, 1);
    camera.lookAt(new THREE.Vector3(0, 0, 0));
    camera.toneMapping = THREE.ACESFilmicToneMapping


    //adjust viewport to window resize
    window.addEventListener('resize', () => {
        renderer.setSize(window.innerWidth, window.innerHeight);
        camera.aspect = window.innerWidth / window.innerHeight;

        camera.updateProjectionMatrix();
    })

    //adding and setting lights
    var light = new THREE.AmbientLight(0x81808F, 0.5);
    var light2 = new THREE.AmbientLight(0xffffff, 0.5);
    var spotLight = new THREE.SpotLight(0xD17A51, 3);
    var spotLight2 = new THREE.SpotLight(0x6D808F, 3);
    spotLight.position.set(500, 300, 300);
    spotLight2.position.set(-500, 300, 300);
    scene.add(spotLight)
    scene.add(spotLight2)
    scene.add(light)
    scene.add(light2)

    //calling the fetching function to load the default models
    JsonLoader(path)

}
//calling init function
init()

//initializing the js object for 3D controls (part of Three.js)
let controls = new THREE.TrackballControls(camera, renderer.domElement);
//controls parameters
controls.rotateSpeed = 1;
controls.zoomSpeed = 1.2;
controls.noPan = true;
controls.minDistance = 2;
controls.maxDistance = 8;

controls.keys = [65, 83, 68];
//Draw frame every second and other goodies
animate();
//Giving functionalities to the User interface
function GuiFunctionality() {
    let GUIlist = document.getElementsByClassName('GUIlist')
    let GuiOption = document.getElementsByClassName('GuiOption')
    let GuiItem = document.getElementsByClassName('GuiItem')
    //Collapse function
    for (let gui = 0; gui < GUIlist.length; gui++) {
        let cGui = GUIlist.item(gui)
        cGui.addEventListener('click', () => {
            let cOpt = GuiOption.item(gui)
            for (let close = 0; close < GuiOption.length; close++) {
                if (close != gui) {
                    GuiOption.item(close).style.height = '0px'
                }
            }
            //Using the scrollHeight propery to set up a heigth of the hidden elements
            cOpt.style.height = `${cOpt.scrollHeight}px`

        })
    }
    //Storing the indexes of 3D Object type changes in an array
    let breaks = []
    for (let breakpoint = 0; breakpoint < GuiItem.length; breakpoint++) {
        //we split the item name which contains the price to Raw name
        let newName = [GuiItem.item(breakpoint).textContent.split(' ')[0], GuiItem.item(breakpoint).textContent.split(' ')[1]]
        // init the Raw name of the adjacent previous item
        let oldName = []
        //checking if it is NOT the first element of the array, 
        let isValid = true
        //if it's not the first item push elements to the Old name
        if (GuiItem.item(breakpoint - 1)) {
            oldName.push(GuiItem.item(breakpoint - 1).textContent.split(' ')[0])
            oldName.push(GuiItem.item(breakpoint - 1).textContent.split(' ')[1])
        } else {
            isValid = false
        }
        //add the break points
        if (!isValid || newName[1] !== oldName[1]) {
                breaks.push(breakpoint)
            }
            
    //for each variant of all 3D object types we add a function in the UI
    }
    for (let WatchPart = 0; WatchPart < GuiItem.length; WatchPart++) {

        // Gives each list Item a click event that will allow us to switch out materials on the 3D object
        GuiItem.item(WatchPart).addEventListener('click', () => {

            GuiItem.item(WatchPart).classList.toggle('activeOption')
            GuiItem.item(WatchPart).classList.toggle('inactiveOption')
            // Searches the JSON data to find the selected Object
            let newName = []
            newName.push(GuiItem.item(WatchPart).textContent.split(' ')[0])
            newName.push(GuiItem.item(WatchPart).textContent.split(' ')[1])
            let GuiItemTypes = dataList.filter((type) => {
                return type.Name == newName.join(' ');
            })
            
            
            //find all alike object in JSON
            let GuiItemListTypes = dataList.filter((type) => {
                return type.TypeId == GuiItemTypes[0].TypeId
            })
            //Find bigger number that WatchPart among the Break points. we use the element one before to know which elements are the same part
            //so we can close them later except the one currently active
            let ceiling = breaks.findIndex((max) => {
                    return max > WatchPart
            })
            //adding a condition to include the last array of elements
            let min;
            if (breaks[ceiling] != undefined) {
                min = breaks[ceiling - 1]
            } else {
                min = breaks[breaks.length - 1]
            }
            //set all elements which are NOT the currently selected to inactive
            GuiItemListTypes.forEach((e, i) => {
                if (e.Name != newName.join(' ')) {
                    GuiItem.item(min + i).classList.remove('activeOption')
                    GuiItem.item(min + i).classList.remove('inactiveOption')
                    GuiItem.item(min + i).classList.add('inactiveOption')
                }
            })



            // Getting the name of the part we are replacing
            let partName = findSelectedType(GuiItemTypes[0].TypeId)[0]
            // Setting the selected boolean to false for the one we are switching out
            dataList.forEach(element => {
                // WHen we find the element we set the isSelected to false and then deleting it from the scene
                if ( element.Name === partName ) {
                    let selectedName = findSelectedType(GuiItemTypes[0].TypeId)
                    element.isSelected = false;
                    DeleteModelFromView(selectedName[0] + '-' + selectedName[1]);

                }
                // We find the object the user selected and update the model with it :)
                if (element.WatchPartId == GuiItemTypes[0].WatchPartId) {
                    element.isSelected = true;
                    loadModel(element);
                    //We update our JSON copy with the currently selected item
                    let arr = dataList.filter((elem) => {
                        return elem.isSelected == true

                    }).map((obj) => {
                        return obj.WatchPartId
                    })
                    //and we set the global variable which collects the Watch Part ID-s (to redirect later)
                    selectedItems = arr
                }

            })
        })
    }

}

// Finds the Child of the scene which we want to switch out 
function findSelectedType(typeId) {
    // Finds the child element of the scene we want to switch out
    let sameTypes = scene.children.filter((child) => {
        return child.name.split('-')[1] == typeId;
    });
    // splitted the name into two parts [0] = Name, [1] = TypeId
    let splittedName = sameTypes[0].name.split('-');
    
    return splittedName;
}

// Deleting the object which was previously on the model so we can replace it with the new object later
function DeleteModelFromView(guiName) {
    var selectedObject = scene.getObjectByName(guiName);
    scene.remove(selectedObject);
    animate();
}

let animation;

//Required loader
const loader = new GLTFLoader();
//the loader function. it accepts a json object and returns a 3D object in the scene
function loadModel(jsonObject) {
    loader.load(
        jsonObject.ModelPath,
            (model) => {
                //model.scene is the scene of the object, not the Three.js scene. All .gltf files have one
                let currentScene = model.scene
                currentScene.name = `${jsonObject.Name}-${jsonObject.TypeId}`

                //getting the data
                let path = jsonObject.ModelPath
                let words = path.split('/');

                let elemType = words[2]

                let currentTexture = jsonObject.TextureImagePath
                if (!jsonObject.TextureImagePath) {
                    currentTexture = undefined }
                let currentNorm = jsonObject.NormalMapPath
                if (!jsonObject.NormalMapPath) {
                    currentNorm = undefined }
                let currentMetal = jsonObject.Metalness
                let currentNormIt = jsonObject.NormalMapIntensity
                let currentRou = jsonObject.Roughness
                let currentEnvMapInt = jsonObject.EnvMapInt


                if (words[2] == 'Pointers') {
                    //Pointers have many objects inside so it needs to be separate
                    currentScene.children[0].children.forEach((element) => {
                        element.material = populateStandardShader(elemType, currentTexture, currentNorm, currentMetal, currentNormIt, currentRou, currentEnvMapInt)
                        element.material.name = words[2]
                    })
                    scene.add(currentScene)
                }
                if (words[2] == 'Rings') {
                    //setting up the animation
                    scene.add(model.scene)
                   animation = model.animations
                }

                if (words[2] == 'Glasses') {
                    currentScene.children.forEach((element) => {
                        element.material = glass
                        element.material.name = words[2] 
                    })
                    scene.add(currentScene)
                }


                else {
                    currentScene.children.forEach((element) => {
                        element.material = populateStandardShader(elemType, currentTexture, currentNorm, currentMetal, currentNormIt, currentRou, currentEnvMapInt)
                        element.material.name = words[2] 
                    })
                    
                    scene.add(currentScene)
                }

                //passing variables to the loader
                loadingFunc(loading, sum)
                loading++
                renderer.render(scene, camera);
            },
            // called when loading is in progresses - for individual elements
            function (xhr) {
                //console.log((xhr.loaded / xhr.total * 100) + '% loaded');

            },
            // called when loading has errors
            function (error) {
                console.log(error);

            })




}

let threeGui = document.getElementById('threeGui')
let loaderContainer = document.getElementById('loaderContainer')
let loadingBar = document.createElement('div')
loadingBar.classList.add('loading')
function loadingFunc(percentage, sum) {
    //the loading screen
    if (percentage / sum != 1) {    
        let currentStatus = (percentage / sum) * 100
        loadingBar.style.width = `${currentStatus}%`
        loadingBar.style.opacity = 1 - (percentage / sum)
        loaderContainer.appendChild(loadingBar)
    } else {
        loadingBar.style.width = `100%`
        //once it is fully loaded 
        threeGui.style.height = '70vh'
        canvas.style.transition = '1s'
        canvas.style.opacity = '1'
    }
    
}



function getAnimation() {
    //Ring animation
    setTimeout(function () {
        animation[0].loop = 1
        mixer = new THREE.AnimationMixer(scene.getObjectByName('Chrome Ring-8'))

        var clipAction = mixer.clipAction(animation[0]);
        clipAction.loop = THREE.LoopOnce
        clipAction.clampWhenFinished = true;
        if (clipAction.time === 0) {
            clipAction.time = clipAction.getClip().duration;
        }
        clipAction.timeScale = -1
        clipAction.paused = false;
        clipAction.play()
        



    }, 1000)
}
getAnimation()

//Update every frame
function animate() {
    
    requestAnimationFrame(animate);

    var delta = clock.getDelta();

    mixer.update(delta);

    renderer.render(scene, camera);

    controls.update();
}

//Redirecting to custom build Product Page - The info is stored in the URL
let prmbtn = document.getElementsByClassName('prmbtn').item(0)
let watchId = document.getElementById('watchId').textContent
prmbtn.addEventListener('click', () => {
    selectedItems.unshift(watchId)
    let WatchInfo = selectedItems.join('-')

    let url = window.location.href.split('/')
    let rawurl = url.slice(0, -1)
    let newurl = `${rawurl[0]}//${rawurl[2]}/ProductPage?watchId=${WatchInfo}`
    window.location.href = newurl
})


//CreatedProductParts

let cartBTN = document.getElementsByClassName('secbtn').item(0);
cartBTN.addEventListener('click', () => {
    selectedItems.unshift(watchId)
    let WatchInfo = selectedItems.join('-')

    document.getElementById("CreatedProductParts").setAttribute("value", `${WatchInfo}`);
})


