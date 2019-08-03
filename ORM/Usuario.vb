

Imports BE

Public Class Usuario

    Public Function ObtenerUsuarioById(id As Integer) As BE.Usuario
        Dim d As New DAL.Datos
        Dim oUser As New BE.Usuario
        Dim hTable As New Hashtable
        Try
            hTable.Add("@Id", id)
            Dim ds = d.Leer("sp_get_usuario_by_id", hTable)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each i In ds.Tables(0).Rows
                    'ASIGNO LAS VARIABLES AL OBJETO USUARIO
                    oUser.id = CInt(i("id"))
                    oUser.nombre = i("nombre")
                    oUser.apellido = i("apellido")
                    oUser.email = i("email")
                    oUser.contraseña = i("contraseña")
                    oUser.activo = CBool(i("activo"))
                    oUser.estado = i("estado")
                    oUser.intentos = i("intentos")
                    oUser.token = i("token")
                    oUser.roles = ORM.Rol.ListarRolesUsuario(oUser)
                Next

            End If
            Return oUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerUsuario(pUsuario As BE.Usuario) As BE.Usuario
        Dim d As New DAL.Datos
        Dim oUser As New BE.Usuario
        Dim hTable As New Hashtable
        If Not pUsuario.token Is Nothing Then
            hTable.Add("@Token", pUsuario.token)
            Try
                Dim ds = d.Leer("sp_get_usuario_by_token", hTable)
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each i In ds.Tables(0).Rows
                        'ASIGNO LAS VARIABLES AL OBJETO USUARIO
                        oUser.id = CInt(i("id"))
                        oUser.nombre = i("nombre")
                        oUser.apellido = i("apellido")
                        oUser.email = i("email")
                        oUser.contraseña = i("contraseña")
                        oUser.activo = CBool(i("activo"))
                        oUser.estado = i("estado")
                        oUser.intentos = i("intentos")
                        oUser.token = i("token")
                        oUser.roles = ORM.Rol.ListarRolesUsuario(oUser)
                    Next

                End If
            Catch ex As Exception
                Throw ex
            End Try
        Else
            hTable.Add("@Email", pUsuario.email)
            Try
                Dim ds = d.Leer("sp_get_usuario", hTable)
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each i In ds.Tables(0).Rows
                        'ASIGNO LAS VARIABLES AL OBJETO USUARIO
                        oUser.id = CInt(i("id"))
                        oUser.nombre = i("nombre")
                        oUser.apellido = i("apellido")
                        oUser.email = i("email")
                        oUser.contraseña = i("contraseña")
                        oUser.activo = CBool(i("activo"))
                        oUser.estado = i("estado")
                        oUser.intentos = i("intentos")
                        oUser.token = i("token")
                        oUser.roles = ORM.Rol.ListarRolesUsuario(oUser)
                    Next

                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If





        Return oUser

    End Function

    Public Function Activar(oUser As BE.Usuario) As Boolean
        Dim d As New DAL.Datos
        Dim htable As New Hashtable
        htable.Add("@Token", oUser.token)
        Try
            Return d.Escribir("sp_confirmar_usuario", htable)

        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function Listar() As List(Of BE.Usuario)
        Dim d As New DAL.Datos
        Dim listaUsuarios = New List(Of BE.Usuario)
        Dim ds = d.Leer("sp_listar_usuario", Nothing)
        If ds.Tables(0).Rows.Count > 0 Then
            For Each i In ds.Tables(0).Rows
                Dim oUser = New BE.Usuario
                'ASIGNO LAS VARIABLES AL OBJETO USUARIO
                oUser.id = i("id")
                oUser.nombre = i("nombre")
                oUser.apellido = i("apellido")
                oUser.email = i("email")
                '     oUser.contraseña = i("contraseña")
                '  oUser.activo = CBool(i("activo"))
                oUser.estado = i("estado")
                '   oUser.token = i("token")
                'ETC

                'AGREGO EL OBJETO A LA LISTA DE USUARIOS
                listaUsuarios.Add(oUser)
            Next

        End If
        Return listaUsuarios
    End Function

    Public Function Crear(pUsuario As BE.Usuario) As Boolean
        Dim d As New DAL.Datos
        Dim htable As New Hashtable
        Try
            'ASIGNO LAS VARIABLES AL HASHTABLE
            htable.Add("@Nombre", pUsuario.nombre)
            htable.Add("@Apellido", pUsuario.apellido)
            htable.Add("@Email", pUsuario.email)
            htable.Add("@Contraseña", pUsuario.contraseña)
            htable.Add("@Token", pUsuario.token)
            'ETC

            Return d.EscribirInt("sp_alta_usuario", htable)
        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Public Function Eliminar(pUsuario As BE.Usuario) As Boolean
        Dim d As New DAL.Datos
        Dim hTable As New Hashtable
        Try
            'ASIGNO EL ID DEL USUARIO PARA ELIMINARLO
            hTable.Add("@Email", pUsuario.email)
            Return d.Escribir("sp_del_usuario", hTable)
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Public Function Modificar(pUsuario As BE.Usuario) As Boolean
        Dim d As New DAL.Datos
        Dim hTable As New Hashtable
        Try
            hTable.Add("@Id", pUsuario.id)
            hTable.Add("@Contraseña", pUsuario.contraseña)
            hTable.Add("@Estado", pUsuario.estado)
            hTable.Add("@Intentos", pUsuario.intentos)
            hTable.Add("@Nombre", pUsuario.nombre)
            hTable.Add("@Apellido", pUsuario.apellido)
            hTable.Add("@Activo", pUsuario.activo)
            d.Escribir("sp_mod_usuario", hTable)
            Return AsignarRol(pUsuario)

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
        'ASIGNO DATOS DEL USUARIO AL HASHTABLE

    End Function


    Public Function AsignarRol(pUsuario As BE.Usuario) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable

        If Not pUsuario.roles Is Nothing Then

            Try

                For Each rol In pUsuario.roles
                    h.Add("@IdUsuario", pUsuario.id)
                    h.Add("@IdRol", rol.id)
                    d.Escribir("sp_asignar_usuario_rol", h)
                    h.Clear()
                Next
                Return True
            Catch ex As Exception
                Throw New Exception
                Return False

            End Try
        Else
            Return True
        End If

    End Function
End Class
