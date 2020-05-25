

import { GLTFLoader } from './GLTFLoader.js';

let BackgroundsTexture, BackgroundsNormal, BackSidesTexture, BackSidesNormal, BasesTexture, BasesNormal, DecorationsTexture, DecorationsNormal, RingsTexture, RingsNormal, SleevesTexture, SleevesNormal
 



let GUI = document.getElementById('GUI')
let path = './js/WatchPartsJSON.js'

    function JsonLoader(path) {
        fetch(path)
            .then(response => response.json())
            .then(data => {
                let typeIds = []

                data.forEach(element => {

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

                addGuiFunctions()
                BuildUpAnimation()
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

let enviromentFlipped = new THREE.CubeTextureLoader()
    .setPath(`models/${HDRIBG}Flipped/`)
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



    scene.background = enviromentFlipped

   
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


function BuildUpAnimation() {

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


function addGuiFunctions() {


}









const loader = new GLTFLoader();

function loadModel(jsonObject) {
   

    loader.load(
        jsonObject.ModelPath,
            (model) => {

                let currentScene = model.scene
                currentScene.name = jsonObject.Name

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

