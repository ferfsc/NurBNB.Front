<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeAlertas.ascx.cs" Inherits="NurBnb.Front.Web.Controles.MensajeAlertas" %>


<div id="MensajeAlert">
<% if (!String.IsNullOrEmpty(MensajeError))
   { %>
    <div class=" uk-margin-small <%= TipoMensaje %>" uk-alert>
        <a class="uk-alert-close" uk-close></a>
        <p>
            <%: MensajeError %>
        </p>
    </div>
<% } %>
</div>