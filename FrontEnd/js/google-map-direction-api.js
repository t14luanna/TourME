var directionsService = new google.maps.DirectionsService;
var directionsDisplay = new google.maps.DirectionsRenderer;

function calculateAndDisplayRoute(directionsService, directionsDisplay, tripBook) {
  var waypts = [];

  if(tripBook.length<2) {
    directionsDisplay.setMap(null);
    return;
  } else {
    directionsDisplay.setMap(mainMap);
  }

  for (var i = 1; i < tripBook.length-1; i++) {
      waypts.push({
        location: tripBook[i].geometry.location,
        stopover: true
      });
  }

  directionsService.route({
    origin: tripBook[0].geometry.location,
    destination: tripBook[tripBook.length-1].geometry.location,
    waypoints: waypts,
    optimizeWaypoints: true,
    travelMode: 'DRIVING'
  }, function(response, status) {
    if (status === 'OK') {
      directionsDisplay.setDirections(response);
      var route = response.routes[0];
      var div = document.getElementById('directions-panel');
      $(div).empty();
      // For each route, display summary information.
      for (var i = 0; i < route.legs.length; i++) {
        var routeSegment = i + 1;
        var summaryPanel = document.createElement('div');
        $(summaryPanel).addClass('stage');
        summaryPanel.innerHTML = '';
        summaryPanel.innerHTML += '<h3>Step: ' + routeSegment +
        '</h3><br>';
        summaryPanel.innerHTML += '<h4> Start : ' + route.legs[i].start_address + '</h4> </br>';
        summaryPanel.innerHTML += '<h4> End : ' + route.legs[i].end_address + '</h4> <br>';
        summaryPanel.innerHTML += '<h4> Distance : ' + route.legs[i].distance.text + '</h4> </br>';
        summaryPanel.innerHTML += '<h4> Time : ' + route.legs[i].duration.text + '</h4> </br>';
        $(div).append(summaryPanel);
      }
    } else {
      window.alert('Directions request failed due to ' + status);
    }
  });
}
