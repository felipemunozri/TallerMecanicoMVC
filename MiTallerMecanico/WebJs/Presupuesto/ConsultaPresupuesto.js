
var datosDetalle = 0;


$(document).ready(function () {

    $("#txtCantidad").change(function () {
        var cantidad = $("#txtCantidad").val();
        var subtotal = $("#txtSubtotal").val();
        var total = Number(cantidad) * Number(subtotal);
        $("#txtTotal").val(total);
    });

    $("#txtSubtotal").change(function () {

        var subtotal = $("#txtSubtotal").val();

        $("#txtTotal").val(subtotal);

    });


});

function DetallePresupuesto (IdPresu) {
    var tableCabecera = $("#tblDetallePresupuesto");
    var tableDetalle = $("#tblDetallePresupuestoDetalle");
    var htmlDetalle = "";
    var htmlCabecera = "";
    var netototal = 0;
    var iva = 0;
    var total = 0;
    $.ajax({
        type: "POST",
        url: "DetallePresupuesto",
        data: { _IdPresu: IdPresu },
        async: true,
        success: function (data) {
            if (data.Mensaje == 1) {
                alert("No se encontró el documento.");
            }
            else {
                $("#tblDetallePresupuesto").html("");
                $("#tblDetallePresupuestoDetalle").html("");

                $.each(data.Cabecera, function (index, value) {

                    netototal = value.neto;
                    iva = value.iva;
                    total = value.total;

                    if (value.observaciones==null || value.observaciones==" ") {
                        value.observaciones = "No existe observación";

                    }

                    htmlCabecera = "<tr><th>N&ordm;Presupuesto.</th>" +
                        "<td>" + value.folioEncabezado + "</td>"+
                        "<th nowrap='nowrap'>Fecha.</th>"+
                        "<td>" + value.fecha + "</td></tr>" +

                        "<tr><th nowrap='nowrap'>Cliente.</th>" +
                        "<td>" + value.Nombre+"</td>" +
                        "<th nowrap='nowrap'>Rut.</th>" +
                        "<td>" + value.rutCliente + "</td>" +
                        "<th nowrap='nowrap'>Telefono</th>" +
                        "<td>" +"+56 "+ value.telefonoCliente + "</td>" +
                        "<td></td>" +
                        "<td></td></tr>" +

                        "<tr><th nowrap='nowrap'>Patente</th>" +
                        "<td>" + value.patente + "</td>" +
                        "<th nowrap='nowrap'>Marca</th>" +
                        "<td>" + value.marca + "</td>" +
                        "<th nowrap='nowrap'>Modelo</th>" +
                        "<td>" + value.modelo + "</td>" +
                        "<td></td>" +
                        "<td></td></tr>" +

                        "<tr><th nowrap='nowrap'>Año.</th>" +
                        "<td>" + value.ano + "</td>" +
                        "<th nowrap='nowrap'>Kilometraje</th>" +
                        "<td>" + formatearNumero(value.kilometraje)+ "</td>" +
                        "<td></td>" +
                        "<td></td>" +
                        "<td></td></tr>" +

                        "<tr><th nowrap='nowrap'>Observacion</th>" +
                        "<td>" + value.observaciones + "</td>" +
                        "<td></td>" +
                        "<td></td>" +
                        "<td></td></tr>";
                    tableCabecera.append(htmlCabecera);
                });

                htmlDetalle = "";
                htmlDetalle = htmlDetalle + "<th>ID</th>";
                htmlDetalle = htmlDetalle + "<th></th>";
                htmlDetalle = htmlDetalle + "<th>Codigo</th>";
                htmlDetalle = htmlDetalle + "<th></th>";
                htmlDetalle = htmlDetalle + "<th>Detalle</th>";
                htmlDetalle = htmlDetalle + "<th></th>";
                htmlDetalle = htmlDetalle + "<th>Cantidad</th>";
                htmlDetalle = htmlDetalle + "<th></th>";
                htmlDetalle = htmlDetalle + "<th>Unidad</th>";
                htmlDetalle = htmlDetalle + "<th></th>";
                htmlDetalle = htmlDetalle + "<th>Total</th>";

                tableDetalle.append(htmlDetalle);

                $.each(data.Detalle, function (index, value) {
                    htmlDetalle = "";
                   
                    htmlDetalle = htmlDetalle + "<tr>";

                    htmlDetalle = htmlDetalle + "<td>" + value.folioDetalle + "</td>";
                    htmlDetalle = htmlDetalle + "<td>"+"</td>";
                    htmlDetalle = htmlDetalle + "<td>" + value.codigo + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + value.nombre + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + "</td>";
                    htmlDetalle = htmlDetalle + "<td style='text-align: center;'>" + formatearNumero(value.cantidad) + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + "</td>";
                    htmlDetalle = htmlDetalle + "<td style='text-align: center;'>" + formatearNumero(value.Unidad) + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + "</td>";
                    htmlDetalle = htmlDetalle + "<td style='text-align: center;'>" + formatearNumero(value.subTotal, "$") + "</td>";
                    
                    htmlDetalle = htmlDetalle + "</tr>";


                    tableDetalle.append(htmlDetalle);
                });

                var colspanTotales = 7;


                var htmldetalleTotal = "";

                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>"+" " +"</th>";
                htmldetalleTotal = htmldetalleTotal + "<td></td><td></td><td></td><td style='text-align: center;'>" + "</td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Neto</th>";
                htmldetalleTotal = htmldetalleTotal + "<td></td><td></td><td></td><td style='text-align: center;'>" + formatearNumero(netototal, "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Iva</th>";
                htmldetalleTotal = htmldetalleTotal + "<td></td><td></td><td></td><td style='text-align: center;'>" + formatearNumero(iva, "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Total</th>";
                htmldetalleTotal = htmldetalleTotal + "<td></td><td></td><td></td><td style='text-align: center;'>" + formatearNumero(total, "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                tableDetalle.append(htmldetalleTotal);
            }
        }
    });
} 



function EditarPresupuesto(Id) {
    var tableCabecera = $("#tblCabecera");
   

    tableCabecera.html("");
    $.ajax({
        type: "POST",
        url: "DetallePresupuesto",
        data: { _IdPresu: Id },
        async: true,
        success: function (data) {
            if (data.Mensaje == 1) {
                alert("No se encontró el documento.");
            }
            else {
                $.each(data.Cabecera, function (index, value) {


                    var htmlCabecera = "<tr><th nowrap='nowrap'>N&ordm; Presupuesto.</th>" +
                        "<td><input type='text' id='idPresupuesto' value=" + value.folioEncabezado + " disabled /></td>" +
                        "<th nowrap='nowrap'>Fecha</th>" +
                        "<td><input type='text' id='fechaEmision' value='" + value.fecha + "' disabled></td>" +

                        "<tr><th nowrap='nowrap'>Cliente.</th>" +
                        "<td><input type='text' id='rut' value='" + value.Nombre + "' disabled /></td>" +

                        "<th nowrap='nowrap'>Rut.</th>" +
                        "<td><input type='text' id='Rut' value='" + value.rutCliente + "' disabled /></td></tr>" +

                        "<tr><th nowrap='nowrap'>Patente.</th>" +
                        "<td><input type='text' id='Patente' value='" + value.patente+"' disabled /></td>" +
                        "<th nowrap='nowrap'>Marca</th>" +
                        "<td><input type='text' id='Marca' value=" + value.marca + " disabled/></td></tr>" +
                        "<th nowrap='nowrap'>Modelo</th>" +
                        "<td><input type='text' id='Modelo' value=" + value.modelo + " disabled/></td></tr>" +

                 

                        "<tr><th nowrap='nowrap'>Observacion</th>" +
                        "<td><input type='text' id='observacion' value='" + value.observaciones + "'></td>" +
                        "<td></td>" +
                        "<td></td></tr>" +
                        "<td></td>" +
                        "<td><button class='btn btn-warning btn-xs' data-toggle='modal' data-target='#DetalleDetalle' onclick='EditarDetallePresupuesto(" + Id + ")'>Editar Detalle</button></td>" +
                        "<td><button class='btn btn-danger btn-xs' onclick='grabaEditaCotizacion(" + value.Id + ")'>Guardar Cabecera</button></td>" +
                        "<td></td>";
                    tableCabecera.append(htmlCabecera);
                });
            }
        }
    });
}





function EditarDetallePresupuesto(Id) {
    var tableDetalle = $("#tblDetalle tbody");
    var htmlDetalle = "";
    tableDetalle.html("");
    var total = 0;
    var iva = 0;
    var neto = 0;
    $.ajax({
        type: "POST",
        url: "DetallePresupuesto",
        data: { _IdPresu: Id },
        async: true,
        success: function (data) {
            if (data.Mensaje == 1) {
                alert("No se encontro detalle.");
            }
            else {
                $("#tblDetalle tbody").html("");
                $.each(data.Detalle, function (index, value) {
                    htmlDetalle = "";

                   
                    htmlDetalle = htmlDetalle + "<tr>";
                    htmlDetalle = htmlDetalle + "<td>" + value.folioDetalle + "</td>";
                    htmlDetalle = htmlDetalle + "<td id='td_detalleProducto_codigoProducto_" + value.folioDetalle + "'>" + value.codigo + "</td>";
                    htmlDetalle = htmlDetalle + "<td id='td_detalleProducto_descripcionProducto_" + value.folioDetalle + "'>" + value.nombre + "</td>";
                   
                    htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + value.cantidad + "</td>";
                    htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + formatearNumero(value.Unidad, "$") + "</td>";
                    htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + formatearNumero(Math.round(value.subTotal), "$") + "</td>";
                    htmlDetalle = htmlDetalle + "<td></td>";
                    htmlDetalle = htmlDetalle + "<td><button class='btn btn-warning btn-xs' data-toggle='modal' data-target='#EditarDetallePresupuesto' onclick='modificardetalle(" + value.folioDetalle + "," + Id + ")'>editar</button></td>";
                    htmlDetalle = htmlDetalle + "<td><button class='btn btn-danger btn-xs' onclick='eliminarDetalle(" + value.folioDetalle + "," + Id + ")'>Eliminar</button></td>";
                    htmlDetalle = htmlDetalle + "</tr>";

                    neto  += value.subTotal;

                    iva =Math.round(neto * 0.19);
                    total = Math.round(neto+iva);
                    
                   
                    

                    tableDetalle.append(htmlDetalle);
                });

                var colspanTotales = 7;
              

                var htmldetalleTotal = "";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>SubTotal</th>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(Math.round(neto), "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Total Iva</th>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(iva, "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Venta Total</th>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(Math.round(total), "$") + "</td>";
                htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                htmldetalleTotal = htmldetalleTotal + "</tr>";
                tableDetalle.append(htmldetalleTotal);

                datosDetalle = data.Detalle;

            }
        }
    });
}





function eliminarDetalle(Linea, idEncabezado) {
    //IdCotizacion = $("#idCotizacion").val();
    var total = 0;
    var iva = 0;
    var neto = 0;
    if (datosDetalle.length > 1) {
        $.ajax({
            type: "POST",
            url: "EliminarDetalle",
            data:
            {
                Linea,
                idEncabezado
            },
            async: true,
            success: function (data) {
                if (data.Verificador) {
                    abrirInformacion("Modificacion", "Registro eliminado");
                    $("#tblDetalle tbody").html("");
                    var tableDetalle = $("#tblDetalle tbody");
                    var htmlDetalle = "";
                    datosDetalle = datosDetalle.filter(m => m.folioDetalle !== Linea);
                    $.each(data.Detalle, function (index, value) {
                        htmlDetalle = "";
                        

                        htmlDetalle = htmlDetalle + "<tr>";
                        htmlDetalle = htmlDetalle + "<td>" + value.folioDetalle + "</td>";
                        htmlDetalle = htmlDetalle + "<td id='td_detalleProducto_codigoProducto_" + value.folioDetalle + "'>" + value.codigo + "</td>";
                        htmlDetalle = htmlDetalle + "<td id='td_detalleProducto_descripcionProducto_" + value.folioDetalle + "'>" + value.nombre + "</td>";

                        htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + value.cantidad + "</td>";
                        htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + formatearNumero(value.Unidad, "$") + "</td>";
                        htmlDetalle = htmlDetalle + "<td style='text-align: right;'>" + formatearNumero(Math.round(value.subTotal), "$") + "</td>";
                        htmlDetalle = htmlDetalle + "<td></td>";
                        htmlDetalle = htmlDetalle + "<td><button class='btn btn-warning btn-xs' data-toggle='modal' data-target='#EditarDetallePresupuesto' onclick='modificarDetalle(" + value.folioDetalle + "," + idEncabezado + ")'>Editar</button></td>";
                        htmlDetalle = htmlDetalle + "<td><button class='btn btn-danger btn-xs' onclick='eliminarDetalle(" + value.folioDetalle + "," + idEncabezado + ")'>Eliminar</button></td>";
                        htmlDetalle = htmlDetalle + "</tr>";

                        neto += value.subTotal;

                        iva = Math.round(neto * 0.19);
                        total = Math.round(neto + iva);

                        tableDetalle.append(htmlDetalle);
                    });

                    var colspanTotales = 7;
                    

                    var htmldetalleTotal = "";
                    htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>SubTotal</th>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(Math.round(neto), "$") + "</td>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                    htmldetalleTotal = htmldetalleTotal + "</tr>";
                    htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Total Iva</th>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(iva, "$") + "</td>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                    htmldetalleTotal = htmldetalleTotal + "</tr>";
                    htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>Venta Total</th>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'>" + formatearNumero(Math.round(total), "$") + "</td>";
                    htmldetalleTotal = htmldetalleTotal + "<td style='text-align: right;'></td>";
                    htmldetalleTotal = htmldetalleTotal + "</tr>";
                    tableDetalle.append(htmldetalleTotal);

                    datosDetalle = data.Detalle;
                }
            }
        });

    } else {
        abrirError("Usuario", "No se puede dejar sin productos");
    }
}




function modificardetalle(Linea,idEncabezado) {
    $.ajax({
        type: "POST",
        url: "BuscarDetalle",
        data: {
           
            Linea,
            idEncabezado
        },
        async: true,
        success: function (data) {
            if (data.Verificador ==false) {
                alert("No se encontro detalle." + data.Detalle.folioDetalle);
            }
            else {
                
                $("#idDetalle").val(data.Detalle.folioDetalle);
                $("#txtCodigo").val(data.Detalle.codigo);
                $("#txtTipo").val(data.Detalle.Tipo);
                $("#txtNombre").val(data.Detalle.nombre);
                $("#txtCantidad").val(data.Detalle.cantidad);
                $("#txtSubtotal").val(data.Detalle.Unidad);
                $("#txtTotal").val(data.Detalle.subTotal);

           

            }
        }
    });
}