using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web.Controles
{
    public partial class MensajeAlertas : System.Web.UI.UserControl
    {
        public enum Tipo
        {
            Default = -1,
            Exitoso = 0,
            Error = 1,
            Advertencia = 2,
            Info = 3,
        }

        private string[] _tipoAlertaString =
        {
            "uk-alert-success",
            "uk-alert-danger",
            "uk-alert-warning",
            "uk-alert-primary",
        };

        private string _mensaje;
        private int _tipo;


        public string MensajeError
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        //public string MensajeError { get; set; }

        public string TipoMensaje
        {
            get
            {
                switch (_tipo)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        return _tipoAlertaString[_tipo];
                    default: return "";
                }
            }
        }

        public string[] TipoAlertaString
        {
            get { return _tipoAlertaString; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void CargarMensaje(string mensaje, object tipo)
        {
            _mensaje = mensaje;
            _tipo = (int)tipo;
        }

        public void ErrorGenerico(bool verificaExtracto = false)
        {
            //if (verificaExtracto)
            //    _mensaje = Convert.ToString(Funciones.Lenguaje("Generico")["Error_Generico_VerificaExtracto"]);
            //else
            _mensaje = "En este momento no se puede procesar su transacción, por favor, intente más tarde";
            //_mensaje = Convert.ToString(Funciones.Lenguaje("Generico")["Error_Generico"]);
            _tipo = 1;
        }

        public void Limpiar()
        {
            _mensaje = string.Empty;
        }
    }
}