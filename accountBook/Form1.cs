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
                string Query = "SELECT MAX(accountSeq)+1 AS seqMax FROM dawoon.dc_account;";
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
                if (textBoxDate.Text == "")
                {
                    MessageBox.Show("날짜를 입력해주세요");
                    textBoxDate.Focus();
                    return;
                }
                try
                {
                    string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                    string Query = "insert into dawoon.dc_account(accountSeq,userDate,userSpend,userWhy,flagYN,regDate,issueDate,issueID) values('"
                        + seqCount() + "','" + textBoxDate.Text.Trim() + "','" + textBoxSpend.Text.Trim() + "','" + richTextBoxWhy.Text.Trim() 
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

         

            private void buttonSearch_Click(object sender, EventArgs e)
            {
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "select * from dawoon.dc_account;";
                string searchtext = textBoxSearch.Text.Trim();
                string keyText = comboBoxSearch.Text;
                string field = "";
                if (keyText == "날짜") field = "userDate";
                else if (keyText == "쓴돈") field = "userSpend";
                else if (keyText == "사유") field = "userWhy";
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
            private void clear()
            {
                textBoxDate.Text = "";
                textBoxSearch.Text = "";
                textBoxSpend.Text = "";
                richTextBoxWhy.Text = "";
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                textBoxDate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxSpend.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            richTextBoxWhy.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }

            private void buttonDel_Click(object sender, EventArgs e)
            {
            try
            {
                string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
                string Query = "update dawoon.dc_account set flagYN='N' WHERE accountSeq=" + seqstr;
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
                    string Query = "UPDATE dawoon.dc_account SET accountSeq='" + seqstr + "',userDate"
                        + textBoxDate.Text + "',userSpend='" + textBoxSpend.Text + "',userWhy ='" + richTextBoxWhy.Text 
                        + "; WHERE accountSeq='" + seqstr + "';";
                    MySqlConnection con = new MySqlConnection(Connect);
                    MySqlCommand Comm = new MySqlCommand(Query, con);
                    MySqlDataReader Read;
                    con.Open();
                    Read = Comm.ExecuteReader();
                    MessageBox.Show("수정완료");
                    con.Close();
                    buttonSave_Click(sender, e);
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
            buttonSearch_Click(sender, e);
        }
    }
    }
