<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMenu.aspx.cs" Inherits="WebApplication1.UserMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aero-Pong</title>
    <link rel="stylesheet" href="Style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="popup--centered_overlay">
            <div class="usermenu">
                <h2>Aero-Pong!</h2>
                <h3>Ник</h3>
                <a href="Vxod.aspx" class="logout" id="bt_logout">Выход</a>
                <a href="#" class="creategame" id="bt_creategame">Создать игру</a>
                <a href="#" class="joingame" id="bt_joingame">Присоединиться к игре</a>
                <a href="#" class="rating" id="bt_rating">Рейтинг</a>
            </div>
          </div>
    </form>
</body>
</html>
