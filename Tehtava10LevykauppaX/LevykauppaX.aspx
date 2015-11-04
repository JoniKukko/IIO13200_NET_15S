<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevykauppaX.aspx.cs" Inherits="DemoSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SqlDataSource testi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
    <!--1. DataSourcen määrittely -->
        <asp:XmlDataSource 
            ID="scrLevyt"
            DataFile="~/App_Data/LevykauppaX.xml"
            XPath="Records/genre/record"
            runat="server"></asp:XmlDataSource>


    <!-- 3. Vaihtoehtoinen tapa esittää repeater-kontrolleria -->
        <h2>Levykauppa X</h2>
        <asp:Repeater ID="Repeater2" DataSourceID="scrLevyt" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="Images/<%# Eval("ISBN") %>.jpg" />
                        </td>
                        <td>
                            <h2><%# Eval("Artist") %> : <%# Eval("Title") %></h2>
                            <b>ISBN</b> <a href="LevykauppaX2.aspx?ISBN=<%# Eval("ISBN") %>"><%# Eval("ISBN") %></a><br />
                            <b>Hinta</b> <%# Eval("Price") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
        </asp:Repeater>

    </div>
    </form>
</body>
</html>
