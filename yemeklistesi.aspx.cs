using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace gp
{
    public partial class yemeklistesi : System.Web.UI.Page
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


            SqlConnection baglanti = new SqlConnection(); /*veri tabanın ile bağlıyoruz using System.Data.SqlClient;*/
            baglanti.ConnectionString = ConfigurationManager.ConnectionStrings["DilaraKConnectionString"].ConnectionString; /*nereye bağlayacğımız using System.Configuration;*/
            string selectsorgusu = string.Format("select * from yemekListesi");
            SqlDataAdapter adapter = new SqlDataAdapter(selectsorgusu, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            //div3.InnerHtml = "<style type=\"text/css\">\r\n.tg  {border-collapse:collapse;border-spacing:0;}\r\n.tg td{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;\r\n  overflow:hidden;padding:10px 5px;word-break:normal;}\r\n.tg th{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;\r\n  font-weight:normal;overflow:hidden;padding:10px 5px;word-break:normal;}\r\n.tg .tg-7hap{font-size:20px;font-weight:bold;text-align:left;vertical-align:top}\r\n.tg .tg-nx8p{font-size:18px;text-align:left;vertical-align:top}\r\n</style>\r\n<table class=\"tg\">\r\n<thead>\r\n  <tr>\r\n    <th class=\"tg-7hap\"></th>\r\n  </tr>\r\n</thead>\r\n<tbody>\r\n  <tr>\r\n    <td class=\"tg-nx8p\"></td>\r\n  </tr>\r\n  <tr>\r\n    <td class=\"tg-nx8p\"></td>\r\n  </tr>\r\n  <tr>\r\n    <td class=\"tg-nx8p\"></td>\r\n  </tr>\r\n  <tr>\r\n    <td class=\"tg-nx8p\"></td>\r\n  </tr>\r\n</tbody>\r\n</table>";


            t1.Text = tablo.Rows[0].Field<string>(0);
            t2.Text = tablo.Rows[0].Field<string>(1);
            t3.Text = tablo.Rows[0].Field<string>(2);
            t4.Text = tablo.Rows[0].Field<string>(3);
            t5.Text = tablo.Rows[0].Field<string>(4);
            //buton eklenecek..

            t6.Text = tablo.Rows[1].Field<string>(0);
            t7.Text = tablo.Rows[1].Field<string>(1);
            t8.Text = tablo.Rows[1].Field<string>(2);
            t9.Text = tablo.Rows[1].Field<string>(3);
            t10.Text = tablo.Rows[1].Field<string>(4);
            //buton eklenecek..

            t11.Text = tablo.Rows[2].Field<string>(0);
            t12.Text = tablo.Rows[2].Field<string>(1);
            t13.Text = tablo.Rows[2].Field<string>(2);
            t14.Text = tablo.Rows[2].Field<string>(3);
            t15.Text = tablo.Rows[2].Field<string>(4);
            //buton eklenecek..

            t16.Text = tablo.Rows[3].Field<string>(0);
            t17.Text = tablo.Rows[3].Field<string>(1);
            t18.Text = tablo.Rows[3].Field<string>(2);
            t19.Text = tablo.Rows[3].Field<string>(3);
            t20.Text = tablo.Rows[3].Field<string>(4);
            //buton eklenecek..

            t21.Text = tablo.Rows[4].Field<string>(0);
            t22.Text = tablo.Rows[4].Field<string>(1);
            t23.Text = tablo.Rows[4].Field<string>(2);
            t24.Text = tablo.Rows[4].Field<string>(3);
            t25.Text = tablo.Rows[4].Field<string>(4);
            //buton eklenecek..

            t26.Text = tablo.Rows[5].Field<string>(0);
            t27.Text = tablo.Rows[5].Field<string>(1);
            t28.Text = tablo.Rows[5].Field<string>(2);
            t29.Text = tablo.Rows[5].Field<string>(3);
            t30.Text = tablo.Rows[5].Field<string>(4);
            //buton eklenecek..

            t31.Text = tablo.Rows[6].Field<string>(0);
            t32.Text = tablo.Rows[6].Field<string>(1);
            t33.Text = tablo.Rows[6].Field<string>(2);
            t34.Text = tablo.Rows[6].Field<string>(3);
            t35.Text = tablo.Rows[6].Field<string>(4);
            //buton eklenecek..

            t36.Text = tablo.Rows[7].Field<string>(0);
            t37.Text = tablo.Rows[7].Field<string>(1);
            t38.Text = tablo.Rows[7].Field<string>(2);
            t39.Text = tablo.Rows[7].Field<string>(3);
            t40.Text = tablo.Rows[7].Field<string>(4);
            //buton eklenecek..

            t41.Text = tablo.Rows[8].Field<string>(0);
            t42.Text = tablo.Rows[8].Field<string>(1);
            t43.Text = tablo.Rows[8].Field<string>(2);
            t44.Text = tablo.Rows[8].Field<string>(3);
            t45.Text = tablo.Rows[8].Field<string>(4);
            //buton eklenecek..

            t46.Text = tablo.Rows[9].Field<string>(0);
            t47.Text = tablo.Rows[9].Field<string>(1);
            t48.Text = tablo.Rows[9].Field<string>(2);
            t49.Text = tablo.Rows[9].Field<string>(3);
            t50.Text = tablo.Rows[9].Field<string>(4);
            //buton eklenecek..

            t51.Text = tablo.Rows[10].Field<string>(0);
            t52.Text = tablo.Rows[10].Field<string>(1);
            t53.Text = tablo.Rows[10].Field<string>(2);
            t54.Text = tablo.Rows[10].Field<string>(3);
            t55.Text = tablo.Rows[10].Field<string>(4);
            //buton eklenecek..

            t56.Text = tablo.Rows[11].Field<string>(0);
            t57.Text = tablo.Rows[11].Field<string>(1);
            t58.Text = tablo.Rows[11].Field<string>(2);
            t59.Text = tablo.Rows[11].Field<string>(3);
            t60.Text = tablo.Rows[11].Field<string>(4);
            //buton eklenecek..

            t61.Text = tablo.Rows[12].Field<string>(0);
            t62.Text = tablo.Rows[12].Field<string>(1);
            t63.Text = tablo.Rows[12].Field<string>(2);
            t64.Text = tablo.Rows[12].Field<string>(3);
            t65.Text = tablo.Rows[12].Field<string>(4);
            //buton eklenecek..

            t66.Text = tablo.Rows[13].Field<string>(0);
            t67.Text = tablo.Rows[13].Field<string>(1);
            t68.Text = tablo.Rows[13].Field<string>(2);
            t69.Text = tablo.Rows[13].Field<string>(3);
            t70.Text = tablo.Rows[13].Field<string>(4);
            //buton eklenecek..

            t71.Text = tablo.Rows[14].Field<string>(0);
            t72.Text = tablo.Rows[14].Field<string>(1);
            t73.Text = tablo.Rows[14].Field<string>(2);
            t74.Text = tablo.Rows[14].Field<string>(3);
            t75.Text = tablo.Rows[14].Field<string>(4);
            //buton eklenecek..


            t76.Text = tablo.Rows[15].Field<string>(0);
            t77.Text = tablo.Rows[15].Field<string>(1);
            t78.Text = tablo.Rows[15].Field<string>(2);
            t79.Text = tablo.Rows[15].Field<string>(3);
            t80.Text = tablo.Rows[15].Field<string>(4);
            //buton eklenecek..



            t81.Text = tablo.Rows[16].Field<string>(0);
            t82.Text = tablo.Rows[16].Field<string>(1);
            t83.Text = tablo.Rows[16].Field<string>(2);
            t84.Text = tablo.Rows[16].Field<string>(3);
            t85.Text = tablo.Rows[16].Field<string>(4);
            //buton eklenecek..



            t86.Text = tablo.Rows[17].Field<string>(0);
            t87.Text = tablo.Rows[17].Field<string>(1);
            t88.Text = tablo.Rows[17].Field<string>(2);
            t89.Text = tablo.Rows[17].Field<string>(3);
            t90.Text = tablo.Rows[17].Field<string>(4);
            //buton eklenecek..




            t91.Text = tablo.Rows[18].Field<string>(0);
            t92.Text = tablo.Rows[18].Field<string>(1);
            t93.Text = tablo.Rows[18].Field<string>(2);
            t94.Text = tablo.Rows[18].Field<string>(3);
            t95.Text = tablo.Rows[18].Field<string>(4);
            //buton eklenecek..




            t96.Text = tablo.Rows[19].Field<string>(0);
            t97.Text = tablo.Rows[19].Field<string>(1);
            t98.Text = tablo.Rows[19].Field<string>(2);
            t99.Text = tablo.Rows[19].Field<string>(3);
            t100.Text = tablo.Rows[19].Field<string>(4);
            //buton eklenecek..




            t101.Text = tablo.Rows[20].Field<string>(0);
            t102.Text = tablo.Rows[20].Field<string>(1);
            t103.Text = tablo.Rows[20].Field<string>(2);
            t104.Text = tablo.Rows[20].Field<string>(3);
            t105.Text = tablo.Rows[20].Field<string>(4);
            //buton eklenecek..





            t106.Text = tablo.Rows[21].Field<string>(0);
            t107.Text = tablo.Rows[21].Field<string>(1);
            t108.Text = tablo.Rows[21].Field<string>(2);
            t109.Text = tablo.Rows[21].Field<string>(3);
            t110.Text = tablo.Rows[21].Field<string>(4);
            //buton eklenecek..




            t111.Text = tablo.Rows[22].Field<string>(0);
            t112.Text = tablo.Rows[22].Field<string>(1);
            t113.Text = tablo.Rows[22].Field<string>(2);
            t114.Text = tablo.Rows[22].Field<string>(3);
            t115.Text = tablo.Rows[22].Field<string>(4);
            //buton eklenecek..



            t116.Text = tablo.Rows[23].Field<string>(0);
            t117.Text = tablo.Rows[23].Field<string>(1);
            t118.Text = tablo.Rows[23].Field<string>(2);
            t119.Text = tablo.Rows[23].Field<string>(3);
            t120.Text = tablo.Rows[23].Field<string>(4);
            //buton eklenecek..



            t121.Text = tablo.Rows[24].Field<string>(0);
            t122.Text = tablo.Rows[24].Field<string>(1);
            t123.Text = tablo.Rows[24].Field<string>(2);
            t124.Text = tablo.Rows[24].Field<string>(3);
            t125.Text = tablo.Rows[24].Field<string>(4);
            //buton eklenecek..



            t126.Text = tablo.Rows[25].Field<string>(0);
            t127.Text = tablo.Rows[25].Field<string>(1);
            t128.Text = tablo.Rows[25].Field<string>(2);
            t129.Text = tablo.Rows[25].Field<string>(3);
            t130.Text = tablo.Rows[25].Field<string>(4);
            //buton eklenecek..



            t131.Text = tablo.Rows[26].Field<string>(0);
            t132.Text = tablo.Rows[26].Field<string>(1);
            t133.Text = tablo.Rows[26].Field<string>(2);
            t134.Text = tablo.Rows[26].Field<string>(3);
            t135.Text = tablo.Rows[26].Field<string>(4);
            //buton eklenecek..



            t136.Text = tablo.Rows[27].Field<string>(0);
            t137.Text = tablo.Rows[27].Field<string>(1);
            t138.Text = tablo.Rows[27].Field<string>(2);
            t139.Text = tablo.Rows[27].Field<string>(3);
            t140.Text = tablo.Rows[27].Field<string>(4);
            //buton eklenecek..



            t141.Text = tablo.Rows[28].Field<string>(0);
            t142.Text = tablo.Rows[28].Field<string>(1);
            t143.Text = tablo.Rows[28].Field<string>(2);
            t144.Text = tablo.Rows[28].Field<string>(3);
            t145.Text = tablo.Rows[28].Field<string>(4);
            //buton eklenecek..



            t146.Text = tablo.Rows[29].Field<string>(0);
            t147.Text = tablo.Rows[29].Field<string>(1);
            t148.Text = tablo.Rows[29].Field<string>(2);
            t149.Text = tablo.Rows[29].Field<string>(3);
            t150.Text = tablo.Rows[29].Field<string>(4);
            //buton eklenecek..




            t151.Text = tablo.Rows[30].Field<string>(0);
            t152.Text = tablo.Rows[30].Field<string>(1);
            t153.Text = tablo.Rows[30].Field<string>(2);
            t154.Text = tablo.Rows[30].Field<string>(3);
            t155.Text = tablo.Rows[30].Field<string>(4);
            //buton eklenecek..



            t156.Text = tablo.Rows[31].Field<string>(0);
            t157.Text = tablo.Rows[31].Field<string>(1);
            t158.Text = tablo.Rows[31].Field<string>(2);
            t159.Text = tablo.Rows[31].Field<string>(3);
            t160.Text = tablo.Rows[31].Field<string>(4);
            //buton eklenecek..
        }



        protected void imagebutton1_Click(object sender, ImageClickEventArgs e)
        {
            div1.Visible = false;
            div2.Visible = false;
            geri_btn.Visible = true;
            div3.Visible = false;
            div4.Visible = true;


        }



        protected void imagebutton2_Click(object sender, ImageClickEventArgs e)
        {
            div1.Visible = false;
            div2.Visible = false;
            geri_btn.Visible = true;
            div3.Visible = true;
            div4.Visible = false;
        }



        protected void geri_btn_Click(object sender, EventArgs e)
        {
            div1.Visible = true;
            div2.Visible = true;
            geri_btn.Visible = false;
            div3.Visible = false;
            div4.Visible= false;


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
    }
}