<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticoloNuovo.aspx.cs" Inherits="ArticoloNuovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family:Arial">
			<asp:Label ID="lblInsModArticolo" runat="server" Text="INSERISCI ARTICOLO"></asp:Label>
			<br />
			<br />
			Codice Articolo:&nbsp;
				<asp:TextBox ID="txtCodice" runat="server"></asp:TextBox>
			&nbsp;Descrizione Articolo:
				<asp:TextBox ID="txtDescrizione" runat="server" Width="346px"></asp:TextBox>
			&nbsp;Prezzo Articolo:
				<asp:TextBox ID="txtPrezzo" runat="server" Width="47px"></asp:TextBox>
			<br />
			<br />
			Note Articolo:<br />
			<asp:TextBox ID="txtNote" runat="server" Height="57px" Width="392px"></asp:TextBox>
			<br />
			<br />
			Attivo:&nbsp;
				<asp:CheckBox ID="ckbAttivo" runat="server" />
			&nbsp;Famiglia:
				<asp:DropDownList ID="ddlFamiglia" runat="server">
				</asp:DropDownList>
			&nbsp;Modello:&nbsp;
				<asp:DropDownList ID="ddlModello" runat="server">
				</asp:DropDownList>
			<br />
			<br />
			<br />
			<br />
			<asp:Button ID="btnSalvaAggiorna" runat="server" Text="Salva" OnClick="btnSalvaAggiorna_Click" />
			<asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
			<br />
			<br />
			<asp:Label ID="lblErrori" runat="server"></asp:Label>
			<br />
			<br />
			<asp:Button ID="btnAggiungiFamiglia" runat="server" BackColor="Lime" OnClick="btnAggiungiFamiglia_Click" Text="Aggiungi Famiglia" />
			<asp:Button ID="btnAggiungiModello" runat="server" BackColor="Lime" OnClick="btnAggiungiModello_Click" Text="AggiungiModello" />
			<asp:Button
				ID="btnVaiElencoArticoli"
				runat="server"
				BackColor="#999999"
				OnClick="btnVaiElencoArticoli_Click"
				Text="Vai a Elenco Articoli"
				CommandArgument='<%#Eval("id_Articoli")%>' />
			<br />
		</div>
	</form>
</body>
</html>
