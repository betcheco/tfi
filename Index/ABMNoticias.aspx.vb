Public Class ABMNoticias
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnABMNoticasSideBar") Then
                ActualizarNoticias()
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("NewNoticia.aspx")
    End Sub

    Sub ActualizarNoticias()
        Try
            Dim listaN As New List(Of BE.Noticia)
            listaN = BLL.Noticia.Listar(Nothing)
            grdNoticias.DataSource = listaN
            grdNoticias.DataBind()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Error al listar las noticias " & ex.Message, Nothing)
        End Try

    End Sub

    Protected Sub grdNoticias_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdNoticias.SelectedIndexChanging

        Response.Redirect("NewNoticia.aspx?noticia=" & Me.grdNoticias.Rows(e.NewSelectedIndex).Cells(0).Text)
    End Sub

    Protected Sub grdNoticias_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdNoticias.RowDeleting
        Dim noti As New BE.Noticia
        Try
            noti.id = grdNoticias.Rows(e.RowIndex).Cells(0).Text
            If BLL.Noticia.Eliminar(noti) Then
                bitacora.evento = "Se elimino la noticia " & noti.id
                bitacora.usuario = Session("currentUser").email
                'bitacora.usuario = "user"
                bitacora.criticidad = 3
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Noticia eliminada con exito0", "La noticia fue eliminada con exito", Nothing)
                ActualizarNoticias()
            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "error al eliminar noticia " & ex.Message, Nothing)
        End Try

    End Sub
End Class