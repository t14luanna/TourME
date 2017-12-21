//function autocomplete(obj, minLength, ul) {
//    $(obj).on("input", function () {
//        suggest(obj, ul, minLength);
//    });

//    $(obj).focus(function () {
//        $(ul).css('display', 'block');
//    });

//}

//Tien
function autocomplete(obj, minLength, ul) {
    var typingTimer;                //timer identifier
    var doneTypingInterval = 1000;  //time in ms, 5 second for example

    //on keyup, start the countdown
    $(obj).on('keyup', function () {
        clearTimeout(typingTimer);
        typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });

    //on keydown, clear the countdown 
    $(obj).on('keydown', function () {
        clearTimeout(typingTimer);
    });

    //user is "finished typing," do something
    function doneTyping() {
        suggest(obj, ul, minLength);
    }

    $(obj).focus(function () {
        $(ul).css('display', 'block');
    });

}


function suggest(obj, ul, minLength) {
    $(ul).empty();
    if (obj.value.length < minLength) return;
    var result = getPlacesForSearch(obj.value);

    for (var i = 0, place; place = result[i]; i++) {
        $(ul).append(createLIAutocomplete(place,ul));
    }
}