Public Class usrCtrlTable
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub Cargar(lista)
        grd.DataSource = lista
        grd.DataBind()
    End Sub

    Sub cargarPermisos(pPermisos As List(Of BE.Permiso))

        For Each permiso In pPermisos 'Recorro los permisos del usuario
            For Each row As GridViewRow In grd.Rows 'recorro las filas de la grilla
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                    Dim cid As Integer = CInt(row.Cells(1).Text)
                    If (cid = permiso.id) Then 'si el id de la fila coincide con el id del permiso, lo chequeo
                        chkRow.Checked = True
                    End If
                End If
            Next
        Next

    End Sub


    Sub cargarRoles(pRoles As List(Of BE.Rol))

        For Each rol In pRoles 'Recorro los permisos del usuario
            For Each row As GridViewRow In grd.Rows 'recorro las filas de la grilla
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                    Dim cid As Integer = CInt(row.Cells(1).Text)
                    If (cid = rol.id) Then 'si el id de la fila coincide con el id del permiso, lo chequeo
                        chkRow.Checked = True
                    End If
                End If
            Next
        Next

    End Sub



    Function permisosSeleccionados() As List(Of BE.Permiso)
        Dim listaSeleccionados As New List(Of BE.Permiso)
        For Each row As GridViewRow In grd.Rows
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

        Return listaSeleccionados
    End Function


    Function rolesSeleccionados() As List(Of BE.Rol)
        Dim listaSeleccionados As New List(Of BE.Rol)
        For Each row As GridViewRow In grd.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chk"), CheckBox)
                If chkRow.Checked Then
                    Dim permiso As New BE.Rol
                    Dim cid As String = row.Cells(1).Text
                    permiso.id = row.Cells(1).Text
                    permiso.nombre = row.Cells(2).Text
                    permiso.descripcion = row.Cells(3).Text
                    listaSeleccionados.Add(permiso)
                    'MsgBox("Permiso seleccionado: " & cid)
                End If
            End If
        Next

        Return listaSeleccionados
    End Function


End Class