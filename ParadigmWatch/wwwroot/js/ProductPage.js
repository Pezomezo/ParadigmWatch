function PathFormat() {
    let loc = document.getElementById('location')
    let newLoc = loc.textContent.split('/').join(' > ')
    loc.textContent = newLoc;
}
PathFormat()