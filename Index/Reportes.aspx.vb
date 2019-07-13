Imports System.Web.UI.DataVisualization.Charting

Public Class Reportes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnReportesSideBar") Then
                Try
                    divTiempoDeRespuesta.Visible = False
                    Me.divFichasDeOpinion.Visible = False
                    Me.divGanancias.Visible = False
                    Me.divEncuestas.Visible = False

                    Dim dsEncuestas = BLL.Encuesta.listar()
                    Me.grdEncuestas.DataSource = dsEncuestas
                    Me.grdEncuestas.DataBind()

                    Dim dsFichasDeOpinion = BLL.Encuesta.listar(True)
                    Me.grdFichasDeOpinion.DataSource = dsFichasDeOpinion
                    Me.grdFichasDeOpinion.DataBind()

                    Me.gridGanacias.Visible = False
                    Me.btnVerListado.Text = "Ver listado"
                    Session("verlistadoganancias") = True
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, Nothing)
                End Try
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If

        Else
            'If Session("verlistadoganancias") Then
            '    Me.gridGanacias.Visible = False
            '    Me.btnVerListado.Text = "Ver listado"
            '    Session("verlistadoganancias") = False
            'End If
        End If


    End Sub

    Protected Sub btnChats_Click(sender As Object, e As EventArgs) Handles btnChats.Click
        divTiempoDeRespuesta.Visible = True
        Me.divFichasDeOpinion.Visible = False
        Me.divGanancias.Visible = False
        Me.divEncuestas.Visible = False

        Me.btnChats.CssClass = "btn-chats-active"
        Me.btnEncuestas.CssClass = "btn-outline-warning"
        Me.btnFichas.CssClass = "btn-outline-success"
        Me.btnGanancias.CssClass = "btn-outline-info"
    End Sub
    Protected Sub btnFiltrarTiempoDeRespuesta_Click(sender As Object, e As EventArgs) Handles btnFiltrarTiempoDeRespuesta.Click
        'valida que ambas fechas esten indicadas
        If Me.dpDesdeTiempoDeRespuesta.Text = "" Or Me.dpHastaTiempoDeRespuesta.Text = "" _
        Then
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe indicar ambas fechas", Nothing)
            Return
        End If

        'valida que fecha desde no sea mayor a fecha hasta
        If Not Me.dpDesdeTiempoDeRespuesta.Text = "" And Not Me.dpHastaTiempoDeRespuesta.Text = "" And
          CDate(Me.dpDesdeTiempoDeRespuesta.Text) > CDate(Me.dpHastaTiempoDeRespuesta.Text) Then

            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Fecha desde no puede ser mayor a fecha hasta", Nothing)
            Return
        End If

        Dim res = BLL.Chat.reporte(CDate(dpDesdeTiempoDeRespuesta.Text).ToString("yyyyMMdd"), CDate(dpHastaTiempoDeRespuesta.Text).ToString("yyyyMMdd"))
        Dim table = Helpers.Charts.DicToDataTable(res, "Minutos")

        If (table.Rows.Count = 0) Then
            Me.divPreguntaTiempoDeRespuesta.InnerHtml = "No se encontró información"
            Me.divTiempoDeRespuesta_Content.Visible = True
        Else
            Dim total As Integer
            Dim count As Integer
            For Each r As DataRow In table.Rows
                total += CInt(r.Item("Minutos")) * CInt(r.Item("value"))
                count += CInt(r.Item("value"))
            Next
            Dim avg = total / count
            Me.divPreguntaTiempoDeRespuesta.InnerHtml = "Tiempo promedio de atencion: " + avg.ToString("N2") + " minutos"

            Dim Dvista As New System.Data.DataView(table)


            chartTiempoDeRespuesta.Series(0).Points.DataBindXY(Dvista, "Minutos", Dvista, "value")
            chartTiempoDeRespuesta.Series(0).ChartType = SeriesChartType.Column
            chartTiempoDeRespuesta.ChartAreas("ChartArea1").AxisX.Title = "Tiempo de respuesta (Minutos)"
            chartTiempoDeRespuesta.ChartAreas("ChartArea1").AxisY.Title = "Consultas"
            chartTiempoDeRespuesta.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        End If

        Me.divTiempoDeRespuesta_Content.Visible = True



    End Sub

    Protected Sub btnFichas_Click(sender As Object, e As EventArgs) Handles btnFichas.Click
        Me.divTiempoDeRespuesta.Visible = False
        Me.divFichasDeOpinion.Visible = True
        Me.divGanancias.Visible = False
        Me.divEncuestas.Visible = False
        Me.divGananciasResultados.Visible = False

        Me.btnChats.CssClass = "btn-outline-danger"
        Me.btnEncuestas.CssClass = "btn-outline-warning"
        Me.btnFichas.CssClass = "btn-fichas-active"
        Me.btnGanancias.CssClass = "btn-outline-info"
    End Sub

    Protected Sub btnGanancias_Click(sender As Object, e As EventArgs) Handles btnGanancias.Click
        Me.divTiempoDeRespuesta.Visible = False
        Me.divFichasDeOpinion.Visible = False
        Me.divGanancias.Visible = True
        Me.divEncuestas.Visible = False
        Me.divGananciasResultados.Visible = False


        Me.btnChats.CssClass = "btn-outline-danger"
        Me.btnEncuestas.CssClass = "btn-outline-warning"
        Me.btnFichas.CssClass = "btn-outline-success"
        Me.btnGanancias.CssClass = "btn-ganancias-active"




    End Sub

    Protected Sub btnEncuestas_Click(sender As Object, e As EventArgs) Handles btnEncuestas.Click
        Me.divTiempoDeRespuesta.Visible = False
        Me.divFichasDeOpinion.Visible = False
        Me.divGanancias.Visible = False
        Me.divEncuestas.Visible = True
        Me.divGananciasResultados.Visible = False


        Me.btnChats.CssClass = "btn-outline-danger"
        Me.btnEncuestas.CssClass = "btn-encuestas-active"
        Me.btnFichas.CssClass = "btn-outline-success"
        Me.btnGanancias.CssClass = "btn-outline-info"

    End Sub

    Protected Sub grdEncuestas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdEncuestas.SelectedIndexChanging
        Dim r As GridViewRow = Me.grdEncuestas.Rows(e.NewSelectedIndex)
        Dim EncuestaId = grdEncuestas.DataKeys(e.NewSelectedIndex).Value

        Dim enc = BLL.Encuesta.obtener(EncuestaId)
        Me.divPreguntaEncuesta.InnerHtml = enc.nombre


        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Doughnut
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True


        Me.divEncuestas_Content.Visible = True

    End Sub
    Protected Sub grdFichasDeOpinion_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdFichasDeOpinion.SelectedIndexChanging
        Dim r As GridViewRow = Me.grdFichasDeOpinion.Rows(e.NewSelectedIndex)
        Dim FichaDeOpinionId = grdFichasDeOpinion.DataKeys(e.NewSelectedIndex).Value

        Dim enc = BLL.Encuesta.obtener(FichaDeOpinionId)
        Me.divPreguntaFichaDeOpinion.InnerHtml = enc.nombre


        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartFichaDeOpinion.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartFichaDeOpinion.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True


        Me.divFichasDeOpinion_Content.Visible = True



    End Sub

    Protected Sub btnGananciasYTD_Click(sender As Object, e As EventArgs) Handles btnGananciasYTD.Click
        Me.divTiempoDeRespuesta.Visible = False
        Me.divFichasDeOpinion.Visible = False
        Me.divGanancias.Visible = True
        Me.divEncuestas.Visible = False
        Try
            Dim res = BLL.Reporte.ytd()
            Me.lblTotalMensual.Text = BLL.Reporte.total(res)
            Me.divGananciasResultados.Visible = True

            'Dim table = Helpers.Charts.DicToDataTable(res, "Minutos")
            'Dim Dvista As New System.Data.DataView(res)
            Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.Reporte)(res))
            ChartGanancias.Series(0).Points.DataBindXY(Dvista, "fecha", Dvista, "monto")
            ChartGanancias.Series(0).ChartType = SeriesChartType.Area
            ChartGanancias.ChartAreas("ChartAreaGanancias").AxisX.Title = "Mes"
            ChartGanancias.ChartAreas("ChartAreaGanancias").AxisY.Title = "$"
            ChartGanancias.ChartAreas("ChartAreaGanancias").Area3DStyle.Enable3D = True

            Me.gridGanacias.DataSource = BLL.Reporte.listadoYtd()
            Me.gridGanacias.DataBind()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try


    End Sub

    Protected Sub btnMensualGanancias_Click(sender As Object, e As EventArgs) Handles btnMensualGanancias.Click
        Me.divTiempoDeRespuesta.Visible = False
        Me.divFichasDeOpinion.Visible = False
        Me.divGanancias.Visible = True
        Me.divEncuestas.Visible = False

        Try
            Dim res = BLL.Reporte.mensual(CInt(ddlMes.SelectedValue))
            Me.lblTotalMensual.Text = BLL.Reporte.total(res)
            Me.divGananciasResultados.Visible = True
            'Dim table = Helpers.Charts.DicToDataTable(res, "Minutos")
            'Dim Dvista As New System.Data.DataView(res)
            Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.Reporte)(res))
            ChartGanancias.Series(0).Points.DataBindXY(Dvista, "fecha", Dvista, "monto")
            ChartGanancias.Series(0).ChartType = SeriesChartType.Area
            ChartGanancias.ChartAreas("ChartAreaGanancias").AxisX.Title = "Fecha"
            ChartGanancias.ChartAreas("ChartAreaGanancias").AxisY.Title = "$"
            ChartGanancias.ChartAreas("ChartAreaGanancias").Area3DStyle.Enable3D = True

            Me.gridGanacias.DataSource = BLL.Reporte.listadoMensual(CInt(ddlMes.SelectedValue))
            Me.gridGanacias.DataBind()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try

    End Sub

    Protected Sub btnFiltrarGanancias_Click(sender As Object, e As EventArgs) Handles btnFiltrarGanancias.Click
        Try
            If Me.dpDesdeGanancias.Text = "" Or Me.dpHastaGanancias.Text = "" Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe seleccionar ambas fechas validas", Nothing)
                Return
            End If

            If Me.dpDesdeGanancias.Text <> "" And Me.dpHastaGanancias.Text <> "" Then
                If CDate(Me.dpDesdeGanancias.Text) < CDate(Me.dpHastaGanancias.Text) Then
                    Dim res = BLL.Reporte.fecha(Me.dpDesdeGanancias.Text, Me.dpHastaGanancias.Text)
                    Me.lblTotalMensual.Text = BLL.Reporte.total(res)
                    Me.divGananciasResultados.Visible = True
                    'Dim table = Helpers.Charts.DicToDataTable(res, "Minutos")
                    'Dim Dvista As New System.Data.DataView(res)
                    Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.Reporte)(res))
                    ChartGanancias.Series(0).Points.DataBindXY(Dvista, "fecha", Dvista, "monto")
                    ChartGanancias.Series(0).ChartType = SeriesChartType.Area
                    ChartGanancias.ChartAreas("ChartAreaGanancias").AxisX.Title = "Fecha"
                    ChartGanancias.ChartAreas("ChartAreaGanancias").AxisY.Title = "$"
                    ChartGanancias.ChartAreas("ChartAreaGanancias").Area3DStyle.Enable3D = True

                    Me.gridGanacias.DataSource = BLL.Reporte.ListadoFecha(Me.dpDesdeGanancias.Text, Me.dpHastaGanancias.Text)
                    Me.gridGanacias.DataBind()

                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe seleccionar ambas fechas validas", Nothing)
                    Return
                End If

            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try


    End Sub

    Protected Sub btnVerListado_Click(sender As Object, e As EventArgs) Handles btnVerListado.Click
        Try
            If Session("verlistadoganancias") Then
                Me.gridGanacias.Visible = True
                Me.btnVerListado.Text = "Ocultar listado"
                Session("verlistadoganancias") = False
            Else
                Me.gridGanacias.Visible = False
                Me.btnVerListado.Text = "Ver listado"
                Session("verlistadoganancias") = True
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Reportes.aspx")
        End Try

    End Sub
End Class