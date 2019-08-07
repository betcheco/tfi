Public Class VerAnuncio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Request.QueryString.HasKeys Then
                Try
                    Dim anuncio As New BE.Anuncio
                    anuncio.id = Request.QueryString("anuncio")
                    anuncio = BLL.Anuncio.ObtenerAnuncio(anuncio)
                    lblTitulo.InnerText = anuncio.titulo
                    lblDescCorta.InnerText = anuncio.desc_corta
                    lblPrecio.InnerText = "$" & anuncio.precio
                    descLarga.InnerText = anuncio.desc_larga
                    img.ImageUrl = anuncio.imagen
                    If Not Session("currentUser") Is Nothing Then
                        If Session("currentUser").id <> anuncio.usuario_id Then
                            btnComentar.Visible = True
                        Else
                            btnComentar.Visible = False
                        End If
                    Else
                        btnComentar.Visible = False
                    End If



                    ''Prueba comentario
                    'Dim c As New BE.Comentario
                    'c.comentario = "prueba comentario"
                    'c.respuesta = "prueba respuesta"
                    'Dim cc As comentario = Page.LoadControl("~/UserControls/comentario.ascx")
                    'cc.asignar(c)
                    'Me.divComentarios.Controls.Add(cc)
                    ActualizarComentarios()
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Error cargando el anuncio " & ex.Message, Nothing)
                End Try
            Else
                Response.Redirect("Clasificados.aspx")
            End If
        End If
    End Sub

    Protected Sub btnEnviarComentario_Click(sender As Object, e As EventArgs) Handles btnEnviarComentario.Click
        Dim comentario As New BE.Comentario
        Try
            comentario.comentario = inputComentario.Text
            comentario.id_anuncio = Request.QueryString("anuncio")
            BLL.Comentario.Nuevo(comentario)
            ActualizarComentarios()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Hubo un problema al enviar el comentario " & ex.Message, Nothing)
        End Try

    End Sub

    Private Sub ActualizarComentarios()
        Me.divComentarios.Controls.Clear()
        Dim c As New BE.Comentario
        Dim listaComentario As New List(Of BE.Comentario)
        Try
            c.id_anuncio = Request.QueryString("anuncio")
            listaComentario = BLL.Comentario.Listar(c)
            If Not listaComentario Is Nothing Then
                For Each comment In listaComentario
                    Dim cc As comentario
                    cc = Page.LoadControl("~/UserControls/comentario.ascx")
                    cc.asignar(comment)
                    cc.ID = comment.id
                    AddHandler cc.EventoActualizar, AddressOf handlerActualizarComentarios
                    Me.divComentarios.Controls.Add(cc)
                Next
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Hubo un problema al cargar los comentarios " & ex.Message, Nothing)
        End Try

    End Sub

    Public Sub handlerActualizarComentarios(sender As Object, e As Object)
        ActualizarComentarios()
    End Sub

    Private Sub Publicacion_Init(sender As Object, e As EventArgs) Handles Me.Init
        ActualizarComentarios()
    End Sub

    Protected Sub btnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        If Session("currentUser") Is Nothing Then
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "Debe estar auntentificado para realizar la compra", Nothing)
        Else
            Response.Redirect("Comprar.aspx?anuncio=" & Request.QueryString("anuncio"))
        End If
    End Sub
End Class