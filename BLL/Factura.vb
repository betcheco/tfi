Imports System.Web

Public Class Factura
    Public Shared Function Crear(pFactura As BE.Factura) As Boolean
        Try
            Return ORM.Factura.Crear(pFactura)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Listar(pFactura As BE.Factura) As List(Of BE.Factura)
        Try
            Return ORM.Factura.Listar(pFactura)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Modificar(pFactura As BE.Factura) As Boolean
        Try
            Return ORM.Factura.Modificar(pFactura)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Obtener(pFactura As BE.Factura) As BE.Factura
        Try
            Return ORM.Factura.ObtenerFactura(pFactura)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
