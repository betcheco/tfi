Public Class MisPublicaciones
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnMisPublicacionesSideBar") Then
                    actualizar()
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
                'TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If

            End If
    End Sub

    Protected Sub btnPublicar_Click(sender As Object, e As EventArgs) Handles btnPublicar.Click
        Response.Redirect("PublicarAnuncio.aspx")
    End Sub

    Protected Sub gridAnuncios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gridAnuncios.RowDeleting
        Try
            Dim anuncio As New BE.Anuncio
            anuncio.id = gridAnuncios.Rows(e.RowIndex).Cells(0).Text
            'MsgBox(anuncio.id)
            anuncio = BLL.Anuncio.ObtenerAnuncio(anuncio)
            anuncio.activo = 0
            If BLL.Anuncio.Modificar(anuncio) Then
                bitacora.criticidad = 3
                bitacora.evento = "Delete anuncio " & anuncio.titulo
                bitacora.usuario = Session("currentUser").email
                BLL.Bitacora.RegistarEvento(bitacora)
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Anuncio eleminado", "El anuncio fue eliminado", Nothing)
                actualizar()
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error al querer emilinar el anuncio " & ex.Message, Nothing)
        End Try
    End Sub

    Function lookAnuncio(id As Integer) As BE.Anuncio
        Try
            Dim result As BE.Anuncio
            For Each anuncio In gridAnuncios.DataSource
                If id = anuncio.id Then
                    result = anuncio
                End If
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Protected Sub gridAnuncios_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles gridAnuncios.SelectedIndexChanging
        Response.Redirect("PublicarAnuncio.aspx?anuncio=" & gridAnuncios.Rows(e.NewSelectedIndex).Cells(0).Text)
    End Sub

    Sub actualizar()
        Try
            Dim a As New BE.Anuncio
            a.usuario_id = Session("currentUser").id
            Dim lista As New List(Of BE.Anuncio)
            lista = BLL.Anuncio.Listar(a)
            If lista.Count > 0 Then
                mensaje.Visible = False
                gridAnuncios.DataSource = lista
                gridAnuncios.DataBind()
            Else
                mensaje.InnerText = "No tenes ningun anuncio publicado, apurate y publica uno!"
                mensaje.Visible = True
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Home.aspx")
        End Try

    End Sub
End Class