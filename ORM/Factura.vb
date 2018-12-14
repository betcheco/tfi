Imports BE

Public Class Factura
    Shared Function Listar(pFactura As BE.Factura) As List(Of BE.Factura)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Factura)
        Dim ds As New DataSet
        Try
            If pFactura Is Nothing Then
                ds = d.Leer("sp_listar_factura", Nothing)
            Else
                If Not pFactura.usuario.id = 0 Then
                    h.Add("@Usuario_id", pFactura.usuario.id)
                    ds = d.Leer("sp_listar_factura_by_user", h)
                End If
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim f As New BE.Factura
                    f.id = row("id")
                    f.fecha = row("fecha")
                    f.usuario.id = row("usuario")
                    f.items = ObtenerItems(f.id)
                    f.estado = row("estado")

                    lista.Add(f)
                Next

            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function ObtenerFactura(pFactura As BE.Factura) As BE.Factura
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim factura As New BE.Factura
        Try
            h.Add("@Id", pFactura.id)
            Dim ds = d.Leer("sp_obtener_factura", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    'Dim f As New BE.Factura
                    factura.id = row("id")
                    factura.fecha = row("fecha")
                    Dim u As New BE.Usuario
                    u.id = row("usuario_id")
                    factura.usuario = u
                    factura.items = ObtenerItems(pFactura.id)
                    factura.estado = row("estado")


                Next

            End If
            Return factura
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Crear(pFactura As BE.Factura) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            ' h.Add("Id", pFactura.id)
            h.Add("@Fecha", pFactura.fecha)
            h.Add("@Usuario_id", pFactura.usuario.id)
            pFactura.id = d.EscribirInt("sp_crear_factura", h)

            For Each item In pFactura.items
                item.factura_id = pFactura.id
                CrearItem(item)
            Next
            If pFactura.id > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Modificar(pFactura As BE.Factura) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Id", pFactura.id)
            h.Add("@Estado", pFactura.estado)

            Return d.Escribir("sp_mod_factura", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Sub CrearItem(item As FacturaItem)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Desc", item.desc)
            h.Add("@Monto", item.monto)
            h.Add("@Factura_id", item.factura_id)
            d.Escribir("sp_crear_item", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Shared Function ObtenerItems(id As Integer) As List(Of FacturaItem)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.FacturaItem)
        Try
            h.Add("Factura_id", id)
            Dim ds = d.Leer("sp_listar_facturaitem", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim fi As New BE.FacturaItem
                    fi.id = row("id")
                    fi.desc = row("descripcion")
                    fi.monto = row("monto")
                    fi.factura_id = row("factura_id")

                    lista.Add(fi)

                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function reporteFecha(desde As String, hasta As String) As List(Of BE.Factura)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Factura)
        Dim ds As New DataSet
        Try

            h.Add("@desde", desde)
            h.Add("@hasta", hasta)
            ds = d.Leer("sp_reporte_factura_fecha", h)


            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim f As New BE.Factura
                    f.id = row("id")
                    f.fecha = row("fecha")
                    f.usuario.id = row("usuario")
                    f.items = ObtenerItems(f.id)
                    f.estado = row("estado")

                    lista.Add(f)
                Next

            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
