Public Class Permiso

    Public Shared Function Listar() As List(Of BE.Permiso)
        Return ORM.Permiso.Listar()
    End Function
End Class
