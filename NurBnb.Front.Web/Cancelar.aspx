<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Cancelar.aspx.cs" Inherits="NurBnb.Front.Web.Cancelar" %>

<%@ Register Src="~/Controles/MensajeAlertas.ascx" TagPrefix="ucMS" TagName="ucMS" %>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">

        function MsjRechazar(element) {
            var mensaje = "¿Está seguro que desea Rechazar la Solicitud de Reserva?";
            UIkit.modal.confirm(mensaje, { 'labels': { 'cancel': 'Cancelar', 'ok': 'Aceptar' } }).then(function () {
                bloqueo();
                location.href = element.href;
            }, function () {
            });
            return false;
        }
        function MsjAutorizar(element) {
            var mensaje = "¿Está seguro que desea Confirmar la Solicitud de Reserva?";
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
            <h1 id="h1" runat="server" class="titulos">Confirmar/Rechazar Solicitud de Reserva</h1>
            <ucMS:ucMS runat="server" ID="ucAlertas" />
            <asp:HiddenField ID="hfMensaje" runat="server" />

            <div id="pnlRegistro" runat="server">

                <div id="cuentas_origen">
                    <ul uk-accordion>
                        <li class="uk-open">
                            <a class="uk-accordion-title uk-text-center" href="#">Solicitudes Pendientes</a>
                            <div class="uk-accordion-content uk-margin-remove-top uk-overflow-auto">
                                <table class="uk-table uk-table-divider uk-table-hover uk-table-middle uk-table-striped uk-table-small uk-table-responsive cuentasOrigen">
                                    <asp:Repeater ID="rptAutorizacion" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr class="trSubTitulo">
                                                    <th>Huesped</th>
                                                    <th>Propiedad</th>
                                                    <th>Fecha Inicio</th>
                                                    <th>Fecha Fin</th>
                                                    <th>Motivo</th>
                                                    <th>Confirmar</th>
                                                    <th>Rechazar</th>
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
                                                <td data-label="Confirmar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkAutorizar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDReserva") %>'
                                                            OnCommand="lnkAutorizar_Command" Text="Confirmar" OnClientClick="return MsjAutorizar(this);">
                                                        </asp:LinkButton>
                                                    </span>
                                                </td>
                                                 <td data-label="Rechazar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkRechazar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDReserva") %>'
                                                            OnCommand="lnkRechazar_Command" Text="Rechazar" OnClientClick="return MsjRechazar(this);">
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
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
