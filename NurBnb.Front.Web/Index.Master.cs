﻿using log4net;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace NurBnb.Front.Web
{
    public partial class Index : MasterPage
    {

        public static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CargarFechas();
                    CargarMenu();
                    hCliente.InnerText = ""; // Sesion.Login.Nombres + " " + Sesion.Login.Ap_Paterno;
                    hRepresentante.InnerText = ""; // Sesion.Login.Mail;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }

        private void CargarMenu()
        {
            string dataSetTemplate = $"{{\"Menu\": {DevolverMenu()}}}";
            DataSet dsMenu = JsonConvert.DeserializeObject<DataSet>(dataSetTemplate);         
            List<Dictionary<string, object>> menuArray = MenuArray(dsMenu.Tables[0]);
            string menu = ArmarMenu(menuArray);
            nav.InnerHtml = $"<ul id=\"nav1\" class=\"uk-nav uk-nav-primary metismenu\">{menu}</ul>";
            nav_tablet.InnerHtml = $"<ul id=\"nav2\" class=\"uk-nav uk-nav-primary uk-dropdown-nav metismenu\">{menu}</ul>";
            nav_smart.InnerHtml = $"<ul id=\"nav3\" class=\"uk-nav uk-nav-primary uk-dropdown-nav metismenu\">{menu}</ul>";
        }

        #region menu

        private List<Dictionary<string, object>> MenuArray(DataTable dtMenu)
        {
            List<Dictionary<string, object>> menu = new List<Dictionary<string, object>>();
            string pagename = Path.GetFileName(Request.ServerVariables["SCRIPT_NAME"]);

            string idDesplegar = "";
            foreach (DataRow dbRow in dtMenu.Rows)
            {
                if (Convert.ToString(dbRow["pantallaNueva"]) == pagename)
                {
                    idDesplegar = Convert.ToString(Convert.ToString(dbRow["idOpcionPadre"]) == "0"
                        ? dbRow["idOpcion"]
                        : dbRow["idOpcionPadre"]);
                    break;
                }
            }

            foreach (DataRow dbRow in dtMenu.Rows)
            {
                if (Convert.ToString(dbRow["idOpcionPadre"]) == "0")
                {
                    Dictionary<string, object> item = new Dictionary<string, object>();
                    item.Add("active", (idDesplegar == Convert.ToString(dbRow["idOpcion"])));
                    item.Add("url", Convert.ToString(dbRow["pantallaNueva"]));
                    item.Add("texto", Page.Server.HtmlDecode(Convert.ToString(dbRow["textoOpcion"])));
                    item.Add("id", Convert.ToString(dbRow["idOpcion"]));                    
                    item.Add("items", MenuItems(dtMenu, Convert.ToString(dbRow["idOpcion"]), 0, pagename));
                    menu.Add(item);
                }
            }

            return menu;
        }

        private List<Dictionary<string, object>> MenuItems(DataTable dtMenu, string id, int idFactor, string pagename)
        {
            List<Dictionary<string, object>> submenu = new List<Dictionary<string, object>>();

            foreach (DataRow dbRow in dtMenu.Rows)
            {
                if (Convert.ToString(dbRow["idOpcionPadre"]) == id)
                {
                    Dictionary<string, object> item = new Dictionary<string, object>();
                    item.Add("active", false);
                    item.Add("url", Convert.ToString(dbRow["pantallaNueva"]));
                    item.Add("texto", Page.Server.HtmlDecode(Convert.ToString(dbRow["textoOpcion"])));
                    pagename = Page.Server.HtmlDecode(pagename);
                    item.Add("id", Convert.ToString(dbRow["idOpcion"]));
                    switch (idFactor)
                    {
                        case 1:
                            {
                                switch (item["url"])
                                {
                                    case "ActivarSoftToken.aspx":
                                    case "CambioSoftToken.aspx":
                                    case "CambioClaveTransaccional.aspx":
                                        continue;
                                    default:
                                        item["active"] = (pagename == (string)item["url"]);
                                        submenu.Add(item);
                                        break;
                                }

                                break;
                            }
                        case 2:
                            {
                                switch (item["url"])
                                {
                                    case "ActivarTokenFisico.aspx":
                                    case "CambioClaveTransaccional.aspx":
                                        continue;
                                    default:
                                        {
                                            item["active"] = (pagename == (string)item["url"]);
                                            submenu.Add(item);
                                            break;
                                        }
                                }

                                break;
                            }
                        default:
                            {
                                switch (item["url"])
                                {
                                    case "ActivarTokenFisico.aspx":
                                    case "ActivarSoftToken.aspx":
                                    case "BajaToken.aspx":
                                    case "CambioSoftToken.aspx":
                                        continue;
                                    default:
                                        {
                                            item["active"] = (pagename == (string)item["url"]);
                                            submenu.Add(item);
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }

            return submenu;
        }

        private string ArmarMenu(List<Dictionary<string, object>> menu)
        {
            StringBuilder menuhtml =  new StringBuilder();
            for (int i = 0; i < menu.Count; ++i)
            {
                Dictionary<string, object> item = menu[i];
                List<Dictionary<string, object>> items = (List<Dictionary<string, object>>)item["items"];
                bool active = (bool)item["active"];

                if (items.Count > 0)
                {
                    menuhtml.Append(
                        $"<li id=\"li{i}\" class=\"uk-parent{((active) ? " uk-open mm-active" : "")}{((i == menu.Count - 1) ? " last" : "")}\">" +
                        $"<a {((active) ? "class=\"active\" aria-expanded=\"true\"" : "")} href=\"#\">{item["texto"]}</a>" +
                        $"<ul class=\"uk-nav-sub\">");
                    for (int j = 0; j < items.Count; ++j)
                    {
                        Dictionary<string, object> subitem = items[j];
                        menuhtml.Append(
                             $"<li{((bool)subitem["active"] ? $" class=\"uk-active\"" : "")}>" +
                            $"<a onclick=\"BlockMaster(this)\" id=\"li{i}.{j}\" href=\"{subitem["url"]}\" {((bool)subitem["active"] ? $" class=\"uk-active\"" : "")}>{subitem["texto"]}</a>" +
                            $"</li>");
                    }

                    menuhtml.Append($"</ul>");
                }
                else
                {
                    menuhtml.Append($"<li id=\"li{i}\" class=\"pri{((active) ? " uk-active" : "")}{((i == menu.Count - 1) ? " last" : "")}\">");
                    menuhtml.Append(
                        $"<a onclick=\"BlockMaster(this)\" {((active) ? "class=\"active\"" : "")} href=\"{item["url"]}\">{item["texto"]}</a>");
                }

                menuhtml.Append("</li>");
            }

            return menuhtml.ToString();
        }

        #endregion

        private void CargarFechas()
        {

            this.lblFecha.Text = DateTime.Now.ToShortDateString() + "  ";
            this.slbFecha.Text = DateTime.Now.ToShortDateString() + "  ";
            string cadenaHora = DateTime.Now.ToLongTimeString();
            string[] arregloHora = cadenaHora.Split(new char[] { ' ' });
            this.lblHora.Text = arregloHora[0].ToString();
            this.slbHora.Text = arregloHora[0].ToString();
        }

        public String ObtenerTimeOut(string nodo, string atributo, string appPath)
        {
            XmlDocument myConfig = new XmlDocument();
            myConfig.Load(Path.Combine(ConfigurationManager.AppSettings["rutaWebConfig"], "web.config"));
            XmlNode n, n2 = null;
            XmlNodeList l = myConfig.GetElementsByTagName(nodo);
            n = l.Item(0);
            n2 = n.Attributes.GetNamedItem(atributo);
            return n2.Value;
        }

        protected void salir_Click(object sender, EventArgs e)
        {
            //Sesion.VaciarSesion();
            HttpContext.Current.Response.Redirect("Login.aspx");
        }

        protected void contact_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Contactenos.aspx");
        }

        private string DevolverMenu()
        {
            StringBuilder sbMenu = new StringBuilder();

            sbMenu.Append("[  ");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 1,");
            sbMenu.Append("    \"textoOpcion\": \"Reservas\",");
            sbMenu.Append("    \"idOpcionPadre\": 0,");
            sbMenu.Append("    \"pantalla\": \"#\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"#\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 2,");
            sbMenu.Append("    \"textoOpcion\": \"Solicitud de Reserva\",");
            sbMenu.Append("    \"idOpcionPadre\": 1,");
            sbMenu.Append("    \"pantalla\": \"Reservas.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmSolicitudCompra.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 3,");
            sbMenu.Append("    \"textoOpcion\": \"Autorizar\",");
            sbMenu.Append("    \"idOpcionPadre\": 0,");
            sbMenu.Append("    \"pantalla\": \"#\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"#\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 4,");
            sbMenu.Append("    \"textoOpcion\": \"Autorizar Solicitud\",");
            sbMenu.Append("    \"idOpcionPadre\": 3,");
            sbMenu.Append("    \"pantalla\": \"AutorizarSolicitud.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"AutorizarSolicitud.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 5,");
            sbMenu.Append("    \"textoOpcion\": \"Parametros\",");
            sbMenu.Append("    \"idOpcionPadre\": 0,");
            sbMenu.Append("    \"pantalla\": \"#\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"#\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 6,");
            sbMenu.Append("    \"textoOpcion\": \"Proyectos\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"frmBusquedaProyecto.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmBusquedaProyecto.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 8,");
            sbMenu.Append("    \"textoOpcion\": \"Unidad\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"frmUnidad.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmUnidad.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 9,");
            sbMenu.Append("    \"textoOpcion\": \"Material\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"frmProyecto_Material.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmProyecto_Material.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 11,");
            sbMenu.Append("    \"textoOpcion\": \"Administracion\",");
            sbMenu.Append("    \"idOpcionPadre\": 0,");
            sbMenu.Append("    \"pantalla\": \"#\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"#\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 12,");
            sbMenu.Append("    \"textoOpcion\": \"Personal\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmPersonal.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmPersonal.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 13,");
            sbMenu.Append("    \"textoOpcion\": \"Cargo\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmCargo.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmCargo.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 14,");
            sbMenu.Append("    \"textoOpcion\": \"Area\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmArea.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmArea.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 15,");
            sbMenu.Append("    \"textoOpcion\": \"Usuario\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmUsuarios.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmUsuarios.aspx\"");
            sbMenu.Append("  },");
          
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 17,");
            sbMenu.Append("    \"textoOpcion\": \"Opcion Menu\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmOpcion.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmOpcion.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 18,");
            sbMenu.Append("    \"textoOpcion\": \"Asignar Menu\",");
            sbMenu.Append("    \"idOpcionPadre\": 11,");
            sbMenu.Append("    \"pantalla\": \"frmUsuarioOpcion.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmUsuarioOpcion.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 19,");
            sbMenu.Append("    \"textoOpcion\": \"Fases\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"Fases.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"Fases.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 20,");
            sbMenu.Append("    \"textoOpcion\": \"Grupos\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"frmGrupo.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmGrupo.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 21,");
            sbMenu.Append("    \"textoOpcion\": \"Modulo\",");
            sbMenu.Append("    \"idOpcionPadre\": 5,");
            sbMenu.Append("    \"pantalla\": \"frmModulo.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmModulo.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 22,");
            sbMenu.Append("    \"textoOpcion\": \"Almacen\",");
            sbMenu.Append("    \"idOpcionPadre\": 0,");
            sbMenu.Append("    \"pantalla\": \"#\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"#\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 23,");
            sbMenu.Append("    \"textoOpcion\": \"Registro de Almacen\",");
            sbMenu.Append("    \"idOpcionPadre\": 22,");
            sbMenu.Append("    \"pantalla\": \"frmAlmacen.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"frmAlmacen.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 24,");
            sbMenu.Append("    \"textoOpcion\": \"Ingresos Almacen\",");
            sbMenu.Append("    \"idOpcionPadre\": 22,");
            sbMenu.Append("    \"pantalla\": \"IngresoMaterial.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"IngresoMaterial.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 25,");
            sbMenu.Append("    \"textoOpcion\": \"Traspaso de Almacen\",");
            sbMenu.Append("    \"idOpcionPadre\": 22,");
            sbMenu.Append("    \"pantalla\": \"TraspasoAlmacen.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"TraspasoAlmacen.aspx\"");
            sbMenu.Append("  },");
            sbMenu.Append("  {");
            sbMenu.Append("    \"idOpcion\": 26,");
            sbMenu.Append("    \"textoOpcion\": \"Salida de Almacen\",");
            sbMenu.Append("    \"idOpcionPadre\": 22,");
            sbMenu.Append("    \"pantalla\": \"SalidasAlmacen.aspx\",");
            sbMenu.Append("    \"imagen1\": \"grupoOver.gif\",");
            sbMenu.Append("    \"valido\": true,");
            sbMenu.Append("    \"mostrar\": false,");
            sbMenu.Append("    \"pantallaNueva\": \"SalidasAlmacen.aspx\"");
            sbMenu.Append("  }");
            sbMenu.Append("]");

            return sbMenu.ToString();

        }


    }
}