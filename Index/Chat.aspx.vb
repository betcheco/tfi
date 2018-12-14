Public Class Chat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("operacion") Is Nothing Then
            Response.Redirect("Home.aspx")
        Else
            If Session("currentUser") Is Nothing Then
                Response.Redirect("Home.aspx")
            Else
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "chatAdmin") Then
                    divInput.Visible = False
                End If
                ActualizarChats()
            End If

        End If

    End Sub

    Private Sub ActualizarChats()
        Me.divMensajes.Controls.Clear()
        Dim c As New BE.Chat
        Dim listaChat As New List(Of BE.Chat)
        Try

            listaChat = BLL.Chat.Listar(Request.QueryString("operacion"))
            If Not listaChat Is Nothing Then
                For Each comment In listaChat
                    Dim cc As chatComment
                    cc = Page.LoadControl("~/UserControls/chatComment.ascx")
                    cc.asignar(comment)
                    cc.ID = comment.id
                    AddHandler cc.EventoActualizar, AddressOf handlerActualizarComentarios
                    Me.divMensajes.Controls.Add(cc)
                Next
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Hubo un problema al cargar los comentarios " & ex.Message, Nothing)
        End Try
    End Sub

    Private Sub handlerActualizarComentarios(sender As Object, e As Object)
        ActualizarChats()
    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim chat As New BE.Chat
        Try
            chat.pregunta = Me.txtInput.Text
            chat.operacion_id = Request.QueryString("operacion")
            BLL.Chat.Nuevo(chat)
            Me.txtInput.Text = ""
            ActualizarChats()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Hubo un problema al enviar el chat " & ex.Message, Nothing)
        End Try
    End Sub
End Class