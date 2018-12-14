Public Class Cuentacorriente
    Shared Function listar(puid As Integer?) As List(Of BE.Cuentacorriente)
        Dim lista As New List(Of BE.Cuentacorriente)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim DS As New DataSet
        Try
            If Not puid Is Nothing Then
                h.Add("@Id_usuario", puid)
                DS = d.Leer("sp_listar_cuentacorriente_by_user", h)
            Else
                DS = d.Leer("sp_listar_cuentacorriente", Nothing)
            End If

            If DS.Tables(0).Rows.Count > 0 Then
                For Each row In DS.Tables(0).Rows
                    Dim cc As New BE.Cuentacorriente
                    cc.fecha = CDate(row("fecha"))
                    cc.descripcion = row("descripcion")
                    cc.tcomprobante = row("tipoComprobante").ToString
                    cc.nroCromprobante = row("nroComprobante").ToString
                    cc.debe = CDbl(row("debe"))
                    cc.haber = CDbl(row("haber"))
                    cc.estado = row("estado").ToString
                    cc.calificacion = CInt(row("calificacion"))
                    cc.operacionid = row("operacion_id")
                    cc.msjnuevo = CInt(row("msj_nuevo"))
                    cc.msjleido = CInt(row("msj_leido"))

                    lista.Add(cc)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
