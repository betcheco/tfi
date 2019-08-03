Public Class Restore
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegRestoreSideBar") Then

        Else
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
        End If
    End Sub

    Protected Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If Not FileUpload1.FileName Is Nothing Then
            Dim fileOK As Boolean
            Dim backup As New BE.Backup
            Dim path As String = Server.MapPath("~/backups/")
            backup.name = FileUpload1.FileName

            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Debug", FileUpload1.PostedFile.ToString(), Nothing)

            Try
                FileUpload1.PostedFile.SaveAs(path &
                         FileUpload1.FileName)
                fileOK = True
            Catch ex As Exception
                fileOK = False
                'MsgBox(ex.Message)
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error al realizar al subir el archivo " & ex.Message, "Restore.aspx")
            End Try

            If fileOK Then
                Try
                    backup.path = ("C:\Temp\" & FileUpload1.FileName)
                    'MsgBox(backup.path)
                    If BLL.Backup.RealizarRestore(backup) Then
                        bitacora.criticidad = 4
                        bitacora.evento = "Se restauro la db del backup: " & backup.name
                        bitacora.usuario = Session("currentUser").email
                        BLL.Bitacora.RegistarEvento(bitacora)
                        TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "Restore exitoso", "Home.aspx")
                    End If
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error al realizar el restore " & ex.Message, "Restore.aspx")
                    Console.WriteLine("Error en UI " & ex.Message)
                End Try

            End If

            'MsgBox(backup.name)

        Else
            'Mostrar error
        End If
    End Sub
End Class