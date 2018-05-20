// Write your JavaScript code.

function putPizzaInShoppingCart(dataM) {
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
        data: dataDto,
        success: function (response) {
            if (response.isSuccess)
                dataM.find('input[name="orderPosition.Count"]').val(1);
        }
    });
}

function delPizzaInShoppingCart(dataM) {
    var dataDto = '{"Pizza":{"Id":"' + dataM + '"}}';

    $.ajax({
        type: "POST",
        url: '/ShoppingCart/DelToShoppingCardAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataDto,
        success: function (response) {
            if (response.isSuccess)
                $('#' + dataM).remove();
        }
    });
}

function okOrderInOrderNew(dataM) {
    var dataDto = '{"Pizza":{"Id":"' + dataM + '"}}';

    $.ajax({
        type: "POST",
        url: '/PersonPage/OkOrderInOrderNewAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataDto,
        success: function (response) {
            if (response.isSuccess)
                $('#' + dataM).remove();
        }
    });
}

function delOrderInOrderNew(dataM) {
    var dataDto = '{"Pizza":{"Id":"' + dataM + '"}}';

    $.ajax({
        type: "POST",
        url: '/PersonPage/DelOrderInOrderNewAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataDto,
        success: function (response) {
            if (response.isSuccess)
                $('#' + dataM).remove();
        }
    });
}

function executeOrderInOrderToDelivery(dataM) {
    var dataDto = '{"Pizza":{"Id":"' + dataM + '"}}';

    $.ajax({
        type: "POST",
        url: '/PersonPage/ExecuteOrderInOrderToDeliveryAjax',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: dataDto,
        success: function (response) {
            if (response.isSuccess)
                $('#' + dataM).remove();
        }
    });
}
