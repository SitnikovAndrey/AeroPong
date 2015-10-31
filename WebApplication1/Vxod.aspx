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
                    
                    <br />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="Label3" runat="server" Text="Ник"></asp:Label>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px" Width="151px"></asp:TextBox>                                            
                    <br />
                    <br />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
               
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                    <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
				    <br />
                    <br />
                    <br />
                    <br />
                    <a class="join">                    
                    <asp:Button ID="bt_vhod" runat="server" Text="Войти" Height="37px" OnClick="bt_vhod_Click" Width="109px" />
                    </a>
                    <a class="reg">
                    <asp:Button ID="bt_otm" runat="server" Text="Регистрация" Height="37px" Width="108px" />
                    </a>
				</div>
			</div>
		</center>
        </form>
</body>
</html>
