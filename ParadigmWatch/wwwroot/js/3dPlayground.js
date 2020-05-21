
import { GLTFLoader } from './GLTFLoader.js';

let BackgroundsTexture, BackgroundsNormal, BackSidesTexture, BackSidesNormal, BasesTexture, BasesNormal, DecorationsTexture, DecorationsNormal, RingsTexture, RingsNormal, SleevesTexture, SleevesNormal
 

var scene = new THREE.Scene();
let myobj = new THREE.Object3D()
var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
var renderer = new THREE.WebGLRenderer();
//let domElement = document.getElementById('canvas')

var e = document.getElementById("bgDropDown");
let HDRIBG = e.options[e.selectedIndex].value;
console.log(HDRIBG + ' : BG HERE')

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

function getBGname()
{
    let HDRIBG = e.options[e.selectedIndex].value;
    console.log(HDRIBG + ' : BG GET')
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
            envMapIntensity: 1,
            roughness: roughnessProp
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


   
    renderer.setSize(window.innerWidth, window.innerHeight);
    document.body.appendChild(renderer.domElement);

    window.addEventListener('resize', () => {
        renderer.setSize(window.innerWidth, window.innerHeight);
        camera.aspect = window.innerWidth / window.innerHeight;

        camera.updateProjectionMatrix();
    })


    var light = new THREE.SpotLight(0xffffff, 1.5);
    light.position.set(0, 500, 2000);
    scene.add(light)




    /* Prop Init */
    const startingModel = document.getElementById('startingModel').textContent

    let baseModel = []
    const PartModelPath = document.getElementsByClassName('PartModelPath')
    const PartName = document.getElementsByClassName('PartName')
    const elementType = document.getElementsByClassName('componentTypeId')
    const textureMap = document.getElementsByClassName('textureMap')
    const metallnessProp = document.getElementsByClassName('metallnessProp')
    const normalMap = document.getElementsByClassName('normalMap')
    const normalIntensity = document.getElementsByClassName('normalIntensity')
    const roughnessProp = document.getElementsByClassName('roughnessProp')
    const EnvMapInt = document.getElementsByClassName('EnvMapInt')

    

    for (let i = 0; i < PartModelPath.length; i++) {
        baseModel.push(PartModelPath.item(i).textContent)
    }
    const loader = new GLTFLoader();

    baseModel.forEach((component, i) => {

        loader.load(
            `${component}`,
            (model) => {

                let currentScene = model.scene
                currentScene.name = PartName.item(i).textContent

                let path = `${component}`
                let words = path.split('/');

                let elemType = words[2]
                let currentTexture = textureMap.item(i).textContent
                let currentNorm = normalMap.item(i).textContent
                let currentMetal = metallnessProp.item(i).textContent
                let currentNormIt = normalIntensity.item(i).textContent
                let currentRou = roughnessProp.item(i).textContent
                let currentEnvMapInt = EnvMapInt.item(i).textContent

                if (words[2] == 'Pointers') {
                    currentScene.children[0].children.forEach((element) => {
                        element.material = populateStandardShader(elemType)
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
                console.log('An error happened');

            })



        
    })
        

    var render = function () {
       
        console.log(HDRIBG);
        requestAnimationFrame(render);
        renderer.render(scene, camera);
    }
    render();



    myobj.name = 'CurrentWatch'

    
}

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

controls.rotateSpeed = 20.0;
controls.zoomSpeed = 1.2;
controls.panSpeed = 0.8;

controls.keys = [65, 83, 68];

animate();