Public Class Noticia
    Public Shared Function Listar(pNoticia As BE.Noticia) As List(Of BE.Noticia)
        Try
            Return ORM.Noticia.Listar(pNoticia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListarByFecha(pNoticia As BE.Noticia) As List(Of BE.Noticia)
        Try
            Return ORM.Noticia.ListarByFecha(pNoticia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Alta(pnotica As BE.Noticia) As Boolean
        Try
            Return ORM.Noticia.Alta(pnotica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Modificar(pNoticia As BE.Noticia) As Boolean
        Try
            Return ORM.Noticia.Modificar(pNoticia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Eliminar(pNoticia As BE.Noticia) As Boolean
        Try
            Return ORM.Noticia.Eliminar(pNoticia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ObtenerNoticia(pnoticia As BE.Noticia) As BE.Noticia
        Try
            Return ORM.Noticia.ObtenerNoticia(pnoticia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
