<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>PRODUCTOS</h1>
    </figure>
    <div class="row row-cols-1 row-cols-md-3 g-4">
          
        <%  negocio.ImagenNegocio negocio = new negocio.ImagenNegocio();
            List<string> lista = new List<string>();
            foreach(dominio.Articulo articulo in ListaArticulos)
            {
                lista = negocio.listarImgPorArticulo(articulo);
        %>
            <div class="col">
                <div class="card" style="width: 250px; height: 380px;">
                    <%--<img src="<%:articulo.Imagenes[0].Url %>" class="card-img-top" style="width: 260px; height: auto;">--%>
                  <%if(!(lista.Count == 0))
                    {
                        %><img src="<%:lista[0] %>" class="img-thumbnail" style="width: 250px; height: auto; display: block; float: right; margin-right: 10px;"><%
                    }                                                                                                     %>
                    <div class="card-body">
                    <h5 class="card-title" style="color: black; text-align: center"> <b><%: articulo.Nombre %> </h5></b>
                    <p class="card-text" style="color: #4675b9; text-align: center"><%:"$" + articulo.Precio %></p>
                    <a href="detalleArticulo.aspx?id=<%: articulo.Id %>" style="display: flex; justify-content: center; align-items: center;" class="btn btn-primary btn-sm">Ver detalle</a>
                    </div>
                </div>
            </div>
                <%  } %>
    </div>
</asp:Content>
