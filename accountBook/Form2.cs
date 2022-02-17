using System;
using System.Data;
using System.Drawing;
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
			show2();
		}
		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void comboBoxInOut_SelectedIndexChanged(object sender, EventArgs e)
		{
			//  ComBoChange();
		}

		private string seqCount()
		{
			try
			{
				string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
				string Query = "SELECT MAX(itemSeq)+1 AS seqMax FROM dawoon.dc_items;";
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
		private void clear()
		{

			textBoxSubject.Text = "";

		}

		private void show2()
		{
			try
			{
				string Connect = "datasource=127.0.0.1;database=dawoon;port=3306;username=root;password=ekdnsel;Charset=utf8";
				string Query = "select * from dc_items;";
				Query = "select * from dawoon.dc_items where flagYN = 'Y';";
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

				dataGridView1.Columns[1].HeaderText = "계정";
				dataGridView1.Columns[2].HeaderText = "항목";

			}

			catch (Exception ex)
			{
				string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
				string Query = "select * from dawoon.dc_items where flagYN = Y;";
				if (ex.Message.ToString() == "Table 'dawoon.dc_items' doesn't exist")
				{
					Query = "CREATE TABLE IF NOT EXISTS `dc_itmes` (" +
"`itemSeq` int(11) NOT NULL COMMENT " + "'아이템번호'," +
"`account` varchar(10) DEFAULT '' COMMENT '입금출금'," +
"`subject` varchar(20) DEFAULT '' COMMENT '내용'," +
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


		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
				string Query = "SELECT acount, subject, COUNT(*) FROM dawoon.dc_items GROUP BY acount, subject HAVING COUNT(*) > 1;";
				MySqlConnection con = new MySqlConnection(Connect);
				MySqlCommand Comm = new MySqlCommand(Query, con);
				MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
				MyAdapter.SelectCommand = Comm;
				DataTable dTable = new DataTable();

				MyAdapter.Fill(dTable);
				con.Open();

				int count = dTable.Rows.Count;
				if (count != 0) { MessageBox.Show("키워드가 이미 들어가 있습니다."); }
				else if (count == 0) { buttonSave_Click(sender, e); }
				con.Close();
				clear();
			}
			catch (Exception ex)
			{

			}
		}


		private void buttonSave_Click(object sender, EventArgs e)
		{
			string constring = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
			string Query3 = "select COUNT(itemSeq) cnt from dawoon.dc_items WHERE subject ='" + textBoxSubject.Text + "' AND acount = '"
					+ comboBoxAccount.Text + "' AND flagYN ='Y';";
			MySqlConnection con3 = new MySqlConnection(constring);
			MySqlCommand Comm3 = new MySqlCommand(Query3, con3);
			MySqlDataReader Read3;
			con3.Open();
			Read3 = Comm3.ExecuteReader();
			// select 문으로 동일한 값이 있으면 메세지박스를 띄우고 없으면 인서트 실행
			// 조건문 만약 서브젝트와 타이틀이 둘다 같으면 키워드가 존재한다고 메세지 띄우기
			while (Read3.Read())
			{
				// 1. 키값을 가져와서 저장시켜야됨. 저장시키고 변수 선언
				string cnt = Read3.GetString("cnt");
				// sub.Contains(subject2)
				if (Convert.ToInt32(cnt) > 0)
				{
					MessageBox.Show(textBoxSubject.Text + "키워드가 이미 들어가 있습니다.");
					// 2. 키값이랑 텍스트박스 서브젝트랑 존재하면 메세지박스 띄우기
				}
				// 지출이 계정이고 . 들어오는값이 용돈이고 용돈이 서브에 포함되

				else
				{
					// 지출인데 보너스가 없으면 보너스를 추가
					string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
					string Query = "insert into dawoon.dc_items(itemSeq,acount,subject,flagYN,regDate,issueDate,issueID) values('"
							+ seqCount() + "','" + comboBoxAccount.Text.Trim() + "','" + textBoxSubject.Text.Trim()
							+ "','Y',now(),now(),'CDY')" + ";";
					MySqlConnection con = new MySqlConnection(Connect);
					MySqlCommand Comm = new MySqlCommand(Query, con);
					MySqlDataReader Read;
					con.Open();
					Read = Comm.ExecuteReader();
					MessageBox.Show("저장완료");
					clear();
					show2();
					// 다른 폼에 있는 메소드를 호출시켜서
					// 로드 자동으로 검색서치 되게만들기
					Form1 MainForm = (Form1)Owner;
					//메인폼안에 있는 버튼서치메소드를 호출할 수 있다
					MainForm.buttonSearch_Click(sender, e);
					MainForm.radioButton1_CheckedChanged(sender, e);
					MainForm.radioButton2_CheckedChanged(sender, e);

				}
			}

		}
		private void buttonDel_Click(object sender, EventArgs e)
		{
			try
			{
				string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
				string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
				string Query = "update dawoon.dc_items set flagYN='N' WHERE itemSeq=" + seqstr;
				MySqlConnection con = new MySqlConnection(Connect);
				MySqlCommand Comm = new MySqlCommand(Query, con);
				MySqlDataReader Read;
				con.Open();
				Read = Comm.ExecuteReader();
				MessageBox.Show("삭제완료");
				con.Close();
				show2();
				clear();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{

			string constring = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
			string Query3 = "select COUNT(itemSeq) cnt from dawoon.dc_items WHERE subject ='" + textBoxSubject.Text + "' AND acount = '"
					+ comboBoxAccount.Text + "' AND flagYN ='Y';";
			MySqlConnection con3 = new MySqlConnection(constring);
			MySqlCommand Comm3 = new MySqlCommand(Query3, con3);
			MySqlDataReader Read3;
			con3.Open();
			Read3 = Comm3.ExecuteReader();
			// select 문으로 동일한 값이 있으면 메세지박스를 띄우고 없으면 인서트 실행
			// 조건문 만약 서브젝트와 타이틀이 둘다 같으면 키워드가 존재한다고 메세지 띄우기
			while (Read3.Read())
			{
				// 1. 키값을 가져와서 저장시켜야됨. 저장시키고 변수 선언
				string cnt = Read3.GetString("cnt");


				if (Convert.ToInt32(cnt) > 0)
				{

					MessageBox.Show(textBoxSubject.Text + "키워드가 이미 들어가 있습니다.");
					// 2. 키값이랑 텍스트박스 서브젝트랑 존재하면 메세지박스 띄우기
				}
				// 지출이 계정이고 . 들어오는값이 용돈이고 용돈이 서브에 포함되

				else
				{

					string seqstr = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
					string Connect = "datasource=127.0.0.1;port=3306;username=root;password=ekdnsel;Charset=utf8";
					string Query = "update dawoon.dc_items set itemSeq='" + seqstr
							+ "',acount='"
							+ comboBoxAccount.Text
							+ "',subject='" + textBoxSubject.Text
							+ "' where itemSeq='" + seqstr + "' and flagYN = 'Y';";
					MySqlConnection con = new MySqlConnection(Connect);
					MySqlCommand Comm = new MySqlCommand(Query, con);
					MySqlDataReader Read;
					con.Open();
					Read = Comm.ExecuteReader();
					MessageBox.Show("수정완료");
					con.Close();
					show2();
					clear();
				}
				
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0)
			{
				return;
			}
			comboBoxAccount.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
			textBoxSubject.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


		}

	

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
				return;
			// 데이터가 Red인 경우 배경색을 빨강으로 변경
			if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "지출")
			{
				e.CellStyle.BackColor = Color.MistyRose;
				e.CellStyle.ForeColor = Color.Black;
			}
			// 데이터가 Blue인 경우 배경색을 파랑으로 변경
			else if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "수입")
			{
				e.CellStyle.BackColor = Color.AliceBlue;
				e.CellStyle.ForeColor = Color.Black;
			}
		}

		private void comboBoxAccount_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			string Connect = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
			string searchtext = textBoxSearch.Text.Trim();
	
			string field = "";
			string flagYN = "";
		
			string Query3 = "";

		

			Query3 = "select * from dawoon.dc_items where subject like '" + "%" + searchtext + "%" + "' AND flagYN = 'Y'";


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

		private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			buttonSearch_Click(sender, e);
		}
	}
}

