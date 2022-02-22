using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Reflection;


namespace accountBook
{
	public partial class Form1 : Form
	{
		MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8");
		bool changSaveUpdate = true;
	

		public Form1()
		{
			InitializeComponent();
			dataGridView1.DoubleBuffered(true);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
		
				dataGridView1.SuspendLayout();

				buttonLogin_Click(sender, e);
		
				buttonUpdate.Enabled = false;
				radioButton1.Checked = true;
				DateTime MonthFirstDay = DateTime.Now.AddDays(1 - DateTime.Now.Day);
				dateTimePicker2.Value = MonthFirstDay;
				pDate.Value = DateTime.Now;

				dateTimePicker1.Value = DateTime.Now;
				dateTimePicker3.Value = DateTime.Now;
				dateTimePicker5.Value = MonthFirstDay;
				dateTimePicker6.Value = DateTime.Now;
				chart();
				buttonSearch_Click(sender, e);
	
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


	
		private void connect(string selectQuery, string account)
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

		private void chart()
		{
			string strConn = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";

			string Dchart = "select accAcount, SUBJECT, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate  =" +
			 "'" + dateTimePicker3.Text + "'"  + "AND accAcount = '수입' AND flagYN ='Y' GROUP BY SUBJECT ORDER BY useddate asc;";
			string Dchart2 = "select accAcount, SUBJECT, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate  =" +
			 "'" + dateTimePicker3.Text + "'"   + "AND accAcount = '지출' AND flagYN ='Y' GROUP BY SUBJECT ORDER BY useddate asc;";
			string Dchart6 = "select useddate, accAcount, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate  =" +
			 "'" + dateTimePicker3.Text + "'" + "AND flagYN ='Y' GROUP BY useddate,accacount ORDER BY useddate asc; ";
			
			string Dchart4 = "select accAcount, SUBJECT, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate  " +
			"BETWEEN" + "'" + dateTimePicker5.Text + "'" + " AND " + "'" + dateTimePicker6.Text + "'" + "AND accAcount = '수입' AND flagYN ='Y' GROUP BY SUBJECT ORDER BY useddate asc;";
			string Dchart5 = "select accAcount, SUBJECT, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate  " +
			"BETWEEN" + "'" + dateTimePicker5.Text + "'" + " AND " + "'" + dateTimePicker6.Text + "'" + "AND accAcount = '지출' AND flagYN ='Y' GROUP BY SUBJECT ORDER BY useddate asc;";
			string Dchart7 = "select useddate, accAcount, sum(cast(replace(money,',','') AS INT))  money FROM dc_account WHERE usedDate " +
			"BETWEEN" + "'" + dateTimePicker5.Value.ToString() + "'" + " AND " + "'" + dateTimePicker6.Value.ToString() + "'" + "AND flagYN ='Y' GROUP BY useddate,accacount ORDER BY useddate asc; ";


			try 
			{ 
			using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
			{
				conn.Open(); // conn 연결
				MySqlCommand cmd = new MySqlCommand(Dchart, conn); //명령클래스 cmd 생성
				DataSet ds = new DataSet(); //데이터셋 ds 생성
				MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
				sa.Fill(ds); //sa 데이터어뎁터 변수를 ds데이터셋에 채워라
										 // DataTable 객체를 DataSource에 지정하고,
										 // X,Y축 컬럼을 XValueMember와 YValueMembers에 지정
				chart1.DataSource = ds.Tables[0]; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
				chart1.Series[0].XValueMember = "subject"; // x축 컬럼 subject필드
				chart1.Series[0].YValueMembers = "money"; // y축 컬럼 money필드
	
				chart1.DataBind(); //chart2 데이터바인딩
				chart1.Series[0].ChartType = SeriesChartType.Pie;
				//가계부.usedDate(between '" + dateTimePicker2.Value.ToString() + "' and '" + dateTimePicker1.Value.ToString() + "') and " +
			}
				using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
				{
					conn.Open(); // conn 연결
					MySqlCommand cmd = new MySqlCommand(Dchart2, conn); //명령클래스 cmd 생성
					DataSet ds = new DataSet(); //데이터셋 ds 생성
					MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
					sa.Fill(ds); //sa 데이터어뎁터 변수를 ds데이터셋에 채워라
											 // DataTable 객체를 DataSource에 지정하고,
											 // X,Y축 컬럼을 XValueMember와 YValueMembers에 지정
					chart3.DataSource = ds.Tables[0]; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
					chart3.Series[0].XValueMember = "subject"; // x축 컬럼 subject필드
					chart3.Series[0].YValueMembers = "money"; // y축 컬럼 money필드

					chart3.DataBind(); //chart2 데이터바인딩
					chart3.Series[0].ChartType = SeriesChartType.Pie;
				}

				using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
				{
					conn.Open(); // conn 연결
					MySqlCommand cmd = new MySqlCommand(Dchart4, conn); //명령클래스 cmd 생성
					DataSet ds = new DataSet(); //데이터셋 ds 생성
					MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
					sa.Fill(ds); //sa 데이터어뎁터 변수를 ds데이터셋에 채워라
											 // DataTable 객체를 DataSource에 지정하고,
											 // X,Y축 컬럼을 XValueMember와 YValueMembers에 지정
					chart4.DataSource = ds.Tables[0]; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
					chart4.Series[0].XValueMember = "subject"; // x축 컬럼 subject필드
					chart4.Series[0].YValueMembers = "money"; // y축 컬럼 money필드

					chart4.DataBind(); //chart2 데이터바인딩
					chart4.Series[0].ChartType = SeriesChartType.Pie;
				}

				using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
				{
					conn.Open(); // conn 연결
					MySqlCommand cmd = new MySqlCommand(Dchart5, conn); //명령클래스 cmd 생성
					DataSet ds = new DataSet(); //데이터셋 ds 생성
					MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
					sa.Fill(ds); //sa 데이터어뎁터 변수를 ds데이터셋에 채워라
											 // DataTable 객체를 DataSource에 지정하고,
											 // X,Y축 컬럼을 XValueMember와 YValueMembers에 지정
					chart5.DataSource = ds.Tables[0]; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
					chart5.Series[0].XValueMember = "subject"; // x축 컬럼 subject필드
					chart5.Series[0].YValueMembers = "money"; // y축 컬럼 money필드

					chart5.DataBind(); //chart2 데이터바인딩
					chart5.Series[0].ChartType = SeriesChartType.Pie;
				}

				using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
		   {
			  chart2.Series.Clear();
				conn.Open(); // conn 연결
				MySqlCommand cmd = new MySqlCommand(Dchart6, conn); //명령클래스 cmd 생성
				DataTable dTable = new DataTable();
				MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
				sa.Fill(dTable);
				chart2.DataSource = dTable; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
				chart2.DataBindCrossTable(dTable.AsEnumerable(), "accAcount", "usedDate", "money", "");
		   }
				using (MySqlConnection conn = new MySqlConnection(strConn)) // 연결클래스 conn 생성
				{
					chart6.Series.Clear();
					conn.Open(); // conn 연결
					MySqlCommand cmd = new MySqlCommand(Dchart7, conn); //명령클래스 cmd 생성
					DataTable dTable = new DataTable();
					MySqlDataAdapter sa = new MySqlDataAdapter(cmd); //cmd인자를 받은 데이터어뎁터 sa 생성
					sa.Fill(dTable);
					chart6.DataSource = dTable; //chart6.데이터소스는 ds,Tables의 첫번째로 지정
					chart6.DataBindCrossTable(dTable.AsEnumerable(), "accAcount", "usedDate", "money", "");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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
					connect(selectQuery, account);
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
					connect(selectQuery, account);
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
						+ moneydot.Replace(",","") + "','"
						+ textBoxContent.Text.Trim() + "','"
						+ textBoxMemo.Text.Trim()
						+ "','Y',now(),now(),'CDY');";
				CrudSql(QuerySave, "저장완료");
				clear();
				buttonSearch_Click(sender, e);
				radioButton1.Checked = true;
				chart();
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
		
				string QuerySearch = "";
			
				if (keyText == "항목") field = "ab.subject ";
				else if (keyText == "내용") field = "ab.content";
			
				if (checkBoxDelShow.Checked == true)
				{
					flagYN = "ab.flagYN = 'N'";
				}
				else
				{
					flagYN = "ab.flagYN = 'Y'";
				}
				// SELECT  accSeq, usedDate, dc_items.acount, dc_items.itemSeq, dc_items.subject, money, content, memo, dc_items.flagYN, dc_items.regDate, dc_items.issueDate, dc_items.issueID FROM dc_account LEFT JOIN dc_items ON dc_account.subject = dc_items.subject;

				// 	+ getItemSeq(account, comboBoxName.Text) + "','"

				QuerySearch = "select " +
					 " ab.accSeq," +
					 " ab.usedDate," +
					 " it.acount," +
					 " it.subject," +
					 " ab.money," +
					 " ab.content," +
					 " ab.memo," +
					 " ab.flagYN," +
					 " ab.regDate," +
					 " ab.issueDate," +
					 " ab.issueID " +
					 " FROM dc_account ab" +
					 " RIGHT JOIN dc_items it ON (ab.subject = it.subject) WHERE "
							+ "ab.usedDate between '" + dateTimePicker2.Value.ToString() + "' and '" + dateTimePicker1.Value.ToString() + "' AND "
					 + field + " like '" + "%" + searchtext + "%" + "' AND " + flagYN;
				MySqlConnection con = new MySqlConnection(Connect);
				MySqlCommand Comm = new MySqlCommand(QuerySearch, con);
				MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
				MyAdapter.SelectCommand = Comm;
				DataTable dTable = new DataTable();
				MyAdapter.Fill(dTable);
				//dataGridView1.SuspendLayout(); 포스팅 더블버퍼링 C#차트
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
				chart();
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
				string moneydot = textBoxMoney.Text;
				string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
				string QueryUpdate = "update dawoon.dc_account AS ab RIGHT JOIN dawoon.dc_items AS it " +
					"ON (ab.itemSeq = it.itemSeq)" +
					"SET ab.accSeq='" + seqstr +
					"',ab.usedDate='" + pDate.Text.Trim() +
					"',it.acount='" + account +
					"',it.subject='" + comboBoxName.Text +
					"',ab.money='" + moneydot.Replace(",", "") +
					"',ab.content='" + textBoxContent.Text +
					"',ab.memo='" + textBoxMemo.Text + "' where ab.accSeq='" + seqstr + "';";
				CrudSql(QueryUpdate, "수정완료");
				buttonSave.Enabled = true;
				clear();
				buttonSearch_Click(sender, e);
				buttonUpdate.Enabled = false;
				radioButton1.Checked = true;
				chart();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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
				MessageBox.Show(ex.Message);
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
		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}
		private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
		{
		}

		private void chart2_Click(object sender, EventArgs e)
		{

		}

		private void chart2_Click_1(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
		{

		}

		private void buttonChart_Click(object sender, EventArgs e)
		{
			chart();
		}

		private void buttonChart2_Click(object sender, EventArgs e)
		{
			chart();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			chart();
		}
	}
	//Put this class at the end of the main class or you will have problems.
	public static class ExtensionMethods    // DoubleBuffered 메서드를 확장 시켜주자..
	{
		public static void DoubleBuffered(this DataGridView dgv, bool setting)
		{
			Type dgvType = dgv.GetType();
			PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
			pi.SetValue(dgv, setting, null);
		}
	}
}
