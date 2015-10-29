<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoxOy.aspx.cs" Inherits="DemoxOy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Asiakkaat</h1>
        <asp:Label ID="errorMessage" runat="server" />
        <asp:GridView ID="gvCustomers" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
