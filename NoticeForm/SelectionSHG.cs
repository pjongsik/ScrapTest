using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoticeForm
{
    public class SelectionSHG
    {
        public SelectionSHG()
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

        public SiteTypeSHG Site
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
                    case SiteTypeSHG.A:
                        returnText = "A";
                        break;
                    case SiteTypeSHG.B:
                        returnText = "B";
                        break;
                    case SiteTypeSHG.C:
                        returnText = "C";
                        break;
                    case SiteTypeSHG.D:
                        returnText = "D";
                        break;
                    case SiteTypeSHG.E:
                        returnText = "E";
                        break;
                }

                return returnText;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} : {3}", Year, Month, Day, Site);
        }
    }

    public enum SiteTypeSHG
    {
        전체 = 0, A = 1, B = 2, C = 3, D = 4, E = 5
    }
    
}
