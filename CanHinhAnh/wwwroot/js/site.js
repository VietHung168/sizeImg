$('input[type="checkbox"]').on('change', function() {
    $('input[name="' + this.name + '"]').not(this).prop('checked', false);
});

function getdata() {

    var link = $("#link").val();
  //  alert(link);

    $.ajax({
        url: '/Home/Check',
        type: 'GET',
        data: {
            link: link
        },
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            var data = JSON.parse(response);
            console.log(data)

            //$('#toy-grid').load('ProductCate/LoadToyBoxes', {
            //    aPList: data
            //});
        },
        error: function () {
        }
    })

}