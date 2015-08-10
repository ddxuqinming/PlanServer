using System;
using System.Collections.Generic;
using System.Text;
using sun.Common;

namespace PlanServer
{
    /// <summary> 
    /// 计划
    /// </summary>
  public   class PlanBase
    {
        protected  string  _id;
        public String ID { get { return _id; }  }
        public String Name   { get; set; }

     
        public  myApp.ConnectionStruct K3DBCfg { get; set; }
        public myApp.ConnectionStruct  PTDBCfg { get; set; }
        /// <summary>
        /// 定时间隔,单位分钟
        /// </summary>
        public  int  Time { get; set; }

      /// <summary>
      /// 读取配置
      /// </summary>
        public void ReadConfig()
        {
            string file = myApp.Config_PlanPath + "\\" + this.ID  + ".config";
            //1
                myApp.ConnectionStruct cfg1;
                cfg1.Server = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "ip", file);
                cfg1.User  = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "user", file);
                cfg1.Pwd  = Functions.EncryptDecrypt.DecryptText2(sun.Common.Functions.XML.ReadInifromXml("sqlserver", "pwd", file));
                cfg1.Db  = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "db", file);
                this.K3DBCfg = cfg1;
            //2
                myApp.ConnectionStruct cfg2;
                cfg2.Server = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "ip2", file);
                cfg2.User = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "user2", file);
                cfg2.Pwd = Functions.EncryptDecrypt.DecryptText2(sun.Common.Functions.XML.ReadInifromXml("sqlserver", "pwd2", file));
                cfg2.Db = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "db2", file);
                this.PTDBCfg  = cfg2;
             //
                 this.Time  =myApp.ConvertToInt ( sun.Common.Functions.XML.ReadInifromXml("pram", "time", file));
            
        }
        /// <summary>
        /// 执行
        /// </summary>
        public  virtual void  Execute()
        {
        }
        

      
    }
}
