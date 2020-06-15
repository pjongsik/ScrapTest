using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace SqliteData
{
    public class SqliteHelper
    {
        // default 경로
        string _strConn = @"Data Source=C:\Temp\mydb.db";

        /// <summary>
        /// sqlite datafile path 설정
        /// 기본 C:\Temp\mydb.db
        /// </summary>
        /// <param name="dataFilePath"></param>
        public void SetConn(string dataFilePath)
        {
            _strConn = string.Format(@"Data Source={0}", dataFilePath);
        }
        
        public string ExcuteNonQuery(string sql)
        {
            if (!ExsistFile(_strConn)) return "데이터 파일이 존재하지 않습니다.";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(_strConn))
                {
                    conn.Open();

                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return null;
        }

        private bool ExsistFile(string _strConn)
        {
            FileInfo file = new FileInfo(_strConn);
            return file.Exists;
        }
    }
}
