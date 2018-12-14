Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hidePublicUser()

    End Sub



    Sub hidePublicUser()
        If Session("user") Is Nothing Then
            Master.FindControl("btnIngresarNavbar").Visible = True
            'btnIngresarNavBar.Visible = True
            'navbarSeparador.Visible = False
            'username.Visible = False
            Master.FindControl("logoutOption").Visible = False
            'btnMyProgressSidebar.Visible = False
            'btnProfileSidebar.Visible = False
            'btnSecuritySidebar.Visible = False
            'btnClasificadosSidebar.Visible = True
        End If

    End Sub



End Class