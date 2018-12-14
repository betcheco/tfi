<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Comparar.aspx.vb" Inherits="Index.Comparar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .item-container {
        width: 300px;
        height: 500px;
        display: flex;
        /*justify-content: space-around;*/
        flex-direction: column;
        background-color: white;
        margin: 0 20px 20px 0px;
        /*border-radius: 10px;*/
        box-shadow: black 1px 1px;
        padding: 20px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
       <asp:Repeater ID="rpt1" runat="server">
           <HeaderTemplate >
               <table class="w-100">
        <tr>
           </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <div class="item-container" runat="server">

                        <asp:Image ID="Image1" runat="server" Style="width: 150px; height: 150px" ImageUrl='<%# Eval("imagen")%>' />

                        <h2>
                            <p><span class="rupees">
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("titulo")%>' Font-Bold="True"></asp:Label></span></p>
                        </h2>
                        <div class="price-details">
                            <div class="price-number">
                                <b>Precio:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp $<asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("precio")%>'></asp:Label>
                            </div>

                            <br />
                            <div class="price-number">
                                <b>Descripcion corta:</b>
                                <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("desc_corta")%>'></asp:Label>
                                <%-- <div class="item-body"><%# Eval("descripcion") %></div>--%>
                            </div>
                            <div class="price-number">
                                <b>Descripcion larga:</b>
                                <asp:Label ID="lblDescLarga" runat="server" Text='<%# Eval("desc_larga")%>'></asp:Label>
                                <%-- <div class="item-body"><%# Eval("descripcion") %></div>--%>
                            </div>
                             <div class="price-number">
                                <b>Categoria:</b>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("categoria")%>'></asp:Label>
                                <%-- <div class="item-body"><%# Eval("descripcion") %></div>--%>
                            </div>

                            <div class="add-cart" runat="server">
                                <h4>
                                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnVer" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Ver"  OnCommand="btnVer_Command" CommandArgument='<%# Eval("id")%>' CommandName="ver"/>
                                    <%--<a href="#" class="button">Añadir Compra</a>--%></h4>
                            </div>
                            <div class="clear"></div>
                        </div>

                    </div>
                    </td>
            </ItemTemplate>
           <FooterTemplate>
        </tr></table>
    </FooterTemplate>

        </asp:Repeater>
         </div>
</asp:Content>
