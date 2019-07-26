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
           /**** Grid 1_0f_4 ****/
.grid_1_of_4 {
	display: block;
	float: left;
	margin: 1% 0 1% 1.6%;
	box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-webkit-box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-moz-box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-o-box-shadow: 0px 0px 3px rgb(150, 150, 150);
}
.grid_rank1
{
	display: block;
	float: left;
	margin: 1% 0 1% 1.6%;
	box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-webkit-box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-moz-box-shadow: 0px 0px 3px rgb(150, 150, 150);
	-o-box-shadow: 0px 0px 3px rgb(150, 150, 150);
}
.images_1_of_4_rank{
	width: 20.8%;
	padding: 1.5%;
	text-align: center;
	position: relative;
}

.grid_1_of_4:first-child {
	margin-left: 0;
}
.images_1_of_4 {
	width: 30%;
	padding: 1.5%;
	text-align: center;
	position: relative;
}
.images_1_of_4  img {
	max-width: 100%;
}
.images_1_of_4  h2 {
	color:#6A82A4;
	font-family: 'ambleregular';
	font-size:1.1em;
	font-weight: normal;
}
.images_1_of_4  p {
	font-size: 0.8125em;
	padding: 0.4em 0;
	color: #333;
}
.images_1_of_4  p span.price {
	font-size: 18px;
	font-family: 'ambleregular';
	color:#CC3636;
}
.price-details{
	margin-top:10px;
	border-top:1px solid #CD1F25;
}
.price-number{
	/*float: left;*/
	padding-top: 5px;
}
.price-details p span.rupees{
	font-size:1.6em;
	font-family: 'ambleregular';
	color:#383838;
}
.add-cart{
	float:right;
	display: inline-block;
}
.add-cart h4 a{
	font-size:0.9em;
	display: block;
	padding:10px 15px;
	font-family: 'ambleregular';
	background:#CD1F25;
	color: #FFF;
	text-decoration: none;
	outline: 0;
	-webkit-transition: all 0.5s ease-in-out;
	-moz-transition: all 0.5s ease-in-out;
	-o-transition: all 0.5s ease-in-out;
	transition: all 0.5s ease-in-out;
}
.add-cart h4 a:hover{
	  text-shadow: 0px 0px 1px #000;
	  background:#292929;
}
.articulo {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.3s;
  width: 25%;
}

.images_1_of_4:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.container {
  padding: 2px 16px;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row mt-4">
       <asp:Repeater ID="rpt1" runat="server">
           <%--<HeaderTemplate >
               <table class="w-100">
        <tr>
           </HeaderTemplate>--%>
           <ItemTemplate>
               <%--<td>--%>
               <div class="grid_1_of_4 images_1_of_4 mx-auto" runat="server">

                   <asp:Image ID="Image1" runat="server" style="width:200px; height:200px " ImageUrl='<%# Eval("imagen")%>' />

                   <h2>
                       <p>
                           <span class="rupees">
                               <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("titulo")%>' Font-Bold="True"></asp:Label></span>
                       </p>
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
                       <%--<div class="price-number">
                           <b>Categoria:</b>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("categoria")%>'></asp:Label>
                           
                       </div>--%>

                       <div class="price-number" runat="server">
                           <h4>
                               <asp:Button CssClass="btn btn-primary w-100" ID="btnVer" runat="server"  Text="Ver" OnCommand="btnVer_Command" CommandArgument='<%# Eval("id")%>' CommandName="ver" />
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

      <div class="row mt-2 d-flex justify-content-center">
        <a class="d-block small mt-3" href="Clasificados.aspx">Volver</a>
    </div>
</asp:Content>
