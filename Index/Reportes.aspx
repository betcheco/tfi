<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Reportes.aspx.vb" Inherits="Index.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .bg-color-green {
    background-color: #fff;
    color: #5cb85c;
}
.back-footer-green {
background-color: #5cb85c;
color:#fff;
border-top: 0px solid #fff;
}
 .back-footer-red {
background-color: #F0433D;
color:#fff;
border-top: 0px solid #fff;
}
 .back-footer-blue {
background-color: #4CB1CF;
color:#fff;
border-top: 0px solid #fff;
}
 .back-footer-brown {
background-color: #f0ad4e;
color:#fff;
border-top: 0px solid #fff;
}
     .bg-color-green {
background-color: #fff;
color: #5cb85c;
}
 .bg-color-blue {
background-color: #fff;
color: #4CB1CF
}
  .bg-color-red {
background-color: #fff;
color:#F0433D;
}
  .btn-outline-danger:active{
      background-color: #F0433D;
      color:#fff;
  }

  .bg-color-brown {
background-color: #fff;
color:#f0ad4e;
}

  .btn-chats-active{
      background-color: #F0433D;
      color:white;  
  }

  .btn-fichas-active{
      background-color:forestgreen;
      color:white;
  }

  .btn-ganancias-active{
      background-color:#4CB1CF;
      color:white;
  }

  .btn-encuestas-active{
      background-color:yellow;
      color:black;
      
  }


    </style>
    <!--Botones de reportes-->
    <div class="row">
        <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="card panel-primary text-center no-boder bg-color-green">
                <div class="panel-body">
                </div>      
                <asp:LinkButton ID="btnFichas" runat="server" CssClass="btn-outline-success">Fichas de opinion</asp:LinkButton>
            </div>
        </div>
        <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="card panel-primary text-center no-boder bg-color-blue">
                <div class="panel-body">
                </div>
                <asp:LinkButton ID="btnGanancias" runat="server" CssClass="btn-outline-info">Ganancias</asp:LinkButton>
            </div>
        </div>
        <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="card panel-primary text-center no-boder bg-color-red">
                <div class="panel-body">
                </div>
                <asp:LinkButton ID="btnChats" runat="server" CssClass="btn-outline-danger">Tiempo de respuesta</asp:LinkButton>
            </div>
        </div>
        <div class="col-md-3 col-sm-12 col-xs-12">
            <div class="card panel-primary text-center no-boder bg-color-brown">
                <div class="panel-body">
                </div>
                <asp:LinkButton ID="btnEncuestas" runat="server" CssClass="btn-outline-warning">Encuestas</asp:LinkButton>
            </div>
        </div>
    </div>

  <!--Tiempo De Respuesta-->
    <div id="divTiempoDeRespuesta" runat="server" class="container mt-2">
        <!--Filtros-->
        <div class="row mt-4">
            <div class="card w-100">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label runat="server" for="dpDesdeTiempoDeRespuesta">Desde:</asp:Label>
                            <asp:TextBox ID="dpDesdeTiempoDeRespuesta" runat="server" TextMode="Date" CssClass="mt-1"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:Label runat="server" for="dpHastaTiempoDeRespuesta">Hasta:</asp:Label>
                            <asp:TextBox ID="dpHastaTiempoDeRespuesta" runat="server" TextMode="Date" CssClass="mt-1"></asp:TextBox>
                        </div>
                        <div class="col-sm-4 justify-content-center">
                            <asp:Button class="btn btn-primary mt-1 w-50" ID="btnFiltrarTiempoDeRespuesta" runat="server" Text="Filtrar" formnovalidate />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--Grafico-->
        <div id="divTiempoDeRespuesta_Content" class="row" runat="server">
            <div id="divPreguntaTiempoDeRespuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold; text-align:center" />
            <div id="divChartTiempoDeRespuesta" runat="server" style="width: 800px; height: 600px; text-align:center">
                <asp:Chart EnableViewState="true" ID="chartTiempoDeRespuesta" runat="server" Style="max-width: 100%">
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

    <!--encuestas-->
    <div id="divEncuestas" runat="server" class="container mt-2">
        <div class="row mt-4 justify-content-center">
            <asp:GridView ID="grdEncuestas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover w-100" DataKeyNames="id" AllowPaging="False" Width="650px" BorderWidth="2">
                <Columns>
                    <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px" />
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
        <div id="divEncuestas_Content" class="row justify-content-center" runat="server">
            <div id="divPreguntaEncuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold; text-align:center" />
            <div id="divChartEncuesta" runat="server" style="width: 100%; height: 600px; align-self:center; text-align:center" class="justify-content-center">
                <asp:Chart EnableViewState="true" ID="chartEncuesta" runat="server" Style="max-width: 100%">
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

    <!--fichas de opinion-->
    <div id="divFichasDeOpinion" runat="server" class="container mt-2">
        <div class="row mt-4 justify-content-center">
            <asp:GridView ID="grdFichasDeOpinion" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover w-100"  BorderWidth="2" DataKeyNames="id" AllowPaging="False" Width="650px">
                <Columns>
                    <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px" />
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
        <div id="divFichasDeOpinion_Content" class="row justify-content-center" runat="server">
            <div id="divPreguntaFichaDeOpinion" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold; text-align:center" />
            <div id="divChartFichaDeOpinion" runat="server" style="width: 600px; height: 600px">
                <asp:Chart EnableViewState="true" ID="chartFichaDeOpinion" runat="server" Style="max-width: 100%">
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

     <!--Ganancias-->
    <div id="divGanancias" runat="server" class="container mt-2">
        <!--Filtros-->
        <div class="row">
            <div class="card text-center w-100">
                <div class="card-header">
                    <ul class="nav nav-tabs card-header-tabs" id="myTab" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active show" id="fechas-tab" data-toggle="tab" href="#fechas" role="tab" aria-selected="true">Fechas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="mensual-tab" data-toggle="tab" href="#mensual" role="tab" aria-selected="false">Mensual</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="anual-tab" data-toggle="tab" href="#anual" role="tab" aria-selected="false">Anual</a>
                        </li>
                    </ul>
                </div>
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade active show" id="fechas" role="tabpanel" aria-labelledby="home-tab">
                        <div class="card-body">
                            <div class="row justify-content-center">                                                     
                                        <div class="col-sm-4">
                                            <asp:Label runat="server" for="dpDesdeGanancias" class="d-inline-block">Desde:</asp:Label>
                                            <asp:TextBox ID="dpDesdeGanancias" runat="server" TextMode="Date"></asp:TextBox>                                      
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:Label runat="server" for="dpHastaGanancias" class="d-inline-block">Hasta:</asp:Label>
                                            <asp:TextBox ID="dpHastaGanancias" runat="server" TextMode="Date" CssClass="mx-1"></asp:TextBox>
                                        </div>
                                <div class="col-sm-4 justify-content-center">
                                     <asp:Button class="btn btn-primary mt-1 w-50" ID="btnFiltrarGanancias" runat="server" Text="Filtrar" formnovalidate />
                                </div>               
                            </div>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="mensual" role="tabpanel" aria-labelledby="home-tab">
                        <div class="card-body">
                            <div class="row justify-content-center">
                        <div class="col-md-6">
                           <label for="ddlMes" class="ml-2">Seleccionar mes del año en curso:</label>
                                <asp:DropDownList ID="ddlMes" runat="server">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-6 justify-content-center">
                               <asp:Button class="btn small btn-primary mt-1 ml-1" ID="btnMensualGanancias" runat="server" Text="Ver Reporte" formnovalidate />
                            </div>
                        
                    </div>
                        </div>
                    </div>

                    <div class="tab-pane fade" id="anual" role="tabpanel" aria-labelledby="home-tab">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 justify-content-center">
                                    <label>Reporte anual hasta la fecha</label>
                                </div>
                                <div class="col-md-6 justify-content-center">
                                    <asp:Button class="btn btn-primary mt-1 align-content-center w-50" ID="btnGananciasYTD" runat="server" Text="Ver reporte" formnovalidate />
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--Grafico-->
        <div id="divGanancias_Content" class="container mt-2" runat="server">
           <div class="row justify-content-center">
                <asp:Chart EnableViewState="true" runat="server" CssClass="text-center" ID="ChartGanancias">
                    <Series>
                        <asp:Series Name="SeriesGanancias"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartAreaGanancias"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
           </div> 
            <div class="row justify-content-center">
                <div id="divGananciasResultados" runat="server" class="mt-3 text-center" visible="false">
                    <asp:Label runat="server">Total: $</asp:Label>
                    <asp:Label runat="server" ID="lblTotalMensual" class="mt-3"></asp:Label>
                    <div class="row justify-content-center">
                        <asp:Button runat="server" ID="btnVerListado" CssClass="btn btn-primary mt-1 text-center" Text="Ver Listado" />
                    </div>
                </div>
            </div>
            <div id="divPreguntaGanancias" runat="server" class=" justify-content-center" style="width: 100%; font-size: 4vh; font-weight: bold" />
            <asp:GridView ID="gridGanacias" runat="server" class="table table-hover w-100 mt-4" BorderWidth="2" AutoGenerateColumns="False" Visible="False">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Nro" HeaderText="Nro" DataField="nro" />
                    <asp:BoundField AccessibleHeaderText="Detalle" HeaderText="Detalle" DataField="detalle" />
                    <asp:BoundField AccessibleHeaderText="Fecha" HeaderText="Fecha" DataField="fecha" />
                    <asp:BoundField AccessibleHeaderText="Monto" HeaderText="Monto" DataField="monto" />
                </Columns>
            </asp:GridView>
        </div>

   

    <!--Footer-->
    <div class="row mt-2 d-flex justify-content-center">
        <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
    </div>
			
</asp:Content>


