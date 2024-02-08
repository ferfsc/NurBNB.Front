using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using System.Text;

namespace NurBnb.Front.Web.AppCode
{
    public class Utils : System.Web.UI.Page
    {
        public static string ObtenerIP()
        {
            try
            {
                var ip = (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                    ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                    : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (ip.Contains(","))
                    ip = ip.Split(',').First().Trim();
                return ip;
            }
            catch (Exception)
            {
                return "127.0.0.127";
            }
        }

        public static string GetMACAddress()
        {
            String st = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                OperationalStatus ot = nic.OperationalStatus;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    st = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return st;
        }

        public static string GetDominio()
        {
            String st = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                OperationalStatus ot = nic.OperationalStatus;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    st = nic.GetIPProperties().DnsSuffix;
                    break;
                }
            }

            return st;
        }

        public static void ScrollTop(object page)
        {
            if (page != null)
            {
                ScriptManager.RegisterClientScriptBlock((Page)page, page.GetType(), "scrolltop", "scrolltop();",
                    true);
            }
        }

        public static void CloseLoading(object page)
        {
            if (page != null)
            {
                ScriptManager.RegisterClientScriptBlock((Page)page, page.GetType(), "closeLoading", "closeLoading();",
                    true);
            }
        }

        public static void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }

        public static void CleanControl(Page page)
        {
            foreach (Control control in page.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }

        public static JObject Lenguaje(string valor)
        {
            JObject languaje;
            string path = ""; //ConfigurationManager.AppSettings["rutaWebConfig"];
            path = Path.Combine(path, "Menu.json");            
            languaje = JObject.Parse(File.ReadAllText(path, Encoding.UTF8));
            return (JObject)(languaje[valor] ?? new JObject());
        }

        public static void FillCombo<TSource>(ref DropDownList ddl, TSource dataSource, string textField, string valueField) 
        {

            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;
            ddl.DataSource = dataSource;
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }

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
    }       
}