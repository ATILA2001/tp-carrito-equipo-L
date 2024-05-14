<%@ Page Title="Detalle Articulo" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="TPCarrito_equipo_L.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label></h1>
    <%  bool primerRegistro=false;
        foreach (dominio.Articulo articulo in ListaArticulos)
        {
            if (lblId.Text == articulo.Id.ToString() && !primerRegistro)
            {
    %>
                <img src="<%:articulo.Imagenes[0].Url %>" class="img-thumbnail" style="width: 260px; height: auto; display: block; float: right; margin-right: 10px;">
                <div>
                <h5 class="card-title">Nombre de artículo</h5>
                <p class="card-text"><%: articulo.Nombre %></p>
                <h6 class="card-title">Descripción</h6>
                <p class="card-text"><%: articulo.Descripcion %></p>
                <h6 class="card-title">Marca</h6>
                <p class="card-text"><%: articulo.Marca %></p>
                <h6 class="card-title">Precio</h6>
                <h3 class="card-title"><%: "$" + articulo.Precio %></h3> <br />
                </div>
                <div class="d-grid gap-2 d-md-block">
                <a href="carritoCompra.aspx?id=<%: articulo.Id %>" class="btn btn-primary" style="border-bottom-color: white">Agregar al carrito</a>
                </div><br />     

                <% primerRegistro = true; %>


        <%  }  %>



    <%
        }
    %>
     <a href="/#" class="btn btn-secondary">Volver</a>
</asp:Content>
