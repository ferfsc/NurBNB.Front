using NurBnb.Front.Web.AppCode;
using NurBnbFront.Infrastructure.Reserva.Dto;
using NurBnbFront.Infrastructure.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure.Propiedad;

namespace NurBnb.Front.Web
{
    
    public partial class Cancelar : System.Web.UI.Page
    {
        public static List<ListOfReservaDto> ReservaDtoList = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                Cargar_Solicitudes_Pendientes();
            }
        }

        private async void Cargar_Solicitudes_Pendientes()
        {
            QueryReserva reserva = new QueryReserva();

            reserva.token = Sesion.Login.token;
            var reservas = await reserva.ObtenerReservas(TipoEstadoReserva.Solicitado.ToString());
            ReservaDtoList = reservas.ToList<ListOfReservaDto>();
            if (ReservaDtoList != null && ReservaDtoList.Count > 0)
            {
                rptAutorizacion.DataSource = ReservaDtoList;
                rptAutorizacion.DataBind();
            }
        }

        protected async void lnkAutorizar_Command(object sender, CommandEventArgs e)
        {           

            var _solicitud = ReservaDtoList.Find(x => x.IDReserva == e.CommandArgument.ToString());

            AutorizarReserva reserva = new AutorizarReserva(){ 
                Token = Sesion.Login.token,
            };

            var result = await reserva.ConfirmarReserva(_solicitud.IDReserva);

            if (result != null && result.Length > 0)
            {
                ucAlertas.CargarMensaje("Confirmación de Reserva exitosa!!!", MensajeAlertas.Tipo.Exitoso);
                Cargar_Solicitudes_Pendientes();
            }
            else
            {
                ucAlertas.CargarMensaje("Error al Registrar el dato", MensajeAlertas.Tipo.Error);
            }

            Utils.CloseLoading(this);
            Utils.ScrollTop(this);
        }

        protected async void lnkRechazar_Command(object sender, CommandEventArgs e)
        {
            var _solicitud = ReservaDtoList.Find(x => x.IDReserva == e.CommandArgument.ToString());

            AutorizarReserva reserva = new AutorizarReserva()
            {
                Token = Sesion.Login.token,
            };

            var result = await reserva.RechazarReserva(_solicitud.IDReserva);

            if (result != null && result.Length > 0)
            {
                ucAlertas.CargarMensaje("Rechazo de Reserva exitosa!!!", MensajeAlertas.Tipo.Exitoso);
                Cargar_Solicitudes_Pendientes();
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