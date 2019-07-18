<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="usrCtrlTable.ascx.vb" Inherits="Index.usrCtrlTable" %>
  <asp:GridView ID="grd" class="table-responsive table-striped table-light table-hover w-100" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" BorderWidth="2">
            <Columns>
                <asp:templatefield HeaderText="Select">
                    <itemtemplate>
                        <asp:checkbox ID="chk" runat="server" ></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
                <asp:BoundField DataField="id" HeaderText="Id" ControlStyle-CssClass="d-flex" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" ControlStyle-CssClass="d-flex"/>
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ControlStyle-CssClass="d-flex"/>
            </Columns>
        </asp:GridView>