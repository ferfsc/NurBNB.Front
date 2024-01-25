using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

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
    }
}