
    $(document).ready(function () {
        $("#CountryId").change(function () {
            var CountryId = $(this).val();
        /*    console.log(CountryId);*/
            $("#StateId").empty();
            $("#StateId").append(`<option value="">--Select State--</option>`);
            $.ajax({
                method: "GET",
                url: "/State/SelectStateList?id=" + CountryId,
                success: function (res) {
                    var data = JSON.parse(res);
                    data.forEach(e => {
                        $("#StateId").append(`<option value="${e.StateId}">${e.StateName}</option>`);
                    })
                }
            })
        })

        $("#StateId").change(function () {

            var StateId = $(this).val();
            
            $("#CityId").empty();
            $("#CityId").append(`<option value="">--Select City--</option>`);
       /*     console.log(StateId);*/
            $.ajax({
                method: "GET",
                url: "/City/SelectCityList?id=" + StateId,
               
                success: function (res) {
                    var data = JSON.parse(res);
                    data.forEach(e => {
                        $("#CityId").append(`<option value="${e.CityId}">${e.CityName}</option>`);
                    })
                   
                }
            })
        })
    });
