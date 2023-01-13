<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="havuz.aspx.cs" Inherits="gp.havuz" %>



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
  overflow: hidden; /*bu yorum satırı aleyde*/
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
  background-color:  #2527AA;;
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
  color: #fff; /* yazının normaldeki rengi */
  padding: 20px 40px 20px 20px;
  text-decoration: none;
}
        
        li b {
  display: block;
  color: #fff; /* yazının normaldeki rengi */
  padding: 25px 30px;
  font-size: 17px;
  text-decoration: none;
  
    
        }        



/* üzerine gelince yazının ve arka planın ne renk olduğu*/
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

<div id="div_open" runat="server" class="openbox" visible="false" style="position:fixed">
            <div><center><img src="icons/mortarboardblack.png" /></center></div>
            <div><center><font style="font-size:18px" id="isim3" runat="server"></font></center></div>
            <div><center><font style="font-size:13px">Öğrenci</font></center></div>
            <div style="margin-top:10px"><asp:Button Width="300" Font-Size="15px" BackColor="#ddd5aa" runat="server" Text="Bakiye İşlemleri" OnClick="Unnamed_Click"/></div>

            <div style="float:right"><asp:Button Width="70px" Height="35px" BorderWidth="0px" Font-Size="15px" BackColor="#dbca78" ID="btn_exit" runat="server" ForeColor="White" Text="Çıkış" OnClick="btn_exit_Click"/></div> 
        </div>

   <div  style="width:230px; height:700px; float:left; margin-top:59px"><ul>
  <li><b> <center><img style="align-content: center" src="icons/user.png"></center>
      <br><center><font id="isim2" runat="server"></font></center><br>  </b></li>
  <li><a href="anasayfa.aspx"><img src="icons/house-black-silhouette-without-door.png"> Ana Sayfa</a></li>
  <li><a href="rezervasyon.aspx"><img src="icons/check.png"> Rezervasyon İşlemleri</a></li>
  <li><a href="havuz.aspx"><img src="icons/cutlery.png"> Yemek Havuzu</a></li>
  <li><a href="yemeklistesi.aspx"><img src="icons/to-do-list.png"/> Yemek Listesi</a></li>
</ul></div>
        <div style="margin-left: 270px; margin-top:80px; float:left; position:absolute; z-index:1">

 

<div style="margin-bottom:100px"><div><font style="font-size:40px; font-weight: 500;">Yemek Havuzu</font><br /><br /></div>

 


<div> <font style="font-size:35px;">Öğle Yemeği</font> </div>
<div style="float:left; margin-top:40px"> 
<font style="font-size:30px" id="ta6" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta7" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta8" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta9" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta10" runat="server"></font>
<br /><br />

 

</div>    

 

 

<div   style="float:left; margin-left:100px;margin-top:40px">

 

 

                <asp:Button ID="Button11"  Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br />  <asp:Button ID="Button12" Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button13"   Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button14"  Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button15"   Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br />
</div>

 



 

                <div   style="float:left; margin-left:30px; margin-top:40px">

 

 

                <asp:Button ID="Obtn1" OnClick="OAl1"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Obtn2"  Visible="false" runat="server" BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br />  <asp:Button ID="Obtn3" OnClick="OAl3" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Obtn4" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Obtn5" OnClick="OAl5"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Obtn6" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Obtn7" OnClick="OAl7" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Obtn8" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Obtn9" OnClick="OAl9"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Obtn10" Visible="false"   runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" />
<br /><br />

 

                </div>

 

 


<div   style="float:left; margin-left:30px; margin-top:40px">

 

 

                <asp:Button ID="Button26" OnClick="Button26_Click"  Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br />  <asp:Button ID="Button27" OnClick="Button27_Click" Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button28" OnClick="Button28_Click"   Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button29" OnClick="Button29_Click"  Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button30" OnClick="Button30_Click"   Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br />
</div>

 

 


<div> <font style="font-size:35px;">Akşam Yemeği</font> </div>
<div style="float:left; margin-top:40px"> 
<font style="font-size:30px" id="ta0" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta1" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta2" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta3" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta4" runat="server"></font>

 

</div>    

 

 

<div   style="float:left; margin-left:100px;margin-top:40px">

 

 

                <asp:Button ID="Button1"  Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br />  <asp:Button ID="Button3" Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button5"   Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button7"  Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" /> 
<br /><br /> <asp:Button ID="Button9"   Visible="true" runat="server" Width="150px" BackColor="White" Height="36px" ForeColor="Black" BorderWidth="0" Text="Kalan Yemek:" />

 

</div>

 

 

                

 

 

                <div   style="float:left; margin-left:30px; margin-top:40px">

 

 

                <asp:Button ID="Abtn1" OnClick="AAl1"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Abtn2"  Visible="false" runat="server" BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" OnClick="Button2_Click" /> 
<br /><br />  <asp:Button ID="Abtn3" OnClick="AAl3" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Abtn4" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Abtn5" OnClick="AAl5"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Abtn6" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Abtn7" OnClick="AAl7" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Abtn8" Visible="false"  runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" /> 
<br /><br /> <asp:Button ID="Abtn9" OnClick="AAl9"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Al" /> 
<asp:Button ID="Abtn10" Visible="false"   runat="server"  BackColor="Green" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Yemek Alındı" />

 

 

                </div>

 

 


<div   style="float:left; margin-left:30px; margin-top:40px">

 

 

                <asp:Button ID="Button2" OnClick="Button2_Click"  Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br />  <asp:Button ID="Button4" OnClick="Button4_Click" Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button6" OnClick="Button6_Click" Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button8" OnClick="Button8_Click" Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" /> 
<br /><br /> <asp:Button ID="Button10" OnClick="Button10_Click" Visible="true" runat="server" Width="150px" BackColor="Gray" Height="36px" ForeColor="White" BorderWidth="0" Text="Yemek Bırak" />

 

</div>



 

        </div> </div>

    </form>
</body>
</html>