Public Class Factura
    Public Property id As Integer
    Public Property fecha As Date
    Public Property usuario As BE.Usuario
    Public Property items As New List(Of BE.FacturaItem)
    Public Property estado As String
End Class
