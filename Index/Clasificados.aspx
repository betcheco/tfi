<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Clasificados.aspx.vb" Inherits="Index.Clasificados" %>
<%@ MasterType virtualpath="~/masterPrincipal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
	width: 20.8%;
	padding: 1.5%;
	text-align: center;
	position: relative;
}

.images_2_of_4 {
	width: 40%;
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
	float: left;
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

.grid_1_of_4:hover {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.container {
  padding: 2px 16px;
}

    </style>
       <script>
         function checkBox(Form){ 
            var total = 0; 
            var boxes = form.querySelectorAll('input[type=checkbox]:checked').length;
            if (boxes < 1 || boxes > 5)
                return true;
            else { 
                alert('Seleccionar al menos 2 checkbox'); 
                return false;
            } 
         }
 
    </script>
    <main role="main">
     <!-- Page Content -->
    <div class="container-fluid">
       
      <div class="row">

          <div class="card-header w-100">
                          
                  <div class="form-row">
                      <div id="divBusquedaAvanzada" class="d-inline-flex mx-auto" runat="server">

                          <asp:Label runat="server" for="lblCategoria" Font-Bold="True">Categoria:</asp:Label>
                          <asp:DropDownList ID="ddlCategoria" runat="server" class="form-control mx-2" DataTextField="nombre" DataValueField="id">
                          </asp:DropDownList>
                      </div>

                      <div class="d-inline-flex mx-auto">
                          <asp:Label runat="server" for="dllTipoServicio" Font-Bold="True" class="mx-2">Precio:</asp:Label>
                          <div style="width: 100%; display: flex; justify-content: flex-start">

                              <asp:TextBox ID="txtPrecioDesde" runat="server" class="form-control mx-2" TextMode="Number" Height="35px" Width="68px"></asp:TextBox>
                              <span style="margin-left: 1vh; margin-right: 1vh;">-</span>

                              <asp:TextBox ID="txtPrecioHasta" runat="server" class="form-control mx-2" TextMode="Number" Height="35px" Width="68px"></asp:TextBox>
                          </div>
                      </div>

                      <div class="d-inline-flex mx-auto">
                          <asp:Button class="btn-sm btn-outline-primary mx-2" ID="btnFiltrar" runat="server" Text="Aplicar" formnovalidate />

                          <br />
                          <asp:Button class="btn-sm btn-outline-primary mx-2" ID="btnComparar" runat="server" Text="Comparar" Visible="true" formnovalidate />
                        </div>
                  </div>
              
          </div>

          <hr />

          <div class="row mt-4 w-100">
                <asp:Repeater ID="rpt1" runat="server">
                    <ItemTemplate>
                       <div  class="grid_1_of_4 images_1_of_4 mx-auto" runat="server" >
                           <asp:Image ID="Image1" runat="server" style="width:200px; height:200px " ImageUrl='<%# Eval("imagen")%>' />
                           <h2>
                               <p><span class="rupees">
                                   <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("titulo")%>'></asp:Label></span></p>
                           </h2>
                           <div class="price-details">
                               <div class="price-number">
                                   <p><span class="rupees">$<asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("precio")%>'></asp:Label></span></p>
                               </div>
                               <div class="add-cart" runat="server">
                                   <input id="chkCompare" name="chkCompare" runat="server" type="checkbox" />
                                   <%--<asp:button ID="chkCompare" runat="server" OnCommand="ValidarCommand"  CommandName="CheckProduct"  CommandArgument='<%# Eval("id") %>'/>--%>
                                   <label for="chkCompare">Comparar</label>
                                   <asp:Label ID="idAnuncio" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Label>
                                   <h4>
                                       <asp:Button CssClass="btn btn-primary btn-sm" ID="btnVer" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Ver" OnCommand="ValidarCommand" CommandName="ShowProduct" CommandArgument='<%# Eval("id")%>' />

                                       <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddCart" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Comprar" OnCommand="ValidarCommand" CommandName="AddCart" CommandArgument='<%# Eval("id") %>' />
                                       <%--<a href="#" class="button">Añadir Compra</a>--%></h4>
                               </div>
                               <div class="clear"></div>
                           </div>

                       </div>

                   </ItemTemplate> 

        </asp:Repeater>

                <asp:Repeater ID="rpt2" runat="server">
                    <ItemTemplate>
                       <div  class="grid_1_of_4 images_2_of_4 mx-auto" runat="server" >
                           <asp:Image ID="Image1" runat="server" style="width:200px; height:200px " ImageUrl='<%# Eval("imagen")%>' />
                           <h2>
                               <p><span class="rupees">
                                   <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("titulo")%>'></asp:Label></span></p>
                           </h2>
                           <div class="price-details">
                               <div class="price-number">
                                   <p><span class="rupees">$<asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("precio")%>'></asp:Label></span></p>
                               </div>
                               <div class="add-cart" runat="server">
                                   <input id="chkCompare" name="chkCompare" runat="server" type="checkbox" />
                                   <%--<asp:button ID="chkCompare" runat="server" OnCommand="ValidarCommand"  CommandName="CheckProduct"  CommandArgument='<%# Eval("id") %>'/>--%>
                                   <label for="chkCompare">Comparar</label>
                                   <asp:Label ID="idAnuncio" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Label>
                                   <h4>
                                       <asp:Button CssClass="btn btn-primary btn-sm" ID="btnVer" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Ver" OnCommand="ValidarCommand" CommandName="ShowProduct" CommandArgument='<%# Eval("id")%>' />

                                       <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddCart" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Comprar" OnCommand="ValidarCommand" CommandName="AddCart" CommandArgument='<%# Eval("id") %>' />
                                       <%--<a href="#" class="button">Añadir Compra</a>--%></h4>
                               </div>
                               <div class="clear"></div>
                           </div>

                       </div>

                   </ItemTemplate> 

        </asp:Repeater>
          </div>


          <!-- /.row -->

        </div>
        <!-- /.col-lg-9 -->

      </div>
      <!-- /.row -->

  
    <!-- /.container -->
        </main>


        
</asp:Content>
