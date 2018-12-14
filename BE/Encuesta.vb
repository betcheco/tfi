Public Class Encuesta
    Public Property id As Integer
    Public Property nombre As String
    Public Property opciones As New List(Of BE.EncuestaOpcion)
    Public Property activo As Boolean
    Public Property vencimiento As DateTime
End Class
