Public Class Anuncio
    Public Shared Function Listar(pAnuncio As BE.Anuncio) As List(Of BE.Anuncio)
        Try
            Return ORM.Anuncio.Listar(pAnuncio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Modificar(pAnuncio As BE.Anuncio) As Boolean
        Try
            Return ORM.Anuncio.Modificar(pAnuncio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Crear(pAnuncio As BE.Anuncio) As Boolean
        Try
            Return ORM.Anuncio.Crear(pAnuncio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ObtenerAnuncio(pAnuncio As BE.Anuncio) As BE.Anuncio
        Try
            Return ORM.Anuncio.obtenerAnuncio(pAnuncio)
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Public Shared Function Filtrar(pCat As BE.Categoria, pMin As Double, pMax As Double) As List(Of BE.Anuncio)
        Try
            Return ORM.Anuncio.Filtrar(pCat, pMin, pMax)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
