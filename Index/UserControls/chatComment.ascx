<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="chatComment.ascx.vb" Inherits="Index.chatComment" %>
<script>
    function modalShow() {
        $('#modalRespuesta').modal('show');
    }
</script>

<style>
    
/* Chat containers */
.container {
  border: 2px solid #dedede;
  background-color: #f1f1f1;
  border-radius: 5px;
  padding: 10px;
  margin: 10px 0;
}

/* Darker chat container */
.darker {
  border-color: #ccc;
  background-color: #ddd;
}

/* Clear floats */
.container::after {
  content: "";
  clear: both;
  display: table;
}

/* Style images */
.container img {
  float: left;
  max-width: 60px;
  width: 100%;
  margin-right: 20px;
  border-radius: 50%;
}

/* Style the right image */
.container p.right {
  float: right;
  margin-left: 20px;
  margin-right:0;
  color:blue;
}

/* Style time text */
.time-right {
  float: right;
  color: #aaa;
}

/* Style time text */
.time-left {
  float: left;
  color: #999;
}
</style>


 <%-- <div class="card-body">
      <div id="pregunta" class="w-100">
          <%--<font color="blue">Usuario dice:</font>--%>
      <%--        <p id="textComment" runat="server"></p>
      </div>
   </div>--%>

<div id="pregunta" class="container">
    <p id="textComment" runat="server"></p>
    <span class="time-right" id="fpregunta" runat="server"></span>
  
</div>


<div id="respuesta" runat="server" class="container darker">
  <p class="right" >Administrador</p>
  <p  id="textRespuesta" runat="server"></p>
  <span class="time-left" id="frespuesta" runat="server"></span>
  
    <asp:TextBox ID="inputRespuesta" runat="server" CssClass="form-control-plaintext" Visible="false"></asp:TextBox>
           <asp:Button class="btn btn-success" runat="server" Text="Enviar Respuesta" ID="btnEnviarRespuesta" Visible="false"/>
      <asp:Button ID="btnResponder" runat="server" Text="Responder" CssClass="btn btn-primary btn-sm right" visible="false"/>
            <asp:HiddenField ID="id" runat="server" />
</div>
       
    
            
          