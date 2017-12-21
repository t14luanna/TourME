var currentCenter;
var maxDistance = 0.05;
var distanceNear = 0.1;
var addedList = $('#tourBook-content');
var markers = [];

var linkIcon = "../../../Asset/Icons/";
var mainIconType = -1;
var icon = ['Country', 'City', 'Address', 'Cafe', 'Hotel', 'Market', 'Education', 'Point_of_interested', 'Health','Entertaiment', 'Gas', 'ATM', 'NightLife', 'Service', 'Restaurant','Spa'];
var tripBook = [];

function initNearBySearch() {
    currentCenter = mainMap.getCenter();

    mainMap.addListener('center_changed', function () {

        var lat = mainMap.getCenter().lat();
        var lng = mainMap.getCenter().lng();
        if (Math.abs(lat - currentCenter.lat()) >= (maxDistance / mainMap.getZoom()*2) ||
            Math.abs(lng - currentCenter.lng()) >= (maxDistance / mainMap.getZoom()*2)) {
            currentCenter = mainMap.getCenter();
            findNearPlace();
            createTripBookMarkers();
        }
    });
}

function createMarker(place, markerType) {
    var image = {
        url: linkIcon + icon[place.PlaceKindId],
        size: new google.maps.Size(71, 71),
        origin: new google.maps.Point(0, 0),
        anchor: new google.maps.Point(17, 34),
        scaledSize: new google.maps.Size(25, 25)
    };

    if (isMobile()) {
        image.scaledSize = new google.maps.Size(60, 60);
    }

    if (markerType == 1) {
        image.url += '_main.png';
    } else {
        image.url += "_default.png";
    }

    var marker = new google.maps.Marker({
        map: mainMap,
        icon: image,
        title: place.name,
        position: { lat: place.Latitude, lng: place.Longitude }
    });

    marker.addListener("click", function () {
        image.url = marker.icon.url.substring(0, marker.icon.url.length - 4) + '_active.png';
        marker.setIcon(image);

        setContentChoice(place,this);
        focusPlace(place);
    });

    if (markerType == 1) {
        setContentChoice(place, marker);
    }

    markers.push(marker);

    return marker;
}

function findNearPlace() {

    clearMarkers();

    var places = [];

    if (mainIconType == -1) {
    //    for (var i = 0; i < icon.length; i++) {
    //        var temp = getPlacesNearby(currentCenter.lng(), currentCenter.lat(), distanceNear, i);
    //        for (var j = 0; j < temp.length; j++) places.push(temp[j]);
    //    }
        places = [];       
    }
    else {
        places = getPlacesNearby(currentCenter.lng(), currentCenter.lat(), distanceNear*2 / mainMap.getZoom(), mainIconType);
    }

    $('.nearby-list').empty();

    for (var i = 0, place; place = places[i]; i++) {
        createNearByLI(place, i, createMarker(place, 0));
        //if (place.Id != mainPlace.Id && tripBook.indexOf(place) < 0) {
            
        //}
    }

    createMarker(mainPlace, 1);
    createTripBookMarkers();
}

function createNearByLI(place, line, marker) {
    var div = document.createElement('div');
    $(div).addClass('eventBlock');   
    if (line % 2 == 0) {
        $(div).addClass('graybg');  
    }

    //var addBtn = document.createElement('button');
    //$(addBtn).addClass('add-btn add-btn-list');

    //var img = document.createElement('img');
    //$(img).attr('src', '../../../Asset/Icons/add_btn.png');

    //$(addBtn).append(img);
    //$(addBtn).click(function () {
    //    addChoice(place);
    //    marker.setIcon(marker.icon.url.substring(0, marker.icon.url.length - 4) + '_active.png');
    //});
    //$(div).append(addBtn);


    var title = document.createElement('h4');
    $(title).text(place.Name + '   ');
    $(div).append(title);

    var address = document.createElement('h5');
    $(address).text(place.Address + '   ');
    $(div).append(address);

    $(div).click(function () {
        setContentChoice(place, marker);
        focusPlace(place);
        $($('.tab__content').find('.active')[0]).removeClass('active').css('display', 'none');
        $($('.tabs').find('.active')[0]).removeClass('active');
        $('.info-tab').addClass('active').css('display', 'list-item');
    });

    $('.nearby-list').append(div);
}

function changeKind(kind) {
    mainIconType = kind;
    findNearPlace();

    if (isMobile()) {
        $("#tsideContainer").removeClass("thide");
        $("#toverlay").removeClass("thide");
        changeTab('tsideContent-nearby');
    } else {
        $($('.tab__content').find('.active')[0]).removeClass('active').css('display', 'none');
        $($('.tabs').find('.active')[0]).removeClass('active');
        $('.nearby-tab').addClass('active').css('display', 'list-item');
    }
}

function addChoice(place) {
    $('#rightDiv-tourBook').removeClass('closingrightDiv-tourBook');
    if (tripBook.indexOf(place) >= 0) {
        alert("Added place");
        return;
    }
    tripBook.push(place);
    addInfoLI(place);    
}

function addInfoLI(place) {
    var div = document.createElement('div');
    $(div).addClass('lineblock');
    $(div).attr('id', place.Id + '-choice');
    $(title).click(function () {
        setContentChoice(place);
    });

    var title = document.createElement('span');
    $(title).text(place.Name);
    $(div).append(title);

    var closeBtn = document.createElement('img');
    $(closeBtn).addClass('deleteTourBookLine');
    $(closeBtn).attr('src', '../../../Asset/Icons/close.png');

    $(closeBtn).click(function () {
        deleteInfoLI(place);
    });

    $(div).append(closeBtn);    

    $(addedList).append(div);
}

function deleteInfoLI(place) {
    $('#' + place.Id + '-choice').remove();
    tripBook.splice($.inArray(place, tripBook), 1);
}

function setMapOnAll(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

// Removes the markers from the map, but keeps them in the array.
function clearMarkers() {
    setMapOnAll(null);
    markers = [];
    createTripBookMarkers();
}

// Shows any markers currently in the array.
function showMarkers() {
    setMapOnAll(mainMap);
}

// Deletes all markers in the array by removing references to them.
function deleteMarkers() {
    clearMarkers();
}

function createTripBookMarkers() {
    for (var i = 0, place; place = tripBook[i]; i++) {
        createMarker(place, 1);
    }
}

$(document).ready(function () {
    initNearBySearch();
});