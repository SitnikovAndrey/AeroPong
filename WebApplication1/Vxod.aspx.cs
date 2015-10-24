using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<personaldata> PD = new List<personaldata>();
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=auropong;User=root;Password=1234");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_vhod_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            } 
            object[] s = new object[3];
            int a;
            MySqlCommand cmd = new MySqlCommand("Select online, nickname, points from auropong.players where nickname='" + TextBox2.Text + "' and password='" + TextBox1.Text + "'", conn);
            DataTable d = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            try
            {
                adapter.Fill(d);

                s = d.Rows[0].ItemArray;
              
                
                a= Convert.ToInt32(s[0]);
                if (a == 0)
                {
                    cmd = new MySqlCommand("update auropong.players set online = 1 where nickname = '" + s[1] + "'", conn);
                    cmd.BeginExecuteNonQuery();
                    //переход на страницу пользователя
                }
                else
                {
                    //сделать лейбл под текст боксами и присваивать ему значение чо пользотатель уже в сети
                    //lable3.text = "этот пользотатель уже в сети";
                }
            }
            catch (Exception ex)
            {
                //lable3.text = "ошибка проверьте правильность вводитых данных";
            }
            conn.Close();
        }
    }
}