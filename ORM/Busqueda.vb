Public Class Busqueda

    Shared Function buscar(palabra As String) As List(Of BE.Busqueda)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Busqueda)
        Try
            h.Add("@Palabra", palabra)
            Dim ds = d.Leer("sp_busqueda", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim b As New BE.Busqueda
                    b.id = row("id")
                    b.pagina = row("pagina")
                    Dim pagina = Split(b.pagina, ".", -1)
                    b.pagina = pagina(0)
                    b.url = row("pagina")
                    b.palabra = row("palabra")
                    b.publico = row("publico")
                    lista.add(b)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
