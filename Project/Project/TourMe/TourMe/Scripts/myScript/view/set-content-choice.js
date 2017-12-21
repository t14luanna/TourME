function setContentChoice(place,marker) {

    try {

        $('#tags').val(place.Name);

        var avatar = getImages('Place', place.Id)[0];

        if (avatar != undefined) {
            $('.tPlaceInfo-img').attr('src', avatar.Url);
            $('.tPlaceInfo-img').css('display', 'block');
        } else {
            $('.tPlaceInfo-img').css('display', 'none');
        }

        $(".tPlaceInfo-Name")[0].innerHTML = '<span>' + place.Name + '</span>';

        $(".tPlaceInfo-address>span")[0].innerHTML = place.Address;

        var addBtn = document.createElement('button');
        $(addBtn).addClass('add-btn');

        var img = document.createElement('img');
        $(img).attr('src', '../../../Asset/Icons/add_btn.png');

        $(addBtn).append(img);
        $(addBtn).click(function () {
            addChoice(place);

            var image = {
                url: marker.icon.url.substring(0, marker.icon.url.length - 4) + '_active.png',
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(25, 25)
            };

            if (isMobile()) {
                image.scaledSize = new google.maps.Size(60, 60);
                $("#tsideContainer").addClass("thide");
                $("#toverlay").addClass("thide");
            }
            marker.setIcon(image);

            focusPlace(place);

        });

        $(".tPlaceInfo-Name")[0].append(addBtn);

        if (isMobile()) {
            $("#tsideContainer").removeClass("thide");
            $("#toverlay").removeClass("thide");
            changeTab('tsideContent-info');
        }

    } catch (e) {
        console.log(e);
    }
}