<%@ Page Title="Edit messages" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Edit.aspx.cs" Inherits="WebChat.Messages.Edit" %>

<asp:Content ID="ContentEditMessages" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit messages</h1>

    <asp:ListView ID="ListViewMessages" runat="server" DataKeyNames="Id"
        ItemType="WebChat.Models.Message" SelectMethod="ListView_GetData" UpdateMethod="ListView_UpdateItem">
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
            <asp:Button ID="ButtonEdit" runat="server" CssClass="btn btn-primary"
                CommandName="Edit" Text="Edit" />
        </ItemTemplate>

        <EditItemTemplate>
            <asp:Label ID="LabelMessageText" runat="server">Message text:</asp:Label>
            <asp:TextBox ID="TextBoxContent" runat="server" Text="<%#: BindItem.Content %>" />

            <asp:Button ID="ButtonUpdate" runat="server" CssClass="btn btn-primary"
                CommandName="Update" Text="Update" />
            <asp:Button ID="ButtonCancel" runat="server" CssClass="btn btn-primary"
                CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
