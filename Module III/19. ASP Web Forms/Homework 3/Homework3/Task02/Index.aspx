<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task02.Index" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Task2</h1>
        <asp:Label Text="Enter text" runat="server" />
        <asp:TextBox Mode="Encode" ID="TextHolder" runat="server" />
        <br />
        <br />
        <asp:Button Text="Show Escaped Text" runat="server" OnClick="ShowEscapedText" />
        <br />
        <asp:Label ID="Result" Text="" runat="server" />
    </div>
    </form>
</body>
</html>
