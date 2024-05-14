<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>PRODUCTOS</h1>
    </figure>
    <div class="row row-cols-1 row-cols-md-3 g-4">
          
        <% foreach(dominio.Articulo articulo in ListaArticulos)
            {
        %>
            <div class="col">
                <div class="card">
                    <%--<img src="<%:articulo.Imagenes[0].Url %>" class="card-img-top" style="width: 260px; height: auto;">--%>
                    <div class="card-body">
                        <h5 class="card-title" style="color: black"> <b><%: articulo.Nombre %> </h5></b>
                        <p class="card-text" style="color: #4675b9"><%:"$" + articulo.Precio %></p>
                        <a href="detalleArticulo.aspx?id=<%: articulo.Id %>" class="btn btn-primary btn-sm" style="border-bottom-color: white">Ver detalle</a>
                    </div>
                </div>
            </div>
                <%  } %>
    </div>
</asp:Content>
