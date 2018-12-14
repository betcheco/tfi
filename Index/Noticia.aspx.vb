Public Class Noticia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Request.QueryString.HasKeys Then
                Try
                    Dim noticia As New BE.Noticia
                    noticia.id = Request.QueryString("noticia")
                    noticia = BLL.Noticia.ObtenerNoticia(noticia)
                    Me.img.ImageUrl = noticia.imagen
                    Me.lblNombre.Text = noticia.titulo
                    Me.lblDetails.Text = noticia.desc_larga

                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Noticias.aspx")
                End Try
            Else
                Response.Redirect("Noticias.aspx")
            End If
        End If
    End Sub

End Class