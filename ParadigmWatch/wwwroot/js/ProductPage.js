//Format Url path on roduct page left top corner
function PathFormat() {
    let loc = document.getElementById('location')
    let WatchName = document.getElementById('WatchName')
    let newLoc = loc.textContent.split('/')
    newLoc.push(WatchName.textContent)

    loc.textContent = newLoc.join(' > ');
    
}
PathFormat()

//populate thumbnail images
let component = document.getElementsByClassName('component')
let thumbnails = document.getElementsByClassName('thumbnails')

for (let e = 0; e < component.length; e++) {
    component.item(e).style.background = `url(${thumbnails.item(e).textContent})`
    component.item(e).style.backgroundSize = 'cover'
    component.item(e).style.backgroundRepeat = 'no-repeat'
}
//populat main thumbnail
let BigThumbnail = document.getElementsByClassName('BigThumbnail').item(0).textContent
let hlContainer = document.getElementsByClassName('hlContainer').item(0)
hlContainer.style.background = `url(${BigThumbnail})`
hlContainer.style.backgroundSize = 'cover'
hlContainer.style.backgroundRepeat = 'no-repeat'