<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebFormsCalculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Calculator</h1>
        <p>
            Enter first number: 
            <asp:TextBox ID="FirstNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter second number: 
            <asp:TextBox ID="SecondNumber" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="CalculateSumButton" runat="server"
            OnClick="CalculateSum" Text="Calculate" />
        </p>
        <p>
            Result: 
            <asp:Label ID="Result" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
