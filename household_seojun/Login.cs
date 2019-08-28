using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace household_seojun
{
    public partial class Login : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=household;Uid=root;Pwd=1234;");

        // private List<Form> frmList = new List<Form>();


        public Login()
        {
        
            InitializeComponent();
        }

        private void LoginOk_Click(object sender, EventArgs e)
        {
            String pain = userNameTb.Text;
            // 데이터베이스 household , tabel member, 컬럼으로 u_name과 u_pw가 있다.
            
            // 로그인 폼을 출력하고 정보를 맞게 입력하지 않거나, 정보가 틀렸다면 메시지 박스 출력
            // 이름과 암호를 입력받고 맞게 입력했다면 MainFo(메인폼) 활성화

            // 회원가입 linklabel 클릭시 로그인 폼인 join 폼 활성화

            member mb = new member(); // 사용자의 정보를 set, get을 통해 입력을 받아 넣는 member폼

            string name = userNameTb.Text.ToString(); // Tb에 입력된 이름과 정보를 입력받는다.
            string pw = uesrPwTb.Text.ToString();

            pain = name;

            string sql = "select * from member where u_name ='" + name + "';"; // 해당 u_name를 데이터베이스에서 조회
            MySqlCommand selectCommand = new MySqlCommand(sql, connection);

            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlDataReader rdr;

            rdr = selectCommand.ExecuteReader();

            if (!rdr.Read()) // u_name의 데이터를 조회 하지 못했을시 아래 메시지박스 출력
            {
                MessageBox.Show("사용자이름 또는 비밀번호가 틀렸습니다.");
            }
            else
            {
                string s_pw = (string)rdr["u_pw"]; // 데이터베이스에 있는 u_name과 u_pw 대입
                string s_name = (string)rdr["u_name"];

                if (pw.Equals(s_pw)) // 비밀번호가 같을시 member class에 대입
                {
                    mb.name = (string)rdr["u_name"];
                    mb.pw = (string)rdr["u_pw"];
                    string s = userNameTb.Text;
                    MainFo mf = new MainFo(s); // 메인폼 활성화

                    mf.Visible = true;
                    this.Visible = false;
                    
    
                }
                
                else if (!name.Equals(s_name))
                {
                    MessageBox.Show("가입되지 않은 사용자입니다.");
                }

                else
                {
                    MessageBox.Show("가입되지 않은 사용자입니다.");
                }
            }

            connection.Close();
        }

        private void UesrPwTb_KeyDown(object sender, KeyEventArgs e)
        {
            // 패스워드에서 enter키 keydown시 loginOk 버튼과 같은 이벤트 실행
            if (e.KeyCode == Keys.Enter)
            {
                String pain = userNameTb.Text;

                member mb = new member(); // 사용자의 정보를 set, get을 통해 입력을 받아 넣는 member폼

                string name = userNameTb.Text.ToString(); // Tb에 입력된 이름과 정보를 입력받는다.
                string pw = uesrPwTb.Text.ToString();

                pain = name;

                string sql = "select * from member where u_name ='" + name + "';"; // 해당 u_name를 데이터베이스에서 조회
                MySqlCommand selectCommand = new MySqlCommand(sql, connection);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlDataReader rdr;

                rdr = selectCommand.ExecuteReader();

                if (!rdr.Read()) // u_name의 데이터를 조회 하지 못했을시 아래 메시지박스 출력
                {
                    MessageBox.Show("사용자이름 또는 비밀번호가 틀렸습니다.");
                }
                else
                {
                    string s_pw = (string)rdr["u_pw"]; // 데이터베이스에 있는 u_name과 u_pw 대입
                    string s_name = (string)rdr["u_name"];

                    if (pw.Equals(s_pw)) // 비밀번호가 같을시 member class에 대입
                    {
                        mb.name = (string)rdr["u_name"];
                        mb.pw = (string)rdr["u_pw"];
                        string s = userNameTb.Text;
                        MainFo mf = new MainFo(s); // 메인폼 활성화

                        mf.Visible = true;
                        this.Visible = false;


                    }

                    else if (!name.Equals(s_name))
                    {
                        MessageBox.Show("가입되지 않은 사용자입니다.");
                    }

                    else
                    {
                        MessageBox.Show("가입되지 않은 사용자입니다.");
                    }
                }

                connection.Close();

            }
        }

        private void joinlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Join jo = new Join();
            jo.Visible = true;

            Login lg = new Login();
            lg.Visible = false;
        }

        void userLogin()
        {
            Login lg = new Login();
            DialogResult result = lg.ShowDialog();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
