//var firebase = new Firebase("https://brilliant-heat-5290.firebaseio.com/");


//firebase.remove();

//var spots = [
//        { lat: 43.05, lng: -89.421 },
//];

//spots.push({ lat: 45.05, lng: -88.421 })

var markers = [];
//markers.push({ lat: 43.05, lng: -89.421 });
//markers.push({ lat: 45.05, lng: -88.421 });
//markers.push({ lat: 46.05, lng: -88.421 });
//markers.push({ lat: 47.05, lng: -88.421 });

var counter = 1;
var jsonPath = "../../Kao.json"
var map;
var marker;
var contentString =
      '<div id="content">' +
      '<img src= "../../fish.JPG" alt="HTML5 Icon" style="width:300px;height:200px;">' +
      '</div>';
      



window.initMap = function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 43.071158333333337, lng: -87.899497222222223 }
    });
    $.getJSON(jsonPath, function (json1) {
        $.each(json1, function (key, data) {
            
            var latLng = new google.maps.LatLng(data.lat, data.lng);
            // Creating a marker and putting it on the map
            var marker = new google.maps.Marker({
                position: latLng,
                title: data.title
            });           
            //var infowindow = new google.maps.InfoWindow({                
            //    content: contentString
            //        //+ counter
            //});
            marker.addListener('click', function () {
                infowindow.open(map, marker);
            });
            marker.addListener('click', function () {
                map.setZoom(8);
                map.setCenter(marker.getPosition());
            });
            marker.setMap(map);
            markers.push(latLng);           
            counter++;
        });
    });
    //for (var i = 0; i < markers.length; i++) {
    //    firebase.push(markers[i]);
    //}
    


    //map.addListener('click', function(e) {
    //    firebase.push({lat: e.latLng.lat(), lng: e.latLng.lng()});
    //});

    //for (var i = 0; i < markers.length; i++) {
    //        marker = new google.maps.Marker({
    //        position: markers[i],
    //        map: map,
    //        title: 'Spot! '+[i + 1]
    //        });

    //marker.addListener('click', function () {
    //    infowindow.open(map, marker);
    //});

    


    //firebase.on("child_added", function (snapshot, prevChildKey) {
    //    // Get latitude and longitude from Firebase.
    //    var newPosition = snapshot.val();

    //    // Create a google.maps.LatLng object for the position of the marker.
    //    // A LatLng object literal (as above) could be used, but the heatmap
    //    // in the next step requires a google.maps.LatLng object.
    //    var latLng = new google.maps.LatLng(newPosition.lat, newPosition.lng);

    ////    // Place a marker at that location.
    ////    marker = new google.maps.Marker({
    ////        position: latLng,
    ////        map: map
    ////    });
    //});

    //google.maps.event.addDomListener(mapDiv, 'click', function () {
    //    window.alert('Map was clicked!');
    //});

}

//function drop() {
//    clearMarkers();
//    for (var i = 0; i < spots.length; i++) {
//        addMarkerWithTimeout(spots[i], i * 200);
//    }
//}

//function addMarkerWithTimeout(position, timeout) {
//    window.setTimeout(function () {
//        markers.push(new google.maps.Marker({
//            position: position,
//            map: map,
//            title: 'Fish Spot!',
//            animation: google.maps.Animation.DROP
//        }));
//    }, timeout);
//}

//function clearMarkers() {
//    for (var i = 0; i < markers.length; i++) {
//        markers[i].setMap(null);      
//    }
//    markers = [];
//}
