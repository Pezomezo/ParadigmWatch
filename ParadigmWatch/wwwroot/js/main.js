//get slide details from the dom
var slides = document.querySelectorAll('.sliderElement')
var nextButton = document.getElementById('next')
var backButton = document.getElementById('back')
var currentSlide = document.getElementById('currentSlide')


// I get the buttons from which I will redirect

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


// This method takes in the part of a url we are redirecting to from the base url
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



//This part handles the sorting of the Alphabetic order
// First off I get the Select element from the view
let sortOrder = document.getElementById('sortOrder');
//I initiate a boolean with false so I can detect every second click on the object
let oddClick = false;
sortOrder.addEventListener('click', () => {
    // I take in the url and seperate it by / 
    let theUrl = window.location.href.split("/")
    if (oddClick) {
        // This if else handles the logic so the program knows of it is part of the Store or the Home page
        if (theUrl[theUrl.length - 1] == "store") {
            //I take in the selected option inside the Select and take its value which is either A-Z or Z-A
            let order = sortOrder.options[sortOrder.selectedIndex].value.toString().substring(0, 1);
            // This element holds the list of our watches
            let productList = document.getElementsById('storeDisclaimer')
            // If the order starts with Z we reverse the list of the watches otherwise we set it to normal
            if (order == 'Z') {
                productList.style.flexDirection = "column-reverse";
            } else {
                productList.style.flexDirection = "column";
            }
            oddClick = false;
        }
        else {
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


// Here I take in the Column gui element and if we cluck it we get redirected depentent on which url are we on to the Store or we are staying 
let redirectToStore = document.getElementById('ColumnViewID')
redirectToStore.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}/Store`
    if (!(returnUrl == window.location.href)) {
       window.location.href = returnUrl;
    }
})

// Here I take in the Column gui element and if we cluck it we get redirected depentent on which url are we on to the Home or we are staying 
let redirectToHome = document.getElementById('GridViewID')
redirectToHome.addEventListener('click', () => {
    let theUrl = window.location.href.split("/")
    let returnUrl = `${theUrl[0]}//${theUrl[2]}`
    if (!(returnUrl == window.location.href)) {
        window.location.href = returnUrl;
    }
})