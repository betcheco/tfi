Public Class NewNoticia
    Inherits System.Web.UI.Page
    Dim path As String = Server.MapPath("./img/noticia/")
    Dim bitacora As New BE.Bitacora
    Dim listCategorias As New List(Of BE.Categoria)
    Dim noticia As New BE.Noticia
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Try
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnABMNoticasSideBar") Then
                    cargarCategorias()
                    If Request.QueryString.HasKeys Then
                        Session("modificarNoticia") = True
                        titulo.InnerText = "Modificar Noticia"
                        noticia.id = Request.QueryString("noticia")
                        noticia = BLL.Noticia.ObtenerNoticia(noticia)
                        inputTitulo.Value = noticia.titulo
                        inputDescCorta.Value = noticia.desc_corta
                        inputDescLarga.Value = noticia.desc_larga
                        fhasta.Text = noticia.fecha_hasta
                        Text1.Text = noticia.fecha_desde
                        img.ImageUrl = noticia.imagen
                        ddCategoria.SelectedValue = BLL.Categoria.obtenerCategoria(noticia.id_categoria).nombre
                        Session("modNoticia") = noticia
                    Else
                        Session("modificarNoticia") = False
                    End If
                Else
                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                    End If




            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
            End Try
        End If
    End Sub

    Private Sub cargarCategorias()
        Try
            listCategorias = BLL.Categoria.Listar
            Session("listaCategorias") = listCategorias
            Dim lista As New List(Of String)
            For Each cat In listCategorias
                lista.Add(cat.nombre)
            Next
            ddCategoria.DataSource = lista
            ddCategoria.DataBind()
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

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click
        If Session("modificarNoticia") Then

            noticia = Session("modNoticia")
            noticia.titulo = inputTitulo.Value
            noticia.desc_corta = inputDescCorta.Value
            noticia.desc_larga = inputDescLarga.Value
            noticia.fecha_desde = CDate(Text1.Text)
            noticia.fecha_hasta = CDate(fhasta.Text)
            noticia.id_categoria = idCategoria(ddCategoria.SelectedValue)
            If imgUpload.HasFile Then
                imgUpload.PostedFile.SaveAs(path &
                imgUpload.FileName)
                noticia.imagen = "img/noticia/" + imgUpload.PostedFile.FileName
            End If
            Try
                If BLL.Noticia.Modificar(noticia) Then
                    bitacora.criticidad = 2
                    bitacora.evento = "Se modifico la noticia " & noticia.titulo
                    bitacora.usuario = "User"
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Noticia modificada con exito", "La noticia fue modificada exitosamente", "ABMNoticias.aspx")
                End If
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
            End Try
        Else
            If imgUpload.HasFile Then
                imgUpload.PostedFile.SaveAs(path &
                 imgUpload.FileName)
                noticia.imagen = "img/noticia/" + imgUpload.PostedFile.FileName
                noticia.titulo = inputTitulo.Value
                noticia.desc_corta = inputDescCorta.Value
                noticia.desc_larga = inputDescLarga.Value
                noticia.fecha_desde = CDate(Text1.Text)
                noticia.fecha_hasta = CDate(fhasta.Text)
                noticia.id_categoria = idCategoria(ddCategoria.SelectedValue)
                Try
                    If BLL.Noticia.Alta(noticia) Then
                        bitacora.criticidad = 2
                        bitacora.evento = "Se creo la noticia " & noticia.titulo
                        bitacora.usuario = "User"
                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Noticia fue creada con exito", "La noticia fue creada exitosamente", "ABMNoticias.aspx")
                        Dim listaNews As New List(Of BE.Newsletter)
                        listaNews = BLL.Newsletter.listar(noticia.id_categoria)
                        For Each n In listaNews
                            Helpers.sendMail.enviarNewsletter(noticia.titulo, noticia.desc_corta, noticia.id, "http://localhost:49915/" & noticia.imagen, n.email)
                        Next

                    End If

                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
                End Try
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe seleccionar una imagen para la noticia", Nothing)
            End If
        End If
    End Sub
End Class