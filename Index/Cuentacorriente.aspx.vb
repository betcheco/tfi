Public Class Cuentacorriente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            If Not Session("currentUser") Is Nothing Then
                Session("admin") = BLL.Usuario.CheckPermiso(Session("currentUser"), "btnAdminCuentaCorrienteSideBar")
                actualizar()
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe estar registrado para acceder a la pagina", "Home.aspx")
            End If




        Else
            actualizar()
            'Me.GridView1.DataSource = ViewState("listadoCuentaCorriente")
            'Me.GridView1.DataBind()
        End If

        AddHandler ModalRating.OnAccept, AddressOf calificar
        AddHandler ModalEstado.OnAccept, AddressOf cambiarEstado


    End Sub

    Private Sub cambiarEstado(sender As Object, e As String)
        Try
            Dim o As New BE.Operacion
            o.id = CInt(ViewState("operacionId"))
            o.estado = e
            BLL.Operacion.setEstado(o)
            If e = "CANCELADO" Then
                o = BLL.Operacion.obtener(o.id)
                Dim factura As New BE.Factura
                factura.id = o.id_factura
                factura = BLL.Factura.Obtener(factura)
                Dim nc As New BE.NotaCredito
                nc.fecha = Date.Now
                nc.saldo = 0
                For Each item In factura.items
                    nc.saldo += item.monto
                Next
                Dim us As New BE.Usuario
                us = BLL.Usuario.BuscarUsuarioById(factura.usuario.id)
                nc.usuario = us
                nc.monto = 0
                nc.concepto = "Factura 00" & factura.id
                If BLL.NotaCredito.Crear(nc) Then
                    Helpers.sendMail.generarComprobante(
             "NOTA DE CRÉDITO",
             nc.id,
            nc.usuario.nombre & " " & nc.usuario.apellido,
             DateTime.Now.ToString("dd/MM/yyyy"),
             nc.concepto,
             nc.saldo,
             nc.usuario.email
         )
                End If
            End If

                actualizar()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try

    End Sub

    Sub actualizar()
        Try
            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnAdminCuentaCorrienteSideBar") Then
                ViewState("listadoCuentaCorriente") = BLL.Cuentacorriente.listar(Nothing)
                GridView1.DataSource = BLL.Cuentacorriente.listar(Nothing)
                GridView1.DataBind()
            Else
                Dim listado = BLL.Cuentacorriente.listar(Session("currentUser").id)
                ViewState("listadoCuentaCorriente") = listado
                If listado.Count = 0 Then
                    Me.sinresultados.Visible = True
                End If
                GridView1.DataSource = listado
                GridView1.DataBind()
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, Nothing)
        End Try


    End Sub

    Protected Sub calificar(sender As Object, value As Integer)
        Try
            Dim operacionId = CInt(ViewState("operacionId"))
            BLL.Operacion.setCalificacion(operacionId, value)
            Dim o As New BE.Operacion
            o.id = operacionId
            o.estado = "CALIFICADO"
            BLL.Operacion.setEstado(o)

            actualizar()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try

    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If Not e.Row.DataItem Is Nothing Then
            Dim tcomprobante = DataBinder.Eval(e.Row.DataItem, "tcomprobante").ToString
            Dim calificacion = CInt(DataBinder.Eval(e.Row.DataItem, "calificacion").ToString)
            Dim estado = DataBinder.Eval(e.Row.DataItem, "estado").ToString
            Dim msjnuevo = DataBinder.Eval(e.Row.DataItem, "msjnuevo")
            Dim msjleido = DataBinder.Eval(e.Row.DataItem, "msjleido")
            Dim debe = DataBinder.Eval(e.Row.DataItem, "debe")

            Dim ctrlRating = e.Row.FindControl("rating")
            Dim ctrlGuion = e.Row.FindControl("spnGuion")
            Dim ctrlCalificar = e.Row.FindControl("btnCalificar")

            Dim btnNoMessage = e.Row.FindControl("btnNoMessage")
            Dim btnMessageSent = e.Row.FindControl("btnMessageSent")
            Dim btnMessageReceived = e.Row.FindControl("btnMessageReceived")
            Dim btnMessageRead = e.Row.FindControl("btnMessageRead")
            Dim btnChangeState = e.Row.FindControl("btnChangeState")
            Dim btnAskCancel = e.Row.FindControl("btnAskCancel")

            If tcomprobante = "FC" Then
                ctrlRating.Visible = False
                ctrlGuion.Visible = False
                ctrlCalificar.Visible = False
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnAdminCuentaCorrienteSideBar") Then
                    btnChangeState.Visible = True
                    btnAskCancel.Visible = False
                    Select Case estado
                        Case "CALIFICADO"
                            ctrlRating.Visible = True
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case "FINALIZADO"
                            ' ctrlCalificar.Visible = True
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case "CANCELADO"
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case Else
                            ctrlGuion.Visible = True
                    End Select
                    'message buttons
                    btnNoMessage.Visible = False
                    btnMessageSent.Visible = False
                    btnMessageReceived.Visible = False
                    btnMessageRead.Visible = False

                    If msjnuevo Then
                        btnMessageReceived.Visible = True
                    Else
                        btnMessageReceived.Visible = False
                    End If

                    If msjleido Then
                        btnMessageRead.Visible = True
                    Else
                        btnMessageRead.Visible = False
                    End If
                    'If Not msjnuevo And Not msjleido Then
                    '    btnNoMessage.Visible = True
                    'End If

                Else
                    ctrlRating.Visible = False
                    ctrlGuion.Visible = True
                    ctrlCalificar.Visible = False
                    btnNoMessage.Visible = False
                    btnMessageSent.Visible = False
                    btnMessageReceived.Visible = False
                    btnMessageRead.Visible = False
                    btnChangeState.Visible = False
                    btnAskCancel.Visible = False

                    Select Case estado
                        Case "CALIFICADO"
                            ctrlRating.Visible = True
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case "FINALIZADO"
                            ctrlCalificar.Visible = True
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case "CANCELADO"
                            btnChangeState.Visible = False
                            btnAskCancel.Visible = False
                        Case "CANCELACION"
                            btnAskCancel.Visible = False
                            btnChangeState.Visible = False
                        Case Else
                            ctrlGuion.Visible = True
                            btnAskCancel.Visible = True
                    End Select


                    'message buttons
                    btnNoMessage.Visible = False
                    btnMessageSent.Visible = False
                    btnMessageReceived.Visible = False
                    btnMessageRead.Visible = False

                    If msjnuevo Then
                        btnMessageReceived.Visible = True
                    Else
                        btnMessageReceived.Visible = False
                    End If

                    If msjleido Then
                        btnMessageRead.Visible = True
                    Else
                        btnMessageRead.Visible = False
                    End If
                    If Not msjnuevo And Not msjleido Then
                        btnNoMessage.Visible = True
                    End If
                End If




            Else
                ctrlRating.Visible = False
                ctrlGuion.Visible = True
                ctrlCalificar.Visible = False
                btnNoMessage.Visible = False
                btnMessageSent.Visible = False
                btnMessageReceived.Visible = False
                btnMessageRead.Visible = False
                btnChangeState.Visible = False
                btnAskCancel.Visible = False



            End If


        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            Dim i As Integer = CType(e.CommandArgument, Integer)
            Select Case e.CommandName
                Case "ViewPdf"
                    Dim tipo = GridView1.Rows(i).Cells(3).Text
                    Dim numero = GridView1.Rows(i).Cells(4).Text
                    Dim prefix = IIf(tipo = "FC", "FACTURA", "NOTA DE CRÉDITO")
                    Dim filename = "comprobantes/" & prefix & "_" & numero & ".pdf"
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "OpenWindow", "window.open('" & filename & "','_newtab');", True)
                Case "Calificar"
                    ViewState("operacionId") = i
                    ModalRating.Show()
                Case "Message"
                    Session("chatAdmin") = BLL.Usuario.CheckPermiso(Session("currentUser"), "btnAdminCuentaCorrienteSideBar")
                    Response.Redirect("Chat.aspx?operacion=" & i)
                Case "ChangeState"
                    'Muestro modal cambio estado
                    ViewState("operacionId") = i
                    Session("operacionId") = i
                    ModalEstado.Show()
                Case "AskCancel"
                    ViewState("operacionId") = i
                    solicitarCancelacion()

            End Select
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Cuentacorriente.aspx")
        End Try

    End Sub

    Private Sub solicitarCancelacion()
        Try
            Dim operacion As New BE.Operacion
            operacion.id = ViewState("operacionId")
            operacion.estado = "CANCELACION"
            If BLL.Operacion.setEstado(operacion) Then
                Dim b As New BE.Bitacora
                b.criticidad = 2
                b.evento = "Solicitud de cancelacion"
                b.usuario = Session("currentUser").email
                actualizar()
            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error solicitando la cancelacion", Nothing)
        End Try

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        actualizar()
    End Sub
End Class