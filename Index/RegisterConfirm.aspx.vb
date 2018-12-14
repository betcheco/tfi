Public Class RegisterConfirm
    Inherits System.Web.UI.Page
    Dim oUser As New BE.Usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Session("currentUser") Is Nothing Then
                oUser.token = Request.QueryString("id")
            Else
                Session("userToConfirm") = Session("currentUser")
            End If


            If Not oUser.token Is Nothing Then
                Try
                    oUser = BLL.Usuario.BuscarUsuario(oUser)
                    Session("userToConfirm") = oUser
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error: ", ex.Message, Nothing)
                End Try


                'BLL.Usuario.ActivarUsuario(oUser)
                'Dim bitacora As New BE.Bitacora
                'bitacora.usuario = oUser.email
                'bitacora.criticidad = 3
                'bitacora.evento = "Activacion de usuario"
                ''mostrar mensaje de exito
                ''  Master.FindControl("alertSuccess").Visible = True
                ''TryCast(Me.Master, masterPrincipal).MostrarAlerta("success", "Su usuario se encuentra activado")
                'success.Visible = True
            Else
                'success.Visible = False

            End If

            End If



    End Sub

    Protected Sub btnResetPwd_Click(sender As Object, e As EventArgs) Handles btnResetPwd.Click
        Try
            oUser = Session("userToConfirm")
            If (Helpers.Hasher.Comparar(inputPassword.Value, oUser.contraseña)) Then

                If (inputNewpassword.Value = inputConfirmPassword.Value) Then
                    oUser.contraseña = Helpers.Hasher.Hash(inputNewpassword.Value)
                    oUser.estado = "CONFIRMADO"
                    If BLL.Usuario.ModificarUsuario(oUser) Then
                        Dim bitacora As New BE.Bitacora
                        bitacora.usuario = oUser.email
                        bitacora.criticidad = 3
                        If Session("currentUser") Is Nothing Then
                            bitacora.evento = "Activacion de usuario"
                            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Activacion de usuario", "El usuario fue activado con exito", "Home.aspx")
                        Else
                            bitacora.evento = "Reseteo de Contraseña"
                            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Reseteo de Contraseña", "Su contraseña fue reseteada correctamente", "Home.aspx")
                        End If

                    End If


                    'Response.Redirect("Home.aspx")
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Las contraseñas nuevas no coinciden", Nothing)
                End If
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Contraseña incorrecta", Nothing)

            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", ex.Message, Nothing)
        End Try

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Not Session("currentUser") Is Nothing Then
            Try
                oUser = Session("currentUser")
                oUser.estado = "CONFIRMADO"
                Response.Redirect("Home.aspx")
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
            End Try


        End If
    End Sub
End Class