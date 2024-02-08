using NurBnb.Front.Web.AppCode;
using NurBnbFront.Infrastructure.Reserva.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NurBnbFront.Infrastructure.Pago.Dto;
using NurBnbFront.Infrastructure.Pago;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure.Reserva;

namespace NurBnb.Front.Web
{
    public partial class CatalogoPago : System.Web.UI.Page
    {
        public static List<CatalogoPagoDto> listCatalogo = null;
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

                var catalogo = listCatalogo.Find(x => x.CatalogoId == Convert.ToString(e.CommandArgument));

                txtDescripcion.Text= catalogo.Descripcion.ToString();
                txtPorcentaje.Text=catalogo.Porcentaje.ToString();
                Sesion.SeleccionarCombo(ref cmbTipo, catalogo.Tipo);
               
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
            RegisterCatalogoPago catalogo = new RegisterCatalogoPago();

            catalogo.token = Sesion.Login.token;

            var result = await catalogo.RegistrarCatalogoPago(txtDescripcion.Text, Convert.ToInt32(txtPorcentaje.Text),Convert.ToInt16(cmbTipo.SelectedValue));

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
        private  void MostrarRegistro(bool Mostrar)
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
            QueryCatalogoPago catalogo = new QueryCatalogoPago();

            catalogo.token = Sesion.Login.token;
            var catalogos = await catalogo.ObtenerCatalogoPago();
            listCatalogo = catalogos.ToList<CatalogoPagoDto>();
            if (listCatalogo != null)
            {
                rptDatos.DataSource = listCatalogo;
                rptDatos.DataBind();
            }

        }
        #endregion
    }
}