using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LightGIS
{
    /// <summary>
    /// Arc数据结构
    /// </summary>
    public struct Arc
    {
        public int ID, LPoly, RPoly, PointCount;
        public PointF[] points;
    }

    /// <summary>
    /// E00数据结构
    /// </summary>
    public class E00
    {
        #region 字段

        private float minX, maxX, minY, maxY;       // 宇宙多边形外包矩形信息，用于转换成位图而在屏幕上显示
        private List<Arc> arcs = new List<Arc>();   // 弧段列表，实际弧段坐标信息
        //private List<Arc> arcs_in_pbox = new List<Arc>();
        private Arc[] arcs_in_pbox; // 在picturebox中绘制时用到的弧段列表，可理解为屏幕显示的弧段

        #endregion

        #region 构造函数
        public E00()
        {
        }

        /// <summary>
        /// 读取E00文件，创建E00对象
        /// </summary>
        /// <param name="file"></param>
        public E00(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            // 将e00文件按照分隔符分开，并返回非空字串
            string[] separators = new string[] { " ", "\n" };
            string[] data = sr.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < data.Length; i++)
            {
                // 读取弧段信息
                if (data[i].Equals("ARC"))
                {
                    i += 2;
                    while (true)
                    {
                        Arc temp = new Arc();
                        if (-1 == Convert.ToInt32(data[i])) // 终止弧段
                            break;
                        temp.ID = Convert.ToInt32(data[i + 1]);
                        temp.LPoly = Convert.ToInt32(data[i + 4]);
                        temp.RPoly = Convert.ToInt32(data[i + 5]);
                        temp.PointCount = Convert.ToInt32(data[i + 6]);
                        i += 7;
                        temp.points = new PointF[temp.PointCount];
                        for (int j = 0; j < temp.PointCount; j++)
                        {
                            temp.points[j].X = Convert.ToSingle(data[i]);
                            temp.points[j].Y = Convert.ToSingle(data[i + 1]);
                            i += 2;
                        }
                        arcs.Add(temp);
                        //arcs_in_pbox.Add(temp);
                    }
                    arcs_in_pbox = new Arc[arcs.Count];
                    arcs_in_pbox = arcs.ToArray();
                }
                // 读取宇宙多边形外包矩形信息
                if (data[i].Equals("PAL"))
                {
                    i += 3;
                    minX = Convert.ToSingle(data[i]);
                    minY = Convert.ToSingle(data[i + 1]);
                    maxX = Convert.ToSingle(data[i + 2]);
                    maxY = Convert.ToSingle(data[i + 3]);
                    break;
                }
            }
            
        }

        #endregion

        #region 属性

        public float MinX
        {
            get { return minX; }
            set { minX = value; }
        }

        public float MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        public float MinY
        {
            get { return minY; }
            set { minY = value; }
        }

        public float MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }
        
        /*
        public Arc[] Arcs_in_pbox
        {
            get {return arcs_in_pbox.ToArray();}
            set 
            {
                arcs_in_pbox.Clear();
                arcs_in_pbox.AddRange(value);
            }
        }
        */

        public Arc[] Arcs_in_pbox
        {
            get { return arcs_in_pbox; }
            set { arcs_in_pbox = value; }
        }

        #endregion

        #region 方法

        
        /// <summary>
        /// 将E00对象转换为Bitmap
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap ToBitmap(int width, int height)
        {
            Bitmap vecBmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(vecBmp);
            Pen pen = new Pen(Color.Black, 1);
            // 设定一个缩放系数，使得绘制结果能完全显示在picturebox中
            float scale = 1.1f * Math.Max((maxX - minX) / width, (maxY - minY) / height);

            // 对显示弧段做修改
            for (int i=0; i<arcs_in_pbox.Length; i++)
            {
                for (int j=0; j<arcs_in_pbox[i].PointCount; j++)
                {                    
                    arcs_in_pbox[i].points[j].X = (arcs_in_pbox[i].points[j].X - minX) / scale;
                    // 屏幕坐标与实际坐标纵轴方向相反，为避免Y方向上的变形，这里采用maxY做参考值
                    arcs_in_pbox[i].points[j].Y = (maxY - arcs_in_pbox[i].points[j].Y) / scale; 
                    if (j > 0)
                        g.DrawLine(pen, arcs_in_pbox[i].points[j - 1], arcs_in_pbox[i].points[j]);
                }
            }
            pen.Dispose();
            g.Dispose();

            return vecBmp;
        }
        
        /// <summary>
        /// 将E00对象转换为Grid对象，采用边界代数法
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Grid ToGrid(int width, int height)
        {
            Grid grid = new Grid();
            //{
            //    Row = height,
            //    Col = width
            //};
            grid.Row = height;
            grid.Col = width;
            grid.GridArray = new int[width, height];
            // 初始化Grid对象阵列值都为0
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    grid.GridArray[i, j] = 0;
            // 边界代数算法核心部分
            for (int i = 0; i < arcs_in_pbox.Length; i++)
            {
                Point start, end;
                int value = arcs_in_pbox[i].LPoly - arcs_in_pbox[i].RPoly;  // 设定值为左多边形序号减去右多边形序号
                for (int j = 0; j < arcs_in_pbox[i].PointCount - 1; j++)
                {
                    // 找到每一小弧段端点最近的像素点（整数点）
                    start = new Point((int)(arcs_in_pbox[i].points[j].X + 0.5), (int)(arcs_in_pbox[i].points[j].Y + 0.5));
                    end = new Point((int)(arcs_in_pbox[i].points[j + 1].X + 0.5), (int)(arcs_in_pbox[i].points[j + 1].Y + 0.5));
                    // 线段下行，注意屏幕坐标与实际坐标的纵轴方向相反
                    if (end.Y > start.Y)
                    {
                        for (int currentY = start.Y; currentY < end.Y; currentY++)
                        {
                            // 直线方程，小弧段上currentY对应的x坐标
                            int lineX = (currentY * (end.X - start.X) - start.Y * end.X + end.Y * start.X) / (end.Y - start.Y); 
                            for (int currentX = 0; currentX <= lineX; currentX++)
                                grid.GridArray[currentX, currentY] -= value;    
                                //grid.GridArray[currentY, currentX] += value;
                        }
                    }
                    // 线段上行
                    if (end.Y < start.Y)
                    {
                        for (int currentY = end.Y; currentY < start.Y; currentY++)
                        {
                            // 直线方程，小弧段上currentY对应的x坐标
                            int lineX = (currentY * (end.X - start.X) - start.Y * end.X + end.Y * start.X) / (end.Y - start.Y);
                            for (int currentX = 0; currentX <= lineX; currentX++)
                                grid.GridArray[currentX, currentY] += value;
                                //grid.GridArray[currentY, currentX] -= value;
                        }
                    }
                }
            }

            return grid;
        }



        #endregion

    }

    /// <summary>
    /// Grid数据结构，并自定义数据文件格式
    /// </summary>
    public class Grid
    {
        #region 字段

        private int col, row;
        private int[,] grid;

        #endregion

        #region 构造函数

        public Grid()
        {

        }

        /// <summary>
        /// 读取grid文件，创建Grid对象
        /// </summary>
        /// <param name="file"></param>
        public Grid(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            //string[] data;
            // 将grid文件按照分隔符分开，并返回非空字串
            char[] splitchar = new char[] { ' ' };
            // 读取文件头
            string[] data = sr.ReadLine().Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
            if (data.Count() != 2)
            {
                MessageBox.Show("文件格式错误");  // 因为是自定义格式，所以需要做格式判断
                return;
            }

            // 初始化文件头信息
            row = Convert.ToInt32(data[0]);
            col = Convert.ToInt32(data[1]);
            grid = new int[col, row];

            string temp;
            int j = 0;
            // 读取栅格阵列数据
            while ((temp = sr.ReadLine()) != null)  // 逐行读取
            {
                data = temp.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);
                if (data.Count() != col)
                {
                    MessageBox.Show("文件格式错误");
                    return;
                }
                for (int i = 0; i < col; i++)   // 行内逐个像素读取
                {
                    grid[i, j] = Convert.ToInt32(data[i]);
                }
                j++;
            }
        }

        #endregion

        #region 属性

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int[,] GridArray
        {
            get { return grid; }
            set { grid = value; }
            //
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将Grid对象转换为Bitmap
        /// </summary>
        /// <returns></returns>
        public Bitmap ToBitmap()
        {
            Bitmap gridBmp = new Bitmap(col, row);
            // 随机生成颜色数组
            Color[] colors = new Color[21];
            // 以时间为随机数种子，生成随机数
            System.Random r = new Random(System.DateTime.Now.Second);
            System.Random g = new Random(System.DateTime.Now.Minute);
            System.Random b = new Random(System.DateTime.Now.Hour);
            // 保证宇宙多边形（以外）为透明
            colors[0] = System.Drawing.Color.Transparent;
            // 生成随机颜色
            for (int i = 1; i < colors.Count(); i++)
            {
                colors[i] = Color.FromArgb(r.Next(256), g.Next(256), b.Next(256));
                //System.Console.Write(colors[i].ToString());
            }

            //MessageBox.Show(colors[1].ToString() + '\n' + colors[2].ToString());

            // 根据栅格阵列数据，填充位图
            for (int i = 0; i < col * row; i++)
            {
                if (grid[i % col, row - i / col - 1] < 0)
                {
                    gridBmp.SetPixel(i % col, row - i / col - 1, colors[20]);
                    continue;
                }
                gridBmp.SetPixel(i % col, row - i / col - 1, colors[grid[i % col, row - i / col - 1] % 20]);
            }
            return gridBmp;
        }

        /// <summary>
        /// 保存成Grid文件
        /// </summary>
        /// <param name="file"></param>
        public void Save(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            // 写入数据
            string temp = "";
            temp = row.ToString() + " " + col.ToString();
            sw.WriteLine(temp);
            for (int i = 0; i < row; i++)
            {
                temp = "";
                for (int j = 0; j < col; j++)
                    temp += (grid[j, i].ToString() + " ");
                sw.WriteLine(temp);
            }

            // 清空缓冲区
            sw.Flush();
            // 关闭流对象
            sw.Close();
            fs.Close();
        }


        #endregion
    }
}
