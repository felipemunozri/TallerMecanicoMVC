

function EditarOrdenMecanico(id,patente) {

    $("#txtordenesId").val(id);
    $("#txtPatenteID").val(patente);
  

}

function Detalleordenes(idOrden) {
    var tableCabecera = $("#tblDetalleordenes");
    var tableDetalle = $("#tblDetalleordenesDetalle");
    var htmlDetalle = "";
    var htmlCabecera = "";
    var netototal = 0;
    var iva = 0;
    var total = 0;
    $.ajax({
        type: "POST",
        url: "DetalleOrdenes",
        data: { idOrden: idOrden },
        async: true,
        success: function (data) {
            if (data.Mensaje == 1) {
                alert("No se encontró el documento.");
            }
            else {
                $("#tblDetalleordenes").html("");
                $("#tblDetalleordenesDetalle").html("");

                $.each(data.Cabecera, function (index, value) {

                    netototal = value.neto;
                    iva = value.iva;
                    total = value.total;

                    if (value.observaciones == null || value.observaciones == " ") {
                        value.observaciones = "No existe observación";

                    }

                    htmlCabecera = "<tr><th>N&ordm;Orden N°.</th>" +
                        "<td>" + value.folioOrden + "</td>" +
                        "<th nowrap='nowrap'>Fecha.</th>" +
                        "<td>" + value.fecha + "</td>" +
                        "<th nowrap='nowrap'>Fecha Entrega.</th>" +
                        "<td>" + value.Plazo + "</td></tr>" +

                        "<tr><th nowrap='nowrap'>Cliente.</th>" +
                        "<td>" + value.Nombre + "</td>" +
                        "<th nowrap='nowrap'>Rut.</th>" +
                        "<td>" + value.rutCliente + "</td>" +
                        "<th nowrap='nowrap'>Telefono</th>" +
                        "<td>" + "+56 " + value.telefonoCliente + "</td>" +
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
                        "<td>" + formatearNumero(value.kilometraje) + "</td>" +
                        "<th nowrap='nowrap'>Responsable.</th>" +
                        "<td>" + value.Responsable + "</td>" +
                        "<td></td>" +
                        "<td></td>" +
                        "<td></td></tr>" +

                        "<tr><th nowrap='nowrap'>Activa/Anulada.</th>" +
                        "<td>" + value.Anulada + "</td>" +
                        "<th nowrap='nowrap'>Prioridad</th>" +
                        "<td>" + value.prioridad + "</td>" +
                        "<tr><th nowrap='nowrap'>Observacion.</th>" +
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

                    htmlDetalle = htmlDetalle + "<td>" + value.folioDetalleOrden + "</td>";
                    htmlDetalle = htmlDetalle + "<td>" + "</td>";
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

                htmldetalleTotal = htmldetalleTotal + "<tr><th colspan='" + colspanTotales + "'>" + " " + "</th>";
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





function CambiarEstado() {
    var url = $("#url").val();
    var id = $("#txtordenesId").val();
    var patente = $("#txtPatenteID").val();
    var comentario = $("#txtComentario").val();
    var Estado = $("#SeleccionarEstado").val();

    if (Estado == 0) {
        Estado = "Ingresado";
    } else {
        if (Estado == 1) { Estado = "Reparacion" }
        else { Estado = "Entregado" }
    }

        $.ajax({
            type: "POST",
            url: "EditarOrdenMecanico",
            data:
            {
                id,
                comentario,
                Estado,
                patente
            },
            async: true,
            success: function (data) {
                if (data.Verificador=true ) {
                    abrirInformacion("Usuario", "Orden Modificada");
                    window.location = url;
                   
                }
                

            }

        });

    
}