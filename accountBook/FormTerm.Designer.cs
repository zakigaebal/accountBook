namespace accountBook
{
    partial class FormTerm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pDate = new System.Windows.Forms.DateTimePicker();
            this.labelTerm = new System.Windows.Forms.Label();
            this.buttonTermSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(167, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(198, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 29);
            this.dateTimePicker1.TabIndex = 19;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // pDate
            // 
            this.pDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pDate.CustomFormat = "yyyy-MM-01";
            this.pDate.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pDate.Location = new System.Drawing.Point(27, 30);
            this.pDate.Name = "pDate";
            this.pDate.Size = new System.Drawing.Size(134, 29);
            this.pDate.TabIndex = 20;
            this.pDate.Value = new System.DateTime(2022, 1, 28, 0, 0, 0, 0);
            this.pDate.ValueChanged += new System.EventHandler(this.pDate_ValueChanged);
            // 
            // labelTerm
            // 
            this.labelTerm.AutoSize = true;
            this.labelTerm.Location = new System.Drawing.Point(12, 15);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(29, 12);
            this.labelTerm.TabIndex = 22;
            this.labelTerm.Text = "기간";
            // 
            // buttonTermSearch
            // 
            this.buttonTermSearch.Location = new System.Drawing.Point(19, 110);
            this.buttonTermSearch.Name = "buttonTermSearch";
            this.buttonTermSearch.Size = new System.Drawing.Size(309, 34);
            this.buttonTermSearch.TabIndex = 23;
            this.buttonTermSearch.Text = "검색하기";
            this.buttonTermSearch.UseVisualStyleBackColor = true;
            // 
            // FormTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 156);
            this.Controls.Add(this.buttonTermSearch);
            this.Controls.Add(this.labelTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pDate);
            this.Name = "FormTerm";
            this.Text = "FormTerm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fSelectMon_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker pDate;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.Button buttonTermSearch;
    }
}