using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 구현한 목록 (1502100464 이서준)
 * 1. DB 연동을 이용한 회원가입과 로그인
 * 2. BaseDirectory을 이용해서 텍스트 데이터 파일인 .csv파일을 통한 저장하기, 불러오기 기능
 * 3. 입금, 출금, 편집, 삭제버튼 이벤트 + 로그아웃 이벤트
 * 4. 차트를 통한 각 분류별 지출 습관 확인
 */

/* 미구현한 목록
 * 1. 회원가입으로 DB에 등록 되어있는 user에 따라 DB구축
 * 2. 월 변경, 월 마감 이벤트
 * 3. 기타 찾지 못한 버그들...
 */

namespace household_seojun
{
    public partial class MainFo : Form
    {

        public string Value { get; set; }

        string openfileName = "";
        //string user = "";
        String pain;    // Login 폼에서 유저 이름을 가져오기 위한 변수 pain

        public MainFo()
        {
            InitializeComponent();
        }

        public MainFo(String pain)
        {

            // Login 폼을 통해서 Login 했을 시, login한 아이디(사용자이름)을 불러서
            this.pain = pain;
            InitializeComponent();
            sbUserName.Text = this.pain;    // mainfo의 sbusername에 넣어준다.

        }

        private void MainFo_Load(object sender, EventArgs e)
        {
            this.Show();

            // 차트 초기화, 차트 그리기.
            charttypeset();
            drawgraph();

            openfileName = AppDomain.CurrentDomain.BaseDirectory + "Data\\" + DateTime.Now.ToString("yyyy-MM") + ".csv";
            // 현재 실행중인 어플리케이션의 bin - debug의 위치에 현재 날짜를 이름.csv 라는 엑셀파일을 생성할 수 있게끔 설정.

            //this.Focus();

            // 합하고(합의 과정 속 drawgraph를 한번 더 실행, 파일 불러오기
            Sum();
            LoadFile();

            //fileName = AppDomain.CurrentDomain.BaseDirectory + "Data\\" + DateTime.Now.ToString("yyyy-MM") + ".csv";
            //  Login lg = new Login();
            // sbUserName.Text = lg.pain;

        }

        public void charttypeset() // 차트 그래프를 그리기 위한 설정
        {
            // 차트를 그리기전 초기화 해주기
            expensechart.ChartAreas.Clear();
            expensechart.Series.Clear();

            // 차트 Areas를 "draw"라는 이름으로 설정
            expensechart.ChartAreas.Add("draw");
            
            // 차트의 배경색
            expensechart.ChartAreas["draw"].BackColor = Color.White;

            expensechart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.Gray; 
            // 대시로 구성 된 파선으로 지정
            expensechart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash; 

            expensechart.ChartAreas["draw"].AxisY.Minimum = 0; // 축설정 최소, 최대, 간격
            expensechart.ChartAreas["draw"].AxisY.Maximum = 500000; 
            expensechart.ChartAreas["draw"].AxisY.Interval = 100000;
            expensechart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.Gray; // 축의 색깔
            // 대시로 구성 된 파선으로 지정
            expensechart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;

            expensechart.Series.Add("나의 지출습관");
            // 세로 막대형의 차트를 그리기 위해 설정
            expensechart.Series["나의 지출습관"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            expensechart.Series["나의 지출습관"].Color = Color.Green;
            expensechart.Series["나의 지출습관"].BorderWidth = 4;
            expensechart.Series["나의 지출습관"].IsValueShownAsLabel = true;
            // 차트 값 색 설정
            expensechart.Series["나의 지출습관"].LabelForeColor = Color.Black;

        }

        public void drawgraph()
        {
            //차트 초기화 진행해주기
            charttypeset();
            MoneyOut f = new MoneyOut();
            int cnt = f.cbtype.Items.Count;
            String[] list = new string[cnt]; // list에 지출폼 item 만큼 수를 가져온다.

            int lcnt = listView1.Items.Count; // listview의 item 역시 그 수만큼 가져온다.

            int[] expensvalue = new int[cnt]; // 금액의 축을 담당할 expensvalue
            for (int i = 0; i < cnt; i++)
                expensvalue[i] = 0; // 금액 초기화

            for (int i = 0; i < cnt; i++)
            {
                list[i] = f.cbtype.Items[i] as string; // 리스트의 배열에 분류 항목 아이템을 차례차례 넣어준다.
            }

            for (int i = 0; i < cnt; i++)
            {

                for (int j = 0; j < lcnt; j++)
                {
                    if (list[i].Equals(listView1.Items[j].SubItems[1].Text)) // 같은 분류항목이라면
                    {

                        string value = listView1.Items[j].SubItems[3].Text; // vaule에 출금의 금액을 더한다.
                        string result = value; // result에 전해주고

                        if (value != "")
                            expensvalue[i] += int.Parse(result); // result는 expensvalue에 그 값을 전해준다.
                    }


                }
            }

            for (int i = 0; i < cnt; i++)
                expensechart.Series["나의 지출습관"].Points.AddXY(list[i], expensvalue[i]); // x축에 출금(분류)항목을 나타내고, y축에 출금액을 나타낸다.
                expensechart.Series["나의 지출습관"].Label.ToString();
            
        }


            void Sum()
            {
            int CategoryCount = this.listView1.Items.Count; // 리스트뷰 항목 카운트 수
            int 합계_입금 = 0; // 값 초기화
            int 합계_출금 = 0;
            int 잔액 = 0;

            for (int i = 0; i < CategoryCount; i++) // for문을 이용하여 리스트뷰 항목 수 만큼 총 입금액, 지출액 구하기
            {
                ListViewItem item = listView1.Items[i];     // 리스트뷰의 satus strip에 각 정보를 넣어주기 위한 작업과 그 값 설정들
                string 입금 = item.SubItems[2].Text.Replace(",", ""); // 금액의 ,를 "" 공백으로 바꿔주기 위한 작업
                string 출금 = item.SubItems[3].Text.Replace(",", "");

                if (입금 == "") 입금 = "0";
                if (출금 == "") 출금 = "0";

                int i입금 = int.Parse(입금);
                int i출금 = int.Parse(출금);

                잔액 += i입금 - i출금; //잔액 계산

                합계_입금 += i입금;
                합계_출금 += i출금;

            }
            sbSumIn.Text = 합계_입금.ToString("");    // staus strip에 잔액, 총입금액, 총지출액 넣기 
            sbSumOut.Text = 합계_출금.ToString("");

            // 잔액이 0원보다 적을시 빨간색으로 글꼴 처리
            if (잔액 < 0) sbBlance.ForeColor = Color.Red;
            sbBlance.Text = 잔액.ToString("");

            drawgraph(); // sum 실행 후 차트에 다시 집계를 해주기 위한 과정

        }

        private void LoadFile()
        {
            if (sbUserName.Text == "")
            {
                MessageBox.Show("로그인을 하세요");
                return;
            }

            // 불러오기
            // 날짜, 분류, 입금, 출금, 비고 등

            string savefolder = AppDomain.CurrentDomain.BaseDirectory + "Data"; // 윈도우 폼에서 사용하는 기능 ( 현재 어플리케이션이 실행되는 경로)

            DateTime timeNow = DateTime.Now;
            string fileName = openfileName; // 저장폴더 + "\\" + 현재시간.ToString("yyyy-MM") + ".csv";

            // 파일이 없다면 사용 불가처리
            if (System.IO.File.Exists(fileName) == false)
            {
                MessageBox.Show("저장된 파일이 없습니다.\n\n" + fileName, "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectMonth = fileName.Substring(fileName.LastIndexOf('\\') + 1, 7);
            lbMon.Text = selectMonth;

            // 내용 지우기
            listView1.Items.Clear();

            //파일을 읽어온다.
            string[] Content = System.IO.File.ReadAllLines(fileName, System.Text.Encoding.UTF8); // 저장된 utf-8 형식의 데이터를 불러오기
            int cc = Content.Length; // 내용의 길이를 맞는지 확인하고 대입해주기 위해

            // 파일을 읽어와서 listview에 업로드

            for (int i = 1; i < cc; i++)
            {
                string lineContent = Content[i];
                string[] linebuffer = lineContent.Split(',');

                ListViewItem item = listView1.Items.Add(linebuffer[0]);  //날짜
                item.SubItems.Add(linebuffer[1]); //분류

                if (linebuffer[2] == "") linebuffer[2] = "0";   //입금액이 없었다면 int를 넣어주기 위해 0 처리
                if (linebuffer[3] == "") linebuffer[3] = "0";   //출금액이 없었다면 int를 넣어주기 위해 0 처리

                int MoneyIn = int.Parse(linebuffer[2]); // 입금액에 int형으로 대입
                int MoneyOut = int.Parse(linebuffer[3]);    // 출금액에 int형으로 대입

                if (MoneyIn != 0)
                    item.SubItems.Add(MoneyIn.ToString("n0")); //입금
                else
                    item.SubItems.Add(""); // 입금 항목이 아니라면 공백 처리

                if (MoneyOut != 0)
                    item.SubItems.Add(MoneyOut.ToString("")); //출금
                else
                    item.SubItems.Add(""); // 출금 항목이 아니라면 공백 처리

                item.SubItems.Add(linebuffer[4]); //비고
            }
            Sum();

        }

        void SaveFile()
        {
            //저장하기 메서드
            //날짜,분류,입금,출금,비고를 저장 할 수 있다.

            string savefolder = AppDomain.CurrentDomain.BaseDirectory + "Data"; // 현재 어플리케이션이 실행 되고 있는 폴더에 저장한다.
            string fileName = openfileName; // 저장폴더 + "\\" + DateTime.Now.ToString("yyyy-MM") + ".csv"; 형식 지정해주기
            // string filePath = System.IO.Directory.GetCurrentDirectory() + @"\data";
            string content = "날짜,분류,입금,출금,비고";


            // Directory.GetAccessControl폴더에 관한 권한을 부여한다.
            Directory.GetAccessControl(savefolder);

            //Directory.GetAccessControl(openfileName);

            // 저장폴더가 없는 경우에만 생성
            if (System.IO.Directory.Exists(savefolder) == false) 
                System.IO.Directory.CreateDirectory(savefolder); // 폴더 생성을하며, 폴더 생성 권한이 없으면 부여해준다.


            // 만약에 저장폴더가 없다면 폴더를 생성해준다.
            //if (Directory.Exists(savefolder) == false)
            //{
              //  Directory.CreateDirectory(savefolder); // 폴더 생성에 관한 권한이 없을때 권한을 부여해주기
            //}

            int cc = listView1.Items.Count; // 카운트 된 만큼 리스트뷰에 추가해주기 위한 작업
            for (int i = 0; i < cc; i++)
            {
                ListViewItem item = listView1.Items[i];
                string date = item.SubItems[0].Text.Replace(",", "");       // 리스트뷰들의 아이템을 불러오기
                string category = item.SubItems[1].Text.Replace(",", "");
                string moneyin = item.SubItems[2].Text.Replace(",", "");
                string moneyout = item.SubItems[3].Text.Replace(",", "");
                string memo = item.SubItems[4].Text.Replace(",", "");
                content += "\n" + date + "," + category + "," + moneyin + "," + moneyout + "," + memo; //저장이름
            }

            System.IO.File.WriteAllText(fileName, content, System.Text.Encoding.UTF8); // 파일 이름과 내용을 utf-8 형식으로 저장해주기

            //System.IO.File.WriteAllText(savefolder, content);

            Console.WriteLine("저장파일명=" + fileName);
            //Console.WriteLine("저장파일명=" + fileName); // 저장 파일명 출력
        }

        public void sortCOL()
        {
            listView1.Sorting = SortOrder.Ascending;
        }

        private void btnIn_Click(object sender, EventArgs e) // 입금 버튼 클릭 이벤트
        {
            MoneyIn m = new MoneyIn();
            DialogResult result = m.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DateTime date = m.dateTimePicker1.Value;
                string category = m.cbtype.SelectedItem as string; // 분류 항목은 콤보박스로 되어 있기 때문에
                string money = m.tbMoneyIn.Text;
                string memo = m.tbMemo.Text;

                ListViewItem lv1 = listView1.Items.Add(date.ToShortDateString());

                lv1.SubItems.Add(category); // 리스트뷰1에 분류, 금액, 비고 추가
                lv1.SubItems.Add(money);
                lv1.SubItems.Add("");
                lv1.SubItems.Add(memo);
                Sum();
                SaveFile();
                sortCOL();
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            MoneyOut m = new MoneyOut();
            DialogResult result = m.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DateTime date = m.dateTimePicker1.Value;
                string category = m.cbtype.SelectedItem as string; // 분류 항목은 콤보박스로 되어 있기 때문에
                string money = m.tbMoneyOut.Text;
                string memo = m.tbMemo.Text;

                ListViewItem lv1 = listView1.Items.Add(date.ToShortDateString());

                lv1.SubItems.Add(category); // 리스트뷰1에 분류, 금액, 비고 추가
                lv1.SubItems.Add("");
                lv1.SubItems.Add(money);
                lv1.SubItems.Add(memo);
                Sum();
                SaveFile();
                sortCOL();
            }
        }

        private void MainFo_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveFile();
            Application.Exit();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Lobby lb = new Lobby();
            lb.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editData();
        }

        void editData()
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("데이터를 선택하세요");
                return;
            }

            //선택된 자료의 구분을 확인한다.
            ListViewItem lv = listView1.SelectedItems[0];
            string 날짜 = lv.SubItems[0].Text;
            string 분류 = lv.SubItems[1].Text;
            string 입금액 = lv.SubItems[2].Text;
            string 출금액 = lv.SubItems[3].Text;
            string 비고 = lv.SubItems[4].Text;

            // 입금을 선택한 경우
            if (입금액 != "")
            {
                //입금화면을 호출하고 현재 데이터를 전송
                MoneyIn f = new MoneyIn(날짜, 입금액, 분류, 비고);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //현재선택된 자료를 업데이트
                    lv.SubItems[0].Text = f.dateTimePicker1.Value.ToShortDateString(); //2018-12-11
                    lv.SubItems[1].Text = f.cbtype.Text; //분류

                    string 입력값 = f.tbMoneyIn.Text.Replace(",", "");
                    if (입력값 == "") 입력값 = "0";
                    int 숫자값 = int.Parse(입력값);
                    lv.SubItems[2].Text = 숫자값.ToString(""); //입금    

                    lv.SubItems[3].Text = "";  //출금
                    lv.SubItems[4].Text = f.tbMemo.Text;
                }
            }
            else // 그 밖의 경우 출금 화면 호출
            {
                //출금화면을 호출하고...
                MoneyOut f = new MoneyOut(날짜, 출금액, 분류, 비고);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //현재선택된 자료를 업데이트
                    lv.SubItems[0].Text = f.dateTimePicker1.Value.ToShortDateString(); //2018-12-11
                    lv.SubItems[1].Text = f.cbtype.Text;
                    lv.SubItems[2].Text = ""; //입금

                    string 입력값 = f.tbMoneyOut.Text.Replace(",", "");
                    if (입력값 == "") 입력값 = "0";
                    int 숫자값 = int.Parse(입력값);
                    lv.SubItems[3].Text = 숫자값.ToString(""); //출금

                    lv.SubItems[4].Text = f.tbMemo.Text;
                }
            }
            SaveFile();
            Sum();
            sortCOL();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DelData();
        }

        void DelData()
        {
            // 삭제메뉴
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("데이터를 선택하세요");
                return;
            }

            ListViewItem lv = listView1.SelectedItems[0];
            string 분류 = lv.SubItems[1].Text;
            string 입금액 = lv.SubItems[2].Text;
            string 출금액 = lv.SubItems[3].Text;
            string 표시금액 = "";

            if (입금액 != "") 표시금액 = 입금액;
            else 표시금액 = 출금액;

            DialogResult result = MessageBox.Show("삭제하시겠습니까?\n\n분류 : " + 분류 + "\n금액 : " + 표시금액 + "원", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                listView1.Items.Remove(lv);
                MessageBox.Show("삭제 완료");
                SaveFile();
                Sum();
                sortCOL();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {

        }
    }
}