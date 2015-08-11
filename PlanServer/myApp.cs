using System;
using System.Collections.Generic;
using System.Text;

namespace PlanServer
{
    /// <summary>
    /// 修改测试
    /// </summary>
    public  static class myApp
    {

        public static string Config_PlanPath = System.Windows.Forms.Application.StartupPath + "\\Plan";
        public struct ConnectionStruct
        {
            public string Server;
            public string User;
            public string Pwd;

            public string Db;
        }
        public static int ConvertToInt( object  s)
        {
            //dd
            int t;
            if (s == null )
                return 0;

            if (s == DBNull.Value )
                return 0;
            if (s.ToString () == "")
                return 0;
             int rt;
            if ( int.TryParse(s.ToString (),out rt))
                 return rt;
            return 0;
            
        
        }

        public static int ConvertToInt2(object s)
        {
            if (s == null)
                return 0;

            if (s == DBNull.Value)
                return 0;
            if (s.ToString() == "")
                return 0;
            int rt;
            if (int.TryParse(s.ToString(), out rt))
                return rt;
            return 0;


        }
    }

}
