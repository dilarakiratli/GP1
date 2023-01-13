<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yemeklistesi.aspx.cs" Inherits="gp.yemeklistesi" %>

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
    width:300px;
    height:130px;
    margin-top:65px;
    float:right;
    background-color: #ddd5aa;
    margin-right:5px;
    position:absolute;
    z-index:2;
    right: 0px;

}

.buttonbox{
	background-color:#CFCFCF;
        display: block;
    margin: auto;
	 border-radius: 3px;
    width: 400px;
    height: 65px;
	
	
	
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
            <div style="margin-top:10px"><asp:Button Width="300" Font-Size="15px" BackColor="#ddd5aa" runat="server" Text="Bakiye İşlemleri"/></div>
           
            <div style="float:right"><asp:Button Width="70px" Height="35px" BorderWidth="0px" Font-Size="15px" BackColor="#dbca78" ID="btn_exit" runat="server" ForeColor="White" Text="Çıkış" OnClick="btn_exit_Click"/></div> 




        </div>
	<div  style="width:230px; height:auto; float:left; margin-top:59px "><ul>
  <li><b> <center><img style="align-content: center" src="icons/user.png"></center> 
	  <br/><center><font id="isim2" runat="server"></font></center><br>  </b></li>
  <li><a href="anasayfa.aspx"><img src="icons/house-black-silhouette-without-door.png"> Ana Sayfa</a></li>
  <li><a href="rezervasyon.aspx"><img src="icons/check.png"> Rezervasyon İşlemleri</a></li>
  <li><a href="havuz.aspx"><img src="icons/cutlery.png"> Yemek Havuzu</a></li>
  <li><a href="yemeklistesi.aspx"><img src="icons/to-do-list.png"/> Yemek Listesi</a></li>
</ul></div>	
	<div>
	</div>

        <div style="margin-left:270px; margin-top:70px; float:left; position:absolute; z-index:1">
	<font style="font-size:40px; font-weight: 500">Yemek Listesi</font>
	<br/><br/>	
			<div id="div1" runat="server" class="buttonbox"  style="float:left">
				<div ><asp:ImageButton OnClick="imagebutton1_Click" id="imagebutton1" runat="server"
           AlternateText="ImageButton1"
           ImageAlign="left"
           ImageUrl="~/icons/restaurant-cutlery (5).png"/></div>
				<div style="margin-top:10px; float:left"><font style="font-size:40px;">Öğle Yemeği</font></div>
			</div>
            
				<div id="div2" runat="server" class="buttonbox"   style="float:left;margin-left:50px">
				
			<div></div><asp:ImageButton OnClick="imagebutton2_Click"  id="imagebutton2" runat="server"
           AlternateText="ImageButton2"
           ImageAlign="left"
           ImageUrl="~/icons/restaurant-cutlery (6).png"/>	<div>
				<div  style="margin-top:10px; float:left"><font style="font-size:40px;">Akşam Yemeği</font></div>
			</div>

			</div>
			<div><asp:Button Visible="false" runat="server" Text="Geri" Font-Size="17px" ForeColor="White" BackColor="#6f92dc" 
				Height="50px" Width="100px" OnClick="geri_btn_Click" ID="geri_btn" BorderWidth="0px" /></div>
			<br/>
			<div id="div3" visible="false" runat="server">



				<div style="float:left"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table1" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000">
       <asp:TableCell ID="t1">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t2">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t3">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t4"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t5"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>
				
				<div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table2" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t6">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t7">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t8">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t9"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t10"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

				<div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table3" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t11">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t12">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t13">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t14"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t15"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

				<div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table4" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t16">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t17">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t18">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t19"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t20"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>
                <br />

				<div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table5" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t21">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t22">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t23">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t24"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t25"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table6" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t26">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t27">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t28">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t29"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t30"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table7" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t31">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t32">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t33">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t34"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t35"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

				
				<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table8" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t36">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t37">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t38">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t39"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t40"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                <br />

                
				<div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table9" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t41">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t42">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t43">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t44"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t45"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table10" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t46">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t47">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t48">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t49"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t50"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table11" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t51">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t52">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t53">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t54"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t55"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

				
				<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table12" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t56">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t57">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t58">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t59"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t60"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                <br />

                
				<div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table13" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t61">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t62">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t63">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t64"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t65"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table14" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t66">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t67">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t68">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t69"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t70"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

                
				<div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table15" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t71">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t72">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t73">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t74"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t75"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

				
				<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table16" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
 <asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#b50000"><asp:TableCell ID="t76">Row 0, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t77">Row 1, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t78">Row 2, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t79"> Row 3, Col 0</asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell ID="t80"> Row 4, Col 0</asp:TableCell></asp:TableRow>
    </asp:Table></div>

			</div>

<div id="div4"  visible="false" runat="server">

<div style="float:left"><asp:Table Font-Size="15px"  ForeColor="#808080" Width="250px"  id="Table17" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White"  HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t81"> Row 0,Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t82">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t83">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t84" > Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t85"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

<div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table18" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t86">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t87">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t88">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t89"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t90"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                <div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table19" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t91">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t92">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t93">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t94"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t95"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                <div style="float:left; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table20" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t96">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t97">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t98">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t99"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t100"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>
<br />

 

 

                <div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table21" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t101">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t102">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t103">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t104"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t105"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table22" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t106">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t107">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t108">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t109"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t110"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>
 

            <div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table23" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t111">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t112">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t113">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t114"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t115"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table24" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t116">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t117">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t118">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t119"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t120"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                <br />

 

     <div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table25" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t121">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t122">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t123">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t124"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t125"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table26" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t126">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t127">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t128">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t129"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t130"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table27" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t131">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t132">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t133">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t134"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t135"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table28" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t136">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t137">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t138">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t139"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t140"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 


<br />

 

                
<div style="float:left; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table29" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t141">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t142">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t143">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t144"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t145"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-left:60px; margin-top:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table30" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t146">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t147">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t148">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t149"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t150"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>


            <div style="float:left;margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table31" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t151">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t152">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t153">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t154"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t155"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

 

 

                
<div style="float:left; margin-top:60px; margin-left:60px"><asp:Table Font-Size="15px" ForeColor="#808080" Width="250px"  id="Table32" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
<asp:TableRow ForeColor="White" HorizontalAlign="Center" BackColor="#8A51D0"><asp:TableCell ID="t156">Row 0, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t157">Row 1, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t158">Row 2, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t159"> Row 3, Col 0</asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell ID="t160"> Row 4, Col 0</asp:TableCell></asp:TableRow>
</asp:Table></div>

            </div>
    </form>
</body>
</html>