Public Class Comentario

    Shared Function Nuevo(pComentario As BE.Comentario) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Comentario", pComentario.comentario)
            h.Add("Anuncio_id", pComentario.id_anuncio)

            Return d.Escribir("sp_nuevo_comentario", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Modificar(pComentario As BE.Comentario) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Id", pComentario.id)
            h.Add("Comentario", pComentario.comentario)
            h.Add("Respuesta", pComentario.respuesta)
            h.Add("Activo", pComentario.activo)
            h.Add("Anuncio_id", pComentario.id_anuncio)

            Return d.Escribir("sp_mod_comentario", h)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function Listar(pComentario As BE.Comentario) As List(Of BE.Comentario)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Comentario)
        Try
            h.Add("Anuncio_id", pComentario.id_anuncio)
            Dim ds = d.Leer("sp_listar_comentarios", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim c As New BE.Comentario
                    c.id = row("id")
                    c.comentario = row("comentario")
                    c.respuesta = row("respuesta")
                    c.activo = row("activo")
                    c.id_anuncio = row("anuncio_id")

                    lista.Add(c)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
