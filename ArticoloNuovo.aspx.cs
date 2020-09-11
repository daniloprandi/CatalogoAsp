using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class ArticoloNuovo : Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      conn.Open();

      SqlCommand cmd = new SqlCommand("select id_ArticoliFamiglie, nome_ArticoliFamiglie from ArticoliFamiglie " +
        "order by nome_ArticoliFamiglie", conn);

      SqlDataReader dr = cmd.ExecuteReader();

      var item = new ListItem("- SELEZIONA -", "");
      //item = new ListItem("- SELEZIONA -", "");
      ddlFamiglia.Items.Add(item);
      while (dr.Read())
      {
        item = new ListItem(dr["nome_ArticoliFamiglie"].ToString(), dr["id_ArticoliFamiglie"].ToString());
        ddlFamiglia.Items.Add(item);
      }
      dr.Dispose();
      cmd.Dispose();

      cmd = new SqlCommand("select id_ArticoliModelli, nome_ArticoliModelli from ArticoliModelli " +
        "order by nome_ArticoliModelli", conn);
      dr = cmd.ExecuteReader();

      item = new ListItem("- SELEZIONA -", "");
      ddlModello.Items.Add(item);
      while (dr.Read())
      {
        item = new ListItem(dr["nome_ArticoliModelli"].ToString(), dr["id_ArticoliModelli"].ToString());
        ddlModello.Items.Add(item);
      }
      dr.Dispose();
      cmd.Dispose();

      if (Request.QueryString["id_Articoli"] != null)
      {
        // la pagina è chiamata in modifica
        // verifico che l'id passato sia un numero
        int id = -1;  // valore indicativo

        if (Int32.TryParse(Request.QueryString["id_Articoli"].ToString(), out id))
        {
          // verifico se l'id passato è presente
          // sulla base dati
          cmd = new SqlCommand("select * from Articoli where id_Articoli = @id_Articoli", conn);

          cmd.Parameters.Add("@id_Articoli", SqlDbType.Int).Value = id;
          dr = cmd.ExecuteReader();

          // controllo se ci sono dati relativi all'id passato
          if (dr.HasRows)
          {
            // ci sono dati
            dr.Read();
            txtCodice.Text = dr["codice_Articoli"].ToString();
            txtCodice.Enabled = false;
            txtDescrizione.Text = dr["descrizione_Articoli"].ToString();
            txtPrezzo.Text = dr["prezzo_Articoli"].ToString();
            txtNote.Text = dr["note_Articoli"].ToString();
            if (dr["attivo_Articoli"].ToString() == "s")
              ckbAttivo.Checked = true;
            ddlFamiglia.Items[ddlFamiglia.SelectedIndex].Selected = false;
            ddlFamiglia.Items.FindByValue(dr["id_ArticoliFamiglie"].ToString()).Selected = true;
            ddlModello.Items[ddlModello.SelectedIndex].Selected = false;
            ddlModello.Items.FindByValue(dr["id_ArticoliModelli"].ToString()).Selected = true;
            dr.Dispose();
            cmd.Dispose();
          }
        }
      }
      conn.Close();
    }
  }
  protected void btnAggiungiFamiglia_Click(object sender, EventArgs e)
  {
    Response.Redirect("FamigliaNuovo.aspx");
  }
  protected void btnAggiungiModello_Click(object sender, EventArgs e)
  {
    Response.Redirect("ModelloNuovo.aspx");
  }
  protected void btnSalvaAggiorna_Click(object sender, EventArgs e)
  {
    lblErrori.Text = "";
    if (txtCodice.Text.Trim() == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "Il <b>CODICE</b> è obbligatorio<br>";
      else
        lblErrori.Text = lblErrori.Text + "Il <b>CODICE</b> è obbligatorio<br>";
    }
    char[] codice = txtCodice.Text.Trim().ToCharArray();
    if (codice.Length != 8)
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "Formato <b>CODICE</b> sbagliato";
      else
        lblErrori.Text = lblErrori.Text + "Formato <b>CODICE</b> sbagliato";
    }
    if (txtDescrizione.Text.Trim() == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "<b>DESCRIZIONE</b> obbligatoria";
      else
        lblErrori.Text = lblErrori.Text + "<b>DESCRIZIONE</b> obbligatoria";
    }
    if (lblErrori.Text != "")
      return;

    conn.Open();
    SqlCommand cmd;

    if (Request.QueryString["id_Articoli"] == null)
    {
      cmd = new SqlCommand("Articoli_Inserisci", conn);

      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codice_Articoli", txtCodice.Text).Value = txtCodice.Text.ToUpper();
      cmd.Parameters.AddWithValue("@descrizione_Articoli", txtDescrizione.Text);
      cmd.Parameters.AddWithValue("@prezzo_Articoli", txtPrezzo.Text).Value = Decimal.Parse(txtPrezzo.Text);
      cmd.Parameters.AddWithValue("@note_Articoli", txtNote.Text).Value = txtNote.Text.ToLower();
      if (ckbAttivo.Checked == true)
        cmd.Parameters.AddWithValue("@attivo_Articoli", ckbAttivo.Text).Value = 's';
      else
        cmd.Parameters.AddWithValue("@attivo_Articoli", ckbAttivo.Text).Value = 'n';
      cmd.Parameters.AddWithValue("@id_ArticoliFamiglie", ddlFamiglia.SelectedValue);
      cmd.Parameters.AddWithValue("@id_ArticoliModelli", ddlModello.SelectedValue);
      cmd.Parameters.Add("@res", SqlDbType.Char, 2).Direction = ParameterDirection.Output;
      cmd.ExecuteNonQuery();
      string res = cmd.Parameters["@res"].Value.ToString();
      if (res == "OK")
        Response.Redirect("ArticoloElenco.aspx");
      else
        lblErrori.Text = "ATTENZIONE!! L'articolo non e' stato inserito";
    }
    else
    {
      cmd = new SqlCommand("UPDATE Articoli SET codice_Articoli = @codice_Articoli, " +
        "descrizione_Articoli = @descrizione_Articoli, prezzo_Articoli = @prezzo_Articoli, note_Articoli = @note_Articoli, " +
        "attivo_Articoli = @attivo_Articoli, id_ArticoliFamiglie = @id_ArticoliFamiglie, id_ArticoliModelli = @id_ArticoliModelli " +
        "WHERE id_Articoli = @id_Articoli", conn);

      cmd.Parameters.Add("@id_Articoli", SqlDbType.Int).Value = Request.QueryString["id_Articoli"].ToString();
      cmd.Parameters.AddWithValue("@codice_Articoli", txtCodice.Text).Value = txtCodice.Text.ToUpper();
      cmd.Parameters.AddWithValue("@descrizione_Articoli", txtDescrizione.Text);
      cmd.Parameters.AddWithValue("@prezzo_Articoli", txtPrezzo.Text).Value = Decimal.Parse(txtPrezzo.Text);
      cmd.Parameters.AddWithValue("@note_Articoli", txtNote.Text).Value = txtNote.Text.ToLower(); 
      if (ckbAttivo.Checked == true)
        cmd.Parameters.AddWithValue("@attivo_Articoli", ckbAttivo.Checked).Value = 's';
      else
        cmd.Parameters.AddWithValue("@attivo_Articoli", ckbAttivo).Value = 'n';
      cmd.Parameters.AddWithValue("@id_ArticoliFamiglie", ddlFamiglia.SelectedValue);
      cmd.Parameters.AddWithValue("@id_ArticoliModelli", ddlModello.SelectedValue);
      cmd.ExecuteNonQuery();
      Response.Redirect("ArticoloElenco.aspx");
    }
  }
  protected void btnAnnulla_Click(object sender, EventArgs e)
  {
    txtCodice.Text = "";
    txtDescrizione.Text = "";
    txtPrezzo.Text = "";
    txtNote.Text = "";
    ckbAttivo.Checked = false;
    ddlFamiglia.Items[ddlFamiglia.SelectedIndex].Selected = false;
    ddlModello.Items[ddlModello.SelectedIndex].Selected = false;
  }
  protected void btnVaiElencoArticoli_Click(object sender, EventArgs e)
  {
    Response.Redirect("ArticoloElenco.aspx");
  }
}