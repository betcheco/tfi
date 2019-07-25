<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Chat.aspx.vb" Inherits="Index.Chat" %>

<%@ Register Src="~/UserControls/chatComment.ascx" TagPrefix="uc1" TagName="chatComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="display: flex; flex-direction: column; height: 100%; padding: 2vw">

        
        <div class="form-control h-75" style="display: flex; flex-direction: column; padding: 1vw; flex-grow: 1; overflow-y: scroll;">
            <div id="divMensajes" runat="server" style="flex-direction: column;">
            </div>
        </div>
        <div id="divInput" runat="server" style="display: flex; flex-direction: row; margin-top: 10px;">
            <asp:TextBox ID="txtInput" runat="server" class="form-control" MaxLength="250" Style="margin-right: 10px" placeholder="Escriba aquí su mensaje"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnEnviar" runat="server" Text="Enviar" />
        </div>
    </div>
      <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Cuentacorriente.aspx">Volver</a>
            </div>
</asp:Content>
