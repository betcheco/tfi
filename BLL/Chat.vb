Public Class Chat

    Public Shared Function Nuevo(chat As BE.Chat) As Boolean
        Try
            Return ORM.Chat.Nuevo(chat)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Responder(id As Integer, resp As String) As Boolean
        Try
            Return ORM.Chat.responder(id, resp)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Listar(opid As Integer) As List(Of BE.Chat)
        Try
            Return ORM.Chat.Listar(opid)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function reporte(fdesde As String, fhasta As String) As Dictionary(Of String, Integer)
        Try
            Return ORM.Chat.reporte(fdesde, fhasta)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
