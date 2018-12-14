Public Class modalDialogRating
    Inherits System.Web.UI.UserControl

    Public Event OnAccept As EventHandler(Of Integer)

    Public Sub Show()

        Me.ratingModal.CurrentRating = 0
        Me.Visible = True
        ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "openModalRating();", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Visible = False
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Visible = False
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Visible = False
        RaiseEvent OnAccept(sender, ratingModal.CurrentRating)
    End Sub

End Class