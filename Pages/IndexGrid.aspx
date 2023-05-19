<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexGrid.aspx.cs" Inherits="WebApplication1.Pages.IndexGrid" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>GridView</title>
    <link rel="stylesheet" type="text/css" href="../Stile/stile.css">
</head>
<body>
    <h2>Gridview Exercise</h2>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
                <asp:BoundField DataField="NumTel" HeaderText="NumTel" />
                <asp:BoundField DataField="File" HeaderText="File" />
                <asp:HyperLinkField HeaderText="Download" Text="Download"
                    DataNavigateUrlFields="File"
                    DataNavigateUrlFormatString="Download.aspx?file={0}"
                    ItemStyle-CssClass="downloadColumn"
                    HeaderStyle-CssClass="downloadColumn" />

            </Columns>
        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="Aggiungi un nuovo record" OnClick="Button1_Click" CssClass="newRecordButton" />
    </form>



    <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
</body>
</html>
