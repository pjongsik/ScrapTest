namespace NoticeForm
{
    partial class SongJiHoForm
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.txtMobile3 = new System.Windows.Forms.TextBox();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbSleepDay = new System.Windows.Forms.ComboBox();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.cbDay = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, -2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1163, 777);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(858, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "날짜선택";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "--------------------------------------------------------------------";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(581, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "해당월로";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(743, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "자리선택";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(662, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "정보입력";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(743, 55);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "카드결제";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtBirthday);
            this.panel1.Controls.Add(this.txtMobile3);
            this.panel1.Controls.Add(this.txtMobile2);
            this.panel1.Controls.Add(this.txtMobile1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbMonth);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbSleepDay);
            this.panel1.Controls.Add(this.cbSite);
            this.panel1.Controls.Add(this.cbDay);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 112);
            this.panel1.TabIndex = 9;
            // 
            // txtBirthday
            // 
            this.txtBirthday.Font = new System.Drawing.Font("굴림", 10F);
            this.txtBirthday.Location = new System.Drawing.Point(91, 79);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(69, 23);
            this.txtBirthday.TabIndex = 11;
            this.txtBirthday.Text = "791225";
            // 
            // txtMobile3
            // 
            this.txtMobile3.Font = new System.Drawing.Font("굴림", 10F);
            this.txtMobile3.Location = new System.Drawing.Point(185, 52);
            this.txtMobile3.Name = "txtMobile3";
            this.txtMobile3.Size = new System.Drawing.Size(43, 23);
            this.txtMobile3.TabIndex = 11;
            this.txtMobile3.Text = "2515";
            // 
            // txtMobile2
            // 
            this.txtMobile2.Font = new System.Drawing.Font("굴림", 10F);
            this.txtMobile2.Location = new System.Drawing.Point(133, 52);
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(46, 23);
            this.txtMobile2.TabIndex = 11;
            this.txtMobile2.Text = "7238";
            // 
            // txtMobile1
            // 
            this.txtMobile1.Font = new System.Drawing.Font("굴림", 10F);
            this.txtMobile1.Location = new System.Drawing.Point(91, 52);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(36, 23);
            this.txtMobile1.TabIndex = 11;
            this.txtMobile1.Text = "010";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("굴림", 10F);
            this.txtName.Location = new System.Drawing.Point(91, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(69, 23);
            this.txtName.TabIndex = 11;
            this.txtName.Text = "박종식";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(500, 27);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 56);
            this.button7.TabIndex = 10;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 14F);
            this.label7.Location = new System.Drawing.Point(41, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "생일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14F);
            this.label6.Location = new System.Drawing.Point(41, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "전번";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14F);
            this.label5.Location = new System.Drawing.Point(41, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14F);
            this.label3.Location = new System.Drawing.Point(277, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "월";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14F);
            this.label4.Location = new System.Drawing.Point(459, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "박";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14F);
            this.label2.Location = new System.Drawing.Point(368, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "일";
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbMonth.Location = new System.Drawing.Point(226, 24);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(45, 20);
            this.cbMonth.TabIndex = 8;
            // 
            // cbSleepDay
            // 
            this.cbSleepDay.FormattingEnabled = true;
            this.cbSleepDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbSleepDay.Location = new System.Drawing.Point(402, 25);
            this.cbSleepDay.Name = "cbSleepDay";
            this.cbSleepDay.Size = new System.Drawing.Size(51, 20);
            this.cbSleepDay.TabIndex = 8;
            // 
            // cbSite
            // 
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "통나무집"});
            this.cbSite.Location = new System.Drawing.Point(393, 63);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(83, 20);
            this.cbSite.TabIndex = 8;
            // 
            // cbDay
            // 
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Location = new System.Drawing.Point(311, 25);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new System.Drawing.Size(51, 20);
            this.cbDay.TabIndex = 8;
            // 
            // SongJiHoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 773);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "SongJiHoForm";
            this.Text = "SongJiHoForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.TextBox txtMobile3;
        private System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.TextBox txtMobile1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbSleepDay;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.ComboBox cbDay;
    }
}