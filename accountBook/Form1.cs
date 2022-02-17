﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
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
			try
			{
				buttonLogin_Click(sender, e);
				
				buttonSearch_Click(sender, e);
				buttonUpdate.Enabled = false;
				radioButton1.Checked = true;
				DateTime MonthFirstDay = DateTime.Now.AddDays(1 - DateTime.Now.Day);
				dateTimePicker2.Value = MonthFirstDay;
				pDate.Value = DateTime.Now;
				dateTimePicker1.Value = DateTime.Now;
				ChartRefresh();

			}
			catch (Exception ex)
			{
			}
		}

		private void 연결(string selectQuery, string account)
		{
			selectQuery = "SELECT * FROM dawoon.dc_items where flagYN = 'Y';";
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
					if (ex.Message.ToString() == "'0'의 InvalidArgument = Value는 'SelectedIndex'에 사용할 수 없습니다.\r\n매개 변수 이름: SelectedIndex")
					{
						MessageBox.Show("항목입력하기");
					}
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
					if (ex.Message.ToString() == "'0'의 InvalidArgument = Value는 'SelectedIndex'에 사용할 수 없습니다.\r\n매개 변수 이름: SelectedIndex")
					{
						MessageBox.Show("항목입력하기");
					}
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
					if (rdr["seqMax"].ToString() == "")
					{
						string a;
						a = rdr["seqMax"].ToString();
						a = "1";
						return a;
					}
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
				var startDay = DateTime.Parse(pDate.Value.ToString("yyyy-MM-01"));
				var endDay = DateTime.Parse(startDay.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
				string moneydot = textBoxMoney.Text;

		
				string account = "지출";
				if (radioButton2.Checked)
					account = "수입";


				string QuerySave = "insert into dawoon.dc_account(accSeq,usedDate,accAcount,itemSeq,subject,money,content,memo,flagYN,regDate,issueDate,issueID) values('"
						+ seqCount() + "','"
						+ pDate.Text + "','"
						+ account + "','"
						+ getItemSeq(account, comboBoxName.Text) + "','"
						+ comboBoxName.Text.Trim() + "','"
						+ moneydot + "','"
						+ textBoxContent.Text.Trim() + "','"
						+ textBoxMemo.Text.Trim()
						+ "','Y',now(),now(),'CDY');";


				CrudSql(QuerySave, "저장완료");
				clear();
				buttonSearch_Click(sender, e);
				radioButton1.Checked = true;

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
				string searchtext = textBoxSearch.Text.Trim();
				string keyText = comboBoxSearch.Text;
				string field = "";
				string flagYN = "";
				string Query2 = "";
				string Query3 = "";
			
				if (keyText == "항목") field = "가계부.subject ";
				else if (keyText == "내용") field = "가계부.content";
			
				if (checkBoxDelShow.Checked == true)
				{
					flagYN = "가계부.flagYN = 'N'";
				}
				else
				{
					flagYN = "가계부.flagYN = 'Y'";
				}
				// SELECT  accSeq, usedDate, dc_items.acount, dc_items.itemSeq, dc_items.subject, money, content, memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account LEFT JOIN dc_items ON dc_account.subject = dc_items.subject;

				// 	+ getItemSeq(account, comboBoxName.Text) + "','"

				Query3 = "select " +
					 " 가계부.accSeq," +
					 " 가계부.usedDate," +
					 " 가계부.accAcount," +
					 " 가계부.subject," +
					 " 가계부.money," +
					 " 가계부.content," +
					 " 가계부.memo," +
					 " 가계부.flagYN," +
					 " 가계부.regDate," +
					 " 가계부.issueDate," +
					 " 가계부.issueID " +
					"from dc_account 가계부 WHERE " + field + " like '" + "%" + searchtext + "%" + "' AND " + flagYN;

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
					 " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject) WHERE " + field + " like '" + "%" + searchtext + "%" + "' AND " + flagYN;
				//  + field + "like '%" + searchtext + "'% AND " + flagYN;
				//  " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject) WHERE " + flagYN;
				MySqlConnection con = new MySqlConnection(Connect);
				MySqlCommand Comm = new MySqlCommand(Query3, con);
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
				dataGridView1.Columns[6].HeaderText = "메모";
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


			if (account == "수입")
			{
				radioButton1.Checked = false;
				radioButton2.Checked = true;
			}
			else if(account == "지출")
			{
				radioButton1.Checked = true;
				radioButton2.Checked = false;
			}
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
			if (textBoxContent.Text == "")
			{
				MessageBox.Show("내용을 입력해주세요");
				textBoxContent.Focus();
				return;
			}

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
					"',가계부.accAcount='" + account +
					"',가계부.subject='" + comboBoxName.Text +
					"',가계부.money='" + textBoxMoney.Text +
					"',가계부.content='" + textBoxContent.Text +
					"',가계부.memo='" + textBoxMemo.Text + "' where 가계부.accSeq='" + seqstr + "';";
				CrudSql(QueryUpdate, "수정완료");
		
				buttonSave.Enabled = true;
				clear();
				buttonSearch_Click(sender, e);
				buttonUpdate.Enabled = false;
				radioButton1.Checked = true;
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
			

			try
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
			catch(Exception ex)
			{
			
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


		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
				return;
			// 데이터가 Red인 경우 배경색을 빨강으로 변경
			if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "지출")
			{
				e.CellStyle.BackColor = Color.MistyRose;
				e.CellStyle.ForeColor = Color.Black;
			}
			// 데이터가 Blue인 경우 배경색을 파랑으로 변경
			else if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "수입")
			{
				e.CellStyle.BackColor = Color.AliceBlue;
				e.CellStyle.ForeColor = Color.Black;
			}
		}

		

		private void buttonTerm_Click(object sender, EventArgs e)
		{
			string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
			string flagYN = "";
			string Query2 = "";
			if (checkBoxDelShow.Checked == true)
			{
				flagYN = "가계부.flagYN = 'N'";
			}
			else
			{
				flagYN = "가계부.flagYN = 'Y'";
			}
			// SELECT  accSeq, usedDate, dc_items.acount, dc_items.itemSeq, dc_items.subject, money, content, memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account LEFT JOIN dc_items ON dc_account.subject = dc_items.subject;
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
							 " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject)" +
							" where 가계부.usedDate between '" + dateTimePicker2.Value.ToString() + "' and '" + dateTimePicker1.Value.ToString() + "' and " + flagYN;
			//  + field + "like '%" + searchtext + "'% AND " + flagYN;
			//  " RIGHT JOIN dc_items 항목 ON (가계부.subject = 항목.subject) WHERE " + flagYN;
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
			dataGridView1.Columns[6].HeaderText = "메모";
		}

	
		private void textBoxMoney_KeyDown(object sender, KeyEventArgs e)
		{
		}
		private void comboBoxName_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
			buttonUpdate.Enabled = false;
		}
		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Form1_Click(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
		{
		
		}

		private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			buttonSearch_Click(sender, e);
		}

		private void panel2_Click(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void tableLayoutPanel2_Click(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		
		}

		private void pDate_KeyPress(object sender, KeyPressEventArgs e)
		{
	
			buttonSave.Enabled = true;
			
		}

		private void textBoxMemo_Click(object sender, EventArgs e)
		{
	
			buttonSave.Enabled = true;
		
		}

		private void textBoxContent_Click(object sender, EventArgs e)
		{
		
			buttonSave.Enabled = true;
		
		}

		private void textBoxMoney_Click(object sender, EventArgs e)
		{
	
			buttonSave.Enabled = true;
		
		}

		private void comboBoxName_Click(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void pDate_MouseDown(object sender, MouseEventArgs e)
		{
			buttonSave.Enabled = true;
		
		}

		private void dataGridView1_Click(object sender, EventArgs e)
		{
			buttonSave.Enabled = false;
			buttonUpdate.Enabled = true;
		
		}

		private void comboBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void comboBoxSearch_SelectedIndexChanged_1(object sender, EventArgs e)
		{

		}

		private void textBoxSearch_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			chart2.Series[0].Points.Clear();
			ChartRefresh();
		
		}

		private void ChartRefresh()
		{
			string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
			MySqlConnection conn = new MySqlConnection(Connect);
			MySqlCommand cmd = new MySqlCommand("select * from dawoon.dc_account", conn);
			MySqlDataReader myReader;
			try
			{
				conn.Open();
				myReader = cmd.ExecuteReader();
				while (myReader.Read())
				{
					chart2.Series[0].Points.AddXY(myReader.GetString("accAcount"), myReader.GetString("money"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void buttonFileSave_Click(object sender, EventArgs e)
		{
			ExportToCSV();
		}

		private void ExportToCSV()
		{
			SaveFileDialog saveFileDialog = GetCsvSave();
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Save_Csv(saveFileDialog.FileName, dataGridView1, true); // dataGridView에 데이터를 세팅하는 메서드를 호출
			}
		}

		bool headerText = true;
		private void Save_Csv(string fileName, DataGridView dataGridView1, bool v)
		{
			string delimiter = ",";  // 구분자
			FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
			StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8); //UTF8로 엔코딩

			if (dataGridView1.Rows.Count == 0) return;

			// header가 true면 헤더정보 출력
			if (headerText)
			{
				for (int i = 1; i < dataGridView1.Columns.Count - 4; i++)
				{
					csvExport.Write(dataGridView1.Columns[i].HeaderText);
					if (i != dataGridView1.Columns.Count - 1)
					{
						csvExport.Write(delimiter);
					}
				}
			}

			csvExport.Write(csvExport.NewLine); // add new line

			// 데이터 출력
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					for (int i = 1; i < dataGridView1.Columns.Count - 4; i++)
					{
						csvExport.Write(row.Cells[i].Value);
						if (i != dataGridView1.Columns.Count - 1)
						{
							csvExport.Write(delimiter);
						}
					}
					csvExport.Write(csvExport.NewLine); // write new line
				}
			}



			csvExport.Flush();
			csvExport.Close();
			fs.Close();

			MessageBox.Show("CSV 파일 저장 완료！");
		}

		private SaveFileDialog GetCsvSave()
		{
			//Getting the location and file name of the excel to save from user.
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.CheckPathExists = true;
			saveDialog.AddExtension = true;
			saveDialog.ValidateNames = true;

			string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string filepath = Path.GetDirectoryName(path);


			saveDialog.InitialDirectory = filepath;// Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			saveDialog.DefaultExt = ".csv";
			saveDialog.Filter = "csv (*.csv) | *.csv";
			saveDialog.FileName = "export".ToString();

			return saveDialog;
		}
	}
}


