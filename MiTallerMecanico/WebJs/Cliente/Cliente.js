

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
                
                var texto = JSON.stringify(data.estado);
                $("#Estado").val(texto);
                $("#txtPreConsulta").attr("hidden", true);
                $('#txtPostConsulta').removeAttr('hidden');

            } else {
                
                $("#Estado").val("Vehiculo no encontrado");
            }


        }

    });

}
