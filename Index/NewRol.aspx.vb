Public Class NewRol
    Inherits System.Web.UI.Page
    Dim bitacora As New BE.Bitacora
    Dim modRol As BE.Rol



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            Actualizar()
            If Request.QueryString.HasKeys Then
                modRol = New BE.Rol
                modRol.id = Request.QueryString("id")
                modRol = BLL.Rol.ObtenerRol(modRol)
                inputNombre.Text = modRol.nombre
                inputDescripcion.Text = modRol.descripcion
                'Actualizar()
                For Each permiso As BE.Permiso In modRol.permisos 'Recorro los permisos del usuario
                    For Each row As GridViewRow In grdPermisos.Rows 'recorro las filas de la grilla
                        If row.RowType = DataControlRowType.DataRow Then
                            Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                            Dim cid As Integer = CInt(row.Cells(1).Text)
                            If (cid = permiso.id) Then 'si el id de la fila coincide con el id del permiso, lo chequeo
                                chkRow.Checked = True
                            End If
                        End If
                    Next
                Next
            Else
                'Es un nuevo rol
            End If
        Else
            If Request.QueryString.HasKeys Then
                modRol = New BE.Rol
                modRol.id = Request.QueryString("id")
                modRol = BLL.Rol.ObtenerRol(modRol)
            End If
        End If






    End Sub

    Sub Actualizar()
        grdPermisos.DataSource = BLL.Permiso.Listar()
        grdPermisos.DataBind()
    End Sub

    'Protected Sub chk_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim chkStatus As CheckBox = sender
    '    Dim row As GridViewRow = chkStatus.NamingContainer

    '    Dim cid = row.Cells(1).Text
    '    Dim status = chkStatus.Checked



    '    MsgBox("Permiso seleccionado: " & cid & " esta checkeado: " & status)
    'End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim listaSeleccionados As New List(Of BE.Permiso)
        Dim listaDesasignar As New List(Of BE.Permiso)
        If modRol Is Nothing Then
            Dim rol As New BE.Rol

            For Each row As GridViewRow In grdPermisos.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                    If chkRow.Checked Then
                        Dim permiso As New BE.Permiso
                        Dim cid As String = row.Cells(1).Text
                        permiso.id = row.Cells(1).Text
                        permiso.nombre = row.Cells(2).Text
                        permiso.descripcion = row.Cells(3).Text
                        listaSeleccionados.Add(permiso)
                        'MsgBox("Permiso seleccionado: " & cid)
                    End If
                End If
            Next

            rol.permisos = listaSeleccionados
            rol.nombre = inputNombre.Text
            rol.descripcion = inputDescripcion.Text

            Dim result = BLL.Rol.Crear(rol)

            If result Then
                bitacora.criticidad = 4
                bitacora.evento = "Se creo un nuevo rol: " & rol.nombre
                BLL.Bitacora.RegistarEvento(bitacora)
                Response.Redirect("Roles.aspx")
            Else
                'Mostrar error de creacion de rol
                MsgBox("Error")

                Response.Redirect("Roles.aspx")
            End If

        Else
            'modificar rol
            For Each row As GridViewRow In grdPermisos.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                    If chkRow.Checked Then
                        Dim permiso As New BE.Permiso
                        Dim cid As String = row.Cells(1).Text
                        permiso.id = row.Cells(1).Text
                        permiso.nombre = row.Cells(2).Text
                        permiso.descripcion = row.Cells(3).Text
                        listaSeleccionados.Add(permiso)
                        'MsgBox("Permiso seleccionado: " & cid)
                    End If
                End If
            Next


            modRol.nombre = Me.inputNombre.Text
            modRol.descripcion = Me.inputDescripcion.Text
            modRol.permisos = listaSeleccionados

            BLL.Rol.ModificarRol(modRol)
            bitacora.criticidad = 4
            bitacora.evento = "Se modifico el rol: " & modRol.nombre
            BLL.Bitacora.RegistarEvento(bitacora)
            Response.Redirect("Roles.aspx")

        End If





    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Roles.aspx")
    End Sub

    Protected Sub grdPermisos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdPermisos.PageIndexChanging
        grdPermisos.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub
End Class