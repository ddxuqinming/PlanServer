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

  #region 属性

       
        public delegate void SetupClickEvent( object sender, string id);
        public event SetupClickEvent SetupClick;
        public PlanBase Plan  { set; get; }
      
    #endregion

        public PlanUI()
        {
            InitializeComponent();
          
        }




        private void lnkSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetupClick (this, this.Plan.ID  );
           
        }

        private void PlanUI_Load(object sender, EventArgs e)
        {
            this.LabName.Text = this.Plan.Name;
            this.labCount.Text = "0";
        }
        //运行计划
        public void Run()
        {
           System.Timers.Timer  timer = new  System.Timers.Timer() ;
           timer.Interval = 1000;
           timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
           timer.Enabled = true;
        
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (this.Plan.Execute())
                {
                    mCount += 1;
                    this.labCount.Text = mCount.ToString();
                }
            
            }
            catch (Exception ex) 
            {
                this.labCount.Text = mCount.ToString() + "," + ex.Message ;
                this.labCount.ForeColor = Color.Red;
            
            }
          
        
        }
    }//class
}
