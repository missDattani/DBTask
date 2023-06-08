$(document).ready(function () {
    $("#CountryId").change(function () {
        var cId = $(this).val();
        $.ajax({
            type: "post",
            url: "/Student/GetStateList?CountryId=" + cId,
            contentType: "html",
            success: function (res) {
                $("#StateId").empty();
                $("#StateId").append(res);
            }
        })
    })

    $("#StateId").change(function () {
        var sId = $(this).val();
        $.ajax({
            type: "post",
            url: "/Student/GetCityList?StateId=" + sId,
            contentType: "html",
            success: function (res) {
                $("#CityId").empty();
                $("#CityId").append(res);
            }
        })
    })
})