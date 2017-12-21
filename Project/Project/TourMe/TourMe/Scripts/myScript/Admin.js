function changeView(page) {
    var baseUrl = "/Admin/"
    $('#bodySection').empty();
    //$.ajax(function () {
    //    url: baseUrl + page;
    //});
    $('#bodySection').load(baseUrl + page);
}