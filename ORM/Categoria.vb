Public Class Categoria
    'Dim h As New Hashtable

    Shared Function obtenerCategoria(id As Integer) As BE.Categoria
        Try
            Dim h As New Hashtable
            Dim d As New DAL.Datos
            Dim result As New BE.Categoria
            h.Add("Id", id)
            Dim ds = d.Leer("sp_get_categoria", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    result.id = row("id")
                    result.nombre = row("nombre")
                Next
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Shared Function Listar() As List(Of BE.Categoria)
        Dim d As New DAL.Datos

        Dim lista As New List(Of BE.Categoria)

        Try
            Dim ds = d.Leer("sp_listar_categorias", Nothing)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim oCategoria As New BE.Categoria
                    oCategoria.id = row("id")
                    oCategoria.nombre = row("nombre")
                    lista.Add(oCategoria)
                Next

            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try
    End Function




End Class
