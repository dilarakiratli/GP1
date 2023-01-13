using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace gp1._1
{






    public partial class rezervasyon : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(); /*veri tabanın ile bağlıyoruz using System.Data.SqlClient;*/
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
            
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString; /*nereye bağlayacğımız using System.Configuration;*/
            string selectsorgusu = string.Format("select * from yemekListesi");
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();
            ta0.InnerHtml = rows[0]["tarih"].ToString();
            ta1.InnerHtml = rows[1]["tarih"].ToString();
            ta2.InnerHtml = rows[2]["tarih"].ToString();
            ta3.InnerHtml = rows[3]["tarih"].ToString();
            ta4.InnerHtml = rows[4]["tarih"].ToString();

            ta6.InnerHtml = rows[16]["tarih"].ToString();
            ta7.InnerHtml = rows[17]["tarih"].ToString();
            ta8.InnerHtml = rows[18]["tarih"].ToString();
            ta9.InnerHtml = rows[19]["tarih"].ToString();
            ta10.InnerHtml = rows[20]["tarih"].ToString();

            string selectsorgusu1 = string.Format("select * from rezervasyonlar where kullaniciID = '{0}'", Int32.Parse((string)Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);
            DataRow[] rows1 = tablo1.Select();

            for ( int i = 0; i < rows1.Length; i++)
            {
                if (rows1[i]["yemekTarih"].Equals(ta0.InnerHtml.ToString()))
                {
                    Abtn1.Visible = false;
                    Abtn2.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta1.InnerHtml.ToString()))
                {
                    Abtn3.Visible = false;
                    Abtn4.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta2.InnerHtml.ToString()))
                {
                    Abtn5.Visible = false;
                    Abtn6.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta3.InnerHtml.ToString()))
                {
                    Abtn7.Visible = false;
                    Abtn8.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta4.InnerHtml.ToString()))
                {
                    Abtn9.Visible = false;
                    Abtn10.Visible = true;
                }
            }

            for (int i = 16; i < rows1.Length; i++)
            {
                if (rows1[i]["yemekTarih"].Equals(ta6.InnerHtml.ToString()))
                {
                    Obtn1.Visible = false;
                    Obtn2.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta7.InnerHtml.ToString()))
                {
                    Obtn3.Visible = false;
                    Obtn4.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta8.InnerHtml.ToString()))
                {
                    Obtn5.Visible = false;
                    Obtn6.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta9.InnerHtml.ToString()))
                {
                    Obtn7.Visible = false;
                    Obtn8.Visible = true;
                }

                if (rows1[i]["yemekTarih"].Equals(ta10.InnerHtml.ToString()))
                {
                    Obtn9.Visible = false;
                    Obtn10.Visible = true;
                }
            }
        }

        protected void Abtn1_Click(object sender, EventArgs e)
        {
            Abtn1.Visible = false;
            Abtn2.Visible = true;
            Abtn1.Enabled = false;
            Abtn2.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
                komut3.ExecuteNonQuery();
            }
        }
        protected void Abtn2_Click(object sender, EventArgs e)
        {
            Abtn1.Visible = true;
            Abtn2.Visible = false;
            Abtn1.Enabled = true;
            Abtn2.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        protected void Abtn3_Click(object sender, EventArgs e)
        {
            Abtn3.Visible = false;
            Abtn4.Visible = true;
            Abtn3.Enabled = false;
            Abtn4.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {

                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
                komut3.ExecuteNonQuery();
            }
            //    string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            //SqlCommand komut;
            //komut = new SqlCommand(sorgu2, baglanti);
            //komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            //komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            //baglanti.Open();
            //komut.ExecuteNonQuery();
            //baglanti.Close();
        }



        protected void Abtn4_Click(object sender, EventArgs e)
        {
            Abtn3.Visible = true;
            Abtn4.Visible = false;
            Abtn3.Enabled = true;
            Abtn4.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Abtn5_Click(object sender, EventArgs e)
        {
            Abtn5.Visible = false;
            Abtn6.Visible = true;
            Abtn5.Enabled = false;
            Abtn6.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;



            //string selectsorgusu = string.Format("select * from kullanici where eposta='{0}'", Session["ogrnum"];
            //SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            //DataTable tablo = new DataTable();
            //adapter.Fill(tablo);
            
            

            //    DataRow[] rows = tablo.Select();
            //    Session["KullaniciAdi"] = rows[0]["eposta"].ToString();
            //    Session["adSoyad"] = rows[0]["AdSoyad"].ToString();
            //    Session["sifre1"] = rows[0]["sifre"].ToString();
            //    Session["ogrnum"] = rows[0]["id"].ToString();
            //    Session["bakiye"] = rows[0]["hesabındakibakiye"].ToString();
            


            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"])>10) {
                /*
                   string sorgu = "select * from kullanici";
                   SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu, baglanti);
                   string sorgu3 = string.Format("update kullanici set hesabındakiBakiye='{0}' where eposta='{1}'", Int32.Parse((string)Session["bakiye"]) - 10, (string)Session["KullaniciAdi"]);

                   adapter1.UpdateCommand = new SqlCommand(sorgu3, baglanti);
                   DataTable tablo1 = new DataTable();
                   adapter1.Fill(tablo1);
                   DataRow cater = tablo1.Rows[0];
                   cater["hesabındakiBakiye"] = 10; /*sayı önemsiz etkisi yok
                   adapter1.Update(tablo1); */




                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();
            }
            /*bakiye 2.  basınca 20 olarak azaltıyo*/
        }



        protected void Abtn6_Click(object sender, EventArgs e)
        {
            Abtn5.Visible = true;
            Abtn6.Visible = false;
            Abtn5.Enabled = true;
            Abtn6.Enabled= false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
            komut.ExecuteNonQuery();


            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) ));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
         
            komut3.ExecuteNonQuery();



            /*
            string sorgu = "select * from kullanici";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu, baglanti);
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye='{0}' where eposta='{1}'", Int32.Parse((string)Session["bakiye"]) + 10, (string)Session["KullaniciAdi"]);

            adapter1.UpdateCommand = new SqlCommand(sorgu3, baglanti);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);
            DataRow cater = tablo1.Rows[0];
            cater["hesabındakiBakiye"] = 10; /*sayı önemsiz etkisi yok
            adapter1.Update(tablo1);*/
            baglanti.Close();


            /* 
             string sorgu = "select * from kullanici";
             string sorgu3 = string.Format("update kullanici set hesabındakiBakiye='{0}' where eposta='{1}'", Int32.Parse((string)Session["bakiye"]) +10, (string)Session["KullaniciAdi"]);
             SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu, baglanti);
             adapter1.UpdateCommand = new SqlCommand(sorgu3, baglanti);
             DataTable tablo1 = new DataTable();
             adapter1.Fill(tablo1);
             DataRow cater = tablo1.Rows[0];
             cater["hesabındakiBakiye"] = 10; /*sayı önemsiz etkisi yok*/
            //adapter1.Update(tablo1);

            /*bakiye iptal basınca 20 olarak arttırıyo*/
        }



        protected void Abtn7_Click(object sender, EventArgs e)
        { 
            Abtn7.Visible = false;
            Abtn8.Visible = true;
            Abtn7.Enabled = false;
            Abtn8.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {

                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
                komut3.ExecuteNonQuery();


            }
        }



        protected void Abtn8_Click(object sender, EventArgs e)
        {
            Abtn7.Visible = true;
            Abtn8.Visible = false;
            Abtn7.Enabled = true;
            Abtn8.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
            komut.ExecuteNonQuery();


            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Abtn9_Click(object sender, EventArgs e)
        {
            Abtn9.Visible = false;
            Abtn10.Visible = true;
            Abtn9.Enabled = false;
            Abtn10.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {

                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();


            }
        }



        protected void Abtn10_Click(object sender, EventArgs e)
        {
            Abtn9.Visible = true;
            Abtn10.Visible = false;
            Abtn9.Enabled = true;
            Abtn10.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
            komut.ExecuteNonQuery();


            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        protected void Obtn1_Click(object sender, EventArgs e)
        {
            Obtn1.Visible = false;
            Obtn2.Visible = true;
            Obtn1.Enabled = false;
            Obtn2.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);
                komut3.ExecuteNonQuery();
            }
        }



        protected void Obtn2_Click(object sender, EventArgs e)
        {
            Obtn1.Visible = true;
            Obtn2.Visible = false;
            Obtn1.Enabled = true;
            Obtn2.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Obtn3_Click(object sender, EventArgs e)
        {
            Obtn3.Visible = false;
            Obtn4.Visible = true;
            Obtn3.Enabled = false;
            Obtn4.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();


            }
        }



        protected void Obtn4_Click(object sender, EventArgs e)
        {
            Obtn3.Visible = true;
            Obtn4.Visible = false;
            Obtn3.Enabled = true;
            Obtn4.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Obtn5_Click(object sender, EventArgs e)
        {
            Obtn5.Visible = false;
            Obtn6.Visible = true;
            Obtn5.Enabled = false;
            Obtn6.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();


            }
        }



        protected void Obtn6_Click(object sender, EventArgs e)
        {
            Obtn5.Visible = true;
            Obtn6.Visible = false;
            Obtn5.Enabled = true;
            Obtn6.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Otbn7_Click(object sender, EventArgs e)
        {
            Obtn7.Visible = false;
            Obtn8.Visible = true;
            Obtn7.Enabled = false;
            Obtn8.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();


            }
        }



        protected void Obtn8_Click(object sender, EventArgs e)
        {
            Obtn7.Visible = true;
            Obtn8.Visible = false;
            Obtn7.Enabled = true;
            Obtn8.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }



        protected void Obtn9_Click(object sender, EventArgs e)
        {
            Obtn9.Visible = false;
            Obtn10.Visible = true;
            Obtn9.Enabled = false;
            Obtn10.Enabled = true;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();



            if (Int32.Parse((string)Session["bakiye"]) > 10)
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();
                string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
                SqlCommand komut3;
                komut3 = new SqlCommand(sorgu3, baglanti);
                komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
                komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

                komut3.ExecuteNonQuery();


            }
        }



        protected void Obtn10_Click(object sender, EventArgs e)
        {
            Obtn9.Visible = true;
            Obtn10.Visible = false;
            Obtn9.Enabled = true;
            Obtn10.Enabled = false;

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();
            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            SqlCommand komut3;
            komut3 = new SqlCommand(sorgu3, baglanti);
            komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"])));
            komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);

            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        protected void hyobtn0_Click(object sender, EventArgs e)
    {

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta6.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyobtn0.Text = buttonText;

            baglanti.Close();
        }

 

    protected void hyobtn1_Click(object sender, EventArgs e)
    {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta7.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyobtn1.Text = buttonText;

            baglanti.Close();


        }

 

    protected void hyobtn2_Click(object sender, EventArgs e)
    {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta7.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyobtn2.Text = buttonText;

            baglanti.Close();
        }

 

    protected void hyobtn3_Click(object sender, EventArgs e)
    {

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta8.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyobtn3.Text = buttonText;

            baglanti.Close();
        }

 

    protected void hyobtn4_Click(object sender, EventArgs e)
    {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta9.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyobtn4.Text = buttonText;

            baglanti.Close();
        }


        protected void hyabtn0_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'" , ta0.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'" , rows[0]["yemek_sayisi"].ToString() );

        

            hyabtn0.Text = buttonText;

            baglanti.Close();

        }

        protected void hyabtn1_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta1.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());
            hyabtn1.Text = buttonText;
            baglanti.Close();

        }

        protected void hyabtn2_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta2.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyabtn2.Text = buttonText;

            baglanti.Close();

        }

        protected void hyabtn3_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta3.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyabtn3.Text = buttonText;

            baglanti.Close();

        }

        protected void hyabtn4_Click(object sender, EventArgs e)
        {
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);


            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
            baglanti.Open();
            komut.ExecuteNonQuery();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from askiYemek where yemekTarih = '{0}'", ta4.InnerHtml.ToString());
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            string buttonText = string.Format("yemek sayısı : '{0}'", rows[0]["yemek_sayisi"].ToString());



            hyabtn4.Text = buttonText;

            baglanti.Close();

        }
        protected void btn_open_Click(object sender, EventArgs e)
        {
            if (div_open.Visible == true)
            {
                div_open.Visible = false;
            }
            else
            {
                div_open.Visible = true;
            }

        }
        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Session["KullaniciAdi"] = null;
            Response.Redirect("login.aspx");
        }

        protected void Unnamed13_Click(object sender, EventArgs e)
        {
            int yemekkodu = Convert.ToInt32(yemekkod.Text.ToString());
            SqlConnection baglanti22 = new SqlConnection();

            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu1 = string.Format("select * from havuzYemekKodu where ID = '{0}'", yemekkodu);
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();

            yemekkod.Text = rows[0]["yemekTarihi"].ToString();

            
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", rows[0]["yemekTarihi"].ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) > 0)
            {
                Response.Write("<script>alert('Yemeğin Var');</script>");
                return;
            }
            else
            {


                
                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", rows[0]["yemekTarihi"].ToString());
                
                komut.ExecuteNonQuery();
                baglanti.Close();




            }








        }

        protected void okod1(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();

            //if (Int32.Parse((string)Session["bakiye"]) > 10)
            //{
            //    baglanti2.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            //    string sorgu3 = string.Format("update kullanici set hesabındakiBakiye =@bakiye where eposta = @eposta");
            //    SqlCommand komut3;
            //    baglanti2.Open();
            //    komut3 = new SqlCommand(sorgu3, baglanti2);
            //    komut3.Parameters.AddWithValue("@bakiye", (Int32.Parse((string)Session["bakiye"]) - 10));
            //    komut3.Parameters.AddWithValue("@eposta", (string)Session["KullaniciAdi"]);


            //    komut3.ExecuteNonQuery();
            //    Session["bakiye"] = (Int32.Parse((string)Session["bakiye"]) - 10).ToString(;
            //}
            //else
            //{
            //    Response.Write($"<script>alert('Yeterli Bakiye Yok');</script>");
            //    return;
            //}

            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta6.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta6.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            o1.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }
        protected void okod2(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta7.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta7.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            o2.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta8.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta8.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            o3.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta9.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta9.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            o4.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta10.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta10.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            o5.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }

        protected void Unnamed7_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta0.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta0.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            a1.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta1.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta1.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            a2.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }

        protected void Unnamed9_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta2.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta2.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            a3.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";
        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta3.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta3.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            a4.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";
        }

        protected void Unnamed11_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti2 = new SqlConnection();
            SqlConnection baglanti22 = new SqlConnection();
            baglanti22.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti22.Open();

            string sorgu11 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta4.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter1 = new SqlDataAdapter(sorgu11, baglanti22);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);

            DataRow[] rows1 = tablo1.Select();

            if (Convert.ToInt32(rows1[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Kod oluşacak yemek yok');</script>");
                return;
            }
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();
            string sorgu = string.Format("INSERT INTO havuzYemekKodu (yemekTarihi) VALUES (@yemektarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@yemektarih", ta4.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            string sorgu1 = string.Format("Select * From havuzYemekKodu ORDER BY  ID DESC ");
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            DataRow[] rows = tablo.Select();
            //aaaaaa.Text = rows[0]["ID"].ToString();

            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
            komut.ExecuteNonQuery();
            //Response.Write($"<script>alert('Yemek Kodu: {rows[0]["ID"]}');</script>");
            a5.InnerHtml = $"Yemek Kodu: {rows[0]["ID"]}";

        }


        protected void isim1_Click(object sender, EventArgs e)
        {
            if (div_open.Visible == true) { div_open.Visible = false; } else { div_open.Visible = true; }
        }
    }
}