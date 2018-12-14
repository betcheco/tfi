Public Class ModalEstado
    Inherits System.Web.UI.UserControl

    Public Event OnAccept As EventHandler(Of String)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.Visible = False
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Visible = False
        RaiseEvent OnAccept(sender, ddlEstados.SelectedValue)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ' Me.Visible = False

    End Sub

    Public Sub Show(estadoActual As String)
        Select Case estadoActual
            Case "RECIBIDO"
                ddlEstados.Items.Remove("ENVIADO")
        End Select

        '<asp:ListItem> ENVIADO</asp:ListItem>
        '        <asp:ListItem>FINALIZADO</asp:ListItem>
        '        <asp:ListItem> CANCELADO</asp:ListItem>
        '        <asp:ListItem>RECIBIDO</asp:ListItem>
        ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "openModalEstado();", True)
        'Me.Visible = True

    End Sub
End Class