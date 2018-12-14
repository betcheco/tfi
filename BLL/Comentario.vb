Public Class Comentario
    Public Shared Function Nuevo(c As BE.Comentario) As Boolean
        Try
            Return ORM.Comentario.Nuevo(c)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Modificar(c As BE.Comentario) As Boolean
        Try
            Return ORM.Comentario.Modificar(c)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Listar(c As BE.Comentario) As List(Of BE.Comentario)
        Try
            Return ORM.Comentario.Listar(c)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
