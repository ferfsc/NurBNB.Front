using NurBnb.Front.Web.AppCode;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure.Pago.Dto;
using NurBnbFront.Infrastructure.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web
{
    public partial class CatalogoDevolucion : System.Web.UI.Page
    {
        public static List<CatalogoDevolucionDto> listCatalogo = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                MostrarRegistro(true);

            }

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            MostrarRegistro(false);
            Utils.CleanControl(this);
        }
        protected void lnkEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                MostrarRegistro(false);

                var catalogo = listCatalogo.Find(x => x.CatalogoDevolucionId == Convert.ToString(e.CommandArgument));

                txtDescripcion.Text = catalogo.Descripcion.ToString();
                txtPorcentaje.Text = catalogo.PorcentajeDescuento.ToString();
                txtDia.Text=catalogo.NroDias.ToString();

            }
            catch (Exception ex)
            {
                ucAlertas.CargarMensaje(ex.Message, MensajeAlertas.Tipo.Advertencia);
                Utils.ScrollTop(this);
            }
            finally
            {
                Utils.CloseLoading(this);
            }
        }

        protected async void btnEnviar_Click(object sender, EventArgs e)
        {
            RegisterCatalogoDevolucion catalogo = new RegisterCatalogoDevolucion();

            catalogo.token = Sesion.Login.token;

            var result = await catalogo.RegistrarCatalogoDevolucion(txtDescripcion.Text, Convert.ToInt32(txtPorcentaje.Text), Convert.ToInt32(txtDia.Text));

            if (result != null && result.Length > 0)
            {
                ucAlertas.CargarMensaje("Catalogo Registrado Exitosamente", MensajeAlertas.Tipo.Exitoso);
                MostrarRegistro(true);
            }
            else
            {
                ucAlertas.CargarMensaje("Error al Registrar el dato", MensajeAlertas.Tipo.Error);
            }

            Utils.CloseLoading(this);
            Utils.ScrollTop(this);
        }

        #region Métodos Privados
        private void MostrarRegistro(bool Mostrar)
        {
            pnlRegistro.Visible = Mostrar;
            RegistroDatos.Visible = !Mostrar;

            if (Mostrar)
            {
                CargarCatalogoPago();
            }
        }
        private async void CargarCatalogoPago()
        {
            QueryCatalogoDevolucion catalogo = new QueryCatalogoDevolucion();

            catalogo.token = Sesion.Login.token;
            var catalogos = await catalogo.ObtenerCatalogoDevolucion();
            listCatalogo = catalogos.ToList<CatalogoDevolucionDto>();
            if (listCatalogo != null)
            {
                rptDatos.DataSource = listCatalogo;
                rptDatos.DataBind();
            }

        }
        #endregion
    }
}