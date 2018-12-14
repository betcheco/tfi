Public Class Backup
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegBackupSideBar") Then

            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
            End If
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim backup As New BE.Backup
        Dim fecha = DateTime.Now.ToString("yyyyMMddhhmm")
        'MsgBox(fecha.ToString)


        backup.name = "GolfTracking_" & fecha.ToString
        If BLL.Backup.RealizarBackup(backup) Then
            'Muestro mensaje de exito
            bitacora.criticidad = 5
            bitacora.evento = "Se genero el backup: " & backup.name
            bitacora.usuario = ""
            BLL.Bitacora.RegistarEvento(bitacora)
        Else
            'Error en el backup
        End If
    End Sub
End Class