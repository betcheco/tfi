Public Class Backup
    Public Shared Function RealizarBackup(pBackup As BE.Backup) As Boolean
        Try
            Return ORM.Backup.RealizarBackup(pBackup)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function RealizarRestore(pBackup As BE.Backup) As Boolean
        Try
            Return ORM.Backup.RealizarRestore(pBackup)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
