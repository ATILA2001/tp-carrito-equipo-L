<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>PRODUCTOS</h1>
    </figure>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%--<asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%> </h5>
                            <%--<p class="card-text"><%#Eval("Descripcion")%></p>
                            <p class="card-text">$ <%#Eval("Precio")%></p>
                            <asp:Button Text="Ver Detalle" type="button" runat="server" class="btn btn-primary" ID="btnDetalle" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnDetalle_Click"></asp:Button>
                            <asp:Button Text="Agregar al carrito" type="button" runat="server" class="btn btn-primary" ID="btnAgregarCarrito" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnAgregarCarrito_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>
        <% 
            foreach(dominio.Articulo articulo in ListaArticulos)
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
