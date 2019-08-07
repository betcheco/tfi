<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Publicidad.aspx.vb" Inherits="Index.Publicidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script>
        function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();
               reader.onload = function(e) {
                   $('#<%= imgPreview.ClientId %>').attr('src', e.target.result);
               }
               reader.readAsDataURL(input.files[0]);
           }
       }
       $("#fuImagen").change(function() {
           readURL(this);
       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
    <asp:Label runat="server" class="page-title h5 text-center">Publicidad</asp:Label>
        </div>

    <div class="table-responsive">
    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" class="table table-striped table-light table-hover w-100" AllowPaging="True" >
        <Columns>
            <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<i class="far fa-eye"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<i class="fas fa-eraser"></i>'>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
            </asp:ButtonField>

            <asp:BoundField DataField="AlternateText" HeaderText="Título">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="NavigateUrl" HeaderText="URL">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="350px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
        </div>
      <div class="row mt-2 mb-2 d-flex justify-content-center">

    <asp:Button class="btn btn-primary mt-1" ID="btnNuevo" runat="server" Text="Nuevo" formnovalidate />
       </div> 



    <div class="card card-register mx-auto" id="divDatosEncuesta" runat="server">
        <div class="card-header">
            Detalle publicidad
        </div>
        <div class="card-body">
    <div class="form-group ">
        <div class="form-label-group">
            <asp:Label runat="server" for="txtTitle">Texto:</asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" class="form-control" Required="true" MaxLength="50"></asp:TextBox>
        </div>
        <div class="form-label-group">
            <asp:Label runat="server" for="txtURL">URL:</asp:Label>
            <asp:TextBox ID="txtURL" runat="server" class="form-control" Required="true" MaxLength="150"></asp:TextBox>
        </div>
    </div>
    
    <div class="form-group mt-3">
        <div class="form-label-group">
            <asp:Label runat="server" for="imgPreview">Imagen:</asp:Label><br />
            <asp:Image ID="imgPreview" runat="server" width="200" accept="image/*"/><br />
            <asp:FileUpload ID="fuImagen" runat="server" CssClass="btn btn-primary form-control-file"/>
            <%--onchange="readURL(this)"--%>

        </div>
    </div>
        </div>
    <div class="card-footer justify-content-center text-center">
        <div class="justify-content-center">
            <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
        </div>
    </div>
        </div>

     <div class="row mt-2 d-flex justify-content-center">
        <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
    </div>

</asp:Content>
