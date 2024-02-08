<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Huesped.aspx.cs" Inherits="NurBnb.Front.Web.Huesped" %>

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
            <h1 id="hTitulo" class="titulos">Registro de Huespedes</h1>
            <ucMS:ucMS runat="server" ID="ucAlertas" />

            <div id="pnlRegistro" runat="server">
                <div class="uk-form-stacked uk-margin-small">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Nuevo" CssClass="uk-button uk-button-primary uk-width-medium@s" OnClick="btnRegistrar_Click" />
                </div>

                <div class="uk-form-stacked uk-margin-small" />

                <div id="cuentas_origen">
                    <ul uk-accordion>
                        <li class="uk-open">
                            <a class="uk-accordion-title uk-text-center" href="#">Clientes</a>
                            <div class="uk-accordion-content uk-margin-remove-top uk-overflow-auto">
                                <table class="uk-table uk-table-divider uk-table-hover uk-table-middle uk-table-striped uk-table-small uk-table-responsive cuentasOrigen">
                                    <asp:Repeater ID="rptDatos" runat="server">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr class="trSubTitulo">                                                    
                                                    <th>Nombres</th>
                                                    <th>Apellidos</th>
                                                    <th>Nro Doc</th>
                                                    <th>Email</th>
                                                    <th>Direccion</th>
                                                    <th>Ciudad</th>
                                                    <th>Pais</th>
                                                    <th>Telefono</th>
                                                    <th>Codigo Postal</th>
                                                    <th>Editar</th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="trSubTitulo_item uk-text-right uk-text-center@s">                                               
                                                <td data-label="Nombres">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="lblCodigo" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "HuespedID") %>' />
                                                        <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' />                                                        
                                                    </span>
                                                </td>
                                                <td data-label="Apellidos" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Apellidos") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Nro Doc" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NroDoc") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Email" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Direccion" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Calle") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Ciudad" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Ciudad") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Pais" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Pais") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Telefono" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Telefono") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Codigo Postal" class="uk-text-left@s">
                                                    <span class="Etiqueta">
                                                        <asp:Label ID="Label11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CodigoPostal") %>' />
                                                    </span>
                                                </td>
                                                <td data-label="Editar">
                                                    <span class="Etiqueta">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CssClass="link_saldo" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "HuespedID") %>'
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
                                <asp:Label ID="Label8" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Nombres</asp:Label>
                                <asp:TextBox ID="txtNombres" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label12" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Apellidos</asp:Label>
                                <asp:TextBox ID="txtApellidos" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label13" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Nro Doc</asp:Label>
                                <asp:TextBox ID="txtNroDoc" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <%-- <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label runat="server" CssClass="custom-dropdown">
                                    <asp:Label ID="Label9" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Estado</asp:Label>
                                    <asp:DropDownList ID="cmbEstado" runat="server" CssClass="customSelect uk-select uk-form-small" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="cmbEstado_SelectedIndexChanged">
                                        <asp:ListItem Value="-1">Seleccionar</asp:ListItem>
                                        <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                        <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                    </asp:DropDownList>
                                </asp:Label>
                            </div>
                            <div id="divMotivo" runat="server" class="uk-width-1-3">
                                <asp:Label ID="Label3" runat="server" CssClass="il_lb_campos uk-form-label texto_15">Motivo Deshabilitaci&oacute;n</asp:Label>
                                <asp:TextBox ID="txtMotivo" runat="server" CssClass="uk-input uk-form-small" MaxLength="100">
                                </asp:TextBox>
                            </div>--%>
                        </div>
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label3" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Teléfono</asp:Label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label14" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Email</asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label15" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Dirección</asp:Label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div uk-grid class="uk-grid-small">
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label16" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Ciudad</asp:Label>
                                <asp:TextBox ID="txtCiudad" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label17" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Pais</asp:Label>
                                <asp:TextBox ID="txtPais" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-2 uk-width-1-3@m">
                                <asp:Label ID="Label18" CssClass="il_lb_campos uk-form-label texto_15" runat="server">Codigo Postal</asp:Label>
                                <asp:TextBox ID="txtCodPostal" runat="server" CssClass="uk-input uk-form-small claseMonto uk-text-left">
                                </asp:TextBox>
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
