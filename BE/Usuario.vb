Public Class Usuario

    Public Property id As Integer
    Public Property nombre As String
    Public Property apellido As String
    Public Property email As String
    Public Property contraseña As String
    Public Property activo As Boolean
    Public Property estado As String
    Public Property intentos As Integer
    Public Property roles As List(Of BE.Rol)
    Public Property token As String


End Class
