using NurBnb.Front.Web.AppCode;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure.Huesped;
using NurBnbFront.Infrastructure.Huesped.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web
{
    public partial class Huesped : System.Web.UI.Page
    {
        public static List<HuespedDto> HuespedDtoList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarRegistro(true);
            }
        }

        private void MostrarRegistro(bool Mostrar)
        {
            pnlRegistro.Visible = Mostrar;
            RegistroDatos.Visible = !Mostrar;

            if (Mostrar)
            {
                CargarHuespedes();
            }
        }
        private async void CargarHuespedes()
        {
            QueryHuesped huesped = new QueryHuesped();

            huesped.token = Sesion.Login.token;
            var huespedes = await huesped.ObtenerHuesped();
            HuespedDtoList = huespedes.ToList<HuespedDto>();
            if (huespedes != null)
            {
                rptDatos.DataSource = HuespedDtoList;
                rptDatos.DataBind();
            }

        }
        protected void lnkEditar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                MostrarRegistro(false);

                var _cliente = HuespedDtoList.Find(x => x.HuespedID == Convert.ToString(e.CommandArgument));

                txtNombres.Text = _cliente.Nombre;
                txtApellidos.Text = _cliente.Apellidos;
                txtNroDoc.Text = _cliente.NroDoc;
                txtTelefono.Text = _cliente.Telefono;
                txtEmail.Text = _cliente.Email;
                txtDireccion.Text = _cliente.Calle;
                txtCiudad.Text = _cliente.Ciudad;
                txtPais.Text = _cliente.Pais;
                txtCodPostal.Text = _cliente.CodigoPostal;

                // por si fuera Sesion.SeleccionarCombo(ref cmbEstado, _cliente.estado.ToString());

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
            RegisterHuesped huesped = new RegisterHuesped();

            huesped.token = Sesion.Login.token;

            var result = await huesped.RegistrarHuesped(txtNombres.Text, txtApellidos.Text, txtNroDoc.Text,
                                                  txtTelefono.Text, txtEmail.Text, txtDireccion.Text,
                                                  txtCiudad.Text, txtPais.Text, txtCodPostal.Text);

            if (result != null && result.Length > 0)
            {
                ucAlertas.CargarMensaje("Registro Modificado exitosamente", MensajeAlertas.Tipo.Exitoso);
                MostrarRegistro(true);
            }
            else
            {
                ucAlertas.CargarMensaje("Error al Registrar el dato", MensajeAlertas.Tipo.Error);
            }

            Utils.CloseLoading(this);
            Utils.ScrollTop(this);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            MostrarRegistro(false);
            Utils.CleanControl(this);
        }
    }
}