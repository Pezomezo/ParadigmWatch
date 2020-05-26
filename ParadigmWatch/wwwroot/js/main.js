//The arrow effect
var watch = document.querySelector("#arrowButton");

var position = 0;

//speed
var speed = 15; //px per sec
var framerate = 60; //frames per sec

var last;
function step() {
    // The now preformance
    var now = performance.now();

    //difference = delta on now and last now, and if last exist it uses last or it uses 0 if last does not exist
    var delta = now - last || 0;
    last = now;

    // The 1000 / delta gives the perfect speed at all conditions
    position += speed / (1000 / delta);
    if (position > 12) {
        position = 0;
    }
    watch.style.transform = `translateY(${position}px)`;
    requestAnimationFrame(step);
}
step();

//The scrool effect


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

var slides = document.querySelectorAll('.sliderElement')

var nextButton = document.getElementById('next')
var backButton = document.getElementById('back')

var currentSlide = document.getElementById('currentSlide')

var LearnMoreBTN = document.getElementById('secondaryLink')
var BuildYourOwnBTN = document.getElementById('primaryLink')

var sliderCounter = 0;

var sliderTexts = document.getElementsByClassName('sliderText');

var burgerMenu = document.getElementById('burgerMenu')


for (var sliderCount = 1; sliderCount < sliderTexts.length + 1; sliderCount++) {
    var currentSlider = document.getElementById(`${sliderCount }`)
    
    var currentText = sliderTexts[sliderCount -1].textContent.toLowerCase();

    currentSlider.style.zIndex = `${sliderCount * -1}`
    currentSlider.style.left = '0px'
    currentSlider.style.backgroundSize = 'cover'
    currentSlider.style.backgroundImage = `url(/Images/${currentText}Background.jpg)`
    console.log(`url(/Images/${currentText}Background.jpg)`)

    console.log(document.getElementById(`${sliderCount + 1}`))

}


nextButton.addEventListener('click', () => {
    if (sliderCounter < slides.length - 1) {

        var currentSlider = document.getElementById(`${sliderCounter + 1}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '-100vw'


        currentSlide.textContent = `0${sliderCounter + 2}`
        sliderCounter++
        console.log(sliderCounter)
    } else {
        for (var i = 0; i < slides.length; i++) {
            var slider = document.getElementById(`${i+1}`)
            slider.style.left = '0px'
            sliderCounter = 0;
            currentSlide.textContent = `01`
        }
    }
})

backButton.addEventListener('click', () => {
    if (sliderCounter > 0) {

        var currentSlider = document.getElementById(`${sliderCounter}`)
        currentSlider.style.transition = '1s'
        currentSlider.style.left = '0px'

        currentSlide.textContent = `0${sliderCounter}`
        sliderCounter--
        console.log(sliderCounter)
    } else {
        for (var i = 0; i < slides.length - 1; i++) {
            var slider = document.getElementById(`${i+1}`)
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
    console.log("Slide ID: " +  parseInt(currentSlide.textContent));
    let current = parseInt(currentSlide.textContent);
    let theUrl = '';
    console.log(slides)
    for (let i = 0; i < slides.length; i++) {
        console.log("Inside the loop: ")
        if (slides[i].id == current) {
            console.log("theurl: " + theUrl)
            theUrl = window.location.href + urlMiddle + current.toString();
        }
    }
    window.location.href = theUrl;
}

//Google Maps 

   var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: 10.158886, lng: 56.119607 },
                zoom: 1
            });
        }