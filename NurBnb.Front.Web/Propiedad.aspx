<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Propiedad.aspx.cs" Inherits="NurBnb.Front.Web.Propiedad" %>

<%@ Register Src="~/Controles/MensajeAlertas.ascx" TagPrefix="ucMS" TagName="ucMS" %>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">


        function pageLoad() {
            cargar_random();

            <%--$("#<%= cmbPrincipal.ClientID %>").change(function () {
                bloqueo();
            });--%>
        }

    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="updGeneral" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 id="hTitulo" class="titulos">Registro de Propiedad</h1>
            <ucMS:ucMS runat="server" ID="ucAlertas" />

            <div id="pnlRegistro" runat="server">
                <div class="uk-form-stacked uk-margin-small">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Nuevo" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnRegistrar_Click" />
                </div>

                <div class="uk-form-stacked uk-margin-small" />

                <div id="cuentas_origen">
                    <ul uk-accordion>
                        <li class="uk-open">
                            <a class="uk-accordion-title uk-text-center" href="#">Proiedad</a>
                            <div class="uk-accordion-content uk-margin-remove-top uk-overflow-auto">
                                <table class="uk-table uk-table-divider uk-table-hover uk-table-middle uk-table-striped uk-table-small uk-table-responsive cuentasOrigen">
                                    <asp:Repeater ID="rptDatos" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr class="trSubTitulo">
                                                    <th>Propietario</th>
                                                    <th>Titulo</th>
                                                    <th>Precio</th>
                                                    <th>Detalle</th>
                                                    <th>Estado</th>
                                                    <th>Editar</th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trSubTitulo_item uk-text-right uk-text-center@s">
                                                <td data-label="Propietario" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Propietario") %>' />
                                                        <asp:Label ID="Label19" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "IDPropiedad") %>' />
                                                        <asp:Label ID="Label5" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "PropietarioID") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Titulo" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Titulo") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Precio" class="uk-text-right@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Precio") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Detalle" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Detalle") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Estado" class="uk-text-center@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Estado") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Editar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDPropiedad") %>'
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
                                    <asp:Label ID="Label9" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Propietario</asp:Label>
                                    <asp:DropDownList ID="cmbPropietario" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label12" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Titulo</asp:Label>
                                <asp:TextBox ID="txtTitulo" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label13" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Precio</asp:Label>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-right@s">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label3" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Detalle</asp:Label>
                                <asp:TextBox ID="txtDetalle" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label14" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Dirección</asp:Label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label4" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Estado</asp:Label>
                                    <asp:DropDownList ID="cmbEstado" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true">
                                        <asp:ListItem Value="-1" Text="Seleccionar"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Disponible"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Solicitado"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Reservado"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Cancelado"></asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="uk-margin-small">
                    <div uk-grid class="uk-grid-small">
                        <div class="uk-width-1-2 uk-width-1-3@m">
                        </div>
                        <div class="uk-width-1-2 uk-width-1-3@m">
                            <asp:Button ID="btnEnviar" runat="server" Text="Guardar Registro" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnEnviar_Click" />
                        </div>
                        <div class="uk-width-1-2 uk-width-1-3@m">
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

