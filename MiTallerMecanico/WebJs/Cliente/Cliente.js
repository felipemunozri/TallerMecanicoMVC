

function EstadoVehiculo() {

    var patente = $("#txtPatente").val();
    $.ajax({
        type: "POST",
        url: "EstadoVehiculo",
        data:
        {
            patente
        },
        async: true,
        success: function (data) {

            if (data.Validador==true) {
                
                //var texto = JSON.stringify(data.estado);
                $("#Estado").text("Su Vehiculo esta : "+ data.estado);
                $("#txtPreConsulta").attr("hidden", true);
                $('#txtPostConsulta').removeAttr('hidden');

            } else {
                
                $("#Estado").val("Vehiculo no encontrado");
            }


        }

    });

}
