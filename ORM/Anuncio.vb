Public Class Anuncio
    Shared Function Listar(pAnuncio As BE.Anuncio) As List(Of BE.Anuncio)
        Try
            Dim d As New DAL.Datos
            Dim listaAnuncios As New List(Of BE.Anuncio)
            Dim sp As String
            Dim h As New Hashtable

            If Not pAnuncio Is Nothing Then
                sp = "sp_get_anuncio_by_usuario"
                h.Add("Usuario_id", pAnuncio.usuario_id)
            Else
                sp = "sp_listar_anuncios"
                h = Nothing
            End If

            Dim ds = d.Leer(sp, h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim oAnuncio As New BE.Anuncio
                    oAnuncio.id = row("id")
                    oAnuncio.titulo = row("titulo")
                    oAnuncio.desc_corta = row("descripcion_corta")
                    oAnuncio.desc_larga = row("descripcion_larga")
                    oAnuncio.activo = row("activo")
                    oAnuncio.categoria = row("categoria")
                    oAnuncio.imagen = row("imagen")
                    oAnuncio.precio = row("precio")
                    oAnuncio.usuario_id = row("usuario_id")

                    listaAnuncios.Add(oAnuncio)
                Next
            End If

            Return listaAnuncios
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Shared Function Modificar(pAnuncio As BE.Anuncio) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Id", pAnuncio.id)
            h.Add("Titulo", pAnuncio.titulo)
            h.Add("DescCorta", pAnuncio.desc_corta)
            h.Add("DescLarga", pAnuncio.desc_larga)
            h.Add("Activo", pAnuncio.activo)
            h.Add("Categoria", pAnuncio.categoria)
            h.Add("Imagen", pAnuncio.imagen)
            h.Add("Precio", pAnuncio.precio.ToString)
            'h.Add("Usuario_id", pAnuncio.usuario_id)

            Return d.Escribir("sp_mod_anuncio", h)


        Catch ex As Exception
            Throw ex


        End Try
    End Function



    Shared Function Crear(pAnuncio As BE.Anuncio) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Titulo", pAnuncio.titulo)
            h.Add("DescCorta", pAnuncio.desc_corta)
            h.Add("DescLarga", pAnuncio.desc_larga)
            h.Add("Categoria", pAnuncio.categoria)
            h.Add("Imagen", pAnuncio.imagen)
            h.Add("Precio", pAnuncio.precio.ToString)
            h.Add("Usuario_id", pAnuncio.usuario_id)

            Return d.Escribir("sp_alta_anuncio", h)


        Catch ex As Exception
            Throw ex


        End Try
    End Function


    Shared Function obtenerAnuncio(pAnuncio As BE.Anuncio) As BE.Anuncio
        Dim sp As String
        Dim h As New Hashtable
        Dim oAnuncio As New BE.Anuncio
        Try


            sp = "sp_get_anuncio"
            h.Add("Id", pAnuncio.id)

            Dim d As New DAL.Datos
            Dim listaAnuncios As New List(Of BE.Anuncio)
            Dim ds = d.Leer(sp, h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows

                    oAnuncio.id = row("id")
                    oAnuncio.titulo = row("titulo")
                    oAnuncio.desc_corta = row("descripcion_corta")
                    oAnuncio.desc_larga = row("descripcion_larga")
                    oAnuncio.activo = row("activo")
                    oAnuncio.categoria = row("categoria")
                    oAnuncio.imagen = row("imagen")
                    oAnuncio.precio = row("precio")
                    oAnuncio.usuario_id = row("usuario_id")


                Next
            End If

            Return oAnuncio
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Shared Function Filtrar(pCat As BE.Categoria, pMin As Double, pMax As Double) As List(Of BE.Anuncio)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Anuncio)
        Try
            If Not pCat.nombre Is Nothing Then
                h.Add("@Categoria_id", pCat.id)
            End If
            If Not pMin = 0 Then
                h.Add("@Min", pMin)
            End If
            If Not pMax = 0 Then
                h.Add("@Max", pMax)
            End If


            Dim ds = d.Leer("sp_filtrar_anuncio", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim oAnuncio As New BE.Anuncio
                    oAnuncio.id = row("id")
                    oAnuncio.titulo = row("titulo")
                    oAnuncio.desc_corta = row("descripcion_corta")
                    oAnuncio.desc_larga = row("descripcion_larga")
                    oAnuncio.activo = row("activo")
                    oAnuncio.categoria = row("categoria")
                    oAnuncio.imagen = row("imagen")
                    oAnuncio.precio = row("precio")
                    oAnuncio.usuario_id = row("usuario_id")

                    lista.Add(oAnuncio)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
