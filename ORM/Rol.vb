Public Class Rol

    Shared Function ObtenerRol(pRol As BE.Rol) As BE.Rol
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim oRol As New BE.Rol
        h.Add("@Id", pRol.id)
        Dim ds = d.Leer("sp_get_rol", h)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each row In ds.Tables(0).Rows

                oRol.id = row("id")
                oRol.nombre = row("nombre")
                oRol.descripcion = row("descripcion")
                oRol.permisos = ListarPermisos(oRol.id)
            Next
        End If
        Return oRol

    End Function

    Shared Function ModificarRol(pRol As BE.Rol) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim h2 As New Hashtable
        h.Add("@Id", pRol.id)
        h.Add("@Nombre", pRol.nombre)
        h.Add("@Descripcion", pRol.descripcion)
        d.Escribir("sp_mod_rol", h)

        ''Desasigno los permisos del rol ---- Esto lo hago dentro del mismo sp
        'Asigno los roles
        For Each permiso In pRol.permisos
            h2.Clear()
            h2.Add("@IdRol", pRol.id)
            h2.Add("@IdPermiso", permiso.id)
            d.Escribir("sp_asignar_permiso_rol", h2)

        Next
        Return True
    End Function

    Shared Function ListarRoles() As List(Of BE.Rol)
        Dim d As New DAL.Datos
        Dim listaRoles As New List(Of BE.Rol)
        Dim ds = d.Leer("sp_listar_roles", Nothing)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each row In ds.Tables(0).Rows
                Dim oRol As New BE.Rol
                oRol.id = row("id")
                oRol.nombre = row("nombre")
                oRol.descripcion = row("descripcion")
                oRol.permisos = ListarPermisos(oRol.id)

                listaRoles.Add(oRol)
            Next
        End If

        Return listaRoles
    End Function

    Shared Function ListarRolesUsuario(user As BE.Usuario) As List(Of BE.Rol)
        Dim d As New DAL.Datos
        Dim listaRoles As New List(Of BE.Rol)
        Dim h As New Hashtable
        h.Add("@Id", user.id)
        Dim ds = d.Leer("sp_listar_roles_by_usuario", h)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each row In ds.Tables(0).Rows
                Dim oRol As New BE.Rol
                oRol.id = row("id")
                oRol.nombre = row("nombre")
                oRol.descripcion = row("descripcion")
                oRol.permisos = ListarPermisos(oRol.id)

                listaRoles.Add(oRol)
            Next
        End If

        Return listaRoles
    End Function

    Shared Function ListarPermisos(rolId As Integer) As List(Of BE.Permiso)
        Dim d As New DAL.Datos
        Dim listaPermisos As New List(Of BE.Permiso)
        Dim h As New Hashtable
        h.Add("@RolId", rolId)
        Dim ds = d.Leer("sp_listar_permisos_by_rol", h)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each row In ds.Tables(0).Rows
                Dim oPermiso As New BE.Permiso
                oPermiso.id = row("id")
                oPermiso.nombre = row("nombre")
                oPermiso.descripcion = row("descripcion")
                'oPermiso.control = row("control")

                listaPermisos.Add(oPermiso)


            Next
        End If

        Return listaPermisos

    End Function

    Shared Function CrearRol(pRol As BE.Rol) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim h2 As New Hashtable
        h.Add("@Nombre", pRol.nombre)
        h.Add("@Descripcion", pRol.descripcion)
        pRol.id = d.EscribirInt("sp_nuevo_rol", h)

        For Each permiso In pRol.permisos
            h2.Clear()
            h2.Add("@IdRol", pRol.id)
            h2.Add("@IdPermiso", permiso.id)
            d.Escribir("sp_asignar_permiso_rol", h2)

        Next
        Return True
    End Function

    Shared Function AsignarPermiso(idPermiso As Integer) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        h.Add("@Id", idPermiso)
        Return d.Escribir("sp_asignar_permiso_rol", h)
    End Function

    Shared Function EliminarRol(pRol As BE.Rol) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        h.Add("@Id", pRol.id)
        Return d.Escribir("sp_del_rol", h)
    End Function
End Class
