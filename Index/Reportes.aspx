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
  .bg-color-brown {
background-color: #fff;
color:#f0ad4e;
}


    </style>
    <div class="row">
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="card panel-primary text-center no-boder bg-color-green">
                            <div class="panel-body">
                                <i class="fa fa-chart-bar fa-5x"></i>
                                <h3>Fichas de opinion</h3>
                            </div>
                            <div class="card-footer back-footer-green">
                                 <asp:LinkButton ID="btnFichas" runat="server" CssClass="btn-outline-success" >Ver</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="card panel-primary text-center no-boder bg-color-blue">
                            <div class="panel-body">
                                <i class="fa fa-shopping-cart fa-5x"></i>
                                <h3>Ganancias </h3>
                            </div>
                            <div class="card-footer bg-color-dark">
                                <asp:LinkButton ID="btnGanancias" runat="server" >Ver</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="card panel-primary text-center no-boder bg-color-red">
                            <div class="panel-body">
                                <i class="fa fa fa-comments fa-5x"></i>
                                <h3>Tiempo de respuesta</h3>
                            </div>
                            <div class="card-footer back-footer-red">
                               <asp:LinkButton ID="btnChats" runat="server" >Ver</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="card panel-primary text-center no-boder bg-color-brown">
                            <div class="panel-body">
                                <i class="fa fa-users fa-5x"></i>
                                <h3>Encuestas </h3>
                            </div>
                            <div class="card-footer back-footer-brown">
                                 <asp:LinkButton ID="btnEncuestas" runat="server" >Ver</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>

  <!--Tiempo De Respuesta-->
    <div id="divTiempoDeRespuesta" runat="server" class="container mt-2">
        <h3>Tiempos de respuesta</h3>
        <div class="row">
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpDesdeTiempoDeRespuesta">Desde:</asp:Label>
               <asp:TextBox ID="dpDesdeTiempoDeRespuesta" runat="server" TextMode="Date" CssClass="mt-1"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <asp:Label runat="server" for="dpHastaTiempoDeRespuesta">Hasta:</asp:Label>
                <asp:TextBox ID="dpHastaTiempoDeRespuesta" runat="server" TextMode="Date" CssClass="mt-1" ></asp:TextBox>
            </div>
            <div class="col-sm-3">

                <asp:Button class="btn btn-primary mt-1" ID="btnFiltrarTiempoDeRespuesta" runat="server" Text="Filtrar" formnovalidate />
            </div>
        </div>
        <div id="divTiempoDeRespuesta_Content" class="row" runat="server">
            <div id="divPreguntaTiempoDeRespuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
            <div id="divChartTiempoDeRespuesta" runat="server" style="width: 800px; height: 600px">
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
        <h3>Encuestas</h3>
        <div class="row">
            <asp:GridView ID="grdEncuestas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" AllowPaging="False" Width="650px">
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
        <div id="divEncuestas_Content" class="row" runat="server">
            <div id="divPreguntaEncuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
            <div id="divChartEncuesta" runat="server" style="width: 600px; height: 600px">
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
        <h3>Fichas de opinion</h3>
        <div class="row">
            <asp:GridView ID="grdFichasDeOpinion" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" AllowPaging="False" Width="650px">
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
        <div id="divFichasDeOpinion_Content" class="row" runat="server">
            <div id="divPreguntaFichaDeOpinion" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
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
    <div id="divGanancias" runat="server" class="container-fluid mt-2">
         <h3>Ganancias</h3>
        <div class="row">           
            <div class="col-6">
             <div class="card">
                 <h6 class="card-title">Filtrar por fecha</h6>
                 <div class="d-inline-flex">
                     <asp:Label runat="server" for="dpDesdeGanancias">Desde:</asp:Label>
                     <asp:TextBox ID="dpDesdeGanancias" runat="server" TextMode="Date"></asp:TextBox>
                     <asp:Label runat="server" for="dpHastaGanancias" CssClass="pl-1">Hasta:</asp:Label>
                     <asp:TextBox ID="dpHastaGanancias" runat="server" TextMode="Date"></asp:TextBox>
                     <asp:Button class="btn btn-primary mt-1 mx-2" ID="btnFiltrarGanancias" runat="server" Text="Filtrar" formnovalidate />
                 </div>
             </div>
         </div>
            <%--<div class="col-6">--%>
             <div class="col-md-3 col-sm-12 col-xs-12">
                 <div class="card">
                  <h6>Reporte mensual</h6>
                     <div class="d-inline-flex" >
             <label for="ddlMes" class="ml-2">Mes:</label>
             <asp:DropDownList ID="ddlMes" runat="server" Width="60px">
                 <asp:ListItem Value="1">Ene</asp:ListItem>
                 <asp:ListItem Value="2">Feb</asp:ListItem>
                 <asp:ListItem Value="3">Mar</asp:ListItem>
                 <asp:ListItem Value="4">Abr</asp:ListItem>
                 <asp:ListItem Value="5">May</asp:ListItem>
                 <asp:ListItem Value="6">Jun</asp:ListItem>
                 <asp:ListItem Value="7">Jul</asp:ListItem>
                 <asp:ListItem Value="8">Ago</asp:ListItem>
                 <asp:ListItem Value="9">Sep</asp:ListItem>
                 <asp:ListItem Value="10">Oct</asp:ListItem>
                 <asp:ListItem Value="11">Nov</asp:ListItem>
                 <asp:ListItem Value="12">Dic</asp:ListItem>
                </asp:DropDownList>
                 <asp:Button class="btn btn-primary mt-1 ml-1" ID="btnMensualGanancias" runat="server" Text="Ver Reporte" formnovalidate />
                         </div>
                     </div>
            </div>  
              <div class="col-md-3 col-sm-12 col-xs-12">
                 <div class="card">
                 <h6 >Reporte anual:</h6>
             <asp:Button class="btn btn-primary mt-1" ID="btnGananciasYTD" runat="server" Text="YTD" formnovalidate />
             </div>
               </div>   
         <%--</div>--%>
           
            </div>
     
       
        <div id="divGanancias_Content" class="row" runat="server">
            <asp:Chart EnableViewState="true" runat="server" CssClass="col-10" id="ChartGanancias">
    <Series>
        <asp:Series Name="SeriesGanancias"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartAreaGanancias"></asp:ChartArea>
    </ChartAreas>
                </asp:Chart>
            <div id="divGananciasResultados" runat="server" class="col-2 mt-5" visible="false">
                <asp:Label runat="server" >Total: $</asp:Label>
                <asp:Label runat="server" ID="lblTotalMensual" class="mt-3"></asp:Label>
                <div class="row align-content-center">
                    <asp:Button runat="server" ID="btnVerListado" CssClass="btn btn-primary mt-1"  text="Ver Listado" />                             
                </div>
                     </div>
            <div id="divPreguntaGanancias" runat="server" class=" justify-content-center" style="width: 100%; font-size: 4vh; font-weight: bold" />
       <asp:GridView ID="gridGanacias" runat="server" class="table table-hover" AutoGenerateColumns="False" Visible="False">
           <Columns>
               <asp:BoundField AccessibleHeaderText="Nro" HeaderText="Nro" DataField="nro" />
               <asp:BoundField AccessibleHeaderText="Detalle" HeaderText="Detalle" DataField="detalle" />
               <asp:BoundField AccessibleHeaderText="Fecha" HeaderText="Fecha" DataField="fecha" />
               <asp:BoundField AccessibleHeaderText="Monto" HeaderText="Monto" DataField="monto" />
           </Columns>
                </asp:GridView>
        </div>
  
        </div>
    <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
			
</asp:Content>


