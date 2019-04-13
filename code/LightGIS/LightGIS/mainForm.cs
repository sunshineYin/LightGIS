using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LightGIS
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.MouseWheel += MainForm_MouseWheel;
        }

        Point pOrigin, pMouseDown;  // 记录绘图时图片所放置的点(pOrigin)，记录漫游时鼠标点下去的位置(pMouseDown)
        float zoomRatio;            // 表示放大缩小的倍数
        private bool isMouseDown;   // 判断是否点下鼠标
        int drawMode = 0;   // 绘制（显示）模式：
                            // 0：不显示，1：显示矢量，2：显示栅格，3：显示矢量+栅格

        E00 e00;    // 定义E00对象
        Grid grid;  // 定义Grid对象
        Bitmap vecMap, gridMap; // 待绘制的矢量图(vecMap)和栅格图(gridMap)

        int width, height;  // 显示图像外包矩形长宽信息



        #region 控件事件处理

        private void mainForm_Load(object sender, EventArgs e)
        {
            isMouseDown = false;
            zoomRatio = 1.0f;
            pOrigin = new Point(0, 0);
            pMouseDown = new Point(0, 0);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
        }        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // 显示图像的外包矩形，随缩放、漫游也发生变化
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height); 
            rect.X = pOrigin.X;
            rect.Y = pOrigin.Y;
            rect.Width = (int)(rect.Width * zoomRatio);
            rect.Height = (int)(rect.Height * zoomRatio);
            
            if (drawMode == 1 && vecMap != null)
                g.DrawImage(vecMap, rect, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), GraphicsUnit.Pixel);
            if (drawMode == 2 && gridMap != null)
                g.DrawImage(gridMap, rect, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), GraphicsUnit.Pixel);
            if (drawMode == 3)
            {                
                if (gridMap != null)
                    g.DrawImage(gridMap, rect, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), GraphicsUnit.Pixel);
                if (vecMap != null)
                    g.DrawImage(vecMap, rect, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), GraphicsUnit.Pixel);
            }
        }       

        private void 打开e00文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "E00文件(*.e00)|*.e00|所有文件(*.*)|*.*";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Title = "打开e00文件";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    e00 = new E00(ofd.FileName);    // 实例化e00对象
                    vecMap = e00.ToBitmap(width, height);   // e00对象转换为位图
                    drawMode = 1;
                    pictureBox1.Refresh();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        

        private void 打开栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Grid文件(*.grid)|*.grid|所有文件(*.*)|*.*";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                ofd.Title = "打开栅格文件";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    grid = new Grid(ofd.FileName);  // 实例化grid对象
                    gridMap = grid.ToBitmap();  // grid对象转换为位图
                    drawMode = 2;
                    pictureBox1.Refresh();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 保存栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.OverwritePrompt = true;
            sfd.RestoreDirectory = true;
            sfd.Filter = "Grid文件(*.grid)|*.grid";
            sfd.AddExtension = true;
            sfd.Title = "保存栅格文件";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = sfd.FileName;
                    grid.Save(file);    // 保存成栅格文件
                    MessageBox.Show("成功保存栅格文件!");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        
        private void 矢量转栅格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                grid = e00.ToGrid(width, height);   // 矢量转栅格
                gridMap = grid.ToBitmap();  // 栅格转位图
                drawMode = 2;
                pictureBox1.Refresh();
            }            
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private void 显示矢量图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vecMap == null)
                MessageBox.Show("当前无矢量图层！\n\n请先导入e00文件！");
            else
            {
                drawMode = 1;
                pictureBox1.Refresh();
            }
        }

        private void 显示栅格图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridMap == null)
                MessageBox.Show("当前无栅格图层！\n\n请先执行矢量转栅格或导入栅格文件！");
            else
            {
                drawMode = 2;
                pictureBox1.Refresh();
            }
        }

        
        private void 显示矢量栅格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vecMap == null && gridMap == null)
                MessageBox.Show("当前无矢量和栅格图层！");
            else
            {
                drawMode = 3;
                pictureBox1.Refresh();
            }
        }

        

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GIS小程序：矢量转栅格\n\n尹赣闽 1600012436");
        }


        private void 联系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如有任何疑问请联系 yinganmin@pku.edu.cn 或 18801226837");
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            pictureBox1.Cursor = Cursors.Hand;
            pMouseDown.X = e.Location.X - pOrigin.X;
            pMouseDown.Y = e.Location.Y - pOrigin.Y;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                pOrigin.X = e.Location.X - pMouseDown.X;
                pOrigin.Y = e.Location.Y - pMouseDown.Y;
                pictureBox1.Refresh();
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            pictureBox1.Cursor = Cursors.Default;
        }

        

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (vecMap != null || gridMap != null)
            {
                float oldZoomRatio = zoomRatio;
                zoomRatio += (float)e.Delta / 1000;
                if (zoomRatio < 0)
                    zoomRatio = 0.005f;
                if (zoomRatio > 16)
                    zoomRatio = 16;
                // 改变pOrigin以产生在以鼠标点为中心放大的效果
                pOrigin.X = e.Location.X - (int)(zoomRatio * (e.Location.X - pOrigin.X) / oldZoomRatio);
                pOrigin.Y = e.Location.Y - (int)(zoomRatio * (e.Location.Y - pOrigin.Y) / oldZoomRatio);
                pictureBox1.Refresh();
            }
            //throw new NotImplementedException();
        }

        #endregion


    }
}
