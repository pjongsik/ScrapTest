using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoticeForm
{
    public partial class frmNotice : Form
    {
        string _uri = null;
        string _message = null;
        public frmNotice(string uri = null, string message = null)
        {
            InitializeComponent();

            _uri = uri;
            _message = message;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            DisplayText();
        }

        private void DisplayText()
        {
            lbText.Text = _message == null ? "" : _message;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_uri);
            this.Close();
        }
    }
}
