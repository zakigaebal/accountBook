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
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxMoney = new System.Windows.Forms.TextBox();
            this.labelItemInput = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.labelCalender = new System.Windows.Forms.Label();
            this.dateTimePickerCalender = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(209, 364);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(105, 89);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "종료";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxMoney
            // 
            this.textBoxMoney.Location = new System.Drawing.Point(76, 145);
            this.textBoxMoney.Name = "textBoxMoney";
            this.textBoxMoney.Size = new System.Drawing.Size(121, 21);
            this.textBoxMoney.TabIndex = 1;
            // 
            // labelItemInput
            // 
            this.labelItemInput.AutoSize = true;
            this.labelItemInput.Location = new System.Drawing.Point(74, 120);
            this.labelItemInput.Name = "labelItemInput";
            this.labelItemInput.Size = new System.Drawing.Size(29, 12);
            this.labelItemInput.TabIndex = 2;
            this.labelItemInput.Text = "금액";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(0, 364);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 89);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "저장";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "콤보박스내용Name";
            // 
            // comboBoxName
            // 
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(76, 85);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxName.TabIndex = 5;
            this.comboBoxName.Text = "월급";
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Items.AddRange(new object[] {
            "수입",
            "지출"});
            this.comboBoxInOut.Location = new System.Drawing.Point(76, 35);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(121, 20);
            this.comboBoxInOut.TabIndex = 7;
            this.comboBoxInOut.Text = "수입";
            this.comboBoxInOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxInOut_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "userInOut";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "비고";
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(76, 203);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(121, 21);
            this.textBoxMemo.TabIndex = 8;
            // 
            // labelCalender
            // 
            this.labelCalender.AutoSize = true;
            this.labelCalender.Location = new System.Drawing.Point(74, 236);
            this.labelCalender.Name = "labelCalender";
            this.labelCalender.Size = new System.Drawing.Size(29, 12);
            this.labelCalender.TabIndex = 10;
            this.labelCalender.Text = "달력";
            // 
            // dateTimePickerCalender
            // 
            this.dateTimePickerCalender.Location = new System.Drawing.Point(76, 263);
            this.dateTimePickerCalender.Name = "dateTimePickerCalender";
            this.dateTimePickerCalender.Size = new System.Drawing.Size(169, 21);
            this.dateTimePickerCalender.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 450);
            this.Controls.Add(this.dateTimePickerCalender);
            this.Controls.Add(this.labelCalender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.comboBoxInOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelItemInput);
            this.Controls.Add(this.textBoxMoney);
            this.Controls.Add(this.buttonClose);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxMoney;
        private System.Windows.Forms.Label labelItemInput;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.ComboBox comboBoxInOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label labelCalender;
        private System.Windows.Forms.DateTimePicker dateTimePickerCalender;
    }
}