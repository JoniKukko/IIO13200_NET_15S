<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WriteFeedback.aspx.cs" Inherits="WriteFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Opintojakson palaute</h1>
            <asp:HyperLink NavigateUrl="~/ReadFeedback.aspx" Text="LUE PALAUTTEITA" runat="server" />
            <h2>Anna palaute</h2>
            <table>
                <tr>
                    <td>PVM</td>
                    <td>
                        <asp:Calendar ID="textboxDate" runat="server" />
                        <asp:CustomValidator ErrorMessage="Kenttä on pakollinen" OnServerValidate="textboxDate_Validate" runat="server"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nimi</td>
                    <td>
                        <asp:TextBox ID="textboxName" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Opintojakson nimi</td>
                    <td>
                        <asp:TextBox ID="textboxClassName" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxClassName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Opintojakson koodi</td>
                    <td>
                        <asp:TextBox ID="textboxClassCode" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxClassCode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Olen oppinut</td>
                    <td>
                        <asp:TextBox ID="textboxLearned" TextMode="MultiLine" Rows="4" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxLearned" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Haluan oppia</td>
                    <td>
                        <asp:TextBox ID="textboxWantToLearn" TextMode="MultiLine" Rows="4" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxWantToLearn" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Hyvää</td>
                    <td>
                        <asp:TextBox ID="textboxGood" TextMode="MultiLine" Rows="4" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxGood" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Parannettavaa</td>
                    <td>
                        <asp:TextBox ID="textboxBad" TextMode="MultiLine" Rows="4" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxBad" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Muuta</td>
                    <td>
                        <asp:TextBox ID="textboxOther" TextMode="MultiLine" Rows="4" runat="server"/>
                        <asp:RequiredFieldValidator ErrorMessage="Kenttä on pakollinen" ControlToValidate="textboxOther" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Tallenna</td>
                    <td><asp:Button ID="buttonSave" Text="Tallenna" runat="server" OnClick="buttonSave_Click" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
