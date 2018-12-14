<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ModalError.ascx.vb" Inherits="Index.ModalError" %>
<script type="text/javascript">
    function openModal() {
        console.log("Entre en la funcion");
        $('#modal').modal('show');
    }
</script>

 <div class="modal fade" id="modal"  role="dialog" aria-labelledby="exampleModalLabel"  >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="tittle" runat="server"></h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body" id="body" runat="server"></div>
          <div class="modal-footer">
            <a class="btn btn-secondary" runat="server"  id="btnAccept" >Aceptar</a>
           <%-- <asp:Button class="btn btn-primary" runat="server" Text="Ok" ID="btnOK"/>--%>
          </div>
        </div>
      </div>
    </div>