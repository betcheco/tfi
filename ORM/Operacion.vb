Public Class Operacion

    Shared Function listar() As List(Of BE.Operacion)
        Dim d As New DAL.Datos
        Dim lista As New List(Of BE.Operacion)
        Try
            Dim ds = d.Leer("sp_listar_operaciones", Nothing)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim o As New BE.Operacion
                    o.id = row("id")
                    o.id_anuncio = row("id_anuncio")
                    o.id_vendedor = row("id_vendedor")
                    o.id_comprador = row("id_comprador")
                    o.id_factura = row("id_factura")
                    o.estado = row("estado")
                    o.id_chat = row("id_chat")
                    o.msj_nuevo = row("msj_nuevo")
                    o.msj_leido = row("msj_leido")
                    o.fecha = row("fecha")

                    lista.add(o)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Shared Function listarByuser(pId As Integer, comprador As Boolean) As List(Of BE.Operacion)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim sp As String
        Dim lista As New List(Of BE.Operacion)
        Try
            If comprador Then
                sp = "sp_listar_operacion_by_comprador"
            Else
                sp = "sp_listar_operacion_by_vendedor"
            End If

            h.Add("@Id_usuario", pId)
            Dim ds = d.Leer(sp, h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim o As New BE.Operacion
                    o.id = row("id")
                    o.id_anuncio = row("id_anuncio")
                    o.id_vendedor = row("id_vendedor")
                    o.id_comprador = row("id_comprador")
                    o.id_factura = row("id_factura")
                    o.estado = row("estado")
                    o.id_chat = row("id_chat")
                    o.msj_nuevo = row("msj_nuevo")
                    o.msj_leido = row("msj_leido")
                    o.fecha = row("fecha")

                    lista.add(o)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function crear(pOperacion As BE.Operacion) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id_anuncio", pOperacion.id_anuncio)
            h.Add("@id_comprador", pOperacion.id_comprador)
            h.Add("@id_vendedor", pOperacion.id_vendedor)
            h.Add("@id_factura", pOperacion.id_factura)
            Return d.Escribir("sp_crear_operacion", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function setEstado(pOperacion As BE.Operacion) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id", pOperacion.id)
            h.Add("@estado", pOperacion.estado)
            Return d.Escribir("sp_mod_estado_operacion", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function obtener(id As Integer) As BE.Operacion
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim o As New BE.Operacion
        Try
            h.Add("@Id", id)
            Dim ds = d.Leer("sp_get_operacion", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    o.id = row("id")
                    o.id_anuncio = row("id_anuncio")
                    o.id_vendedor = row("id_vendedor")
                    o.id_comprador = row("id_comprador")
                    o.id_factura = row("id_factura")
                    o.estado = row("estado")
                    o.id_chat = row("id_chat")
                    o.msj_nuevo = row("msj_nuevo")
                    o.msj_leido = row("msj_leido")
                    o.fecha = row("fecha")
                Next
            End If
            Return o
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Shared Function setCalificacion(id As Integer, pcalificacion As Integer) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Id", id)
            h.Add("@Calificacion", pcalificacion)
            Return d.Escribir("sp_mod_calificacion_operacion", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function setMsje(id As Integer, msjNuevo As Boolean) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Id", id)
            If msjNuevo Then
                Return d.Escribir("sp_msjnuevo_operacion", h)
            Else
                Return d.Escribir("sp_msjleido_operacion", h)
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Function
End Class
