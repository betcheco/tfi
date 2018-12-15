Public Class comentario
    Inherits System.Web.UI.UserControl
    Public Event EventoActualizar As EventHandler(Of Object)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub asignar(comentario As BE.Comentario)
        Dim a As New BE.Anuncio
        a.id = comentario.id_anuncio
        a = BLL.Anuncio.ObtenerAnuncio(a)
        id.Value = comentario.id
        'idModal.Value = comentario.id
        textComment.InnerText = comentario.comentario
        textRespuesta.InnerText = comentario.respuesta
        If Not Session("currentUser") Is Nothing Then
            If comentario.respuesta = "" And Session("currentUser").id = a.usuario_id Then
                btnResponder.Visible = True
            Else
                btnResponder.Visible = False
            End If
            For Each rol In Session("currentUser").roles
                For Each permiso In rol.permisos
                    If permiso.nombre = "btnEliminarComentario" Then
                        btnEliminar.Visible = True
                    End If
                Next
            Next
        Else
            btnResponder.Visible = False
        End If





    End Sub
    'Public Property comment As BE.Comentario
    '    Get
    '        Return Nothing
    '    End Get
    '    Set(value As BE.Comentario)
    '        ViewState("comment") = value
    '        ' Me.divName.InnerText = value.owner.nombre & " " & value.owner.apellido
    '        Me.textComment.InnerText = value.comentario
    '        Me.textRespuesta.InnerText = value.respuesta
    '        Me.id.Value = value.id
    '        ' Dim currentUserId = IIf(ViewState("isHelpdeskAdmin"), -1, BLL.Usuario.current.id)
    '        If value.respuesta = "" Then
    '            Me.bResponder.Visible = True
    '        Else
    '            Me.bResponder.Visible = False
    '        End If
    '        Me.btnEliminar.Visible = True
    '    End Set
    'End Property

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim c As New BE.Comentario
        Try
            c.id = id.Value
            c.activo = 0
            c.comentario = textComment.InnerText
            c.respuesta = textRespuesta.InnerText
            c.id_anuncio = Request.QueryString("anuncio")
            BLL.Comentario.Modificar(c)
            RaiseEvent EventoActualizar(sender, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnEnviarRespuesta_Click(sender As Object, e As EventArgs) Handles btnEnviarRespuesta.Click
        Dim c As New BE.Comentario
        Try
            c.id = id.Value
            c.activo = 1
            c.comentario = textComment.InnerText
            c.respuesta = inputRespuesta.Text
            c.id_anuncio = Request.QueryString("anuncio")
            BLL.Comentario.Modificar(c)
            RaiseEvent EventoActualizar(sender, "")
        Catch ex As Exception
            Throw ex

        End Try
    End Sub



    Protected Sub btnResponder_Click(sender As Object, e As EventArgs) Handles btnResponder.Click
        'Me.idModal.Value = Me.id.Value
        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "modalShow();", True)
        Me.inputRespuesta.Visible = True
        Me.btnEnviarRespuesta.Visible = True
        Me.btnResponder.Visible = False
        Me.inputRespuesta.Focus()

    End Sub
End Class