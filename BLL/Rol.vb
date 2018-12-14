Imports BE

Public Class Rol

    Public Shared Function Eliminar(pRol As BE.Rol) As Boolean
        Return ORM.Rol.EliminarRol(pRol)
    End Function

    Public Shared Function Listar() As List(Of BE.Rol)
        Return ORM.Rol.ListarRoles()

    End Function

    Public Shared Function Crear(pRol As BE.Rol) As Boolean
        'Dim id As New Integer
        'Try
        '    id = ORM.Rol.CrearRol(pRol)
        '    For Each permiso In pRol.permisos
        '        AsignarPermiso(permiso.id)
        '    Next
        '    Return True
        'Catch ex As Exception
        '    Console.WriteLine("Error en BLL " & ex.Message)
        '    Return False
        'End Try
        Return ORM.Rol.CrearRol(pRol)

    End Function

    Public Shared Function AsignarPermiso(idRol As Integer) As Boolean

        Return ORM.Rol.AsignarPermiso(idRol)

    End Function

    Public Shared Function ObtenerRol(pRol As BE.Rol) As BE.Rol
        Return ORM.Rol.ObtenerRol(pRol)
    End Function

    Public Shared Function ModificarRol(pModRol As BE.Rol) As Boolean
        Return ORM.Rol.ModificarRol(pModRol)
    End Function
End Class
