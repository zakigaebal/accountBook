namespace accountBook
{
    partial class Login
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonlogin = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "이름(&I)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(8, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "암호(&P)";
			// 
			// textBoxName
			// 
			this.textBoxName.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBoxName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
			this.textBoxName.Location = new System.Drawing.Point(12, 37);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(295, 43);
			this.textBoxName.TabIndex = 2;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.textBoxPassword.Location = new System.Drawing.Point(12, 120);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(295, 43);
			this.textBoxPassword.TabIndex = 4;
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
			// 
			// buttonlogin
			// 
			this.buttonlogin.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonlogin.Location = new System.Drawing.Point(0, 183);
			this.buttonlogin.Name = "buttonlogin";
			this.buttonlogin.Size = new System.Drawing.Size(323, 60);
			this.buttonlogin.TabIndex = 0;
			this.buttonlogin.Text = "확인(&C)";
			this.buttonlogin.UseVisualStyleBackColor = true;
			this.buttonlogin.Click += new System.EventHandler(this.buttonlogin_Click);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(323, 243);
			this.Controls.Add(this.buttonlogin);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "로그인";
			this.Load += new System.EventHandler(this.Login_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonlogin;
    }
}