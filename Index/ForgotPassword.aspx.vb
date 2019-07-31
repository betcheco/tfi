Imports System.IO

Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnResetPwd_Click(sender As Object, e As EventArgs) Handles btnResetPwd.Click
        Dim oUser As New BE.Usuario
        oUser.email = inputEmail.Value
        oUser = BLL.Usuario.BuscarUsuario(oUser)
        If Not oUser Is Nothing Then
            If oUser.estado.Trim = "RESET" Then
                'error no puedo resetear el password, verificar mail para el enlace
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error!", "Por favor verifique su casilla de email para el reseteo de contraseña", Nothing)
            Else
                oUser.estado = "RESET"
                If (BLL.Usuario.BlanqueoPassword(oUser)) Then
                    'Abrir modal con link para el blanqueo 
                    Dim bitacora As New BE.Bitacora
                    bitacora.usuario = oUser.email
                    bitacora.evento = "Solicitud blanqueo de contraseña"
                    bitacora.criticidad = 3
                    BLL.Bitacora.RegistarEvento(bitacora)
                    ' linkResetPwd.Attributes.Add("href", "ResetPassword.aspx?id=" & oUser.token)
                    divMail.Visible = False
                    success.Visible = True
                    Dim msg = "<br /><br />Por favor ingresa en este link "
                    msg += "<br /><a href = 'http://localhost:49915/ResetPassword.aspx?id=" & oUser.token + "'>Click aqui.</a>"
                    ' Helpers.sendMail.send("Reestablecer contraseña", CreateBody(oUser.nombre, "Reseteo Contraseña", msg), oUser.email)
                    'Response.Redirect("Home.aspx")
                Else
                    divMail.Visible = False
                    [error].Visible = True
                    'mostrar error no se puede realizar la operacion en este momento
                End If
            End If
        Else
            divMail.Visible = False
            [error].Visible = True
            'mostrar error el usuario no existe
        End If





    End Sub
    Function CreateBody(username As String, tittle As String, message As String) As String
        Dim body As String = String.Empty

        Using reader As New StreamReader(Server.MapPath("emailTemplates/emailTemplate.html"))


            body = reader.ReadToEnd

            body = body.Replace("{UserName}", username) ' //replacing the required things  

            body = body.Replace("{Title}", tittle)

            body = body.Replace("{message}", message)


            Return body

        End Using
    End Function
End Class