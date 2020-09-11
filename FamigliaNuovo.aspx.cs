using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class FamigliaNuovo : System.Web.UI.Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      conn.Open();
      // verifico se la pagina è chiamata in modifica di un oggetto esistente
      if (Request.QueryString["id_ArticoliFamiglie"] != null)
      {
        lblInsModFamiglia.Text = "MODIFICA FAMIGLIA";
        btnSalvaAggiorna.Text = "AGGIORNA";
        // la pagina è chiamata in modifica
        // verifico che il codice cliente passato sia un numero

        int id = -1; // valore indicativo

        if (Int32.TryParse(Request.QueryString["id_ArticoliFamiglie"].ToString(), out id))
        {
          // verifico se l'id passato è presente
          // sulla base dati
          SqlCommand cmd = new SqlCommand("select * from ArticoliFamiglie where id_ArticoliFamiglie = @id", conn);
          cmd.Parameters.AddWithValue("@id", id);
          SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
          // controllo se ci sono dati relativi all'id passato
          if (dr.HasRows)
          {
            //ci sono dati
            dr.Read();
            txtNome.Text = dr["nome_ArticoliFamiglie"].ToString();
            txtDescrizione.Text = dr["descrizione_ArticoliFamiglie"].ToString();
            if (dr["attivo_ArticoliFamiglie"].ToString() == "s")
              ckbAttivo.Checked = true;
          }
          cmd.Dispose();

          // SQL COMMAND BUILDER

          //string query = "select * from ArticoliFamiglie where id_ArticoliFamiglie = @id";
          //SqlDataAdapter da = new SqlDataAdapter(query, conn);
          //da.SelectCommand.Parameters.AddWithValue("@id", id);
          //DataSet ds = new DataSet();
          //da.Fill(ds, "Famiglie");
          //ViewState["SQL_QUERY"] = query;
          //ViewState["DATASET"] = ds;
          //DataRow dRow = ds.Tables["Famiglie"].Rows[0];
          //txtNome.Text = dRow["nome_ArticoliFamiglie"].ToString();
          //txtDescrizione.Text = dRow["descrizione_ArticoliFamiglie"].ToString();
          //if (dRow["attivo_ArticoliFamiglie"].ToString() == "s")
          //  ckbAttivo.Checked = true;
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

    #region SqlCommandBuilder
    //SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], conn);
    //SqlCommandBuilder builder = new SqlCommandBuilder(da);
    //DataSet ds = (DataSet)ViewState["DATASET"];
    //if (Request.QueryString["id_ArticoliFamiglie"] != null)
    //{
    //  da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = Request.QueryString["id_ArticoliFamiglie"].ToString();
    //  DataRow dRow = ds.Tables["Famiglie"].Rows[0];
    //  dRow["nome_ArticoliFamiglie"] = txtNome.Text;
    //  dRow["descrizione_ArticoliFamiglie"] = txtDescrizione.Text;
    //  if (ckbAttivo.Checked == true)
    //    dRow["attivo_ArticoliFamiglie"] = "s";
    //  else
    //    dRow["attivo_ArticoliFamiglie"] = "n";

    //  da.Update(ds, "Famiglie");
    //  Response.Redirect("FamigliaElenco.aspx");
    //}
    //else
    //{
    //  string ins = da.InsertCommand.CommandText;
    //}
    #endregion

    SqlCommand cmd;

    conn.Open();
    // verifico se la pagina è chiamata in modifica
    // sui dati di un oggetto esistente
    if (Request.QueryString["id_ArticoliFamiglie"] == null)
    {
      cmd = new SqlCommand("ArticoliFamiglie_Inserisci", conn);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@nome_ArticoliFamiglie", txtNome.Text);
      cmd.Parameters.AddWithValue("@descrizione_ArticoliFamiglie", txtDescrizione.Text);
      if (ckbAttivo.Checked == true)
        cmd.Parameters.Add("@attivo_ArticoliFamiglie", SqlDbType.Char, 1).Value = 's';
      else
        cmd.Parameters.Add("@attivo_ArticoliFamiglie", SqlDbType.Char, 1).Value = 'n';
      cmd.Parameters.Add("@res", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
      cmd.ExecuteNonQuery();
      string res = cmd.Parameters["@res"].Value.ToString();
      cmd.Dispose();
      conn.Close();
      if (res == "OK")
        Response.Redirect("FamigliaElenco.aspx");
      else
        lblErrori.Text = "ATTENZIONE!! Il cliente non e' stato inserito";
    }
    else
    {
      cmd = new SqlCommand("update ArticoliFamiglie set nome_ArticoliFamiglie = @nome_ArticoliFamiglie, descrizione_ArticoliFamiglie = @descrizione_ArticoliFamiglie, " +
        "attivo_ArticoliFamiglie = @attivo_ArticoliFamiglie where " +
        "id_ArticoliFamiglie = @id_ArticoliFamiglie", conn);
      cmd.Parameters.AddWithValue("@nome_ArticoliFamiglie", txtNome.Text);
      cmd.Parameters.AddWithValue("@descrizione_ArticoliFamiglie", txtDescrizione.Text);
      if (ckbAttivo.Checked == true)
        cmd.Parameters.Add("@attivo_ArticoliFamiglie", SqlDbType.Char, 1).Value = "s";
      else
        cmd.Parameters.Add("@attivo_ArticoliFamiglie", SqlDbType.Char, 1).Value = "n";
      cmd.Parameters.Add("@id_ArticoliFamiglie", SqlDbType.Int).Value = Request.QueryString["id_ArticoliFamiglie"].ToString();
      cmd.ExecuteNonQuery();
      Response.Redirect("FamigliaElenco.aspx");
    }
    conn.Close();
  }
  protected void btnAnnulla_Click(object sender, EventArgs e)
  {
    txtNome.Text = "";
    txtDescrizione.Text = "";
    ckbAttivo.Checked = false;
  }
  protected void btnElencoFamiglie_Click(object sender, EventArgs e)
  {
    Response.Redirect("FamigliaElenco.aspx");
  }
}