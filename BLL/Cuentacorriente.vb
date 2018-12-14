Public Class Cuentacorriente

    Public Shared Function listar(puid As Integer?) As List(Of BE.Cuentacorriente)
        Try
            Return ORM.Cuentacorriente.listar(puid)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
