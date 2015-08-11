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
            this.SuspendLayout();
            // 
            // LabName
            // 
            this.LabName.AutoSize = true;
            this.LabName.Location = new System.Drawing.Point(24, 17);
            this.LabName.Name = "LabName";
            this.LabName.Size = new System.Drawing.Size(41, 12);
            this.LabName.TabIndex = 0;
            this.LabName.Text = "label1";
            // 
            // lnkSetup
            // 
            this.lnkSetup.AutoSize = true;
            this.lnkSetup.Location = new System.Drawing.Point(220, 94);
            this.lnkSetup.Name = "lnkSetup";
            this.lnkSetup.Size = new System.Drawing.Size(29, 12);
            this.lnkSetup.TabIndex = 1;
            this.lnkSetup.TabStop = true;
            this.lnkSetup.Text = "设置";
            this.lnkSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSetup_LinkClicked);
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Location = new System.Drawing.Point(24, 89);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(41, 12);
            this.labCount.TabIndex = 2;
            this.labCount.Text = "label1";
            // 
            // PlanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labCount);
            this.Controls.Add(this.lnkSetup);
            this.Controls.Add(this.LabName);
            this.Name = "PlanUI";
            this.Size = new System.Drawing.Size(268, 115);
            this.Load += new System.EventHandler(this.PlanUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkSetup;
        public System.Windows.Forms.Label LabName;
        private System.Windows.Forms.Label labCount;
    }
}
