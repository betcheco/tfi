<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="NewNoticia.aspx.vb" Inherits="Index.NewNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="card card-register mx-auto">
          
        <div class="card-header" runat="server" id="titulo">Nueva noticia</div>
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
                <input runat="server" type="text" id="inputDescLarga" class="form-control" placeholder="Descripcion larga" required="required" aria-multiline/>
                <label for="inputDescLarga">Descripcion larga</label>
                      </div>
              </div>
            </div>
             <div class="form-group">
              <div class="form-row">
                 <div class="col-md-6">
               <div class="form-label-group">
                    <asp:textbox runat="server" type="text" id="Text1" class="form-control"  required="required" autofocus="autofocus" TextMode="Date" />
                    <label for="Text1">Fecha Desde</label>
                  </div>
                     </div>
                  <div class="col-md-6">
                        <div class="form-label-group">
                    <asp:textbox runat="server"  id="fhasta" class="form-control"  required="required" TextMode="Date"></asp:textbox>
                    <label for="fhasta">Fecha Hasta</label>
                  </div>
                  </div>
              </div>
            </div>
            <div class="form-group">
                <div class="form-row">
                    <label for="ddCategoria" class="d-flex">Categoria:</label>
                      <div class="form-label-group">
                          <%--<input runat="server" type="text" id="Text2" class="form-control" placeholder="Descripcion corta" required="required" />
                    <label for="inputDescCorta">Descripcion corta</label>--%>
                          
                          <asp:DropDownList ID="ddCategoria" runat="server" Class="d-flex  form-control btn-primary btn-group-toggle">
                              
                          </asp:DropDownList>
                      </div>
                </div>
            </div>
            <div class="form-group">
                 <p>Seleccione la imagen para la noticia:
                 </p>
        <asp:FileUpload ID="imgUpload" class="btn btn-primary form-control-file" runat="server" />
                <asp:Image ID="img" height="250px" width="50%" runat="server" />

            </div>
             <asp:button ID="btnCrear" runat="server" class="btn btn-primary btn-block" Text="Guardar"/>
            
                   
          <div class="text-center">
            <a class="d-block small mt-3" href="ABMNoticias.aspx">Volver</a>
            </div>
            </div>
          </div>
</asp:Content>
