//bloqueo de pantalla
function bloqueo() {
    $.blockUI({
        message: $('#Block_div'),
        css:
            {
                padding: 0,
                margin: 0,
                textAlign: 'center',
                fontSize: 12,
                cursor: 'auto',
                border: 'none',
                background: 'none'
            }
    });
}
//desbloqueo de pantalla
function closeLoading() {
    $.unblockUI();
}
function abrirConsejos(url) {
    var win = window.open(url, '_blank');
    win.location.href = url;

    win.focus();
    return false;
}
function pageLoad() {
    $('#btnContinuar').click(function () {
        bloqueo();
    });
    $('#Block_div').click(function () {
        $.unblockUI();
    });
};

function ValidarCaracteresUsr(e) {
    let tecla;
    tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    return (tecla > 47 && tecla < 58) //,
        || (tecla > 64 && tecla < 91)  //-
        || (tecla > 96 && tecla < 123) //.
        || tecla === 44 //ñ 
        || tecla === 45 //Ñ 
        || tecla === 46 //espacio 
        || tecla === 241 //!
        || tecla === 209 //+
        || tecla === 32 //#
        || tecla === 33 //*
        || tecla === 43 //[
        || tecla === 35 //]
        || tecla === 42 //(
        || tecla === 91 //)
        || tecla === 93 //=
        || tecla === 40 //;
        || tecla === 41 //:
        || tecla === 61 //_
        || tecla === 59 //delete 
        || tecla === 47 // /
        || tecla === 124 // |
        || tecla === 92 // \
        || tecla === 123 // {
        || tecla === 125 // }
        || tecla === 38 // &
        || tecla === 37 // %
        || tecla === 36 // $
        || tecla === 64 // @
        || tecla === 60 // <
        || tecla === 62 // >
        || tecla === 63 // ?
        || tecla === 94 // ^
        || tecla === 126 // ~
        || tecla === 39 // '
        || tecla === 96 // `
        || tecla === 34 // "
        || tecla === 58
        || tecla === 95
        || tecla === 127
        || (tecla >= 0 && tecla <= 31);
}


$(document).ready(function () {
    $("#keyboard li").attr('onclick', '');
    $("#keyboard li").css('cursor', 'default');
    $("#ContentPlaceHolder_txtContrasena1").val("");
    $("#ContentPlaceHolder_txtContrasena1").focus();
    //Cambio Clave Acceso Primera Vez

    $("#txtNuevoUsuario").val("");
    $("#txtConfirmaUsuario").val("");

    $("#txtClaveAnterior").val("");
    $("#txtClaveNueva").val("");
    $("#txtClaveConfirma").val("");

    $("#ContentPlaceHolder_txtNuevoUsuario").val("");
    $("#ContentPlaceHolder_txtConfirmaUsuario").val("");

    $("#ContentPlaceHolder_txtClaveAnterior").val("");
    $("#ContentPlaceHolder_txtClaveNueva").val("");
    $("#ContentPlaceHolder_txtClaveConfirma").val("");
    //Cambio Clave Transaccional Primera Vez
    $("#txtTransAnterior").focus();
    $("#txtTransAnterior").val("");
    $("#txtTransNueva").val("");
    $("#txtTransConfirmar").val("");
    $("#ContentPlaceHolder_txtTransAnterior").focus();
    $("#ContentPlaceHolder_txtTransAnterior").val("");
    $("#ContentPlaceHolder_txtTransNueva").val("");
    $("#ContentPlaceHolder_txtTransConfirmar").val("");
});

let sw = false;

function check() {
    if (sw !== true) {
        $("#keyboard").css('display', '');
        $("#keyboard li").attr('onclick', 'tecla_oprimida(this.id)');
        $("#shift").attr('onclick', 'shift()');
        $("#borrar").attr('onclick', 'borrar()');
        $("#espacio").attr('onclick', 'espacio()');
        $("#keyboard li").css('cursor', 'pointer');
        $("#ContentPlaceHolder_txtContrasena1").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtContrasena1").val("");

        //Cambio Clave Acceso Primera Vez
        $("#ContentPlaceHolder_txtClaveAnterior").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveAnterior").val("");
        $("#ContentPlaceHolder_txtClaveNueva").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveNueva").val("");
        $("#ContentPlaceHolder_txtClaveConfirma").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveConfirma").val("");
        $("#ContentPlaceHolder_txtClaveAnterior").focus();

        let cadena = "";
        let cadena_anterior = "";
        let cadena_nueva = "";
        let cadena_confirma = "";
        sw = true;
    } else {
        $("#keyboard").css('display', 'none');
        $("#keyboard li").attr('onclick', '');
        $("#keyboard li").css('cursor', 'default');
        $("#ContentPlaceHolder_txtContrasena1").removeAttr('readonly');
        $("#ContentPlaceHolder_txtContrasena1").val("");
        $("#ContentPlaceHolder_txtContrasena1").focus();

        //Cambio Clave Acceso Primera Vez
        $("#ContentPlaceHolder_txtClaveAnterior").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveAnterior").val("");
        $("#ContentPlaceHolder_txtClaveNueva").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveNueva").val("");
        $("#ContentPlaceHolder_txtClaveConfirma").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveConfirma").val("");
        $("#ContentPlaceHolder_txtClaveAnterior").focus();
limpiar();
        sw = false;
    }
}


function check_pw_usr() {
    if (sw !== true) {
        $("#keyboard").css('display', '');
        $("#keyboard li").attr('onclick', 'tecla_oprimida(this.id)');
        $("#shift").attr('onclick', 'shift()');
        $("#borrar").attr('onclick', 'borrar()');
        $("#espacio").attr('onclick', 'espacio()');
        $("#keyboard li").css('cursor', 'pointer');
        $("#txtContrasena1").attr('disabled', 'disabled');
        $("#txtContrasena1").val("");

        //Cambio Usuario Primera Vez  
        $("#ContentPlaceHolder_txtNuevoUsuario").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtNuevoUsuario").val("");
        $("#ContentPlaceHolder_txtConfirmaUsuario").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtConfirmaUsuario").val("");
        //Cambio Clave Acceso Primera Vez  
        $("#ContentPlaceHolder_txtClaveAnterior").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveAnterior").val("");
        $("#ContentPlaceHolder_txtClaveNueva").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveNueva").val("");
        $("#ContentPlaceHolder_txtClaveConfirma").attr('readonly', 'true');
        $("#ContentPlaceHolder_txtClaveConfirma").val("");
        $("#ContentPlaceHolder_txtClaveAnterior").focus();

        let cadena = "";
        let cadenaUsuario = "";
        let cadena_confirmaUsuario = "";
        let cadena_anterior = "";
        let cadena_nueva = "";
        let cadena_confirma = "";
        sw = true;
    } else {
        $("#keyboard").css('display', 'none');
        $("#keyboard li").attr('onclick', '');
        $("#keyboard li").css('cursor', 'default');
        $("#txtContrasena1").attr('disabled', '');
        $("#txtContrasena1").val("");
        $("#txtContrasena1").focus();

        //Cambio Usuario Primera Vez 
        $("#ContentPlaceHolder_txtNuevoUsuario").removeAttr('readonly');
        $("#ContentPlaceHolder_txtNuevoUsuario").val("");
        $("#ContentPlaceHolder_txtConfirmaUsuario").removeAttr('readonly');
        $("#ContentPlaceHolder_txtConfirmaUsuario").val("");
        //Cambio Clave Acceso Primera Vez      
        $("#ContentPlaceHolder_txtClaveAnterior").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveAnterior").val("");
        $("#ContentPlaceHolder_txtClaveNueva").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveNueva").val("");
        $("#ContentPlaceHolder_txtClaveConfirma").removeAttr('readonly');
        $("#ContentPlaceHolder_txtClaveConfirma").val("");
        $("#ContentPlaceHolder_txtClaveAnterior").focus();

        sw = false;
    }
}

