﻿let navItem = document.querySelector('nav')
let slides = document.querySelectorAll('.sliderElement')

let nextButton = document.getElementById('next')
let backButton = document.getElementById('back')

let currentSlide = document.getElementById('currentSlide')

let sliderCounter = 0;


nextButton.addEventListener('click', () => {
    if (sliderCounter < 2) {

        let currentSlider = document.getElementById(`slide${sliderCounter + 1}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '-100vw'

        currentSlide.textContent = `0${sliderCounter + 2}`
        sliderCounter++
        console.log(sliderCounter)
    } else {
        for (let i = 0; i < slides.length; i++) {
            let slider = document.getElementById(`slide${i+1}`)
            slider.style.left = '0px'
            sliderCounter = 0;
            currentSlide.textContent = `01`
        }
    }
})

backButton.addEventListener('click', () => {
    if (sliderCounter > 0) {

        let currentSlider = document.getElementById(`slide${sliderCounter}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '0px'

        currentSlide.textContent = `0${sliderCounter}`
        sliderCounter--
        console.log(sliderCounter)
    } else {
        for (let i = 0; i < slides.length - 1; i++) {
            let slider = document.getElementById(`slide${i+1}`)
            slider.style.left = '-100vw'
            sliderCounter = 2;
            currentSlide.textContent = `03`

        }
    }

})


function navStyle() {
    if (window.scrollY > 0) {
        navItem.style.transition = '1s';
        navItem.style.backgroundColor = '#1F2125'
    } else {
        navItem.style.backgroundColor = 'rgba(0,0,0,0)'
    }
}

setInterval(navStyle, 100)
