let mobile1 = document.getElementById('mobile1')
let mobile2 = document.getElementById('mobile2')
let navContent = document.getElementById('navContent')
let navItem = document.querySelector('nav')


let mobileContainer = document.getElementsByClassName('mobileContainer').item(0)

console.log(mobileContainer)

burgerMenu.addEventListener('click', () => {
    if (mobile1.style.display == '' && mobile2.style.display == '') {
        mobile1.style.display = 'inline-flex'
        mobile2.style.display = 'inline-flex'
        mobileContainer.style.height = '100vh'
        navContent.style.backgroundColor = '#1F2125'
        console.log('clicked')
    } else {
        mobile1.style.display = ''
        mobile2.style.display = ''
        navContent.style.backgroundColor = 'rgba(0,0,0,0)'

        mobileContainer.style.height = '0vh'
    }

})




function navStyle() {
    if (window.innerWidth > 1200 && window.scrollY > 0) {
        navItem.style.transition = '1s';
        navItem.style.backgroundColor = '#1F2125'
    } else {
        navItem.style.backgroundColor = 'rgba(0,0,0,0)'
    }
}

setInterval(navStyle, 100)