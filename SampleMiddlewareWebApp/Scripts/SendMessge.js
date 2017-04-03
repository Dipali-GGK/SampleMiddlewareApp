
    $("#Send").click(function () {
        var d=$('#msg').val();

        $.ajax({
            type: "POST",
            url: "/Home/Index/"+ d.toString(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                
                alert(data.result);
            }

        });
    });
   
