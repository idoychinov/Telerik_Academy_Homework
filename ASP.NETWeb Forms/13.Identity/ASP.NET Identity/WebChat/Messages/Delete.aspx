<%@ Page Title="Delete messages" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="Delete.aspx.cs" 
    Inherits="WebChat.Messages.Delete" %>

<asp:Content ID="ContentDeleteMessages" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Delete messages</h1>

    <asp:ListView ID="ListViewMessages" runat="server" DataKeyNames="Id"
        ItemType="WebChat.Models.Message" SelectMethod="ListView_GetData" DeleteMethod="ListViewMessages_DeleteItem">
        <LayoutTemplate>
            <span runat="server" id="itemPlaceholder" />
            <div class="pagerLine">
                <asp:DataPager ID="DataPagerMessages" runat="server" PageSize="2">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"
                            ShowPreviousPageButton="true" ShowLastPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="true"
                            ShowPreviousPageButton="false" ShowLastPageButton="true" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>

        <EmptyDataTemplate>
            <div>No data was returned.</div>
        </EmptyDataTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div class="item">
                <p><%#: Item.Content %></p>
                <div>
                    <strong>Created by <%#: Item.Author.UserName %> (<%#: Item.Author.FirstName + " " + Item.Author.LastName %>) 
                    on <%#: string.Format("{0:dd.MM.yyyy}", Item.CreationDate) %></strong>
                </div>
            </div>
            <asp:Button ID="ButtonDelete" runat="server" CssClass="btn btn-primary"
                 CommandName="Delete" Text="Delete" />
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
