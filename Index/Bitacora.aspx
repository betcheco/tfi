<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Bitacora.aspx.vb" Inherits="Index.Bitacora" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <h2>Consultar Bitacora</h2>
  
    <!--Filters-->
    <div class="py-1">
        <div class="container-fluid mx-auto">
            <div class="form-row">
                <%--<div class="align-items-start">--%>
                <div class="col-md-3">
                    <label for="inputDateFrom">Fecha Desde:</label>
                    <asp:TextBox ID="inputDateFrom" runat="server" TextMode="Date"></asp:TextBox>
                    <%--   <i id="btnDateFrom" runat="server"  class="fa fa-calendar" style="font-size: 24px;"></i>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="inputDateFrom"
                    PopupButtonID="btnDateFrom"></asp:CalendarExtender>--%>
                </div>


              

                <div class="col-md-3">
                    <label for="inputDateTo">Fecha Hasta:</label>
                    <asp:TextBox ID="inputDateTo" runat="server" TextMode="Date"></asp:TextBox>
                    <%-- <i id="bntDateTo" runat="server" class="fa fa-calendar" style="font-size: 24px"></i>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                    TargetControlID="inputDateTo"
                    PopupButtonID="bntDateTo"></asp:CalendarExtender>--%>
                    <%--<asp:Calendar ID="dFrom" runat="server"></asp:Calendar>--%>
                </div>


               <%-- <div class="form-group">
                    <div class="mx-auto align-items-start">--%>
                <div class="col-md-3">
                        <label for="inputCriticidad">
                            Seleccione criticidad:
                        </label>
                        <asp:DropDownList ID="inputCriticidad" runat="server" CssClass="btn-group-toggle mx-1">
                            <asp:ListItem Value="0">Todas</asp:ListItem>
                            <asp:ListItem Value="1">Baja</asp:ListItem>
                            <asp:ListItem Value="2">Media</asp:ListItem>
                            <asp:ListItem Value="3">Alta</asp:ListItem>
                            <asp:ListItem Value="4">Severa</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                       <div class="col-md-3">
                        <label for="userList">
                            Usuario:
                        </label>
                        <asp:DropDownList ID="userList" runat="server" CssClass=" d-inline-flex btn-group-toggle mx-auto">
                        </asp:DropDownList>

                    </div>
                </div>
            </div>
        </div>

            <div class="form-row">
                <div class=" mx-auto  align-items-center">
                    <asp:Button runat="server" ID="showBtn" Text="Mostrar" OnClientClick="showBtn_Click" CssClass="btn btn-primary px-3 mx-3" />
                      <asp:Button ID="btnBorrarFiltros" runat="server" Text="Borrar filtros" CssClass="btn btn-primary px-3 mx-3" />
                </div>
               <%-- <div class="col-md-6 mx-auto align-content-start">
                  
                    </div>--%>
            </div>
            <%-- <usrCtrl:Modal ID="msgError" runat="server" />--%>
      
    <!--Buttons-->
    

   <!--Grilla Bitacora-->
    <div class="table-responsive mt-auto py-2">
    <asp:gridview runat="server" id="bitacoraGrid" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" Width="100%" AllowPaging="True" >
          <Columns>
              <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" ApplyFormatInEditMode="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="usuario" HeaderText="Usuario">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
          <asp:BoundField DataField="evento" HeaderText="Evento" ApplyFormatInEditMode="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="criticidad" HeaderText="Criticidad">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="Descripcion">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="400px" />
            </asp:BoundField>
        </Columns>
    </asp:gridview>
        </div>
    <div class="row mt-2 d-flex justify-content-center">
                <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            </div>
        
</asp:Content>
