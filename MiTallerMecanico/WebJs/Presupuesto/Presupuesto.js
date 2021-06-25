

var Lista = [];


$(document).ready(function () {
    
    
    $("#selServicio").change(function () {
       
        ValorSugerido();

    });
   
    $("#txtRutCliente").change(function () {
        var rut = $("#txtRutCliente").val();

        if (validaRut(rut) == "ok") {
            BuscarCliente();
        } else {
            abrirError("Usuario", "Este rut es incorrecto");
        }

        
  
    });

    $("#txtPatVehiculo").change(function () {
        BuscarVehiculo();

    });
    

});




function checkRut() {
    var sRut1 = document.getElementById("txtRutCliente").value;
    sRut1 = sRut1.replace('-', '');// se elimina el guion
    sRut1 = sRut1.replace('.', '');// se elimina el primer punto
    sRut1 = sRut1.replace('.', '');// se elimina el segundo punto
    sRut1 = sRut1.replace(/k$/, "K");
    document.getElementById("txtRutCliente").value = sRut1;
    //contador de para saber cuando insertar el . o la -
    var nPos = 0;
    //Guarda el rut invertido con los puntos y el gui&oacute;n agregado
    var sInvertido = "";
    //Guarda el resultado final del rut como debe ser
    var sRut = "";
    for (var i = sRut1.length - 1; i >= 0; i--) {
        sInvertido += sRut1.charAt(i);
        if (i == sRut1.length - 1)
            sInvertido += "-";
        else if (nPos == 3) {
            sInvertido += ".";
            nPos = 0;
        }
        nPos++;
    }
    for (var j = sInvertido.length - 1; j >= 0; j--) {
        if (sInvertido.charAt(sInvertido.length - 1) != ".")
            sRut += sInvertido.charAt(j);
        else if (j != sInvertido.length - 1)
            sRut += sInvertido.charAt(j);
    }
    //Pasamos al campo el valor formateado
    document.getElementById("txtRutCliente").value = sRut.toUpperCase();
}

function ValorSugerido() {
    var seleccion = $("#selServicio").val(); // obtengo el id del servicio
    
    $.ajax({
        type: "post",
        url: "obtenerServiciosRespuestos",
        data: {

        },
        async: false,
        success: function (data) {
            servicios = data.servicios;
            objeto = servicios.find(m => m.idServicio == seleccion);

            $("#txtValServicio").val(objeto.valorServicio);



        },
        error: function (a, b, c) {
            console.log(a, b, c);
        },
        async: false
    });

}




function agregarCabecera() {
    var rut = $("#txtRutCliente").val();
    rut = rut.replace('.', '');
    rut = rut.replace('.', '');
    var cabecera = {
        fk_rutCliente:rut,
        fk_patente: $("#txtPatVehiculo").val(),
        fecha: $("#txtFecha").val(),
        observaciones: $("#txtObservaciones").val(),
        estado: "0",
        neto: parseInt($("#txtNeto").val()),
        iva: parseInt($("#txtIVA").val()),
        total:parseInt( $("#txtTotal").val())
    };

    $.ajax({
        type: "post",
        url: "AgregarPresupuesto",
        data: {
            presupuesto: cabecera,
            detalle : Lista
        },
        async: false,
        success: function (data) {
            if (data.Validador==true) {

                abrirInformacion("Usuario", "Presupuesto generado");


            } else {
                abrirError("usuario","presupuesto no generado");

            }

        },
        error: function (a, b, c) {
            console.log(a, b, c);
        }
    });

}



function BuscarCliente(){
    var rutCliente = $("#txtRutCliente").val();
    rutCliente = rutCliente.replace('.', '');
    rutCliente = rutCliente.replace('.', '');
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
    var valor = parseInt($("#txtValServicio").val()); 
    var cantidad = 1;
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
                + '<th>' + formatearNumero(valor,"$") + '</th>' + '<th> <a id="thservicio" href="#generaTabla" onclick="eliminarFila(' + contador + ',' +objeto.idServicio+');"><img src="../Content/Image/delete.png" /></th > '  ;

            var nuevo_campo = $(insertar_texto);
            $("#generaTabla").append(nuevo_campo);
            
            var agregado = {
                id:objeto.idServicio,
                cantidad: cantidad,
                Tipo:'S',
                subTotal: valor,               
                contador: contador
            };
            contador++;
            Lista.push(agregado);
            calculaTabla();
           
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        },
        async: false
    });
   
 

}


function agregarFilaTablaRepuesto() {
    var seleccion = $("#selRepuesto").val(); // obtengo el id del servicio
    var valor = $("#txtValRepuesto").val();
    var cantidad = $("#txtCantRepuesto").val();
    
    var valorFinal = valor * cantidad;
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
            objeto = repuestos.find(m => m.idRepuesto == seleccion);


            var insertar_texto = '<tr id="id_' + contador + '">' + '<th>' + objeto.idRepuesto + '</th>'
                + '<th>' + objeto.nombreRepuesto + '</th>' + '<th>' + cantidad + '</th>'
                + '<th>' + formatearNumero(valorFinal, "$") + '</th>' + '<th> <a id="thservicio" href="#generaTabla" onclick="eliminarFila(' + contador + ');"><img src="../Content/Image/delete.png" /></th > ';

            var nuevo_campo = $(insertar_texto);
            $("#generaTabla").append(nuevo_campo);

            var agregado = {
                id: objeto.idRepuesto,
                cantidad: cantidad,
                Tipo:'R',    
                subTotal:valorFinal,               
                contador:contador
            };
            contador++;
            Lista.push(agregado);
            calculaTabla();

        },
        error: function (a, b, c) {
            console.log(a, b, c);
        },
        async: false
    });

}





function eliminarFila(filaDelete) {

    fila = $('#generaTabla tr[id=id_' + filaDelete + ']'); // paso id del tr  a la variable fila
    Lista= jQuery.grep(Lista, function (value) {
        return value.contador !== filaDelete;
    });

    
    fila.remove();
    calculaTabla();

}



function calculaTabla() {

    var aux = 0;
    var neto = 0;

    var netoTotal = 0;
    var iva;
    var Total;

    for (i = 0; i < Lista.length; i++) {

        aux = Number(aux) + Number(neto);
        neto = Number(aux) + Number(Lista[i].subTotal);

    }
    netoTotal =parseInt(Math.round(neto));
    iva = Math.round( netoTotal * 0.19);
    Total =Math.round(netoTotal + iva);

  

    $("#txtNeto").val(netoTotal);
    $("#txtIVA").val(iva);
    $("#txtTotal").val(Total);
    

}