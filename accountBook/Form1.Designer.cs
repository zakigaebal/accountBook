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
            this.components = new System.ComponentModel.Container();
            this.labelDate = new System.Windows.Forms.Label();
            this.richTextBoxWhy = new System.Windows.Forms.RichTextBox();
            this.labelWhy = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelSpend = new System.Windows.Forms.Label();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkBoxDelShow = new System.Windows.Forms.CheckBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
            this.comboBoxContents = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMoney = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonForm2 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dateTimePickerCalender = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(17, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(59, 12);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "수입/지출";
            // 
            // richTextBoxWhy
            // 
            this.richTextBoxWhy.Location = new System.Drawing.Point(19, 114);
            this.richTextBoxWhy.Name = "richTextBoxWhy";
            this.richTextBoxWhy.Size = new System.Drawing.Size(300, 178);
            this.richTextBoxWhy.TabIndex = 4;
            this.richTextBoxWhy.Text = "";
            // 
            // labelWhy
            // 
            this.labelWhy.AutoSize = true;
            this.labelWhy.Location = new System.Drawing.Point(17, 99);
            this.labelWhy.Name = "labelWhy";
            this.labelWhy.Size = new System.Drawing.Size(29, 12);
            this.labelWhy.TabIndex = 5;
            this.labelWhy.Text = "메모";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(14, 314);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 69);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "저장";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(113, 314);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(99, 69);
            this.buttonDel.TabIndex = 7;
            this.buttonDel.Text = "삭제";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(218, 314);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(101, 69);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "수정";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(358, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(656, 325);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // labelSpend
            // 
            this.labelSpend.AutoSize = true;
            this.labelSpend.Location = new System.Drawing.Point(17, 59);
            this.labelSpend.Name = "labelSpend";
            this.labelSpend.Size = new System.Drawing.Size(87, 12);
            this.labelSpend.TabIndex = 3;
            this.labelSpend.Text = "수입/지출 내용";
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "금액",
            "메모"});
            this.comboBoxSearch.Location = new System.Drawing.Point(613, 7);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(94, 20);
            this.comboBoxSearch.TabIndex = 10;
            this.comboBoxSearch.Text = "금액";
            this.comboBoxSearch.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearch_SelectedIndexChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(713, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(144, 21);
            this.textBoxSearch.TabIndex = 11;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(863, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(66, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "검색";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // checkBoxDelShow
            // 
            this.checkBoxDelShow.AutoSize = true;
            this.checkBoxDelShow.Location = new System.Drawing.Point(358, 4);
            this.checkBoxDelShow.Name = "checkBoxDelShow";
            this.checkBoxDelShow.Size = new System.Drawing.Size(76, 16);
            this.checkBoxDelShow.TabIndex = 13;
            this.checkBoxDelShow.Text = "삭제 보기";
            this.checkBoxDelShow.UseVisualStyleBackColor = true;
            this.checkBoxDelShow.CheckedChanged += new System.EventHandler(this.checkBoxDelShow_CheckedChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(935, 0);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(79, 54);
            this.buttonLogin.TabIndex = 14;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Items.AddRange(new object[] {
            "수입",
            "지출"});
            this.comboBoxInOut.Location = new System.Drawing.Point(19, 34);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(57, 20);
            this.comboBoxInOut.TabIndex = 19;
            this.comboBoxInOut.Text = "수입";
            this.comboBoxInOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxInOut_SelectedIndexChanged);
            // 
            // comboBoxContents
            // 
            this.comboBoxContents.FormattingEnabled = true;
            this.comboBoxContents.Items.AddRange(new object[] {
            "월급",
            "이자",
            "보너스",
            "점심식대",
            "저녁식대"});
            this.comboBoxContents.Location = new System.Drawing.Point(19, 76);
            this.comboBoxContents.Name = "comboBoxContents";
            this.comboBoxContents.Size = new System.Drawing.Size(57, 20);
            this.comboBoxContents.TabIndex = 20;
            this.comboBoxContents.Text = "월급";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "날짜";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "금액";
            // 
            // textBoxMoney
            // 
            this.textBoxMoney.Location = new System.Drawing.Point(133, 27);
            this.textBoxMoney.Name = "textBoxMoney";
            this.textBoxMoney.Size = new System.Drawing.Size(186, 21);
            this.textBoxMoney.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerCalender);
            this.panel1.Controls.Add(this.buttonForm2);
            this.panel1.Controls.Add(this.labelDate);
            this.panel1.Controls.Add(this.textBoxMoney);
            this.panel1.Controls.Add(this.labelSpend);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.richTextBoxWhy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelWhy);
            this.panel1.Controls.Add(this.comboBoxContents);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.comboBoxInOut);
            this.panel1.Controls.Add(this.buttonDel);
            this.panel1.Controls.Add(this.buttonUpdate);
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 386);
            this.panel1.TabIndex = 25;
            // 
            // buttonForm2
            // 
            this.buttonForm2.Location = new System.Drawing.Point(82, 76);
            this.buttonForm2.Name = "buttonForm2";
            this.buttonForm2.Size = new System.Drawing.Size(45, 20);
            this.buttonForm2.TabIndex = 25;
            this.buttonForm2.Text = "...";
            this.buttonForm2.UseVisualStyleBackColor = true;
            this.buttonForm2.Click += new System.EventHandler(this.buttonForm2_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // dateTimePickerCalender
            // 
            this.dateTimePickerCalender.Location = new System.Drawing.Point(133, 76);
            this.dateTimePickerCalender.Name = "dateTimePickerCalender";
            this.dateTimePickerCalender.Size = new System.Drawing.Size(186, 21);
            this.dateTimePickerCalender.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 397);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.checkBoxDelShow);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxSearch);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "가계부";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.RichTextBox richTextBoxWhy;
        private System.Windows.Forms.Label labelWhy;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelSpend;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckBox checkBoxDelShow;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ComboBox comboBoxInOut;
        private System.Windows.Forms.ComboBox comboBoxContents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMoney;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonForm2;
        private System.Windows.Forms.DateTimePicker dateTimePickerCalender;
    }
}

