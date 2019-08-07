<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="NewRol.aspx.vb" Inherits="Index.NewRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card card-register mx-auto">
    <p class="card-header h5 text-center">Rol</p>
        <div class="card-body">
            <div class="form-group">
                <label for="inputNombre">Nombre:</label>
                <asp:TextBox ID="inputNombre" runat="server" CssClass="form-control"></asp:TextBox>


                <label for="inputDescripcion">Descripcion:</label>
                <asp:TextBox ID="inputDescripcion" runat="server" CssClass="form-control w-100"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="text-center">
                <p class="h5">Listado de permisos:</p>
            </div>
            <div class="table-responsive">

                <asp:GridView ID="grdPermisos" class="table-sm table-hover w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" PageSize="20">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    

        </div>
    <div class="row mt-2 d-flex justify-content-center">
        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-primary mx-3 mt-1" />
       <asp:Button ID="btnVolver" Text="Volver" runat="server" CssClass="btn btn-primary mx-3 mt-1" />
    </div>

</asp:Content>
