Public Class Chat

    Shared Function Listar(opid As Integer) As List(Of BE.Chat)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Chat)
        Try
            h.Add("@operacionid", opid)
            Dim ds = d.Leer("sp_listar_chat", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim c As New BE.Chat
                    c.id = row("id")
                    c.operacion_id = row("operacion_id")
                    c.pregunta = row("pregunta")
                    c.respuesta = row("respuesta")
                    c.fpregunta = CDate(row("fpregunta"))
                    c.frespuesta = CDate(row("frespuesta"))
                    lista.Add(c)
                Next

            End If

            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function Nuevo(chat As BE.Chat) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@pregunta", chat.pregunta)
            h.Add("@operacionid", chat.operacion_id)

            Return d.Escribir("sp_nuevo_chat", h)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function responder(id As Integer, respuesta As String) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id", id)
            h.Add("@respuesta", respuesta)
            Return d.Escribir("sp_responder_chat", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function reporte(fdesde As String, fhasta As String) As Dictionary(Of String, Integer)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@desde", fdesde)
            h.Add("@hasta", fhasta)
            Dim ds = d.Leer("sp_reporte_chat", h)

            Dim dic As New Dictionary(Of String, Integer)
            For Each r As DataRow In ds.Tables(0).Rows
                dic.Add(r("diff").ToString, CInt(r("count")))
            Next
            Return dic
        Catch ex As Exception
            Throw ex
        End Try


    End Function

End Class
