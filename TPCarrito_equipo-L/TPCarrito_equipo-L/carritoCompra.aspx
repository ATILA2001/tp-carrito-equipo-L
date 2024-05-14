<%@ Page Title="Carrito de compras" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="carritoCompra.aspx.cs" Inherits="TPCarrito_equipo_L.carritoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>CARRITO</h1>
    </figure>
    <asp:GridView runat="server" ID="dgvCarrito" CssClass="table"></asp:GridView>

    <a href="/#" class="btn btn-secondary">Volver</a>
</asp:Content>
