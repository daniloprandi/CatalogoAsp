<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamigliaElenco.aspx.cs" Inherits="FamigliaElenco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family:Arial">
			<header>
				<b>ELENCO FAMIGLIE:<br />
					<br />
				</b>
			</header>
			<asp:GridView ID="gvArticoliFamiglie" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
				<Columns>
					<asp:BoundField DataField="id_ArticoliFamiglie" HeaderText="ID" />
					<asp:BoundField DataField="nome_ArticoliFamiglie" HeaderText="NOME" />
					<asp:BoundField DataField="descrizione_ArticoliFamiglie" HeaderText="DESCRIZIONE" />
					<asp:BoundField DataField="attivo_ArticoliFamiglie" HeaderText="ATTIVO" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton
								ID="lnkbModifica"
								runat="server"
								Text="Modifica"
								OnClick="Modifica_Click"
								CommandArgument='<%#Eval("id_ArticoliFamiglie")%>'>
							</asp:LinkButton>
							<asp:LinkButton
								ID="lnkbCancella"
								runat="server"
								Text="Cancella"
								OnClick="Cancella_Click"
								CommandArgument='<%#Eval("id_ArticoliFamiglie")%>'>
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
				ID="btnAggiungiFamiglia"
				runat="server"
				Text="Aggiungi Famiglia"
				OnClick="btnAggiungiFamiglia_Click"
				CommandArgument='<%#Eval("id_ArticoliFamiglie")%>'>
			</asp:Button>
		</div>
	</form>
</body>
</html>