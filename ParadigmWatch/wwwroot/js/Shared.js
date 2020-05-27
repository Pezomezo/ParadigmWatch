let mobile1 = document.getElementById('mobile1')
let mobile2 = document.getElementById('mobile2')
let navContent = document.getElementById('navContent')
let navItem = document.querySelector('nav')

let mobileContainer = document.getElementsByClassName('mobileContainer').item(0)
//burger menu funcionality
burgerMenu.addEventListener('click', () => {
    if (mobile1.style.display == '' && mobile2.style.display == '') {
        mobile1.style.display = 'inline-flex'
        mobile2.style.display = 'inline-flex'
        mobileContainer.style.height = '100vh'
        navContent.style.backgroundColor = '#1F2125'
    } else {
        mobile1.style.display = ''
        mobile2.style.display = ''
        navContent.style.backgroundColor = 'rgba(0,0,0,0)'

        mobileContainer.style.height = '0vh'
    }

})
//fade on scroll effect
function navStyle() {
    if (window.innerWidth > 1200 && window.scrollY > 0) {
        navItem.style.transition = '1s';
        navItem.style.backgroundColor = '#1F2125'
    } else {
        navItem.style.backgroundColor = 'rgba(0,0,0,0)'
    }
}

setInterval(navStyle, 100)

let logo = document.getElementsByClassName('logo').item(0)

logo.addEventListener('click', () => {
    let url = window.location.href.split('/')
    let rawurl = url.slice(0, -1)
    let newurl = `${rawurl[0]}//${rawurl[2]}/`
    window.location.href = newurl
})
