namespace NoticeForm
{
    partial class frmBoard
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoard));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtday = new System.Windows.Forms.TextBox();
            this.btns = new System.Windows.Forms.Button();
            this.btne = new System.Windows.Forms.Button();
            this.cbbMonth = new System.Windows.Forms.ComboBox();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.listSelection = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtGapTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBirth = new System.Windows.Forms.TextBox();
            this.txtM1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtM2 = new System.Windows.Forms.TextBox();
            this.txtM3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(14, 149);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(563, 331);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "예약알림";
            this.notifyIcon1.BalloonTipTitle = "예약알림";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // txtday
            // 
            this.txtday.Location = new System.Drawing.Point(151, 18);
            this.txtday.Name = "txtday";
            this.txtday.Size = new System.Drawing.Size(47, 21);
            this.txtday.TabIndex = 1;
            // 
            // btns
            // 
            this.btns.Location = new System.Drawing.Point(419, 20);
            this.btns.Name = "btns";
            this.btns.Size = new System.Drawing.Size(75, 23);
            this.btns.TabIndex = 2;
            this.btns.Text = "시작";
            this.btns.UseVisualStyleBackColor = true;
            this.btns.Click += new System.EventHandler(this.btns_Click);
            // 
            // btne
            // 
            this.btne.Location = new System.Drawing.Point(500, 19);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(75, 23);
            this.btne.TabIndex = 3;
            this.btne.Text = "중지";
            this.btne.UseVisualStyleBackColor = true;
            this.btne.Click += new System.EventHandler(this.btne_Click);
            // 
            // cbbMonth
            // 
            this.cbbMonth.FormattingEnabled = true;
            this.cbbMonth.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cbbMonth.Location = new System.Drawing.Point(104, 19);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Size = new System.Drawing.Size(41, 20);
            this.cbbMonth.TabIndex = 4;
            // 
            // cbSite
            // 
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Items.AddRange(new object[] {
            "전체",
            "1구역",
            "2구역",
            "3구역",
            "4구역",
            "통나무"});
            this.cbSite.Location = new System.Drawing.Point(14, 20);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(84, 20);
            this.cbSite.TabIndex = 5;
            // 
            // listSelection
            // 
            this.listSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSelection.FormattingEnabled = true;
            this.listSelection.ItemHeight = 12;
            this.listSelection.Location = new System.Drawing.Point(14, 55);
            this.listSelection.Name = "listSelection";
            this.listSelection.Size = new System.Drawing.Size(561, 88);
            this.listSelection.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(204, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(272, 20);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(62, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtGapTime
            // 
            this.txtGapTime.Location = new System.Drawing.Point(340, 22);
            this.txtGapTime.Name = "txtGapTime";
            this.txtGapTime.Size = new System.Drawing.Size(36, 21);
            this.txtGapTime.TabIndex = 7;
            this.txtGapTime.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "초";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(64, 21);
            this.txtName.TabIndex = 9;
            this.txtName.Text = "박종식";
            this.txtName.Visible = false;
            // 
            // txtBirth
            // 
            this.txtBirth.Location = new System.Drawing.Point(162, 11);
            this.txtBirth.Name = "txtBirth";
            this.txtBirth.Size = new System.Drawing.Size(80, 21);
            this.txtBirth.TabIndex = 9;
            this.txtBirth.Text = "791225";
            this.txtBirth.Visible = false;
            // 
            // txtM1
            // 
            this.txtM1.Location = new System.Drawing.Point(305, 12);
            this.txtM1.Name = "txtM1";
            this.txtM1.Size = new System.Drawing.Size(44, 21);
            this.txtM1.TabIndex = 9;
            this.txtM1.Text = "010";
            this.txtM1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "전번";
            this.label2.Visible = false;
            // 
            // txtM2
            // 
            this.txtM2.Location = new System.Drawing.Point(355, 12);
            this.txtM2.Name = "txtM2";
            this.txtM2.Size = new System.Drawing.Size(44, 21);
            this.txtM2.TabIndex = 9;
            this.txtM2.Text = "7238";
            this.txtM2.Visible = false;
            // 
            // txtM3
            // 
            this.txtM3.Location = new System.Drawing.Point(405, 12);
            this.txtM3.Name = "txtM3";
            this.txtM3.Size = new System.Drawing.Size(44, 21);
            this.txtM3.TabIndex = 9;
            this.txtM3.Text = "2515";
            this.txtM3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "이름";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "생일";
            this.label4.Visible = false;
            // 
            // frmBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 492);
            this.Controls.Add(this.txtM3);
            this.Controls.Add(this.txtM2);
            this.Controls.Add(this.txtM1);
            this.Controls.Add(this.txtBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGapTime);
            this.Controls.Add(this.listSelection);
            this.Controls.Add(this.cbSite);
            this.Controls.Add(this.cbbMonth);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btns);
            this.Controls.Add(this.txtday);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBoard";
            this.Text = "알림";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtday;
        private System.Windows.Forms.Button btns;
        private System.Windows.Forms.Button btne;
        private System.Windows.Forms.ComboBox cbbMonth;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.ListBox listSelection;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtGapTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBirth;
        private System.Windows.Forms.TextBox txtM1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtM2;
        private System.Windows.Forms.TextBox txtM3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

