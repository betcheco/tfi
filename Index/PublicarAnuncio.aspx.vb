Imports System.Drawing
Imports ImageResizer

Public Class PublicarAnuncio
    Inherits System.Web.UI.Page
    'Dim path As String = Server.MapPath("~/backups/")
    Dim path As String = Server.MapPath("./img/")
    Dim bitacora As New BE.Bitacora
    Dim anuncio As New BE.Anuncio
    Dim modAnuncio As BE.Anuncio
    Dim listCategorias As New List(Of BE.Categoria)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Try
                If Not Session("currentUser") Is Nothing Then
                    cargarCategorias()
                    If Request.QueryString.HasKeys Then
                        modAnuncio = New BE.Anuncio
                        Session("modficarAnuncio") = True
                        titulo.InnerText = "Modificar Anuncio"
                        modAnuncio.id = Request.QueryString("anuncio")
                        modAnuncio = BLL.Anuncio.ObtenerAnuncio(modAnuncio)
                        If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnABMPublicacionesSideBar") Or Session("currentUser").id = modAnuncio.usuario_id Then
                            inputTitulo.Value = modAnuncio.titulo
                            inputDescCorta.Value = modAnuncio.desc_corta
                            inputDescLarga.Value = modAnuncio.desc_larga
                            inputPrecio.Value = modAnuncio.precio
                            ddCategoria.SelectedValue = BLL.Categoria.obtenerCategoria(modAnuncio.categoria).nombre
                            img.ImageUrl = modAnuncio.imagen
                            Session("modAnuncio") = modAnuncio
                        Else
                            'If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnMisPublicacionesSideBar") And Session("currentUser").id = modAnuncio.usuario_id Then
                            '    inputTitulo.Value = modAnuncio.titulo
                            '    inputDescCorta.Value = modAnuncio.desc_corta
                            '    inputDescLarga.Value = modAnuncio.desc_larga
                            '    inputPrecio.Value = modAnuncio.precio
                            '    ddCategoria.SelectedValue = BLL.Categoria.obtenerCategoria(modAnuncio.categoria).nombre
                            '    img.ImageUrl = modAnuncio.imagen
                            '    Session("modAnuncio") = modAnuncio
                            'Else
                            Response.Redirect("Home.aspx")
                        End If
                    Else
                        Session("modficarAnuncio") = False
                    End If

                Else
                    Session("modficarAnuncio") = False
                    Response.Redirect("Home.aspx")
                    'TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "Debe auntenticarse para acceder", "Home.aspx")
                End If
                'TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "Debe auntenticarse para acceder", "Home.aspx")
                'End If
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", ex.Message, Nothing)
            End Try

        End If
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As EventArgs) Handles btnCrear.Click

        If inputTitulo.Value <> "" Then
            If inputDescCorta.Value <> "" Then
                If inputDescLarga.Value <> "" Then
                    If inputPrecio.Value <> "" Then
                        If Not Session("modficarAnuncio") Then
                            If imgUpload.HasFile Then
                                Try
                                    'Redimensionamiento de imagen
                                    Dim bmp As New Bitmap(imgUpload.PostedFile.InputStream)
                                    Dim newImage = New Bitmap(200, 200)
                                    Using g = Graphics.FromImage(newImage)
                                        g.DrawImage(bmp, 0, 0, 200, 200)
                                    End Using
                                    newImage.Save(path & imgUpload.FileName)
                                    '                   imgUpload.PostedFile.SaveAs(path &
                                    'imgUpload.FileName)
                                    anuncio.titulo = inputTitulo.Value
                                    anuncio.desc_corta = inputDescCorta.Value
                                    anuncio.desc_larga = inputDescLarga.Value
                                    anuncio.precio = inputPrecio.Value
                                    anuncio.imagen = "img/" + imgUpload.PostedFile.FileName
                                    anuncio.categoria = idCategoria(ddCategoria.SelectedValue)
                                    anuncio.usuario_id = Session("currentUser").id
                                    If BLL.Anuncio.Crear(anuncio) Then
                                        bitacora.criticidad = 3
                                        bitacora.evento = "Se creo el anuncio " & anuncio.titulo
                                        bitacora.usuario = Session("currentUser").email
                                        BLL.Bitacora.RegistarEvento(bitacora)
                                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Anuncio publicado con exito", "Su anuncio ya se encuentra publicado", "MisPublicaciones.aspx")
                                        'Response.Redirect("Home.aspx")
                                    End If
                                Catch ex As Exception
                                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", ex.Message, Nothing)
                                    bitacora.criticidad = 3
                                    bitacora.evento = "Sucedio un error al guardar el anuncio " & anuncio.titulo & "error " & ex.Message
                                    bitacora.usuario = Session("currentUser").email
                                    BLL.Bitacora.RegistarEvento(bitacora)
                                End Try
                            Else
                                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe seleccionar una imagen para el anuncio", Nothing)
                            End If
                        Else
                            Try
                                modAnuncio = Session("modAnuncio")
                                If imgUpload.HasFile Then
                                    imgUpload.PostedFile.SaveAs(path &
                                   imgUpload.FileName)
                                    modAnuncio.imagen = "img/" + imgUpload.PostedFile.FileName
                                End If

                                modAnuncio.titulo = inputTitulo.Value
                                modAnuncio.desc_corta = inputDescCorta.Value
                                modAnuncio.desc_larga = inputDescLarga.Value
                                modAnuncio.precio = inputPrecio.Value
                                modAnuncio.categoria = idCategoria(ddCategoria.SelectedValue)
                                'modAnuncio.usuario_id = modAnuncio.usuario_id
                                If BLL.Anuncio.Modificar(modAnuncio) Then
                                    bitacora.criticidad = 3
                                    bitacora.evento = "Se Modifico el anuncio " & modAnuncio.titulo
                                    bitacora.usuario = Session("currentUser").email
                                    BLL.Bitacora.RegistarEvento(bitacora)
                                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Modificacion anuncio", "Su anuncio se modifico con exito", "MisPublicaciones.aspx")
                                End If
                            Catch ex As Exception
                                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", ex.Message, Nothing)
                                bitacora.criticidad = 3
                                bitacora.evento = "Sucedio un error al guardar el anuncio " & modAnuncio.titulo & "error " & ex.Message
                                bitacora.usuario = Session("currentUser").email
                                BLL.Bitacora.RegistarEvento(bitacora)
                            End Try



                        End If




                    Else
                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe completar un precio para el anuncio", Nothing)
                    End If
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe completar una descripcion larga para el anuncio", Nothing)
                End If
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe completar una descripcion corta para el anuncio", Nothing)
            End If
        Else
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Debe completar un titulo para el anuncio", Nothing)
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




End Class