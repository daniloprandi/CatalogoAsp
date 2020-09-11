<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModelloNuovo.aspx.cs" Inherits="ModelloNuovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anagrafica Modello</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
            <asp:Label ID="lblInsModModello" runat="server" Font-Bold="True" Text="INSERISCI MODELLO"></asp:Label>
						<br />
						<br />
            Nome:&nbsp;
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
&nbsp;Descrizione:&nbsp;
            <asp:TextBox ID="txtDescrizione" runat="server" Width="540px"></asp:TextBox>
&nbsp;<br />
            <br />
            Attivo:
            <asp:CheckBox ID="ckbAttivo" runat="server" />
&nbsp;Famiglia:
            <asp:DropDownList ID="ddlFamiglie" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSalvaAggiorna" runat="server" Text="Salva" OnClick="btnSalvaAggiorna_Click" />
            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
            <br />
						<br />
						<asp:Button ID="btnAggiungiFamiglia" runat="server" OnClick="btnAggiungiFamiglia_Click" Text="Aggiungi Famiglia" />
						<asp:Button ID="btnElencoModelli" runat="server" BackColor="#00CC00" OnClick="btnElencoModelli_Click" Text="Elenco Modelli" />
            <br />
            <br />
            <asp:Label ID="lblErrori" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
