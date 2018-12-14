Imports BE

Public Class Encuesta

    Shared Function listar(FichaOpinion As Boolean) As List(Of BE.Encuesta)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim lista As New List(Of BE.Encuesta)
        Try
            h.Add("@fichaopinion", FichaOpinion)
            Dim ds = d.Leer("sp_listar_encuesta", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim e As New BE.Encuesta
                    e.id = row("id")
                    e.nombre = row("nombre")
                    e.vencimiento = CDate(row("vencimiento"))
                    e.activo = row("activo")
                    e.opciones = listarOpciones(e.id)
                    lista.Add(e)
                Next
            End If
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function listarOpciones(id As Integer) As List(Of EncuestaOpcion)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim listaOpciones As New List(Of BE.EncuestaOpcion)
        Try
            h.Add("@encuestaid", id)
            Dim ds = d.Leer("sp_listar_opciones_by_encuesta", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows
                    Dim o As New BE.EncuestaOpcion
                    o.id = row("id")
                    o.nombre = row("nombre")
                    o.valor = row("valor")
                    listaOpciones.Add(o)
                Next
            End If
            Return listaOpciones
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function obtenerEncuesta(id As Integer) As BE.Encuesta
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Dim result As New BE.Encuesta
        Try
            h.Add("@id", id)
            Dim ds = d.Leer("sp_get_encuesta_by_id", h)
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row In ds.Tables(0).Rows

                    result.id = row("id")
                    result.nombre = row("nombre")
                    result.vencimiento = CDate(row("vencimiento"))
                    result.activo = row("activo")
                    result.opciones = listarOpciones(result.id)
                Next
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function nuevo(ByRef pEncuesta As BE.Encuesta, fo As Boolean) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@nombre", pEncuesta.nombre)
            h.Add("@vencimiento", pEncuesta.vencimiento)
            h.Add("@fichaopinion", fo)

            Dim id As Integer = d.EscribirInt("sp_nuevo_encuesta", h)
            pEncuesta.id = id
            For Each o As EncuestaOpcion In pEncuesta.opciones
                addOpcion(pEncuesta, o)
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Function addOpcion(pEncuesta As BE.Encuesta, o As EncuestaOpcion) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@encuestaId", pEncuesta.id)
            h.Add("@nombre", o.nombre)
            Return d.Escribir("sp_nuevo_opcion", h)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Shared Function modificar(pEncuesta As BE.Encuesta) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id", pEncuesta.id)
            h.Add("@nombre", pEncuesta.nombre)
            h.Add("@vencimiento", pEncuesta.vencimiento)

            Return d.Escribir("sp_mod_encuenta", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Shared Sub votar(id As Integer)
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id", id)
            d.Escribir("sp_votar_encuesta_opcion", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Shared Function eliminar(id As Integer) As Boolean
        Dim d As New DAL.Datos
        Dim h As New Hashtable
        Try
            h.Add("@id", id)
            Return d.Escribir("sp_del_encuesta", h)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
