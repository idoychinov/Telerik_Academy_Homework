<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Web Chat</h1>
    <p>There are four types of users:</p>
    <ul>
        <li><strong>Unregistered (anonymous) user</strong> - can view messages <br />
            <em>Example login:</em> none
        </li>
        <li><strong>Registered user</strong> - can view and add messages <br />
            <em>Example login:</em> username - testUser, password - testtest
        </li>
        <li><strong>Moderator</strong> - can view, add and edit messages <br />
            <em>Example login:</em> username - moderator, password - moderator
        </li>
        <li><strong>Administrator</strong> - can view, add, edit and delete messages <br />
            <em>Example login:</em> username - admin, password - adminn
        </li>
    </ul>
</asp:Content>
