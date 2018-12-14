Public Class ModalError
    Inherits System.Web.UI.UserControl

    Public Sub mostrar(titulo As String, mensaje As String, ruta As String)
        If Not ruta Is Nothing Then
            btnAccept.Attributes.Remove("data-dismiss")

            btnAccept.Attributes.Add("href", "../" & ruta)
        Else
            btnAccept.Attributes.Add("data-dismiss", "modal")
        End If
        tittle.InnerText = titulo
        body.InnerText = mensaje
        ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "openModal();", True)
    End Sub

End Class