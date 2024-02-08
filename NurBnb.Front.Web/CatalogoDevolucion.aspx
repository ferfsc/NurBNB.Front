<%@ Page Async="true" Language="C#" MasterPageFile="~/Index.Master"  AutoEventWireup="true" CodeBehind="CatalogoDevolucion.aspx.cs" Inherits="NurBnb.Front.Web.CatalogoDevolucion" %>
<%@ Register Src="~/Controles/MensajeAlertas.ascx" TagPrefix="ucMS" TagName="ucMS" %>
<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">

        function MsjEliminar(element) {
            var mensaje = "¿Está seguro que desea Eliminar el catalogo?";
            UIkit.modal.confirm(mensaje, { 'labels': { 'cancel': 'Cancelar', 'ok': 'Aceptar' } }).then(function () {
                bloqueo();
                location.href = element.href;
            }, function () {
            });
            return false;
        }
        function MsjAutorizar(element) {
            var mensaje = "¿Está seguro que desea Autorizar el catalogo?";
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
            <h1 id="hTitulo" runat="server" class="titulos">Formulario de Registro de Catálogo de Devoluciones</h1>
            <ucMS:ucMS runat="server" ID="ucAlertas" />
            <asp:HiddenField ID="hfMensaje" runat="server" />

            <div id="pnlRegistro" runat="server">
                <div class="uk-form-stacked uk-margin-small">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Catálogo" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnRegistrar_Click" />
                </div>
                <div class="uk-form-stacked uk-margin-small" />

                <div id="cuentas_origen">
                    <ul uk-accordion>
                        <li class="uk-open">
                            <a class="uk-accordion-title uk-text-center" href="#">Lista de Catalogo de Devoluciones</a>
                            <div class="uk-accordion-content uk-margin-remove-top uk-overflow-auto">
                                <table class="uk-table uk-table-divider uk-table-hover uk-table-middle uk-table-striped uk-table-small uk-table-responsive cuentasOrigen">
                                    <asp:Repeater ID="rptDatos" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr class="trSubTitulo">
                                                    <th>Catalogo</th>
                                                    <th>Descripción</th>
                                                    <th>Dias</th>
                                                    <th>Porcentaje Descuento</th>
                                                    <th>Editar</th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trSubTitulo_item uk-text-right uk-text-center@s">
                                                <td data-label="Catalogo" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CatalogoDevolucionId") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Descripcion" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblDescripcion" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Descripcion") %>' />
                                                    </span>
                                                </td>
                                                 <td data-label="Nro.Dias" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblDia" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NroDias") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Porcentaje Descuento" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblPorcentaje" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PorcentajeDescuento") %>' />
                                                    </span>
                                                </td>
                                               
                                                <td data-label="Editar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CatalogoDevolucionId") %>'
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
                                    <asp:Label ID="Label2" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Descripcion</asp:Label>
                                     <asp:TextBox ID="txtDescripcion" runat="server" CssClass="uk-input uk-form-large claseMonto uk-text-left"/>
 </asp:TextBox>
                                </asp:Label></div></div>
                        <div uk-grid class="uk-grid-small">
                            
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label1" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Nro.Dias</asp:Label>
                                   <asp:TextBox ID="txtDia" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left"/>
                                </asp:Label></div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
     <asp:Label runat="server" CssClass="custom-dropdown">
         <asp:Label ID="Label8" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Porcentaje Descuento</asp:Label>
         <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left"/>
     </asp:Label></div>

                        </div></div>
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

