﻿Public Class Backup
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegBackupSideBar") Then

                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
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
            bitacora.criticidad = 4
            bitacora.evento = "Se genero el backup: " & backup.name
            bitacora.usuario = Session("currentUser").email
            BLL.Bitacora.RegistarEvento(bitacora)
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Exito", "El backup se realizo con exito", "Home.aspx")
        Else
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error al realizar el backup", "Backup.aspx")
        End If
    End Sub
End Class