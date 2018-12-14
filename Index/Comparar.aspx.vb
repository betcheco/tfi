Public Class Comparar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("listaComparacion") Is Nothing Then
                cargar()
            Else
                Response.Redirect("Clasificados.aspx")
            End If
        End If


    End Sub


    Sub cargar()
        Dim lista As New List(Of BE.Anuncio)
        Dim listaInt As New List(Of Integer)
        Try
            listaInt = Session("listaComparacion")
            For Each i In listaInt
                Dim a As New BE.Anuncio
                a.id = i
                a = BLL.Anuncio.ObtenerAnuncio(a)
                lista.Add(a)
            Next
            rpt1.DataSource = lista
            rpt1.DataBind()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! error al cargar la lista para comparar " & ex.Message, "Clasificados.aspx")
        End Try
    End Sub



    Protected Sub btnVer_Command(sender As Object, e As CommandEventArgs)
        If e.CommandName = "ver" Then
            Response.Redirect("VerAnuncio.aspx?anuncio=" & e.CommandArgument)
        End If
    End Sub
End Class