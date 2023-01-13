<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rezervasyon.aspx.cs" Inherits="gp1._1.rezervasyon" %>

 

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
      <asp:Button  Font-Size="20px" BorderWidth="0px" Width="150px" BackColor="#ddd5aa" ForeColor="white" OnClick="isim1_Click"  ID="isim1" runat="server">
     </asp:Button>
  </div>
</div>
        <div id="div_open" runat="server" class="openbox" visible="false" style="position:fixed">
            <div><center><img src="icons/mortarboardblack.png" /></center></div>
            <div><center><font style="font-size:18px" id="isim3" runat="server"></font></center></div>
            <div><center><font style="font-size:13px">Öğrenci</font></center></div>
            <div style="margin-top:10px"><asp:Button Width="300" Font-Size="15px" BackColor="#ddd5aa" runat="server" Text="Bakiye İşlemleri"/></div>
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

<div style="margin-left: 270px; margin-top:75px; float:left; position:absolute; z-index:1">
<div style="margin-bottom:100px; "><div><font style="font-size:40px; font-weight: 500; float:left">Rezervasyon</font></div>
</div>



  <div style="float:left"">
      <font  style="font-size:30px" id="ta6" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta7" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta8" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta9" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta10" runat="server"></font>

</div>
    			
    


<div style="margin-left:100px;float:left">
<asp:Button ID="Obtn1" OnClick="Obtn1_Click"  Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Öğle Yemeği Al" /> 
<asp:Button ID="Obtn2" OnClick="Obtn2_Click" Visible="false" runat="server" BackColor="Purple" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyobtn0" OnClick="hyobtn0_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button ID="aaaaaa" runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="okod1"/>
     <font ID="o1" runat="server" ></font>

<br /><br /> <asp:Button ID="Obtn3" OnClick="Obtn3_Click" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Öğle Yemeği Al" /> 
<asp:Button ID="Obtn4" Visible="false" OnClick="Obtn4_Click" runat="server"  BackColor="Purple" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyobtn1" OnClick="hyobtn1_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="okod2"/>
    <font ID="o2" runat="server" ></font>

<br /><br /> <asp:Button ID="Obtn5" OnClick="Obtn5_Click" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Öğle Yemeği Al" /> 
<asp:Button ID="Obtn6" Visible="false" OnClick="Obtn6_Click" runat="server"  BackColor="Purple" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyobtn2" OnClick="hyobtn2_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed4_Click"/>
    <font runat="server" ID="o3"></font>
     

<br /><br /> <asp:Button ID="Obtn7" OnClick="Otbn7_Click" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Öğle Yemeği Al" /> 
<asp:Button ID="Obtn8" Visible="false" OnClick="Obtn8_Click" runat="server"  BackColor="Purple" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyobtn3" OnClick="hyobtn3_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed5_Click"/>
     <font ID="o4" runat="server" ></font>

<br /><br /> <asp:Button ID="Obtn9" OnClick="Obtn9_Click" Visible="true" runat="server" Width="150px" BackColor="Purple" Height="36px" ForeColor="White" BorderWidth="0" Text="Öğle Yemeği Al" /> 
<asp:Button ID="Obtn10" Visible="false" OnClick="Obtn10_Click" runat="server"  BackColor="Purple" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyobtn4" OnClick="hyobtn4_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" />
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed6_Click"/>
     <font ID="o5" runat="server" ></font>

 
</div>
    <br />

    <br />
   <br />

    <div style="float:left;margin-top:50px">
        <font  style="font-size:30px" id="ta0" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta1" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta2" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta3" runat="server"></font>
<br /><br /> <font style="font-size:30px" id="ta4" runat="server"></font>
        
        
        
</div>

      
    
<div style="float:left; margin-top:50px; margin-left:100px">
<asp:Button ID="Abtn1" Visible="true" runat="server" OnClick="Abtn1_Click" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Akşam Yemeği Al" /> 
<asp:Button ID="Abtn2" Visible="false" runat="server" OnClick="Abtn2_Click" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyabtn0" OnClick="hyabtn0_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed7_Click"/>
    <font ID="a1" runat="server"></font>
   
<br /> <br /><asp:Button ID="Abtn3" Visible="true" OnClick="Abtn3_Click" runat="server" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Akşam Yemeği Al" />
<asp:Button ID="Abtn4" Visible="false" runat="server" OnClick="Abtn4_Click"  BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyabtn1" OnClick="hyabtn1_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White"  BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed8_Click"/>
    <font ID="a2" runat="server"></font>
    
<br /> <br /><asp:Button ID="Abtn5" Visible="true" OnClick="Abtn5_Click" runat="server" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Akşam Yemeği Al" /> 
<asp:Button ID="Abtn6" Visible="false" runat="server" OnClick="Abtn6_Click"  BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyabtn2" OnClick="hyabtn2_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed9_Click"/>
  <font ID="a3" runat="server"></font>

<br /> <br /><asp:Button ID="Abtn7" Visible="true" OnClick="Abtn7_Click" runat="server" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Akşam Yemeği Al" /> 
<asp:Button ID="Abtn8" Visible="false" runat="server" OnClick="Abtn8_Click"  BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyabtn3" OnClick="hyabtn3_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed10_Click"/>
     <font ID="a4" runat="server"></font>

<br /> <br /><asp:Button ID="Abtn9" Visible="true" OnClick="Abtn9_Click" runat="server" BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="Akşam Yemeği Al" /> 
<asp:Button ID="Abtn10" Visible="false" runat="server" OnClick="Abtn10_Click"   BackColor="Red" Height="36px" Width="150px" ForeColor="White" BorderWidth="0" Text="İPTAL ET" /> 
<asp:Button ID="hyabtn4" OnClick="hyabtn4_Click" Visible="true" runat="server" Width="150px" BackColor="Black" Height="36px" ForeColor="White" BorderWidth="0" Text="Havuza Al" /> 
    <asp:Button runat="server" Height="36px" Width="150px" BackColor="Gray" ForeColor="White" BorderWidth="0" Text="Kod Oluştur" OnClick="Unnamed11_Click"/>
     <font ID="a5" runat="server"></font>
</div>
        
     <div style="position:absolute; margin-top:530px"><font style="font-size:25px">Yemek Aktarım</font><br /><br />
<asp:TextBox ID="yemekkod" runat="server" Text="Kod giriniz"></asp:TextBox>
<asp:Button runat="server" Text="Aktar" OnClick="Unnamed13_Click" />
        <br /><br /><br />

    </div>

</div>
           
</form>
</body>
</html>