using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gp
{
    public partial class havuz : System.Web.UI.Page
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

            List<int> yemeksayisi = new List<int>();
            for(var i=0; i<5; i++)
            {
                string selectsorgusu1 = string.Format("select count(*) as yemeksayisi from askiYemek where yemekTarih = '{0}' ", rows[i]["tarih"].ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                yemeksayisi.Add(Convert.ToInt32(rows2[0]["yemeksayisi"]));
            }

            Button1.Text = "Kalan Yemek Sayısı : " + yemeksayisi[0].ToString();
            Button3.Text = "Kalan Yemek Sayısı : " + yemeksayisi[1].ToString();
            Button5.Text = "Kalan Yemek Sayısı : " + yemeksayisi[2].ToString();
            Button7.Text = "Kalan Yemek Sayısı : " + yemeksayisi[3].ToString();
            Button9.Text = "Kalan Yemek Sayısı : " + yemeksayisi[4].ToString();

            List<int> yemeksayisii = new List<int>();
            for (var i = 16; i < 21; i++)
            {
                string selectsorgusu1 = string.Format("select count(*) as yemeksayisii from askiYemek where yemekTarih = '{0}' ", rows[i]["tarih"].ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                yemeksayisii.Add(Convert.ToInt32(rows2[0]["yemeksayisii"]));
            }

            Button11.Text = "Kalan Yemek Sayısı : " + yemeksayisii[0].ToString();
            Button12.Text = "Kalan Yemek Sayısı : " + yemeksayisii[1].ToString();
            Button13.Text = "Kalan Yemek Sayısı : " + yemeksayisii[2].ToString();
            Button14.Text = "Kalan Yemek Sayısı : " + yemeksayisii[3].ToString();
            Button15.Text = "Kalan Yemek Sayısı : " + yemeksayisii[4].ToString();

            //kalan bakiye kısmı için
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
        protected void OAl1(object sender, EventArgs e) //öğlen yemek alma
        {
           
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta6.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();

                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();

                //yemek alma butonu yap

                baglanti.Close();
                havuzyemekgüncelle1();

                Obtn1.Visible = false;
                Obtn2.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");

            }
        }
        protected void OAl3(object sender, EventArgs e)
        {
           
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta7.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();

                //yemek alma butonu yap

                baglanti.Close();
                havuzyemekgüncelle1();

                Obtn3.Visible = false;
                Obtn4.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }
        protected void OAl5(object sender, EventArgs e)
        {
            
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta8.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();





                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle1();

                Obtn5.Visible = false;
                Obtn6.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }



        protected void OAl7(object sender, EventArgs e)
        {
           
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta9.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();



                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle1();

                Obtn7.Visible = false;
                Obtn8.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }




        protected void OAl9(object sender, EventArgs e)
        {
            

            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta10.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();





                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle1();
                Obtn9.Visible = false;
                Obtn10.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e) //akşamın yemek bırakması
        {
            Abtn1.Visible = true;
            Abtn2.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta0.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle();

        }
        protected void Button4_Click(object sender, EventArgs e)
        {


            Abtn3.Visible = true;
            Abtn4.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta1.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle();


        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Abtn5.Visible = true;
            Abtn6.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta2.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle();
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            Abtn7.Visible = true;
            Abtn8.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta3.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle();
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            Abtn9.Visible = true;
            Abtn10.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta4.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle();
        }
        public void havuzyemekgüncelle1()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString; /*nereye bağlayacğımız using System.Configuration;*/
            string selectsorgusu = string.Format("select * from yemekListesi");
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();
            ta6.InnerHtml = rows[16]["tarih"].ToString();
            ta7.InnerHtml = rows[17]["tarih"].ToString();
            ta8.InnerHtml = rows[18]["tarih"].ToString();
            ta9.InnerHtml = rows[19]["tarih"].ToString();
            ta10.InnerHtml = rows[20]["tarih"].ToString();

            List<int> yemeksayisii = new List<int>();
            for (var i = 16; i < 21; i++)
            {
                string selectsorgusu1 = string.Format("select count(*) as yemeksayisii from askiYemek where yemekTarih = '{0}' ", rows[i]["tarih"].ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                yemeksayisii.Add(Convert.ToInt32(rows2[0]["yemeksayisii"]));



            }

            Button11.Text = "Kalan Yemek Sayısı : " + yemeksayisii[0].ToString();
            Button12.Text = "Kalan Yemek Sayısı : " + yemeksayisii[1].ToString();
            Button13.Text = "Kalan Yemek Sayısı : " + yemeksayisii[2].ToString();
            Button14.Text = "Kalan Yemek Sayısı : " + yemeksayisii[3].ToString();
            Button15.Text = "Kalan Yemek Sayısı : " + yemeksayisii[4].ToString();
        }
        public void havuzyemekgüncelle()
        {
            SqlConnection baglanti = new SqlConnection();
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


            List<int> yemeksayisi = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                string selectsorgusu1 = string.Format("select count(*) as yemeksayisi from askiYemek where yemekTarih = '{0}' ", rows[i]["tarih"].ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                yemeksayisi.Add(Convert.ToInt32(rows2[0]["yemeksayisi"]));



            }

            Button1.Text = "Kalan Yemek Sayısı : " + yemeksayisi[0].ToString();
            Button3.Text = "Kalan Yemek Sayısı : " + yemeksayisi[1].ToString();
            Button5.Text = "Kalan Yemek Sayısı : " + yemeksayisi[2].ToString();
            Button7.Text = "Kalan Yemek Sayısı : " + yemeksayisi[3].ToString();
            Button9.Text = "Kalan Yemek Sayısı : " + yemeksayisi[4].ToString();

            List<int> yemeksayisii = new List<int>();
            for (var i = 18; i < 23; i++)
            {
                string selectsorgusu1 = string.Format("select count(*) as yemeksayisii from askiYemek where yemekTarih = '{0}' ", rows[i]["tarih"].ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                yemeksayisii.Add(Convert.ToInt32(rows2[0]["yemeksayisii"]));



            }

            Button11.Text = "Kalan Yemek Sayısı : " + yemeksayisii[0].ToString();
            Button12.Text = "Kalan Yemek Sayısı : " + yemeksayisii[1].ToString();
            Button13.Text = "Kalan Yemek Sayısı : " + yemeksayisii[2].ToString();
            Button14.Text = "Kalan Yemek Sayısı : " + yemeksayisii[3].ToString();
            Button15.Text = "Kalan Yemek Sayısı : " + yemeksayisii[4].ToString();



        }





        protected void AAl1(object sender, EventArgs e) //akşam yemek alma
        {
            
            try { 
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
            baglanti.Open();

            string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta0.InnerHtml.ToString());
            SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
            DataTable tablo1 = new DataTable();
            adapter1.Fill(tablo1);
            DataRow[] rows2 = tablo1.Select();
            string id = rows2[0]["ID"].ToString();


            string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta0.InnerHtml.ToString());
            // baglanti.Open();
            komut.ExecuteNonQuery();

             sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglanti.Close();

            havuzyemekgüncelle();
                Abtn1.Visible = false;
                Abtn2.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }
        protected void AAl3(object sender, EventArgs e)
        {
            
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta1.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta1.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();





                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle();

                Abtn3.Visible = false;
                Abtn4.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }



        protected void AAl5(object sender, EventArgs e)
        {
           
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta2.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta2.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();



                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle();

                Abtn5.Visible = false;
                Abtn6.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }



        protected void AAl7(object sender, EventArgs e)
        {
           

            try
            {
               
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta3.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta3.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();





                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle();

                Abtn7.Visible = false;
                Abtn8.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }




        protected void AAl9(object sender, EventArgs e)
        {
            
            try
            {
                baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;
                baglanti.Open();

                string selectsorgusu1 = string.Format("select *  from askiYemek where yemekTarih = '{0}' ", ta4.InnerHtml.ToString());
                SqlDataAdapter adapter1 = new SqlDataAdapter(selectsorgusu1, baglanti);
                DataTable tablo1 = new DataTable();
                adapter1.Fill(tablo1);
                DataRow[] rows2 = tablo1.Select();
                string id = rows2[0]["ID"].ToString();


                string sorgu2 = string.Format("INSERT INTO rezervasyonlar (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
                SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
                komut.Parameters.AddWithValue("@yemekTarih", ta4.InnerHtml.ToString());
                // baglanti.Open();
                komut.ExecuteNonQuery();

                sorgu2 = string.Format("DELETE FROM askiYemek WHERE (ID=@id)");
                //SqlCommand komut;
                komut = new SqlCommand(sorgu2, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();





                //yemek alma butonu yap


                baglanti.Close();

                havuzyemekgüncelle();

                Abtn9.Visible = false;
                Abtn10.Visible = true;
            }
            catch
            {
                Response.Write("<script>alert('yemek yok');</script>");
            }
        }



        protected void Button26_Click(object sender, EventArgs e)
        {
            Obtn1.Visible = true;
            Obtn2.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta6.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta6.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle1();

        }
        protected void Button27_Click(object sender, EventArgs e)
        {
            Obtn3.Visible = true;
            Obtn4.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta7.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta7.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle1();

        }
        protected void Button28_Click(object sender, EventArgs e)
        {
            Obtn5.Visible = true;
            Obtn6.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta8.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta8.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle1();


        }
        protected void Button29_Click(object sender, EventArgs e)
        {
            Obtn7.Visible = true;
            Obtn8.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta9.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta9.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle1();


        }
        protected void Button30_Click(object sender, EventArgs e)
        {
            Obtn9.Visible = true;
            Obtn10.Visible = false;
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString;

            baglanti.Open();

            string sorgu1 = string.Format("select count(*) as yemek_sayisi from rezervasyonlar where (yemekTarih = '{0}' and kullaniciID = '{1}') ", ta10.InnerHtml.ToString(), Convert.ToInt64(Session["ogrnum"]));
            SqlDataAdapter adapter = new SqlDataAdapter(sorgu1, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            DataRow[] rows = tablo.Select();

            if (Convert.ToInt32(rows[0]["yemek_sayisi"]) == 0)
            {
                Response.Write("<script>alert('Bırakılacak yemek yok');</script>");
                return;
            }




            string sorgu = string.Format("INSERT INTO askiYemek (kullaniciID,yemekTarih) VALUES (@kullaniciID , @yemekTarih)");
            SqlCommand komut;
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());

            komut.ExecuteNonQuery();





            string sorgu2 = string.Format("DELETE FROM rezervasyonlar WHERE (kullaniciID=@kullaniciID and yemekTarih=@yemekTarih)");
            //SqlCommand komut;
            komut = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", Session["ogrnum"]);
            komut.Parameters.AddWithValue("@yemekTarih", ta10.InnerHtml.ToString());
            komut.ExecuteNonQuery();

            havuzyemekgüncelle1();


        }





        protected void Abtn2_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("anasayfa.aspx");

        }
    }
}