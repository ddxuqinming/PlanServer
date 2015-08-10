using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlanServer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
          
         
           
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Environment.Exit(0);   //彻底退出
            }


        }

        private void LoadPlan()
        {
            //计划1
            PlanUI ui = new PlanUI();
            ui.Plan = new Plan_K3Lock();
            ui.SetupClick  += new PlanUI.SetupClickEvent (PlanUI_SetupClick) ;
            this.pnlMain.Controls.Add(ui);
            
        
        
        }
        private void PlanUI_SetupClick(object sender, string id)
        {
            frmConfig frm = new frmConfig();
            frm.Text = ((PlanUI)sender).Plan.Name ;
            if (frm.ShowConfig(id)) 
            {
                ((PlanUI)sender).Plan.ReadConfig();
            
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadPlan();
        }

      

    }
}
