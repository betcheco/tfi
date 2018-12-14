<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ModalEstado.ascx.vb" Inherits="Index.ModalEstado" %>
<script type="text/javascript">
    function openModalEstado() {
        console.log("Entre en la funcion");
        $('#modalEstado').modal('show');
    }
</script>
 <div  class="modal fade" id="modalEstado"  role="dialog" aria-labelledby="exampleModalLabel"  >
      <div class="modal-dialog" role="document" >
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="tittle" runat="server">Cambio de estado</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body" id="body" runat="server">
              <label for="ddlEstados">Seleccione el estado:</label>
            <asp:DropDownList ID="ddlEstados" runat="server">
                <asp:ListItem>ENVIADO</asp:ListItem>
                <asp:ListItem>FINALIZADO</asp:ListItem>
                <asp:ListItem>CANCELADO</asp:ListItem>
                <asp:ListItem>RECIBIDO</asp:ListItem>
              </asp:DropDownList>
          </div>
            
          <div class="modal-footer">
             <asp:Button class="btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" formnovalidate  data-dismiss="modalEstado"/>
             <asp:Button class="btn btn-primary" ID="btnCancelar" runat="server" Text="Cancelar" formnovalidate data-dismiss="modalEstado" />
          </div>
        </div>
      </div>
    </div>