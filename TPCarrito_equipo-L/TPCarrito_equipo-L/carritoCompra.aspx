<%@ Page Title="Carrito de compras" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="carritoCompra.aspx.cs" Inherits="TPCarrito_equipo_L.carritoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>CARRITO</h1>
    </figure>
    <asp:GridView runat="server" ID="dgvCarrito" class="table table-striped" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvCarrito_SelectedIndexChanged">
         <Columns>
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
             <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
             <asp:BoundField HeaderText="Precio" DataField="Precio" />
             <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" ControlStyle-CssClass="btn btn-danger"/>
        </Columns>   
    </asp:GridView>   
    <asp:Label ID="lblPrecioTotal" runat="server" CssClass="form-control" Text=""></asp:Label>

    <br />
    <a href="/#" class="btn btn-secondary">Volver</a>
    <a href="#" class="btn btn-primary" style="float: right;">Finalizar compra</a>
    
     </asp:Content>
