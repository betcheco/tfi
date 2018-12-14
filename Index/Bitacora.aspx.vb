Public Class Bitacora
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegBitacoraSideBar") Then
                inputCriticidad.SelectedValue = 0
                Session("filtroFdesde") = Nothing
                Session("filtroFhasta") = Nothing
                Session("filtroUser") = Nothing
                Session("filtroCriticidad") = Nothing

                Actualizar()
                Dim listUsuarios = BLL.Usuario.Listar
                Dim listNombreUsuarios As New List(Of String)
                listNombreUsuarios.Add("Todos")
                For Each usuario In listUsuarios
                    listNombreUsuarios.Add(usuario.email)

                Next
                userList.DataSource = listNombreUsuarios
                userList.DataBind()
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If

        End If

        'TryCast(Me.Master, masterPrincipal).mostrarMesaje()

    End Sub

    Protected Sub showBtn_Click(sender As Object, e As EventArgs) Handles showBtn.Click
        'sin filtros
        If (inputDateFrom.Text = "") And (inputDateTo.Text = "") And (inputCriticidad.SelectedValue = 0) And (userList.SelectedValue = "Todos") Then
            Session("filtroFdesde") = Nothing
            Session("filtroFhasta") = Nothing
            Session("filtroUser") = Nothing
            Session("filtroCriticidad") = Nothing

            Actualizar()

        Else
            'Filtro solo criticidad
            If (inputCriticidad.SelectedValue <> 0) And (inputDateFrom.Text = "") And (inputDateTo.Text = "") And (userList.SelectedValue = "Todos") Then
                Session("filtroFdesde") = Nothing
                Session("filtroFhasta") = Nothing
                Session("filtroUser") = Nothing
                Session("filtroCriticidad") = inputCriticidad.SelectedValue
                Actualizar()

            Else
                'Fecha de inicio
                If (inputCriticidad.SelectedValue = 0) And (inputDateFrom.Text <> "") And (inputDateTo.Text = "") And (userList.SelectedValue = "Todos") Then
                    'Mensaje debe iniciar todas las fechas
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error en fechas", "Debe seleccionar todas las fechas, falta seleccionar fecha hasta", Nothing)
                Else
                    'solo fecha hasta
                    If (inputCriticidad.SelectedValue = 0) And (inputDateFrom.Text = "") And (inputDateTo.Text <> "") And (userList.SelectedValue = "Todos") Then
                        'Mensaje debe iniciar todas las fechas
                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error en fechas", "Debe seleccionar todas las fechas, falta seleccionar fecha desde", Nothing)
                    Else
                        'filtro solo por fechas
                        If (inputCriticidad.SelectedValue = 0) And (inputDateFrom.Text <> "") And (inputDateTo.Text <> "") And (userList.SelectedValue = "Todos") Then
                            Dim fdesde As Date
                            Dim fhasta As Date
                            Try
                                fdesde = CType(inputDateFrom.Text, Date)
                                fhasta = CType(inputDateTo.Text, Date)

                            Catch ex As Exception
                                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error!", "Ups! ocurrio un error: " + ex.Message, Nothing)

                            End Try

                            If fhasta < fdesde Then
                                'mostrar error fecha hasta mayor que desde
                                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error en fechas", "La fecha hasta debe ser menor a la fecha desde", Nothing)
                            Else
                                Try
                                    Session("filtroFdesde") = fdesde
                                    Session("filtroFhasta") = fhasta
                                    Session("filtroUser") = Nothing
                                    Session("filtroCriticidad") = Nothing
                                    Actualizar()
                                Catch ex As Exception
                                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
                                End Try
                                'filtro fecha + criticidad
                                If (inputCriticidad.SelectedValue <> 0) And (inputDateFrom.Text <> "") And (inputDateTo.Text <> "") And (userList.SelectedValue = "Todos") Then
                                    Try
                                        Session("filtroFdesde") = fdesde
                                        Session("filtroFhasta") = fhasta
                                        Session("filtroUser") = Nothing
                                        Session("filtroCriticidad") = inputCriticidad.SelectedValue
                                        Actualizar()
                                    Catch ex As Exception
                                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
                                    End Try
                                End If

                            End If

                        End If

                    End If
                    'Filtro solo usuario
                    If (inputCriticidad.SelectedValue = 0) And (inputDateFrom.Text = "") And (inputDateTo.Text = "") And (userList.SelectedValue <> "Todos") Then
                        Try
                            Dim usuario As New BE.Usuario
                            usuario.email = userList.SelectedValue
                            Session("filtroFdesde") = Nothing
                            Session("filtroFhasta") = Nothing
                            Session("filtroUser") = userList.SelectedValue
                            Session("filtroCriticidad") = Nothing
                            Actualizar()
                        Catch ex As Exception
                            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)

                        End Try
                    Else
                        'filtro usuario y criticidad
                        If (inputCriticidad.SelectedValue <> 0) And (inputDateFrom.Text = "") And (inputDateTo.Text = "") And (userList.SelectedValue <> "Todos") Then
                            Try
                                Dim usuario As New BE.Usuario
                                usuario.email = userList.SelectedValue
                                Session("filtroFdesde") = Nothing
                                Session("filtroFhasta") = Nothing
                                Session("filtroUser") = userList.SelectedValue
                                Session("filtroCriticidad") = inputCriticidad.SelectedValue
                                Actualizar()
                            Catch ex As Exception
                                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)

                            End Try
                        Else
                            'filtro usuario y fecha
                            If (inputCriticidad.SelectedValue = 0) And (inputDateFrom.Text <> "") And (inputDateTo.Text <> "") And (userList.SelectedValue <> "Todos") Then
                                'Dim listaBitacoraFull = BLL.Bitacora.ConsultarBItacora(CType(inputDateFrom.Text, Date), CType(inputDateTo.Text, Date), Nothing, userList.SelectedValue)
                                'Me.bitacoraGrid.DataSource = listaBitacoraFull
                                'Me.bitacoraGrid.DataBind()
                                Dim usuario As New BE.Usuario
                                usuario.email = userList.SelectedValue
                                Session("filtroFdesde") = CType(inputDateFrom.Text, Date)
                                Session("filtroFhasta") = CType(inputDateTo.Text, Date)
                                Session("filtroUser") = userList.SelectedValue
                                Session("filtroCriticidad") = Nothing
                                Actualizar()


                            Else
                                'filtro full
                                If (inputCriticidad.SelectedValue <> 0) And (inputDateFrom.Text <> "") And (inputDateTo.Text <> "") And (userList.SelectedValue <> "Todos") Then
                                    'Dim listaBitacoraFull = BLL.Bitacora.ConsultarBItacora(CType(inputDateFrom.Text, Date), CType(inputDateTo.Text, Date), inputCriticidad.SelectedValue, userList.SelectedValue)
                                    'Me.bitacoraGrid.DataSource = listaBitacoraFull
                                    'Me.bitacoraGrid.DataBind()
                                    Dim usuario As New BE.Usuario
                                    usuario.email = userList.SelectedValue
                                    Session("filtroFdesde") = CType(inputDateFrom.Text, Date)
                                    Session("filtroFhasta") = CType(inputDateTo.Text, Date)
                                    Session("filtroUser") = userList.SelectedValue
                                    Session("filtroCriticidad") = inputCriticidad.SelectedValue
                                    Actualizar()
                                End If
                            End If

                        End If

                    End If
                End If
            End If
        End If





    End Sub

    Private Sub Actualizar()
        Dim fdesde As Date
        Dim fhasta As Date
        If Session("filtroFdesde") Is Nothing And Session("filtroFhasta") Is Nothing Then
            fdesde = CType("01/01/1990", Date)
            fhasta = CType("01/01/1990", Date)
        Else
            fdesde = CType(inputDateFrom.Text, Date)
            fhasta = CType(inputDateTo.Text, Date)
        End If

        If Session("filtroCriticidad") Is Nothing Then
            Session("filtroCriticidad") = 0
        End If
        If Not fdesde > fhasta Then
            Try
                Dim listaBitacora = BLL.Bitacora.ConsultarBItacora(fdesde, fhasta, Session("filtroCriticidad"), Session("filtroUser"))
                Me.bitacoraGrid.DataSource = listaBitacora
                Me.bitacoraGrid.DataBind()
                If listaBitacora.Count = 0 Then
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "No se encontraron eventos", Nothing)
                End If
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, Nothing)
            End Try
        Else
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "La fecha desde no puede ser posterior a la fecha hasta", Nothing)
        End If



    End Sub

    Protected Sub bitacoraGrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles bitacoraGrid.PageIndexChanging

        bitacoraGrid.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub

    Protected Sub btnBorrarFiltros_Click(sender As Object, e As EventArgs) Handles btnBorrarFiltros.Click
        inputDateFrom.Text = ""
        inputDateTo.Text = ""
        inputCriticidad.SelectedValue = 0
        userList.SelectedValue = "Todos"
        '  Actualizar()
    End Sub
End Class