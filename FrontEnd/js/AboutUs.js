var cursor = 0 //$('#tbg').offset().top;//0
var offset = $(document).height() / 5; //$('.tmid-block').height(); //254
//var arr = [false, false, false, false, false ];

$(document).ready(function () {
    scrollPage(0);
    $.when($('.tmid-smallSquare-ver').removeClass('tboxsmall-ver')).done($('.tmid-smallSquare-kind').removeClass('tboxsmall-kind'));

    $('.tmb-right-content').removeClass('tmb-right-content-hide')



    //    $('#tmid').on('mousewheel', function (event, delta) {
    //        console.log('wheeling');
    //        if ($('#tmid').is(':animated')) {
    //            return false;
    //        }
    //        var windowHeight = $(window).height();
    //        if (delta < 0) {
    //            //up
    //            console.log('up cursor: ' + cursor + ' offset: ' + offset)
    //            scrollPage(cursor + offset);
    //        }
    //        if (delta > 0) {
    //            //down
    //            console.log('down cursor: ' + cursor + ' offset: ' + offset)
    //            scrollPage(cursor - offset);
    //        }
    //    });

    $('#tmid').bind('mousewheel', function (e) {
        //cursor = $('#tbg').offset().top;
        //console.log('cursor now: ' + cursor);
        if ($('#tmid').is(':animated')) {
            return false;
        }
        //console.log('wheeling' + ' cursor: ' + cursor + ' offset: ' + offset);
        if (e.originalEvent.wheelDelta / 120 > 0) {
            if ((cursor - offset) >= 0) {
                //console.log('scrolling up ! ' + (cursor - offset));
                scrollPage(cursor - offset);
                cursor = cursor - offset;
            }
        } else {
            if ((cursor + offset) <= (offset * 5)) {
                //console.log('scrolling down ! ' + (cursor + offset));
                scrollPage(cursor + offset);
                cursor = cursor + offset;
                transform(cursor)
            }
        }
    });
});

function changeTo(pos){
    cursor = offset*pos;
    scrollPage(cursor);
    transform(cursor);
}


function scrollPage(pagePosition) {
    $("html, body").animate({
        scrollTop: pagePosition
    }, 1000);
}


function transform(currPos) {
    var anchor = currPos / offset;
    if (anchor == 1) {
        $('.tmb-left-content').removeClass('tmb-left-content-hide');
        $('.tmb-right-content2').removeClass('tmb-right-content-hide2');
    }
}

//$('#tmid').bind('mousewheel', function (e) {
//    //cursor = $('#tbg').offset().top;
//    //console.log('cursor now: ' + cursor);
//    console.log('wheeling' + ' cursor: ' + cursor + ' offset: ' + offset);
//    if (e.originalEvent.wheelDelta / 120 > 0) {
//        if (cursor < 254) {
//            scrollPage(0);
//        }
//        if ((cursor - offset) >= 0) {
//            //console.log('scrolling up ! ' + (cursor - offset));
//            scrollPage(cursor - offset);
//        }
//    } else {
//        if ((cursor + offset) <= (offset * 5)) {
//            //console.log('scrolling down ! ' + (cursor + offset));
//            scrollPage(cursor + offset);
//            console.log($('.tmid-block').height());
//            if ((cursor >= 637 && cursor < 1274) && (tmb2 == false)) {
//                $('.tmb-left-content').removeClass('.tmb-left-content-hide');
//                tmb2 = true;
//            }
//        }
//    }
//});

function sendMessage () {
    var nameField = $('#nametxt').val();
    var emailField = $('#emailtxt').val();
    var titleField = $('#titletxt').val();
    var txtaField = $('#txta').val();
    if(valid(nameField, emailField, titleField, txtaField)){
        //submit code;
        $('#sendBox').append('<p class="tpnofi">Send successful! We will response as soon as possible. Thank you!</p>');
    }
}

function valid(nameField, emailField, titleField, txtaField) {
    var reg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (reg.test(emailField) == false) {
        alert('Invalid Email Address');
        return false;
    }
    if (nameField) {
        if (emailField) {
            if (titleField) {
                if (txtaField) {
                    alert('success!');
                } else return false;
            }
        }else return false;
        
    } else return false;

    return true;
}