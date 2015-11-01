<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="WebApplication1.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aero-Pong</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body style="height: 14px">
		<form id="form1" runat="server">
            <div class="popup--centered_overlay">
				<div class="registration">
				<h2>Регистрация в Aero-Pong!</h2>                     
                    <div style="height: 145px">
                        <h2>Введите Ник</h2>
                        <center><input type="text" size="30" id="tb_nik"></center>
                        <h2>Введите Пароль</h2>
                        <center><input type="text" size="30" id="tb_password"> </center>
                         <h2>Повторите Пароль</h2>
                        <center><input type="text" size="30" id="tb_password2"> </center>                   
				    </div>
                    <a href="UserMenu.aspx" class="create" id="bt_create">Ок</a>  
                    <a href="Vxod.aspx" class="cancel" id="bt_cancel">Отмена</a>            
			</div>
          </div>
        </form>
</body>
</html>
