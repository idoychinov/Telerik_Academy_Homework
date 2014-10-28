<%@ Page Title="New message" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="WebChat.Messages.New" %>

<asp:Content ID="ContentNewMessage" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add new message</h1>

    <asp:Label ID="LabelMessageText" runat="server">Message text:</asp:Label> <br />
    <asp:TextBox ID="TextBoxContent" runat="server" /> <br />
    <asp:Button ID="ButtonAddMessage" runat="server" CssClass="btn btn-primary"
        Text="Add" OnClick="ButtonAddMessage_Click" />
</asp:Content>
