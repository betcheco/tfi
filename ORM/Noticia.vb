Public Class Noticia
    Shared Function Listar(pNoticia As BE.Noticia) As List(Of BE.Noticia)
        Dim d As New DAL.Datos
        Dim lista As New List(Of BE.Noticia)
        Dim sp As String
        Dim ds As New DataSet
        Try
            If pNoticia Is Nothing Then
                ds = d.Leer("sp_listar_noticias", Nothing)
            Else

                Dim h As New Hashtable
                    h.Add("Categoria_id", pNoticia.id_categoria)
                    ds = d.Leer("sp_listar_noticias_by_categoria", h)


            End If

            If ds.Tables(0).Rows.Count > 0 Then
                    For Each row In ds.Tables(0).Rows
                        Dim n As New BE.Noticia
                        n.id = row("id")
                        n.titulo = row("titulo")
                        n.desc_corta = row("desc_corta")
                        n.desc_larga = row("desc_larga")
                        n.fecha_desde = row("fecha_desde")
                        n.fecha_hasta = row("fecha_hasta")
                    n.id_categoria = row("id_categoria")
                    n.imagen = row("imagen")

                    lista.Add(n)

                    Next
                End If

                Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Shared Function ListarByFecha(pNoticia As BE.Noticia) As List(Of BE.Noticia)
        Dim d As New DAL.Datos
        Dim lista As New List(Of BE.Noticia)
        Dim sp As String
        Dim ds As New DataSet
        Try
            If pNoticia Is Nothing Then
                ds = d.Leer("sp_listar_noticias_by_fecha", Nothing)
            Else

                Dim h As New Hashtable
                h.Add("Categoria_id", pNoticia.id_categoria)
                ds = d.Leer("sp_listar_noticias_by_fecha_and_categoria", h)


            End If

            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim n As New BE.Noticia
                    n.id = row("id")
                    n.titulo = row("titulo")
                    n.desc_corta = row("desc_corta")
                    n.desc_larga = row("desc_larga")
                    n.fecha_desde = row("fecha_desde")
                    n.fecha_hasta = row("fecha_hasta")
                    n.id_categoria = row("id_categoria")
                    n.imagen = row("imagen")

                    lista.Add(n)

                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Alta(pNoticia As BE.Noticia) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            'h.Add("Id", pNoticia.id)
            h.Add("Titulo", pNoticia.titulo)
            h.Add("Desc_corta", pNoticia.desc_corta)
            h.Add("Desc_larga", pNoticia.desc_larga)
            h.Add("Fecha_desde", pNoticia.fecha_desde)
            h.Add("Fecha_hasta", pNoticia.fecha_hasta)
            h.Add("Id_categoria", pNoticia.id_categoria)
            h.Add("Imagen", pNoticia.imagen)

            Return d.Escribir("sp_alta_noticia", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Modificar(pNoticia As BE.Noticia) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Id", pNoticia.id)
            h.Add("Titulo", pNoticia.titulo)
            h.Add("Desc_corta", pNoticia.desc_corta)
            h.Add("Desc_larga", pNoticia.desc_larga)
            h.Add("Fecha_desde", pNoticia.fecha_desde)
            h.Add("Fecha_hasta", pNoticia.fecha_hasta)
            h.Add("Id_categoria", pNoticia.id_categoria)
            h.Add("Imagen", pNoticia.imagen)

            Return d.Escribir("sp_mod_noticia", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Eliminar(pNoticia As BE.Noticia) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Id", pNoticia.id)
            'h.Add("Titulo", pNoticia.titulo)
            'h.Add("Desc_corta", pNoticia.desc_corta)
            'h.Add("Desc_larga", pNoticia.desc_larga)
            'h.Add("Fecha_desde", pNoticia.fecha_desde)
            'h.Add("Fecha_hasta", pNoticia.fecha_hasta)
            'h.Add("Id_categoria", pNoticia.id_categoria)

            Return d.Escribir("sp_del_noticia", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function ObtenerNoticia(pNoticia As BE.Noticia) As BE.Noticia
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim noti As New BE.Noticia
        Try
            h.Add("Id", pNoticia.id)
            Dim ds = d.Leer("sp_get_noticia", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    noti.id = row("id")
                    noti.titulo = row("titulo")
                    noti.desc_corta = row("desc_corta")
                    noti.desc_larga = row("desc_larga")
                    noti.fecha_desde = row("fecha_desde")
                    noti.fecha_hasta = row("fecha_hasta")
                    noti.id_categoria = row("id_categoria")
                    noti.imagen = row("imagen")
                Next
            End If
            Return noti
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
