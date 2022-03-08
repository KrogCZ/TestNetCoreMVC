// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('click', '#btnEdit', function (e) {
    e.stopPropagation();
    $('#editCityModal').modal('show');
    var tr = $(this).parents('tr');
    var id = $(tr).find('#city_Id').val();
    var name = $(tr).find('#city_Name').val();
    var inputName = $('#formEditCity').find('#name');
    var inputId = $('#formEditCity').find('#id');
    var population = $('#formEditCity').find('#population');

    inputName.val(name);
    inputId.val(id);

    $.ajax({
        type: 'POST',
        url: '/Home/GetDetailCity',
        data: { 'id': id },
        success: function (response) {
            $(population).val(response.population);
        },
        failure: function (response) {
            $.fancybox.open('<div class="error"><h2>Error</h2><p>Fail to load data</p></div>');
        },
        error: function (response) {
            $.fancybox.open('<div class="error"><h2>Error</h2><p>Fail to load data</p></div>');
        }
    });
})

$(document).on('click', 'tbody>.rowCity', function () {
    $.ajax({
        type: 'POST',
        url: '/Home/GetDetailCityWithWeather',
        data: { 'id': $(this).find('input[name="city.Id"]').val() },
        success: function (response) {
            $.fancybox.open('<div class="cityDetail"><h2>' + response[0].value.name + '</h2><p>Population: ' + response[0].value.population + '</p>' +
                '<p>Actual weather: ' + response[1].value.temp + '°C</p><p>Wind: ' + response[1].value.wind + '</p><img src="' + response[1].value.icon + '"/></div>');
                
        },
        failure: function (response) {
            $.fancybox.open('<div class="error"><h2>Error</h2><p>Fail to load data</p></div>');
        },
        error: function (response) {
            $.fancybox.open('<div class="error"><h2>Error</h2><p>Fail to load data</p></div>');
        }
    });
});

function stopPropagation(evt) {
    if (typeof evt.stopPropagation == "function") {
        evt.stopPropagation();
    } else {
        evt.cancelBubble = true;
    }
}
