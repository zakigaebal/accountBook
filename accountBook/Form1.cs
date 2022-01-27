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
        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string account = "지출";
                comboBoxName.Items.Clear();


                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8");
                    string selectQuery = "SELECT * FROM dawoon.dc_items";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //지출로 저장한 account변수가 sql 필드 acoount가 맞으면 subject를 추가해라
                        if (account == reader.GetString("acount"))
                        {
                            comboBoxName.Items.Add(reader.GetString("subject"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*
         * 금액 타입으로 바꿔주는 함수
         */
        private string LetMoneyTYPE(string Num)
        {
            if (Num.Contains("."))
            {
                //소수점 이하의 스트링을 저장한다.
                int Check = Num.Substring(Num.IndexOf('.')).Length;
                char[] delimiterChars = { '.' };
                string[] words = Num.Split(delimiterChars);
                string mntyNum = string.Format("{0:#,0}", int.Parse(words[0]));
                string ComplateNum = string.Format("{0}.{1}", mntyNum, words[1]);
                return ComplateNum;
            }
            else
            {
                string mntyNum = string.Format("{0:#,0}", int.Parse(Num));
                string ComplateNum = string.Format("{0}", mntyNum);
                return ComplateNum;
            }
        }



        
        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string account = "수입";
               
                comboBoxName.Items.Clear();
                try
                {
                    MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8");
                    string selectQuery = "SELECT * FROM dawoon.dc_items";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //수입으로 저장한 account변수가 sql 필드 acoount가 맞으면 subject를 추가해라
                        if (account == reader.GetString("acount"))
                        {
                            comboBoxName.Items.Add(reader.GetString("subject"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // getItemSeq 함수를 만들기
        private string getItemSeq(string account, string txt)
        {
            try
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "SELECT itemSeq FROM dawoon.dc_items WHERE subject = '" + txt + "' AND acount ='" + account + "';";
                MySqlConnection con = new MySqlConnection(Connect);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["itemSeq"].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        private string seqCount()
        {
            try
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "SELECT MAX(accSeq)+1 AS seqMax FROM dawoon.dc_account;";
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
            if (textBoxMoney.Text == "")
            {
                MessageBox.Show("금액을 입력해주세요");
                textBoxMoney.Focus();
                return;
            }

            try
            {
                string account = "지출";
                if (radioButton2.Checked)
                    account = "수입";
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "insert into dawoon.dc_account(accSeq,usedDate,accAcount,itemSeq,subject,money,content,memo,flagYN,regDate,issueDate,issueID) values('"
                    + seqCount() + "','"
                    + dateTimePickerCalender.Text.Trim() + "','"
                    + account + "','"
                    + getItemSeq(account, comboBoxName.Text) + "','"
                    + comboBoxName.Text.Trim() + "','"
                    + textBoxMoney.Text.Trim() + "','"
                    + textBoxContent.Text.Trim() + "','"
                    + textBoxMemo.Text.Trim()
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
                string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
                string Query = "select * from dc_account;";
                string Query2 = "SELECT accSeq, usedDate, dc_items.acount, dc_account.subject, dc_account.money, content, dc_account.memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account RIGHT OUTER JOIN dc_items ON dc_account.subject = dc_items.subject";
                string searchtext = textBoxSearch.Text.Trim();
                string keyText = comboBoxSearch.Text;
                string field = "";
                if (keyText == "금액") field = "dc_account.money";
                else if (keyText == "메모") field = "dc_account.memo";
                string flagYN = "";
                if (checkBoxDelShow.Checked == true)
                {
                    flagYN = "";
                }
                else
                {
                    flagYN = "AND dc_items.flagYN = 'Y'";
                }
                // SELECT  accSeq, usedDate, dc_items.acount, dc_items.itemSeq, dc_items.subject, money, content, memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account LEFT JOIN dc_items ON dc_account.subject = dc_items.subject;
                Query = "select * from dc_account " +
                    "WHERE " + field + " like '%" + searchtext + "%' " + flagYN;
                Query2 = "SELECT accSeq, usedDate, dc_items.acount, dc_account.subject, dc_account.money, content, dc_account.memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account RIGHT OUTER JOIN dc_items ON dc_account.subject = dc_items.subject WHERE dc_account.flagYN = 'Y' AND dc_items.flagYN = 'Y'";
                MySqlConnection con = new MySqlConnection(Connect);
                MySqlCommand Comm = new MySqlCommand(Query2, con);
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
                         "`accSeq` int(11) NOT NULL COMMENT " + "'번호'," +
                         "`usedDate` varchar(10) DEFAULT '' COMMENT '달력'," +
                         "`accAcount` varchar(20) DEFAULT '' COMMENT '지출수입'," +
                          "`itemSeq` varchar(11) DEFAULT '' COMMENT 'dc_items의 고유번호'," +
                          "`subject` varchar(30) DEFAULT '' COMMENT '아이템들'," +
                          "`money` varchar(300) DEFAULT '' COMMENT '돈'," +
                          "`content` varchar(300) DEFAULT '' COMMENT '내용'," +
                          "`memo` varchar(300) DEFAULT '' COMMENT '메모'," +
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
            textBoxSearch.Text = "";
            textBoxMemo.Text = "";
            textBoxMoney.Text = "";
            textBoxContent.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string account = "지출";
            if (radioButton2.Checked)
                account = "수입";
            string accountName = getItemSeq(account, comboBoxName.Text);
            if (e.RowIndex < 0)
            {
                return;
            }
            dateTimePickerCalender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            account = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //accountName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBoxName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxMoney.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxContent.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBoxMemo.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "update dawoon.dc_account set flagYN='N' WHERE accSeq=" + seqstr;
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
            string account = "지출";
            if (radioButton2.Checked)
                account = "수입";
            string accountName = getItemSeq(account, comboBoxName.Text);
            try
            {
                string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
                string Query = "UPDATE dc_account AS a, dc_items AS b SET a.accSeq='" + seqstr +
                  "',a.usedDate='" + dateTimePickerCalender.Text.Trim() +
                  "',b.acount='" + account +
                  "',a.subject='" + comboBoxName.Text +
                  "',a.money='" + textBoxMoney.Text +
                  "',a.content='" + textBoxContent.Text +
                  "',a.memo='" + textBoxMemo.Text + "' where a.accSeq='" + seqstr + "';";
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
            buttonLogin_Click(sender, e);
            buttonSearch_Click(sender, e);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("실패");
                this.Close();
            }
        }
        private void buttonForm2_Click(object sender, EventArgs e)
        {
            //새로운창뜨기
            //지출등록
            //수입등록
            //dc_account dc_items
            Form2 newform2 = new Form2();
            newform2.ShowDialog(this);
        }
     
        private void ComBoChange()
        {
        }
        private void buttonForm2_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePickerCalender_ValueChanged(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void textBoxMoney_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBoxMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
               
            }
            
        }
    }
}
