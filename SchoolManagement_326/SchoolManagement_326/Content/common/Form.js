$(document).ready(function () {
    let CountryId;
    let StateId;
    $("#CountryId").change(function () {
       
        CountryId = $(this).val();
        $.get("/State/SelectStateList", { CoId: CountryId }, function (data) {
            $("#StateId").empty();
            $("#StateId").append(`<option value="">--Select State--</option>`);

            $.each(data, function (index, row) {
                $("#StateId").append(`<option value="${row.StId}">${row.StateName}</option>`);
            })
        })
    })

    $("#StateId").change(function () {
        //debugger;
        StateId = $(this).val();
        $.get("/City/SelectCityList", { CoId: CountryId, StId: StateId }, function (data) {
            //debugger;
            $("#CityId").empty();
            $("#CityId").append(`<option value="">--Select City--</option>`);

            $.each(data, function (index, row) {
                $("#CityId").append(`<option value="${row.CiId}">${row.CityName}</option>`);
            })
        })
    })

});