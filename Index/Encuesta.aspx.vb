Imports System.Web.UI.DataVisualization.Charting

Public Class Encuesta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnABMEncuestasSideBar") Then

                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
            End If

            'If Not Request.QueryString("id") Is Nothing Then
            '    Session("modEncuesta") = True
            '    Cargar()
            'Else
            '    Session("modEncuesta") = False
            'End If
        End If
    End Sub

    Private Sub Cargar()
        Try
            Dim enc = BLL.Encuesta.obtener(Request.QueryString("id"))
            Dim Dvista As New System.Data.DataView(Helpers.Charts.ToDataTable(Of BE.EncuestaOpcion)(enc.opciones))
            chartEncuesta.Series(0).Points.DataBindXY(Dvista, "nombre", Dvista, "valor")
            chartEncuesta.Series(0).ChartType = SeriesChartType.Pie

            Me.txtDescription.Text = enc.nombre
            Me.inputVencimiento.Text = enc.vencimiento
            If Session("fo") Then
                Me.chkFOpinion.Checked = True
                Me.chkFOpinion.Enabled = False
            Else
                Me.chkFOpinion.Checked = False
                Me.chkFOpinion.Enabled = False
            End If

            Dim opcionesList As New List(Of String)
            For Each o In BLL.Encuesta.listarOpciones(enc.id)
                opcionesList.Add(o.nombre)
            Next
            If Not ViewState("opcionesList") Is Nothing Then
                opcionesList = ViewState("opcionesList")
            End If

            rptOpciones.DataSource = opcionesList
            rptOpciones.DataBind()


            Me.divBtnGuardar.Visible = True
            Me.divChart.Visible = True
            Me.divContOpciones.Visible = True
            Me.divCampos.Visible = True
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "ups! " & ex.Message, "ABMEncuestas.aspx")
        End Try
    End Sub

    Protected Sub addOpcion_Click(sender As Object, e As EventArgs) Handles addOpcion.Click
        Try
            If Me.txtOpcion.Text <> "" Then
                Dim opcionesList As New List(Of String)
                If Not ViewState("opcionesList") Is Nothing Then
                    opcionesList = ViewState("opcionesList")
                End If
                opcionesList.Add(Me.txtOpcion.Text)
                ViewState("opcionesList") = opcionesList
                rptOpciones.DataSource = opcionesList
                rptOpciones.DataBind()

                Me.txtOpcion.Text = ""
                Me.divAddOpcion.Visible = False

            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.divAddOpcion.Visible = True
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New BE.Encuesta

        Dim opcionesList As New List(Of String)
        If Not ViewState("opcionesList") Is Nothing Then
            opcionesList = ViewState("opcionesList")
        End If

        If opcionesList.Count < 2 Then
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debes ingresar al menos dos opciones para la encuesta", Nothing)
            Return
        End If

        If Me.inputVencimiento.Text = "" Or CDate(Me.inputVencimiento.Text) < Date.Now Then
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe ingresar una fecha de vencimiento válida", Nothing)
            Return
        End If

        obj.nombre = txtDescription.Text

        obj.vencimiento = inputVencimiento.Text

        For Each o In opcionesList
            Dim eo As New BE.EncuestaOpcion
            eo.nombre = o
            eo.valor = 0
            obj.opciones.Add(eo)
        Next

        'If Session("modEncuesta") Then
        '    BLL.Encuesta.modificar(obj)
        'Else
        BLL.Encuesta.nuevo(obj, Me.chkFOpinion.Checked)
        'End If


        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "Se creo la nueva encuesta", "ABMEncuestas.aspx")
        'Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub rptOpciones_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptOpciones.ItemCommand
        If e.CommandName = "Remove" Then
            Dim opcionesList As New List(Of String)
            If Not ViewState("opcionesList") Is Nothing Then
                opcionesList = ViewState("opcionesList")
            End If
            opcionesList.RemoveAt(CInt(e.CommandArgument))
            ViewState("opcionesList") = opcionesList
            rptOpciones.DataSource = opcionesList
            rptOpciones.DataBind()
        End If
    End Sub

    Protected Sub btnCancelOpcion_Click(sender As Object, e As EventArgs) Handles btnCancelOpcion.Click
        Me.txtOpcion.Text = ""
        Me.divAddOpcion.Visible = False
    End Sub
End Class