﻿//The scrool effect

//REVEAL GENERAL SETTING
window.sr = ScrollReveal({
    reset: true
});

// Custom Settings

sr.reveal('.foo-2', {
    duration: 2000,
    mobile: true
});

sr.reveal('.foo-3', {
    origin: 'left',
    rotate: {
        x: 0,
        y: 100,
        z: 0
    },
    duration: 2000
});

sr.reveal('.foo-5', {
    scale: 10
});

sr.reveal('.foo-6', {
    class: 'h-scroll-reveal',
    duration: 2000,
    scale: 1,
    distance: '20px'
});

let slides = document.querySelectorAll('.sliderElement')

let nextButton = document.getElementById('next')
let backButton = document.getElementById('back')

let currentSlide = document.getElementById('currentSlide')

let sliderCounter = 0;

let sliderTexts = document.getElementsByClassName('sliderText');

let burgerMenu = document.getElementById('burgerMenu')


for (let sliderCount = 1; sliderCount < sliderTexts.length + 1; sliderCount++) {
    let currentSlider = document.getElementById(`${sliderCount }`)
    
    let currentText = sliderTexts[sliderCount -1].textContent.toLowerCase();

    currentSlider.style.zIndex = `${sliderCount * -1}`
    currentSlider.style.left = '0px'
    currentSlider.style.backgroundSize = 'cover'
    currentSlider.style.backgroundImage = `url(/Images/${currentText}Background.jpg)`
    console.log(`url(/Images/${currentText}Background.jpg)`)

    console.log(document.getElementById(`${sliderCount + 1}`))

}


nextButton.addEventListener('click', () => {
    if (sliderCounter < slides.length - 1) {

        let currentSlider = document.getElementById(`${sliderCounter + 1}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '-100vw'


        currentSlide.textContent = `0${sliderCounter + 2}`
        sliderCounter++
        console.log(sliderCounter)
    } else {
        for (let i = 0; i < slides.length; i++) {
            let slider = document.getElementById(`${i+1}`)
            slider.style.left = '0px'
            sliderCounter = 0;
            currentSlide.textContent = `01`
        }
    }
})

backButton.addEventListener('click', () => {
    if (sliderCounter > 0) {

        let currentSlider = document.getElementById(`${sliderCounter}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '0px'

        currentSlide.textContent = `0${sliderCounter}`
        sliderCounter--
        console.log(sliderCounter)
    } else {
        for (let i = 0; i < slides.length - 1; i++) {
            let slider = document.getElementById(`${i+1}`)
            slider.style.left = '-100vw'
            sliderCounter = 2;
            currentSlide.textContent = `03`

        }
    }

})





