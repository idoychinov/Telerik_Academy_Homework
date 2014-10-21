<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentRegistrationForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label AssociatedControlID="FirstName" ID="FirstNameLabel" runat="server">First Name: </asp:Label>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label AssociatedControlID="LastName" ID="LastNameLabel" runat="server">Last Name: </asp:Label>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label AssociatedControlID="FacultyNumber" ID="FacultyNumberLabel" runat="server">Faculty Number: </asp:Label>
            <asp:TextBox ID="FacultyNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label AssociatedControlID="University" ID="UniversityLabel" runat="server">University: </asp:Label>
            <asp:DropDownList ID="University" runat="server">
                <asp:ListItem Value="SU">SU</asp:ListItem>
                <asp:ListItem Value="TU">TU</asp:ListItem>
                <asp:ListItem Value="UNSS">UNSS</asp:ListItem>
                <asp:ListItem Value="NBU">NBU</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label AssociatedControlID="Courses" ID="CoursesLabel" runat="server">Courses: </asp:Label>
            <asp:ListBox ID="Courses" runat="server" SelectionMode="Multiple">
                <asp:ListItem Value="Math">Math</asp:ListItem>
                <asp:ListItem Value="Physics">Physics</asp:ListItem>
                <asp:ListItem Value="Computer Science">Computer Science</asp:ListItem>
                <asp:ListItem Value="Art">Art</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
            <br />
            <asp:Panel ID="Output" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
