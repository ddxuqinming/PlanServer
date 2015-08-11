using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sun.Common;
using sun.DataProvider;

namespace PlanServer
{
    public partial class frmConfig : Form
    {
        private bool mOK;
        private string mID;
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save(mID);
            mOK = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save(string id) {
           if (!System.IO.Directory.Exists(myApp.Config_PlanPath)) {
                System.IO.Directory.CreateDirectory(myApp.Config_PlanPath);
            }
            string file = myApp.Config_PlanPath + "\\" + id + ".config";
            //1
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "ip",  txtServer.Text , file);
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "user",   txtUser.Text, file);
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "pwd", Functions.EncryptDecrypt.EncryptText1( txtPwd.Text) , file);
            sun.Common.Functions.XML.WriteIniToXml ("sqlserver", "db", drpDB.Text , file);
            //2
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "ip2", txtServer2.Text, file);
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "user2", txtUser2.Text, file);
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "pwd2", Functions.EncryptDecrypt.EncryptText1(txtPwd2.Text), file);
            sun.Common.Functions.XML.WriteIniToXml("sqlserver", "db2", drpDB2.Text, file);
             //
            sun.Common.Functions.XML.WriteIniToXml ("pram", "time", drpTime.Text ,file);
            sun.Common.Functions.XML.WriteIniToXml("pram", "stop", chkStop.Checked.ToString(), file);
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 30; i++)
            {
                this.drpTime.Items.Add(i);
                
            }
        }
        public bool ShowConfig(string id)
        {
            mID = id;
            string file = myApp.Config_PlanPath + "\\" + id + ".config";
            //1
            txtServer.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver","ip",file);
            txtUser.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "user", file);
            txtPwd.Text = Functions.EncryptDecrypt.DecryptText2 ( sun.Common.Functions.XML.ReadInifromXml("sqlserver", "pwd", file));
            drpDB.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "db", file);
            //2
            txtServer2.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "ip2", file);
            txtUser2.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "user2", file);
            txtPwd2.Text = Functions.EncryptDecrypt.DecryptText2(sun.Common.Functions.XML.ReadInifromXml("sqlserver", "pwd2", file));
            drpDB2.Text = sun.Common.Functions.XML.ReadInifromXml("sqlserver", "db2", file);

            //
            drpTime.Text = sun.Common.Functions.XML.ReadInifromXml("pram", "time", file);
            chkStop.Checked  = sun.Common.Functions.Type.ConvertToBoolean ( sun.Common.Functions.XML.ReadInifromXml("pram", "stop", file));
            this.ShowDialog();
            return mOK;
        }

        private void drpDB_DropDown(object sender, EventArgs e)
        {
            string strConn=DataAccess.getNewSqlConnectionString (this.txtServer.Text ,txtUser.Text , txtPwd.Text ,"master","PlanServer","");
            DataAccess xudb = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);

            try
            {
                xudb.Open();
                DataTable dtb = xudb.getDataTable("select name from master..sysdatabases order by name");
                drpDB.Items.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++) 
                {
                    drpDB.Items.Add(dtb.Rows[i]["name"].ToString ());
                
                }
                xudb.Close();

            }
            catch (  Exception  ex)
          {
                
                 MessageBox.Show (ex.Message );
            }
        }


        private void drpDB2_DropDown(object sender, EventArgs e)
        {
            string strConn = DataAccess.getNewSqlConnectionString(this.txtServer2.Text, txtUser2.Text, txtPwd2.Text, "master", "PlanServer", "");
            DataAccess xudb = new DataAccess(strConn, DataAccess.DbProviderFactoryTypeEnum.SqlClient);

            try
            {
                xudb.Open();
                DataTable dtb = xudb.getDataTable("select name from master..sysdatabases order by name");
                drpDB2.Items.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    drpDB2.Items.Add(dtb.Rows[i]["name"].ToString());

                }
                xudb.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

       
    }//class
}
