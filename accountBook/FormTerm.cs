using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountBook
{
    public partial class FormTerm : Form
    {
        public string Mon = string.Empty;
        public FormTerm(string baseyear)
        {
            InitializeComponent();
            this.Text = baseyear + "년 조회 월 선택";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //몇월을 선택했는지?
            var tb = sender as Button;
            this.Mon = tb.Text;
            DialogResult = DialogResult.OK;
        }

        private void fSelectMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void pDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
