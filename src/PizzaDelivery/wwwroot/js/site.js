// Write your JavaScript code.

function ajaxTest(dataM) {
    var dataArray = dataM.serializeArray();
    var dataJson = JSON.stringify(dataArray);

    $.ajax({
        type: "POST",
        url: '/Main/AddToShoppingCardAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataJson
    });
}