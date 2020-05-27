//get slide details from the dom
var slides = document.querySelectorAll('.sliderElement')
var nextButton = document.getElementById('next')
var backButton = document.getElementById('back')
var currentSlide = document.getElementById('currentSlide')

//buttons
var LearnMoreBTN = document.getElementById('secondaryLink')
var BuildYourOwnBTN = document.getElementById('primaryLink')

//slider info
var sliderCounter = 0;
var sliderTexts = document.getElementsByClassName('sliderText');

//burger functionalities
var burgerMenu = document.getElementById('burgerMenu')

//arrow animation
const refreshRate = 1000 / 60;
const maxXPosition = 50;
let arrowButton = document.getElementById('arrowButton');
let speedX = 0.4;
let positionX = 0;
function step() {
    positionX = positionX + speedX;
    if (positionX > maxXPosition || positionX < 0) {
        positionX = 0
    }
    arrowButton.style.marginTop = positionX + 'px';
    window.requestAnimationFrame(step);
}
window.requestAnimationFrame(step);
//fill up sliders
for (let sliderCount = 1; sliderCount < sliderTexts.length + 1; sliderCount++) {
    let currentSlider = document.getElementById(`${sliderCount}`)

    let currentText = sliderTexts[sliderCount - 1].textContent.toLowerCase();

    currentSlider.style.zIndex = `${sliderCount * -1}`
    currentSlider.style.left = '0px'
    currentSlider.style.backgroundSize = 'cover'
    currentSlider.style.backgroundImage = `url(/Images/${currentText}Background.jpg)`


}

// slider next button functionality
nextButton.addEventListener('click', () => {
    if (sliderCounter < slides.length - 1) {

        let currentSlider = document.getElementById(`${sliderCounter + 1}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '-100vw'


        currentSlide.textContent = `0${sliderCounter + 2}`
        sliderCounter++
    } else {
        for (let i = 0; i < slides.length; i++) {
            let slider = document.getElementById(`${i + 1}`)
            slider.style.left = '0px'
            sliderCounter = 0;
            currentSlide.textContent = `01`
        }
    }
})
//slider back button funcionalities
backButton.addEventListener('click', () => {
    if (sliderCounter > 0) {

        let currentSlider = document.getElementById(`${sliderCounter}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '0px'

        currentSlide.textContent = `0${sliderCounter}`
        sliderCounter--
    } else {
        for (let i = 0; i < slides.length - 1; i++) {
            let slider = document.getElementById(`${i + 1}`)
            slider.style.left = '-100vw'
            sliderCounter = 2;
            currentSlide.textContent = `03`

        }
    }

})




//  This part is about redirection for the Build and Learn more buttons

BuildYourOwnBTN.addEventListener('click', () => { redirect('ThreeD?watchId=') } );

LearnMoreBTN.addEventListener('click', () => { redirect('ProductPage?watchId=') } );

// ProductPage?watchId=1

function redirect(urlMiddle) {
    let current = parseInt(currentSlide.textContent);
    let theUrl = '';
    for (let i = 0; i < slides.length; i++) {
        if (slides[i].id == current) {
            theUrl = window.location.href + urlMiddle + current.toString();
        }
    }
    window.location.href = theUrl;
}




let sortOrder = document.getElementById('sortOrder');
let oddClick = false;
sortOrder.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    if (oddClick) {

        
        if (theUrl[theUrl.length - 1] == "store") {
            let order = sortOrder.options[sortOrder.selectedIndex].value.toString().substring(0, 1);
            let productList = document.getElementsById('storeDisclaimer')
            if (order == 'Z') {
                productList.style.flexDirection = "column-reverse";
            } else {
                productList.style.flexDirection = "column";
            }
            oddClick = false;
        } else {
            let order = sortOrder.options[sortOrder.selectedIndex].value.toString().substring(0, 1);
            let productList = document.getElementsByClassName('products').item(0)
            if (order == 'Z') {
                productList.style.flexDirection = "row-reverse";
            } else {
                productList.style.flexDirection = "row";
            }
            oddClick = false;
        }
        
    } else {
        oddClick = true;
    }
})

let redirectToStore = document.getElementById('ColumnViewID')
redirectToStore.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}/Store`
    if (!(returnUrl == window.location.href)) {
       window.location.href = returnUrl;
    }
})


let redirectToHome = document.getElementById('GridViewID')
redirectToHome.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}`
    if (!(returnUrl == window.location.href)) {
        window.location.href = returnUrl;
    }
})