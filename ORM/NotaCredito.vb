Public Class NotaCredito
    Shared Function Listar(nc As BE.NotaCredito) As List(Of BE.NotaCredito)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim ds As New DataSet
        Dim lista As New List(Of BE.NotaCredito)
        Try
            If nc Is Nothing Then
                ds = d.Leer("sp_listar_notacredito", Nothing)
            Else
                If Not nc.usuario Is Nothing Then
                    h.Add("@Usuario_id", nc.usuario.id)
                    ds = d.Leer("sp_listar_notacredito_by_user", h)
                End If
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim n As New BE.NotaCredito
                    n.id = row("id")
                    n.fecha = row("fecha")
                    Dim u As New BE.Usuario
                    u.id = row("usuario_id")
                    n.usuario = u
                    n.concepto = row("concepto")
                    n.monto = row("monto")
                    n.saldo = row("saldo")
                    n.facturaid = row("factura_id")

                    lista.Add(n)

                Next
            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Crear(nc As BE.NotaCredito) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            'h.Add("Id", nc.id)
            h.Add("@Fecha", nc.fecha)
            h.Add("@Usuario_id", nc.usuario.id)
            h.Add("@Concepto", nc.concepto)
            h.Add("@Monto", nc.monto)
            h.Add("@Saldo", nc.saldo)
            h.Add("@Factura_id", nc.facturaid)

            nc.id = d.EscribirInt("sp_crear_notacredito", h)
            If nc.id > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Modificar(nc As BE.NotaCredito) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("Id", nc.id)
            h.Add("Fecha", nc.fecha)
            h.Add("Usuario_id", nc.usuario.id)
            h.Add("Concepto", nc.concepto)
            h.Add("Monto", nc.monto)
            h.Add("Saldo", nc.saldo)

            Return d.Escribir("sp_mod_notacredito", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Obtener(nc As BE.NotaCredito) As BE.NotaCredito
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim n As New BE.NotaCredito
        Try
            h.Add("Id", nc.id)
            Dim ds = d.Leer("sp_get_notacredito", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows

                    n.id = row("id")
                    n.fecha = row("fecha")
                    Dim u As New BE.Usuario
                    u.id = row("usuario_id")
                    n.usuario = u
                    n.concepto = row("concepto")
                    n.monto = row("monto")
                    n.saldo = row("saldo")
                    n.facturaid = row("factura_id")


                Next
            End If

            Return n
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
