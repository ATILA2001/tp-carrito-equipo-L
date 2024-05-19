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
    public partial class carritoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> carrito;
            carrito = Session["carrito"] != null ? (List<Articulo>)Session["carrito"] : new List<Articulo>();
            Session.Add( "carrito", carrito);
            int id = -1;
            if (Request.QueryString["id"]!=null)
            {
                id = int.Parse(Request.QueryString["id"]);
                List<Articulo> listaOriginal = (List<Articulo>)Session["listaArticulos"];
                Articulo seleccionado = listaOriginal.Find(x => x.Id == id);
                if (!carrito.Exists(a => a.Id == seleccionado.Id))
                {
                    carrito.Add(seleccionado);
                }else
                {
                    //muestra que el articulo ya se agrego
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El artículo ya está en el carrito. Realice una nueva compra o aguarde una actualizacion de sistema. Disculpe las molestias');", true);


                }
            }
            
            dgvCarrito.DataSource = carrito;
            dgvCarrito.DataBind();
            decimal total = 0;
            foreach (Articulo item in carrito)
            {
                total += item.Precio;
            }

            // Asignar la suma al Text de la etiqueta
            lblTotal.Text = "Total: $" + total.ToString();
        }
    }
}