<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Noticias.aspx.vb" Inherits="Index.Noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .article {
    border-bottom: 1px solid #eee;
    margin-top: 3.5em;
    padding-bottom: 3em;
}
        .article-left {
    width: 27%;
   float: left;
    margin-right: 3%;
}
        .article-right {
    float: right;
    width: 60%;
}
    </style>
  
      <asp:Repeater ID="rpt1" runat="server">

            <ItemTemplate>
              <%--  <div class="row">
                    <div class="col-md-5">
                    
                            <asp:Image ID="Image1" runat="server" class="img-fluid d-block mb-4 img-thumbnail"  ImageUrl='<%# Eval("imagen")%>' />
                         </div>
                    <div class="col-md-7">
                        <h2 class="text-primary pt-3">
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("titulo")%>'></asp:Label>
                            <asp:Label ID="hdlblID" runat="server" Visible="false" Text='<%# Eval("id")%>'></asp:Label>
                        </h2>
                        <p class="">
                            <asp:Label ID="lbldescripcion" runat="server" Text='<%#Eval("desc_corta")%>'></asp:Label>
                        </p>
                        <%----%>

<%--                        <asp:Button CssClass="btn btn-outline-info" ID="btnVer" runat="server" Height="25px" Style="font-size: 12px; text-align: center;" Text="Saber Mas" OnCommand="ValidarCommand" CommandName="ShowNoticia" CommandArgument='<%# Eval("id")%>' />

                    </div>
                                <div class="clear"></div>
                            

                        
                        </div>--%>
                 
                   <div class="article">
						<%--<div class="article-left">--%>
							<a><img class="article-left" height="250px" src='<%# Eval("imagen")%>'></a>
						<%--</div>--%>
						<div class="article-right">
							<div class="article-title">
								<asp:label runat="server" DataFormatString="{0:dd/MM/yyyy}"><%#String.Format("{0:dd/MM/yyyy}", Eval("fecha_desde"))%></asp:label>
                                </div>
                                <div class="article-title">
								<h5 class="title" href="single.html"> <%# Eval("titulo")%></h5>
							</div>
							<div class="article-text">
								<p>'<%#Eval("desc_corta")%>'.</p>
								<a ><img src="images/more.png" alt=""></a>
								<div class="clearfix"></div>
                                <asp:Label ID="hdlblID" runat="server" Visible="false" Text='<%# Eval("id")%>'></asp:Label>
                                <asp:Button CssClass="btn btn-outline-info" ID="btnVer" runat="server" Style="font-size: 12px; text-align: center;" Text="Saber Mas" OnCommand="ValidarCommand" CommandName="ShowNoticia" CommandArgument='<%# Eval("id")%>' />
							</div>
						</div>
						<div class="clearfix"></div>
					</div>
                

            </ItemTemplate>

        </asp:Repeater>
    
    <div id="divSubscribir">
    <h6>Subscribite a nuestro Newsletter</h6>
    <div class="row">
        
        <div class="col-6">
            <label for="txtEmail">Ingrese su email:</label>
            <asp:TextBox runat="server" ID="txtEmail" class="form-control" TextMode="Email"></asp:TextBox>
        </div>
         <div class="col-6">
            <asp:CheckBoxList ID="chkListCategorias" runat="server" RepeatColumns="2"></asp:CheckBoxList>
        </div>
        </div>

    <div class="row justify-content-center">
        <div >
            <asp:button ID="btnSubscribir" runat="server" CssClass="btn btn-primary" Text="Subscribirse" />
        </div>
    </div>
        </div>
      <div class="row mt-2 d-flex justify-content-center">
        <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
    </div>

</asp:Content>
