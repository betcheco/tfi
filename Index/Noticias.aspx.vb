Public Class Noticias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            ActulizarNoticias()


        End If
    End Sub

    Sub ActulizarNoticias()
        'Dim n As New BE.Noticia
        Try
            Dim noticas As New List(Of BE.Noticia)

            noticas = BLL.Noticia.ListarByFecha(Nothing)
            rpt1.DataSource = noticas
            rpt1.DataBind()

            cargarCategorias()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! Sucedio un error al cargar las noticias " & ex.Message, Nothing)
        End Try

    End Sub

    Public Sub ValidarCommand(sender As Object, e As CommandEventArgs)


        If (e.CommandName = "ShowNoticia") Then

            'Session("NotiShow") = (e.CommandArgument.ToString)
            Response.Redirect("Noticia.Aspx?noticia=0" & e.CommandArgument.ToString)


        End If
    End Sub

    Protected Sub btnSubscribir_Click(sender As Object, e As EventArgs) Handles btnSubscribir.Click
        Dim listaCategoriasChk As New List(Of Integer)
        listaCategoriasChk = categoriasChecked()

        If txtEmail.Text.Length > 0 And listaCategoriasChk.Count > 0 Then
            Try
                Dim news As New BE.Newsletter
                news.email = txtEmail.Text
                For Each i In listaCategoriasChk
                    Dim c As New BE.Categoria
                    c.id = i
                    news.categorias.Add(c)
                Next

                If BLL.Newsletter.subscripcion(news) Then
                    Dim bitacora As New BE.Bitacora
                    bitacora.evento = "Subscripcion al newsletter del mail " & news.email
                    bitacora.criticidad = 1
                    bitacora.usuario = "Invitado"
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Felicitaciones", "Muchas gracias por subscribirse", "Noticias.aspx")
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Por favor vuelva a intentarlo mas tarde", Nothing)
                End If


            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "UPs! " & ex.Message, Nothing)
            End Try
        End If
    End Sub

    Function categoriasChecked() As List(Of Integer)
        Dim lista As New List(Of Integer)
        For Each item In chkListCategorias.Items
            If item.Selected Then
                lista.Add(idCategoria(item.Text.Trim))
            End If

        Next
        Return lista
    End Function

    Private Sub cargarCategorias()
        Dim listCategorias As New List(Of BE.Categoria)
        Try
            listCategorias = BLL.Categoria.Listar
            Session("listaCategorias") = listCategorias
            Dim lista As New List(Of String)
            For Each cat In listCategorias
                lista.Add(cat.nombre)
            Next
            chkListCategorias.DataSource = lista
            chkListCategorias.DataBind()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Function idCategoria(categoria As String) As Integer
        Dim id As Integer

        Try
            For Each cat In Session("listaCategorias")
                If categoria.Trim = cat.nombre.Trim Then
                    id = cat.id
                End If
            Next
            Return id

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class