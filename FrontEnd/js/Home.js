$('#tSubMap').click(function(){
  alert('run');
  $('#tbtnSwitchSubMap') .toggleClass('tSubMap_open');
});

function switchSubContent(){
  $('#tsubContent') .toggleClass('tsubContent-open');
  $('#tbtnSwitchSubContent') .toggleClass('tbtnSwitchSubContent_right');
  $('#tmainContent').toggleClass('tmainContent-collapse');
}

function changeBackGroundImage(targetId, imageUrl){
  $(targetId).css('background-image', 'url(' + imageUrl + ')');
}

//----------------------------
//Example 1
//
//var gmap = new google.maps.LatLng(10.765974,106.689422);
//var marker;
//function initialize()
//{
//    var mapProp = {
//         center:new google.maps.LatLng(10.765974,106.689422),
//         zoom:16,
//        mapTypeId:google.maps.MapTypeId.ROADMAP
//    };
//
//    var map=new google.maps.Map(document.getElementById("tmainMap")
//    ,mapProp);
//
//  var styles = [
//    {
//      featureType: 'road.arterial',
//      elementType: 'all',
//      stylers: [
//        { hue: '#fff' },
//        { saturation: 100 },
//        { lightness: -48 },
//        { visibility: 'on' }
//      ]
//    },{
//      featureType: 'road',
//      elementType: 'all',
//      stylers: [
//
//      ]
//    },
//    {
//        featureType: 'water',
//        elementType: 'geometry.fill',
//        stylers: [
//            { color: '#adc9b8' }
//        ]
//    },{
//        featureType: 'landscape.natural',
//        elementType: 'all',
//        stylers: [
//            { hue: '#809f80' },
//            { lightness: -35 }
//        ]
//    }
//  ];
//
//  var styledMapType = new google.maps.StyledMapType(styles);
//  map.mapTypes.set('Styled', styledMapType);
//
//  marker = new google.maps.Marker({
//    map:map,
//    draggable:true,
//    animation: google.maps.Animation.DROP,
//    position: gmap
//  });
//  google.maps.event.addListener(marker, 'click', toggleBounce);
//  google.maps.event.addListener(marker, 'click', getPlaceDetail);
//}
//
//function toggleBounce() {
//
//  if (marker.getAnimation() !== null) {
//    marker.setAnimation(null);
//  } else {
//    marker.setAnimation(google.maps.Animation.BOUNCE);
//  }
//}
//
//google.maps.event.addDomListener(window, 'load', initialize);

//Example 2

var point = {lat: 10.7832932, lng:106.3798135};

var map = new google.maps.Map(document.getElementById('tmainMap'), {
  zoom: 10,
  center: point,
  disableDefaultUI: true,

  styles:
  //Multi Brand Style
   [{"featureType":"all","elementType":"labels","stylers":[{"visibility":"on"}]},{"featureType":"all","elementType":"labels.text.fill","stylers":[{"saturation":36},{"color":"#000000"},{"lightness":40}]},{"featureType":"all","elementType":"labels.text.stroke","stylers":[{"visibility":"on"},{"color":"#000000"},{"lightness":16}]},{"featureType":"all","elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"administrative","elementType":"geometry.fill","stylers":[{"color":"#000000"},{"lightness":20}]},{"featureType":"administrative","elementType":"geometry.stroke","stylers":[{"color":"#000000"},{"lightness":17},{"weight":1.2}]},{"featureType":"administrative.country","elementType":"labels.text.fill","stylers":[{"color":"#e5c163"}]},{"featureType":"administrative.locality","elementType":"labels.text.fill","stylers":[{"color":"#c4c4c4"}]},{"featureType":"administrative.neighborhood","elementType":"labels.text.fill","stylers":[{"color":"#e5c163"}]},{"featureType":"landscape","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":20}]},{"featureType":"poi","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":21},{"visibility":"on"}]},{"featureType":"poi.business","elementType":"geometry","stylers":[{"visibility":"on"}]},{"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#e5c163"},{"lightness":"0"}]},{"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"visibility":"off"}]},{"featureType":"road.highway","elementType":"labels.text.fill","stylers":[{"color":"#ffffff"}]},{"featureType":"road.highway","elementType":"labels.text.stroke","stylers":[{"color":"#e5c163"}]},{"featureType":"road.arterial","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":18}]},{"featureType":"road.arterial","elementType":"geometry.fill","stylers":[{"color":"#575757"}]},{"featureType":"road.arterial","elementType":"labels.text.fill","stylers":[{"color":"#ffffff"}]},{"featureType":"road.arterial","elementType":"labels.text.stroke","stylers":[{"color":"#2c2c2c"}]},{"featureType":"road.local","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":16}]},{"featureType":"road.local","elementType":"labels.text.fill","stylers":[{"color":"#999999"}]},{"featureType":"transit","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":19}]},{"featureType":"water","elementType":"geometry","stylers":[{"color":"#000000"},{"lightness":17}]}]
});

// var infowindow = new google.maps.InfoWindow();

// var request = {
//     location: point,
//     radius: '500',
//     type: ['city']
//   };

// var marker, i;

// for (i = 0; i < locations.length; i++) {
//   marker = new google.maps.Marker({
//     position: new google.maps.LatLng(locations[i][1], locations[i][2]),
//     map: map
//   });
//
//   google.maps.event.addListener(marker, 'click', (function(marker, i) {
//     return function() {
//       infowindow.setContent(locations[i][0]);
//       infowindow.open(map, marker);
//     }
//   })(marker, i));
//
// }

function getPlaceDetail(){

}

function createMarker(place) {
        // var placeLoc = place.geometry.location;
        var marker = new google.maps.Marker({
          map: map,
          position: new google.maps.LatLng(place.lat,place.lng)
        });

        google.maps.event.addListener(marker, 'click', function() {
          // infowindow.setContent(place);
          infowindow.open(map, this);
        });
}

function callback(results, status) {
  if (status == google.maps.places.PlacesServiceStatus.OK) {
    for (var i = 0; i < results.length; i++) {
      var place = results[i];
      createMarker(results[i]);
    }
  }
}

//Setup Drop Down
function cusDD(select, style) {
  /*Style Switcher*/
  var ddstyle = "";
  if (!style) {
    ddstyle = "cusDD_default";
  } else if (style == "slick dark") {
    ddstyle = "cusDD_slick_d";
  } else if (style == "slick light") {
    ddstyle = "cusDD_slick_l";
  } else {
    ddstyle = style;
  }

  for (var i = 0; i < $(select).length; i++) {
    var curr = $($(select)[i]);

    //Replace select with div
    curr.addClass(ddstyle+" cusDD").changeElementType("div");

    //put drop downs in a container
    //Replace options with divs
    curr = $($(select)[i]);
    curr.find("option").wrapAll("<div class='cusDD_options' />");
    curr.find("option").addClass("cusDD_opt").each(function() {
      $(this).changeElementType("div");
    });

    //Add selector and drop down
    curr.prepend("<div class='cusDD_select'><div class='cusDD_arrow'></div></div>");

    //Add default option
    var def = (curr.find("div[selected='selected']").length >= 1) ? $(curr.find("div[selected='selected']")) : $(curr.find(".cusDD_opt")[0]);
    curr.find(".cusDD_select").prepend(def.text());

  } //End for loop

  $(document).click(function() {
    $(".cusDD_options").slideUp(200);
    $(".cusDD_arrow").removeClass("active");
  })

  $(select).click(function(e) {
    e.stopPropagation();
    $(this).find(".cusDD_options").slideToggle(200);
    $(this).find(".cusDD_arrow").toggleClass("active");
  })
  $(".cusDD_opt").click(function() {
    $($(this).parent()).siblings(".cusDD_select").contents()[0].nodeValue = $(this).text();
  });

  } // End function)

(function($) {
    $.fn.changeElementType = function(newType) {
        var attrs = {};

        $.each(this[0].attributes, function(idx, attr) {
            attrs[attr.nodeName] = attr.nodeValue;
        });

        this.replaceWith(function() {
            return $("<" + newType + "/>", attrs).append($(this).contents());
        });
    };
})(jQuery);

/* Call the cusDD function on any select elements by ID or Class */
$(document).ready(function() {
  cusDD(".search-list");
});
