Public Class Comprar
    Inherits System.Web.UI.Page

    Dim bitacora As New BE.Bitacora
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            If Not Session("currentUser") Is Nothing Then
                Actualizar()
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Necesita estar logueado para acceder", "Home.aspx")
            End If

        End If
    End Sub

    Protected Sub row_checked(sender As Object, e As EventArgs)
        'MsgBox("row_cheked")
        Me.lblPrecio.InnerHtml = precioActualizado().ToString("C2")
    End Sub


    Sub Actualizar()
        If Request.QueryString.HasKeys Then
            If Not Request.QueryString("anuncio") Is Nothing Then
                Try
                    Dim anuncio As New BE.Anuncio
                    anuncio.id = Request.QueryString("anuncio")
                    anuncio = BLL.Anuncio.ObtenerAnuncio(anuncio)
                    Me.img.ImageUrl = anuncio.imagen
                    Me.lblTitulo.InnerText = anuncio.titulo
                    Me.lblPrecio.InnerText = "$" & anuncio.precio
                    Me.lblDescCorta.InnerText = anuncio.desc_corta

                    Dim listaNc As New List(Of BE.NotaCredito)
                    Dim notacred As New BE.NotaCredito
                    notacred.usuario = Session("currentUser")
                    listaNc = BLL.NotaCredito.Listar(notacred)
                    grd.DataSource = listaNc
                    grd.DataBind()

                    If listaNc.Count = 0 Then
                        Me.divNotasCredito.InnerText = "No posee notas de credito"
                    End If

                Catch ex As Exception
                    TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
                End Try
            Else
                Response.Redirect("Clasificados.aspx")
            End If
        Else
            Response.Redirect("Clasificados.aspx")
        End If
    End Sub

    Private Function CurrencyToDouble(ByVal CurrencyString As String) As Double
        Dim TempStr As New System.Text.StringBuilder
        For i As Integer = 0 To CurrencyString.Length - 1
            If CurrencyString(i) = "," Or CurrencyString(i) = "." Or (CurrencyString(i) >= "0" And CurrencyString(i) <= "9") Then
                TempStr.Append(CurrencyString(i))
            End If
        Next

        Dim MyDouble As Double
        If Double.TryParse(TempStr.ToString, MyDouble) = False Then
            MyDouble = -1
        End If
        Return MyDouble
    End Function

    Private Function precioActualizado() As Double
        Dim nc As Double = 0
        For Each r As GridViewRow In grd.Rows
            If TryCast(r.FindControl("chkSelect"), CheckBox).Checked Then
                nc += CurrencyToDouble(r.Cells(3).Text)
            End If
        Next



        Dim anuncio As New BE.Anuncio
        anuncio.id = Request.QueryString("anuncio")
        anuncio = BLL.Anuncio.ObtenerAnuncio(anuncio)

        Return Math.Max(0, anuncio.precio - nc)
    End Function

    Protected Sub btnConfirmarPago_Click(sender As Object, e As EventArgs) Handles btnConfirmarPago.Click
        Dim precio = precioActualizado()
        If precio > 0 Then
            'validar form
            If txtNroTarjeta.Text.Length < 19 Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "Número de tarjeta no válido", Nothing)
                Return
            End If
            If txtNombre.Text.Length < 1 Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "Nombre del titular no válido", Nothing)
                Return
            End If
            Dim thisDt As DateTime
            Dim expiracion = "01/" & txtExpiracion.Text
            Dim b = DateTime.TryParse(expiracion, thisDt)
            If expiracion.Length < 10 Or Not DateTime.TryParse(expiracion, thisDt) Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "Fecha de expiración no válida", Nothing)
                Return
            End If
            If thisDt < DateTime.Now Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "La tarjeta esta vencida", Nothing)
            End If
            If txtCodSeg.Text.Length < 3 Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "Código de seguridad no válido", Nothing)
                Return
            End If
            If txtDNI.Text.Length < 8 Then
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("", "Número de documento no válido", Nothing)
                Return
            End If
        End If

        Dim anuncio As New BE.Anuncio
        anuncio.id = Request.QueryString("anuncio")
        anuncio = BLL.Anuncio.ObtenerAnuncio(anuncio)

        'actualizar las nc (si las hubiera)
        Dim saldo = anuncio.precio
        For Each r As GridViewRow In grd.Rows
            If TryCast(r.FindControl("chkSelect"), CheckBox).Checked And saldo > 0 Then
                Dim nc As New BE.NotaCredito
                nc.id = grd.DataKeys(r.RowIndex).Value
                nc = BLL.NotaCredito.Obtener(nc)
                nc.saldo = CurrencyToDouble(r.Cells(3).Text)
                If nc.saldo < saldo Then
                    nc.saldo = 0
                    BLL.NotaCredito.Modificar(nc)
                Else
                    nc.saldo = nc.saldo - saldo
                    BLL.NotaCredito.Modificar(nc)
                End If
                saldo -= nc.saldo
            End If
        Next

        'Creo la factura
        Dim factura As New BE.Factura
        factura.fecha = Date.Now
        factura.usuario = Session("currentUser")

        'Creo el item de la factura y lo asigno
        Dim facturaItem = New BE.FacturaItem
        facturaItem.desc = anuncio.titulo
        facturaItem.monto = anuncio.precio
        factura.items.Add(facturaItem)

        Try
            If BLL.Factura.Crear(factura) Then
                bitacora.criticidad = 3
                bitacora.evento = "Compra realizada"
                bitacora.usuario = Session("currentUser").email
                BLL.Bitacora.RegistarEvento(bitacora)
                Helpers.sendMail.generarComprobante(
             "FACTURA",
             factura.id,
             factura.usuario.nombre & " " & factura.usuario.apellido,
             DateTime.Now.ToString("dd/MM/yyyy"),
             facturaItem.desc,
             facturaItem.monto.ToString(),
             Session("currentUser").email
         )
                Dim operacion As New BE.Operacion
                operacion.id_anuncio = anuncio.id
                operacion.id_comprador = Session("currentUser").id
                operacion.id_vendedor = anuncio.usuario_id
                operacion.id_factura = factura.id
                Session("operacionid") = BLL.Operacion.crear(operacion)
                Dim b As New BE.Bitacora
                b.usuario = Session("currentUser").email
                b.criticidad = 3
                b.evento = "Compra realizada"
                BLL.Bitacora.RegistarEvento(b)
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Operacion realizada con exito", "Gracias por tu compra, en breve te llegara un mail con la factura correspondiente", "Findecompra.aspx?anuncio=" & Request.QueryString("anuncio"))
            Else
                TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Sucedio un error en la operacion", Nothing)
            End If
        Catch ex As Exception
            TryCast(Me.Master, masterPrincipal).mostrarMesaje("Error", "Ups! " & ex.Message, Nothing)
        End Try




    End Sub
End Class