<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="comentario.ascx.vb" Inherits="Index.comentario" %>

<script>
    function modalShow() {
        $('#modalRespuesta').modal('show');
    }
</script>
  <div class="card-body">
              <p id="textComment" runat="server">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Omnis et enim aperiam inventore, similique necessitatibus neque non! Doloribus, modi sapiente laboriosam aperiam fugiat laborum. Sequi mollitia, necessitatibus quae sint natus.</p>
              <small class="text-muted" id="textRespuesta" runat="server">Posted by Anonymous on 3/1/17</small>
       <div class="card-footer">
     <%-- <a runat="server" class="btn btn-primary btn-sm" href="#" id="bResponder" data-toggle="modal" data-target="#modalRespuesta" onclick="modalShow()">Responder</a>--%>
            <asp:TextBox ID="inputRespuesta" runat="server" CssClass="form-control-plaintext" Visible="false"></asp:TextBox>
           <asp:Button class="btn btn-success" runat="server" Text="Enviar Respuesta" ID="btnEnviarRespuesta" Visible="false"/>
      <asp:Button ID="btnResponder" runat="server" Text="Responder" CssClass="btn btn-primary btn-sm" visible="false"/> <%-- data-toggle="modal" data-target="#modalRespuesta"--%>
      <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" Visible="false" />
            <asp:HiddenField ID="id" runat="server" />
           </div>
              <hr>
      </div>

<%-- <!-- Modal Respuesta-->
    <div class="modal fade" id="modalRespuesta" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" >Escriba su respuesta</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">
              <asp:TextBox ID="inputRespuesta" runat="server" CssClass="form-control-plaintext"></asp:TextBox>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
            <asp:Button class="btn btn-success" runat="server" Text="Enviar Respuesta" ID="btnEnviarRespuesta"/>
               <asp:HiddenField ID="idModal" runat="server" />
          </div>
        </div>
      </div>
    </div>--%>