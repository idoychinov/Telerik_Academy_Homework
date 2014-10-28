<%@ Page Title="All messages" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="WebChat.Posts.All" %>

<asp:Content ID="ContentAllPosts" ContentPlaceHolderID="MainContent" runat="server">
    <h1>All messages</h1>

    <asp:ListView ID="ListViewMessages" runat="server"
        ItemType="WebChat.Models.Message" SelectMethod="ListView_GetData">
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
                <div><strong>Created by <%#: Item.Author.UserName %> (<%#: Item.Author.FirstName + " " + Item.Author.LastName %>) 
                    on <%#: string.Format("{0:dd.MM.yyyy}", Item.CreationDate) %></strong></div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
