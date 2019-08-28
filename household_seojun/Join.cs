using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace household_seojun
{
    

    public partial class Join : Form
    {

        Login lg;

        string name;
        string pw;

        String strConn = "Server=localhost;Database=household;Uid=root;Pwd=1234;";
        //MySqlConnection connection = new MySqlConnection("Server=localhost;Database=household;Uid=root;Pwd=1234;");

        public Join()
        {
            InitializeComponent();
        }

        public Join(Login lg)
        {
            InitializeComponent();
            this.lg = lg;
        }

        private void Join_Load(object sender, EventArgs e)
        {
            
        }

        private void joinOk_Click(object sender, EventArgs e)
        {
            /*SqlConnection sql = new SqlConnection(@"Data Source=(local);Initial Catalog=household;Integrated Security=True");
            sql.Open();
            SqlCommand sqc = new SqlCommand("insert into gil values('" + j_name.Text + "','" + j_pw.Text + "')", sql);
            sqc.ExecuteNonQuery();
            sql.Close();*/
            if (j_name.Text == "")
            {
                MessageBox.Show("아이디에 공백을 입력 하실 수 없습니다.");
            }
            else if (j_pw.Text == "")
            {
                MessageBox.Show("비밀번호에 공백을 입력 하실 수 없습니다.");
            }

            else if (!j_name.Equals("") && !j_pw.Equals(""))
            {
                string sql;

                MySqlConnection conn = new MySqlConnection(strConn);
                MySqlCommand cmd = new MySqlCommand("", conn);
                conn.Open();

                sql = "CREATE TABLE IF NOT EXISTS member (u_name char(10), u_pw varchar(30))";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                try
                {
                    name = j_name.Text.ToString();
                    pw = j_pw.Text.ToString();

                    sql = "INSERT INTO member VALUES('" + name + "', '" + pw + "')";

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("회원가입 성공");
                }
                catch (Exception)
                {
                    MessageBox.Show("회원가입 실패");
                }

                conn.Close();

                //string id = j_name.Text.ToString();
                //string pw = j_pw.Text.ToString();

                //string sql = "insert into user(u_name, u_password) values(@name, @pw)";
                //MySqlCommand cmd = new MySqlCommand();

                //MySqlCommand selectCommand = new MySqlCommand(sql, connection);

                this.Dispose();

                //Login lg = new Login();
                //lg.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("공백을 입력 하실 수 없습니다.");
            }
            
        }

        private void Join_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}
