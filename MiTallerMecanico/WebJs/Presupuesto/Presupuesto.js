var servicios = [];
var repuestos = [];
var ListaServicios = [];
var ListaRepuestos = [];


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


var contador = 0;
function agregarFilaTablaServicio() {
    var seleccion = $("#selServicio").val(); // obtengo el id del servicio
    var valor = $("#txtValServicio").val(); 
    var cantidad = '1';
    var objeto;
    $.ajax({
        type: "post",
        url: "obtenerServiciosRespuestos",
        data: {

        },
        async: false,
        success: function (data) {
            servicios = data.servicios;
            repuestos = data.repuestos;
            objeto = servicios.find(m => m.idServicio ==seleccion);
           

            var insertar_texto = '<tr id="id_'+contador +'">' + '<th>' + objeto.idServicio + '</th>'
                + '<th>' + objeto.nombreServicio + '</th>' + '<th>' + cantidad + '</th>'
                + '<th>' + valor + '</th>' + '<th> <a id="thservicio" href="#generaTabla" onclick="eliminarFila(' + contador + ');"><img src="../Content/Image/delete.png" /></th > '  ;

            var nuevo_campo = $(insertar_texto);
            $("#generaTabla").append(nuevo_campo);
            
            var agregado = {
                idServicio: objeto.idServicio,
                nombreServicio: objeto.nombreServicio,
                valorServicio: valor

            };
            contador++;
            ListaServicios.push(agregado);

           
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        },
        async: false
    });
   
 

}

function eliminarFila(filaDelete) {

    fila = $('#generaTabla tr[id=id_' + filaDelete + ']'); // paso id del tr  a la variable fila
    ListaServicios = jQuery.grep(ListaServicios, function (value) {
        return value.contador !== filaDelete;
    });

    fila.remove();

}

