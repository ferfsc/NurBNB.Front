using NurBnb.Front.Web.AppCode;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure.Huesped;
using NurBnbFront.Infrastructure.Huesped.Dto;
using NurBnbFront.Infrastructure.Propiedad;
using NurBnbFront.Infrastructure.Reserva;
using NurBnbFront.Infrastructure.Reserva.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web
{
    public partial class Reservas : System.Web.UI.Page
    {
        public static List<ListOfReservaDto> ReservaDtoList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarRegistro(true);
                CargarPropiedades();
                CargarHuespedes();
            }
        }

        private async void CargarPropiedades()
        {
            QueryPropiedades propiedades = new QueryPropiedades();

            propiedades.token = Sesion.Login.token;
            var listPropiedades = await propiedades.ObtenerPropiedades();

            Utils.FillCombo(ref cmbPropiedad, listPropiedades, "Titulo", "IDPropiedad");
            

        }

        private async void CargarHuespedes()
        {
           
            QueryHuesped huesped = new QueryHuesped();

            huesped.token = Sesion.Login.token;
            var huespedes = await huesped.ObtenerHuesped();
            var HuespedDtoList = huespedes.ToList<HuespedDto>();

            Utils.FillCombo(ref cmbHuesped, HuespedDtoList, "NombreCompleto", "HuespedID");


        }
        private void MostrarRegistro(bool Mostrar)
        {
            pnlRegistro.Visible = Mostrar;
            RegistroDatos.Visible = !Mostrar;

            if (Mostrar)
            {
                CargarReservas();
            }
        }
        private async void CargarReservas()
        {
            QueryReserva reserva = new QueryReserva();

            reserva.token = Sesion.Login.token;
            var reservas = await reserva.ObtenerReservas();
            ReservaDtoList = reservas.ToList<ListOfReservaDto>();
            if (ReservaDtoList != null)
            {
                rptDatos.DataSource = ReservaDtoList;
                rptDatos.DataBind();
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

                var reserva = ReservaDtoList.Find(x => x.IDReserva == Convert.ToString(e.CommandArgument));

                Sesion.SeleccionarCombo(ref cmbHuesped, reserva.HuespedID);
                Sesion.SeleccionarCombo(ref cmbPropiedad, reserva.PropiedadID);
                txtFechaInicio1.Value = reserva.FechaCheckin.ToString("dd/MM/yyyy");
                txtFechaInicio2.Value = reserva.FechaCheckOut.ToString("dd/MM/yyyy");                
                txtMotivo.Text = reserva.Motivo;
                Sesion.SeleccionarCombo(ref cmbEstado, "", reserva.Estado);
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
            RegisterReserva reserva = new RegisterReserva();

            reserva.token = Sesion.Login.token;

            var result = await reserva.RegistrarReserva(cmbHuesped.SelectedValue, cmbPropiedad.SelectedValue, 
                                                        Convert.ToDateTime(txtFechaInicio1.Value),
                                                        Convert.ToDateTime(txtFechaInicio2.Value),                                                       
                                                            txtMotivo.Text);

            if (result != null && result.Length > 0)
            {
                ucAlertas.CargarMensaje("Solicitud Registrada Exitosamente", MensajeAlertas.Tipo.Exitoso);
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