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
    public partial class frmBoard : Form
    {
        string _month = "10";
        int _year = 2015;
        int _day = 0;
        bool _keepRunning = true;
        int _reservationPossible = 0;
        const int _showWebCount = 2;
       // frmNotice _frm= new frmNotice();

        public frmBoard()
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
                    string html = ScrapTest.Scrap.Scraping(data.Url, ScrapTest.Method.GET);

                    html = html.Replace("\r\n", "");
                    html = html.Replace("\t", "");
                    
                    // 예약가능여부찾기
                    //string searchText = "<article class='day'>{0}</article><article class='camp'>예약완료";
                    //string searchText1 = "choiceDay='{0}' productGroupCode='A'>1구역(<span>0</span>/30)</a>";
                    //string searchText2 = "choiceDay='{0}' productGroupCode='B'>2구역(<span>0</span>/20)</a>";
                    //string searchText3 = "choiceDay='{0}' productGroupCode='C'>3구역(<span>0</span>/20)</a>";
                    //string searchText4 = "choiceDay='{0}' productGroupCode='D'>4구역(<span>0</span>/20)</a>";
                    //string searchText5 = "choiceDay='{0}' productGroupCode='W'>통나무(<span>0</span>/10)</a>";

             
                    // 전체
                    string searchText = "<a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='A'>1구역(<span>0</span>/30)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='B'>2구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='C'>3구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='D'>4구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='W'>통나무(<span>0</span>/10)</a>";
                    if (data.Site == SiteType.구역1)
                    {
                        searchText = "choiceDay='{0}' productGroupCode='A'>1구역(<span>0</span>/30)</a>";
                    }
                    else if (data.Site == SiteType.구역2)
                    {
                        searchText = "choiceDay='{0}' productGroupCode='B'>2구역(<span>0</span>/20)</a>";
                    }
                    else if (data.Site == SiteType.구역3)
                    {
                        searchText = "choiceDay='{0}' productGroupCode='C'>3구역(<span>0</span>/20)</a>";
                    }
                    else if (data.Site == SiteType.구역4)
                    {
                        searchText = "choiceDay='{0}' productGroupCode='D'>4구역(<span>0</span>/20)</a>";
                    }
                    else if (data.Site == SiteType.통나무)
                    {
                        searchText = "choiceDay='{0}' productGroupCode='W'>통나무(<span>0</span>/10)</a>";
                    }

                    int day = data.Day;
                    int month = data.Month;

                    // 확인 텍스트
                    searchText = string.Format(searchText, day.ToString("00"));

                    string displayMessage = "{1}월 {2}일 ({0}) --  {3}";
 
                    if (html.IndexOf(searchText) <= 0)
                    {
      
                        DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                        DisplayTextBox(string.Format(displayMessage, data.Site.ToString(), month, day, "예약가능함. ○○○○○○○○○○○○○○○○○○○○○○○○○○○"));

                        if (_reservationPossible < _showWebCount)
                        {
                            System.Diagnostics.Process.Start(data.Url);

                            //ShowSongJiHoForm(data);

                            Thread.Sleep(10000);
                        }

                        _reservationPossible++;
                    }
                    else
                    {
                        DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                        DisplayTextBox(string.Format(displayMessage, data.Site.ToString(), month, day, "예약완료 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"));

                        _reservationPossible = 0;
                    }

                    _checkCount++;
                }

                if (_checkCount > 600)
                {
                    CrearDisplayText();
                    _checkCount = 0;
                }

                // 선택된 날짜 모두 확인후 3초후
                Thread.Sleep(gapTime);
            }
        }

        private void ShowSongJiHoForm(SelectionBase data)
        {
            using (var frm = new SongJiHoForm(data))
            {
                frm.Show();
                Application.Run();
            }
        }

        private void DoWorkTeabek()
        {
            while (_keepRunning)
            {
                string url = string.Format(@"http://forest.taebaek.go.kr/member/index.html?s_year={0}&s_month={1}&s_day=1", _year, _month);

                string html = ScrapTest.Scrap.Scraping(url, ScrapTest.Method.GET);

                html = html.Replace("\r\n", "");
                html = html.Replace("\t", "");


                // 예약가능여부찾기
                                     
                string searchText = ">{0}</font></span>&nbsp<br><div align=center><img src=\"/ts_img/wanryo.gif\"";

                searchText = string.Format(searchText, txtday.Text.Trim());

                //Console.WriteLine(html);

                if (html.IndexOf(searchText) <= 0)
                {
                    //MessageBox.Show("예약가능");

                    DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                    DisplayTextBox("[" + _month + "월 " + txtday.Text + "일]  예약가능함. ○○○○○○○○○○○○○○○○○○○○○○○○○○○");

                    if (_reservationPossible < _showWebCount)
                    {
                        System.Diagnostics.Process.Start(url);

                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }

                    _reservationPossible++;
                }
                else
                {
                    DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                    DisplayTextBox("[" + _month + "월 " + txtday.Text + "일] 예약완료 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                    _reservationPossible = 0;

                    Thread.Sleep(3000);
                }
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
            if (string.IsNullOrEmpty(cbbMonth.Text)
                || string.IsNullOrEmpty(txtday.Text)
                || string.IsNullOrEmpty(cbSite.Text))
            {
                MessageBox.Show("날짜 및 사이트 선택오류~!");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text)
               || string.IsNullOrEmpty(txtBirth.Text)
               || string.IsNullOrEmpty(txtM1.Text)
                || string.IsNullOrEmpty(txtM2.Text)
            || string.IsNullOrEmpty(txtM3.Text))
            {
                MessageBox.Show("개인정보를 입력해주세요~!");
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
                Site = stieType,
                Name = txtName.Text,
                BirthDay = txtBirth.Text,
                Phone1 = txtM1.Text,
                Phone2 = txtM2.Text,
                Phone3 = txtM3.Text
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
