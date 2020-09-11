using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ArticoloElenco : System.Web.UI.Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
  {
    SqlDataAdapter da =
      new SqlDataAdapter("select id_Articoli, codice_Articoli, descrizione_Articoli, prezzo_Articoli, note_Articoli, attivo_Articoli, nome_ArticoliFamiglie, " +
      "nome_ArticoliModelli from Articoli inner join ArticoliFamiglie on Articoli.id_ArticoliFamiglie = ArticoliFamiglie.id_ArticoliFamiglie inner join ArticoliModelli " +
      "on Articoli.id_ArticoliModelli = ArticoliModelli.id_ArticoliModelli order by attivo_Articoli desc, descrizione_Articoli", conn);
    DataSet ds = new DataSet();
    da.Fill(ds);
    Cache["Data"] = ds;
    gvArticoli.DataSource = ds;
    gvArticoli.DataBind();
    conn.Open();
    SqlCommand cmd = new SqlCommand("select count(*) from Articoli", conn);
    txtNumArt.Text = cmd.ExecuteScalar().ToString();
    txtNumArt.Enabled = false;
    cmd.Dispose();
    conn.Close();
  }

  protected void lnkbModifica_Click(object sender, EventArgs e)
  {
    string id_Articoli = ((LinkButton)sender).CommandArgument.ToString();
    Response.Redirect("ArticoloNuovo.aspx?id_Articoli=" + id_Articoli);
  }

  protected void lnkbCancella_Click(object sender, EventArgs e)
  {

  }

  protected void btnAggiungiArticolo_Click(object sender, EventArgs e)
  {
    Response.Redirect("ArticoloNuovo.aspx");
  }

  protected void btnCerca_Click(object sender, EventArgs e)
  {
    SqlCommand cmd = new SqlCommand("select id_Articoli, codice_Articoli, descrizione_Articoli, prezzo_Articoli, note_Articoli, attivo_Articoli, nome_ArticoliFamiglie, " +
      "nome_ArticoliModelli from Articoli inner join ArticoliFamiglie on Articoli.id_ArticoliFamiglie = ArticoliFamiglie.id_ArticoliFamiglie inner join ArticoliModelli " +
      "on Articoli.id_ArticoliModelli = ArticoliModelli.id_ArticoliModelli where descrizione_Articoli like @descrizione or codice_Articoli like @codice " +
      "order by attivo_Articoli desc, descrizione_Articoli", conn);
    cmd.Parameters.AddWithValue("@codice", txtCerca.Text + "%");
    cmd.Parameters.AddWithValue("@descrizione", txtCerca.Text + "%");
    conn.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    gvArticoli.DataSource = dr;
    gvArticoli.DataBind();
    dr.Dispose();
    cmd = new SqlCommand("select COUNT(*) from Articoli where descrizione_Articoli like @descrizione or codice_Articoli like @codice"
      , conn);
    cmd.Parameters.AddWithValue("@codice", txtCerca.Text + "%");
    cmd.Parameters.AddWithValue("@descrizione", txtCerca.Text + "%");
    txtNumArt.Text = cmd.ExecuteScalar().ToString();
    conn.Close();
  }

  protected void lnkbVisualizza_Click(object sender, EventArgs e)
  {
    string id_Articoli = ((LinkButton)sender).CommandArgument.ToString();
    Response.Redirect("ArticoloNuovo.aspx?id_Articoli=" + id_Articoli);
  }

  protected void btnElencoArticoli_Click(object sender, EventArgs e)
  {
    Response.Redirect("ArticoloElenco.aspx");
  }

  protected void btnMenuPrincipale_Click(object sender, EventArgs e)
  {
    Response.Redirect("Menu.aspx");
  }
}