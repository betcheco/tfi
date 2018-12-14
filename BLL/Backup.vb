Public Class Backup
    Public Shared Function RealizarBackup(pBackup As BE.Backup) As Boolean
        Return ORM.Backup.RealizarBackup(pBackup)
    End Function

    Public Shared Function RealizarRestore(pBackup As BE.Backup) As Boolean
        Return ORM.Backup.RealizarRestore(pBackup)
    End Function

End Class
