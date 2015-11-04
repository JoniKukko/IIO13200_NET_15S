<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevykauppaX2.aspx.cs" Inherits="DemoSQL" %>

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
            runat="server"></asp:XmlDataSource>

        <asp:XmlDataSource 
            ID="scrBiisit"
            DataFile="~/App_Data/LevykauppaX.xml"
            runat="server"></asp:XmlDataSource>


    <!-- 3. Vaihtoehtoinen tapa esittää repeater-kontrolleria -->
        <h2>Levykauppa X</h2>
        <table>
            <asp:Repeater ID="Repeater2" DataSourceID="scrLevyt" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src="Images/<%# Eval("ISBN") %>.jpg" />
                        </td>
                        <td>
                            <h2><%# Eval("Artist") %> : <%# Eval("Title") %></h2>
                            <b>ISBN</b> <a href="?ISBN=<%# Eval("ISBN") %>"><%# Eval("ISBN") %></a><br />
                            <b>Hinta</b> <%# Eval("Price") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="Repeater1" DataSourceID="scrBiisit" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td><b>Biisit</b></td>
                        <td>
                            <ul>
                </HeaderTemplate>
                <ItemTemplate>
                                <li><%# Eval("name") %></li>
                </ItemTemplate>
                <FooterTemplate>
                            </ul>
                        </td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>

        </table>
        <a href="LevykauppaX.aspx">Takaisin listaukseen</a>
    </div>
    </form>
</body>
</html>
