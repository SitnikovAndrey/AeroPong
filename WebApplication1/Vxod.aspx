<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vxod.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aero-Pong</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body style="height: 14px">
		<form id="form1" runat="server">
		<center>
			<div class="popup--centered_overlay">
				<div class="glav">
				<h2>Добро пожаловать в Aero-Pong!</h2>                     
                    <div style="height: 145px">
                        <h2>Ник</h2>
                        <center><input type="text" size="30" id="tb_nik"></center>
                        <h2>Пароль</h2>
                        <center><input type="text" size="30" id="tb_password"> </center>                   
				    </div>
                    <a href="UserMenu.aspx" class="vhod" id="bt_vhod">Вход</a>  
                    <a href="registration.aspx" class="reg" id="bt_reg">Регистрация</a>            
			</div>
          </div>
		</center>
        </form>
</body>
</html>
