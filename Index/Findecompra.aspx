<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Findecompra.aspx.vb" Inherits="Index.Findecompra" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <!--ENCUESTA-->
            <div runat="server" id="divEncuesta" class="card">
                <div id="divEncuestaPreguntas" runat="server" class="card-body" visible="true">
                    <h5 class="card-title">Por favor, responde esta breve ficha de opinion</h5>
                    <p class="card-text" runat="server" id="encuestaText"></p>
                    <asp:Repeater ID="rptEncuestaOpciones" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton
                                class="btn btn-primary"
                                runat="server"
                                UseSubmitBehavior="false"
                                CommandArgument='<%# Eval("id") %>'>
                                <%# Eval("nombre") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div id="divEncuestaChart" runat="server" class="card-body" visible="false">
                    <h5 class="card-title">Resultados</h5>
                    <asp:Chart ID="chartEncuesta" runat="server" Style="max-width: 100%">
                        <Series>
                            <asp:Series Name="Series1"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>
   

        <div class="row mt-2 d-flex justify-content-center">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Compra" CssClass="btn-danger" />
            </div>
    
        <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
    
</asp:Content>
