Imports System.Web.UI.DataVisualization.Charting

Public Class ABMEncuestas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnABMEncuestasSideBar") Then
                    Actualizar()
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
            End If

        End If
    End Sub

    Private Sub Actualizar()
        Try
            Dim dsEncuestas = BLL.Encuesta.listar()
            Me.grd.DataSource = dsEncuestas
            Me.grd.DataBind()

            Dim dsFichas = BLL.Encuesta.listar(True)
            Me.gridFichas.DataSource = dsFichas
            Me.gridFichas.DataBind()

            ' btnNuevo.Visible = grd.Rows.Count > 0

            '  btnNuevo_Click(Nothing, Nothing)
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! error al listar encuestas " & ex.Message, "Home.aspx")
        End Try

    End Sub


    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("Encuesta.aspx")
    End Sub

    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
        Dim r As GridViewRow = Me.grd.Rows(e.NewSelectedIndex)
        Dim EncuestaId = grd.DataKeys(e.NewSelectedIndex).Value
        'Response.Redirect("Encuesta.aspx?id=" & EncuestaId)
        Dim enc = BLL.Encuesta.obtener(EncuestaId)
        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True


        Me.divChart.Visible = True



    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
        Dim EncuestaId = grd.DataKeys(e.RowIndex).Value
        Try
            If BLL.Encuesta.eliminar(EncuestaId) Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "Se elimino la encuesta", Nothing)
                'Dim b As New BE.Bitacora
                'b.criticidad = 2
                'b.usuario = Session("currentUser")
                'b.evento = "Se elimino encuesta " & EncuestaId
                'BLL.Bitacora.RegistarEvento(b)
                Actualizar()
            End If



        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, Nothing)
            'TryCast(Me.Master, homefix).ShowMessage(New Message(Message.MessageType.Err, "Error", ex.Message))
        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub


    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub

    Protected Sub gridFichas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridFichas.SelectedIndexChanging
        Dim r As GridViewRow = Me.gridFichas.Rows(e.NewSelectedIndex)
        Dim EncuestaId = gridFichas.DataKeys(e.NewSelectedIndex).Value

        Dim enc = BLL.Encuesta.obtener(EncuestaId)
        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = SeriesChartType.Pie
        chartEncuesta.ChartAreas(0).Area3DStyle.Enable3D = True



        Me.divChart.Visible = True



    End Sub

    Protected Sub gridFichas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gridFichas.RowDeleting
        Dim EncuestaId = gridFichas.DataKeys(e.RowIndex).Value
        Try
            If BLL.Encuesta.eliminar(EncuestaId) Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "Se elimino la encuesta", Nothing)
                'Dim b As New BE.Bitacora
                'b.criticidad = 2
                'b.usuario = Session("currentUser")
                'b.evento = "Se elimino encuesta " & EncuestaId
                'BLL.Bitacora.RegistarEvento(b)
                Actualizar()
            End If



        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, Nothing)
            'TryCast(Me.Master, homefix).ShowMessage(New Message(Message.MessageType.Err, "Error", ex.Message))
        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub


    Protected Sub gridFichas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridFichas.PageIndexChanging
        gridFichas.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub
End Class