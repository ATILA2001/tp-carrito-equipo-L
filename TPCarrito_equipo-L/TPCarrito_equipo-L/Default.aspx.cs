using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;


namespace TPCarrito_equipo_L
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaArticulos"] != null)
            {
                ListaArticulos = (List<Articulo>)Session["listaArticulos"];
            }
            else
            {

                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listar();
                Session.Add("listaArticulos", ListaArticulos);
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;

        }
    }
}