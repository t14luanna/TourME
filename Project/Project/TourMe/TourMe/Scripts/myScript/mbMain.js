$("#tsearchIcon").click(function () {
    $("#tsearch-div").toggleClass("thide");
});

$("#thamburgerIcon").click(function () {
    $("#tsideContainer").removeClass("thide");
    $("#toverlay").removeClass("thide");
});

$("#closeSideContainer").click(function () {
    $("#tsideContainer").addClass("thide");
    $("#toverlay").addClass("thide");
});

$("#toverlay").click(function () {
    $("#tsideContainer").addClass("thide");
    $("#toverlay").addClass("thide");
});

function changeTab(divId) {
    $('.tsideContent-content').css('display', 'none');
    $('#' + divId).css('display', 'block');
}