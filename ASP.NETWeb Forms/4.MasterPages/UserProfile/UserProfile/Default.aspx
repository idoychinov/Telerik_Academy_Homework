<%@ Page Title="Personal info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserProfile._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Personal info page</h1>
        <p class="lead">Someone's personal page</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Picture goes here</h2>
        </div>
        <div class="col-md-4">
            <h2>Some base info: Name, age, etc.</h2>
        </div>
        <div class="col-md-4">
            <h2>Some more info</h2>
        </div>
    </div>

</asp:Content>
