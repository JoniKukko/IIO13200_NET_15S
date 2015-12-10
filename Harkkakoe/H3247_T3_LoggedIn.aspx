<%@ Page Title="H3247 Tehtävä 3 Kirjautuneena sisään" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3247_T3_LoggedIn.aspx.cs" Inherits="H3247_T3_LoggedIn" %>

<asp:Content ID="body" ContentPlaceHolderID="body" Runat="Server">
    <asp:GridView ID="gridviewData" runat="server"></asp:GridView>
    <asp:Label ID="labelMessages" runat="server"></asp:Label>
    <asp:Button ID="buttonSave" runat="server" Text="Tallenna" OnClick="buttonSave_Click" />
    <asp:Button ID="buttonLogout" runat="server" Text="Kirjaudu ulos" OnClick="buttonLogout_Click" />
</asp:Content>

