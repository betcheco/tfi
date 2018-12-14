Imports BE

Public Class Usuario

    Shared Function Listar() As List(Of BE.Usuario)
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.Listar()
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Shared Function RegistrarUsuario(pUsuario As BE.Usuario) As Boolean
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.Crear(pUsuario)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function BuscarUsuarioById(pId As Integer) As BE.Usuario
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.ObtenerUsuarioById(pId)




        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Shared Function BuscarUsuario(pUsuario As BE.Usuario) As BE.Usuario
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.ObtenerUsuario(pUsuario)




        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Shared Function ActivarUsuario(oUser As BE.Usuario)
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.Activar(oUser)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Shared Function BlanqueoPassword(oUser As BE.Usuario) As Boolean
        Try
            Dim mapper As New ORM.Usuario

            Return mapper.Modificar(oUser)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function ModificarUsuario(oUser As BE.Usuario) As Boolean
        Try
            Dim mapper As New ORM.Usuario

            Return mapper.Modificar(oUser)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function EliminarUsuario(oUser As BE.Usuario) As Boolean
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.Eliminar(oUser)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function AsignarRoles(oUser As BE.Usuario) As Boolean
        Try
            Dim mapper As New ORM.Usuario
            Return mapper.AsignarRol(oUser)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Shared Function CheckPermiso(paramUser As BE.Usuario, paramPermiso As String) As Boolean
        Dim result As Boolean
        Try
            If Not paramUser Is Nothing Then
                For Each rol In paramUser.roles
                    For Each permiso In rol.permisos
                        If permiso.nombre = paramPermiso Then
                            result = True
                        End If
                    Next
                Next
                Return result
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
