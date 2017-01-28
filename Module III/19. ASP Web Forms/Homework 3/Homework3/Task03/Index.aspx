<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Task03.Index"  ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Enter first name: " runat="server"/>
        <asp:TextBox runat="server" ID="FirstName" />
        <br />
        <br />
        <asp:Label Text="Enter last name: " runat="server" />
        <asp:TextBox runat="server"  ID="LastName"/>
        <br />
        <br />
        <asp:Label Text="Enter faculty number: " runat="server" />
        <asp:TextBox runat="server" ID="FacultyNumber"/>
        <br />
        <br />
        <asp:Label Text="Choose university: " runat="server" />
        <asp:DropDownList ID="UniversityPicker" runat="server">
            <asp:ListItem Text="UNSS" />
            <asp:ListItem Text="SU" />
            <asp:ListItem Text="TU" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label Text="Choose specialty: " runat="server" />
        <asp:DropDownList ID="SpecialityPicker" runat="server">
            <asp:ListItem Text="Finance" />
            <asp:ListItem Text="Low" />
            <asp:ListItem Text="Computer Science" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:ListBox runat="server" ID="CoursePicker" SelectionMode="Multiple">
            <asp:ListItem Text="Course 1" />
            <asp:ListItem Text="Course 2" />
            <asp:ListItem Text="Course 3" />
            <asp:ListItem Text="Course 4" />
            <asp:ListItem Text="Course 5" />
            <asp:ListItem Text="Course 6" />
        </asp:ListBox>
        <br />
        <asp:Button Text="Submit" runat="server" OnClick="RegisterStudent" />
        <hr />
        <asp:Label runat="server" ID="Result">
            
        </asp:Label>
    </div>
    </form>
</body>
</html>
