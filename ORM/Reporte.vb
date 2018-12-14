Public Class Reporte
    Shared Function ytd() As List(Of BE.Reporte)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Reporte)
        Try
            Dim ds = d.Leer("sp_reporte_ganancias_ytd", Nothing)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim r As New BE.Reporte
                    r.fecha = row("fecha")
                    r.monto = row("monto")

                    lista.Add(r)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function mensual(mes As Integer) As List(Of BE.Reporte)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Reporte)
        Try
            h.Add("@mes", mes)
            Dim ds = d.Leer("sp_reporte_ganancias_mensual", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim r As New BE.Reporte
                    r.fecha = row("fecha")
                    r.monto = row("monto")

                    lista.add(r)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function fecha(desde As String, hasta As String) As List(Of BE.Reporte)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Reporte)
        Try
            h.Add("@desde", desde)
            h.Add("@hasta", hasta)
            Dim ds = d.Leer("sp_reporte_ganancias_fecha", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim r As New BE.Reporte
                    r.fecha = row("fecha")
                    r.monto = row("monto")

                    lista.Add(r)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Shared Function listadoFecha(desde As String, hasta As String) As List(Of BE.ReporteFactura)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.ReporteFactura)
        Try
            h.Add("@desde", desde)
            h.Add("@hasta", hasta)
            Dim ds = d.Leer("sp_reporte_factura_fecha", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim r As New BE.ReporteFactura
                    r.nro = row("nro")
                    r.fecha = row("fecha")
                    r.detalle = row("detalle")
                    r.monto = row("monto")

                    lista.Add(r)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function listadoMensual(mes As Integer) As List(Of BE.ReporteFactura)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.ReporteFactura)
        Try
            h.Add("@mes", mes)
            Dim ds = d.Leer("sp_reporte_factura_mensual", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim r As New BE.ReporteFactura
                    r.nro = row("nro")
                    r.fecha = row("fecha")
                    r.detalle = row("detalle")
                    r.monto = row("monto")

                    lista.Add(r)
                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function listadoYtd() As List(Of BE.ReporteFactura)
        Dim d As New DAL.Datos

        Dim lista As New List(Of BE.ReporteFactura)
        Try
            Dim ds = d.Leer("sp_reporte_factura_ytd", Nothing)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows

                    Dim r As New BE.ReporteFactura
                        r.nro = row("nro")
                        r.fecha = row("fecha")
                        r.detalle = row("detalle")
                        r.monto = row("monto")

                        lista.Add(r)
                    Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
