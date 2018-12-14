Public Class chatComment
    Inherits System.Web.UI.UserControl
    Public Event EventoActualizar As EventHandler(Of Object)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub asignar(chat As BE.Chat)
        Dim o As New BE.Operacion
        o.id = chat.operacion_id
        ' o = BLL.Anuncio.ObtenerAnuncio(a)
        id.Value = chat.id
        'idModal.Value = comentario.id
        textComment.InnerText = chat.pregunta
        textRespuesta.InnerText = chat.respuesta
        If chat.respuesta = "" And Session("chatAdmin") Then
            btnResponder.Visible = True
        Else
            btnResponder.Visible = False
        End If
    End Sub


    Protected Sub btnEnviarRespuesta_Click(sender As Object, e As EventArgs) Handles btnEnviarRespuesta.Click
        Dim c As New BE.Chat
        Try
            If Session("respuesta") Then
                If BLL.Chat.Responder(id.Value, inputRespuesta.Text) Then
                    BLL.Operacion.setMsj(Request.QueryString("operacion"), False)
                    Session.Remove("respuesta")
                    Dim b As New BE.Bitacora
                    b.criticidad = 1
                    b.evento = "Respuesta de chat id:" & id.Value
                    b.usuario = Request.QueryString("operacion")
                    BLL.Bitacora.RegistarEvento(b)
                End If
            Else
                ' c.id = id.Value
                'c.activo = 1
                c.pregunta = textComment.InnerText
                '  c.respuesta = inputRespuesta.Text
                c.operacion_id = Request.QueryString("operacion")
                'BLL.Comentario.Modificar(c)
                If BLL.Chat.Nuevo(c) Then
                    BLL.Operacion.setMsj(Request.QueryString("operacion"), True)
                    Dim b As New BE.Bitacora
                    b.criticidad = 1
                    b.evento = "nuevo de chat id:" & id.Value
                    b.usuario = Request.QueryString("operacion")
                    BLL.Bitacora.RegistarEvento(b)
                End If
            End If

            RaiseEvent EventoActualizar(sender, "")
        Catch ex As Exception
            Throw ex

        End Try
    End Sub



    Protected Sub btnResponder_Click(sender As Object, e As EventArgs) Handles btnResponder.Click
        'Me.idModal.Value = Me.id.Value
        'ScriptManager.RegisterStartupScript(Me, Me.GetType, System.Guid.NewGuid().ToString(), "modalShow();", True)
        Session("respuesta") = True
        Me.inputRespuesta.Visible = True
        Me.btnEnviarRespuesta.Visible = True
        Me.btnResponder.Visible = False
        Me.inputRespuesta.Focus()

    End Sub
End Class