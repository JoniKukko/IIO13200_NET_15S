<%@ Page Title="H3247 Tehtävä 3A" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="H3247_T3A.aspx.cs" Inherits="H3247_T3A" %>


<asp:Content ID="bodyContent" ContentPlaceHolderID="body" Runat="Server">
    <h1>Tervetuloa!</h1>

    <p>
        Käyttäjänimi: <asp:textbox ID="textboxUsername" runat="server" /><br />
        Salasana: <asp:textbox ID="textboxPassword" type="password" runat="server" /><br />
        <asp:button ID="buttonLogin" runat="server" text="Kirjaudu" OnClick="buttonLogin_Click" />
    </p>

    <p>
        <asp:Label ID="labelMessages" runat="server" />
    </p>
</asp:Content>

