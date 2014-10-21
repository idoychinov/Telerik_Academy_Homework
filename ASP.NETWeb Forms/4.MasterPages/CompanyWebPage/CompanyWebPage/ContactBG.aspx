<%@ Page Title="Контакт" Language="C#" MasterPageFile="~/SiteBG.master" AutoEventWireup="true" CodeBehind="ContactBG.aspx.cs" Inherits="CompanyWebPage.ContactBG" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Някъде си<br />
        Далеко<br />
        <abbr title="Телефон">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Поддръжка:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Маркетинг:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
