function PathFormat() {
    let loc = document.getElementById('location')
    console.log(loc.textContent)
    let newLoc = loc.textContent.split('/').join(' > ')
    loc.textContent = newLoc;
    
}
PathFormat()