// Write your JavaScript code.

function ajaxTest(dataM) {
    var id = dataM.find('input[name="orderPosition.Pizza.Id"]').val();
    var name = dataM.find('input[name="orderPosition.Pizza.Name"]').val();
    var recipe = dataM.find('input[name="orderPosition.Pizza.Recipe"]').val();
    var cost = dataM.find('input[name="orderPosition.Pizza.Cost"]').val();
    var count = dataM.find('input[name="orderPosition.Count"]').val();

    var dataDto = '{"Pizza":{"Id":"' + id + '","Name":"' + name + '","Recipe":"' + recipe + '","Cost":' + cost + '},"Count":' + count + '}';

    $.ajax({
        type: "POST",
        url: '/Main/AddToShoppingCardAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataDto
    });
}