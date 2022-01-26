using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace accountBook
{

    // 이슈
    // 테이블연동...
    public partial class Form2 : Form
    {
        public Form2()
        {
           
            InitializeComponent();
           
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        // 테이블을 두개로 바꿔야됨
        // account테이블 기존 하나
        // 또 다른 테이블 하나 items 테이블 하나 생성
        // items안에는 itemSe q가 있고 userInout, Name(월급,이자,상여금,보너스)
        // uerInOut 옆에 userSe.q도 있어야함 item테이블
        // ... 클릭하면 새로운폼 띄우고 콤보박스내용name과 아이템 입력값을 저장
        // 콤보박스내용 Name 이 바뀌게
        // 날짜 텍스트박스가 아니라 데이터픽커로
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        private void comboBoxInOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComBoChange();
        }
        private void ComBoChange()
        {
            //함수로 만들어보자
            // 만약에 userInOut 내용이 지출이라면 콤보박스내용 Name은 간식 교통비 교육비 월세 외식을 보여준다
            if (comboBoxInOut.Text == "수입") 
            {
                comboBoxName.Text = "월급";
                comboBoxName.Items.Clear();
                comboBoxName.Items.Add("월급");
                comboBoxName.Items.Add("떡값");
                comboBoxName.Items.Add("상여금");
                comboBoxName.Items.Add("보너스");
            }
            else if (comboBoxInOut.Text == "지출")
            {
                comboBoxName.Text = "간식";
                comboBoxName.Items.Clear();
                comboBoxName.Items.Add("간식");
                comboBoxName.Items.Add("교통비");
                comboBoxName.Items.Add("교육비");
                comboBoxName.Items.Add("월세");
                comboBoxName.Items.Add("외식");
            }
        }
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private string seqCount()
        {
            try
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "SELECT MAX(itemsSeq)+1 AS seqMax FROM dawoon.dc_items;";
                MySqlConnection con = new MySqlConnection(Connect);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["seqMax"].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        private void clear()
        {
            comboBoxInOut.Text = "수입";
            comboBoxName.Text = "월급";
            textBoxMoney.Text = "";
            textBoxMemo.Text = "";
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxMoney.Text == "")
            {
                MessageBox.Show("입력값을 입력해주세요");
                textBoxMoney.Focus();
                return;
            }
            try
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "insert into dawoon.dc_items(itemsSeq,userInOut,userContents,userMoney,userCalender,userWhy,flagYN,regDate,issueDate,issueID) values('"
                    + seqCount() + "','" + comboBoxInOut.Text.Trim() + "','" + comboBoxName.Text.Trim() + "','"
                    + textBoxMoney.Text.Trim() + "','" + dateTimePickerCalender.Text.Trim() + "','" + textBoxMemo.Text.Trim()
                    + "','Y',now(),now(),'CDY')" + ";";

                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query, con);
                MySqlDataReader Read;
                con.Open();
                Read = Comm.ExecuteReader();
                MessageBox.Show("저장완료");           
                clear();
                //구글링으로해결
                // 다른 폼에 있는 메소드를 호출시키고 싶은데
                // buttonSearch_Click(sender, e);
                // 로드 자동으로 검색서치 되게만들기
                Form1 MainForm = (Form1)Owner;
                //메인폼안에 있는 SetConnectionButton메소드를 호출할 수 있다
                MainForm.buttonSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        
        

       
    }
}
