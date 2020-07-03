using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NoticeForm
{
    public partial class frmSHG : Form
    {
        bool _keepRunning = false;
        int _reservationPossible = 0;
        const int _showWebCount = 2;
       
        public frmSHG()
        {
            InitializeComponent();
           
            // 
            txtday.Text = DateTime.Now.AddDays(1).Day.ToString();
            

            cbbMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cbbMonth.Items.Add(i);
            }

            cbbMonth.Text = DateTime.Now.AddDays(1).Month.ToString();
            cbSite.SelectedIndex = 0;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        Thread _th1 = null;
        string _searchText = string.Empty;
        private void DoProcess()
        {
            //
            btns.Enabled = false;
            btne.Enabled = true;

            //
            _keepRunning = true;

            //
            _th1 = new Thread(DoWork);
            _th1.SetApartmentState(ApartmentState.STA);

            _th1.Start();
        }
       
        private void DoWork()
        {
            int _checkCount = 0;

            while (_keepRunning)
            {
                int gapTime = 3;

                if (int.TryParse(txtGapTime.Text, out gapTime) == false)
                    gapTime = 3;

                gapTime *= 1000;

                var monthList = _selectedList.GroupBy(x => new { x.Year, x.Month }).Select(x => new { x.Key.Year, x.Key.Month }).ToList();

                string title = "솔향기캠핑장";
                string displayMessage = "솔향기캠핑장 : {1}월 {2}일 ({0}) --  {3}";
                string message = string.Empty;

                foreach (var data in monthList)
                {
                    // 스크래핑함
                    string 검색월 = new DateTime(data.Year, data.Month, 1).ToString("yyyyMM");
                    string url = string.Format(string.Format(@"https://camping.gtdc.or.kr/DZ_reservation/reserCamping.php?xch=reservation&xid=camping_reservation&searchDate={0}", 검색월));
                    string html = ScrapTest.Scrap.Scraping(url, ScrapTest.Method.GET, "UTF-8");
                    string remainCount = string.Empty;
                    
                    if (html.IndexOf(title) <= 0)
                    {
                        // 페이지 읽기 오류
                        // 페이지 오류
                        DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));

                        message = string.Format(" {0}년{1}월 - 조회중 오류가 발생하였습니다. !!!!!!!!!!!", data.Year, data.Month);
                        DisplayTextBox(message);

                        continue;
                    }

                    // 1. 날짜 찾기 
                    // 2. 구역 찾기 
                    foreach (var searchDatre in _selectedList.Where(x => x.Year == data.Year && x.Month == data.Month).OrderBy(x=> x.Day))
                    {
                        // 구분자
                        const string startBlockTag = "<TD style='padding:5px;'>";
                        const string dayTag1 = "<span class='fl b fs11pt txt-dark'>{0}</span>"; // 평일
                        const string dayTag2 = "<span class='fl b fs11pt txt-red'>{0}</span>";  // 주말/휴일
                        
                        const string siteTag = "mr5'></i>{0}";
                        const string siteEndTag = "</span>";  // 앞에 (숫자) 남은것 (0) 이 아니면 자리있음으로 확인하면됨

                        //
                        string temp = string.Empty;

                        // 날짜 블럭 시작부터로
                        html = html.Substring(html.IndexOf(startBlockTag));
                        
                        // 날짜 찾기
                        if (html.IndexOf(string.Format(dayTag1, searchDatre.Day)) > 0)
                            html = html.Substring(html.IndexOf(string.Format(dayTag1, searchDatre.Day)));
                        else
                            html = html.Substring(html.IndexOf(string.Format(dayTag2, searchDatre.Day)));

                        // 해당 날짜 블럭 구하기
                        if (html.IndexOf(startBlockTag) > 0)
                            temp = html.Substring(0, html.IndexOf(startBlockTag));
                        else
                            temp = html;

                        //
                        var sites = new string[] { "A", "B", "C", "D", "E" };
                        if ((int)searchDatre.Site != 0) // 전체
                        {
                            sites = new string[] { searchDatre.Site.ToString() };
                        }

                        foreach (var selectedSite in sites)
                        {
                            if (temp.IndexOf(string.Format(siteTag, selectedSite)) < 0)
                            {
                                message = string.Format(displayMessage, selectedSite, searchDatre.Month, searchDatre.Day, "조회오류 - 아직 예약전이거나, 해당사이트 정보를 찾을수 없습니다.");
                            }
                            else
                            {
                                temp = temp.Substring(temp.IndexOf(string.Format(siteTag, selectedSite)));

                                remainCount = temp.Substring(0, temp.IndexOf(siteEndTag));

                                remainCount = remainCount.Substring(remainCount.IndexOf("(") + 1, remainCount.IndexOf(")") - remainCount.IndexOf("(") - 1);

                                Console.WriteLine("{1}-{2} [{3}] remainCount : {0}", remainCount, searchDatre.Month, searchDatre.Day, selectedSite);

                                if ("0".Equals(remainCount) == true) // 만석
                                {
                                    message = string.Format(displayMessage, selectedSite, searchDatre.Month, searchDatre.Day, "예약완료. XXXXXXXXXXXXXXXXXXXXXXXXX");
                                }
                                else
                                {
                                    // 가능
                                    message = string.Format(displayMessage, selectedSite, searchDatre.Month, searchDatre.Day, "예약가능함. ○○○○○○○○○○○○○○○○");

                                    // 텔레그램
                                    TelegramHelper.SendMessageByTelegramBot(string.Format("{0}- {1}", message, url));

                                    if (chkPassAlarm.Checked == false)
                                    {
                                        if (MessageBox.Show(message, "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                        {
                                            // 바로가기 
                                            System.Diagnostics.Process.Start(url);
                                        }
                                    }
                                }
                            }

                            DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                            DisplayTextBox(message);
                        }
                      
                        
                        _checkCount++;
                    }
                }

                if (_checkCount > 600)
                {
                    CrearDisplayText();
                    _checkCount = 0;
                }

                // 선택된 날짜 모두 확인후 대기후 시작
                Thread.Sleep(gapTime);
            }
        }

        void CrearDisplayText()
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new Action(() => richTextBox1.Clear()));
            }
            else
            {
                richTextBox1.Clear();
            }
        }

        void DisplayTextBox(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new Action(() => richTextBox1.Text += text ));
                richTextBox1.BeginInvoke(new Action(() => richTextBox1.SelectionStart = richTextBox1.Text.Length));
                richTextBox1.BeginInvoke(new Action(() => richTextBox1.ScrollToCaret()));
            }
            else
            {
                richTextBox1.Text += text;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //base.OnFormClosing(e);
            e.Cancel = true;

            this.Hide();

            notifyIcon1.Visible = true;

            //notifyIcon1.ShowBalloonTip(100);
            
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;

            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈춘다 

            this.Activate(); // 폼을 활성화 시킨다

            this.notifyIcon1.Visible = false;


            //this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;

            this.Dispose();

            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void btns_Click(object sender, EventArgs e)
        {
            _reservationPossible = 0;

            if (_selectedList.Count == 0)
            {
                MessageBox.Show("선택된 내용이 없네요");
                return;
            }

            DoProcess();
        }

        private void btne_Click(object sender, EventArgs e)
        {
            btns.Enabled = true;
            btne.Enabled = false;

            _keepRunning = false;

            if (_th1 != null && _th1.IsAlive)
                _th1.Abort();

            _th1 = null;
        }

        List<SelectionSHG> _selectedList = new List<SelectionSHG>();
        /// <summary>
        /// 추가        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_keepRunning)
            {
                MessageBox.Show("중지 후 추가가능합니다.");
                return;
            }
            
            if (string.IsNullOrEmpty(cbbMonth.Text)
                || string.IsNullOrEmpty(txtday.Text)
                || string.IsNullOrEmpty(cbSite.Text))
            {
                MessageBox.Show("날짜 및 사이트 선택오류~!");
                return;
            }

            int year = DateTime.Now.Year;
            int month = int.Parse(cbbMonth.Text);
            int day = int.Parse(txtday.Text);

            if (new DateTime(year, month, day) <= DateTime.Now.Date)
                MessageBox.Show("날짜 선택오류 - 내일부터 선택가능~!");

            SiteTypeSHG stieType = (SiteTypeSHG)cbSite.SelectedIndex;
            
            _selectedList.Add(new SelectionSHG()
            {
                Year = year,
                Month = month,
                Day = day,
                Site = stieType
            });

            SetDataSource();
        }

        private void SetDataSource()
        {
            listSelection.DataSource = null;
            listSelection.DataSource = _selectedList;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var index = listSelection.SelectedIndex;
            if (index < 0)
                return;

            _selectedList.RemoveAt(index);
            SetDataSource();
        }
    }

  
  
}
