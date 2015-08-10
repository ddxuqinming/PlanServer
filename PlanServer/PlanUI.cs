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

        }
    }//class
}
