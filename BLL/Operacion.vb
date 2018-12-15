Public Class Operacion

    Public Shared Function listar() As List(Of BE.Operacion)
        Try
            Return ORM.Operacion.listar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function listarbyuser(pid As Integer, comprador As Boolean) As List(Of BE.Operacion)
        Try
            Return ORM.Operacion.listarByuser(pid, comprador)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function crear(pOperacion As BE.Operacion) As Integer
        Try
            Return ORM.Operacion.crear(pOperacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function setEstado(pOperacion As BE.Operacion) As Boolean
        Try
            Return ORM.Operacion.setEstado(pOperacion)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function obtener(pid As Integer) As BE.Operacion
        Try
            Return ORM.Operacion.obtener(pid)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function setCalificacion(pid As Integer, pcali As Integer) As Boolean
        Try
            Return ORM.Operacion.setCalificacion(pid, pcali)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function setMsj(pid As Integer, msjNuevo As Boolean) As Boolean
        Try
            Return ORM.Operacion.setMsje(pid, msjNuevo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
