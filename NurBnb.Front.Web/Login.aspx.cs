using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NurBnb.Front.Web.Controles;
using NurBnbFront.Infrastructure;
using NurBnb.Front.Web.AppCode;
using Newtonsoft.Json;

namespace NurBnb.Front.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private MensajeAlertas mensajeAlertas = new MensajeAlertas();
        private static log4net.ILog log { get; set; } = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); // Es lo mismo q poner type(Login)

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    VaciarDatos();
                }
            }
            catch (ArgumentException ex)
            {
                lblMensajeError.Text = ex.Message;
                lblMensajeError.Focus();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                mensajeAlertas.ErrorGenerico();
                lblMensajeError.Text = mensajeAlertas.MensajeError;
            }
            finally
            {
                Utils.CloseLoading(this);
                
            }
        }
        private void VaciarDatos()
        {
            txtUsuario.Text = string.Empty;
            txtUsuario.Focus();
            txtPassword.Text = string.Empty;
        }

        private void ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                throw new ArgumentException("Ingrese su Usuario");

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                throw new ArgumentException("Ingrese su Clave");

        }

        protected async void btnContinuarLogin_Click(object sender, EventArgs e)
        {

            try
            {

                ValidarDatos();
                InicioLogin objLogin = new InicioLogin();
                
                //Conexion.Token token = await objLogin.InicioSession(txtUsuario.Text, txtPassword.Text);
                Conexion.Token token = await objLogin.InicioSession("admin@fake.com", "admin@123");
                //Conexion.Token token = await objLogin.InicioSession("admin@fake.com", "Admin123*");
                

                if (token != null && token.jwt != null && token.jwt.Length > 0)
                {
                    Sesion.Login = objLogin;
                    Response.Redirect("Principal.aspx", false);
                }
                else
                    lblMensajeError.Text = "Ingreso invalido.";
            }
            catch (ArgumentException ex1)
            {
                log.Error(ex1.Message, ex1);
                lblMensajeError.Text = ex1.Message;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                lblMensajeError.Text = ex.Message;
            }
            finally
            {
                Utils.CloseLoading(this);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            VaciarDatos();
            Response.Redirect("~/Login.aspx");
        }
    }
}