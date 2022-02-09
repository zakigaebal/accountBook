namespace accountBook
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.buttonSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.comboBoxAccount = new System.Windows.Forms.ComboBox();
			this.textBoxSubject = new System.Windows.Forms.TextBox();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSave
			// 
			this.buttonSave.BackColor = System.Drawing.Color.PaleGreen;
			this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSave.FlatAppearance.BorderSize = 2;
			this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSave.Location = new System.Drawing.Point(237, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(214, 62);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "저장";
			this.buttonSave.UseVisualStyleBackColor = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
			this.label1.Location = new System.Drawing.Point(58, 151);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "항목을 추가해주세요";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
			this.label2.Location = new System.Drawing.Point(38, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "지출이나 수입을 선택하세요";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 4);
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 218);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(448, 166);
			this.dataGridView1.TabIndex = 10;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// comboBoxAccount
			// 
			this.comboBoxAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxAccount, 3);
			this.comboBoxAccount.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.comboBoxAccount.FormattingEnabled = true;
			this.comboBoxAccount.Items.AddRange(new object[] {
            "지출",
            "수입"});
			this.comboBoxAccount.Location = new System.Drawing.Point(11, 87);
			this.comboBoxAccount.Name = "comboBoxAccount";
			this.comboBoxAccount.Size = new System.Drawing.Size(211, 33);
			this.comboBoxAccount.TabIndex = 7;
			this.comboBoxAccount.Text = "지출";
			this.comboBoxAccount.SelectedIndexChanged += new System.EventHandler(this.comboBoxInOut_SelectedIndexChanged);
			// 
			// textBoxSubject
			// 
			this.textBoxSubject.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxSubject, 3);
			this.textBoxSubject.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBoxSubject.Location = new System.Drawing.Point(11, 178);
			this.textBoxSubject.Name = "textBoxSubject";
			this.textBoxSubject.Size = new System.Drawing.Size(211, 33);
			this.textBoxSubject.TabIndex = 11;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.BackColor = System.Drawing.Color.LightBlue;
			this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonUpdate.FlatAppearance.BorderSize = 2;
			this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonUpdate.Location = new System.Drawing.Point(237, 142);
			this.buttonUpdate.Name = "buttonUpdate";
			this.tableLayoutPanel1.SetRowSpan(this.buttonUpdate, 2);
			this.buttonUpdate.Size = new System.Drawing.Size(214, 70);
			this.buttonUpdate.TabIndex = 12;
			this.buttonUpdate.Text = "수정";
			this.buttonUpdate.UseVisualStyleBackColor = false;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.BackColor = System.Drawing.Color.LightPink;
			this.buttonDel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonDel.FlatAppearance.BorderSize = 2;
			this.buttonDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDel.Location = new System.Drawing.Point(237, 71);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(214, 65);
			this.buttonDel.TabIndex = 12;
			this.buttonDel.Text = "삭제";
			this.buttonDel.UseVisualStyleBackColor = false;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.52831F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.4717F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonDel, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonSave, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.buttonUpdate, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxSubject, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxAccount, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.97959F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.02041F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 387);
			this.tableLayoutPanel1.TabIndex = 13;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 387);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "아이템입력";
			this.Load += new System.EventHandler(this.Form2_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxAccount;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}