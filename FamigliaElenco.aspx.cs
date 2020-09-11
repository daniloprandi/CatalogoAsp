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
    SqlDataAdapter da = new SqlDataAdapter("select * from ArticoliFamiglie order by attivo_ArticoliFamiglie DESC, nome_ArticoliFamiglie", conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    conn.Open();
    gvArticoliFamiglie.DataSource = dt;
    gvArticoliFamiglie.DataBind();
    conn.Close();
  }

  protected void Modifica_Click(object sender, EventArgs e)
  {
    string id_ArticoliFamiglie = ((LinkButton)sender).CommandArgument.ToString();
    Response.Redirect("FamigliaNuovo.aspx?id_ArticoliFamiglie=" + id_ArticoliFamiglie);
  }

  protected void Cancella_Click(object sender, EventArgs e)
  {

  }

  protected void btnAggiungiFamiglia_Click(object sender, EventArgs e)
  {
    Response.Redirect("FamigliaNuovo.aspx");
  }
}