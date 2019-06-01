<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Comprar.aspx.vb" Inherits="Index.Comprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
      $(function () {
            $("#<%= txtNroTarjeta.ClientId %>").mask("9999-9999-9999-9999");
            $('#<%= txtExpiracion.ClientId %>').mask('99/9999', { placeholder: "MM/yyyy" })
            $("#<%= txtCodSeg.ClientId %>").mask("999");
            $("#<%= txtDNI.ClientId %>").mask("99999999");
        });


        $(document).ready(function () {
            var validaTarj = function (e) {
                var val = $(this).val().toString();
                var btn = $('[id$=btnConfirmarPago]');

                var esTarjeta = false;
                /* VALIDACION DE TIPO */

                if (val.substring(0, 1) == "4") {
                    $("#imgCard").attr("src", "img/cards/visa.png");
                    esTarjeta = true;
                } else {
                    var num = val.substring(0, 2)
                    if (num == "34" || num == "37") {
                        $("#imgCard").attr("src", "img/cards/amex.jpg");
                        esTarjeta = true;
                        console.log(2);
                    } else if (num == "51" || num == "55" || num == "53") {
                        $("#imgCard").attr("src", "img/cards/master.png");
                        esTarjeta = true;
                    }
                }
                if (esTarjeta) {
                    $("#imgCard").css("display", "block");
                    $("#divConfirmarPago").css("display", "block");
                    $("#divErrorTarjeta").css("display", "none");
                    btn.removeAttr("disabled");
                    
                   
                } else {
                    $("#imgCard").css("display", "block");
                    $("#imgCard").attr("src", "img/cards/error.png");
                   // $("#divConfirmarPago").css("display", "none");
                    $("#divErrorTarjeta").css("display", "block");
                    btn.attr("disabled", "true");
                    
                }
            }
            $("#txtNroTarjeta").change(validaTarj);
            $("#txtNroTarjeta").keyup(validaTarj);
        });
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Finalizar compra</h2>
    <div class="card-header">
     
        <div class="row">
            
            <div class="card-icon">
                <asp:Image ID="img" runat="server" Style="width: 100px; height: 100px" />
                </div>
                
            <div class="col-md-6">
                <h4 class="card-title" id="lblTitulo" runat="server"></h4>
                <h5 runat="server" id="lblPrecio"></h5>
                <p class="card-text" id="lblDescCorta" runat="server"></p>
            </div>
            </div>
        </div>
  

     <div class="card card-outline-secondary my-4" >
            <div class="card-header">
              Notas de crédito
            </div>
              <div class="card-body" id="divNotasCredito" runat="server">
                 <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" DataKeyNames="id" AllowPaging="False" Width="450px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <ItemTemplate>
                                        <asp:CheckBox id="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="row_checked"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/M/yyyy}">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="concepto" HeaderText="Concepto">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo" HeaderText="Saldo" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Width="80px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
              </div>
              </div>

     <div class="card card-outline-secondary my-4">
            <div class="card-header">
              Tarjeta
            </div>
              <div class="card-body">
                <div class="row">
                    <div class="col-6">
                        <asp:Label runat="server" for="txtNroTarjeta">Número de tarjeta</asp:Label>
                        <asp:TextBox ID="txtNroTarjeta" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:Label runat="server" for="imgCard">&nbsp</asp:Label>
                         <img id="imgCard" style="height: 5vh; display: block; margin-top: 0.5vh; display:none"/>
                        <p id="errorText" style="color:red; display:none;">El numero de tarjeta es invalido</p>
                        </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label runat="server" for="txtNombre">Nombre y apellido</asp:Label>
                        <asp:TextBox ID="txtNombre" ClientIDMode="static" runat="server" class="form-control" required MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:Label runat="server" for="txtExpiracion">F. Expiración</asp:Label>
                        <asp:TextBox ID="txtExpiracion" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:Label runat="server" for="txtCodSeg">Cód. Seguridad</asp:Label>
                        <asp:TextBox ID="txtCodSeg" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <asp:Label runat="server" for="txtDNI">DNI del titular</asp:Label>
                        <asp:TextBox ID="txtDNI" ClientIDMode="static" runat="server" class="form-control" required></asp:TextBox>
                    </div>
                </div>
                   <div class="row">
                    <div class="col-12 align-content-center" id="divErrorTarjeta" display="none">
                       
                    </div>
                </div>
                <div class="row">
                    <div class="col-12 align-content-center" id="divConfirmarPago">
                        <asp:Button class="btn btn-primary mt-4" ID="btnConfirmarPago" runat="server" Text="Confirmar pago" formnovalidate="true" />
                    </div>
                </div>
            </div>
              </div>
              </div>
</asp:Content>
