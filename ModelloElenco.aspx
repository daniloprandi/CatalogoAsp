<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModelloElenco.aspx.cs" Inherits="FamigliaElenco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Elenco Modelli</title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family:Arial">
			<header>
				<b>ELENCO MODELLI:<br />
					<br />
				</b>
			</header>
			<asp:GridView ID="gvArticoliModelli" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
				CellPadding="4">
				<Columns>
					<asp:BoundField DataField="id_ArticoliModelli" HeaderText="ID" />
					<asp:BoundField DataField="nome_ArticoliModelli" HeaderText="NOME" />
					<asp:BoundField DataField="descrizione_ArticoliModelli" HeaderText="DESCRIZIONE" />
					<asp:BoundField DataField="attivo_ArticoliModelli" HeaderText="ATTIVO" />
					<asp:BoundField DataField="nome_ArticoliFamiglie" HeaderText="FAMIGLIA" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton
								ID="lnkbModifica"
								runat="server"
								Text="Modifica"
								OnClick="Modifica_Click"
								CommandArgument='<%#Eval("id_ArticoliModelli")%>'>
							</asp:LinkButton>
							<asp:LinkButton
								ID="lnkbCancella"
								runat="server"
								Text="Cancella"
								OnClick="Cancella_Click"
								CommandArgument='<%#Eval("id_ArticoliModelli")%>'>
							</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
				<HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
				<PagerStyle ForeColor="#003399" HorizontalAlign="Left" BackColor="#99CCCC" />
				<RowStyle BackColor="White" ForeColor="#003399" />
				<SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
				<SortedAscendingCellStyle BackColor="#EDF6F6" />
				<SortedAscendingHeaderStyle BackColor="#0D4AC4" />
				<SortedDescendingCellStyle BackColor="#D6DFDF" />
				<SortedDescendingHeaderStyle BackColor="#002876" />
			</asp:GridView><br />
			<asp:Button
				ID="btnAggiungiModello"
				runat="server"
				Text="Aggiungi Modello"
				OnClick="btnAggiungiFamiglia_Click"
				CommandArgument='<%#Eval("id_ArticoliFamiglie")%>'>
			</asp:Button>
		</div>
	</form>
</body>
</html>