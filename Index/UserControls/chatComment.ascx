<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="chatComment.ascx.vb" Inherits="Index.chatComment" %>
<script>
    function modalShow() {
        $('#modalRespuesta').modal('show');
    }
</script>
  <div class="card-body">
      <div id="pregunta" class="w-100">
          <%--<font color="blue">Usuario dice:</font>--%>
              <p id="textComment" runat="server"></p>
      </div>
   </div>

        <div class="card-body w-75">
            <font color="blue">Admin responde:</font>
              <small class="text-muted justify-content-left" id="textRespuesta" runat="server"></small>
       <div>
    
            <asp:TextBox ID="inputRespuesta" runat="server" CssClass="form-control-plaintext" Visible="false"></asp:TextBox>
           <asp:Button class="btn btn-success" runat="server" Text="Enviar Respuesta" ID="btnEnviarRespuesta" Visible="false"/>
      <asp:Button ID="btnResponder" runat="server" Text="Responder" CssClass="btn btn-primary btn-sm" visible="false"/>
            <asp:HiddenField ID="id" runat="server" />
           </div>
              
      </div>