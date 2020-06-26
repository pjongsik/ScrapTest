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
    public partial class SongJiHoForm : Form
    {
        SelectionBase _selectionData = null;

        public SongJiHoForm()
        {
            InitializeComponent();
        }

        public SongJiHoForm(SelectionBase data)
        {
            InitializeComponent();

            _selectionData = data;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //
            webBrowser1.Navigate(_selectionData.Url);

        }
              

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // 시작
            //SelectDaynSite_2(_selectionData.Day.ToString(),  _selectionData.SiteLetter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // http://stackoverflow.com/questions/34713772/invoking-an-href-click-event-javascript-in-winforms-webbrowser-control

            //using (var form = new Form1())
            //{
            //    form.ShowDialog();
            //}

            // 구역 : A B C D W
            string site = string.Empty;
            if ("1".Equals(cbSite.SelectedItem))
                site = "A";
            else if ("2".Equals(cbSite.SelectedItem))    
                site = "B";
            else if ("3".Equals(cbSite.SelectedItem))
                site = "C";
            else if ("4".Equals(cbSite.SelectedItem))
                site = "D";
            else if ("통나무집".Equals(cbSite.SelectedItem))
                site = "W";

            SelectDaynSite_2(cbDay.SelectedItem.ToString(), site);
        }

        private void SelectDaynSite_2(string day, string groupCode)
        {
            var elements = webBrowser1.Document.GetElementsByTagName("a");

            foreach (HtmlElement element in elements)
            {
                // If there's more than one button, you can check the
                //element.InnerHTML to see if it's the one you want
                if (element != null
                        && element.GetAttribute("choiceDay").Equals(day)
                        && element.GetAttribute("productGroupCode").Equals(groupCode))
                {
                    element.InvokeMember("CLICK");
                }
            }

            // submit
            var form = webBrowser1.Document.GetElementById("theForm");
            form.InvokeMember("submit");

            _nextStep = 3;
        }
        //private void SelectDaySiteSubmit(string day, string groupCode)
        //{
           
        //    var element = webBrowser1.Document.GetElementById("theForm");
        //    if (element == null) return;

        //    var childElements = element.Children.GetElementsByName("input");

        //    foreach (HtmlElement el in childElements)
        //    {
        //        if (el.GetAttribute("id") == "searchDay")
        //        {
        //            el.InnerText = day;
        //        }
        //        else if (el.GetAttribute("id") == "productGroupCode")
        //        {
        //            el.InnerText = groupCode;
        //        }
        //    }

        //    element.InvokeMember("submit");
        //}

        private string SeletMonth_1(int month)
        {
            if (month < 4 && month > 10) 
                return "월선택을 다시해라 4월 ~ 10월 가능";

            month -= 1;
            
            string monthValue = month.ToString("00");

            string url = string.Format(@"http://125.209.198.55/reservation/online_step_01.php?searchYear=2017&searchMonth={0}&searchType=next#subContents", monthValue);

            webBrowser1.Navigate(url);

            _nextStep = 2;

            return null;
        }

        int _nextStep = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            SeletMonth_1(int.Parse(cbMonth.SelectedItem.ToString()));
        }

        /// <summary>
        /// 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            label1.Text += "webBrowser1_Navigating" + ">>>";
        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            label1.Text += "webBrowser1_Navigated" + ">>>";
            
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            label1.Text += "webBrowser1_DocumentCompleted" + ">>> "  + _nextStep.ToString();
           
            if (_nextStep == 3)
            {
                SelectSeats_3();
            }
            else if (_nextStep == 4)
            {
                InsertUserInfo_4(_selectionData.Name, _selectionData.Phone1, _selectionData.Phone2, _selectionData.Phone3, _selectionData.BirthDay);
            }
            else if (_nextStep == 5)
            {
                ConfirmOrder_5();
            }
            else
            {
                // 시작
                SelectDaynSite_2(_selectionData.Day.ToString(), _selectionData.SiteLetter);
            }
        }

        /// <summary>
        /// 자리선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SelectSeats_3(int.Parse(cbSleepDay.SelectedItem.ToString()));
        }

        /// <summary>
        /// 정보입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            InsertUserInfo_4(txtName.Text.Trim(), txtMobile1.Text.Trim(), txtMobile2.Text.Trim(), txtMobile3.Text.Trim(), txtBirthday.Text.Trim());
        }


        private void button6_Click(object sender, EventArgs e)
        {
            ConfirmOrder_5();
        }

        /// <summary>
        /// 자리 체크
        /// </summary>
        private void SelectSeats_3(int stayCount = 1, int site1 = 0, int site2 = 0)
        {
            // 기간 설정
            if (stayCount > 1)
            {
                if (stayCount > 3) stayCount = 3;

                var selectElements = webBrowser1.Document.GetElementsByTagName("select");

                foreach (HtmlElement el in selectElements)
                {
                    if (el.GetAttribute("name") == "stayCount")
                    {
                        el.SetAttribute("value", stayCount.ToString());
                    }
                }
            }

            // 가능 자리 확인
            int index = 0;
            List<string> seatList = new List<string>();
            var spanElements = webBrowser1.Document.GetElementsByTagName("span");
            foreach (HtmlElement el in spanElements)
            {
                if (el.GetAttribute("class") == "siteTitle")
                {
                    seatList.Add(el.InnerText);

                    if (el.InnerText.Contains(site1.ToString()))
                    {
                        site1 = index;
                    }
                    else if (el.InnerText.Contains(site2.ToString()))
                    {
                        site2 = index;
                    }
                }

                index++;
            }

            // 자리 설정
            var inputElements = webBrowser1.Document.GetElementsByTagName("input");

            // 설정하지 않은경우 앞에서 두개
            if (site1 == 0 && site2 == 0)
            {
                int checkCount = 0;
                foreach (HtmlElement el in inputElements)
                {
                    if (el.GetAttribute("name") == "checkItem")
                    {
                        el.SetAttribute("checked", "true");
                        //el.InvokeMember("CLICK");

                        checkCount++;
                    }

                    if (checkCount == 2)
                        break;
                }
            }
            else
            {
                inputElements[site1].SetAttribute("checked", "true");
                inputElements[site2].SetAttribute("checked", "true");
            }

            // 동의
            //elements.GetElementsByName("agree")[0].InvokeMember("CLICK");
            inputElements.GetElementsByName("agree")[0].SetAttribute("checked", "true");


            // submit
            var form = webBrowser1.Document.GetElementById("reserveForm");
            //if (form == null) return;
            form.InvokeMember("submit");

            _nextStep = 4;
        }

   

        private void InsertUserInfo_4(string name, string phone1, string phone2, string phone3, string birth)
        {
            var elements = webBrowser1.Document.GetElementsByTagName("input");

            foreach (HtmlElement el in elements)
            {
                if (el.GetAttribute("name") == "reserve_name")
                {
                    el.SetAttribute("value", name);
                }
                if (el.GetAttribute("name") == "phone1")
                {
                    el.SetAttribute("value", phone1);
                }
                if (el.GetAttribute("name") == "phone2")
                {
                    el.SetAttribute("value", phone2);
                }
                if (el.GetAttribute("name") == "phone3")
                {
                    el.SetAttribute("value", phone3);
                }

                if (el.GetAttribute("name") == "birth")
                {
                    el.SetAttribute("value", birth);
                }

            }

            // 동의
            //elements.GetElementsByName("isAdult")[0].InvokeMember("CLICK");
            elements.GetElementsByName("isAdult")[0].SetAttribute("checked", "true");

            //submit
            var form = webBrowser1.Document.GetElementById("reserveForm");
            //if (form == null) return;
            form.InvokeMember("submit");

            _nextStep = 5;

        }

        /// <summary>
        /// step 4 결제창 띄우기
        /// </summary>
        private void ConfirmOrder_5()
        {
            var elements = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement el in elements)
            {
                if (el.GetAttribute("name") == "agree")
                {
                    //el.InvokeMember("CLICK");
                    el.SetAttribute("checked", "true");
                }

                if (el.GetAttribute("name") == "selectType" && el.GetAttribute("value") == "CARD")
                {
                    //el.InvokeMember("CLICK");
                    el.SetAttribute("checked", "true");
                }

            }

            // 카드결제
            webBrowser1.Document.InvokeScript("chkPayType", null);

            // 결제시작
            webBrowser1.Document.InvokeScript("proc", null);
        }
    }
}
