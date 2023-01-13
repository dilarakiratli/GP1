<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="gp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>

                body {
            background-image:url(icons/back.png);
            
        }

    /*butonun genel özellikleri için*/
        button {
  display: inline;
  background: #262626;
  color: #FFFFFF;
  border: 0;
  border-radius: 5px;
  padding: 4px;
  width: 90px;
}
        /*giriş kısımları için*/
        input {
    display: block;
    width: 250px;
    height: 30px;
    margin-top: 1.0em;
   padding: 4px;
}
        
        
        
        /*en dıştaki kutu*/
        .outer-box {
    display: block;
    margin: auto;
    background: #ddd5aa;
    border-radius: 5px;
    width: 450px;
    height: 600px;



}
        
        
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div>
            <center><font style="font-size: 50px">Manisa Celal Bayar<br/> Üniversitesi</font></center></div>
    
    <br/>
    <div  class="outer-box">
        <br/>
        <center><asp:TextBox ID="kullaniciAdi" runat="server" class="form-control" placeholder="Kullanıcı Adı"></asp:TextBox></center>
    <br/>
        <center><asp:TextBox ID="sifre" runat="server" class="form-control" placeholder="Sifre" TextMode="Password" OnTextChanged="sifre_TextChanged"></asp:TextBox></center>
    <br/>
       <center><asp:Button ID="BtnGiris" runat="server" class="btn btn-primary" Text="Giriş" OnClick="BtnGiris_Click"/></center>
<!--sadece verileri okuyo update yapmıyo-->
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:DilaraKConnectionString %>' SelectCommand="SELECT * FROM [kullanici]"></asp:SqlDataSource>

        <br/> <br/>
        <div style="margin:0 30px 0 30px"><center>  <font style="color:red;font-weight:700">DİKKAT</font> </center> <br />
            <center ><font style="color:red;font-weight:600">1-) REZERVASYON SİSTEMİNE GİRİŞ YAPARKEN ÖĞRENCİ İSENİZ KULLANICI ADINIZ ÖĞRENCİ NUMARANIZ, ŞİFRENİZ İSE T.C KİMLİK NUMARANIZDIR.</font></center>
           <br />
            <center><font style="color:red;font-weight:600">2-) Sisteme girişte TC Kimlik numaraları uyumsuz hatası ile karşılaşılması durumunda MCBÜ - Bilgi İşlem Daire Başkanlığı'ndan destek alınabilir.İletişim : </font> <font style="font-weight:600"> 0 236 201 11 81</font></center>
            <br />
            <center><font style="color:red;font-weight:600">3-) Yemeklerle ilgili şikayet ve önerileriniz için :</font></center>
            <center><font style="font-weight:600">201 14 10 , 201 14 12 , 201 14 13 , 201 14 14 Arayınız .</font></center>
    
        </div>
        </div>    </form>
</body>
</html>
