Imports System.IO
Imports System.Xml.Linq

Public Class Publicidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                If BLL.Usuario.CheckPermiso(Session("currentUser"), "btnPublicidadSideBar") Then
                    Actualizar()
                Else
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "No posee permisos para acceder a la pagina", "Home.aspx")
                End If

            Else
                Response.Redirect("Home.aspx")
            End If


        End If
    End Sub

    Private Function getDoc() As XDocument
        Dim xmlDoc = XDocument.Load(getDocPath)
        Return xmlDoc
    End Function

    Private Function getDocPath()
        Dim dir As String = HttpContext.Current.Server.MapPath("~")
        If Not dir.EndsWith("\") Then dir = dir & "\"
        dir = dir & "publicidades\"
        Return dir + "index.xml"
    End Function



    Private Sub Actualizar()

        Dim xmlDoc = getDoc()
        Dim Consulta = From Ad In xmlDoc.Descendants("Ad")
                       Select New With
                           {
                               .AlternateText = Ad.Element("AlternateText").Value,
                               .NavigateUrl = Ad.Element("NavigateUrl").Value,
                               .ImageUrl = Ad.Element("ImageUrl").Value
                           }

        Me.grd.DataSource = Consulta.ToList
        Me.grd.DataBind()

        btnNuevo.Visible = grd.Rows.Count > 0

        btnNuevo_Click(Nothing, Nothing)
        Me.divDatosEncuesta.Visible = False
    End Sub

    Protected Sub grd_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles grd.SelectedIndexChanging
        Me.divDatosEncuesta.Visible = True
        'Dim r As GridViewRow = Me.grd.Rows(e.NewSelectedIndex)
        ViewState("i") = e.NewSelectedIndex

        Dim xmlDoc = getDoc()
        Dim Consulta = From Ad In xmlDoc.Descendants("Ad")
                       Select New With
                           {
                               .AlternateText = Ad.Element("AlternateText").Value,
                               .NavigateUrl = Ad.Element("NavigateUrl").Value,
                               .ImageUrl = Ad.Element("ImageUrl").Value
                           }

        Dim lst = Consulta.ToList
        Dim o = lst(e.NewSelectedIndex)

        ViewState("ImageUrl") = o.ImageUrl

        Me.txtTitle.Text = o.AlternateText
        Me.txtURL.Text = o.NavigateUrl
        Me.imgPreview.ImageUrl = o.ImageUrl

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim alternateText = txtTitle.Text
        Dim navigateUrl = txtURL.Text
        Dim ImageUrl = Me.imgPreview.ImageUrl



        If ViewState("i") > -1 Then
            If Not Me.fuImagen.HasFile Then
                ImageUrl = ViewState("ImageUrl")
            Else
                Dim extension = System.IO.Path.GetExtension(Me.fuImagen.FileName)
                If extension <> ".jpg" And extension <> ".jpeg" And extension <> ".gif" And extension <> ".png" Then
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Seleccione una imagen para la publicidad", Nothing)
                    Me.fuImagen.Focus()
                    Return
                End If

                Dim file = "imagenes/" + fuImagen.FileName
                fuImagen.SaveAs(HttpContext.Current.Server.MapPath("~") & file)
                ImageUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + file
            End If

            Dim xmlDoc = getDoc()
            Dim el = xmlDoc.Descendants("Ad").ElementAt(ViewState("i"))
            el.SetElementValue("AlternateText", alternateText)
            el.SetElementValue("NavigateUrl", navigateUrl)
            el.SetElementValue("ImageUrl", ImageUrl)
            xmlDoc.Save(getDocPath())
        Else
            If Not Me.fuImagen.HasFile Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Seleccione una imagen para la publicidad", Nothing)
                Me.fuImagen.Focus()
                Return
            Else
                Dim extension = System.IO.Path.GetExtension(Me.fuImagen.FileName)
                If extension <> ".jpg" And extension <> ".jpeg" And extension <> ".gif" And extension <> ".png" Then
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Seleccione una imagen para la Novedad", Nothing)
                    Me.fuImagen.Focus()
                    Return
                End If
            End If

            Dim file = "img/" + fuImagen.FileName
            fuImagen.SaveAs(HttpContext.Current.Server.MapPath("~") & file)
            ImageUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + file

            Dim xmlDoc = getDoc()

            xmlDoc.Element("Advertisements").Add(New XElement("Ad",
                                         New XElement("ImageUrl", ImageUrl),
                                         New XElement("NavigateUrl", navigateUrl),
                                         New XElement("AlternateText", alternateText),
                                         New XElement("Impressions", "40"),
                                         New XElement("Keyword", alternateText)
                                         ))
            xmlDoc.Save(getDocPath())
        End If

        Actualizar()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.divDatosEncuesta.Visible = True
        ViewState("i") = -1

        Me.txtURL.Text = ""
        Me.txtTitle.Text = ""
        Me.imgPreview.ImageUrl = "Content/No_Image_Available.gif"
    End Sub

    Protected Sub grd_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grd.RowDeleting
        'Dim NovedadeId = grd.DataKeys(e.RowIndex).Value
        Try
            Dim xmlDoc = getDoc()
            xmlDoc.Descendants("Ad").ElementAt(e.RowIndex).Remove()
            xmlDoc.Save(getDocPath())
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Éxito", "Publicidad borrada", Nothing)

            Actualizar()
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)

        End Try
        Server.TransferRequest(Request.Url.AbsolutePath, False)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        Actualizar()
    End Sub

End Class