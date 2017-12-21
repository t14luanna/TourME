var tmp;
var jsono;
var category = 1;
var setcity = 1;

//$(document).ready(function () {
//    console.log('run');
//    while (setcity <= 2) {//129 cities
//        category = 1;
//        while (category <= 14) {//14 categories
//            $.ajax({
//                async: false,
//                url: "https://map.coccoc.com/map/search.json?category=" + category + "&set_city=" + setcity,
//                url: "https://map.coccoc.com/map?borders=10.769811360951389%2C106.70167837846702%2C10.771300112026342%2C106.70534227598137&category=1&bounds_change=true",
//                dataType: "json",
//                success: function (data) {
//                    tmp = data;
//                    //jsono = JSON.parse(data);
//                    insert(data.result.poi);
//                    console.log(category + ' ' + setcity);
//                }
//            });
//            category++;
//            console.log(setcity + ' ' + category);
//        }
//        setcity++;
//        console.log(setcity + ' ' + category);
//    }
//});https://map.coccoc.com/map/search.json?category=9&borders=10.774500000000018%2C106.68200000000002%2C10.775000000000018%2C106.68250000000002bounds_change=true


$(document).ready(function () {
    console.log('run');
    var minLat = 10.7600;
    var maxLat = 10.7800;
    var minLng = 106.6800;
    var maxLng = 106.7100;
    var distance = 0.0005;
    for (var i = minLat; i < maxLat; i += distance) {
        for (var j = minLng; j < maxLng; j += distance) {
            for (var k = 1; k <= 14; k++) {
                $.ajax({
                    async: false,
                    url: "https://map.coccoc.com/map/search.json?category=" + k + "&borders=" + i + "%2C" + j + "%2C" + (i + distance) + "%2C" + (j + distance) + "bounds_change=true",
                    dataType: "json",
                    success: function (data) {
                        // tmp = data;
                        if (data.result.poi.length > 0) {
                            console.log(data.result.poi.length);
                            insert(data.result.poi);
                        }
                        //   console.log(category + ' ' + setcity);
                    }
                });
            }
        }
    }

    
});

function insert(input) {
    tmp = input;
    console.log(input);
    $.ajax({
        async: false,
        type: "post",
        url: "/api/Craw/Insert",
        data: JSON.stringify(input), //JSON.parse(input),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            console.log(inserted);
        }
    });
}
