<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="NurBnb.Front.Web.Reservas" %>

<%@ Register Src="~/Controles/MensajeAlertas.ascx" TagPrefix="ucMS" TagName="ucMS" %>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">

        function MsjEliminar(element) {
            var mensaje = "¿Está seguro que desea Rechazar la solicitud de Materiales?";
            UIkit.modal.confirm(mensaje, { 'labels': { 'cancel': 'Cancelar', 'ok': 'Aceptar' } }).then(function () {
                bloqueo();
                location.href = element.href;
            }, function () {
            });
            return false;
        }
        function MsjAutorizar(element) {
            var mensaje = "¿Está seguro que desea Autorizar la solicitud de Materiales?";
            UIkit.modal.confirm(mensaje, { 'labels': { 'cancel': 'Cancelar', 'ok': 'Aceptar' } }).then(function () {
                bloqueo();
                location.href = element.href;
            }, function () {
            });
            return false;
        }

        function pageLoad() {
            cargar_random();

           <%-- $("#<%= cmbEstado.ClientID %>").change(function () {
                bloqueo();
            });

            $("#<%= cmbPrincipal.ClientID %>").change(function () {
                bloqueo();
            });--%>

        }

    </script>
</asp:Content>


<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updGeneral" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 id="hTitulo" runat="server" class="titulos">Formulario de Registro de Reservas</h1>
            <ucMS:ucMS runat="server" ID="ucAlertas" />
            <asp:HiddenField ID="hfMensaje" runat="server" />

            <div id="pnlRegistro" runat="server">
                <div class="uk-form-stacked uk-margin-small">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Solicita Reserva" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnRegistrar_Click" />
                </div>
                <div class="uk-form-stacked uk-margin-small" />

                <div id="cuentas_origen">
                    <ul uk-accordion>
                        <li class="uk-open">
                            <a class="uk-accordion-title uk-text-center" href="#">Lista de Reservas</a>
                            <div class="uk-accordion-content uk-margin-remove-top uk-overflow-auto">
                                <table class="uk-table uk-table-divider uk-table-hover uk-table-middle uk-table-striped uk-table-small uk-table-responsive cuentasOrigen">
                                    <asp:Repeater ID="rptDatos" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr class="trSubTitulo">
                                                    <th>Huesped</th>
                                                    <th>Propiedad</th>
                                                    <th>Fecha Inicio</th>
                                                    <th>Fecha Fin</th>
                                                    <th>Motivo</th>
                                                    <th>Editar</th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trSubTitulo_item uk-text-right uk-text-center@s">
                                                <td data-label="Huesped" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cliente") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Propiedad">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Titulo") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Fecha Inicio" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblNombres" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FechaCheckin") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Fecha Fin" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FechaCheckOut") %>' />
                                                        <asp:Label ID="Label7" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IDReserva") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Motivo" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Motivo") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Editar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDReserva") %>'
                                                            OnCommand="lnkEditar_Command" Text="Editar">
                                                        </asp:LinkButton>
                                                    </span>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>

            <div id="RegistroDatos" runat="server">
                <div class="uk-margin-small">
                    <h2 id="hDatosTransferencia" runat="server" class="titulos_secundarios">Datos</h2>
                    <div class="uk-margin-small">
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label2" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Huesped</asp:Label>
                                    <asp:DropDownList ID="cmbHuesped" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label8" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Propiedad</asp:Label>
                                    <asp:DropDownList ID="cmbPropiedad" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                        </div>
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label12" runat="server" CssClass="uk-form-label texto_15">Fecha CheckIn</asp:Label>
                                <input id="txtFechaInicio1" type="date" runat="server" class="uk-input uk-form-small" />
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label11" runat="server" CssClass="uk-form-label texto_15">Fecha CheckOut</asp:Label>
                                <input id="txtFechaInicio2" type="date" runat="server" class="uk-input uk-form-small" />                                
                            </div>
                        </div>
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-2-3@m">
                                <asp:Label ID="Label13" runat="server" CssClass="uk-form-label texto_15">Motivo</asp:Label>
                                <asp:TextBox ID="txtMotivo" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label1" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Estado</asp:Label>
                                    <asp:DropDownList ID="cmbEstado" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                        <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="uk-margin-small">
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Button ID="btnEnviar" runat="server" Text="Guardar Solicitud" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnEnviar_Click" />
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEnviar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
