var servicios = [];
var repuestos = [];
var agregados = [];

$(document).ready(function () {
    
    
    $("#selRepuesto").val("-1");

    $("#txtRutCliente").change(function () {
        BuscarCliente();
  
    });

    $("#txtPatVehiculo").change(function () {
        BuscarVehiculo();

    });
    

});




function BuscarCliente(){
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

                    $("#txtNomCliente").val("");
                    $("#txtApeCliente").val("");
                    $("#txtDirCliente").val("");
                    $("#txtTelCliente").val("");
                    $("#txtMailCliente").val("");

                    
                } else {
                    abrirInformacion("Usuario", "vehiculo ya registrado");
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

function BuscarVehiculo() {
    var patente = $("#txtPatVehiculo").val();
    $.ajax({
        type: "post",
        url: "BuscarVehiculo",
        data: {
            patente
        },
        async: true,
        success: function (data) {
            if (!data.Validador) {
                abrirInformacion("Usuario", "vehiculo  no encontrado, ingrese datos");

                $("#selTipoVehiculo").val("-1");
                $("#txtMarVehiculo").val("");
                $("#txtModVehiculo").val("");
                $("#txtColorVehiculo").val("");
                $("#txtAnoVehiculo").val("");
                $("#txtKilVehiculo").val("");
               
            } else {

                abrirInformacion("Usuario", "vehiculo ya registrado");

                $("#selTipoVehiculo").val(data.vehiculo.fk_idTipoVehiculo);
                $("#txtMarVehiculo").val(data.vehiculo.marca);
                $("#txtModVehiculo").val(data.vehiculo.modelo);
                $("#txtColorVehiculo").val(data.vehiculo.color);
                $("#txtAnoVehiculo").val(data.vehiculo.ano);
                $("#txtKilVehiculo").val(data.vehiculo.kilometraje);
            }
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        },
        async: false
    });
}



//function agregarFilaTablaServicio() {

//    var servicio = $("#selServicio").val();
//    var valorServicio = $("#txtValServicio").val();
//    var cantidad = ("1");

//    if (servicio == "-1" || valorServicio=="" || cantidad=="") {
//        abrirError("Error datos", "Favor,Complete todos los campos para continuar");

//    } else {
//        var contador = 0;

//        var texto_insertar =
//            '<tr id="id_' + contador + '" class=thproductolist' + contador + '">'
//            + '<td><span id="lblCodigo_'+ contador + '">' + codigo   

//    }

 

//}

