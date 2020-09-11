using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class FamigliaElenco : System.Web.UI.Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

  protected void Page_Load(object sender, EventArgs e)
  {
    using (conn)
    {
      conn.Open();
      SqlDataAdapter da = 
        new SqlDataAdapter("SELECT id_ArticoliModelli, nome_ArticoliModelli, descrizione_ArticoliModelli, attivo_ArticoliModelli, " +
        "nome_ArticoliFamiglie FROM ArticoliModelli INNER JOIN ArticoliFamiglie ON " +
        "ArticoliModelli.id_ArticoliFamiglie = ArticoliFamiglie.id_ArticoliFamiglie", conn);
      DataTable dt = new DataTable();
      da.Fill(dt);
      gvArticoliModelli.DataSource = dt;
      gvArticoliModelli.DataBind();
    }
  }

  protected void Modifica_Click(object sender, EventArgs e)
  {
    string id_ArticoliModelli = ((LinkButton)sender).CommandArgument.ToString();
    Response.Redirect("ModelloNuovo.aspx?id_ArticoliModelli=" + id_ArticoliModelli);
  }

  protected void Cancella_Click(object sender, EventArgs e)
  {

  }

  protected void btnAggiungiFamiglia_Click(object sender, EventArgs e)
  {
    Response.Redirect("ModelloNuovo.aspx");
  }
}