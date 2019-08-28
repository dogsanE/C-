namespace household_seojun
{
    partial class Join
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Join));
            this.uesrPw = new System.Windows.Forms.Label();
            this.j_pw = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.j_name = new System.Windows.Forms.TextBox();
            this.joinOk = new System.Windows.Forms.Button();
            this.joinlb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uesrPw
            // 
            this.uesrPw.AutoSize = true;
            this.uesrPw.BackColor = System.Drawing.Color.Transparent;
            this.uesrPw.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uesrPw.Location = new System.Drawing.Point(16, 117);
            this.uesrPw.Name = "uesrPw";
            this.uesrPw.Size = new System.Drawing.Size(60, 17);
            this.uesrPw.TabIndex = 10;
            this.uesrPw.Text = "비밀번호";
            // 
            // j_pw
            // 
            this.j_pw.Location = new System.Drawing.Point(85, 114);
            this.j_pw.Name = "j_pw";
            this.j_pw.Size = new System.Drawing.Size(150, 21);
            this.j_pw.TabIndex = 9;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userName.Location = new System.Drawing.Point(27, 75);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(34, 17);
            this.userName.TabIndex = 8;
            this.userName.Text = "이름";
            // 
            // j_name
            // 
            this.j_name.Location = new System.Drawing.Point(85, 72);
            this.j_name.Name = "j_name";
            this.j_name.Size = new System.Drawing.Size(150, 21);
            this.j_name.TabIndex = 7;
            // 
            // joinOk
            // 
            this.joinOk.Image = ((System.Drawing.Image)(resources.GetObject("joinOk.Image")));
            this.joinOk.Location = new System.Drawing.Point(85, 157);
            this.joinOk.Name = "joinOk";
            this.joinOk.Size = new System.Drawing.Size(75, 23);
            this.joinOk.TabIndex = 11;
            this.joinOk.UseVisualStyleBackColor = true;
            this.joinOk.Click += new System.EventHandler(this.joinOk_Click);
            // 
            // joinlb
            // 
            this.joinlb.AutoSize = true;
            this.joinlb.BackColor = System.Drawing.Color.Transparent;
            this.joinlb.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.joinlb.Location = new System.Drawing.Point(78, 13);
            this.joinlb.Name = "joinlb";
            this.joinlb.Size = new System.Drawing.Size(97, 30);
            this.joinlb.TabIndex = 12;
            this.joinlb.Text = "회원가입";
            // 
            // Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(258, 199);
            this.Controls.Add(this.joinlb);
            this.Controls.Add(this.joinOk);
            this.Controls.Add(this.uesrPw);
            this.Controls.Add(this.j_pw);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.j_name);
            this.Name = "Join";
            this.Text = "Join";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Join_FormClosed);
            this.Load += new System.EventHandler(this.Join_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button joinOk;
        private System.Windows.Forms.Label uesrPw;
        private System.Windows.Forms.TextBox j_pw;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.TextBox j_name;
        private System.Windows.Forms.Label joinlb;
    }
}