<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="NurBnb.Front.Web.Principal" %>



<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">


        function pageLoad() {
            cargar_random();

            <%--$("#<%= cmbHabilitado.ClientID %>").change(function () {
                bloqueo();
            });--%>


        }
    </script>
</asp:Content>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updGeneral" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="RegistroDatos">
                <div id="panelDatosTransferencia" class="uk-margin-small">
                    <div class="uk-margin-large">
                        <div uk-grid class="uk-grid-small">                            
                            <div class="uk-width-1-1 uk-flex-center uk-width-1-1@m">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/principal_siscon.png" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btnRegistrar" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
