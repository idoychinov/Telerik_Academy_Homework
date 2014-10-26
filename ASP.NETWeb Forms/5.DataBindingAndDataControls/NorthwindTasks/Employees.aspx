<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="NorthwindTasks.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="EmployeesNames" AutoGenerateColumns="False" DataKeyNames="EmployeeID" DataSourceID="Northwind">
            <Columns>
                <asp:HyperLinkField  DataNavigateUrlFields ="EmployeeID" DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" DataTextField="FullName" HeaderText="Name"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Northwind" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT *, FirstName + ' ' + LastName as FullName FROM [Employees]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
