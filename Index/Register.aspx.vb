Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class Register
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim newUser As New BE.Usuario
        Try
            If (inputconfirmPassword.Value = inputPassword.Value) Then
                If tycCheck.Checked Then
                    If inputPassword.Value.Length < 8 Then
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "setAlertText('danger','La contraseña debe tener al menos 8 caracteres');", True)
                        'alertDanger.Visible = True
                        modalMsg.mostrar("Error", "La contraseña debe tener al menos 8 caracteres", Nothing)
                        Return
                    End If

                    If Not ctrlGoogleReCaptcha.Validate Then
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "setAlertText('danger','Captcha no válido');", True)
                        'alertDanger.Visible = True
                        modalMsg.mostrar("Error", "Captcha no válido", Nothing)
                        Return
                    End If
                    newUser.nombre = inputfirstName.Value
                    newUser.apellido = inputlastName.Value
                    newUser.email = inputEmail.Value
                    newUser.contraseña = Helpers.Hasher.Hash(inputconfirmPassword.Value)
                    newUser.token = Helpers.Hasher.Hash(inputEmail.Value)


                    If (BLL.Usuario.RegistrarUsuario(newUser)) Then
                        If profileDropdownlist.SelectedValue = "Jugador" Then
                            Dim rol As New BE.Rol
                            rol.id = 11
                            newUser = BLL.Usuario.BuscarUsuario(newUser)
                            newUser.roles.Add(rol)
                        Else
                            Dim rol As New BE.Rol
                            rol.id = 12
                            newUser = BLL.Usuario.BuscarUsuario(newUser)
                            newUser.roles.Add(rol)

                        End If
                        linkConfirm.Visible = False

                        linkConfirm.Attributes.Add("href", "RegisterConfirm.aspx?id=" & newUser.token)

                        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "openModalSuc();", True)
                        ' TryCast(Me.Master, masterPrincipal).mostrarMesaje("Registro exitoso", "Gracias por registrarse, en instantes recibira un mail a la direccion registrada para finalizar el proceso.", Nothing)
                        modalMsg.mostrar("Registro exitoso", "Gracias por registrarse, en instantes recibira un mail a la direccion registrada para finalizar el proceso.", "Home.aspx")
                        bitacora.criticidad = 3
                        bitacora.evento = "Se registro el usuario: " & newUser.email
                        bitacora.usuario = newUser.email
                        BLL.Bitacora.RegistarEvento(bitacora)
                        Dim msg = "<br /><br />Por favor ingresa en este link para activar tu cuenta"
                        msg += "<br /><a href = 'http://localhost:49915/RegisterConfirm.aspx?id=" & newUser.token + "'>Click aqui.</a>"

                        ' Helpers.sendMail.send("Activacion de registro", CreateBody(newUser.nombre, "Activar usuario", msg), newUser.email)
                        'SendActivationEmail(newUser)
                    Else
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "errorRegistro();", True)
                        modalMsg.mostrar("Error", "Hubo un eror durante el proceso de registracion", Nothing)
                        ' TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Hubo un eror durante el proceso de registracion", Nothing)
                        bitacora.criticidad = 3
                        bitacora.evento = "Sucedio un error en el registro del usuario ya existe usuario registrado con mismo email: " & newUser.email
                        bitacora.usuario = newUser.email
                        BLL.Bitacora.RegistarEvento(bitacora)
                    End If


                    'btnRegistrar.Attributes.Add("onclick", "javascript:openModal()")


                    ' Response.Redirect("Home.aspx")
                Else
                    ' ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "setAlertText('danger','Debe aceptar los terminos y condiciones');", True)
                    'alertDanger.Visible = True
                    modalMsg.mostrar("Error", "Debe aceptar los terminos y condiciones", Nothing)
                    'Mensaje porfavor acepta los terminos y condiciones
                End If
            Else
                ' ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "setAlertText('danger','Las contraseñas no coinciden');", True)
                '  alertDanger.Visible = True
                modalMsg.mostrar("Error", "Las contraseñas no coinciden", Nothing)
                'Mensaje las password no coinciden

            End If

        Catch ex As Exception
            modalMsg.mostrar("Error", ex.Message, Nothing)
        End Try


    End Sub

    Public Sub SendActivationEmail(newUser As BE.Usuario)
        Using mm As New MailMessage("golftracking2018@gmail.com", newUser.email)
            mm.Subject = "Confirmacion de registro a GolfTracking"
            Dim body As String = "Hola " + newUser.nombre.Trim() + ","
            body += "<br /><br />Por favor ingresa en este link para activar tu cuenta"
            body += "<br /><a href = 'http://localhost:49915/RegisterConfirm.aspx?id=" & newUser.token + "'>Click aqui.</a>"
            body += "<br /><br />Gracias"
            mm.Body = body
            mm.IsBodyHtml = True
            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential("golftracking2018@gmail.com", "Golf*2018")
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587

            Try
                smtp.Send(mm)
                bitacora.usuario = newUser.email
                bitacora.criticidad = 3
                bitacora.evento = "Envio mail confirmacion"
            Catch ex As Exception
                bitacora.usuario = newUser.email
                bitacora.criticidad = 3
                bitacora.evento = "Fallo el Envio del mail confirmacion: " & ex.Message
                Console.Write("ERROR" & ex.Message)
            End Try
        End Using
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