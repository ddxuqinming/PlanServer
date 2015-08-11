namespace PlanServer
{
    partial class PlanUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabName = new System.Windows.Forms.Label();
            this.lnkSetup = new System.Windows.Forms.LinkLabel();
            this.labCount = new System.Windows.Forms.Label();
            this.labStop = new System.Windows.Forms.Label();
            this.labRefresh = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LabName
            // 
            this.LabName.AutoSize = true;
            this.LabName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabName.Location = new System.Drawing.Point(18, 17);
            this.LabName.Name = "LabName";
            this.LabName.Size = new System.Drawing.Size(47, 12);
            this.LabName.TabIndex = 0;
            this.LabName.Text = "label1";
            // 
            // lnkSetup
            // 
            this.lnkSetup.AutoSize = true;
            this.lnkSetup.Location = new System.Drawing.Point(220, 78);
            this.lnkSetup.Name = "lnkSetup";
            this.lnkSetup.Size = new System.Drawing.Size(29, 12);
            this.lnkSetup.TabIndex = 1;
            this.lnkSetup.TabStop = true;
            this.lnkSetup.Text = "设置";
            this.lnkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetup_LinkClicked);
            // 
            // labCount
            // 
            this.labCount.Location = new System.Drawing.Point(18, 78);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(155, 28);
            this.labCount.TabIndex = 2;
            this.labCount.Text = "label1";
            // 
            // labStop
            // 
            this.labStop.AutoSize = true;
            this.labStop.ForeColor = System.Drawing.Color.Red;
            this.labStop.Location = new System.Drawing.Point(220, 17);
            this.labStop.Name = "labStop";
            this.labStop.Size = new System.Drawing.Size(29, 12);
            this.labStop.TabIndex = 3;
            this.labStop.Text = "stop";
            // 
            // labRefresh
            // 
            this.labRefresh.AutoSize = true;
            this.labRefresh.Location = new System.Drawing.Point(185, 78);
            this.labRefresh.Name = "labRefresh";
            this.labRefresh.Size = new System.Drawing.Size(29, 12);
            this.labRefresh.TabIndex = 4;
            this.labRefresh.TabStop = true;
            this.labRefresh.Text = "刷新";
            this.labRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labRefresh_LinkClicked);
            // 
            // PlanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labRefresh);
            this.Controls.Add(this.labStop);
            this.Controls.Add(this.labCount);
            this.Controls.Add(this.lnkSetup);
            this.Controls.Add(this.LabName);
            this.Name = "PlanUI";
            this.Size = new System.Drawing.Size(268, 115);
            this.Load += new System.EventHandler(this.PlanUI_Load);
            this.MouseLeave += new System.EventHandler(this.PlanUI_MouseLeave);
            this.MouseHover += new System.EventHandler(this.PlanUI_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSetup;
        public System.Windows.Forms.Label LabName;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.Label labStop;
        private System.Windows.Forms.LinkLabel labRefresh;
    }
}
