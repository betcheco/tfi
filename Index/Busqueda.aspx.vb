Imports BE

Public Class Busqueda
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Request.QueryString("palabra") Is Nothing Then
                Try
                    Dim palabra As String = Request.QueryString("palabra")
                    Dim Busqueda As New List(Of BE.Busqueda)
                    Busqueda = BLL.Busqueda.buscar(palabra)

                    mostrarResultados(Busqueda)
                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Home.aspx")
                End Try


            Else
                Response.Redirect("Home.aspx")
            End If

        End If
    End Sub

    Private Sub mostrarResultados(busqueda As List(Of BE.Busqueda))
        Dim listaAMostrar As New List(Of BE.Busqueda)
        Try
            If Session("currentUser") Is Nothing Then
                For Each res In busqueda
                    If res.publico Then
                        listaAMostrar.Add(res)
                    End If
                Next
            Else
                For Each res In busqueda
                    If res.publico Then
                        listaAMostrar.Add(res)

                    Else
                        If BLL.Usuario.CheckPermiso(Session("currentUser"), res.permiso) Then
                            listaAMostrar.Add(res)
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, "Home.aspx")
        End Try
        If listaAMostrar.Count > 0 Then
            mensaje.InnerHtml = "Resultados para: " & Request.QueryString("palabra")
            divResultados.Visible = True
            Repeater1.DataSource = listaAMostrar
            Repeater1.DataBind()
        Else
            mensaje.InnerHtml = "No se encontraron resultados para: " & Request.QueryString("palabra")
            divResultados.Visible = False
        End If

    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Home.aspx")
    End Sub
End Class