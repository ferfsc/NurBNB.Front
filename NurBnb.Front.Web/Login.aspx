<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NurBnb.Front.Web.Login" %>


<asp:Content ID="Content" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/login.js"></script>
    <script src="assets/js/Teclado.js"></script>

    <style type="text/css">
        #img_icon_verisign {
            border: none;
        }
    </style>
    <script>
        function pageLoad() {
            $("#keyboard").css('display', 'none');
            if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                $('#<%= hfdispositivo.ClientID %>').val(2);
            }
            else {
                $('#<%= hfdispositivo.ClientID %>').val(1);
            }
            $(document).ready(function ($) {
                //restriccion de input
                $('.alphanumerico').mask('AAAAAAAAAAAAAAAAAAAAAAA');
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div id="il_contenedor" class="uk-grid-collapse" uk-grid style="padding-top: 4%">

        <div class="uk-width-1-6@s"></div>
        <div class="uk-width-expand@s">           
            <div class="borde_gris uk-margin-small">
                <div id="il_cabecera" class="uk-grid-small uk-grid-row-collapse" uk-grid>
                    <div class="uk-width-auto@m">
                        <asp:HiddenField ID="hfdispositivo" runat="server" Value="0" />
                        <span id="il_ingreso_sistema" class="titulo_login texto_gris texto_Bold uk-margin-remove">Ingreso al sistema</span>
                    </div>
                    <div class="uk-width-expand@m">                        
                    </div>
                </div>
            </div>

            <div id="il_datos_usuario" class="uk-grid-collapse uk-margin-small uk-margin-small-top borde_gris" uk-grid>
                <div class="uk-width-1-6@m"></div>
                <div class="uk-width-expand@s">

                    <div class="uk-form-stacked">                      

                        <div class="uk-margin-small">
                            <asp:Label ID="lblUsuario" CssClass="uk-form-label texto_15 texto_gris" runat="server">Código de usuario:</asp:Label>

                            <div class="uk-inline uk-form-controls uk-width-1-1">
                                <%--<a class="uk-form-icon uk-form-icon-flip" href="#" uk-icon="icon: fa-solid-eye" onclick="mostrar(this,'<%= txtUsuario.ClientID %>','Usuario')" uk-tooltip="Mostrar Usuario"></a>--%>
                                <a class="uk-form-icon uk-form-icon-flip" href="#"  uk-tooltip="Mostrar Usuario"></a>
                                <asp:TextBox ID="txtUsuario" CssClass="uk-input uk-form-small " Text="admin@fake.com"  TabIndex="1"  runat="server" />
                            </div>

                        </div>

                        <div class="uk-margin-small">
                            <asp:Label ID="lblContrasena" CssClass="uk-form-label texto_15 texto_gris" runat="server">Clave de acceso:</asp:Label>
                            <div class="uk-inline uk-form-controls uk-width-1-1">
                                <a class="uk-form-icon uk-form-icon-flip" href="#" uk-icon="icon: fa-solid-eye" onclick="mostrar(this,'<%= txtPassword.ClientID %>','Contraseña')" uk-tooltip="Mostrar Contraseña"></a>
                                <asp:TextBox ID="txtPassword" CssClass="uk-input uk-form-small " TabIndex="2" Text="admin@123"  runat="server" />                                
                            </div>
                        </div>
                         <% if (!String.IsNullOrEmpty(lblMensajeError.Text))
                                   { %>
                                    <div class="uk-alert-danger" uk-alert>
                                        <a class="uk-alert-close" uk-close></a>
                                        <p>
                                            <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                                        </p>
                                    </div>
                                <% } %>
                        <div class="uk-grid-small uk-margin-small" uk-grid>
                            <div class="uk-width-1-2@s ">
                                <asp:Button ID="btnContinuarLogin" CssClass="uk-button uk-button-primary uk-width-1-1" runat="server" TabIndex="3" Text="Ingresar" OnClick="btnContinuarLogin_Click" OnClientClick="bloqueo();" />
                            </div>
                            <div class="uk-width-1-2@s">
                                <asp:Button ID="btnCancelar" CssClass="uk-button uk-button-primary uk-width-1-1" runat="server" Text="Cancelar" TabIndex="4" OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="uk-width-1-6@m"></div>
            </div>
        </div>
        <div class="uk-width-1-6@s"></div>
    </div>

</asp:Content>

