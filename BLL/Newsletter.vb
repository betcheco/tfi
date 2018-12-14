Public Class Newsletter

    Public Shared Function listar(id_cat As Integer) As List(Of BE.Newsletter)
        Try
            Return ORM.Newsletter.listar(id_cat)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function subscripcion(pn As BE.Newsletter) As Boolean
        Try
            Return ORM.Newsletter.subscribir(pn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function baja(pn As BE.Newsletter) As Boolean
        Try
            Return ORM.Newsletter.baja(pn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
