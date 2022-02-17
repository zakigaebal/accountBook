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
	public partial class Report : Form
	{
		public Report(DateTime sd,DateTime ed)
		{
			InitializeComponent();
			this.KeyDown += Report_KeyDown;
			 

		
		}


		private DataTable getData()
		{
			DataTable dt = new DataTable();
			string connStr = "datasource=127.0.0.1;port=3306;database=dawoon;username=root;password=ekdnsel;Charset=utf8";
			using (MySqlConnection conn = new MySqlConnection(connStr))
			{
				string sql = "SELECT * FROM Tab1 WHERE Id>=2";
				MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
				adpt.Fill(dt);
			}
			return dt;
		}

		private void Report_KeyDown(object sender, KeyEventArgs e)
		{
		if(e.KeyCode == Keys.Escape) this.Close();
		}

		private void Report_Load(object sender, EventArgs e)
		{
			reportViewer1.Reset();
			

			this.reportViewer1.RefreshReport();
	
		}
	}
}
