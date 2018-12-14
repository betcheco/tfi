Public Class ResetPassword
    Inherits System.Web.UI.Page
    Dim user As New BE.Usuario
    Dim bitacora As New BE.Bitacora
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'buscar usuario asociado y verificar que pueda cambiar el password
        user.token = Request.QueryString("id")
        user = BLL.Usuario.BuscarUsuario(user)

        If Not (Trim(user.estado) = "RESET") Then
            'Muestro error el usuario no pidio reset password
            bitacora.usuario = user.email
            bitacora.evento = "Error, el usuario no solicito un blanqueo de password"
            bitacora.criticidad = 5
            divError.Visible = True
        Else
            container.Visible = True
        End If
    End Sub

    Protected Sub btnResetPwd_Click(sender As Object, e As EventArgs) Handles btnResetPwd.Click
        If (inputpassword.Value = inputConfirmPassword.Value) Then
            user.contraseña = Helpers.Hasher.Hash(inputpassword.Value)
            user.estado = "CONFIRMADO"
            user.intentos = 0
            BLL.Usuario.ModificarUsuario(user)
            bitacora.usuario = user.email
            bitacora.evento = "Blanqueo de password exitoso"
            bitacora.criticidad = 4
            container.Visible = False
            divSuccess.Visible = True

        Else
            'Mostrar error de que las password no coinciden
            errorPwd.Visible = True


        End If
    End Sub
End Class