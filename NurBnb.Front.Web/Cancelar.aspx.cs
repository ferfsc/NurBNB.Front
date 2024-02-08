using NurBnb.Front.Web.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web
{
    public partial class Cancelar : System.Web.UI.Page
    {
        //private static List<SolicitudesPendientesDto> _SolicitudesPendientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                Cargar_Solicitudes_Pendientes();
            }
        }

        private void Cargar_Solicitudes_Pendientes()
        {
            //clsAutorizacion = new RegistrarAutorizacion(Sesion.Login.Id_Empresa);

            //clsAutorizacion.Cod_Persona = Sesion.Login.ID_Personal;
            //_SolicitudesPendientes = clsAutorizacion.CargarListaSolicitudesPendientes();


            //rptAutorizacion.DataSource = _SolicitudesPendientes;
            //rptAutorizacion.DataBind();
        }

        protected void lnkAutorizar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lnkRechazar_Command(object sender, CommandEventArgs e)
        {

        }
    }
}