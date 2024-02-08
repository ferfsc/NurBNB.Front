using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace NurBnb.Front.Web.AppCode
{
    public class Sesion
    {

        public static NurBnbFront.Infrastructure.InicioLogin Login { get; set; }

        // public static LogicaSiscon.Proyecto Proyectos { get; set; }

        //public static void VaciarSesion()
        //{
        //    Login = null;
        //}

        //public static List<Material> Materiales { get; set; }

        #region Utilitarios

        //public static bool enLinea()
        //{            
        //    return (Login != null && Login.esUsuario);
        //}

        //public static void volverLogin()
        //{
        //    VaciarSesion();
        //    HttpContext.Current.Response.Redirect("Login.aspx");
        //}

        //public static void verificarEnLinea()
        //{
        //    if (!enLinea())
        //        volverLogin();
        //}

        public static void SeleccionarCombo(ref DropDownList pCmbCombo, string pStrValue = "", string pStrText = "")
        {
            if (pStrText != "")
            {
                if (pCmbCombo.Items.FindByText(pStrText) == null)
                    return;
                pCmbCombo.SelectedItem.Selected = false;
                pCmbCombo.Items.FindByText(pStrText).Selected = true;
            }
            else
            {
                if (pStrValue != "")
                {
                    if (pCmbCombo.Items.FindByValue(pStrValue) == null)
                        return;
                    pCmbCombo.SelectedItem.Selected = false;
                    pCmbCombo.Items.FindByValue(pStrValue).Selected = true;
                }
                else
                {
                    if (pCmbCombo.Items.Count > 0)
                        pCmbCombo.Items[0].Selected = true;
                }
            }
        }

        #endregion

        #region Seguridad

        internal static string EncriptarPass(string pass)
        {
            try
            {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                string password = pass;
                byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                int i = 0;
                while (i < dataMd5.Length)
                {
                    sb.AppendFormat("{0:x2}", dataMd5[i]);
                    i = i + 1;
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas al encriptar la contraseña.");
            }
        }

        #endregion
    }
}