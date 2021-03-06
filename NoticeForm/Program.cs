﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoticeForm
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && "shg".Equals(args[0].ToLower()))
                Application.Run(new frmSHG());
            else
                Application.Run(new frmSJH());
        }
    }
}
