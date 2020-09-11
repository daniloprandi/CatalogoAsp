using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ModelloNuovo : System.Web.UI.Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      conn.Open();
      SqlCommand cmd = new SqlCommand("Select id_ArticoliFamiglie, nome_ArticoliFamiglie from ArticoliFamiglie", conn);
      SqlDataReader dr = cmd.ExecuteReader(); // risultato 
      ListItem item = new ListItem("- SELEZIONA -", "");
      ddlFamiglie.Items.Add(item);
      while (dr.Read())
      {
        item = new ListItem(dr["nome_ArticoliFamiglie"].ToString(), dr["id_ArticoliFamiglie"].ToString());
        ddlFamiglie.Items.Add(item);
      }
      dr.Close();
      cmd.Dispose();
      if (Request.QueryString["id_ArticoliModelli"] != null)
      {
        btnSalvaAggiorna.Text = "Aggiorna";
        lblInsModModello.Text = "MODIFICA MODELLO";
        // la pagina è chiamata in modifica
        // verifico che l'id passato sia un numero
        int id;  // valore indicativo 
        if (Int32.TryParse(Request.QueryString["id_ArticoliModelli"].ToString(), out id))
        {
          // verifico se l'id passato è presente
          // sulla base dati
          cmd = new SqlCommand("select * from ArticoliModelli where id_ArticoliModelli = @id_ArticoliModelli", conn);
          //cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@id_ArticoliModelli", id);

          dr = cmd.ExecuteReader(); // risultato

          // controllo se ci sono dati relativi all'id passato
          if (dr.HasRows)
          {
            // ci sono dati
            dr.Read();
            txtNome.Text = dr["nome_ArticoliModelli"].ToString();
            txtDescrizione.Text = dr["descrizione_ArticoliModelli"].ToString();
            if (dr["attivo_ArticoliModelli"].ToString() == "s")
              ckbAttivo.Checked = true;
            ddlFamiglie.Items[ddlFamiglie.SelectedIndex].Selected = false;
            ddlFamiglie.Items.FindByValue(dr["id_ArticoliFamiglie"].ToString()).Selected = true;
          }
        }

      }
      conn.Close();
    }
  }

  protected void btnSalvaAggiorna_Click(object sender, EventArgs e)
  {
    lblErrori.Text = "";

    if (txtNome.Text.Trim() == "")
      lblErrori.Text = "Il campo <b>NOME</b> è obbligatorio";

    if (lblErrori.Text != "")
      return;

    conn.Open();
    SqlCommand cmd;
    // verifico se la pagina è chiamata in modifica
    // sui dati di un oggetto esistente
    if (Request.QueryString["id_ArticoliModelli"] == null)
    {
      cmd = new SqlCommand("ArticoliModelli_Inserisci", conn);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@nome_ArticoliModelli", txtNome.Text);
      cmd.Parameters.AddWithValue("@descrizione_ArticoliModelli", txtDescrizione.Text);
      if (ckbAttivo.Checked == true)
        cmd.Parameters.AddWithValue("@attivo_ArticoliModelli", ckbAttivo.Checked).Value = 's';
      else
        cmd.Parameters.AddWithValue("@attivo_ArticoliModelli", ckbAttivo).Value = 'n';
      cmd.Parameters.AddWithValue("@id_ArticoliFamiglie", ddlFamiglie.SelectedValue);
      cmd.Parameters.Add("@res", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
      cmd.ExecuteNonQuery();   //store procedure che non ritorna nessuna riga
      string res = cmd.Parameters["@res"].Value.ToString();
      cmd.Dispose();
      conn.Close();
      if (res == "OK")
        Response.Redirect("ModelloElenco.aspx");
      else
        lblErrori.Text = "ATTENZIONE!! Il MODELLO non e' stato inserito";
    }
    else
    {
      cmd = new SqlCommand("UPDATE ArticoliModelli SET nome_ArticoliModelli = @nome_ArticoliModelli, descrizione_ArticoliModelli = @descrizione_ArticoliModelli, attivo_ArticoliModelli = @attivo_ArticoliModelli, id_ArticoliFamiglie = @id_ArticoliFamiglie WHERE id_ArticoliModelli = @id_ArticoliModelli", conn);
      cmd.Parameters.Add("@id_ArticoliModelli", SqlDbType.Int).Value = Request.QueryString["id_ArticoliModelli"].ToString();
      cmd.Parameters.AddWithValue("@nome_ArticoliModelli", txtNome.Text);
      cmd.Parameters.AddWithValue("@descrizione_ArticoliModelli", txtDescrizione.Text);
      if (ckbAttivo.Checked == true)
        cmd.Parameters.AddWithValue("@attivo_ArticoliModelli", ckbAttivo.Checked).Value = 's';
      else
        cmd.Parameters.AddWithValue("@attivo_ArticoliModelli", ckbAttivo).Value = 'n';
      cmd.Parameters.AddWithValue("@id_ArticoliFamiglie", ddlFamiglie.SelectedValue);
      cmd.ExecuteNonQuery();   //store procedure che non ritorna nessuna riga
      cmd.Dispose();
      conn.Close();
      Response.Redirect("ModelloElenco.aspx");
    }
  }

  protected void btnAnnulla_Click(object sender, EventArgs e)
  {
    txtNome.Text = "";
    txtDescrizione.Text = "";
    ckbAttivo.Checked = false;
    ddlFamiglie.Items[ddlFamiglie.SelectedIndex].Selected = false;
  }

  protected void btnAggiungiFamiglia_Click(object sender, EventArgs e)
  {
    Response.Redirect("FamigliaNuovo.aspx");
  }

  protected void btnElencoModelli_Click(object sender, EventArgs e)
  {
    Response.Redirect("ModelloElenco.aspx");
  }
}