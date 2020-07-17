using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoticeForm
{
    public partial class frmWebBrowser : Form
    {
        public string URL { get; set; }
        public string SiteDate { get; set; }

        #region 생성자

        public frmWebBrowser()
        {
            InitializeComponent();

            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        public frmWebBrowser(string url, string siteDate) : this()
        {
            URL = url;
            SiteDate = siteDate;
        }

        #endregion

        #region OVERRIDE

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            webBrowser.Navigate(URL);
        }

        #endregion

        #region EVENT

        private int _documentCompletedCount = 0;
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Console.WriteLine("==> WebBrowser_DocumentCompleted <== ");
            AutoDateClick();
        }

        private void AutoDateClick()
        {
            _documentCompletedCount++;

            Console.WriteLine("_documentCompletedCount : {0} ", _documentCompletedCount);

            var doc = webBrowser.Document;

            var buttons = doc.GetElementsByTagName("button");

            if (_documentCompletedCount == 1)
            {
                string siteAndDate = SiteDate; // "A:2020-07-20";

                foreach (HtmlElement button in buttons)
                {
                    if (button.GetAttribute("value").Equals(siteAndDate))
                    {
                        Console.WriteLine("Click : {0} ", siteAndDate);
                        button.InvokeMember("click");
                    }
                }
            }
            else if (_documentCompletedCount == 2)
            {
                // button
                foreach (HtmlElement button in buttons)
                {
                    if (button.OuterHtml.Contains(" on\""))
                    {
                        Console.WriteLine("Click : {0} ", button.ToString());
                        button.InvokeMember("click");
                    }
                }

                // select 
                var selects = doc.GetElementsByTagName("select");

                foreach (HtmlElement select in selects)
                {
                    if (select.InnerHtml.Contains("인원선택"))
                    {
                        Console.WriteLine("select : {0} ", select.ToString());
                        select.SetAttribute("value", "4");
                    }
                }
                
                // 다음
                foreach (HtmlElement button in buttons)
                {
                    if (button.InnerText.StartsWith("다음"))
                    {
                        Console.WriteLine("Click : {0} ", button.ToString());
                        button.InvokeMember("click");
                    }
                }
            }

        }

        #endregion
    }
}
