namespace household_seojun
{
    partial class MoneyIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoneyIn));
            this.lbDate = new System.Windows.Forms.Label();
            this.lbMoneyIn = new System.Windows.Forms.Label();
            this.lbCg = new System.Windows.Forms.Label();
            this.lbMemo = new System.Windows.Forms.Label();
            this.tbMoneyIn = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Location = new System.Drawing.Point(25, 28);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(29, 12);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "날짜";
            // 
            // lbMoneyIn
            // 
            this.lbMoneyIn.AutoSize = true;
            this.lbMoneyIn.BackColor = System.Drawing.Color.Transparent;
            this.lbMoneyIn.Location = new System.Drawing.Point(25, 70);
            this.lbMoneyIn.Name = "lbMoneyIn";
            this.lbMoneyIn.Size = new System.Drawing.Size(41, 12);
            this.lbMoneyIn.TabIndex = 1;
            this.lbMoneyIn.Text = "입금액";
            // 
            // lbCg
            // 
            this.lbCg.AutoSize = true;
            this.lbCg.BackColor = System.Drawing.Color.Transparent;
            this.lbCg.Location = new System.Drawing.Point(25, 111);
            this.lbCg.Name = "lbCg";
            this.lbCg.Size = new System.Drawing.Size(29, 12);
            this.lbCg.TabIndex = 2;
            this.lbCg.Text = "분류";
            // 
            // lbMemo
            // 
            this.lbMemo.AutoSize = true;
            this.lbMemo.BackColor = System.Drawing.Color.Transparent;
            this.lbMemo.Location = new System.Drawing.Point(25, 154);
            this.lbMemo.Name = "lbMemo";
            this.lbMemo.Size = new System.Drawing.Size(29, 12);
            this.lbMemo.TabIndex = 3;
            this.lbMemo.Text = "비고";
            // 
            // tbMoneyIn
            // 
            this.tbMoneyIn.Location = new System.Drawing.Point(85, 67);
            this.tbMoneyIn.Name = "tbMoneyIn";
            this.tbMoneyIn.Size = new System.Drawing.Size(200, 21);
            this.tbMoneyIn.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // tbMemo
            // 
            this.tbMemo.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.tbMemo.Location = new System.Drawing.Point(85, 154);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(200, 73);
            this.tbMemo.TabIndex = 7;
            // 
            // btOk
            // 
            this.btOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOk.BackgroundImage")));
            this.btOk.Location = new System.Drawing.Point(85, 248);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(200, 34);
            this.btOk.TabIndex = 8;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // cbtype
            // 
            this.cbtype.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Location = new System.Drawing.Point(85, 108);
            this.cbtype.Margin = new System.Windows.Forms.Padding(2);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(200, 20);
            this.cbtype.TabIndex = 9;
            // 
            // MoneyIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(312, 312);
            this.Controls.Add(this.cbtype);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbMemo);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tbMoneyIn);
            this.Controls.Add(this.lbMemo);
            this.Controls.Add(this.lbCg);
            this.Controls.Add(this.lbMoneyIn);
            this.Controls.Add(this.lbDate);
            this.Name = "MoneyIn";
            this.Text = "MoneyIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbMoneyIn;
        private System.Windows.Forms.Label lbCg;
        private System.Windows.Forms.Label lbMemo;
        private System.Windows.Forms.Button btOk;
        public System.Windows.Forms.TextBox tbMemo;
        public System.Windows.Forms.TextBox tbMoneyIn;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ComboBox cbtype;
    }
}