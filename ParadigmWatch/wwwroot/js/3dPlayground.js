





import { GLTFLoader } from './GLTFLoader.js';

let BackgroundsTexture, BackgroundsNormal, BackSidesTexture, BackSidesNormal, BasesTexture, BasesNormal, DecorationsTexture, DecorationsNormal, RingsTexture, RingsNormal, SleevesTexture, SleevesNormal
 



let GUI = document.getElementById('GUI')
let path = './js/WatchPartsJSON.js'
let dataList = []

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
                    console.log()
                    GuiListItem.forEach(listItem => {
                        let currentListItem = document.createElement('div')
                        currentListItem.textContent = listItem.Name
                        currentListItem.classList.add('GuiItem')
                        if (listItem.isSelected) {
                            currentListItem.classList.toggle('activeOption')
                            loadModel(listItem)
                        } else {
                            currentListItem.classList.toggle('inactiveOption')
                        }
                        currentGuiItem.appendChild(currentListItem)
                    })

                    console.log(currentGuiItem)
                    GuiContent.appendChild(currentGuiName)
                    GuiContent.appendChild(currentGuiItem)

                    GUI.appendChild(GuiContent)
                })
                GuiFunctionality()
            })
    }


var scene = new THREE.Scene();
let myobj = new THREE.Object3D()
var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
var renderer = new THREE.WebGLRenderer();
//let domElement = document.getElementById('canvas')

var e = document.getElementById("bgDropDown");
let HDRIBG = e.options[e.selectedIndex].value;
//console.log(HDRIBG + ' : BG HERE')

let enviroment = new THREE.CubeTextureLoader()
    .setPath('models/' + HDRIBG +'/')
    .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);

var glass = new THREE.MeshPhongMaterial({
    color: 0xffffff,
    envMap: enviroment,
    refractionRatio: 0.9,
    depthWrite: false,
    opacity: 0.4,
    transparent: true
})


glass.envMap.mapping = THREE.CubeRefractionMapping;

//function getBGname()
//{
//    let HDRIBG = e.options[e.selectedIndex].value;
//    console.log(HDRIBG + ' : BG GET')
//}
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



async function init() {



    scene.background = enviroment

   
    camera.position.z = 3;

    camera.position.set(-2, -2, 5);
    camera.up = new THREE.Vector3(0, 0, 1);
    camera.lookAt(new THREE.Vector3(0, 0, 0));


    let canvas = document.getElementById('canvas')
    renderer.setSize(window.innerWidth, window.innerHeight);
    canvas.appendChild(renderer.domElement);

    window.addEventListener('resize', () => {
        renderer.setSize(window.innerWidth, window.innerHeight);
        camera.aspect = window.innerWidth / window.innerHeight;

        camera.updateProjectionMatrix();
    })


    var light = new THREE.AmbientLight(0xffffff, 0.4);
    var spotLight = new THREE.SpotLight(0xffffff, 1);
    spotLight.position.set(500, 500, 2000);
    scene.add(spotLight)
    scene.add(light)





    JsonLoader(path)    

    var render = function () {
       
       // console.log(HDRIBG);
        requestAnimationFrame(render);
        renderer.render(scene, camera);
    }
    render();



    myobj.name = 'CurrentWatch'

    
}

console.log(scene.children)

function locator() {
    scene.remove()

   //console.log(scene.getObjectByName('Glass').children[0].material = populateStandardShader('Glasses'))
}




async function initialize() {
    init()
    let promise = new Promise((res, rej) => {
        setTimeout(() => res("loaded"), 1000)
    });

    let result = await promise;

    locator()
}

initialize();


function animate() {
    requestAnimationFrame(animate);
   
    controls.update();
    renderer.render(scene, camera);
}

let controls = new THREE.TrackballControls(camera, renderer.domElement);

controls.rotateSpeed = 1;
controls.zoomSpeed = 1.2;
controls.panSpeed = 0.8;

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

    for (let WatchPart = 0; WatchPart < GuiItem.length; WatchPart++) {
        // Gives each list Item a click event that will allow us to switch out materials on the 3D object
        GuiItem.item(WatchPart).addEventListener('click', () => {
            console.log(GuiItem.item(WatchPart).children[0].innerText)
            console.log(scene.children)
            // Searches the JSON data to find the selected Object
            let GuiItemTypes = dataList.filter((type) => {
                return type.Name == GuiItem.item(WatchPart).innerText;
            })

            console.log('Gui Items ' + GuiItemTypes[0].TypeId);
        })
    }

}

// Finds the Child of the scene which we want to switch out 
function findSelectedType(typeId) {
    // Finds the child element of the scene we want to switch out
    let sameTypes = scene.children.filter((child) => {
        return child.Name.split('-')[1] == typeId;
    });
    // splitted the name into two parts [0] = Name, [1] = TypeId
    let splittedName = sameTypes[0].Name.split('-');
    return splittedName[0];
}

function DeleteModelFromView(guiName) {

}




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

