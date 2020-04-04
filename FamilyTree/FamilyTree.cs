using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FamilyTree
{
    public partial class FamilyTree : UserControl
    {
        /// <summary>
        /// 定义委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void MyClickHandle(object sender, EventArgs e);

        /// <summary>
        /// 定义事件（点击孩子图形事件）
        /// </summary>
        public event MyClickHandle ChildClick;

        //private List<Person> m_personLst = new List<Person>();
        //private List<NodeInfo> m_nodeInfo = new List<NodeInfo>();
        Hashtable m_ht = new Hashtable();

        //姓名框配置
        private int m_iPWidth = 30;
        private int m_iPHeight = 80;
        //开始高度
        private int m_iStartHeight = 140;

        // 竖排
        StringFormat m_strFormat = new StringFormat(StringFormatFlags.DirectionVertical);
        //StrF.FormatFlags = StringFormatFlags.DirectionVertical;
        /// <summary>
        /// 家谱数据源
        /// </summary>
        public Person FTData = new Person();

        Size ScrollOffset;

        public FamilyTree()
        {
            InitializeComponent();
            this.AutoScrollMinSize = new Size(800, 600);
        }

        /// <summary>
        /// 画图事件处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ScrollOffset = new Size(this.AutoScrollPosition);

            Graphics g = e.Graphics;
            g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            //this.AutoScrollMinSize = new Size(800, 600);

            //CreateFamilyTreeTest2Ren();
            CreateFamilyTree(FTData, true);
        }

        private void LoadData()
        {
            foreach (Person p in FTData.ChildNodes)
            {

            }
        }

        private void CreateFamilyTreeTest2Ren()
        {
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();

            //控件边框线
            g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width, this.Height);

            #region 第一世代
            // 中点位置
            int iCenterX = this.Width / 2;

            // 开始位置：中点位置左移 姓名框的宽度的一半
            int iD1_X1 = iCenterX - FTConfig.iPWidth / 2;
            // 开始Y坐标
            int iD1_Y1 = FTConfig.iTop;

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "01";
            CreateRec(iD1_X1, iD1_Y1, g, nodeInfo);

            g.DrawString("母 张 氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1, iD1_Y1, m_strFormat);
            g.DrawString("父 张老大", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1 + FTConfig.iPWidth / 2, iD1_Y1, m_strFormat);
            #endregion

            #region 竖线配置
            //横线中点
            float fCenterX = iCenterX;
            float fCenterY1 = iD1_Y1 + FTConfig.iPHeight;

            float fCenterY2 = fCenterY1 + FTConfig.fHeight;
            //中点竖线
            g.DrawLine(new Pen(Color.Red, 1), fCenterX, fCenterY1, fCenterX, fCenterY2);
            #endregion

            #region 横线配置
            //人数
            int iCn = 2;
            float fLineWidth = FTConfig.fLineWidth * iCn;

            // 横线X1：中点左移横线一半的宽度
            float fLineX1 = fCenterX - fLineWidth / 2;

            // 横线X2：X1右移动横线宽度
            float fLineX2 = fLineX1 + fLineWidth;
            g.DrawLine(new Pen(Color.Red, 1), fLineX1, fCenterY2, fLineX2, fCenterY2);
            
            #endregion

            #region 竖线 + 姓名框
            //// 竖线X1，X2 和 横线相同
            //// 竖线Y1：= 横线Y1：
            //float fSLineY1 = fCenterX - fLineWidth / 2;

            // 竖线Y2：中点右移动横线宽度
            float fSLineY2 = fCenterY2 + FTConfig.fHeight;
            g.DrawLine(new Pen(Color.Red, 1), fLineX2, fCenterY2, fLineX2, fSLineY2);
            g.DrawString("长子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), (Int32)fLineX2, (Int32)fCenterY2, m_strFormat);

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "0101";

            int iD21_X1 = (Int32)fLineX2 - FTConfig.iPWidth / 2;
            int iD21_Y1 = (Int32)fSLineY2;
            CreateRec(iD21_X1, iD21_Y1, g, nodeInfo);
            g.DrawString("妻 张 氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD21_X1, iD21_Y1, m_strFormat);
            g.DrawString("夫 张老大", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD21_X1 + FTConfig.iPWidth / 2, iD21_Y1, m_strFormat);

            #endregion

            #region 竖线 + 姓名框
            //// 竖线X1，X2 和 横线相同
            //// 竖线Y1：= 横线Y1：
            float fSLineX11 = fLineX2 - fLineWidth;

            //// 竖线Y2：中点右移动横线宽度
            //float fSLineY2 = fCenterY2 + FTConfig.fHeight;
            g.DrawLine(new Pen(Color.Red, 1), fSLineX11, fCenterY2, fSLineX11, fSLineY2);
            g.DrawString("次子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), (Int32)fSLineX11, (Int32)fCenterY2, m_strFormat);

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "0102";

            int iD22_X1 = (Int32)fSLineX11 - FTConfig.iPWidth / 2;
            int iD22_Y1 = (Int32)fSLineY2;
            CreateRec(iD22_X1, iD22_Y1, g, nodeInfo);
            g.DrawString("妻 张 氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1, iD22_Y1, m_strFormat);
            g.DrawString("夫 张老大", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1 + FTConfig.iPWidth / 2, iD22_Y1, m_strFormat);

            #endregion
        }

        /// <summary>
        /// 创建家谱图
        /// </summary>
        private void CreateFamilyTree(Person argP, bool isFirst, int x1 = 0, int y1 = 0)
        {
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();

            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;

            //控件边框线
            g.DrawRectangle(new Pen(Color.Red, 2), 0 , 0, this.Width, this.Height);

            #region 第一世代
            // 中点位置（控件宽度的中点）
            int iCenterX = x1 + FTConfig.iPWidth / 2;

            // 开始位置：中点位置左移 姓名框的宽度的一半
            int iD1_X1 = iCenterX - FTConfig.iPWidth / 2;
            // 开始Y坐标
            int iD1_Y1 = y1;

            if (isFirst)
            {
                // 中点位置（控件宽度的中点）
                iCenterX = this.Width / 2;

                // 开始位置：中点位置左移 姓名框的宽度的一半
                iD1_X1 = iCenterX - FTConfig.iPWidth / 2;
                // 开始Y坐标
                iD1_Y1 = FTConfig.iTop;

                nodeInfo = new NodeInfo();
                nodeInfo.MyPerson = argP;
                //nodeInfo.MyPerson.Key = "01";
                CreateRec(iD1_X1, iD1_Y1, g, nodeInfo);

                g.DrawString("母 " + argP.PartnerName, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1, iD1_Y1, m_strFormat);
                g.DrawString("父 " + argP.Name, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1 + FTConfig.iPWidth / 2, iD1_Y1, m_strFormat);
            }
            #endregion

            #region 竖线配置
            //横线中点
            float fCenterX = iCenterX;
            float fCenterY1 = iD1_Y1 + FTConfig.iPHeight;

            float fCenterY2 = fCenterY1 + FTConfig.fHeight;
            //中点竖线
            g.DrawLine(new Pen(Color.Red, 1), fCenterX, fCenterY1, fCenterX, fCenterY2);
            #endregion

            #region 横线配置（子世代为复数时才会配置）
            //人数
            int iCn = argP.GetChildCount();

            // 横线的长度
            float fLineWidth = 0;

            // 横线X1：中点左移横线一半的宽度
            float fLineX1 = fCenterX;

            // 横线X2：X1右移动横线宽度
            float fLineX2 = fLineX1;

            // 只有一个子代的时候不需要画横线
            if(iCn != 1)
            {
                // 横线的长度
                fLineWidth = FTConfig.fLineWidth * iCn;

                // 横线X1：中点左移横线一半的宽度
                fLineX1 = fCenterX - fLineWidth / 2;

                // 横线X2：X1右移动横线宽度
                fLineX2 = fLineX1 + fLineWidth;
                g.DrawLine(new Pen(Color.Red, 1), fLineX1, fCenterY2, fLineX2, fCenterY2);
            }
            #endregion

            #region 测试
            //if (iCn == 2)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 3)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 4)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 5)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 3, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            #endregion

            //遍历生成子世代图
            for (int i = 0; i<= iCn - 1; i++)
            {
                if (i == 0)
                {
                    CreatePerson(fLineX2, fCenterY2, argP.GetChild(i));
                }
                // 最后
                else if (i == iCn - 1)
                {
                    CreatePerson(fLineX2 - fLineWidth, fCenterY2, argP.GetChild(i));
                }
                else
                {
                    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * i, fCenterY2, argP.GetChild(i));
                }
            }
        }

        /// <summary>
        /// 创建家谱图
        /// </summary>
        private void CreateFamilyTree2()
        {
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();

            //控件边框线
            g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width, this.Height);

            #region 第一世代
            // 中点位置（控件宽度的中点）
            int iCenterX = this.Width / 2;

            // 开始位置：中点位置左移 姓名框的宽度的一半
            int iD1_X1 = iCenterX - FTConfig.iPWidth / 2;
            // 开始Y坐标
            int iD1_Y1 = FTConfig.iTop;

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "01";
            CreateRec(iD1_X1, iD1_Y1, g, nodeInfo);

            g.DrawString("母 张 氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1, iD1_Y1, m_strFormat);
            g.DrawString("父 张老大", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD1_X1 + FTConfig.iPWidth / 2, iD1_Y1, m_strFormat);
            #endregion

            #region 竖线配置
            //横线中点
            float fCenterX = iCenterX;
            float fCenterY1 = iD1_Y1 + FTConfig.iPHeight;

            float fCenterY2 = fCenterY1 + FTConfig.fHeight;
            //中点竖线
            g.DrawLine(new Pen(Color.Red, 1), fCenterX, fCenterY1, fCenterX, fCenterY2);
            #endregion

            #region 横线配置（子世代为复数时才会配置）
            //人数
            int iCn = 8;

            // 横线的长度
            float fLineWidth = 0;

            // 横线X1：中点左移横线一半的宽度
            float fLineX1 = fCenterX;

            // 横线X2：X1右移动横线宽度
            float fLineX2 = fLineX1;

            // 只有一个子代的时候不需要画横线
            if (iCn != 1)
            {
                // 横线的长度
                fLineWidth = FTConfig.fLineWidth * iCn;

                // 横线X1：中点左移横线一半的宽度
                fLineX1 = fCenterX - fLineWidth / 2;

                // 横线X2：X1右移动横线宽度
                fLineX2 = fLineX1 + fLineWidth;
                g.DrawLine(new Pen(Color.Red, 1), fLineX1, fCenterY2, fLineX2, fCenterY2);
            }
            #endregion

            #region 测试
            //if (iCn == 2)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 3)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 4)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            //else if (iCn == 5)
            //{
            //    CreatePerson(fLineX2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1), fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 2, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * 3, fCenterY2);
            //    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
            //}
            #endregion

            //遍历生成子世代图
            for (int i = 0; i <= iCn - 1; i++)
            {
                if (i == 0)
                {
                    CreatePerson(fLineX2, fCenterY2);
                }
                // 最后
                else if (i == iCn - 1)
                {
                    CreatePerson(fLineX2 - fLineWidth, fCenterY2);
                }
                else
                {
                    CreatePerson(fLineX2 - fLineWidth / (iCn - 1) * i, fCenterY2);
                }
            }
        }

        private void CreatePerson(float x1, float y1)
        {

        }

        /// <summary>
        /// 创建竖线和姓名框
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        private void CreatePerson(float x1, float y1, Person argSon)
        {
            #region 竖线 + 姓名框 2
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();
            nodeInfo.MyPerson = argSon;

            //// 竖线X1，X2 和 横线相同
            //// 竖线Y1：= 横线Y1：
            float fSLineX11 = x1;
            float fSLineY11 = y1 + FTConfig.fHeight;

            //// 竖线Y2：中点右移动横线宽度
            //float fSLineY2 = fCenterY2 + FTConfig.fHeight;
            g.DrawLine(new Pen(Color.Red, 1), fSLineX11, y1, fSLineX11, fSLineY11);
            DrawCircular(fSLineX11, y1, 8);

            //g.draw
            g.DrawString(argSon.Idx + "子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), (Int32)fSLineX11, (Int32)y1, m_strFormat);

            //nodeInfo = new NodeInfo();
            //nodeInfo.MyPerson.Key = "0102";

            int iD22_X1 = (Int32)fSLineX11 - FTConfig.iPWidth / 2;
            int iD22_Y1 = (Int32)fSLineY11;
            CreateRec(iD22_X1, iD22_Y1, g, nodeInfo);

            g.DrawString("妻 " + argSon.PartnerName, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1, iD22_Y1, m_strFormat);
            g.DrawString("夫 " + argSon.Name, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1 + FTConfig.iPWidth / 2, iD22_Y1, m_strFormat);

            #endregion

            if (argSon.GetChildCount() > 0)
            {
                CreateFamilyTree(argSon, false, iD22_X1, iD22_Y1);
            }
        }

        /// <summary>
        /// 画圆点
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y2"></param>
        /// <param name="argD"></param>
        private void DrawCircular(float x1, float y2, float argD)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y2 = y2 + ScrollOffset.Height;

            Graphics g = this.CreateGraphics();
            for (int r = 0; r < argD / 2; r++)
            {
                g.DrawEllipse(new Pen(Color.Blue, 1),
                    x1 - r, y2 - r, r * 2, r * 2);
            }
        
            g.Dispose();
        }
        private void CreateFamilyTreeTest2()
        {
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();

            //控件边框线
            g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width, this.Height);

            //短竖线高度()
            float fDHeight = 40;

            //横线配置
            float x1 = 25;
            float iWith = this.Width - x1 * 2;
            float x2 = x1 + iWith;
            float y1 = m_iStartHeight;//开始高度
            float y2 = y1;
            //横线描绘
            g.DrawLine(new Pen(Color.Red, 1), x1, y1, x2, y2);
            g.DrawString("次子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), x1, y1, m_strFormat);

            g.DrawString("长子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), x2, y2, m_strFormat);

            //横线中点
            float fCenterX = x1 + (x2 - x1) / 2;
            float fCenterY1 = y1;
            float fCenterY2 = fCenterY1 - fDHeight;
            //中点竖线
            g.DrawLine(new Pen(Color.Red, 1), fCenterX, fCenterY1, fCenterX, fCenterY2);

            #region 创建父节点图形
            //顶部图形
            int iTopX = Convert.ToInt32(fCenterX) - 15;//图形剧中
            int iTopY = Convert.ToInt32(fCenterY2) - m_iPHeight;

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "01";
            nodeInfo.MyPoints[0] = new Point(iTopX, iTopY);

            CreateRec(iTopX, iTopY, g, nodeInfo);
            g.DrawString("母 张 氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iTopX, iTopY, m_strFormat);
            g.DrawString("父 张老大", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iTopX + m_iPWidth / 2, iTopY, m_strFormat);
            DebugLog("母 张 氏:" + iTopX + iTopY);
            #endregion

            #region 竖线配置
            //竖线的高度
            float fHeight = 40;

            //左侧线的配置
            float fLeftLineX1 = x1;
            float fLeftLineY1 = y1;

            float fLeftLineX2 = x1;
            float fLeftLineY2 = y1 + fHeight;

            g.DrawLine(new Pen(Color.Red, 1), fLeftLineX1, fLeftLineY1, fLeftLineX2, fLeftLineY2);


            //右侧线的配置
            float fRightLineX1 = x2;
            float fRightLineY1 = y1;

            float fRightLineX2 = x2;
            float fRightY2 = y1 + fHeight;
            g.DrawLine(new Pen(Color.Red, 1), fRightLineX1, fRightLineY1, fRightLineX2, fRightY2);
            #endregion

            #region 子图形配置
            //左侧下方图形
            int iPWidth = 30;
            int iPHeight = 80;
            int iBottomLX = Convert.ToInt32(fRightLineX1) - 15;//图形剧中
            int iBottomLY = Convert.ToInt32(fLeftLineY2);

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "0101";
            nodeInfo.MyPoints[0] = new Point(iBottomLX, iBottomLY);

            //Rectangle rec = new Rectangle(iBottomX, iBottomY, iPWidth, iPHeight);
            //g.DrawRectangle(new Pen(Color.Red, 1), rec);
            CreateRec(iBottomLX, iBottomLY, g, nodeInfo);

            //右侧下方图形
            int iBottomRX = Convert.ToInt32(fLeftLineX1) - 15;//图形剧中
            int iBottomRY = Convert.ToInt32(fRightY2);

            nodeInfo = new NodeInfo();
            nodeInfo.MyPerson.Key = "0102";
            nodeInfo.MyPoints[0] = new Point(iBottomRX, iBottomRY);

            CreateRec(iBottomRX, iBottomRY, g, nodeInfo);
            #endregion
        }

        /// <summary>
        /// 创建人物图形
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="g">绘图图面</param>
        private void CreateRec(int x, int y, Graphics g, NodeInfo argNodeinfo)
        {
            //int iPWidth = 30;
            //int iPHeight = 80;
            //x = x + ScrollOffset.Width;
            //y = y + ScrollOffset.Height;

            Rectangle rec = new Rectangle(x, y, m_iPWidth, m_iPHeight);
            g.DrawRectangle(new Pen(Color.Red, 1), rec);
            
            argNodeinfo.MyRegion = rec;
            argNodeinfo.MyPoints[0] = new Point(x, y);
            argNodeinfo.MyPoints[1] = new Point(x + m_iPWidth, y + m_iPHeight);

            AddChild(argNodeinfo);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            MouseEventArgs me = (MouseEventArgs)e;
            CheckPntInPoly(me);

            DebugLog("x,y:" + me.X +"," + me.Y);
        }
        private void FamilyTree_Load(object sender, EventArgs e)
        {
            //m_personLst
        }

        private void DebugLog(string argStr)
        {
#if DEBUG
            Console.WriteLine(argStr);
#endif
        }

        /// <summary>
        /// 添加节点（人员信息，位置信息）
        /// </summary>
        /// <param name="argNodeInfo"></param>
        public void AddChild(NodeInfo argNodeInfo)
        {
            if (!String.IsNullOrEmpty(argNodeInfo.MyPerson.Key) && !m_ht.ContainsKey(argNodeInfo.MyPerson.Key))
            {
                m_ht.Add(argNodeInfo.MyPerson.Key, argNodeInfo);
            }
        }

        private bool CheckPntInPoly(MouseEventArgs e)
        {
            foreach (DictionaryEntry de in m_ht)
            {
                NodeInfo ni = (NodeInfo)de.Value;

                if (ni.MyRegion.Contains(e.X, e.Y))
                {
                    if (ChildClick != null)
                    {
                        // 触发事件
                        ChildClick(ni, e);
                    }

                    return true;
                }
            }
            return false;
        }

        private void DrawString(String argText, int x1, int y1, Graphics g)
        {
            x1 = x1 + ScrollOffset.Width;
            y1 = y1 + ScrollOffset.Height;
            g.DrawString(argText, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), x1, y1, m_strFormat);
        }

        private void DrawLine(int x1, int y1, int x2, int y2, Graphics g)
        {
            x1 = x1 + ScrollOffset.Width;
            y1 = y1 + ScrollOffset.Height;

            x2 = x2 + ScrollOffset.Width;
            y2 = y2 + ScrollOffset.Height;

            g.DrawLine(new Pen(Color.Red, 1), x1, y1, x2, y2);
        }

        private void DrawEllipse(int x1, int y1, int x2, int y2, Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Blue, 1),
                   x1, y2, x2, y2);
        }
        //private bool CheckPntInPoly(Point[] points, Point pnt)
        //{
        //    if (points == null || points.Length == 0 || pnt == Point.Empty)
        //    {
        //        return false;
        //    }

        //    System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
        //    Region myRegion = new Region();
        //    myGraphicsPath.Reset();
        //    myGraphicsPath.AddPolygon(points);

        //    myRegion.MakeEmpty();
        //    myRegion.Union(myGraphicsPath);

        //    //返回判断点是否在多边形里
        //    return myRegion.IsVisible(pnt);
        //}
    }
}
