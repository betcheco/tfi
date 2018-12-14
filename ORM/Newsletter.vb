Public Class Newsletter

    Shared Function subscribir(pnews As BE.Newsletter) As Boolean
        Dim h As New Hashtable
        Dim d As New DAL.Datos
        Dim id As Integer
        Try
            h.Add("@Email", pnews.email)
            id = d.EscribirInt("sp_subscripcion_newsletter", h)
            For Each cat In pnews.categorias
                Dim h2 As New Hashtable
                h2.Add("@Id_news", id)
                h2.Add("@Id_cat", cat.id)
                d.Escribir("sp_asignar_cat_news", h2)
            Next
            If id > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function listar(id_cat As Integer) As List(Of BE.Newsletter)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim listaN As New List(Of BE.Newsletter)
        Try
            h.Add("@Id_cat", id_cat)
            Dim ds = d.Leer("sp_listar_newsletter", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim n As New BE.Newsletter
                    n.id = row("id")
                    n.email = row("email")
                    listaN.Add(n)
                Next
            End If
            Return listaN

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function baja(pn As BE.Newsletter) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@Id", pn.id)
            Return d.Escribir("sp_baja_news", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


