Public Class Categoria

    Public Shared Function Listar() As List(Of BE.Categoria)
        Try
            Return ORM.Categoria.Listar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function obtenerCategoria(id As Integer) As BE.Categoria
        Try
            Return ORM.Categoria.obtenerCategoria(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
