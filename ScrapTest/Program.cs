using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string html = Scrap.Scraping("",Method.GET);

            html = html.Replace("\r\n", "");
            html = html.Replace("\t", "");

            string searchText = "<article class='day'>11</article><article class='camp'><a href=";

            Console.WriteLine(html);

            if (html.IndexOf(searchText) > 0)
            {

                Console.WriteLine("==================");
                Console.WriteLine("11일 예약 가능!@!@");
                Console.WriteLine("11일 예약 가능!@!@");
                Console.WriteLine("==================");
            }
            else
            {

                Console.WriteLine("11일 예약완료 XXXXXXXXXXXXXXXXX");
                
            }

            Console.ReadKey();
        }

    }
}
