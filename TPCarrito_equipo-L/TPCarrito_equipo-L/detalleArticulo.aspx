<%@ Page Title="Detalle Articulo" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="TPCarrito_equipo_L.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>

        <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label></h1>
    <%  negocio.ImagenNegocio negocio = new negocio.ImagenNegocio();
        List<string> lista = new List<string>();
        foreach (dominio.Articulo articulo in ListaArticulos)
        {
            if (lblId.Text == articulo.Id.ToString())
            {
                lista = negocio.listarImgPorArticulo(articulo);

    %>



    <div id="carouselExample" class="carousel slide">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="<%:lista[0] %>"  class="rounded mx-auto d-block" style="width: 260px; height: auto; display: block;  margin-left: 200px;"  alt="..." onerror="https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg">

            </div>
            <%
                int c = lista.Count();
                for (int i = 1; i < c; i++)
                {
            %>

            <div class="carousel-item">
                <img src="<%:lista[i] %>"  class="rounded mx-auto d-block" style="width: 260px; height: auto; display: block;  margin-left:200px;" alt="..." onerror="https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg">
            </div>



            <% }%>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev" color="black">
            <span class="badge text-bg-secondary p-3" aria-hidden="true">< </span>
            <span class="visually-hidden">Anterior</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next" color="black">
            <span class="badge text-bg-secondary p-3" aria-hidden="true">> </span>
            <span class="visually-hidden">Siguiente</span>
        </button>
    </div>

    <hr />

    <%--	<img src="<%:lista[0] %>" class="img-thumbnail" style="width: 260px; height: auto; display: block; float: right; margin-right: 10px;">--%>
    <%--<img src="<%:articulo.Imagenes[0].Url %>" class="img-thumbnail" style="width: 260px; height: auto; display: block; float: right; margin-right: 10px;">--%>
    <div>
        <h5 class="card-title">Nombre de artículo</h5>
        <p class="card-text"><%: articulo.Nombre %></p>
        <h6 class="card-title">Descripción</h6>
        <p class="card-text"><%: articulo.Descripcion %></p>
        <h6 class="card-title">Marca</h6>
        <p class="card-text"><%: articulo.Marca %></p>
        <h6 class="card-title">Precio</h6>
        <h3 class="card-title"><%: "$" + articulo.Precio %></h3>
        <br />
    </div>
    <div class="d-grid gap-2 d-md-block">
        <a href="carritoCompra.aspx?id=<%: articulo.Id %>" class="btn btn-primary" style="border-bottom-color: white">
            <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
                <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5M3.102 4l1.313 7h8.17l1.313-7zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4m7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4m-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2m7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2" />
            </svg>Agregar al carrito</a>
    </div>
    <br />



    <%  }%>





    <% }%>



    <a href="/#" class="btn btn-secondary">Volver</a>
</asp:Content>



