﻿namespace accountBook
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.checkBoxDelShow = new System.Windows.Forms.CheckBox();
			this.comboBoxSearch = new System.Windows.Forms.ComboBox();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonTerm = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.pDate = new System.Windows.Forms.DateTimePicker();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonForm2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxMoney = new System.Windows.Forms.TextBox();
			this.labelWhy = new System.Windows.Forms.Label();
			this.textBoxContent = new System.Windows.Forms.TextBox();
			this.textBoxMemo = new System.Windows.Forms.TextBox();
			this.comboBoxName = new System.Windows.Forms.ComboBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxDelShow
			// 
			this.checkBoxDelShow.AutoSize = true;
			this.checkBoxDelShow.Location = new System.Drawing.Point(466, 12);
			this.checkBoxDelShow.Name = "checkBoxDelShow";
			this.checkBoxDelShow.Size = new System.Drawing.Size(76, 16);
			this.checkBoxDelShow.TabIndex = 13;
			this.checkBoxDelShow.Text = "삭제 보기";
			this.checkBoxDelShow.UseVisualStyleBackColor = true;
			this.checkBoxDelShow.CheckedChanged += new System.EventHandler(this.checkBoxDelShow_CheckedChanged);
			// 
			// comboBoxSearch
			// 
			this.comboBoxSearch.FormattingEnabled = true;
			this.comboBoxSearch.Items.AddRange(new object[] {
            "항목",
            "내용"});
			this.comboBoxSearch.Location = new System.Drawing.Point(558, 10);
			this.comboBoxSearch.Name = "comboBoxSearch";
			this.comboBoxSearch.Size = new System.Drawing.Size(83, 20);
			this.comboBoxSearch.TabIndex = 2;
			this.comboBoxSearch.Text = "항목";
			this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged_1);
			this.comboBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxSearch_KeyPress);
			// 
			// buttonSearch
			// 
			this.buttonSearch.BackColor = System.Drawing.Color.Gold;
			this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonSearch.FlatAppearance.BorderSize = 2;
			this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSearch.Location = new System.Drawing.Point(780, 6);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(67, 28);
			this.buttonSearch.TabIndex = 4;
			this.buttonSearch.Text = "검색";
			this.buttonSearch.UseVisualStyleBackColor = false;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// textBoxSearch
			// 
			this.textBoxSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.textBoxSearch.Location = new System.Drawing.Point(647, 10);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new System.Drawing.Size(127, 21);
			this.textBoxSearch.TabIndex = 3;
			this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged_1);
			this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
			this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(152, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 23);
			this.label5.TabIndex = 24;
			this.label5.Text = "~";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonTerm
			// 
			this.buttonTerm.Location = new System.Drawing.Point(338, 4);
			this.buttonTerm.Name = "buttonTerm";
			this.buttonTerm.Size = new System.Drawing.Size(85, 33);
			this.buttonTerm.TabIndex = 19;
			this.buttonTerm.Text = "기간조회";
			this.buttonTerm.UseVisualStyleBackColor = true;
			this.buttonTerm.Click += new System.EventHandler(this.buttonTerm_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(188, 5);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(135, 29);
			this.dateTimePicker1.TabIndex = 22;
			this.dateTimePicker1.Value = new System.DateTime(2022, 2, 7, 0, 0, 0, 0);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CalendarFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dateTimePicker2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(16, 4);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(135, 29);
			this.dateTimePicker2.TabIndex = 25;
			this.dateTimePicker2.Value = new System.DateTime(2022, 2, 7, 0, 0, 0, 0);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.dateTimePicker2);
			this.panel2.Controls.Add(this.checkBoxDelShow);
			this.panel2.Controls.Add(this.dateTimePicker1);
			this.panel2.Controls.Add(this.buttonSearch);
			this.panel2.Controls.Add(this.buttonTerm);
			this.panel2.Controls.Add(this.comboBoxSearch);
			this.panel2.Controls.Add(this.textBoxSearch);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(460, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(856, 62);
			this.panel2.TabIndex = 1;
			this.panel2.Click += new System.EventHandler(this.panel2_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.64746F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.35254F));
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 383F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 525F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1319, 512);
			this.tableLayoutPanel1.TabIndex = 26;
			this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.30769F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.69231F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
			this.tableLayoutPanel2.Controls.Add(this.pDate, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.buttonLogin, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonForm2, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.textBoxMoney, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.labelWhy, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.textBoxContent, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.textBoxMemo, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.comboBoxName, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.radioButton1, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.radioButton2, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 71);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.73684F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.26316F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 199F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(451, 377);
			this.tableLayoutPanel2.TabIndex = 16;
			this.tableLayoutPanel2.Click += new System.EventHandler(this.tableLayoutPanel2_Click);
			// 
			// pDate
			// 
			this.pDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.tableLayoutPanel2.SetColumnSpan(this.pDate, 3);
			this.pDate.CustomFormat = "YYYY-MM-dd";
			this.pDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.pDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.pDate.Location = new System.Drawing.Point(69, 82);
			this.pDate.Name = "pDate";
			this.pDate.Size = new System.Drawing.Size(379, 29);
			this.pDate.TabIndex = 25;
			this.pDate.Value = new System.DateTime(2022, 2, 9, 0, 0, 0, 0);
			this.pDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pDate_KeyPress);
			this.pDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pDate_MouseDown);
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point(357, 3);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(91, 29);
			this.buttonLogin.TabIndex = 5;
			this.buttonLogin.Text = "로그인";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Visible = false;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label6.Location = new System.Drawing.Point(16, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 17);
			this.label6.TabIndex = 15;
			this.label6.Text = "계정";
			// 
			// buttonForm2
			// 
			this.buttonForm2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonForm2.FlatAppearance.BorderSize = 2;
			this.buttonForm2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonForm2.Location = new System.Drawing.Point(357, 38);
			this.buttonForm2.Name = "buttonForm2";
			this.buttonForm2.Size = new System.Drawing.Size(91, 38);
			this.buttonForm2.TabIndex = 9;
			this.buttonForm2.Text = "항목 추가";
			this.buttonForm2.UseVisualStyleBackColor = true;
			this.buttonForm2.TextChanged += new System.EventHandler(this.buttonForm2_TextChanged);
			this.buttonForm2.Click += new System.EventHandler(this.buttonForm2_Click);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.Location = new System.Drawing.Point(16, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "항목";
			this.label4.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(16, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "날짜";
			this.label1.Click += new System.EventHandler(this.label2_Click);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(16, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 17);
			this.label2.TabIndex = 12;
			this.label2.Text = "금액";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(16, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "내용";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// textBoxMoney
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.textBoxMoney, 3);
			this.textBoxMoney.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMoney.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBoxMoney.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.textBoxMoney.Location = new System.Drawing.Point(69, 115);
			this.textBoxMoney.Name = "textBoxMoney";
			this.textBoxMoney.Size = new System.Drawing.Size(379, 29);
			this.textBoxMoney.TabIndex = 1;
			this.textBoxMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxMoney.Click += new System.EventHandler(this.textBoxMoney_Click);
			this.textBoxMoney.TextChanged += new System.EventHandler(this.textBoxMoney_TextChanged);
			this.textBoxMoney.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMoney_KeyDown);
			this.textBoxMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMoney_KeyPress);
			// 
			// labelWhy
			// 
			this.labelWhy.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelWhy.AutoSize = true;
			this.labelWhy.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.labelWhy.Location = new System.Drawing.Point(16, 268);
			this.labelWhy.Name = "labelWhy";
			this.labelWhy.Size = new System.Drawing.Size(34, 17);
			this.labelWhy.TabIndex = 3;
			this.labelWhy.Text = "메모";
			// 
			// textBoxContent
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.textBoxContent, 3);
			this.textBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxContent.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBoxContent.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.textBoxContent.Location = new System.Drawing.Point(69, 147);
			this.textBoxContent.Name = "textBoxContent";
			this.textBoxContent.Size = new System.Drawing.Size(379, 29);
			this.textBoxContent.TabIndex = 2;
			this.textBoxContent.Click += new System.EventHandler(this.textBoxContent_Click);
			this.textBoxContent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBoxMemo
			// 
			this.tableLayoutPanel2.SetColumnSpan(this.textBoxMemo, 3);
			this.textBoxMemo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMemo.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.textBoxMemo.Location = new System.Drawing.Point(69, 180);
			this.textBoxMemo.Multiline = true;
			this.textBoxMemo.Name = "textBoxMemo";
			this.textBoxMemo.Size = new System.Drawing.Size(379, 194);
			this.textBoxMemo.TabIndex = 4;
			this.textBoxMemo.Click += new System.EventHandler(this.textBoxMemo_Click);
			// 
			// comboBoxName
			// 
			this.comboBoxName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel2.SetColumnSpan(this.comboBoxName, 2);
			this.comboBoxName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.comboBoxName.FormattingEnabled = true;
			this.comboBoxName.Location = new System.Drawing.Point(69, 42);
			this.comboBoxName.Name = "comboBoxName";
			this.comboBoxName.Size = new System.Drawing.Size(282, 29);
			this.comboBoxName.TabIndex = 8;
			this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
			this.comboBoxName.Click += new System.EventHandler(this.comboBoxName_Click);
			this.comboBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxName_KeyPress);
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButton1.AutoSize = true;
			this.radioButton1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.radioButton1.Location = new System.Drawing.Point(159, 5);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(60, 25);
			this.radioButton1.TabIndex = 10;
			this.radioButton1.Text = "지출";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.radioButton2.AutoSize = true;
			this.radioButton2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.radioButton2.Location = new System.Drawing.Point(69, 5);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(60, 25);
			this.radioButton2.TabIndex = 11;
			this.radioButton2.Text = "수입";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(460, 71);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(856, 438);
			this.dataGridView1.TabIndex = 9;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
			this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
			// 
			// buttonSave
			// 
			this.buttonSave.BackColor = System.Drawing.Color.White;
			this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSave.FlatAppearance.BorderSize = 2;
			this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonSave.Location = new System.Drawing.Point(3, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(144, 49);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "저장";
			this.buttonSave.UseVisualStyleBackColor = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.BackColor = System.Drawing.Color.LightPink;
			this.buttonDel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonDel.FlatAppearance.BorderSize = 2;
			this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonDel.Location = new System.Drawing.Point(153, 3);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(144, 49);
			this.buttonDel.TabIndex = 7;
			this.buttonDel.Text = "삭제";
			this.buttonDel.UseVisualStyleBackColor = false;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.BackColor = System.Drawing.Color.White;
			this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonUpdate.FlatAppearance.BorderSize = 2;
			this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonUpdate.Location = new System.Drawing.Point(303, 3);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(145, 49);
			this.buttonUpdate.TabIndex = 8;
			this.buttonUpdate.Text = "수정";
			this.buttonUpdate.UseVisualStyleBackColor = false;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Controls.Add(this.buttonUpdate, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.buttonDel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.buttonSave, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 454);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(451, 55);
			this.tableLayoutPanel3.TabIndex = 17;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(451, 62);
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1319, 578);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "매일매일 가계부";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Click += new System.EventHandler(this.Form1_Click);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.CheckBox checkBoxDelShow;
		private System.Windows.Forms.ComboBox comboBoxSearch;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonTerm;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.DateTimePicker pDate;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonForm2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxMoney;
		private System.Windows.Forms.Label labelWhy;
		private System.Windows.Forms.TextBox textBoxContent;
		private System.Windows.Forms.TextBox textBoxMemo;
		private System.Windows.Forms.ComboBox comboBoxName;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

