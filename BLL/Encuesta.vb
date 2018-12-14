Public Class Encuesta

    Public Shared Function eliminar(id As Integer) As Boolean
        Try
            Return ORM.Encuesta.eliminar(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function listar(Optional FichaOpinion As Boolean = False) As List(Of BE.Encuesta)
        Try
            Return ORM.Encuesta.listar(FichaOpinion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function obtener(id As Integer) As BE.Encuesta
        Try
            Return ORM.Encuesta.obtenerEncuesta(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function nuevo(ByRef pencuesta As BE.Encuesta, Optional fichaopinion As Boolean = False) As Boolean
        Try
            Return ORM.Encuesta.nuevo(pencuesta, fichaopinion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function modificar(ByRef pencuesta As BE.Encuesta) As Boolean
        Try
            Return ORM.Encuesta.modificar(pencuesta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function listarOpciones(encuestaId As Integer) As List(Of BE.EncuestaOpcion)
        Try
            Return ORM.Encuesta.listarOpciones(encuestaId)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Sub votar(id As Integer)
        ORM.Encuesta.votar(id)
    End Sub

    Shared Function getRandom(Optional FichaOpinion As Boolean = False) As BE.Encuesta
        Try

            Dim encuestas = listar(FichaOpinion)
            Dim activas = encuestas.FindAll(Function(x) x.vencimiento > DateTime.Now And x.activo)
            If activas.Count > 0 Then
                Dim i = CInt(Math.Floor(Rnd() * activas.Count))
                Return activas(i)
            Else
                Return Nothing
            End If
        Catch ex As Exception

            Throw ex
        End Try
    End Function


End Class
