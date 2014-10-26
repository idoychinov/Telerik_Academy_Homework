<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarsSearch.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label AssociatedControlID="Producer" ID="ProducerLabel" runat="server">Producer:</asp:Label>
        <asp:DropDownList ID="Producer" runat="server" DataTextField="Name" DataValueField="Name"
             OnSelectedIndexChanged="Producer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <br />
        <asp:Label AssociatedControlID="Model" ID="ModelLabel" runat="server" OnLoad="Producer_SelectedIndexChanged">Model:</asp:Label>
        <asp:DropDownList ID="Model" runat="server"></asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="Extras" runat="server" ItemType="List<Extra>" DataValueField="Name" DataTextField="Name"></asp:CheckBoxList>
        <br />
        <asp:RadioButtonList ID="EngineType" runat="server" RepeatDirection="Horizontal">
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
        <br />
        <asp:Literal ID="Result" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
