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
    public partial class MainFo : Form
    {

        public MainFo()
        {
            InitializeComponent();
        }

        private void MainFo_Load(object sender, EventArgs e)
        {
            this.Show();

        }

        void Sum()
        {
            int CategoryCount = this.listView1.Items.Count; // 리스트뷰 항목 카운트 수
            int Totalin = 0; // 값 초기화
            int Totalout = 0;
            int balance = 0;

            for(int i=0; i<CategoryCount; i++) // for문을 이용하여 리스트뷰 항목 수 만큼 총 입금액, 지출액 구하기
            {
                ListViewItem item = listView1.Items[i];
                string MoneyIn = item.SubItems[2].Text.Replace(",", ""); // 금액 별 , 추가하기 
                string MoneyOut = item.SubItems[3].Text.Replace(",", "");

                if (MoneyIn == "") MoneyIn = "0";
                if (MoneyOut == "") MoneyOut = "0";

                int MoneyIn2 = int.Parse(MoneyIn); 
                int MoneyOut2 = int.Parse(MoneyOut);

                balance = MoneyIn2 - MoneyOut2; // 잔액 계산

                Totalin += MoneyIn2;
                Totalout += MoneyOut2;

            }
            sbSumIn.Text = Totalin.ToString("");    // staus strip에 잔액, 총입금액, 총지출액 넣기 
            sbSumOut.Text = Totalout.ToString("");
            sbBlance.Text = balance.ToString("");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            MoneyIn m = new MoneyIn();
            DialogResult result = m.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                DateTime date = m.dateTimePicker1.Value;
                string category = m.tbCategory.Text;
                string money = m.tbMoneyIn.Text;
                string memo = m.tbMemo.Text;

                ListViewItem lv1 = listView1.Items.Add(date.ToShortDateString());

                lv1.SubItems.Add(category); // 리스트뷰1에 분류, 금액, 비고 추가
                lv1.SubItems.Add(money);
                lv1.SubItems.Add("");
                lv1.SubItems.Add(memo);
                Sum();
            }

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            MoneyOut m = new MoneyOut();
            DialogResult result = m.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DateTime date = m.dateTimePicker1.Value;
                string category = m.tbMoneyOut.Text;
                string money = m.tbMoneyOut.Text;
                string memo = m.tbMemo.Text;

                ListViewItem lv1 = listView1.Items.Add(date.ToShortDateString());

                lv1.SubItems.Add(category); // 리스트뷰1에 분류, 금액, 비고 추가
                lv1.SubItems.Add("");
                lv1.SubItems.Add(money);
                lv1.SubItems.Add(memo);
                Sum();
            }

        }
    }
}
