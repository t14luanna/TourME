function getPlaces() {
    var places = [];
    $.ajax({
        url: "/api/Place/Get",
        dataType: "json",
        async: false,
        success: function (data) {
            places = data;
        },
        error: function (err) {
            console.log(err);
        }
    });
    return places;
}

function getPlacesNearby(lng, lat, distance, scope) {
    var places = [];
    $.ajax({
        url: "/api/Place/GetNearBy",
        dataType: "json",
        async: false,
        data: {
            'objlng': lng,
            'objlat': lat,
            'distance': distance,
            'scope': scope
        },
        success: function (data) {
            places = data;
        },
        error: function (err) {
            console.log(err);
        }
    });
    return places;
}

function getPlacesForSearch(query) {
    var arr = [];
    $.ajax({
        url: "/api/Place/GetPlacesByPopular",
        dataType: "json",
        async: false,
        data: { 'search': query },
        success: function (data) {
            $.each(data, function (index, object) {
                arr.push(
                    {
                        id: object.Id,
                        label: object.Name,
                        data: object
                    }
                );
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
    return arr;
}