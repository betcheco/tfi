Public Class Permiso

    Shared Function Listar() As List(Of BE.Permiso)
        Dim d As New DAL.Datos
        Dim listaPermisos As New List(Of BE.Permiso)

        Dim ds = d.Leer("sp_listar_permisos", Nothing)
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


End Class
