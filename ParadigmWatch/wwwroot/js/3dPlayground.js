
import * as THREE from './three.module.js';
import { GLTFLoader } from './GLTFLoader.js';
import { MeshStandardMaterial } from '../build/three.module.js';


var num = "<%=feevalue%>";
console.log(num)
function init() {

    // The object we will select on click and drag around
    var selectedItem = null;

    var scene = new THREE.Scene();
    scene.background = new THREE.Color(0xf0f0f0);

    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.z = 3;

    camera.position.set(-2, -2, 5);
    camera.up = new THREE.Vector3(0, 0, 1);
    camera.lookAt(new THREE.Vector3(0, 0, 0));

    var raycaster = new THREE.Raycaster();
    var mouse = new THREE.Vector2();

    var renderer = new THREE.WebGLRenderer();
    renderer.setSize(window.innerWidth, window.innerHeight);
    document.body.appendChild(renderer.domElement);

    window.addEventListener('resize', () => {
        renderer.setSize(window.innerWidth, window.innerHeight);
        camera.aspect = window.innerWidth / window.innerHeight;

        camera.updateProjectionMatrix();
    })


    var light = new THREE.SpotLight(0xffffff, 1.5);
    light.position.set(0, 500, 2000);

    scene.add(light);


    function onMouseClick(event) {

        // calculate mouse position in normalized device coordinates
        // (-1 to +1) for both components

        mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
        mouse.y = - (event.clientY / window.innerHeight) * 2 + 1;

        console.log(mouse);
        raycaster.setFromCamera(mouse, camera);

        var intersects = raycaster.intersectObjects(scene.children, true)
        for (let i = 0; i < intersects.length; i++) {
            this.selectedItem = intersects[i].object;
        }
        console.log(this.selectedItem)
    }

    function onMouseMove(event) {

        mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
        mouse.y = - (event.clientY / window.innerHeight) * 2 + 1;

        raycaster.setFromCamera(mouse, camera);

        if (this.selectedItem != null) {
            console.log('moving')
            console.log(this.selectedItem);
            this.selectedItem.position.copy(new THREE.Vector3(mouse.x, mouse.y, 0));
            console.log(selectedItem.position);
        }
    }

    function onDocumentMouseCancel(event) {
        if (this.selectedItem) {
            console.log('Cancelling');
            this.selectedItem = null;
        }
    }



    /* Prop Init */
    const startingModel = document.getElementById('startingModel').textContent
    const elementType = document.getElementsByClassName('componentTypeId')
    const textureMap = document.getElementsByClassName('textureMap')
    const metallnessProp = document.getElementsByClassName('metallnessProp')
    const normalMap = document.getElementsByClassName('normalMap')
    const normalIntensity = document.getElementsByClassName('normalIntensity')
    const roughnessProp = document.getElementsByClassName('roughnessProp')

    const chromeTexture = new THREE.TextureLoader().load('models/chrome.png')
    const chromeNormal = new THREE.TextureLoader().load('models/chromeNormal.jpg')


    const watchFront = new THREE.TextureLoader().load('models/watchFrontTexture.png')
    watchFront.flipY = false

    const strapTexture = new THREE.TextureLoader().load('models/strap.png')


    const enviroment = new THREE.CubeTextureLoader()
        .setPath('models/hdri1/')
        .load(['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png']);


    console.log(elementType, textureMap, metallnessProp, normalMap, normalIntensity, roughnessProp, startingModel)
    const loader = new GLTFLoader();
    
    loader.load(
        // resource URL
        `models/${startingModel}.gltf`,
        // called when resource is loaded
        (gltf) => {

            let elements = gltf.scene.children


     let comps = []
     gltf.scene.children.forEach((component, i) => {
         var obj = component.clone()
               

         comps.push(obj)

     })


            comps.forEach((e, index) => {
                var glass = new THREE.MeshPhongMaterial({
                    color: 0xffffff,
                    envMap: enviroment,
                    refractionRatio: 0.9,
                    depthWrite: false,
                    opacity: 0.4,                       
                    transparent: true
                })

                
                glass.envMap.mapping = THREE.CubeRefractionMapping;

                var chrome = new THREE.MeshStandardMaterial({
                    color: 0xffffff,
                    map: chromeTexture,
                    bumpMap: chromeTexture,
                    bumpScale: 0.1,
                    metalness: 1,
                    envMap: enviroment,
                    envMapIntensity: 5,
                    roughness: 0
                })
                chrome.envMap.mapping = THREE.CubeRefractionMapping;


                var dial = new THREE.MeshStandardMaterial({
                    
                    map: watchFront
                })
                var strap = new THREE.MeshStandardMaterial({ map: strapTexture, bumpMap: strapTexture, bumpScale: 0.1 })

                var handle = new THREE.MeshStandardMaterial({ color: 0xffffff })

                switch (index) {
                    case 0:
                        e.material = dial
                        break;
                    case 1:
                        e.material = chrome
                        break;
                    case 2: 
                        e.material = chrome
                        break;
                    case 3: 
                        e.material = chrome
                        break;
                    case 4:
                        e.children.forEach((elem) => {
                            elem.material = handle
                        })
                        break;
                    case 5:
                        e.material = strap
                        break;
                    case 6:
                        e.material = glass
                        break;
                    case 7:
                        e.material = chrome
                        break;
                    case 8:
                        e.material = strap
                        break;
                    case 9:
                        e.material = strap
                        break;
                }


               

         scene.add(e)
     })
            
            
     

            renderer.render(scene, camera);
        },
        // called when loading is in progresses
        function (xhr) {
            console.log((xhr.loaded / xhr.total * 100) + '% loaded');

        },
        // called when loading has errors
        function (error) {
            console.log('An error happened');

        })
    console.log(scene)  


    // var cubes = []
    // cubes.push(cube)
    // var controls = THREE.DragControls(cubes, camera, renderer.domElement);
    var render = function () {

        requestAnimationFrame(render);
        renderer.render(scene, camera);
    }
    window.addEventListener('click', onMouseClick, false);
    window.addEventListener('mousemove', onMouseMove, false);
    window.addEventListener('mouseup', onDocumentMouseCancel, false);
    render();









}




init();

