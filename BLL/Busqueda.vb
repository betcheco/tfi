Public Class Busqueda

    Public Shared Function buscar(palabra As String) As List(Of BE.Busqueda)
        Try
            Return ORM.Busqueda.buscar(palabra)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
