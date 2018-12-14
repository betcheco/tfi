Public Class MiPerfil
    Inherits System.Web.UI.Page
    Dim modUser As BE.Usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then


            If Not Session("CurrentUser") Is Nothing Then

                modUser = New BE.Usuario

                modUser = Session("CurrentUser")
                inputEmail.Value = modUser.email
                inputEmail.Disabled = True
                inputfirstName.Value = modUser.nombre
                inputlastName.Value = modUser.apellido
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If

            End If

    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        Try
            ' modUser.email = inputEmail.Value
            modUser = New BE.Usuario

            modUser = Session("CurrentUser")
            modUser.apellido = inputlastName.Value
            modUser.nombre = inputfirstName.Value

            If BLL.Usuario.ModificarUsuario(modUser) Then
                'Usuario modificado con exito
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "Su perfil fue modificado exitosamente", "Home.aspx")
                'Response.Redirect("Usuarios.aspx")
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! Lo sentimos sucedio un error modificando el usuario", Nothing)
            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error!", ex.Message, Nothing)
        End Try
    End Sub

    Protected Sub btnCambioPass_Click(sender As Object, e As EventArgs) Handles btnCambioPass.Click
        Response.Redirect("RegisterConfirm.aspx?id=" & Session("currentUser").token)
    End Sub
End Class