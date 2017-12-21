function getImages(kind, ownId) {
    var images = [];
    $.ajax({
        url: "/api/Image/GetImage",
        dataType: "json",
        async: false,
        data: {
            'ObjectKind': kind,
            'ownId': ownId
        },
        success: function (data) {
            images = data;
        },
        error: function (err) {
            console.log(err);
        }
    });
    return images;
}