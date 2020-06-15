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
    public partial class frmKangC : Form
    {
        string _month = "10";
        int _year = 2016;
        int _day = 0;
        bool _keepRunning = true;
        int _reservationPossible = 0;
        const int _showWebCount = 2;

        public frmKangC()
        {
            InitializeComponent();

            //
            // 
            txtday.Text = DateTime.Now.Day.ToString();


            cbbMonth.Items.Clear();
            for (int i = 1; i < 13; i++)
            {
                cbbMonth.Items.Add(i);
            }

            cbbMonth.Text = DateTime.Now.Month.ToString();
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

            _month = cbbMonth.Text;

            _searchText = txtday.Text.Trim();

            //
            _th1 = new Thread(DoWork);

            _th1.Start();
        }

        private void DoWork()
        {
            while (_keepRunning)
            {
                string url = @"http://gangssibong.gg.go.kr/reservation.asp?location=002";

                string html = ScrapTest.Scrap.Scraping(url, ScrapTest.Method.GET);

                html = html.Replace("\r\n", "");
                html = html.Replace("\t", "");


                // 예약가능여부찾기
                //string searchText = "<article class='day'>{0}</article><article class='camp'>예약완료";
                string searchText = "<a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='A'>1구역(<span>0</span>/30)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='B'>2구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='C'>3구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='D'>4구역(<span>0</span>/20)</a><a href='javascript:;' class='onlineReserve' choiceDay='{0}' productGroupCode='W'>통나무(<span>0</span>/10)</a>";

                //string searchText1 = "choiceDay='{0}' productGroupCode='A'>1구역(<span>0</span>/30)</a>";
                //string searchText2 = "choiceDay='{0}' productGroupCode='B'>2구역(<span>0</span>/20)</a>";
                //string searchText3 = "choiceDay='{0}' productGroupCode='C'>3구역(<span>0</span>/20)</a>";
                //string searchText4 = "choiceDay='{0}' productGroupCode='D'>4구역(<span>0</span>/20)</a>";
                //string searchText5 = "choiceDay='{0}' productGroupCode='W'>통나무(<span>0</span>/10)</a>";

                string[] arrDay = _searchText.Split(',');

                //Console.WriteLine(html);
                for (int i = 0; i < arrDay.Length; i++)
                {
                    int day = 0;
                    if (int.TryParse(arrDay[i], out day) == false) continue;

                    searchText = string.Format(searchText, day);

                    if (html.IndexOf(searchText) <= 0)
                    {
                        //MessageBox.Show("예약가능");

                        //DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                        //DisplayTextBox("[" + _month + "월 " + day.ToString() + "일]  예약가능함. ○○○○○○○○○○○○○○○○○○○○○○○○○○○");

                        if (_reservationPossible < _showWebCount)
                        {
                            System.Diagnostics.Process.Start(url);

                            Thread.Sleep(10000);
                        }

                        _reservationPossible++;
                    }
                    else
                    {
                        //DisplayTextBox(DateTime.Now.ToString("\r\n yyyy-MM-dd [HH:mm:ss] \t"));
                        //DisplayTextBox("[" + _month + "월 " + day.ToString() + "일] 예약완료 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

                        _reservationPossible = 0;
                    }
                }

                Thread.Sleep(3000);
            }
        }



        private void btns_Click(object sender, EventArgs e)
        {

        }

        private void btne_Click(object sender, EventArgs e)
        {

        }
    }
}
