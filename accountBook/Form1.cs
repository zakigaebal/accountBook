using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace accountBook
{
	public partial class Form1 : Form
	{
		MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8");
		bool changSaveUpdate = true;



		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			buttonLogin_Click(sender, e);
			buttonSearch_Click(sender, e);
			buttonUpdate.Enabled = false;
		    radioButton1.Checked = true;
		}
		private void 연결(string selectQuery, string account)
		{
			selectQuery = "SELECT * FROM dawoon.dc_items";
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
			connection.Close();
		}
		private void CrudSql(string Query, string 메세지)
		{
			string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
			MySqlConnection con = new MySqlConnection(Connect);
			MySqlCommand Comm = new MySqlCommand(Query, con);
			MySqlDataReader Read;
			con.Open();
			Read = Comm.ExecuteReader();
			MessageBox.Show(메세지);
			con.Close();
		}
		public void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			
			if (radioButton1.Checked)
			{
				string account = "지출";
				comboBoxName.Items.Clear();
				
				try
				{
					string selectQuery = "SELECT * FROM dawoon.dc_items";
					연결(selectQuery, account);
					comboBoxName.SelectedIndex = 0;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
					string selectQuery = "SELECT * FROM dawoon.dc_items";
					연결(selectQuery, account);
					comboBoxName.SelectedIndex = 0;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
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
			if (textBoxContent.Text == "")
			{
				MessageBox.Show("내용을 입력해주세요");
				textBoxContent.Focus();
				return;
			}
			try
			{
				string moneydot = textBoxMoney.Text;
				var startDay = DateTime.Parse(pDate.Value.ToString("yyyy-MM-01"));
				var endDay = DateTime.Parse(startDay.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
				// 마감날짜 해아함
				string account = "지출";
				if (radioButton2.Checked)
					account = "수입";
				string Query = "insert into dawoon.dc_account(accSeq,usedDate,accAcount,itemSeq,subject,money,content,memo,flagYN,regDate,issueDate,issueID) values('"
						+ seqCount() + "','"
						+ pDate.Text + "','"
						+ account + "','"
						+ getItemSeq(account, comboBoxName.Text) + "','"
						+ comboBoxName.Text.Trim() + "','"
						+ moneydot + "','"
						+ textBoxContent.Text.Trim() + "','"
						+ textBoxMemo.Text.Trim()
						+ "','Y',now(),now(),'CDY');";

				CrudSql(Query, "저장완료");
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
				string Query2 = "SELECT 가계부.accSeq," +
					 " 가계부.usedDate," +
					 " 항목.acount," +
					 " 항목.subject," +
					 " 가계부.money," +
					 " 가계부.content," +
					 " 가계부.memo," +
					 " 가계부.flagYN," +
					 " 가계부.regDate," +
					 " 가계부.issueDate," +
					 " 가계부.issueID" +
					 " FROM dc_account 가계부" +
					 " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject)";
				string searchtext = textBoxSearch.Text.Trim();
				string keyText = comboBoxSearch.Text;
				string field = "";
				if (keyText == "항목") field = "항목.subject ";
				else if (keyText == "내용") field = "가계부.content";
				string flagYN = "";
				if (checkBoxDelShow.Checked == true)
				{
					flagYN = "가계부.flagYN = 'N'";
				}
				else
				{
					flagYN = "가계부.flagYN = 'Y'";
				}
				// SELECT  accSeq, usedDate, dc_items.acount, dc_items.itemSeq, dc_items.subject, money, content, memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account LEFT JOIN dc_items ON dc_account.subject = dc_items.subject;
				Query = "select * from dc_account " +
						"WHERE " + field + " like '%" + searchtext + "%' " + flagYN;
				Query2 = "SELECT 가계부.accSeq," +
					 " 가계부.usedDate," +
					 " 항목.acount," +
					 " 항목.subject," +
					 " 가계부.money," +
					 " 가계부.content," +
					 " 가계부.memo," +
					 " 가계부.flagYN," +
					 " 가계부.regDate," +
					 " 가계부.issueDate," +
					 " 가계부.issueID" +
					 " FROM dc_account 가계부" +
					 " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject) WHERE " + flagYN;
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
				dataGridView1.Columns[1].HeaderText = "날짜";
				dataGridView1.Columns[2].HeaderText = "계정";
				dataGridView1.Columns[3].HeaderText = "항목";
				dataGridView1.Columns[4].HeaderText = "금액";
				dataGridView1.Columns[5].HeaderText = "내용";
				dataGridView1.Columns[3].HeaderText = "메모";
			}
			catch (Exception ex)
			{
				string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
				string Query2 = "select * from dawoon.dc_account;";
				if (ex.Message.ToString() == "Table 'dawoon.dc_account' doesn't exist")
				{
					Query2 = "CREATE TABLE IF NOT EXISTS `dc_account` (" +
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
					MySqlCommand Comm = new MySqlCommand(Query2, con);
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
			radioButton1.Checked = false;
			radioButton2.Checked = false;
			textBoxMoney.Text = "0";
			textBoxContent.Text = "";
			pDate.Text = "";
			comboBoxName.Text = "";
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (changSaveUpdate == true)
			{
				changSaveUpdate = false;

				buttonUpdate.Enabled = true;
				buttonSave.Enabled = false;
			}
			else
			{
				changSaveUpdate = true;
			}


			string account = "지출";
			if (radioButton2.Checked)
				account = "수입";


			string accountName = getItemSeq(account, comboBoxName.Text);
			if (e.RowIndex < 0)
			{
				return;
			}

			pDate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
				string QueryDelete = "update dawoon.dc_account set flagYN='N' WHERE accSeq=" + seqstr;
				CrudSql(QueryDelete, "삭제완료");
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
				string QueryUpdate = "update dawoon.dc_account AS 가계부 RIGHT JOIN dawoon.dc_items AS 항목 " +
					"ON (가계부.subject = 항목.subject)" +
					"SET 가계부.accSeq='" + seqstr +
					"',가계부.usedDate='" + pDate.Text.Trim() +
					"',항목.acount='" + account +
					"',항목.subject='" + comboBoxName.Text +
					"',가계부.money='" + textBoxMoney.Text +
					"',가계부.content='" + textBoxContent.Text +
					"',가계부.memo='" + textBoxMemo.Text + "' where 가계부.accSeq='" + seqstr + "';";
				CrudSql(QueryUpdate, "수정완료");
				buttonSearch_Click(sender, e);
				buttonSave.Enabled = true;
				clear();
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
		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void textBoxMoney_TextChanged(object sender, EventArgs e)
		{

			string prevValue = string.Empty;
			TextBox textBox = sender as TextBox;

			string text = textBox.Text.Replace(",", ""); // 입력되는 텍스트들의 ','를 전부 삭제하기

			long num = 0;
			if (long.TryParse(text, out num))//숫자형태의 값일 때만 처리
			{
				textBox.Text = string.Format("{0:#,##0}", num); // 천단위 콤마 표시
				textBox.SelectionStart = textBox.TextLength;//커서를 항상 글자 제일 뒤로 위치시킴
				textBox.SelectionLength = 0;
			}
			else
			{
				textBox.Text = prevValue;//숫자형태의 값이 아니면 이전값으로 설정
			}

			prevValue = textBox.Text;

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

		private void pDate_ValueChanged_1(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
				return;
			// 데이터가 Red인 경우 배경색을 빨강으로 변경
			if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "지출")
			{
				e.CellStyle.BackColor = Color.PaleVioletRed;
				e.CellStyle.ForeColor = Color.White;
			}
			// 데이터가 Blue인 경우 배경색을 파랑으로 변경
			else if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "수입")
			{
				e.CellStyle.BackColor = Color.CornflowerBlue;
				e.CellStyle.ForeColor = Color.White;
			}
		}

		private void buttonTerm_Click(object sender, EventArgs e)
		{
			buttonSearch_Click(sender, e);
		}

		private void buttonDate_Click(object sender, EventArgs e)
		{
			//dateTimePicker1.Text = baseYear + "-" + int.Parse(f.Mon).ToString("00");
			//    buttonSearch_Click(sender,e);
		}
		private void textBoxMoney_KeyDown(object sender, KeyEventArgs e)
		{
		}
		private void comboBoxName_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}
		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void buttontest_Click(object sender, EventArgs e)
		{

		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}


