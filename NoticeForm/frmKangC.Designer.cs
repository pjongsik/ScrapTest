namespace NoticeForm
{
    partial class frmKangC
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
            this.cbbMonth = new System.Windows.Forms.ComboBox();
            this.btne = new System.Windows.Forms.Button();
            this.btns = new System.Windows.Forms.Button();
            this.txtday = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cbbMonth
            // 
            this.cbbMonth.FormattingEnabled = true;
            this.cbbMonth.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cbbMonth.Location = new System.Drawing.Point(12, 12);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Size = new System.Drawing.Size(41, 20);
            this.cbbMonth.TabIndex = 8;
            // 
            // btne
            // 
            this.btne.Location = new System.Drawing.Point(247, 10);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(75, 23);
            this.btne.TabIndex = 7;
            this.btne.Text = "종료";
            this.btne.UseVisualStyleBackColor = true;
            this.btne.Click += new System.EventHandler(this.btne_Click);
            // 
            // btns
            // 
            this.btns.Location = new System.Drawing.Point(166, 10);
            this.btns.Name = "btns";
            this.btns.Size = new System.Drawing.Size(75, 23);
            this.btns.TabIndex = 6;
            this.btns.Text = "시작";
            this.btns.UseVisualStyleBackColor = true;
            this.btns.Click += new System.EventHandler(this.btns_Click);
            // 
            // txtday
            // 
            this.txtday.Location = new System.Drawing.Point(60, 12);
            this.txtday.Name = "txtday";
            this.txtday.Size = new System.Drawing.Size(100, 21);
            this.txtday.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(404, 266);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // frmKangC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 333);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cbbMonth);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btns);
            this.Controls.Add(this.txtday);
            this.Name = "frmKangC";
            this.Text = "강씨봉";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbMonth;
        private System.Windows.Forms.Button btne;
        private System.Windows.Forms.Button btns;
        private System.Windows.Forms.TextBox txtday;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}