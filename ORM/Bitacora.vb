Public Class Bitacora

    Public Shared Sub RegistrarEvento(pBitacora As BE.Bitacora)
        Dim htable As New Hashtable
        Dim d As New DAL.Datos
        Try
            pBitacora.usuario = Helpers.Hasher.Encriptar(pBitacora.usuario)
            htable.Add("@Usuario", pBitacora.usuario)
            htable.Add("@Criticidad", pBitacora.criticidad)
            htable.Add("@Evento", pBitacora.evento)


            d.Escribir("sp_registrar_bitacora", htable)
        Catch ex As Exception
            Console.WriteLine("Error en ORM Bitacora" & ex.Message)
        End Try
    End Sub

    'filtros completos
    Public Shared Function ConsultarBitacora(pFechaDesde As Date, pFechaHasta As Date, pCriticidad As Integer, pUsuario As String) As List(Of BE.Bitacora)
        Dim d As New DAL.Datos
        Dim htable As New Hashtable
        'htable.Add("@Fdesde", CDate(pFechaDesde).ToString("dd/MM/yyyy") + " 00:00")
        'htable.Add("@Fhasta", CDate(pFechaHasta).ToString("dd/MM/yyyy") + " 23:59")
        If Not pFechaDesde = CType("01/01/1990", Date) Then
            htable.Add("@Fdesde", CDate(pFechaDesde).ToString("yyyyMMdd"))
        End If
        If Not pFechaHasta = CType("01/01/1990", Date) Then
            htable.Add("@Fhasta", CDate(pFechaHasta).ToString("yyyyMMdd"))
        End If

        If Not pCriticidad = 0 Then
            htable.Add("@Criticidad", pCriticidad)
        End If

        If Not pUsuario Is Nothing Then
            htable.Add("@Usuario", pUsuario)
        End If
        Dim listaBitacora As New List(Of BE.Bitacora)
        Dim ds = d.Leer("sp_listar_bitacora", htable)
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                For Each i In ds.Tables(0).Rows
                    Dim oBitacora = New BE.Bitacora
                    'ASIGNO LAS VARIABLES AL OBJETO 
                    oBitacora.id = i("id")
                    oBitacora.fecha = CDate(i("fecha"))
                    oBitacora.usuario = Helpers.Hasher.Desencriptar(i("usuario"))
                    oBitacora.evento = i("evento")
                    oBitacora.criticidad = i("criticidad")
                    oBitacora.descripcion = i("descripcion")


                    'ETC

                    'AGREGO EL OBJETO A LA LISTA
                    listaBitacora.Add(oBitacora)
                Next

            End If

        Catch ex As Exception
            Console.WriteLine("Error listando eventos en ORM: " & ex.Message)
            Throw ex
        End Try
        Return listaBitacora
    End Function

    'FIltro por fechas

    Public Shared Function ConsultarBitacora(pFechaDesde As Date, pFechaHasta As Date) As List(Of BE.Bitacora)
        Dim d As New DAL.Datos
        Dim htable As New Hashtable
        htable.Add("@Fdesde", pFechaDesde)
        htable.Add("@Fhasta", pFechaHasta)
        Dim listaBitacora As New List(Of BE.Bitacora)
        Dim ds = d.Leer("sp_listar_bitacora", htable)
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                For Each i In ds.Tables(0).Rows
                    Dim oBitacora = New BE.Bitacora
                    'ASIGNO LAS VARIABLES AL OBJETO 
                    oBitacora.id = i("id")
                    oBitacora.fecha = i("fecha")
                    oBitacora.usuario = Helpers.Hasher.Desencriptar(i("usuario"))
                    oBitacora.evento = i("evento")
                    oBitacora.criticidad = i("criticidad")
                    oBitacora.descripcion = i("descripcion")


                    'ETC

                    'AGREGO EL OBJETO A LA LISTA
                    listaBitacora.Add(oBitacora)
                Next

            End If

        Catch ex As Exception
            Console.WriteLine("Error listando eventos en ORM: " & ex.Message)
        End Try
        Return listaBitacora
    End Function

    'filtro por criticidad
    Public Shared Function ConsultarBitacora(pCriticidad As Integer) As List(Of BE.Bitacora)
        Dim d As New DAL.Datos
        Dim htable As New Hashtable
        htable.Add("@Criticidad", pCriticidad)
        Dim listaBitacora As New List(Of BE.Bitacora)
        Dim ds = d.Leer("sp_listar_bitacora", htable)
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                For Each i In ds.Tables(0).Rows
                    Dim oBitacora = New BE.Bitacora
                    'ASIGNO LAS VARIABLES AL OBJETO 
                    oBitacora.id = i("id")
                    oBitacora.fecha = i("fecha")
                    oBitacora.usuario = Helpers.Hasher.Desencriptar(i("usuario"))
                    oBitacora.evento = i("evento")
                    oBitacora.criticidad = i("criticidad")
                    oBitacora.descripcion = i("descripcion")


                    'ETC

                    'AGREGO EL OBJETO A LA LISTA
                    listaBitacora.Add(oBitacora)
                Next

            End If

        Catch ex As Exception
            Console.WriteLine("Error listando eventos en ORM: " & ex.Message)
        End Try
        Return listaBitacora
    End Function
    'sin filtros
    Public Shared Function ConsultarBitacora() As List(Of BE.Bitacora)
        Dim d As New DAL.Datos
        Dim listaBitacora As New List(Of BE.Bitacora)
        Dim ds = d.Leer("sp_listar_bitacora", Nothing)
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                For Each i In ds.Tables(0).Rows
                    Dim oBitacora = New BE.Bitacora
                    'ASIGNO LAS VARIABLES AL OBJETO 
                    oBitacora.id = i("id")
                    oBitacora.fecha = i("fecha")
                    oBitacora.usuario = Helpers.Hasher.Desencriptar(i("usuario"))
                    oBitacora.evento = i("evento")
                    oBitacora.criticidad = i("criticidad")
                    oBitacora.descripcion = i("descripcion")


                    'ETC

                    'AGREGO EL OBJETO A LA LISTA
                    listaBitacora.Add(oBitacora)
                Next

            End If

        Catch ex As Exception
            Console.WriteLine("Error listando eventos en ORM: " & ex.Message)
        End Try
        Return listaBitacora
    End Function
End Class
