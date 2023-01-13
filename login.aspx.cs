using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gp
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sifre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string selectsorgusu = string.Format("select * from kullanici where eposta='{0}' and sifre='{1}'", kullaniciAdi.Text, sifre.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo= new DataTable();
            adapter.Fill(tablo);
            if (tablo.Rows.Count == 0 )
            {
                Response.Write("<script>alert('kullanici adi veya sifre yanlis');</script>");
            }
            else
            {
                
                DataRow[] rows = tablo.Select();
                Session["KullaniciAdi"] = rows[0]["eposta"].ToString();
                Session["adSoyad"] = rows[0]["AdSoyad"].ToString();
                Session["sifre1"] = rows[0]["sifre"].ToString();
                Session["ogrnum"]= rows[0]["id"].ToString();
                Session["bakiye"] = rows[0]["hesabındakibakiye"].ToString();
                Response.Redirect("anasayfa.aspx");
            }
        }
    }
}

