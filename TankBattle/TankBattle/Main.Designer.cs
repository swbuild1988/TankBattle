namespace TankBattle
{
    partial class Main
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.DebugPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Bar_FPS = new System.Windows.Forms.TrackBar();
            this.DebugPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_FPS)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(380, 457);
            this.DrawPanel.TabIndex = 0;
            // 
            // DebugPanel
            // 
            this.DebugPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugPanel.Controls.Add(this.label1);
            this.DebugPanel.Controls.Add(this.Bar_FPS);
            this.DebugPanel.Location = new System.Drawing.Point(386, 0);
            this.DebugPanel.Name = "DebugPanel";
            this.DebugPanel.Size = new System.Drawing.Size(218, 457);
            this.DebugPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPS";
            // 
            // Bar_FPS
            // 
            this.Bar_FPS.Location = new System.Drawing.Point(69, 11);
            this.Bar_FPS.Maximum = 60;
            this.Bar_FPS.Minimum = 1;
            this.Bar_FPS.Name = "Bar_FPS";
            this.Bar_FPS.Size = new System.Drawing.Size(136, 45);
            this.Bar_FPS.TabIndex = 0;
            this.Bar_FPS.Value = 30;
            this.Bar_FPS.ValueChanged += new System.EventHandler(this.Bar_FPS_ValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 457);
            this.Controls.Add(this.DebugPanel);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "坦克大战";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DebugPanel.ResumeLayout(false);
            this.DebugPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bar_FPS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Panel DebugPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar Bar_FPS;
    }
}

