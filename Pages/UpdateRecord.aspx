<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateRecord.aspx.cs" EnableViewState="true" Inherits="WebApplication1.Pages.UpdateRecord" %>

<!DOCTYPE html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Modifica record</title>
    <link rel="stylesheet" type="text/css" href="../Stile/stile.css">
</head>
<body>
    <h2>Modifica record</h2>
    <form id="form3" runat="server">
        <div>
            <asp:Label ID="NomeLabel" runat="server" Text="Nome:"></asp:Label>
            <asp:TextBox ID="NomeTextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="CognomeLabel" runat="server" Text="Cognome:"></asp:Label>
            <asp:TextBox ID="CognomeTextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="NumLabel" runat="server" Text="Numero di Telefono:"></asp:Label>
            <asp:TextBox ID="NumTextBox2" runat="server"></asp:TextBox>
        </div>

        <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="SubmitButton" runat="server" Text="Modifica" OnClick="SubmitButton_Click" />
    </form>

    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
</body>
</html>
