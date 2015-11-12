<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadFeedback.aspx.cs" Inherits="ReadFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Opintojakson palaute</h1>
            <asp:HyperLink NavigateUrl="~/WriteFeedback.aspx" Text="ANNA PALAUTTEITA" runat="server" />
            <h2>Lue palaute</h2>
            <asp:Table runat="server" ID="feedbackTable">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>PVM</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nimi</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Opintojakson nimi</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Opintojakson koodi</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Olen oppinut</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Haluan oppia</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Hyvää</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Parannettavaa</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Muuta</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
