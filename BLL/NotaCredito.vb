Public Class NotaCredito

    Public Shared Function Listar(pnc As BE.NotaCredito) As List(Of BE.NotaCredito)
        Try
            Return ORM.NotaCredito.listar(pnc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Modificar(pnc As BE.NotaCredito) As Boolean
        Try
            Return ORM.NotaCredito.Modificar(pnc)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function Obtener(pnc As BE.NotaCredito) As BE.NotaCredito
        Try
            Return ORM.NotaCredito.Obtener(pnc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Crear(pnc As BE.NotaCredito) As Boolean
        Try
            Return ORM.NotaCredito.Crear(pnc)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
