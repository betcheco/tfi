Public Class Clasificados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'hidePublicUser()
        If Not (Page.IsPostBack) Then
            'If Not Session("currentUser") Is Nothing Then
            Try
                    Dim listCat As New List(Of BE.Categoria)
                    Dim c As New BE.Categoria
                    c.id = 0
                    c.nombre = ""
                    listCat.Add(c)
                    For Each cat In BLL.Categoria.Listar()
                        listCat.Add(cat)
                    Next
                    ViewState("listaCat") = listCat
                    'For Each cat In ViewState("listaCat")
                    '    listNomCat.Add(cat.nombre)
                    'Next
                    ddlCategoria.DataSource = listCat
                    ddlCategoria.DataBind()
                    Dim listadoAnuncios = BLL.Anuncio.Listar(Nothing)
                    Me.rpt1.DataSource = listadoAnuncios
                    Me.rpt1.DataBind()
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Home.aspx")
                End Try

            '    End If

        End If
    End Sub



    Public Sub ValidarCommand(sender As Object, e As CommandEventArgs)
        If (e.CommandName = "AddCart") Then
            'e.CommandArgument
            'MsgBox("Precio" + e.CommandArgument.ToString)

            Response.Redirect("Comprar.aspx?anuncio=" & e.CommandArgument.ToString)
        End If
        If (e.CommandName = "CheckProduct") Then
            'btnComparar.Visible = True
            MsgBox("Comparar " & e.CommandArgument.ToString)
            MsgBox(sender.ToString())



        End If
        If (e.CommandName = "ShowProduct") Then
            'MsgBox(e.CommandArgument.ToString)
            Response.Redirect("VerAnuncio.aspx?anuncio=" & e.CommandArgument.ToString)
        End If
    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Dim precioMin As Double
        Dim precioMax As Double
        Dim listaCat As New List(Of BE.Categoria)
        Dim cat As New BE.Categoria
        Try
            If Not ddlCategoria.SelectedValue = 0 Then
                listaCat = ViewState("listaCat")

                For Each categoria In listaCat
                    If categoria.id = ddlCategoria.SelectedValue Then
                        cat = categoria
                    End If
                Next
            Else
                If IsNumeric(txtPrecioDesde.Text) Then
                    precioMin = CDbl(txtPrecioDesde.Text)
                End If
                If IsNumeric(txtPrecioHasta.Text) Then
                    precioMax = CDbl(txtPrecioHasta.Text)
                End If




            End If



            If ddlCategoria.SelectedValue <> 0 Or IsNumeric(txtPrecioDesde.Text) Or IsNumeric(txtPrecioHasta.Text) Then
                Dim listaAnuncios As List(Of BE.Anuncio)
                listaAnuncios = BLL.Anuncio.Filtrar(cat, precioMin, precioMax)
                Me.rpt1.DataSource = listaAnuncios
                Me.rpt1.DataBind()
            End If




        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try
    End Sub

    Protected Sub btnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        Dim cont = checks()

        If cont > 1 Then
            If cont <= 3 Then
                Response.Redirect("Comparar.aspx")
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Puede seleccionar como maximo 3 anuncios para comparar", Nothing)
            End If

        Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe seleccionar por lo menos dos anuncios para comparar", Nothing)
            End If

    End Sub

    Function checks() As Integer
        Dim cantCheck As Integer = 0
        Dim listaComparacion As New List(Of Integer)
        For Each item As RepeaterItem In rpt1.Items
            Dim chk As HtmlInputCheckBox = CType(item.FindControl("chkCompare"), HtmlInputCheckBox)
            If chk.Checked Then
                Dim label As Label
                label = item.FindControl("idAnuncio")
                listaComparacion.Add(CInt(label.Text))
                cantCheck += 1
            End If


        Next
        Session("listaComparacion") = listaComparacion
        Return cantCheck
    End Function

End Class