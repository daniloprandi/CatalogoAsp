<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamigliaNuovo.aspx.cs" Inherits="FamigliaNuovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Anagrafica Famiglia</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:Label ID="lblInsModFamiglia" runat="server" Enabled="False" Font-Bold="True" Text="INSERISCI FAMIGLIA"></asp:Label>
			<br />
			<br />
			Nome:&nbsp;<asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
			&nbsp;Descrizione:
            <asp:TextBox ID="txtDescrizione" runat="server" Width="512px"></asp:TextBox>
			&nbsp;Attivo:
            <asp:CheckBox ID="ckbAttivo" runat="server" />
			<br />
			<br />
			<asp:Button ID="btnSalvaAggiorna" runat="server" OnClick="btnSalvaAggiorna_Click" Text="Salva" />
			<asp:Button ID="btnAnnulla" runat="server" OnClick="btnAnnulla_Click" Text="Annulla" />

			<br />
			<br />
			<asp:Button ID="btnElencoFamiglie" runat="server" Text="Elenco Famiglie" BackColor="#00CC00" OnClick="btnElencoFamiglie_Click" />

			<br />
			<br />
			<asp:Label ID="lblErrori" runat="server"></asp:Label>

		</div>
	</form>
</body>
</html>
