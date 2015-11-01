<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="WebApplication1.Rating" %>

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
                <h4>Рейтинг игроков</h4>
                <center>
                <table border="1">
				 <tr>
				   <td>Номер</td>
				   <td>Ник</td>
                   <td>Рейтинг</td>
				 </tr>
				 <tr>
                   <td>1</td>
				   <td>2</td>
                   <td>3</td>
				 </tr>
			   </table>
               </center>
                <a href="usermenu.aspx" class="vmenu" id="bt_vmenu">Назад</a>
            </div>
          </div>
    </form>
</body>
</html>
