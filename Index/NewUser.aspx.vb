Imports System.IO

Public Class NewUser
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora
    Dim modUser As BE.Usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.Controls.Add(Me.LoadControl("usrCtrlTable.ascx"))
        'modalMsg.mostrar("prueba", "Esto es una prueba")


        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegUsuariosSideBar") Then

                    'actualizo grilla roles
                    grilla.Cargar(BLL.Rol.Listar())

                    If Request.QueryString.HasKeys Then
                        btnCrear.Text = "Guardar"
                        titulo.InnerText = "Modificar Usuario"
                        modUser = New BE.Usuario
                        modUser.email = Request.QueryString("user")
                        modUser = BLL.Usuario.BuscarUsuario(modUser)
                        inputEmail.Value = modUser.email
                        inputEmail.Disabled = True
                        inputfirstName.Value = modUser.nombre
                        inputlastName.Value = modUser.apellido
                        stateDropdownlist.Text = Trim(modUser.estado)
                        divEstado.Visible = True
                        'agregar control para el estado
                        'Y recorrer lista de roles
                        If Not modUser.roles Is Nothing Then
                            grilla.cargarRoles(modUser.roles)
                        End If


                    End If



                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
            End If



        Else
            If Request.QueryString.HasKeys Then
                modUser = New BE.Usuario
                modUser.email = Request.QueryString("user")
                modUser = BLL.Usuario.BuscarUsuario(modUser)
            End If
        End If
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        If modUser Is Nothing Then
            Dim newUser As New BE.Usuario
            newUser.email = inputEmail.Value
            newUser.apellido = inputlastName.Value
            newUser.nombre = inputfirstName.Value
            newUser.token = Helpers.Hasher.Hash(inputEmail.Value)
            newUser.contraseña = "asd"
            newUser.estado = "RESET"
            newUser.intentos = 0

            If BLL.Usuario.RegistrarUsuario(newUser) Then
                newUser = BLL.Usuario.BuscarUsuario(newUser)
                newUser.estado = "RESET"
                If BLL.Usuario.BlanqueoPassword(newUser) Then
                    'linkConfirm.Attributes.Add("href", "ResetPassword.aspx?id=" & newUser.token)
                    divConfirm.Visible = True
                    inputEmail.Value = Nothing
                    inputlastName.Value = Nothing
                    inputfirstName.Value = Nothing
                    bitacora.criticidad = 1
                    bitacora.evento = "Creacion de usuario: " & newUser.email
                    bitacora.usuario = Session("currentUser").email
                    BLL.Bitacora.RegistarEvento(bitacora)
                    Dim msg = "<br /><br />Se ha generado un nuevo usuario asociado a este mail.Por favor ingresa en este link para activar tu cuenta"
                    msg += "<br /><a href = 'http://localhost:49915/ResetPassword.aspx?id=" & newUser.token + "'>Click aqui.</a>"
                    'Helpers.sendMail.send("Bienvenido a GolfTracking", CreateBody(newUser.nombre, "Activar Usuario", msg), newUser.email)
                    Response.Redirect("Usuarios.aspx")
                Else
                    'error creacion del usuario
                    BLL.Usuario.EliminarUsuario(newUser)
                    'modalMsg.mostrar("Error", "Ups! Lo sentimos sucedio un error modificando el usuario")
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! Lo sentimos sucedio un error modificando el usuario", Nothing)
                End If
            Else
                'Error de creacion del usuario
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! Lo sentimos sucedio un error modificando el usuario", Nothing)
            End If
        Else
            'es para modificar el usuario
            Try
                modUser.email = inputEmail.Value
                modUser.apellido = inputlastName.Value
                modUser.nombre = inputfirstName.Value
                modUser.estado = stateDropdownlist.Text
                modUser.roles = grilla.rolesSeleccionados
                If BLL.Usuario.ModificarUsuario(modUser) Then
                    'Usuario modificado con exito
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "El usuario fue modificado exitosamente", "Usuarios.aspx")
                    'Response.Redirect("Usuarios.aspx")
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! Lo sentimos sucedio un error modificando el usuario", Nothing)
                End If
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error!", ex.Message, Nothing)
            End Try

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