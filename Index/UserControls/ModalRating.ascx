<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ModalRating.ascx.vb" Inherits="Index.modalDialogRating" %>
<script type="text/javascript">
    function openModalRating() {
        console.log("Entre en la funcion");
        $('#modalRating').modal('show');
    }
</script>
 <ContentTemplate>
<%--        <div class="modal-dialog-bg">
            <div class="modal-dialog-content">
                <div class="modal-dialog-content-head">
                    <asp:Label ID="lblTitle" runat="server" Text="title"></asp:Label>
                </div>
                
                <div class="modal-dialog-content-body">
                    <ajaxToolkit:Rating 
                        ID="ratingModal" 
                        runat="server"
                        StarCssClass="Star" 
                        WaitingStarCssClass="Big-WaitingStar" 
                        EmptyStarCssClass="Big-Star"
                        FilledStarCssClass="Big-FilledStar"
                        ReadOnly ="false"
                        CurrentRating = "0"
                    />
                </div>

                <div class="modal-dialog-content-buttons">
                    <asp:Button class="btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" formnovalidate />
                    <asp:Button class="btn btn-primary" ID="btnCancelar" runat="server" Text="Cancelar" formnovalidate />
                </div>
            </div>
        </div>--%>
      <div class="modal fade" id="modalRating"  role="dialog" aria-labelledby="exampleModalLabel"  >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="tittle" runat="server">Ingrese su calificación</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
                
          </div>
          <div class="modal-body" id="body" runat="server">
              <ajaxToolkit:Rating 
                        ID="ratingModal" 
                        runat="server"
                        StarCssClass="Star" 
                        WaitingStarCssClass="Big-WaitingStar" 
                        EmptyStarCssClass="Big-Star"
                        FilledStarCssClass="Big-FilledStar"
                        ReadOnly ="false"
                        CurrentRating = "0"
                    />
          </div>
          <div class="modal-footer">
             <asp:Button class="btn btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" formnovalidate />
                    <asp:Button class="btn btn-primary" ID="btnCancelar" runat="server" Text="Cancelar" formnovalidate />
          </div>
        </div>
      </div>
    </div>
    </ContentTemplate>
