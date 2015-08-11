using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PlanServer
{
    public partial class PlanUI : UserControl
    {
        private int mCount=0;
        private bool mStop = false;
        private bool mDoing = false;

  #region 属性

       
        public delegate void SetupClickEvent( object sender, string id);
        public event SetupClickEvent SetupClick;
        public PlanBase Plan  { set; get; }
      
    #endregion

        public PlanUI()
        {
            InitializeComponent();
          
        }



        private void ddd(object sender, string id) { }
        private void lnkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetupClick (this, this.Plan.ID  );
          
           
        }

        private void PlanUI_Load(object sender, EventArgs e)
        {

            Refresh();
             

        }
        public override  void Refresh()
        {
            this.Plan.ReadConfig();
            this.LabName.Text = this.Plan.Name;
            this.labCount.Text = "0";
            this.labCount.ForeColor = Color.Black;
            mStop = this.Plan.Stop;
            mDoing = false;
            if (this.Plan.Stop)
                this.labStop.Text = "停用";
            else
                this.labStop.Text = "";
        
        }
        //运行计划
        public void Run()
        {
           System.Timers.Timer  timer = new  System.Timers.Timer() ;
           timer.Interval = 1000 * 60   * this.Plan.Time;
           timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
           timer.Enabled = true;
        
        }
       
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (mStop || mDoing) return;
            try
            {
                mDoing = true;
                this.labCount.Text = "执行中...";
                System.Windows.Forms.Application.DoEvents();
                if (this.Plan.Execute())
                {
                    mCount += 1;
                    this.labCount.Text = mCount.ToString() + "次";
                    mDoing = false;
                }
            
            }
            catch (Exception ex) 
            {
                this.labCount.Text = mCount.ToString() + "," + ex.Message ;
                this.labCount.ForeColor = Color.Red;
                mStop = true;
            
            }
          
        
        }

        private void PlanUI_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f4fbe1");
        }

        private void PlanUI_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void labRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Refresh();
        }
    }//class
}
