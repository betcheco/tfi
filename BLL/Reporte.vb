Public Class Reporte
    Public Shared Function ytd() As List(Of BE.Reporte)
        Try
            Return ORM.Reporte.ytd()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function mensual(mes As Integer) As List(Of BE.Reporte)
        Try
            Return ORM.Reporte.mensual(mes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fecha(desde As String, hasta As String) As List(Of BE.Reporte)
        Try
            Return ORM.Reporte.fecha(CDate(desde).ToString("yyyyMMdd"), CDate(hasta).ToString("yyyyMMdd"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function listadoYtd() As List(Of BE.ReporteFactura)
        Try
            Return ORM.Reporte.listadoYtd()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function listadoMensual(mes As Integer) As List(Of BE.ReporteFactura)
        Try
            Return ORM.Reporte.listadoMensual(mes)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ListadoFecha(desde As String, hasta As String) As List(Of BE.ReporteFactura)
        Try
            Return ORM.Reporte.listadoFecha(CDate(desde).ToString("yyyyMMdd"), CDate(hasta).ToString("yyyyMMdd"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function total(lista As List(Of BE.Reporte)) As Double
        Try
            Dim result As New Double
            result = 0
            For Each monto In lista
                result += monto.monto
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
