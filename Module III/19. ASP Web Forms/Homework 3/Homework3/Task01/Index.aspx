<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task01.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Using HTML controls</h1>
        <label runat="server" for="minLimit">Enter min number limit:</label>
        <input type="text" id="MinLimit" name="minLimit" value=" " runat="server" />
        <br />
        <br />
        <label runat="server" for="maxLimit">Enter max number limit:</label>
        <input type="text" id="MaxLimit" name="maxLimit" value=" " runat="server" />
        <br />
        <br />
        <button type="submit" runat="server" onserverclick="GenerateRandomNumberHTML">Generate</button>
        <br />
        <br />
        <span>Random number: <span id="Result" runat="server"></span></span>

        <hr />

        <h1>Using WEB controls</h1>
        <asp:Label Text="Enter min number limit:" runat="server" />
        <asp:TextBox ID="MinLimit2" runat="server" />
        <br />
        <br />
        <asp:Label Text="Enter max number limit:" runat="server" />
        <asp:TextBox ID="MaxLimit2" runat="server" />
        <br />
        <br />
        <asp:Button Text="Generate" runat="server" OnClick="GenerateRandomNumberWEB" />
        <br />
        <br />
        <asp:Label Text="Result:" runat="server" />
        <asp:Label ID="Result2" Text="" runat="server" />
    </div>
    </form>
</body>
</html>
