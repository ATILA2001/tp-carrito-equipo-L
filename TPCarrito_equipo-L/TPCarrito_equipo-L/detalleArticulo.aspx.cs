using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPCarrito_equipo_L
{
    public partial class detalleArticulo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            string id = Request.QueryString["id"];
            lblId.Text = id;


        }
    }
}