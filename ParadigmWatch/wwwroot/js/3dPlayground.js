

import { GLTFLoader } from './GLTFLoader.js';


function myFunction() {
    console.log('Change')
}

let BackgroundsTexture, BackgroundsNormal, BackSidesTexture, BackSidesNormal, BasesTexture, BasesNormal, DecorationsTexture, DecorationsNormal, RingsTexture, RingsNormal, SleevesTexture, SleevesNormal
 


let animatable 
let GUI = document.getElementById('GUI')
let path = './js/WatchPartsJSON.js'
let dataList = []
let selectedItems = []
let loading = 1
let sum = 0

    function JsonLoader(path) {
        fetch(path)
            .then(response => response.json())
            .then(data => {
                
                let typeIds = []

                data.forEach(element => {
                    dataList.push(element)
                    typeIds.push(element.TypeId)
                })

                let uniqueTypeIDs = [...new Set(typeIds)]

                sum = uniqueTypeIDs.length

                uniqueTypeIDs.forEach(item => {

                    let GuiContent = document.createElement('li')


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



                    /* First Section */

                    let currentGuiItem = document.createElement('div')
                    currentGuiItem.classList.add('GuiOption')

                    let GuiListItem = data.filter((type) => {
                        return type.TypeId == item;
                    })
                    GuiListItem.forEach(listItem => {
                        let currentListItem = document.createElement('div')
                        currentListItem.textContent = listItem.Name
                        currentListItem.classList.add('GuiItem')
                        if (listItem.isSelected) {
                            currentListItem.classList.toggle('activeOption')
                            selectedItems.push(listItem.WatchPartId)
                            loadModel(listItem)
                            console.log(listItem.WatchPartId)
                            
                        } else {
                            currentListItem.classList.toggle('inactiveOption')
                        }
                        currentGuiItem.appendChild(currentListItem)
                    })

                    GuiContent.appendChild(currentGuiName)
                    GuiContent.appendChild(currentGuiItem)

                    GUI.appendChild(GuiContent)
                    
                })

                GuiFunctionality()
                console.log(selectedItems)
            })
    }

let clock = new THREE.Clock();


let mixer = new THREE.AnimationMixer(animatable)
//var clipAction = mixer.clipAction(animatable);
//clipAction.play();








var scene = new THREE.Scene();
let myobj = new THREE.Object3D()
var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
var renderer = new THREE.WebGLRenderer({ antialias: true });
//let domElement = document.getElementById('canvas')

// get the initial bacground image
var e = document.getElementById("bgDropDown");
let HDRIBG = e.options[e.selectedIndex].value;

// The environment reflecting on the object
let enviroment = new THREE.CubeTextureLoader()
    .setPath(`models/${HDRIBG}/`)
    .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);
// The bacground environment
let enviromentFlipped = new THREE.CubeTextureLoader()
    .setPath(`models/${HDRIBG}Flipped/`)
    .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);
console.log('Initial Load: ' + HDRIBG);

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

let oddClick = true;
dropdownElement.addEventListener('click', () => {
    if (!oddClick) {

        var e = document.getElementById("bgDropDown");
        let HDRIBG = e.options[e.selectedIndex].value;

        enviroment = new THREE.CubeTextureLoader()
            .setPath(`models/${HDRIBG}/`)
            .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);

        enviromentFlipped = new THREE.CubeTextureLoader()
            .setPath(`models/${HDRIBG}Flipped/`)
            .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);
        scene.background = enviroment;
        console.log(HDRIBG + ': Selected Element');


        deleteJson()
        ReloadModels()
         
         

        oddClick = true;
    } else {
        oddClick = false;
    }

})

function deleteJson() {
    scene.children.forEach(e => {
        if (e.name != '') {
            scene.remove(e)
        }
    })
}
function ReloadModels() {
    dataList.forEach(e => {
        if (e.isSelected) {
            
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

    if (textureMap != undefined || normalMap != undefined) {

        let tempText = `${elementType}Texture = new THREE.TextureLoader().load('${textureMap}')`
        let flipingBug = `${elementType}Texture.flipY = false`
        let tempNorm = `${elementType}Normal = new THREE.TextureLoader().load('${normalMap}')`
        let texture = eval(tempText)
        let normal = eval(tempNorm)
        eval(flipingBug)
        hasTexture = true
        return ShaderBuilder(texture, normal, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color)
    } else {

        return ShaderBuilder(textureMap, normalMap, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color)
    }
}

function ShaderBuilder(texture, normal, metallnessProp, normalIntensity, roughnessProp, hasTexture, EnvMapInt, color) {

    if (hasTexture) {

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

        return currentMat
    } else {
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
let canvas = document.getElementById('canvas')
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.toneMapping = THREE.ReinhardToneMapping;
canvas.appendChild(renderer.domElement)


async function init() {



    scene.background = enviromentFlipped

   
    camera.position.z = 3;

    camera.position.set(-2, -2, 5);
    camera.up = new THREE.Vector3(0, 0, 1);
    camera.lookAt(new THREE.Vector3(0, 0, 0));
    camera.toneMapping = THREE.ACESFilmicToneMapping



    window.addEventListener('resize', () => {
        renderer.setSize(window.innerWidth, window.innerHeight);
        camera.aspect = window.innerWidth / window.innerHeight;

        camera.updateProjectionMatrix();
    })


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





    JsonLoader(path)
   


    



    myobj.name = 'CurrentWatch'

}

console.log(scene.children)




function BuildUpAnimation() {

}

async function initialize() {
    init()
    let promise = new Promise((res, rej) => {
        setTimeout(() => res("loaded"), 1000)
    });

    let result = await promise;

}

initialize();

let controls = new THREE.TrackballControls(camera, renderer.domElement);

controls.rotateSpeed = 1;
controls.zoomSpeed = 1.2;
controls.noPan = true;
controls.minDistance = 2;
controls.maxDistance = 8;

controls.keys = [65, 83, 68];

animate();

function GuiFunctionality() {
    let GUIlist = document.getElementsByClassName('GUIlist')
    let GuiOption = document.getElementsByClassName('GuiOption')
    let GuiItem = document.getElementsByClassName('GuiItem')
    //Collapse function
    for (let gui = 0; gui < GUIlist.length; gui++) {
        let cGui = GUIlist.item(gui)
        cGui.addEventListener('click', () => {
            let cOpt = GuiOption.item(gui)
            console.log(cOpt.scrollHeight)
            for (let close = 0; close < GuiOption.length; close++) {
                if (close != gui) {
                    GuiOption.item(close).style.height = '0px'
                }
            }

            cOpt.style.height = `${cOpt.scrollHeight}px`

        })
    }
    console.log(GuiItem)
    let breaks = []
    for (let breakpoint = 0; breakpoint < GuiItem.length; breakpoint++) {
        if (GuiItem.item(breakpoint).textContent.split(' ')[1]) {
            if (!GuiItem.item(breakpoint - 1) || GuiItem.item(breakpoint).textContent.split(' ')[1] !== GuiItem.item(breakpoint - 1).textContent.split(' ')[1]) {
                breaks.push(breakpoint)
            }
            
        } else {
            console.log(1)
        }
        //if () {
        //    breaks.push(breakpoint)
        //}
    }
    for (let WatchPart = 0; WatchPart < GuiItem.length; WatchPart++) {

        // Gives each list Item a click event that will allow us to switch out materials on the 3D object
        GuiItem.item(WatchPart).addEventListener('click', () => {

            console.log(scene)
            GuiItem.item(WatchPart).classList.toggle('activeOption')
            GuiItem.item(WatchPart).classList.toggle('inactiveOption')
            // Searches the JSON data to find the selected Object
            let GuiItemTypes = dataList.filter((type) => {
                return type.Name == GuiItem.item(WatchPart).textContent;
            })
            console.log(GuiItemTypes[0])

            let GuiItemListTypes = dataList.filter((type) => {
                return type.TypeId == GuiItemTypes[0].TypeId
            })
            let ceiling = breaks.findIndex((max) => {
                return max > WatchPart
            })
            let min = breaks[ceiling - 1]
            console.log()
            console.log(WatchPart)
            GuiItemListTypes.forEach((e, i) => {
                if (e.Name != GuiItem.item(WatchPart).textContent) {
                    GuiItem.item(min + i).classList.remove('activeOption')
                    GuiItem.item(min + i).classList.remove('inactiveOption')
                    GuiItem.item(min + i).classList.add('inactiveOption')
                }
            })

            console.log(GuiItemListTypes)


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
                    let arr = dataList.filter((elem) => {
                        return elem.isSelected == true

                    }).map((obj) => {
                        return obj.WatchPartId
                    })
                    selectedItems = arr
                    console.log(selectedItems)
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


const loader = new GLTFLoader();

function loadModel(jsonObject) {
    loader.load(
        jsonObject.ModelPath,
            (model) => {

                let currentScene = model.scene
                currentScene.name = `${jsonObject.Name}-${jsonObject.TypeId}`

                let path = jsonObject.ModelPath
                let words = path.split('/');

                let elemType = words[2]

                
                

                let currentTexture = jsonObject.TextureImagePath
                if (!jsonObject.TextureImagePath) {
                    currentTexture = undefined
                }
                let currentNorm = jsonObject.NormalMapPath
                if (!jsonObject.NormalMapPath) {
                    currentNorm = undefined
                }

                let currentMetal = jsonObject.Metalness
                let currentNormIt = jsonObject.NormalMapIntensity
                let currentRou = jsonObject.Roughness
                let currentEnvMapInt = jsonObject.EnvMapInt


                if (words[2] == 'Pointers') {
                    currentScene.children[0].children.forEach((element) => {
                        element.material = populateStandardShader(elemType, currentTexture, currentNorm, currentMetal, currentNormIt, currentRou, currentEnvMapInt)
                        element.material.name = words[2]
                    })
                    scene.add(currentScene)
                }
                if (words[2] == 'Rings') {

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

                
                //scene.add(currentScene)

                loadingFunc(loading, sum)
                loading++
                renderer.render(scene, camera);
            },
            // called when loading is in progresses
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

    if (percentage / sum != 1) {

        
        let currentStatus = (percentage / sum) * 100
        loadingBar.style.width = `${currentStatus}%`
        loadingBar.style.opacity = 1 - (percentage / sum)
        loaderContainer.appendChild(loadingBar)
    } else {
        loadingBar.style.width = `100%`
        

        threeGui.style.height = '70vh'
        canvas.style.transition = '1s'
        canvas.style.opacity = '1'
    }
    
}



function getAnimation() {
    setTimeout(function () {
        //scene.add(animatable)
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
        
        //console.log(mixer)
        //var clipAction = mixer.clipAction(animatable.animations[0]);
        //console.log(clipAction)
        //clipAction.play();


    }, 1000)
}
getAnimation()


function animate() {
    requestAnimationFrame(animate);

    var delta = clock.getDelta();

    mixer.update(delta);

    renderer.render(scene, camera);

    controls.update();
}

console.log(dataList)

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
    alert(document.getElementById("CreatedProductParts"))
})


