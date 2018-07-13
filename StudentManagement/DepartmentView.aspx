<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.Master" AutoEventWireup="true" CodeBehind="DepartmentView.aspx.cs" Inherits="StudentManagement.DepartmentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateDepartment() {

            if ($.trim($("#<%=txtDepartment.ClientID%>").val()) == "") {
                alert('Please enter alphanumeric characters');
                return false;
            }

            var letters = /^[0-9a-zA-Z]+$/;
            if (!$("#<%=txtDepartment.ClientID%>").val().match(letters)) {
                alert('Please input alphanumeric characters only');
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table>
            <tr>
                <td>Department Name</td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server" MaxLength="20"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="return ValidateDepartment();" OnClick="btn_Click" /></td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvDepartment" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="false" OnRowCommand="gvDepartment_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="SNO">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    <asp:Label ID="lblId" runat="server" Visible="false" Text="<%# Eval("Id") %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text="<%# Eval("Name") %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button Text="Delete" runat="server" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
</asp:Content>
