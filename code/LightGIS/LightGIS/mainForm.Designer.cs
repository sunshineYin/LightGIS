namespace LightGIS
{
    partial class mainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开e00文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矢量转栅格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示矢量图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示栅格图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示矢量栅格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.转换ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开e00文件ToolStripMenuItem,
            this.打开栅格文件ToolStripMenuItem,
            this.保存栅格文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开e00文件ToolStripMenuItem
            // 
            this.打开e00文件ToolStripMenuItem.Name = "打开e00文件ToolStripMenuItem";
            this.打开e00文件ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.打开e00文件ToolStripMenuItem.Text = "打开矢量文件";
            this.打开e00文件ToolStripMenuItem.Click += new System.EventHandler(this.打开e00文件ToolStripMenuItem_Click);
            // 
            // 打开栅格文件ToolStripMenuItem
            // 
            this.打开栅格文件ToolStripMenuItem.Name = "打开栅格文件ToolStripMenuItem";
            this.打开栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.打开栅格文件ToolStripMenuItem.Text = "打开栅格文件";
            this.打开栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.打开栅格文件ToolStripMenuItem_Click);
            // 
            // 保存栅格文件ToolStripMenuItem
            // 
            this.保存栅格文件ToolStripMenuItem.Name = "保存栅格文件ToolStripMenuItem";
            this.保存栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.保存栅格文件ToolStripMenuItem.Text = "保存栅格文件";
            this.保存栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.保存栅格文件ToolStripMenuItem_Click);
            // 
            // 转换ToolStripMenuItem
            // 
            this.转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矢量转栅格ToolStripMenuItem});
            this.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem";
            this.转换ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.转换ToolStripMenuItem.Text = "转换";
            // 
            // 矢量转栅格ToolStripMenuItem
            // 
            this.矢量转栅格ToolStripMenuItem.Name = "矢量转栅格ToolStripMenuItem";
            this.矢量转栅格ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.矢量转栅格ToolStripMenuItem.Text = "矢量转栅格";
            this.矢量转栅格ToolStripMenuItem.Click += new System.EventHandler(this.矢量转栅格ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示矢量图像ToolStripMenuItem,
            this.显示栅格图像ToolStripMenuItem,
            this.显示矢量栅格ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // 显示矢量图像ToolStripMenuItem
            // 
            this.显示矢量图像ToolStripMenuItem.Name = "显示矢量图像ToolStripMenuItem";
            this.显示矢量图像ToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.显示矢量图像ToolStripMenuItem.Text = "显示矢量图像";
            this.显示矢量图像ToolStripMenuItem.Click += new System.EventHandler(this.显示矢量图像ToolStripMenuItem_Click);
            // 
            // 显示栅格图像ToolStripMenuItem
            // 
            this.显示栅格图像ToolStripMenuItem.Name = "显示栅格图像ToolStripMenuItem";
            this.显示栅格图像ToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.显示栅格图像ToolStripMenuItem.Text = "显示栅格图像";
            this.显示栅格图像ToolStripMenuItem.Click += new System.EventHandler(this.显示栅格图像ToolStripMenuItem_Click);
            // 
            // 显示矢量栅格ToolStripMenuItem
            // 
            this.显示矢量栅格ToolStripMenuItem.Name = "显示矢量栅格ToolStripMenuItem";
            this.显示矢量栅格ToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.显示矢量栅格ToolStripMenuItem.Text = "显示矢量+栅格";
            this.显示矢量栅格ToolStripMenuItem.Click += new System.EventHandler(this.显示矢量栅格ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.联系ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 联系ToolStripMenuItem
            // 
            this.联系ToolStripMenuItem.Name = "联系ToolStripMenuItem";
            this.联系ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.联系ToolStripMenuItem.Text = "反馈";
            this.联系ToolStripMenuItem.Click += new System.EventHandler(this.联系ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(853, 499);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 542);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "矢量转栅格";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开e00文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矢量转栅格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示矢量图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示栅格图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示矢量栅格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

