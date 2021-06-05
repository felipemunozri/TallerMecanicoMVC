$(document).ready(function () {
    $("#Login").click(function () {
        var nombre = $("#Nombre").val();
        var contrasena = $("#Contrasena").val();
        var urlIndex = $("#urlIndex").val();
       

        var urlLogin = $("#urlLogin").val();
        $.ajax({
            type: "POST",
            url: urlLogin,
            data: {
                _Nombre: nombre,
                _Contrasena: contrasena
            },
            async: true,
            success: function (data) {
                try {
                    if (data.Verificador !== undefined) {
                        if (!data.Verificador) {
                            $("#modalErrorLoginMensaje").html(data.Mensaje);
                            $("#aModalErrorLogin").click();
                            return;
                        }
                    }
                }
                catch (e) {

                }
                if (data.Validador ==1) {
                    window.location = urlIndex;
                    //traer url de vista
                }
                
            },
            error: function (a, b, c) {
                console.log(a, b, c);

            }
        });
    });
});

function NombreKeyPress(event) {
    if (event.keyCode === 13) {
        $('#Contrasena').focus();
    }
}
function ContrasenaKeyPress(event) {
    if (event.keyCode === 13) {
        $('#Login').click();
    }
}