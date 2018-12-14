
Imports System.Web.UI.DataVisualization.Charting

Public Class Findecompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
        End If
    End Sub

    Private Sub Actualizar()
        If Not Request.QueryString("anuncio") Is Nothing Then
            setEncuesta()
        Else
            Response.Redirect("Clasificados.aspx")
        End If
    End Sub

    Private Sub setEncuesta()
        Dim e = BLL.Encuesta.getRandom(True)
        If Not e Is Nothing Then
            ViewState("encuestaId") = e.id
            Me.encuestaText.InnerHtml = e.nombre
            rptEncuestaOpciones.DataSource = e.opciones
            rptEncuestaOpciones.DataBind()
        End If
    End Sub

    Protected Sub rptEncuestaOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptEncuestaOpciones.ItemCommand
        BLL.Encuesta.votar(CInt(e.CommandArgument))

        Dim enc = BLL.Encuesta.obtener(ViewState("encuestaId"))
        Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
        chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
        chartEncuesta.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie

        divEncuestaChart.Visible = True
        divEncuestaPreguntas.Visible = False
    End Sub
End Class