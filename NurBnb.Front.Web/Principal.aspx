<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="NurBnb.Front.Web.Principal" %>

<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">

    <link href="assets/css/Teclado.css" rel="stylesheet" />
    <script src="assets/js/Teclado.js"></script>
    <script src="assets/js/jquery.numeric.js"></script>

    <script type="text/javascript">


        function pageLoad() {
            cargar_random();

        }
    </script>
</asp:Content>

<asp:Content ID="Contenido" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updGeneral" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="RegistroDatos">
                <div id="panelDatosTransferencia" class="uk-margin-small">
                    <div class="uk-margin-large">                       
                        <div class="uk-height-medium uk-flex uk-flex-center uk-flex-middle uk-background-cover uk-light"
                            sources="srcset: https://images.unsplash.com/photo-1487837647815-bbc1f30cd0d2?fit=crop&w=650&h=433&q=80; media: (min-width: 1200px)"
                            data-src="https://images.unsplash.com/photo-1546349851-64285be8e9fa?fit=crop&w=650&h=433&q=80"
                            uk-img>
                            <h1>Background Image</h1>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
