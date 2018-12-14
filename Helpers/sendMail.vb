Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Web

Public Class sendMail

    ''Public Property path = Server.MapPath("emailTemplates/emailTemplate.html")
    'Shared Function CreateBody(username As String, tittle As String, message As String) As String
    '    Dim body As String = String.Empty

    '    Using reader As New StreamReader(Path)


    '        body = reader.ReadToEnd

    '        body = body.Replace("{UserName}", username) ' //replacing the required things  

    '        body = body.Replace("{Title}", tittle)

    '        body = body.Replace("{message}", message)


    '        Return body

    '    End Using
    'End Function

    Public Shared Sub generarComprobante(comprobante As String, facturaId As String, razonSocial As String, fecha As String, descripcion As String, total As String, mail As String)
        Dim Renderer = New IronPdf.HtmlToPdf()
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "emailTemplates\factura.html"
        Dim str = New StreamReader(FilePath)
        Dim body = str.ReadToEnd()

        body = body.Replace("{comprobante}", comprobante)
        body = body.Replace("{fecha}", fecha)
        body = body.Replace("{cliente}", razonSocial)
        body = body.Replace("{servicio}", descripcion)
        body = body.Replace("{total}", total)

        Dim name_comprobante = comprobante & "_" & Right("0000" & facturaId, 4)
        Dim name = "comprobantes\" & name_comprobante & ".pdf"

        Dim PDF = Renderer.RenderHtmlAsPdf(body)
        Dim OutputPath = HttpContext.Current.Server.MapPath("~") & name
        PDF.SaveAs(OutputPath)

        'Helpers.sendMail.send(name_comprobante, body, mail)

    End Sub




    Public Shared Sub send(subject As String, body As String, toMail As String)




        Using mm As New MailMessage("golftracking2018@gmail.com", toMail)
            mm.Subject = subject
            '        Dim body As String = "Hola " + txtEmail.Text.Trim() + ","
            '        body += "<br /><br />Por favor ingresa en este link para activar tu cuenta"
            '        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("VB.aspx", Convert.ToString("VB_Activation.aspx?ActivationCode=") & activationCode) + "'>Click aqui.</a>"
            '        body += "<br /><br />Gracias"
            mm.Body = body
            mm.IsBodyHtml = True
            Dim smtp As New SmtpClient()
            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            Dim NetworkCred As New NetworkCredential("golftracking2018@gmail.com", "Golf*2018")
            smtp.UseDefaultCredentials = True
            smtp.Credentials = NetworkCred
            smtp.Port = 587

            Try
                smtp.Send(mm)

            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Sub

    Public Shared Sub enviarNewsletter(ptitulo As String, pDesc As String, pIdAnuncio As String, pImg As String, pMail As String)
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~") & "emailTemplates\newsletter.html"
        Dim str = New StreamReader(FilePath)
        Dim body = str.ReadToEnd()

        body = body.Replace("{titulo}", ptitulo)
        body = body.Replace("{descripcion}", pDesc)
        body = body.Replace("{id_noticia}", pIdAnuncio)
        body = body.Replace("{imagen}", pImg)


        Helpers.sendMail.send("Tenemos algo que contarte", body, pMail)
    End Sub

End Class
