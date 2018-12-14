<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="ABMEncuestas.aspx.vb" Inherits="Index.ABMEncuestas" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <div class="flex-row">
        <Label runat="server"  for="grd" class="page-title">Encuestas</Label>
    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" Width="600px" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-eraser"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="vencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="activo" HeaderText="Activa">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView>
        <Label runat="server"  for="gridFichas" class="page-title">Ficha de opinion</Label>
           <asp:GridView ID="gridFichas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" Width="600px" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-eraser"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="vencimiento" HeaderText="Vencimiento" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="activo" HeaderText="Activa">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView>
        </div>
    
    <asp:Button class="btn btn-primary mt-1" ID="btnNuevo" runat="server" Text="Nuevo" formnovalidate />
        <a class="d-block small mt-3 ml-2" href="Home.aspx">Ir a inicio</a>
  
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

  <%--  <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
			--%>

</asp:Content>
