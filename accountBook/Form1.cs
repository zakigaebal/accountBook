using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace accountBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        private void buttonSave_Click(object sender, EventArgs e)
            {
                if (comboBoxInOut.Text == "")
                {
                    MessageBox.Show("날짜를 입력해주세요");
                    comboBoxInOut.Focus();
                    return;
                }
                try
                {
                    string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                    string Query = "insert into dawoon.dc_account(userSeq,userInOut,userContents,userMoney,userCalender,userWhy,flagYN,regDate,issueDate,issueID) values('"
                        + seqCount() + "','" + comboBoxInOut.Text.Trim() + "','" + comboBoxContents.Text.Trim() + "','" 
                        + textBoxMoney.Text.Trim() + "','" + dateTimePickerCalender.Text.Trim() + "','" + richTextBoxWhy.Text.Trim() 
                        + "','Y',now(),now(),'CDY');";

                    MySqlConnection con = new MySqlConnection(Connect);
                    MySqlCommand Comm = new MySqlCommand(Query, con);
                    MySqlDataReader Read;
                    con.Open();
                    Read = Comm.ExecuteReader();
                    MessageBox.Show("저장완료");
                    con.Close();
                clear();
                    buttonSearch_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

         

            public void buttonSearch_Click(object sender, EventArgs e)
            {
            try
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "select * from dawoon.dc_account;";
                string searchtext = textBoxSearch.Text.Trim();
                string keyText = comboBoxSearch.Text;
                string field = "";
                if (keyText == "금액") field = "userContents";

                else if (keyText == "메모") field = "userWhy";
                string flagYN = "";
                if (checkBoxDelShow.Checked == true)
                {
                    flagYN = "";
                }
                else
                {
                    flagYN = "AND flagYN = 'Y'";
                }
                Query = "select * from dawoon.dc_account WHERE " + field + " like '%" + searchtext + "%' " + flagYN;
                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query, con);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = Comm;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[dataGridView1.Columns.Count - 4].Visible = false;
                dataGridView1.Columns[dataGridView1.Columns.Count - 3].Visible = false;
                dataGridView1.Columns[dataGridView1.Columns.Count - 2].Visible = false;
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
            }
            catch (Exception ex)
            {
                string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
                string Query = "select * from dawoon.dc_account;";
                if (ex.Message.ToString() == "Table 'dawoon.dc_account' doesn't exist")
                {
                    Query = "CREATE TABLE IF NOT EXISTS `dc_account` (" +
  "`userSeq` int(11) NOT NULL COMMENT " + "'번호'," +
  "`userInOut` varchar(10) DEFAULT '' COMMENT '지출수입'," +
  "`userContents` varchar(20) DEFAULT '' COMMENT '내용'," +
  "`userMoney` varchar(11) DEFAULT '' COMMENT '돈'," +
  "`userCalender` varchar(30) DEFAULT '' COMMENT '달력'," +
  "`userWhy` varchar(300) DEFAULT '' COMMENT '사유'," +
  "`flagYN` varchar(1) DEFAULT 'Y' COMMENT '가용여부(Y:유효/N:삭제)'," +
  "`regDate` datetime DEFAULT NULL COMMENT '최초저장일'," +
  "`issueDate` datetime DEFAULT NULL COMMENT '최종저장일'," +
  "`issueID` varchar(20) DEFAULT '' COMMENT '최종저장자 ID'" +
") ENGINE = InnoDB DEFAULT CHARSET = utf8 COMMENT = '사용자 관리'; ";
                    MySqlConnection con = new MySqlConnection(Connect);
                    MySqlCommand Comm = new MySqlCommand(Query, con);
                    MySqlDataReader Read;
                    con.Open();
                    Read = Comm.ExecuteReader();
                    con.Close();
                }
                else if (ex.Message.ToString() == "Unable to connect to any of the specified MySQL hosts.")
                {
                    MessageBox.Show("데이터베이스가 없거나 실행되지않았습니다.");

                }

            }
        }
            private void clear()
            {
                comboBoxInOut.Text = "";
                textBoxSearch.Text = "";
                comboBoxContents.Text = "";
                richTextBoxWhy.Text = "";
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                comboBoxInOut.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBoxContents.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBoxMoney.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateTimePickerCalender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                richTextBoxWhy.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }

            private void buttonDel_Click(object sender, EventArgs e)
            {
            try
            {
                string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "update dawoon.dc_account set flagYN='N' WHERE userSeq=" + seqstr;
                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query, con);
                MySqlDataReader Read;
                con.Open();
                Read = Comm.ExecuteReader();
                MessageBox.Show("삭제완료");
                con.Close();
                buttonSearch_Click(sender, e);
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void buttonUpdate_Click(object sender, EventArgs e)
            {
                try
                {
                string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "UPDATE dawoon.dc_account SET userSeq='" + seqstr +
                  "',userInOut='" + comboBoxInOut.Text +
                  "',userContents='" + comboBoxContents.Text +
                  "',userMoney='" + textBoxMoney.Text +
                  "',userCalender='" + dateTimePickerCalender.Text.Trim() +
                  "',userWhy='" + richTextBoxWhy.Text + "' where userSeq='" + seqstr + "';";
                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query, con);
                MySqlDataReader Read;
                con.Open();
                Read = Comm.ExecuteReader();
                MessageBox.Show("수정완료");
                while (Read.Read())
                {

                }
                con.Close();
                buttonSearch_Click(sender, e);
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        
       

        

      


            private void textBoxSearch_TextChanged(object sender, EventArgs e)
            {
            if (textBoxSearch.Text == "")
            {
                buttonSearch_Click(sender, e);
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxDelShow_CheckedChanged(object sender, EventArgs e)
        {
            buttonSearch_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var f = new Login();
            DialogResult = f.ShowDialog();
            // 로그인 false로 바꾸고 해야함
            buttonSearch_Click(sender, e);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            DialogResult result = f.ShowDialog();
            if(result == DialogResult.OK)
            {
                MessageBox.Show("성공");
            }
           
        }

       

        private void buttonForm2_Click(object sender, EventArgs e)
        {
            //새로운창뜨기
            //지출등록
            //수입등록
            //dc_account dc_items
            Form2 newform2 = new Form2();
            newform2.ShowDialog();
        }

        private void comboBoxInOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonForm2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
