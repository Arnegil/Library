// Write your JavaScript code.

function ajaxTest(dataM) {
    var expectedData = '{"Pizza":{"Id":"00000000-0000-1111-0000-000000000001","Name":"Барбекю","Recipe":"Пицца с ветчиной, беконом, пепперони, болгарским перцем и томатным соусом для ценителей мясных деликатесов","Cost":410.0},"Count":1,"Sum":410.0}';

    var dataArray = dataM.serializeArray();
    var dataJson = JSON.stringify(dataArray);
    
    $.ajax({
        type: "POST",
        url: '/Main/AddToShoppingCardAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: expectedData
    });
}