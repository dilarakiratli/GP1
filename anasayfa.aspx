<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="gp.anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style>
* {box-sizing: border-box;}



body {
  margin: 0;
/* font-family: Arial, Helvetica, sans-serif;*/
}

.openbox {
            width: 300px;
            height: 130px;
            margin-top: 65px;
            float: right;
            background-color: #ddd5aa;
            margin-right: 5px;
            position: absolute;
            z-index: 2;
            right: 0px;
        }

.header {
  overflow: hidden;
  background-color: #ddd5aa;
  padding: 5px 0 5px 30px ;
position: fixed; 
width:100%;
z-index:2;
}



.header a {
  float: left;
  color: white;
  text-align: center;
  padding: 12px;
  text-decoration: none;
  font-size: 18px;
  line-height: 25px;
  border-radius: 4px;
}



.header a.logo {
  font-size: 25px;
  font-weight: bold;
}



.header a:hover {
  background-color: #2527AA;
  color: white;
}


.header a.active {
  background-color:  #2527AA;
  color: white;
}


.header-right {
  float: right;
}



@media screen and (max-width: 500px) {
  .header a {
    float: none;
    display: block;
    text-align: left;
  }
  
  .header-right {
    float: none;
  }
}
        
             
        
ul {
  list-style-type: none;
  margin: 0 ;
  padding:0;
  width: 230px;
  height:100%;
    position:fixed;
  background-color: #222d32;
}



li a {
  display: block;
  color: #fff; 
  padding: 20px 40px 20px 20px;
  text-decoration: none;
}
        
        li b {
  display: block;
  color: #fff; 
  padding: 25px 30px;
  font-size: 17px;
  text-decoration: none;
        }        


li a:hover {
  background-color: #192125;
  color: #fff;
}

</style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="header">
  <a href="#default" class="logo">MCBU SKS</a>
  <div style="margin-top:7px; margin-right:2px" class="header-right">
      <asp:Button  Font-Size="20px" BorderWidth="0px" Width="150px" BackColor="#ddd5aa" ForeColor="white" OnClick="btn_open_Click" ID="isim1" runat="server">
     </asp:Button>
  </div>
</div>

        <div id="div_open" style="position:fixed" visible="false" runat="server" class="openbox">
            <div><center><img src="icons/mortarboardblack.png" /></center></div>
            <div><center><font style="font-size:18px" id="isim3" runat="server"></font></center></div>
            <div><center><font style="font-size:13px">Öğrenci</font></center></div>
            <div style="margin-top:10px"><asp:Button Width="300" Font-Size="15px" BackColor="#ddd5aa" onClick="Unnamed5_Click" runat="server" Text="Bakiye İşlemleri"/></div>
           
            <div style="float:right"><asp:Button Width="70px" Height="35px" BorderWidth="0px" Font-Size="15px" BackColor="#dbca78" ID="btn_exit" runat="server" ForeColor="White" Text="Çıkış" OnClick="btn_exit_Click"/></div>
        </div>

   <div  style="width:230px; height:auto; float:left; margin-top:59px"><ul>
  <li><b> <center><img style="align-content: center" src="icons/user.png"></center>
      <br><center><font id="isim2" runat="server"></font></center><br>  </b></li>
  <li><a href="anasayfa.aspx"><img src="icons/house-black-silhouette-without-door.png"> Ana Sayfa</a></li>
  <li><a href="rezervasyon.aspx"><img src="icons/check.png"> Rezervasyon İşlemleri</a></li>
  <li><a href="havuz.aspx"><img src="icons/cutlery.png"> Yemek Havuzu</a></li>
  <li><a href="yemeklistesi.aspx"><img src="icons/to-do-list.png"> Yemek Listesi</a></li>
</ul></div>   
        

<div id="div1" visible="true" runat="server" style="margin-left:270px;margin-top:70px; z-index:1; position:absolute">
        <font style="color:red; font-size:30px; font-weight: 700">YEMEK SAATLERİMİZ</font>
            <br/>
            <font style="color:black; font-size:25px; font-weight: 600">Öğle yemeği saat aralığı:</font>
            <font style="color:black; font-size:25px; font-weight: 400"> 11:30-13:30</font>
            <br/>
            <font style="color:black; font-size:25px; font-weight: 600">Akşam yemeği saat aralığı:</font>
                <font style="color:black; font-size:25px; font-weight: 400"> 16:00-18:00</font>
            <br /><br />
            <font style="color:red;font-size:28px; font-weight: 500"">Önemli Uyarı!</font>
            <br/>
            <font style="color:black; font-size:15px; font-weight:400;">Sistem üzerinden rezervasyon yapabilmek için telefon bilgilerinin güncel ve kartların internet alışverişine açık olması gerekmektedir. (Telefon Numarası = 0850 220 00 00 ) (Rezervasyon yapılmak istendiğinde şifre gelmiyorsa banka ile iletişime geçilip telefon bilgilerinin güncellenmesi gerekir.)<br /> 31.01.2018 tarihi itibariyle tüm Ziraat bankası kartları internet kullanımına kapatıldığından dolayı tekrar açılması gerekmektedir.</font>
            <br /> <br />
            <font style="color:red; font-size:20px">Önemli Uyarı!</font>
            <br />
            <font style="color:black; font-size:15px">Rezervasyonlarınızı, sistemdeki hesap bakiyenize önceden para yükleyerek (ziraat bankası hesaplarınızı kullanarak) oluşturduğunuz sanal paranızdan yada ziraat bankası hesaplarınızdan direk ödeme yaparak tamamlayabilirsiniz.</font>
            <br /><br />
            <font style="font-weight:400">Rezervasyon aktarma nedir?</font>
            <br />
            <font>Herhangi bir güne yapılan rezervasyonun günü ve öğünü değişmeksizin başka birisine aktarılmasıdır. Rezervasyonun başka bir güne ya da öğüne aktarılması değildir.</font>
            
        </div>
        <div id="div2" runat="server" visible="false" style="margin-left:300px;margin-top:130px; z-index:2; position:absolute"> <div >
            <div>
                <asp:Button  runat="server" Text="Geri" Font-Size="17px" ForeColor="White" BackColor="#6f92dc"
                Height="50px" Width="100px" OnClick="geri_btn_Click" ID="geri_btn" BorderWidth="0px" />
            </div> <br /><br />
            
            <font style="color:red; font-size:30px; font-weight: 700">Bakiye İşlemleri</font>
            <br />
            <br />
            <div><font Style="font-size:20px; float:left">Güncel Bakiyeniz: </font>
                            <div><center><font style="font-size:18px" id="güncelf" runat="server"></font></center></div>
</div>
            <br /> <br />
            
                <div> <asp:TextBox class="form-control" placeholder="Yüklemek İstediğiniz Miktar" runat="server" ID="para" OnTextChanged="Unnamed4_TextChanged">0</asp:TextBox></div> <br />
                <asp:Button BackColor="#6f92dc" BorderStyle="Ridge" Text="Yükle" runat="server" OnClick="Unnamed5_Click"/>
        
        </div> </div>

   </form>
</body>
</html>
