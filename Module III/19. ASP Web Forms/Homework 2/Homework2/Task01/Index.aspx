<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task01.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Task 1</h1>
        <asp:Label runat="server">Enter name: </asp:Label>
        <asp:TextBox ID="NameInput" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Solute!" ID="AddButton" OnClick="OnButtonClick" />
        <br />
        <asp:Label runat="server">Result: </asp:Label>
        <asp:Label runat="server" ID="Result"></asp:Label>
    </div>
    </form>
</body>
</html>
