<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="PublicarAnuncio.aspx.vb" Inherits="Index.PublicarAnuncio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="card card-register mx-auto">
          
        <div class="card-header" runat="server" id="titulo">Publicar Anuncio</div>
        <div class="card-body">
          
            <div class="form-group">
              
               <div class="form-label-group">
                   <div class ="form-row">
                    <input runat="server" type="text" id="inputTitulo" class="form-control" placeholder="Titulo" required="required" autofocus="autofocus"/>
                    <label for="inputTitulo">Titulo</label>
                  </div>
                   </div>
                <div class="form-label-group">
                    <div class ="form-row">
                    <input runat="server" type="text" id="inputDescCorta" class="form-control" placeholder="Descripcion corta" required="required" />
                    <label for="inputDescCorta">Descripcion corta</label>
                        </div>
                </div>
              
            </div>
            <div class="form-group">
              <div class="form-label-group">
                  <div class ="form-row">
                <input runat="server" type="text" id="inputDescLarga" class="form-control" placeholder="Descripcion larga" required="required"/>
                <label for="inputDescLarga">Descripcion larga</label>
                      </div>
              </div>
            </div>
             <div class="form-group">
              <div class="form-row">
                 <div class="col-md-6">
               <div class="form-label-group">
                    <input runat="server" type="number" id="inputPrecio" class="form-control" placeholder="Precio" required="required" />
                    <label for="inputPrecio">Precio</label>
                  </div>
                     </div>
                  <div class="col-md-6">
                      <label for="ddCategoria" class="d-flex">Categoria:</label>
                      <div class="form-label-group">
                          <%--<input runat="server" type="text" id="Text2" class="form-control" placeholder="Descripcion corta" required="required" />
                    <label for="inputDescCorta">Descripcion corta</label>--%>
                          
                          <asp:DropDownList ID="ddCategoria" runat="server" Class="d-flex  form-control btn-primary btn-group-toggle">
                              
                          </asp:DropDownList>
                      </div>
                  </div>
              </div>
            </div>
            <div class="form-group">
                 <p>Seleccione la imagen del anuncio:
                 </p>
        <asp:FileUpload ID="imgUpload" class="btn btn-primary form-control-file" runat="server" />
                <asp:Image ID="img" runat="server" />



        
                              
                    
                     
                     

            </div>
             <asp:button ID="btnCrear" runat="server" class="btn btn-primary btn-block" Text="Guardar"/>
            
                   
          <div class="text-center">
            <a class="d-block small mt-3" href="MisPublicaciones.aspx">Volver</a>
            </div>
            </div>
          </div>
</asp:Content>
