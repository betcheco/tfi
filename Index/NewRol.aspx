<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="NewRol.aspx.vb" Inherits="Index.NewRol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="h3">Rol</p>
    <div class="d-inline">
    <div class="col-6">
        <label for="inputNombre">Nombre:</label>
        <asp:TextBox ID="inputNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
      <div class="col-12">
        <label for="inputDescripcion">Descripcion:</label>
       <asp:TextBox ID="inputDescripcion" runat="server" CssClass="form-control w-100"></asp:TextBox>
      </div>
        </div>
    <div>
        <p class="h5">Permisos:</p>
    </div>
    <div class="d-flex justify-content-center">
        
        <asp:GridView ID="grdPermisos" class="table-responsive table-hover w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" PageSize="20">
            <Columns>
                <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="chk" runat="server" ></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
            </Columns>
        </asp:GridView>
        </div>
    <div class="align-content-center">
        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-primary mx-auto mt-1" />
       <asp:Button ID="btnVolver" Text="Volver" runat="server" CssClass="btn btn-primary mx-auto mt-1" />
    </div>
</asp:Content>
