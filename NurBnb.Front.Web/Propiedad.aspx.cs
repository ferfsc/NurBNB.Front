using NurBnb.Front.Web.AppCode;
using NurBnbFront.Infrastructure.Huesped.Dto;
using NurBnbFront.Infrastructure.Huesped;
using NurBnbFront.Infrastructure.Propiedad;
using NurBnbFront.Infrastructure.Propiedad.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NurBnb.Front.Web.Controles;

namespace NurBnb.Front.Web
{
    public partial class Propiedad : System.Web.UI.Page
    {
        public static List<ListofPropiedadesDto> ListofPropiedadesDtoList = null;
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
                CargarPropiedades();
            }
            else
            {
                CargarPropietarios();
                

            }
        }

        private async void CargarPropiedades()
        {
            QueryPropiedades propiedades = new QueryPropiedades();

            propiedades.token = Sesion.Login.token;
            var listPropiedades = await propiedades.ObtenerPropiedades();
            ListofPropiedadesDtoList = listPropiedades;
            if (ListofPropiedadesDtoList != null)
            {
                rptDatos.DataSource = ListofPropiedadesDtoList;
                rptDatos.DataBind();
            }

        }

        private async void CargarPropietarios()
        {
            QueryHuesped huesped = new QueryHuesped();

            huesped.token = Sesion.Login.token;
            var huespedes = await huesped.ObtenerHuesped();
            var HuespedDtoList = huespedes.ToList<HuespedDto>();

            Utils.FillCombo( ref cmbPropietario, HuespedDtoList, "NombreCompleto", "HuespedID");
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            MostrarRegistro(false); 
            Utils.CleanControl(this);
            Utils.SeleccionarCombo(ref cmbEstado, "0");
            cmbEstado.Enabled = false;
        }

        protected void lnkEditar_Command(object sender, CommandEventArgs e)
        {
            
            try
            {
                MostrarRegistro(false);
                cmbEstado.Enabled = true;

                var propiedad = ListofPropiedadesDtoList.Find(x => x.IDPropiedad.ToString() == Convert.ToString(e.CommandArgument));

                Sesion.SeleccionarCombo(ref cmbPropietario, propiedad.PropietarioID.ToUpper()); 

                txtTitulo.Text = propiedad.Titulo;
                txtPrecio.Text = propiedad.Precio.ToString();
                txtDetalle.Text = propiedad.Detalle;
                txtDireccion.Text = propiedad.Ubicacion;
                Sesion.SeleccionarCombo(ref cmbEstado, "" , propiedad.Estado);

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
            RegisterPropiedad propiedad = new RegisterPropiedad();

            propiedad.token = Sesion.Login.token;

            var result = await propiedad.RegistrarPropiedad(cmbPropietario.SelectedValue, txtTitulo.Text, 
                                                            Convert.ToDecimal(txtPrecio.Text), txtDetalle.Text, txtDireccion.Text, 
                                                            cmbEstado.SelectedValue);

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
    }
}