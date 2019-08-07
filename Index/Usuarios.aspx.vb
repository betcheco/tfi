Public Class Usuarios
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegUsuariosSideBar") Then
                Actualizar()
            Else
                Response.Redirect("Home.aspx")
            End If

        End If
    End Sub

    Sub Actualizar()
        grdUsers.DataSource = BLL.Usuario.Listar()
        grdUsers.DataBind()

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("NewUser.aspx")
    End Sub

    Protected Sub grdUsers_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdUsers.RowDeleting
        Dim user As New BE.Usuario
        'MsgBox(Me.grdUsers.DataKeys(e.RowIndex).Value)
        'MsgBox("Email?  " & grdUsers.Rows(e.RowIndex).Cells(3).Text)
        user.email = grdUsers.Rows(e.RowIndex).Cells(3).Text
        user = BLL.Usuario.BuscarUsuario(user)
        user.activo = 0
        If BLL.Usuario.ModificarUsuario(user) Then
            bitacora.criticidad = 4
            bitacora.evento = "Se elimino el usuario: " & user.email
            bitacora.usuario = "prueba"
            BLL.Bitacora.RegistarEvento(bitacora)
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "Se elimino el usuario " & user.email & " con exito", "Usuarios.aspx")
            Actualizar()
        Else
            'error al eliminar el usuario

        End If
        'Response.Redirect("NewUser.aspx?user="& user.email)
    End Sub



    Protected Sub grdUsers_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdUsers.SelectedIndexChanging
        'MsgBox(Me.grdUsers.DataKeys(e.NewSelectedIndex).Value)
        ' MsgBox("Email?= " & Me.grdUsers.Rows(e.NewSelectedIndex).Cells(3).Text)
        Response.Redirect("NewUser.aspx?user=" & Me.grdUsers.Rows(e.NewSelectedIndex).Cells(3).Text)
    End Sub
End Class