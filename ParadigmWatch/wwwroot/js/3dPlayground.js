
import * as THREE from './three.module.js';
import { OBJLoader } from './OBJLoader.js';




function init() {
    var scene = new THREE.Scene();
    scene.background = new THREE.Color(0xFF0000)
    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);


    var light = new THREE.PointLight(0x404040, 10); // soft white light
    light.position.y = 5
    light.position.y = -2
    scene.add(light);


    var renderer = new THREE.WebGLRenderer({ antialias: true });
    renderer.setSize(window.innerWidth / 2, window.innerHeight / 2);
    document.body.appendChild(renderer.domElement);


    camera.position.z = 5;



    const loader = new OBJLoader();
    loader.load(
        // resource URL
        'models/cube.obj',
        // called when resource is loaded
        function (object) {

            scene.add(object);
            console.log(object)

        },
        // called when loading is in progresses
        function (xhr) {

            console.log((xhr.loaded / xhr.total * 100) + '% loaded');

        },
        // called when loading has errors
        function (error) {

            console.log('An error happened');

        })
}




init();