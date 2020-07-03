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
    public partial class frmSJH : Form
    {
        string _month = "8";
        int _year = 2019;
        int _day = 0;
        bool _keepRunning = false;
        int _reservationPossible = 0;
        const int _showWebCount = 2;
       // frmNotice _frm= new frmNotice();

        public frmSJH()
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

            //
            //DoProcess();
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
                int gapTime = 3 * 1000;

                if (int.TryParse(txtGapTime.Text, out gapTime) == false)
                    gapTime = 3;

                gapTime *= 1000;

                foreach (var data in _selectedList)
                {
                    
                    // 스크래핑함
                    int 숙박일 = 1; // 1박
                    string 시작일 = new DateTime(data.Year, data.Month, data.Day).ToString("yyyyMMdd");
                    string 종료일 = new DateTime(data.Year, data.Month, data.Day).AddDays(숙박일).ToString("yyyyMMdd");

                    int[] 구역 = new int[] { 1 };
                    if (data.Site == SiteType.전체)
                        구역 = new int[] { 1, 2, 3, 4, 5 };
                    else
                        구역 = new int[] { (int)data.Site };

                    foreach (var site in 구역)
                    {
                        string url = string.Format(string.Format(@"https://gwgs.ticketplay.zone/portal/realtime/productSelect?room_area_no={0}&stay_cnt={1}&check_in={2}&check_out={3}", site, 숙박일, 시작일, 종료일));
                        string html = ScrapTest.Scrap.Scraping(url, ScrapTest.Method.GET, "UTF-8");
                        
                        int day = data.Day;
                        int month = data.Month;

                        string displayMessage = "송지호 : {1}월 {2}일 ({0}) --  {3}";

                        //송지호 오토캠핑장
                        string title = "송지호 오토캠핑장";
                        if (html.IndexOf(title) <= 0)
                        {
                            // 페이지 오류
                            DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));

                            string message = string.Format(displayMessage, Enum.GetName(typeof(SiteType), site), month, day, "조회중 오류가 발생하였습니다. !!!!!!!!!!!!!!!!!!!");
                            DisplayTextBox(message);
                        }
                        else
                        {

                            // 확인 텍스트
                            string searchText = "예약 가능한 사이트가 없습니다.";

                            if (html.IndexOf(searchText) <= 0)
                            {

                                DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));

                                string message = string.Format(displayMessage, Enum.GetName(typeof(SiteType), site), month, day, "예약가능함. ○○○○○○○○○○○○○○○○○○○○");
                                DisplayTextBox(message);

                                // 텔레그램
                                TelegramHelper.SendMessageByTelegramBot(string.Format("{0}- {1}", message, url));

                                //if (_reservationPossible < _showWebCount)
                                //{
                                //System.Diagnostics.Process.Start(url);

                                //ShowAlarmForm(url, message);
                                if (chkPassAlarm.Checked == false)
                                {
                                    if (MessageBox.Show(message, "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        // 바로가기 
                                        System.Diagnostics.Process.Start(url);
                                    }
                                }
                                    // Thread.Sleep(10000);
                               // }

                                _reservationPossible++;
                            }
                            else
                            {
                                DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                                DisplayTextBox(string.Format(displayMessage, Enum.GetName(typeof(SiteType), site), month, day, "예약완료. XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"));

                                _reservationPossible = 0;
                            }
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

        List<SelectionBase> _selectedList = new List<SelectionBase>();
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

            SiteType stieType = (SiteType)cbSite.SelectedIndex;
            
            _selectedList.Add(new SelectionBase()
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
