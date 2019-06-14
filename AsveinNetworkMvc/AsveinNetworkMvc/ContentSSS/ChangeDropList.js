$(function () {
    //省下拉列表改变事件
    $("#Pid").change(function () {
        $.ajax({
            url: '/Goods/GetDropList?id=' + $(this).val(),
            type: 'get',
            dataType: 'json',
            success: function (data) {
                if (data.length > 0) {
                    $("#Cid").empty();
                    for (var i = 0; i < data.length; i++) {
                        $("#Cid").append("<option value='" + data[i].Id + "'>" + data[i].Name + "</option>");
                    }
                }
            }
        })
    })
})

