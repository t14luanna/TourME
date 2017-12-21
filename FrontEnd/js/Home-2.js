//---------------------------------------------------------------------------
//Init

function initButtonCollapse(){
  var collapses = $(".collapse-in");

  for (var i = 0; i < collapses.length; i++) {
      var btn = collapses[i];

      setButtonCollapseIn(btn);
  }

  var collapses = $(".collapse-out");

  for (var i = 0; i < collapses.length; i++) {
      var btn = collapses[i];

      setButtonCollapseOut(btn);
  }
}

function setButtonCollapseIn(btn){
  $(btn).click(function(){
    var parent = $(btn).parent('.tSide');
    var classParent = parent.attr('class').split(' ');
    parent.css('display','none');
    console.log($('#' + classParent[classParent.length-1]));
    $('#' + classParent[classParent.length-1]).css('display','block');
  });
}

function setButtonCollapseOut(btn){
  $(btn).click(function(){
    $('.' + btn.id).css('display','block');
    $(btn).css('display','none');
  });
}

function init(){
  initButtonCollapse();
}

//---------------------------------------------------------------------------
//Popup Tour book

//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
//---FB APIs

//FB Login

$(document).ready(function(){
  init();
});
