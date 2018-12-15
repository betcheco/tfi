<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="VerAnuncio.aspx.vb" Inherits="Index.VerAnuncio" %>
<%@ Register Src="~/UserControls/comentario.ascx" TagPrefix="userCtrl" TagName="comentario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-lg-9">

          <div class="card mt-4">
            <%--<img class="card-img-top img-fluid" src="http://placehold.it/900x400" alt="">--%>
               <asp:Image ID="img" class="card-img-top img-fluid" runat="server" Width="300px" ImageUrl='<%# Eval("img")%>'/>
            
            <div class="card-body">
              <h3 class="card-title" id="lblTitulo" runat="server"></h3>
              <h4 runat="server" id="lblPrecio"></h4>
              <p class="card-text" id="lblDescCorta" runat="server"></p>
              <asp:Button ID="btnComprar" runat="server" text="Comprar" CssClass=" card-text btn btn-primary btn-sm"/>
             
            </div>
          </div>
          <!-- /.card -->
          <div class="card card-outline-secondary my-4">
            <div class="card-header">
              Descripcion
            </div>
              <div class="card-body">
                  <p id="descLarga" runat="server"></p>
              </div>
              </div>

          <div class="card card-outline-secondary my-4">
            <div class="card-header" ">
             Comentarios
            </div>
            <div class="card-body" id="divComentarios" runat="server">
              <%--<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Omnis et enim aperiam inventore, similique necessitatibus neque non! Doloribus, modi sapiente laboriosam aperiam fugiat laborum. Sequi mollitia, necessitatibus quae sint natus.</p>
              <small class="text-muted">Posted by Anonymous on 3/1/17</small>
              <hr>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Omnis et enim aperiam inventore, similique necessitatibus neque non! Doloribus, modi sapiente laboriosam aperiam fugiat laborum. Sequi mollitia, necessitatibus quae sint natus.</p>
              <small class="text-muted">Posted by Anonymous on 3/1/17</small>
              <hr>
              <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Omnis et enim aperiam inventore, similique necessitatibus neque non! Doloribus, modi sapiente laboriosam aperiam fugiat laborum. Sequi mollitia, necessitatibus quae sint natus.</p>
              <small class="text-muted">Posted by Anonymous on 3/1/17</small>
              <hr>
              <a href="#" class="btn btn-success">Leave a Review</a>--%>
            </div>
          </div>
          <!-- /.card -->
         <a runat="server" class="btn btn-info" href="#" id="btnComentar" data-toggle="modal" data-target="#modalComentario">Comentar</a>
        </div>
        <!-- /.col-lg-9 -->

         
      <%--<asp:Button ID="btnComentar" runat="server" Text="Comentar" CssClass="btn btn-info" />--%>

     <!-- Modal Comentario-->
    <div class="modal fade" id="modalComentario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" >Escriba su comentario</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">
              <asp:TextBox ID="inputComentario" runat="server" CssClass="form-control-plaintext"></asp:TextBox>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
            <asp:Button class="btn btn-success" runat="server" Text="Enviar comentario" ID="btnEnviarComentario"/>
          </div>
        </div>
      </div>
    </div>

</asp:Content>
