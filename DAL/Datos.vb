Imports System.Data.SqlClient


Public Class Datos
    'ASUS
    'Const strConn As String = "Data Source=APU-PC\MSSQL;Initial Catalog=GolfTracking;Integrated Security=True"
    'UAI
    Const strConn As String = "Data Source = .\ SQL_UAI;Initial Catalog=GolfTracking;Integrated Security=True"
    'ofi
    'Const strConn As String = "Data Source=W10ETCHECOB\SQLEXPRESS;Initial Catalog=GolfTracking;Integrated Security=True"
    'Lenovo
    'Const strConn As String = "Data Source=PC-PC\SQLEXPRESS;Initial Catalog=GolfTracking;Integrated Security=True"


    Private Conn As New SqlConnection(strConn)
    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand

    Public Function Leer(query As String, h As Hashtable) As DataSet
        Dim ds As New DataSet
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try


            Cmd = New SqlCommand
            Cmd.Connection = Conn
            Cmd.CommandText = query
            Cmd.CommandType = CommandType.StoredProcedure
            If Not h Is Nothing Then
                For Each key In h.Keys
                    Cmd.Parameters.AddWithValue(key, h(key))
                Next
            End If
            Dim adapter As New SqlDataAdapter(Cmd)
            adapter.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            Conn.Close()
        End Try
    End Function

    Public Function Escribir(query As String, h As Hashtable) As Boolean
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try
            Tranx = Conn.BeginTransaction
            Cmd = New SqlCommand(query, Conn, Tranx)
            Cmd.CommandType = CommandType.StoredProcedure
            If Not h Is Nothing Then
                For Each key In h.Keys
                    Cmd.Parameters.AddWithValue(key, h(key))
                Next
            End If
            Cmd.ExecuteNonQuery()
            Tranx.Commit()

            Return True
        Catch ex As Exception
            Console.WriteLine("Se rompio Err en DAL" & ex.Message)
            Throw ex
            Tranx.Rollback()
            Return False
        Finally
            Conn.Close()

        End Try
    End Function

    Public Function EscribirInt(sp As String, h As Hashtable) As Object
        Dim Cnn As New SqlConnection(strConn)
        Dim cmd = Cnn.CreateCommand()
        cmd = New SqlCommand
        cmd.Connection = Cnn
        cmd.CommandText = sp
        cmd.CommandType = CommandType.StoredProcedure
        Try
            If Not h Is Nothing Then
                For Each key In h.Keys
                    cmd.Parameters.AddWithValue(key, h(key))
                Next
            End If

            Cnn.Open()
            Dim res = cmd.ExecuteScalar()
            Cnn.Close()
            Return res
        Catch ex As Exception
            Throw ex

        End Try



    End Function
End Class
