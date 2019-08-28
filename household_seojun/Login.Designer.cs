namespace household_seojun
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
            this.userNameTb = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.uesrPw = new System.Windows.Forms.Label();
            this.uesrPwTb = new System.Windows.Forms.TextBox();
            this.loginOk = new System.Windows.Forms.Button();
            this.joinlink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // userNameTb
            // 
            this.userNameTb.Location = new System.Drawing.Point(101, 18);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.Size = new System.Drawing.Size(150, 21);
            this.userNameTb.TabIndex = 1;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userName.Location = new System.Drawing.Point(43, 21);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(34, 17);
            this.userName.TabIndex = 2;
            this.userName.Text = "이름";
            // 
            // uesrPw
            // 
            this.uesrPw.AutoSize = true;
            this.uesrPw.BackColor = System.Drawing.Color.Transparent;
            this.uesrPw.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uesrPw.Location = new System.Drawing.Point(32, 63);
            this.uesrPw.Name = "uesrPw";
            this.uesrPw.Size = new System.Drawing.Size(60, 17);
            this.uesrPw.TabIndex = 4;
            this.uesrPw.Text = "비밀번호";
            // 
            // uesrPwTb
            // 
            this.uesrPwTb.Location = new System.Drawing.Point(101, 60);
            this.uesrPwTb.Name = "uesrPwTb";
            this.uesrPwTb.PasswordChar = '*';
            this.uesrPwTb.Size = new System.Drawing.Size(150, 21);
            this.uesrPwTb.TabIndex = 3;
            this.uesrPwTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UesrPwTb_KeyDown);
            // 
            // loginOk
            // 
            this.loginOk.Image = ((System.Drawing.Image)(resources.GetObject("loginOk.Image")));
            this.loginOk.Location = new System.Drawing.Point(101, 106);
            this.loginOk.Name = "loginOk";
            this.loginOk.Size = new System.Drawing.Size(75, 23);
            this.loginOk.TabIndex = 5;
            this.loginOk.UseVisualStyleBackColor = true;
            this.loginOk.Click += new System.EventHandler(this.LoginOk_Click);
            // 
            // joinlink
            // 
            this.joinlink.AutoSize = true;
            this.joinlink.BackColor = System.Drawing.Color.Transparent;
            this.joinlink.Location = new System.Drawing.Point(211, 120);
            this.joinlink.Name = "joinlink";
            this.joinlink.Size = new System.Drawing.Size(53, 12);
            this.joinlink.TabIndex = 6;
            this.joinlink.TabStop = true;
            this.joinlink.Text = "회원가입";
            this.joinlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.joinlink_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.joinlink);
            this.Controls.Add(this.loginOk);
            this.Controls.Add(this.uesrPw);
            this.Controls.Add(this.uesrPwTb);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userNameTb);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTb;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label uesrPw;
        private System.Windows.Forms.TextBox uesrPwTb;
        private System.Windows.Forms.Button loginOk;
        private System.Windows.Forms.LinkLabel joinlink;
    }
}