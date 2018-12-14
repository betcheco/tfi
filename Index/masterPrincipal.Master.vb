Imports System.Web.UI.DataVisualization.Charting

Public Class masterPrincipal
    Inherits System.Web.UI.MasterPage
    Dim bitacora As New BE.Bitacora

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", ".-En Bitacora todos los filtros en una misma row(achicar)", Nothing)
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", ".-En Bitacora Verificar bug boton Borrar Filtros", Nothing)
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", ".-En Noticia boton volver", Nothing)
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", ".-enviar newsletter envio cuando creo noticia, varias categorias, sin activacion", Nothing)
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", ".Revisar logout", Nothing)
        'mostrarMesaje("TENES QUE HACER ESTO PAPARULO", "Para comprar achicar foto y descripcion de producto, mejorar UI de validacion para compra", Nothing)


        If Not (Page.IsPostBack) Then
            hidePublicUser()
            setEncuesta()
        End If

    End Sub



    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim user As New BE.Usuario
        user.email = inputEmail.Text
        Try
            user = BLL.Usuario.BuscarUsuario(user)
            'MsgBox("User ok")
        Catch ex As Exception
            'MsgBox("Err " & ex.Message)
            mostrarMesaje("Error", ex.Message, Nothing)
            user = Nothing
            bitacora.criticidad = 4
            bitacora.evento = "Hubo un error en el login del usuario: " & inputEmail.Text & " Error: " & ex.Message
            bitacora.usuario = inputEmail.Text
            BLL.Bitacora.RegistarEvento(bitacora)
        End Try
        Try
            If Not (user.apellido) Is Nothing Then
                If user.estado.Trim = "CONFIRMADO" Then
                    If (Helpers.Hasher.Comparar(inputPassword.Text, user.contraseña)) Then
                        Session("user") = user.email
                        Session("currentUser") = user
                        hidePublicUser()
                        bitacora.criticidad = 3
                        bitacora.evento = "Hizo login el usuario: " & user.email
                        bitacora.usuario = user.email
                        BLL.Bitacora.RegistarEvento(bitacora)
                    Else
                        user.intentos = user.intentos + 1
                        If user.intentos = 3 Then
                            user.estado = "BLOQUEADO"
                            BLL.Usuario.ModificarUsuario(user)
                            bitacora.criticidad = 4
                            bitacora.evento = "Se bloqueo el usuario ante reiterados intentos fallidos de login"
                            bitacora.usuario = user.email
                            BLL.Bitacora.RegistarEvento(bitacora)
                            mostrarMesaje("Error", "El usuario se encuentra bloqueado por intentos fallidos. Realice un blanqueo de password para volver a activarlo", Nothing)
                        Else
                            If user.intentos > 3 Then
                                BLL.Usuario.ModificarUsuario(user)
                                bitacora.criticidad = 3
                                bitacora.evento = "El usuario intenta ingresar con la cuenta bloqueada"
                                bitacora.usuario = user.email
                                BLL.Bitacora.RegistarEvento(bitacora)
                                mostrarMesaje("Error", "El usuario se encuentra bloqueado por intentos fallidos. Realice un blanqueo de password para volver a activarlo", Nothing)
                            Else
                                BLL.Usuario.ModificarUsuario(user)
                                bitacora.criticidad = 2
                                bitacora.evento = "Ingreso incorrecto"
                                bitacora.usuario = user.email
                                BLL.Bitacora.RegistarEvento(bitacora)
                                mostrarMesaje("Error", "El usuario o contraseña es incorrecto", Nothing)
                            End If
                        End If
                        '  BLL.Usuario.ModificarUsuario(user)
                    End If
                Else
                    If user.estado.Trim = "BLOQUEADO" Then
                        mostrarMesaje("Error", "El usuario se encuentra bloqueado por intentos fallidos. Realice un blanqueo de password para volver a activarlo", Nothing)
                    Else
                        mostrarMesaje("Error", "No fue posible el inicio de sesion, porfavor comuniquese con soporte", Nothing)
                    End If
                End If
            Else
                mostrarMesaje("Error", "El usuario o contraseña es incorrecto", Nothing)
            End If
        Catch ex As Exception
            mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try



        'Prueba
        'Session("user") = "Bruno"
        'hidePublicUser()

    End Sub

    Public Sub mostrarMesaje(pTitulo, pMensaje, ruta)
        Me.modalMsg.mostrar(pTitulo, pMensaje, ruta)
    End Sub

    Protected Sub btnLogoutModal_Click(sender As Object, e As EventArgs) Handles btnLogoutModal.Click
        Console.WriteLine("Click en boton loguout del modal")
        bitacora.evento = "Hizo logout el usuario: " & Session("user")
        bitacora.usuario = Session("user")
        Session.Remove("user")
        Session.Remove("currentUser")
        Session.RemoveAll()
        Response.Redirect("Home.aspx")
        btnIngresarNavBar.Visible = True
        bitacora.criticidad = 3

        BLL.Bitacora.RegistarEvento(bitacora)

    End Sub


    Sub hidePublicUser()
        If Session("user") Is Nothing Then
            sidebar.Visible = True
            btnProfileSidebar.Visible = False
            btnIngresarNavBar.Visible = True
            navbarSeparador.Visible = False
            username.Visible = False
            logoutOption.Visible = False

        Else
            sidebar.Visible = True
            btnIngresarNavBar.Visible = False
            'recorrer permisos
            RecorrerPermisos()
            navbarSeparador.Visible = True
            username.Visible = True
            logoutOption.Visible = True
            btnProfileSidebar.Visible = True
            ProfileNavBarBtn.InnerText = Session("user")


        End If

    End Sub

    Sub RecorrerPermisos()
        Try
            If Not Session("currentUser") Is Nothing Then
                Dim user As New BE.Usuario
                user = Session("currentUser")
                For Each rol In user.roles
                    For Each permiso In rol.permisos
                        If permiso.nombre.Contains("SideBar") Then
                            Me.FindControl(permiso.nombre).Visible = True
                        End If
                        'If Not permiso.id = 16 Then

                        'End If

                    Next
                Next
            End If
        Catch ex As Exception
            mostrarMesaje("Error en check permisos", "Ups!  " & ex.Message, Nothing)
        End Try

    End Sub

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)
        If inputSearch.Value.Length > 0 Then

            Try
                Response.Redirect("Busqueda.aspx?palabra=" & inputSearch.Value)
            Catch ex As Exception
                mostrarMesaje("Error", "Sucedio un error a procesar su busqueda", Nothing)
            End Try

        End If


    End Sub

    Protected Sub setEncuesta()
        Me.divEncuesta.Visible = Session("encuestaCerrada") Is Nothing And Session("encuestaRespondida") Is Nothing
        If Me.divEncuesta.Visible Then
            Dim e = BLL.Encuesta.getRandom
            If e Is Nothing Then
                btnCloseEncuesta_Click(Nothing, Nothing)
            Else
                Session("encuestaId") = e.id
                Me.encuestaText.InnerHtml = e.nombre
                rptEncuestaOpciones.DataSource = e.opciones
                rptEncuestaOpciones.DataBind()
            End If
        End If
    End Sub
    Protected Sub rptEncuestaOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEncuestaOpciones.ItemCommand
        BLL.Encuesta.votar(CInt(e.CommandArgument))

        Dim enc = BLL.Encuesta.obtener(Session("encuestaId"))
        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie

        divEncuestaChart.Visible = True
        divEncuestaPreguntas.Visible = False

        Session("encuestaRespondida") = True
    End Sub

    Protected Sub btnCloseEncuesta_Click(sender As Object, e As EventArgs) Handles btnCloseEncuesta.Click
        Session("encuestaCerrada") = True
        Me.divEncuesta.Visible = False
    End Sub
End Class