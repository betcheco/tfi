Imports System.Data.SqlClient

Public Class Backup
    Shared Function RealizarBackup(pBackup As BE.Backup) As Boolean
        ' Dim mstrConexion As String = "Data Source=APU-PC\MSSQL;Initial Catalog=GolfTracking;Integrated Security=True"
        'Dim mstrConexion As String = "Data Source=.\SQL_UAI;Initial Catalog=master;Integrated Security=True"
        'Lenovo
        Const mstrConexion As String = "Data Source=PC-PC\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"
        Dim mCon As SqlConnection
        Dim sqlBackup As String = "BACKUP DATABASE [GolfTracking] TO DISK = 'C:\Temp\" & pBackup.name & ".bak'"
        Try
            SqlConnection.ClearAllPools()
            mCon = New SqlConnection(mstrConexion)
            mCon.Open()
            Dim sqlCommand As New SqlCommand(sqlBackup, mCon)
            sqlCommand.ExecuteNonQuery()
            mCon.Close()
            mCon.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
            Console.WriteLine(ex.Message & "Error al querer backapear DB ")
            mCon.Close()
            mCon.Dispose()
            Return False
        End Try



    End Function

    Shared Function RealizarRestore(pBackup As BE.Backup) As Boolean
        Dim mCon As SqlConnection
        Dim discos As String = " DISK = '" & pBackup.path & "'"

        'Dim sqlRestore As String = "Alter Database [GolfTracking]  SET Single_user " &
        '                           "With Rollback Immediate;" &
        '                           "go;" &
        Dim sqlRestore As String = "USE [master] " &
                                    " RESTORE DATABASE [GolfTracking] FROM" &
                                    " " & discos &
                                    " WITH FILE = 1, " &
                                    " RECOVERY, " &
                                    " NOUNLOAD, " &
                                    " REPLACE, " &
                                    " STATS = 10; "
        '  "GO"
        '" ALTER DATABASE [GolfTracking] Set Multi_User;" &
        '"GO;"

        ' Dim mstrConexion As String = "Data Source=APU-PC\MSSQL;Initial Catalog=master;Integrated Security=True"
        Const mstrConexion As String = "Data Source=PC-PC\SQLEXPRESS;Initial Catalog=GolfTracking;Integrated Security=True"

        'MsgBox(sqlRestore)

        Try
            SqlConnection.ClearAllPools()
            mCon = New SqlConnection(mstrConexion)
            mCon.Open()
            Dim sqlCommand As New SqlCommand(sqlRestore, mCon)

            sqlCommand.ExecuteNonQuery()
            mCon.Close()
            mCon.Dispose()
            Return True
        Catch ex As Exception
            mCon.Close()
            mCon.Dispose()
            Console.WriteLine(ex.Message & "Error al querer restaurar DB ")
            Throw ex
            Return False
        End Try


    End Function
End Class
