Public Class Bitacora

    Public Shared Sub RegistarEvento(pBitacora As BE.Bitacora)
        Dim descripcion As String

        ORM.Bitacora.RegistrarEvento(pBitacora)
    End Sub

    Public Shared Function ConsultarBItacora(pFechaDesde As DateTime, pFechaHasta As DateTime, pCriticidad As Integer, pUsuario As String) As List(Of BE.Bitacora)
        Try
            Return ORM.Bitacora.ConsultarBitacora(pFechaDesde, pFechaHasta, pCriticidad, pUsuario)
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Shared Function ConsultarBItacora(pFechaDesde As DateTime, pFechaHasta As DateTime) As List(Of BE.Bitacora)
        Return ORM.Bitacora.ConsultarBitacora(pFechaDesde, pFechaHasta)
    End Function
    Public Shared Function ConsultarBItacora() As List(Of BE.Bitacora)
        Return ORM.Bitacora.ConsultarBitacora()
    End Function
    Public Shared Function ConsultarBItacora(pCriticidad As Integer) As List(Of BE.Bitacora)
        Return ORM.Bitacora.ConsultarBitacora(pCriticidad)
    End Function


End Class
