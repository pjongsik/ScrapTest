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
    public partial class frmInter : Form
    {
        public frmInter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = @"http://ticket.interpark.com/Ticket/Goods/GoodsInfo.asp?GoodsCode=20003621&pis1=ticket&pis2=product";
            var text = ScrapTest.Scrap.Scraping(url, ScrapTest.Method.GET);

            //ifrCalendar.asp? GoodsCode=20003621&PlaceCode=20000376&OnlyDeliver=68006&DBDay =12&ExpressDelyDay=0

            MessageBox.Show(text);
        }
    }
}
