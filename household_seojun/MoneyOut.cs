using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace household_seojun
{
    public partial class MoneyOut : Form
    {
        public MoneyOut()
        {
            InitializeComponent();
            setCombo();
        }
        
        public void setCombo()
        {
            string[] list = { "세금", "식비", "교통비", "통신비", "기타" };
            cbtype.Items.AddRange(list);
            cbtype.SelectedIndex = 0;
        }

        public MoneyOut(string dt, string money, string category, string memo)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Parse(dt);
            cbtype.SelectedIndex = cbtype.Items.IndexOf(category);
            tbMoneyOut.Text = money;
            tbMemo.Text = memo;
            setCombo();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (cbtype.Text == "") //분류 입력이 되었는지 체크하기
            {
                cbtype.Focus(); //안되었다면 분류 텍스트박스 포커스
                return;
            }

            if (tbMoneyOut.Text == "")
            {
                tbMoneyOut.Focus();
                return;
            }

            //폼이 종료될 때 작업한 내용을 전달하기 위하여 OK 버튼 클릭시 DialogReulst 
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
