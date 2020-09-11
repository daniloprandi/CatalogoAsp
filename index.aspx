<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MENU PRINCIPALE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
					<header><u><b>MENU PRINCIPALE</b></u></header>
					<br />
					<br />
        	<b>Magazzino:<br />
					</b>&nbsp;<br />
					<asp:LinkButton ID="lnkbNuovoArticolo" runat="server" OnClick="lnkbNuovoArticolo_Click">Aggiungi Articolo</asp:LinkButton>
        	<br />
					<asp:LinkButton ID="lnkbElencoArticoli" runat="server" OnClick="lnkbElencoArticoli_Click">Elenco Articoli</asp:LinkButton>
        	<br />
					<br />
					<b>Anagrafica Aziende</b><br /><br />
					<asp:LinkButton ID="lnkbNuovaAzienda" runat="server" OnClick="lnkbNuovaAzienda_Click">Aggiungi Azienda</asp:LinkButton>
        </div>
    </form>
</body>
</html>
