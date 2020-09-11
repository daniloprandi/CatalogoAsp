<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AziendaNuovo.aspx.cs" Inherits="AziendaNuovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Anagrafica Aziende</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<header>
				<b>INSERISCI AZIENDA<br />
					<br />
				</b>
			</header>
			<br />
			<br />
			<b>Dati Anagrafici</b>:<br />
			<br />
			Ragione sociale:
					<asp:TextBox ID="txtRagioneSociale" runat="server">
					</asp:TextBox>
			&nbsp;<br />
			<br />
			Tipologia 1:
			<asp:DropDownList ID="ddlTipologiaAzienda1" runat="server">
			</asp:DropDownList>
&nbsp;Tipologia 2:
			<asp:DropDownList ID="ddlTipologiaAzienda2" runat="server">
			</asp:DropDownList>
&nbsp;Tipologia 3:
			<asp:DropDownList ID="ddlTipologiaAzienda3" runat="server">
			</asp:DropDownList>
			<br />
			&nbsp;
					<%--<asp:DropDownList ID="ddlTipologiaAzienda" runat="server" selectionMode="Multiple">
					</asp:DropDownList>--%>
			<br />
			<br />
			Partita Iva:
					<asp:TextBox ID="txtPartitaIva" runat="server"></asp:TextBox>
			&nbsp;<br />
			<br />
			Codice Fiscale:
			<asp:TextBox ID="txtCodiceFiscale" runat="server"></asp:TextBox>
			&nbsp;<br />
			<br />
			Note:
					<br />
			<asp:TextBox ID="txtNote" runat="server" Height="92px" Width="285px"></asp:TextBox>
			<br />
			<br />
			Attivo:
					<asp:CheckBox ID="ckbAttivo" runat="server" />
			<br />
			<br />
			<b>Indirizzo:</b><br />
			<br />
			Tipologia:
					<asp:DropDownList ID="ddlTipologiaIndirizzo" runat="server">
					</asp:DropDownList>
			<br />
			<br />
			Via:
					<asp:TextBox ID="txtVia" runat="server" Width="511px"></asp:TextBox>
			&nbsp;Num:
					<asp:TextBox ID="txtNumCivico" runat="server" Height="20px" Width="38px"></asp:TextBox>
			&nbsp; CAP:
					<asp:TextBox ID="txtCap" runat="server" Width="80px"></asp:TextBox>
			<br />
			<br />
			Città:
					<asp:TextBox ID="txtCitta" runat="server"></asp:TextBox>
			&nbsp;Provincia:
					<asp:DropDownList ID="ddlProvincia" runat="server">
					</asp:DropDownList>
			&nbsp;Stato:
					<asp:DropDownList ID="ddlStato" runat="server">
					</asp:DropDownList>
			<br />
			<br />
			<asp:Button ID="cmdSalva" runat="server" OnClick="cmdSalva_Click" Text="Salva" />
			<asp:Button ID="cmdAnnulla" runat="server" OnClick="cmdAnnulla_Click" Text="Annulla" />
			<br />
			<br />
			<br />
			<asp:Label ID="lblErrori" runat="server"></asp:Label>
			<br />
			<br />
		</div>
	</form>
</body>
</html>
