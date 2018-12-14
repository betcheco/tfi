Public Class Notadebito

    Public Shared Function Listar(pNd As BE.NotaDebito) As List(Of BE.NotaDebito)
        Try
            Return ORM.NotaDebito.Listar(pNd)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Obtener(id As Integer) As BE.NotaDebito
        Try
            Return ORM.NotaDebito.Obtener(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function Crear(pNd As BE.NotaDebito) As Boolean
        Try
            Return ORM.NotaDebito.Crear(pNd)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
