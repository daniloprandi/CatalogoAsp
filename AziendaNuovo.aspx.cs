using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AziendaNuovo : System.Web.UI.Page
{
  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

  protected void Page_Load(object sender, EventArgs e)
  {
    if(!IsPostBack)
    {
      using (conn)
      {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from AziendeTipologie order by descrizione_AziendeTipologie", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        ListItem li = new ListItem("- SELEZIONA -", "");
        ddlTipologiaAzienda1.Items.Add(li);
        ddlTipologiaAzienda2.Items.Add(li);
        ddlTipologiaAzienda3.Items.Add(li);
        while (dr.Read())
        {
          li = new ListItem(dr["descrizione_AziendeTipologie"].ToString(), dr["id_AziendeTipologie"].ToString());
          ddlTipologiaAzienda1.Items.Add(li);
          ddlTipologiaAzienda2.Items.Add(li);
          ddlTipologiaAzienda3.Items.Add(li);
        }
        dr.Dispose();
        cmd.Dispose();
        cmd = new SqlCommand("select * from IndirizziTipologie", conn);
        dr = cmd.ExecuteReader();
        li = new ListItem("- SELEZIONA -", "");
        ddlTipologiaIndirizzo.Items.Add(li);
        while(dr.Read())
        {
          li = new ListItem(dr["descrizione_IndirizziTipologie"].ToString(),dr["id_IndirizziTipologie"].ToString());
          ddlTipologiaIndirizzo.Items.Add(li);
        }
        dr.Dispose();
        cmd.Dispose();
        cmd = new SqlCommand("select * from Province order by descrizione_Province ", conn);
        dr = cmd.ExecuteReader();
        li = new ListItem("- SELEZIONA -", "");
        ddlProvincia.Items.Add(li);
        while (dr.Read())
        {
          li = new ListItem(dr["id_Province"].ToString(), dr["descrizione_Province"].ToString());
          ddlProvincia.Items.Add(li);
        }
        dr.Dispose();
        cmd.Dispose();
        cmd = new SqlCommand("select * from Stati order by descrizione_Stati", conn);
        dr = cmd.ExecuteReader();
        li = new ListItem("- SELEZIONA -", "");
        ddlStato.Items.Add(li);
        while (dr.Read())
        {
          li = new ListItem(dr["descrizione_Stati"].ToString(), dr["id_Stati"].ToString());
          ddlStato.Items.Add(li);
        }
        dr.Dispose();
        cmd.Dispose();
        if (Request.QueryString["id_Aziende"] != null)
        {
          int idAziende = -1;
          if(Int32.TryParse(Request.QueryString["id_Aziende"].ToString(), out idAziende))
          {
            cmd = new SqlCommand("select * from Aziende where id_Aziende = @id_Aziende", conn);
            cmd.Parameters.Add("@id_Aziende", SqlDbType.Int).Value = idAziende;
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
              dr.Read();
              txtRagioneSociale.Text = dr["ragione_sociale_Aziende"].ToString();
              ddlTipologiaAzienda1.Items[ddlTipologiaAzienda1.SelectedIndex].Selected = false;
              ddlTipologiaAzienda1.Items.FindByValue(dr["id_AziendeTipologie"].ToString()).Selected = true;
              ddlTipologiaAzienda2.Items[ddlTipologiaAzienda2.SelectedIndex].Selected = false;
              ddlTipologiaAzienda2.Items.FindByValue(dr["id_AziendeTipologie"].ToString()).Selected = true;
              ddlTipologiaAzienda3.Items[ddlTipologiaAzienda3.SelectedIndex].Selected = false;
              ddlTipologiaAzienda3.Items.FindByValue(dr["id_AziendeTipologie"].ToString()).Selected = true;
              //ddlTipologiaAzienda.Items[ddlTipologiaAzienda.SelectedIndex].Selected = false;
              //ddlTipologiaAzienda.Items.FindByValue(dr["id_Aziende"].ToString()).Selected = true;
              dr.Dispose();
              cmd.Dispose();
            }
          }
        }
      }
    }
  }

  protected void cmdSalva_Click(object sender, EventArgs e)
  {
    using (conn)
    {
      conn.Open();
      SqlCommand cmd = new SqlCommand("Aziende_Inserisci", conn);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@ragione_sociale", txtRagioneSociale.Text);
      cmd.Parameters.AddWithValue("@partita_iva", txtPartitaIva.Text);
      cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text);
      cmd.Parameters.AddWithValue("@note", txtNote.Text);
      if (ckbAttivo.Checked == true)
        cmd.Parameters.AddWithValue("@attivo", ckbAttivo).Value = 's';
      cmd.Parameters.AddWithValue("@id_AziendeTipologie", ddlTipologiaAzienda1.SelectedValue);
      cmd.Parameters.Add("@res", SqlDbType.Char, 2).Direction = ParameterDirection.Output;
      cmd.ExecuteNonQuery();
      string res = cmd.Parameters["@res"].Value.ToString();
      cmd.Dispose();
      if (res == "OK")
        Response.Redirect("AziendaElenco.aspx");
      else
        lblErrori.Text = "Azienda non inserita";
    }
  }

  protected void cmdAnnulla_Click(object sender, EventArgs e)
  {
    txtRagioneSociale.Text = "";
    txtPartitaIva.Text = "";
    txtCodiceFiscale.Text = "";
    txtNote.Text = "";
    ckbAttivo.Checked = false;
  }
}