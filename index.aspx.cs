using System;

public partial class Menu : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void lnkbNuovoArticolo_Click(object sender, EventArgs e)
  {
    Response.Redirect("ArticoloNuovo.aspx");
  }

  protected void lnkbElencoArticoli_Click(object sender, EventArgs e)
  {
    Response.Redirect("ArticoloElenco.aspx");
  }

  protected void lnkbNuovaAzienda_Click(object sender, EventArgs e)
  {
    Response.Redirect("AziendaNuovo.aspx");
  }
}