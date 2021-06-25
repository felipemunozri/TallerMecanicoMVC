

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
                //$("#Estado").text("Su Vehiculo está " + data.estado);
                $("#Estado").text(data.estado);
                $("#Estado").addClass('text-primary');
                $("#txtPreConsulta").attr("hidden", true);
                $('#txtPostConsulta').removeAttr('hidden');

            } else {
                
                $("#Estado").val("Vehiculo no encontrado");
            }


        }

    });

}
