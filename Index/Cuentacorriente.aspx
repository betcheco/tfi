﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Cuentacorriente.aspx.vb" Inherits="Index.Cuentacorriente" %>

<%@ Register Src="~/UserControls/ModalRating.ascx" TagPrefix="uc1" TagName="ModalRating" %>
<%@ Register Src="~/UserControls/ModalEstado.ascx" TagPrefix="uc2" TagName="ModalEstado" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager runat="server"></asp:ScriptManager>--%>
    <div class="text-center">
        <h5>Cuenta Corriente</h5>
    </div>
    <h4 id="sinresultados" class=" alert-info" runat="server" visible="false">No se encontraron resultados</h4>
    <div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-striped table-light table-hover w-100" AllowPaging="True" >
         <Columns>
            <asp:ButtonField CommandName="ViewPdf" ShowHeader="True" Text='<i class="far fa-file-pdf"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="fecha" HeaderText="Fecha" ApplyFormatInEditMode="True" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Detalle">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="tcomprobante" HeaderText="Tipo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="nroCromprobante" HeaderText="Nº Comp.">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="debe" HeaderText="Debe" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="haber" HeaderText="Haber" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="75px" />
            </asp:BoundField>
            <asp:BoundField DataField="estado" HeaderText="Estado">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
                <ItemTemplate>
                    <ajaxToolkit:Rating 
                        ID="rating" 
                        runat="server"
                        StarCssClass="Star" 
                        WaitingStarCssClass="WaitingStar" 
                        EmptyStarCssClass="Star"
                        FilledStarCssClass="FilledStar"
                        ReadOnly ="true"
                        CurrentRating = '<%#Eval("calificacion") %>'
                    >
                    </ajaxToolkit:Rating>
                    <span id="spnGuion" runat="server">-</span>
                 <asp:LinkButton ID="btnCalificar" runat="server" CommandName="Calificar" CommandArgument='<%#Eval("operacionId") %>'>Calificar</asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnNoMessage" runat="server" CommandName="Message" CommandArgument='<%#Eval("operacionId") %>'><i class="far fa-comments"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnMessageSent" runat="server" CommandName="Message" CommandArgument='<%#Eval("operacionId") %>'><i class="fas fa-comments"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnMessageReceived" runat="server" CommandName="Message" CommandArgument='<%#Eval("operacionId") %>'><i class="far fa-envelope"></i></asp:LinkButton>
                     <asp:LinkButton ID="btnMessageRead" runat="server" CommandName="Message" CommandArgument='<%#Eval("operacionId") %>'><i class="fas fa-check-double"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnChangeState" runat="server" CommandName="ChangeState" CommandArgument='<%#Eval("operacionId") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                     <asp:LinkButton ID="btnAskCancel" runat="server" CommandName="AskCancel" CommandArgument='<%#Eval("operacionId") %>'><i class="fas fa-dollar-sign"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             </Columns>
      
    </asp:GridView>
        </div>
      
    <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir al inicio</a>
            </div>

    <uc1:ModalRating runat="server" id="ModalRating" />
    <uc2:ModalEstado runat="server" id="ModalEstado" />
</asp:Content>  
