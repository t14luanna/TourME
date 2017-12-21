var mainPlace; 

function initAutocomplete(input) {
    autocomplete($('#tags')[0], 2,$('#searchUl')[0]);
}

function choice(place) {
    focusPlace(place);
}

function focusPlace(place) {
    mainPlace = place;
    mainIconType = mainPlace.PlaceKindId;

    mainMap.setCenter({ lat: place.Latitude, lng: place.Longitude });
    currentCenter = mainMap.getCenter();
    mainMap.setZoom(parseInt(place.ZoomSize) + 2);

}

function createLIAutocomplete(place,ul) {
    var li = document.createElement('li');

    var div = document.createElement('div');

    var title = document.createElement('span');
    $(title).addClass('title-result');
    $(title).text(place.label + '   ');
    $(div).append(title);

    var address = document.createElement('span');
    $(address).addClass('address-result');
    $(address).text(place.data.Address);
    $(div).append(address); 

    $(li).append(div);
    $(li).click(function () {
        choice(place.data);
        $(ul).css('display', 'none');
    });
    return li;
}

function isMobile() {
    if (navigator.userAgent.match(/Android/i) ||
        navigator.userAgent.match(/webOS/i) ||
        navigator.userAgent.match(/iPhone/i) ||
        navigator.userAgent.match(/iPad/i) ||
        navigator.userAgent.match(/iPod/i) ||
        navigator.userAgent.match(/BlackBerry/i) ||
        navigator.userAgent.match(/Windows Phone/i))
    {
        return true;
    }

    return false;
}