<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Number change to words</title>
</head>
    <body>
        <form id="Form1" runat="server">
            <div>
                <h2>
                    WORDS CONVERTER!!
                </h2>
                <label for="txtNumber">ENTER NUMBER:</label>
                <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnChange" runat="server" Text="Convert to words" OnClick="btnChange_Click" />
                <br /><br />
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                <br /><br />

            <h3>Conversion History</h3>
                <br /><br />
            <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
            </div>

        </form>
    </body>
</html>

