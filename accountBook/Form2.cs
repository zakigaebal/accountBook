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

namespace accountBook
{
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
        // items안에는 itemsSeq가 있고 userInout, Name(월급,이자,상여금,보너스)
        // uerInOut 옆에 userSeq도 있어야함 item테이블
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
                comboBoxName.Items.Add("월급");
                comboBoxName.Items.Add("떡값");
                comboBoxName.Items.Add("상여금");
                comboBoxName.Items.Add("보너스");
            }
            else if (comboBoxInOut.Text == "지출")
            {
                comboBoxName.Text = "간식";
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
                string Query = "SELECT MAX(userSeq)+1 AS seqMax FROM dawoon.dc_account;";
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
            dateTimePickerCalender.Text = "";
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
                string Query = "insert into dawoon.dc_account(userSeq,userInOut,userContents,userMoney,userCalender,userWhy,flagYN,regDate,issueDate,issueID) values('"
                    + seqCount() + "','" + comboBoxInOut.Text.Trim() + "','" + comboBoxName.Text.Trim() + "','"
                    + textBoxMoney.Text.Trim() + "','" + dateTimePickerCalender.Text.Trim() + "','" + textBoxMemo.Text.Trim()
                    + "','Y',now(),now(),'CDY');";

                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query, con);
                MySqlDataReader Read;
                con.Open();
                Read = Comm.ExecuteReader();
                MessageBox.Show("저장완료");           
                clear();
                //추가
                //로드 자동으로 검색서치 되게만들기
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        

       
    }
}
