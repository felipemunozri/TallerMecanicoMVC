﻿
function agregarSeparadorMiles(numero, caracterSeparador, caracterDecimal) {
    caracterSeparador = caracterSeparador === undefined || caracterSeparador === null ? "," : caracterSeparador;

    numero = String(numero);
    var decimales = "";
    if (numero.indexOf(".") !== -1) {
        decimales = numero.substring(numero.indexOf("."));
    }

    numero = String(numero).replace(decimales, "");

    decimales = decimales.replace(".", caracterDecimal);

    numero = numero === '' ? numero : Number(numero).toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.').split('').reverse().join('').replace(/^[\.]/, '');

    while (numero.indexOf(",") !== -1) {
        numero = numero.replace(",", caracterSeparador);
    }

    numero = numero + decimales;

    return numero;
}

$(document).ready(function () {
        $('#dataTable').DataTable({
            ordering: false,
            language: {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ Registros",
                "sZeroRecords": "&nbsp;",
                "sEmptyTable": "&nbsp;",
                "sInfo": "Encontrados: _TOTAL_ Registros (Mostrando del _START_ al _END_)",
                "sInfoEmpty": "* No se han encontrado resultados en la búsqueda",
                "sInfoFiltered": "",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
            //aoColumnDefs: [{ 'bSortable': false, 'aTargets': ['no-sortable'] }]
        });

    $("#modalLayoutEmpresasAgregar").click(function () {
        var empresa = $("#ddlLayoutEmpresas").val();

        var urlSeleccionaEmpresa = $("#urlSeleccionaEmpresa").val();

        $.ajax({
            url: urlSeleccionaEmpresa,
            type: "POST",
            data: { _IdEmpresa: empresa },
            async: true,
            success: function (data) {
                var urlHome = $("#urlHome").val();
                window.location = urlHome;
            }
        });
    });
});


$(document).ready(function () {
    $("#aBaseModalCambioContrasena").click(function () {
        $("#btnBaseModalCambioContrasena").click();
    });

    $("#baseBtnCambiaContrasena").click(function () {
        console.log("sdlfhiosdbvnkld");
        $.ajax({
            url: "BaseCambiaContrasena",
            type: "POST",
            data: {
                contrasena: $("#baseTxtContrasena").val(),
            },
            async: true,
            success: function (data) {
                console.log(data);
                if (data.Verificador) {
                    $("#baseBtnCerrarModal").click();
                    abrirInformacion("Cambio Contraseña", data.Mensaje);
                    $("#baseTxtContrasena").val("");
                }
                else {
                    abrirError("Cambio Contraseña", data.Mensaje);
                }
            }
        });
    });
});

function abrirLoadingCompleto(texto) {
    /*
    if (texto === undefined || texto === null) {
        texto = "Cargando";
    }
    $("#loading-ajax-texto").html(texto);
    jQuery("#loading-ajax").show();
    */
}
function cerrarLoadingCompleto() {
    /*
    jQuery("#loading-ajax").hide();
    */
}


var tipoAlert = 1;

function abrirError(titulo, mensaje, callBackOK) {
    callBackOK = (callBackOK === undefined || callBackOK === null) ? function () { } : callBackOK;
    if (tipoAlert === 1) {
        swal({
            title: titulo,
            text: mensaje,
            icon: 'error',
            buttons: {
                confirm: {
                    text: 'Aceptar',
                    value: true,
                    visible: true,
                    className: 'btn btn-danger',
                    closeModal: true
                }
            }
        }).then((value) => {
            if (value === true) {
                callBackOK();
            }
        });
    }
    else {
        alert(mensaje);
    }
}

function abrirAprobacion(titulo, mensaje, callBackOK) {
    callBackOK = (callBackOK === undefined || callBackOK === null) ? function () { } : callBackOK;
    if (tipoAlert === 1) {
        swal({
            title: titulo,
            text: mensaje,
            icon: 'success',
            buttons: {
                confirm: {
                    text: 'Aceptar',
                    value: true,
                    visible: true,
                    className: 'btn btn-success',
                    closeModal: true
                }
            }
        }).then((value) => {
            if (value === true) {
                callBackOK();
            }
        });
    }
    else {
        alert(mensaje);
    }
}

function abrirInformacion(titulo, mensaje, callBackOK) {
    callBackOK = (callBackOK === undefined || callBackOK === null) ? function () { } : callBackOK;
    if (tipoAlert === 1) {
        swal({
            title: titulo,
            text: mensaje,
            icon: 'info',
            buttons: {
                confirm: {
                    text: 'Aceptar',
                    value: true,
                    visible: true,
                    className: 'btn btn-info',
                    closeModal: true
                }
            }
        }).then((value) => {
            if (value === true) {
                callBackOK();
            }
        });
    }
    else {
        alert(mensaje);
    }
}

function abrirConfirmacion(titulo, mensaje, callBackOK, callBackCancel, esError) {
    callBackOK = (callBackOK === undefined || callBackOK === null) ? function () { } : callBackOK;
    callBackCancel = (callBackCancel === undefined || callBackCancel === null) ? function () { } : callBackCancel;
    if (tipoAlert === 1) {
        swal({
            title: titulo,
            text: mensaje,
            icon: (esError ? 'error' : 'info'),
            buttons: {
                cancel: {
                    text: 'Cancelar',
                    value: null,
                    visible: true,
                    className: 'btn btn-default',
                    closeModal: true,
                },
                confirm: {
                    text: 'Confirmar',
                    value: true,
                    visible: true,
                    className: 'btn btn-success',
                    closeModal: true
                }
            }
        }).then((value) => {
            if (value === true) {
                callBackOK();
            }
            else {
                callBackCancel();
            }
        });
    }
    else {
        var conf = confirm(mensaje);

        if (conf) {
            if (callBackOK !== null && callBackOK !== undefined && (callBackOK instanceof Function)) {
                callBackOK();
            }
        }
        else {
            if (callBackCancel !== null && callBackCancel !== undefined && (callBackCancel instanceof Function)) {
                callBackCancel();
            }
        }
    }
}

var spinnerButton = function () {
    return "<span class='spinner-border spinner-border-sm' role='status' aria-hidden='true'></span> ";
}


var ____botonesLoading = [];

var addBotonLoading = function (id) {
    if (____botonesLoading.find(m => m.id === id) === undefined) {
        ____botonesLoading.push({
            id: id,
            htmlOriginal: $("#" + id).html(),
            htmlLoading: (spinnerButton() + $("#" + id).html())
        });
    }
}

function activarLoadingBoton(id) {
    addBotonLoading(id);
    $("#" + id).html(____botonesLoading.find(m => m.id === id).htmlLoading);
    $("#" + id).attr("disabled", "disabled");
}

function desactivarLoadingBoton(id) {
    addBotonLoading(id);
    $("#" + id).html(____botonesLoading.find(m => m.id === id).htmlOriginal);
    $("#" + id).removeAttr("disabled");
}

function convertirFullScreenModal(id) {
    var width100 = window.screen.width;
    var width90 = Math.round(width100 * 0.90);
    var width10 = Math.round(width100 - width90);
    var width5 = Math.round(width10 / 2);

    $("#" + id).find(".modal-dialog").attr("style", "width: " + width90 + "px; margin: " + width5 + "px");
    $("#" + id + " div[class=modal-content]").attr("style", "width: " + width90 + "px");
}






function formatearNumero(numero, simboloAntes, valorDefecto) {
    simboloAntes = simboloAntes === undefined || simboloAntes === null ? "" : simboloAntes;
    valorDefecto = valorDefecto === undefined || valorDefecto === null ? numero : valorDefecto;

    var numeroTemp = "" + numero;
    if (!isNaN(numeroTemp)) {
        numeroTemp = numeroTemp.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        numeroTemp = numeroTemp.split('').reverse().join('').replace(/^[\.]/, '');
        return simboloAntes + numeroTemp;
    }
    else {
        return valorDefecto;
    }
}

function validaRut(rut) {
    // Despejar Puntos
    var valor = rut.replace('.', '');
    valor = valor.replace('.', '');
    valor = valor.replace('.', '');
    // Despejar Guión
    valor = valor.replace('-', '');

    // Aislar Cuerpo y Dígito Verificador
    cuerpo = valor.slice(0, -1);
    dv = valor.slice(-1).toUpperCase();

    // Formatear RUN
    rut = cuerpo + '-' + dv

    // Si no cumple con el mínimo ej. (n.nnn.nnn)
    if (cuerpo.length < 7) { return "RUT Incompleto"; }

    // Calcular Dígito Verificador
    suma = 0;
    multiplo = 2;

    // Para cada dígito del Cuerpo
    for (i = 1; i <= cuerpo.length; i++) {

        // Obtener su Producto con el Múltiplo Correspondiente
        index = multiplo * valor.charAt(cuerpo.length - i);

        // Sumar al Contador General
        suma = suma + index;

        // Consolidar Múltiplo dentro del rango [2,7]
        if (multiplo < 7) { multiplo = multiplo + 1; } else { multiplo = 2; }

    }

    // Calcular Dígito Verificador en base al Módulo 11
    dvEsperado = 11 - (suma % 11);

    // Casos Especiales (0 y K)
    dv = (dv == 'K') ? 10 : dv;
    dv = (dv == 0) ? 11 : dv;

    // Validar que el Cuerpo coincide con su Dígito Verificador
    if (dvEsperado != dv) { return "RUT Inválido"; }

    // Si todo sale bien, eliminar errores (decretar que es válido)
    return '';
}

function validaEmail(mail) {
    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
        return (true)
    }
    return (false)
}