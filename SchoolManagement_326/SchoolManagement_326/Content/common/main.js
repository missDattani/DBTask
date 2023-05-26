$(document).ready(function () {
    let CountryId;
    let StateId;
    $("#CoId").change(function () {
        $("#CiId").prop("disabled", true);
        CountryId = $(this).val();
        $.get("/State/SelectStateList", { CoId: CountryId }, function (data) {
            $("#StId").empty();
            $("#StId").append(`<option value="">--Select State--</option>`);

            $.each(data, function (index, row) {
                $("#StId").append(`<option value="${row.StId}">${row.StateName}</option>`);
            })
        })
    })



    $("#StId").change(function () {
        $("#CiId").prop("disabled", false);
        StateId = $(this).val();
        $.get("/City/SelectCityList", { CoId: CountryId, StId: StateId }, function (data) {

            $("#CiId").empty();
            $("#CiId").append(`<option value="">--Select City--</option>`);

            $.each(data, function (index, row) {
                $("#CiId").append(`<option value="${row.CiId}">${row.CityName}</option>`);
            })
        })
    })



});