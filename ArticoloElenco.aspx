<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticoloElenco.aspx.cs" Inherits="ArticoloElenco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family:Arial">
			<header>
				<b>ELENCO ARTICOLI:</b></header>
			<u>
			<br />
			<asp:TextBox ID="txtCerca" Placeholder="cerca con codice o descrizione" runat="server" Width="242px"></asp:TextBox>
			<asp:Button ID="btnCerca" runat="server" Text="Cerca" OnClick="btnCerca_Click" />
			<br />
			<br />
			Articoli a catalogo:</u>
			<asp:TextBox ID="txtNumArt" runat="server" Width="44px"></asp:TextBox>
			<br />
			<br />
			<br />
			<br />
					<asp:GridView ID="gvArticoli" runat="server" AutoGenerateColumns="false" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
						<Columns>
							<asp:BoundField DataField="id_Articoli" HeaderText="ID" />
							<asp:BoundField DataField="codice_Articoli" HeaderText="CODICE" />
							<asp:BoundField DataField="descrizione_Articoli" HeaderText="DESCRIZIONE" />
							<asp:BoundField DataField="prezzo_Articoli" HeaderText="PREZZO" />
							<asp:BoundField DataField="note_Articoli" HeaderText="NOTE" />
							<asp:BoundField DataField="attivo_Articoli" HeaderText="ATTIVO" />
							<asp:BoundField DataField="nome_ArticoliFamiglie" HeaderText="FAMIGLIA" />
							<asp:BoundField DataField="nome_ArticoliModelli" HeaderText="MODELLO" />
							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton
										ID="lnkbVisualizza"
										Text="Visualizza"
										runat="server"
										OnClick="lnkbVisualizza_Click"
										CommandArgument='<%#Eval("id_Articoli")%>'>
									</asp:LinkButton>
									<asp:LinkButton
										ID="lnkbModifica"
										Text="Modifica"
										runat="server"
										OnClick="lnkbModifica_Click"
										CommandArgument='<%#Eval("id_Articoli")%>'>
									</asp:LinkButton>
									<asp:LinkButton
										ID="lnkbCancella"
										Text="Cancella"
										runat="server"
										OnClick="lnkbCancella_Click"
										CommandArgument='<%#Eval("id_Articoli")%>'>
									</asp:LinkButton>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
						<FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
						<HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
						<PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
						<RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
						<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
						<SortedAscendingCellStyle BackColor="#FFF1D4" />
						<SortedAscendingHeaderStyle BackColor="#B95C30" />
						<SortedDescendingCellStyle BackColor="#F1E5CE" />
						<SortedDescendingHeaderStyle BackColor="#93451F" />
					</asp:GridView><br />
			<asp:Button 
				ID="btnAggiungiArticolo" 
				runat="server" 
				BackColor="#00CC00"
				OnClick="btnAggiungiArticolo_Click" 
				Text="Aggiungi Articolo" 
				CommandArgument='<%#Eval("id_Articoli")%>'/>
			<asp:Button 
				ID="btnElencoArticoli" 
				runat="server" 
				BackColor="#999999"
				OnClick="btnElencoArticoli_Click" 
				Text="Elenco Articoli" 
				CommandArgument='<%#Eval("id_Articoli")%>'/>
			<asp:Button ID="btnMenuPrincipale" runat="server" OnClick="btnMenuPrincipale_Click" Text="Menu Principale" />
		</div>
	</form>
</body>
</html>
