<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="StudentManagement.StudentRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateStudent() {

            if ($.trim($("#<%=txtStudent.ClientID%>").val()) == "") {
                alert('Please enter alphanumeric characters');
                return false;
            }

             if ($.trim($("#<%=ddlDepartment.ClientID%>").val()) == "") {
                alert('Please select department');
                return false;
            }

            var letters = /^[0-9a-zA-Z]+$/;
            if (!$("#<%=txtStudent.ClientID%>").val().match(letters)) {
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
                <td>Student Name</td>
                <td>
                    <asp:TextBox ID="txtStudent" runat="server" MaxLength="20"></asp:TextBox></td>

            </tr>
            <tr>
                <td>Department</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="false"></asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="return ValidateStudent();" OnClick="btn_Click" /></td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvStudent" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="false" OnRowCommand="gvStudent_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="SNO">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    <asp:Label ID="lblId" runat="server" Visible="false" Text="<%# Eval("Id") %>"></asp:Label>
                    <asp:Label ID="lblDepartmentId" runat="server" Visible="false" Text="<%# Eval("DepartmentId") %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Student">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text="<%# Eval("Name") %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="lblDepartmentName" runat="server" Text="<%# Eval("DepartmentName") %>"></asp:Label>
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
