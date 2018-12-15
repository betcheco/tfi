<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Noticia.aspx.vb" Inherits="Index.Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="dvNombreProducto" class="row col-12 justify-content-center" runat="server" >
                <asp:Label ID="lblNombre" runat="server" CssClass="h3 text-justify"  Text='<%# Eval("titulo")%>'></asp:Label>
            </div>
    <div class="row col-12 justify-content-center">
        <asp:Image ID="img" runat="server"  ImageUrl='<%# Eval("imagen")%>'/>
        
        </div>
        <div>

           
           
            <div id="dvDescripcion" class="row col-12 justify-content-center"  runat="server" style="margin-top: 2vh; margin-bottom: 2vh;">
                <asp:label ID="lblDetails" runat="server" Text='<%# Eval("desc_larga")%>'></asp:label>
               <%--  <asp:Label ID="lblDetails" runat="server"  Text='<%# Eval("descripcion")%>'></asp:Label>
          --%>  </div>

          
        </div>
    <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Noticias.aspx">Volver a noticias</a>
            </div>
    <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
			
			
</asp:Content>
