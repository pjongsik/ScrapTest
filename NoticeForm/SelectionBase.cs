using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoticeForm
{
    public class SelectionBase
    {
        public SelectionBase()
        {
        }

        public int Year
        {
            get;
            set;
        }

        public int Month
        {
            get;
            set;
        }

        public int Day
        {
            get;
            set;
        }

        public SiteType Site
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Phone1
        {
            get;
            set;
        }

        public string Phone2
        {
            get;
            set;
        }

        public string Phone3
        {
            get;
            set;
        }

        public string BirthDay
        {
            get;
            set;
        }

        public string SiteLetter
        {
            get
            {
                string returnText = string.Empty;
                switch (Site)
                {
                    case SiteType.구역1:
                        returnText = "A";
                        break;
                    case SiteType.구역2:
                        returnText = "B";
                        break;
                    case SiteType.구역3:
                        returnText = "C";
                        break;
                    case SiteType.구역4:
                        returnText = "D";
                        break;
                    case SiteType.통나무:
                        returnText = "W";
                        break;
                }

                return returnText;
            }
        }

        public string Url
        {
            get
            {
                return string.Format(string.Format(@"http://125.209.193.208/reservation/online_step_01.php?searchYear={0}&searchMonth={1}&searchType=next#subContents", Year, (Month - 1).ToString("00")));
            }
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} : {3}", Year, Month, Day, Site);
        }
    }

    public enum SiteType
    {
        전체 = 0, 통나무 = 1, 구역1 = 2, 구역2 = 3, 구역3 = 4, 구역4 = 5
    }
}
