$(document).ready(function () {
    $("#selTipoVehiculo").val("-1");
    $("#selServicio").val("-1");
    $("#selRepuesto").val("-1");

    $("#txtRutCliente").change(function () {
        BuscarCliente();
  
    });

});


function BuscarCliente() {
    var rutCliente = $("#txtRutCliente").val();

        $.ajax({
            type: "post",
            url: "BuscarCliente",
            
            data: {
                rutCliente

            },
            async: true,

            success: function (data) {
                if (!data.Validador) {
                    abrirInformacion("Usuario", "Usuario no encontrado, ingrese datos");
                    return null;
                } else {

                    abrirInformacion("Usuario", "Cliente ya registrado");

                    $("#txtNomCliente").val(data.cliente.nombreCliente);
                    $("#txtApeCliente").val(data.cliente.apellidoCliente);
                    $("#txtDirCliente").val(data.cliente.direccionCliente);
                    $("#txtTelCliente").val(data.cliente.telefonoCliente);
                    $("#txtMailCliente").val(data.cliente.correoCliente);

                }



            },
            error: function (a, b, c) {
                console.log(a, b, c);
            },
            async: false




        });
    
}