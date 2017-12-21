var autocompleteMainMap;

function initAutocomplete(){
  var input = document.getElementById('tags');

  autocompleteMainMap = new google.maps.places.Autocomplete(input);

  // Bind the map's bounds (viewport) property to the autocomplete object,
  // so that the autocomplete requests use the current map bounds for the
  // bounds option in the request.
  autocompleteMainMap.bindTo('bounds', mainMap);

  //Change Place After Search
  autocompleteMainMap.addListener('place_changed', function() {
    var place = autocompleteMainMap.getPlace();
    if (!place.geometry) {
      window.alert("No details available for input: '" + place.name + "'");
      return;
    }

    deleteMarkers();
    createMainMarker(place);
    initNearBySearch(place,'cafe');
    initNearBySearch(place,'point_of_interest');
    initNearBySearch(place,'restaurant');
    initNearBySearch(place,'lodging');

    directionsDisplay.setMap(null);

    mainMap.setCenter(place.geometry.location);
    mainMap.setZoom(16);
  });
}

$(document).ready(function(){
  initAutocomplete();
});
