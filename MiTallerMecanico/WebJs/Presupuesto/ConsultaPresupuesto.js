



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

                  

                        //"<tr><th nowrap='nowrap'>Centro de Costo</th>" +
                        //"<td>" + centroCosto + "</td>" +
                        //"<th nowrap='nowrap'>Lista de Precio</th>" +
                        //"<td>" + listaPrecio + "</td>" +

                        "<tr><th nowrap='nowrap'>Observacion</th>" +
                        "<td><input type='text' id='observacion' value='" + value.observaciones + "'></td>" +
                        "<td></td>" +
                        "<td></td></tr>" +
                        "<td></td>" +
                        "<td><button class='btn btn-warning btn-xs' data-toggle='modal' data-target='#DetalleDetalle' onclick='EditarDetallePresupuesto(" + value.folioEncabezado + ")'>Editar Detalle</button></td>" +
                        "<td><button class='btn btn-danger btn-xs' onclick='grabaEditaCotizacion(" + value.Id + ")'>Guardar Cabecera</button></td>" +
                        "<td></td>";
                    tableCabecera.append(htmlCabecera);
                });
            }
        }
    });
}

