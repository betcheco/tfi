<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Encuesta.aspx.vb" Inherits="Index.Encuesta" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div id="divCampos" runat="server" class="form-group row mt-3">
            <div class="col-3">
                <asp:Label runat="server" for="txtDescription">Pregunta:</asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" class="form-control" placeholder="Pregunta de la encuesta" required MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label runat="server" for="chkActivo">Ficha de opinion:</asp:Label>
                <asp:CheckBox ID="chkFOpinion" runat="server" class="form-control" Text="Ficha de Opinion"></asp:CheckBox>
            </div>
            <div class="col-3">
                <asp:Label runat="server" for="inputVencimiento">Vencimiento:</asp:Label>
                <asp:TextBox ID="inputVencimiento" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div id="divContOpciones" runat="server" class="form-group row mt-3">
            <div class="col-6">
                <asp:Label runat="server" for="divOpciones">Opciones:</asp:Label>
                <div runat="server" id="divOpciones" class="form-control" style="display: flex; flex-direction: column; height: auto">
                    <asp:Repeater ID="rptOpciones" runat="server">
                        <ItemTemplate>
                            <div style="width: 100%; display: flex;">
                                <div style="flex-grow: 1">
                                    <%# Container.DataItem.ToString() %>
                                </div>
                                <div style="flex-shrink: 0">
                                    <asp:LinkButton
                                        runat="server"
                                        ID="btnQuitar"
                                        CommandName="Remove"
                                        UseSubmitBehavior="false"
                                        CommandArgument='<%# Container.ItemIndex %>'>
                                        <i class="fas fa-eraser"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button class="btn btn-primary btn-sm mt-2" ID="btnAgregar" runat="server" Text="Agregar" formnovalidate />
                <div id="divAddOpcion" runat="server" visible="false">
                    <label for="txtOpcion" class="mt-1">Escriba la opción:</label>
                    <asp:TextBox CssClass="form-control" ID="txtOpcion" runat="server"></asp:TextBox>
                    <asp:Button class="btn btn-outline-success mt-1" ID="addOpcion" runat="server" Text="Aceptar" formnovalidate />
                     <asp:Button class="btn btn-outline-danger mt-1" ID="btnCancelOpcion" runat="server" Text="Cancelar" formnovalidate />
                    </div>
                </div>
                    
            </div>
        </div>
        <div id="divBtnGuardar" runat="server" class="form-group row mt-5">
            <div class="col-3">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
                <a class="d-block small mt-3" href="ABMEncuestas.aspx">Volver</a>
            </div> 
            
        </div>

        <div id="divChart" runat="server" class="form-group row mt-5">
            <div class="col-6">
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



    </div>

 <%--   <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="ABMEncuestas.aspx">Volver</a>
            </div>--%>
</asp:Content>
