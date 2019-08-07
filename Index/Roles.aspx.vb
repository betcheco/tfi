Public Class Roles
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnSegRolesSideBar") Then
                    grdRoles.DataSource = BLL.Rol.Listar()
                    grdRoles.DataBind()
                Else
                    Response.Redirect("Home.aspx")
                End If
            Else
                Response.Redirect("Home.aspx")
            End If

        End If


    End Sub

    Protected Sub grdRoles_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdRoles.RowDeleting
        'MsgBox("Elimino el rol: " & Me.grdRoles.DataKeys(e.RowIndex).Value)
        Dim delRol As New BE.Rol
        delRol.id = Me.grdRoles.DataKeys(e.RowIndex).Value
        If Not delRol.id = 11 Xor Not delRol.id = 12 Xor Not delRol.id = 13 Then
            Try
                If BLL.Rol.Eliminar(delRol) Then
                    bitacora.criticidad = 4
                    bitacora.evento = "Se elimino el rol: " & delRol.id
                    bitacora.usuario = Session("currentUser").email
                    BLL.Bitacora.RegistarEvento(bitacora)
                    grdRoles.DataSource = BLL.Rol.Listar()
                    grdRoles.DataBind()
                Else

                End If
            Catch ex As Exception
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
            End Try
        Else
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Atencion", "Los roles del sistema no se pueden eliminar", Nothing)
        End If
    End Sub

    Protected Sub grdRoles_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grdRoles.SelectedIndexChanging
        'MsgBox("Selecciono el rol: " & Me.grdRoles.DataKeys(e.NewSelectedIndex).Value)
        Response.Redirect("NewRol.aspx?id=" & Me.grdRoles.DataKeys(e.NewSelectedIndex).Value)
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("NewRol.aspx")
    End Sub
End Class