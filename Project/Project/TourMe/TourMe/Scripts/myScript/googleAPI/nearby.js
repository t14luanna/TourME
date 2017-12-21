//var placesList = document.getElementById('places');
//var placeChoice = document.getElementById('place-choice');
var bounds = new google.maps.LatLngBounds();
var infoContent = $('#info-content');
var tripBook = [];

var markers = [];

var service;
var mainPlace;

var icon = ['restaurant', 'cafe', 'hotel', 'market', 'lodging', 'natural_feature', 'point_of_interest'];

function initNearBySearch(place, type) {

    //$(placesList).empty();

    var request = {
        location: {lat: parseFloat(place.Latitude), lng: parseFloat(place.Longitude)},
        radius: '500',
        type: type
    };

    service.nearbySearch(request, processResults);
}

function processResults(results, status, pagination) {
    if (status !== google.maps.places.PlacesServiceStatus.OK) {
        return;
    } else {
        createMarkers(results);

        if (pagination.hasNextPage) {
            //var moreButton = document.getElementById('more');

            //moreButton.disabled = false;

            //moreButton.addEventListener('click', function () {
            //    moreButton.disabled = true;
            //    pagination.nextPage();
            //});
        }
    }
}

function createMarkers(places) {
    for (var i = 0, place; place = places[i]; i++) {
        createMarker(place);
    }
    // mainMap.fitBounds(bounds);
}

function createMarker(place) {

    var type = checkSupportType(place.types);

    if (type == null) {
        return;
    }

    var image = {
        url: '../Asset/Icons/' + type + '_default.png',
        size: new google.maps.Size(71, 71),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(17, 34),
        scaledSize: new google.maps.Size(25, 25)
    };

    if (checkValidation(place.name)) return;

    var marker = new google.maps.Marker({
        map: mainMap,
        icon: image,
        title: place.name,
        position: place.geometry.location
    });

    markers.push(marker);

    var div = createPlaceLI(place, marker, type);

    var li = document.createElement('li');
    $(li).append(div);

    //$(placesList).append(li);

    bounds.extend(place.geometry.location);

    google.maps.event.addListener(marker, 'click', function () {
        // if(tripBook.indexOf(place)>-1) {
        //   marker.setIcon('icons/' + type + '_default.png');
        // } else {
        //   marker.setIcon('icons/' + type + '_active.png');
        // }
        showInfo(place, marker, type);
        // addPlace(place,marker,type);
    });
}

function createMainMarker(place) {

    var type = checkSupportType(place.types);

    if (type != null) {
        var image = {
            url: 'icons/' + type + '_main.png',
            size: new google.maps.Size(71, 71),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(17, 34),
            scaledSize: new google.maps.Size(25, 25)
        };

        var marker = new google.maps.Marker({
            map: mainMap,
            icon: image,
            title: place.name,
            position: place.geometry.location
        });

        markers.push(marker);

        google.maps.event.addListener(marker, 'click', function () {
            // if(tripBook.indexOf(place)>-1) {
            //   marker.setIcon('icons/' + type + '_main.png');
            // } else {
            //   marker.setIcon('icons/' + type + '_main_active.png');
            // }
            showInfo(place, marker, type);
            // addPlace(place);
        });
    }

    mainPlace = place;

    //var div = createPlaceLI(place, marker, type);

    //var li = document.createElement('li');
    //$(li).append(div);

    //$(placesList).append(li);

    //bounds.extend(place.geometry.location);

}

function checkSupportType(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (icon.indexOf(arr[i]) != -1) return arr[i];
    }
    return null;
}

function checkValidation(name) {
    for (var i = 0; i < markers.length; i++) {
        if (name == markers[i].title) return true;
    }

    return false;
}

function addPlace(place, marker, type) {
    if (tripBook.indexOf(place) > -1) {
        tripBook.splice($.inArray(place, tripBook), 1);
        deletePlace(place);
    }
    else {
        tripBook.push(place);
        showAddedPlace(place, marker, type);
    }
}

function showInfo(place, marker, type) {
    $(infoContent).empty();

    var info = document.createElement('h2');
    $(info).text("Infomation");
    $(infoContent).append(info);

    var title = document.createElement('h3');
    $(title).text("Name : " + place.name);
    $(infoContent).append(title);

    var address = document.createElement('h4');
    $(address).text("Address : " + place.vicinity);
    $(infoContent).append(address);

    if (place.rating != null) {
        var rating = document.createElement('h4');
        $(rating).text("Rating : " + place.rating);
        $(infoContent).append(rating);
    }

    var button = document.createElement('button');
    $(button).addClass('add-button');
    $(button).text('+');
    $(button).click(function () {
        if (tripBook.indexOf(place) < 0) {
            marker.setIcon('icons/' + type + '_active.png');
            tripBook.push(place);
            showAddedPlace(place, marker, type);
        } else {
            alert("You had added");
        }
    });

    $(info).append(button);

}

function showAddedPlace(place, marker, type) {
    var div = document.createElement('div');

    var title = document.createElement('h3');
    $(title).addClass('title');
    $(title).text(place.name);
    $(div).append(title);

    var button = document.createElement('button');
    $(button).addClass('del-button');
    $(button).text('X');
    $(button).click(function () {
        marker.setIcon('icons/' + type + '_default.png');
        tripBook.splice($.inArray(place, tripBook), 1);
        deletePlace(place);
    });

    var li = document.createElement('li');
    $(li).addClass("nearby-component choice-component");
    $(li).attr('id', place.place_id + '-choice');
    $(li).append(div);
    $(li).append(button);

    $(div).click(function () {
        showInfo(place, marker, type);
    });

    $(li).click(function () {
        showInfo(place, marker, type);
    });

    $(placeChoice).append(li);
}

function deletePlace(place, marker) {
    $('#' + place.place_id + '-choice').remove();
}

function createPlaceLI(place, marker, type) {
    var div = document.createElement('div');
    $(div).addClass("nearby-component");
    $(div).attr('id', place.place_id);

    var content = document.createElement('div');
    $(content).addClass("nearby-content");

    var title = document.createElement('h3');
    $(title).addClass('title');
    $(title).text(place.name);
    $(content).append(title);

    var address = document.createElement('span');
    $(address).addClass('address');
    $(address).text(place.vicinity);
    $(content).append(address);

    $(div).append(content);

    var button = document.createElement('button');
    $(button).addClass('add-button');
    $(button).text('+');
    $(button).click(function () {
        if (tripBook.indexOf(place) < 0) {
            marker.setIcon('icons/' + type + '_active.png');
            tripBook.push(place);
            showAddedPlace(place, marker, place);
        } else {
            alert("You had added");
        }
    });

    $(div).append(button);

    $(div).click(function () {
        showInfo(place, marker, type);
    });

    return div;
}

// Sets the map on all markers in the array.
function setMapOnAll(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

// Removes the markers from the map, but keeps them in the array.
function clearMarkers() {
    setMapOnAll(null);
}

// Shows any markers currently in the array.
function showMarkers() {
    setMapOnAll(mainMap);
}

// Deletes all markers in the array by removing references to them.
function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function setMarkerActiveTripBook() {
    for (var i = 0, place; place = tripBook[i]; i++) {
        createTripBookMarker(place);
    }
}

function createTripBookMarker(place) {
    var type = checkSupportType(place.types);

    if (type == null) {
        return;
    }

    var image = {
        url: 'icons/' + type + '_active.png',
        size: new google.maps.Size(71, 71),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(17, 34),
        scaledSize: new google.maps.Size(25, 25)
    };

    var marker = new google.maps.Marker({
        map: mainMap,
        icon: image,
        title: place.name,
        position: place.geometry.location
    });

    markers.push(marker);

    bounds.extend(place.geometry.location);

    google.maps.event.addListener(marker, 'click', function () {
        if (tripBook.indexOf(place) > -1) {
            marker.setIcon('icons/' + type + '_default.png');
        } else {
            marker.setIcon('icons/' + type + '_active.png');
        }
        addPlace(place, marker, type);
    });
}

function InitAll(place) {
    deleteMarkers();
    createMainMarker(place);
    initNearBySearch(place, 'cafe');
    initNearBySearch(place, 'point_of_interest');
    initNearBySearch(place, 'restaurant');
    initNearBySearch(place, 'lodging');

    directionsDisplay.setMap(null);

    mainMap.setCenter(place.geometry.location);
    mainMap.setZoom(16);
}

$(document).ready(function () {
    //$('.filter-btn').click(function () {
    //    if (mainPlace != null) {
    //        deleteMarkers();
    //        initNearBySearch(mainPlace, this.id);
    //        createMainMarker(mainPlace);
    //    }
    //});

    //$('.filter-btn#all').click(function () {
    //    InitAll(mainPlace);
    //});
    //$('#mapping-btn').click(function () {
    //    if (tripBook.length < 2) {
    //        alert("You must choice at least 2 place");
    //        return;
    //    }
    //    deleteMarkers();
    //    setMarkerActiveTripBook();
    //    calculateAndDisplayRoute(directionsService, directionsDisplay, tripBook);
    //});
});
