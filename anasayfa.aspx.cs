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
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] != null)
            {
                isim1.Text = (string)Session["adSoyad"];
                isim2.InnerHtml = (string)Session["adSoyad"];
                isim3.InnerHtml = (string)Session["adSoyad"] + "-" + (string)Session["ogrnum"];
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            //güncelf.InnerHtml = (string)Session["bakiye"];
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string selectsorgusu = string.Format("select * from kullanici where eposta='{0}' and sifre='{1}'", Session["KullaniciAdi"], Session["sifre1"]);
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            if (tablo.Rows.Count == 0)
            {
                Response.Write("<script>alert('kullanici adi veya sifre yanlis');</script>");
            }
            else
            {

                DataRow[] rows = tablo.Select();
                Session["bakiye"] = rows[0]["hesabındakibakiye"].ToString();
            }
            güncelf.InnerHtml = (string)Session["bakiye"];
        }

        protected void btn_open_Click(object sender, EventArgs e)
        {
                if (div_open.Visible == true) { div_open.Visible = false; } else { div_open.Visible = true; }

        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Session["KullaniciAdi"] = null;
            Response.Redirect("login.aspx");
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            div1.Visible = false;
            div2.Visible = true;

            int sayi;
            sayi = Convert.ToInt32(para.Text);
            //sayi=sayi + Int32.Parse((string)Session["bakiye"]);

            //******************************************************
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string selectsorgusu = string.Format("select * from kullanici where eposta='{0}' and sifre='{1}'", Session["KullaniciAdi"], Session["sifre1"]);
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            if (tablo.Rows.Count == 0)
            {
                Response.Write("<script>alert('kullanici adi veya sifre yanlis');</script>");
            }
            else
            {

                DataRow[] rows1 = tablo.Select();
                Session["bakiye"] = rows1[0]["hesabındakibakiye"].ToString();
            }
            

            sayi =sayi+ Int32.Parse((string)Session["bakiye"]);
            Session["bakiye"] = sayi.ToString();
            güncelf.InnerHtml = (string)Session["bakiye"];
            //****************************************





            SqlConnection baglanti1 = new SqlConnection();
            baglanti1.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu = "select * from kullanici";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu, baglanti1);
            string sorgu2 = string.Format("update kullanici set hesabındakiBakiye='{0}' where eposta='{1}'", sayi, (string)Session["KullaniciAdi"]);
            adapter1.UpdateCommand = new SqlCommand(sorgu2, baglanti1);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);
            DataRow cater = tablo1.Rows[0];
            cater["hesabındakiBakiye"] = 20; /*sayı önemsiz etkisi yok*/
            adapter1.Update(tablo1);

            SqlConnection baglanti2 = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string selectsorgusu2 = string.Format("select * from kullanici where eposta='{0}'", (string)Session["KullaniciAdi"]);
            SqlDataAdapter adapter2 = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo2 = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();
            //güncelf.InnerHtml=rows[0]["hesabındakibakiye"].ToString();

        }

        protected void geri_btn_Click(object sender, EventArgs e)
        {
            div1.Visible = true;
            div2.Visible = false;
        }

        protected void Unnamed4_TextChanged(object sender, EventArgs e)
        {
        }

        protected void Unnamed3_TextChanged(object sender, EventArgs e)
        {
            /* güncel bakiye*/
        }
    }
}


/*protected void Unnamed_Click1(object sender, EventArgs e)
        {
            bool SayiMi(string text)
            {
                foreach (char chr in text)
                {
                    if (!Char.IsNumber(chr)) return false;
                }
                return true;
            }*/
/*<br />
            <font runat="server" visible="false" Id="kontrol">Yanlış bir değer girdiniz!</font>*/