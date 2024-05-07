<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_equipo_L.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <figure class="text-center">
        <h1>PRODUCTOS</h1>
    </figure>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <%--<img src="..." class="card-img-top" alt="...">--%>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%> </h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <p class="card-text">$ <%#Eval("Precio")%></p>
                            <asp:button Text="Ver Detalle" type="button" runat="server" class="btn btn-primary" id="btnDetalle" commandArgument='<%#Eval("Id") %>' commandName="IdArticulo" OnClick="btnDetalle_Click" >
                            </asp:button>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>

