Public Class NotaDebito

    Shared Function Listar(pNd As BE.NotaDebito) As List(Of BE.NotaDebito)
        Dim d As New DAL.Datos
        Dim lista As New List(Of BE.NotaDebito)
        Dim h As New Hashtable
        Dim ds As New DataSet
        Try
            If pNd Is Nothing Then
                ds = d.Leer("sp_listar_notadebito", Nothing)
            Else
                If Not pNd.usuario.id = 0 Then
                    h.Add("@Usuario_id", pNd.usuario.id)
                    ds = d.Leer("sp_listar_notadebito_by_user", h)
                End If
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim nd As New BE.NotaDebito
                    nd.id = row("id")
                    nd.concepto = row("concepto")
                    nd.fechas = row("fecha")
                    nd.monto = row("monto")
                    nd.usuario.id = row("usuario_id")

                    lista.Add(nd)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Crear(pNd As BE.NotaDebito) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Concepto", pNd.concepto)
            h.Add("@Fecha", pNd.fechas)
            h.Add("@Monto", pNd.monto)
            h.Add("@Usuario_id", pNd.usuario.id)

            Return d.Escribir("sp_crear_notadebito", h)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function Obtener(id As Integer) As BE.NotaDebito
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim nd As New BE.NotaDebito
        Try
            h.Add("@Id", id)
            Dim ds = d.Leer("sp_get_notadebito", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    nd.id = row("id")
                    nd.concepto = row("concepto")
                    nd.fechas = row("fecha")
                    nd.monto = row("monto")
                    nd.usuario.id = row("usuario_id")
                Next
            End If
            Return nd
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
