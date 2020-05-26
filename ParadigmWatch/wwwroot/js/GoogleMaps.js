//Google Maps 

var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 10.158886, lng: 56.119607 },
        zoom: 1
    });
}