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
    public partial class FamilyTreeV2 : UserControl
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
        public Person FTData = null;

        Size ScrollOffset;

        public FamilyTreeV2()
        {
            InitializeComponent();
            this.AutoScrollMinSize = new Size(1100, 1100);
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

            if (FTData == null)
            {
                CreateFamilyTree2();
            }
            else
            {
                //CreateFamilyTreeTest2Ren();
                CreateFamilyTree(g, FTData, true);
            }
        }

        private void LoadData()
        {
            foreach (Person p in FTData.ChildNodes)
            {

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
            //g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width + ScrollOffset.Width, this.Height + ScrollOffset.Height);
            g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width + ScrollOffset.Width, this.Height + ScrollOffset.Height);

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
            int iCn = 3;

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

        /// <summary>
        /// 创建家谱图
        /// </summary>
        private void CreateFamilyTree(Graphics g, Person argP, bool isFirst, int x1 = 0, int y1 = 0)
        {
            //Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();

            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;

            ////控件边框线
            //g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width + ScrollOffset.Width, this.Height + ScrollOffset.Height);
            g.DrawRectangle(new Pen(Color.Red, 2), 0, 0, this.Width, this.Height);

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

                DrawString("母 " + argP.PartnerName, iD1_X1, iD1_Y1, g);
                DrawString("父 " + argP.Name, iD1_X1 + FTConfig.iPWidth / 2, iD1_Y1, g);
            }
            #endregion

            #region 竖线配置
            //横线中点
            float fCenterX = iCenterX;
            float fCenterY1 = iD1_Y1 + FTConfig.iPHeight;

            float fCenterY2 = fCenterY1 + FTConfig.fHeight;
            //中点竖线
            DrawLine(fCenterX, fCenterY1, fCenterX, fCenterY2, g);
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
                DrawLine(fLineX1, fCenterY2, fLineX2, fCenterY2, g);
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
                    CreatePerson(g, fLineX2, fCenterY2, argP.GetChild(i));
                }
                // 最后
                else if (i == iCn - 1)
                {
                    CreatePerson(g, fLineX2 - fLineWidth, fCenterY2, argP.GetChild(i));
                }
                else
                {
                    CreatePerson(g, fLineX2 - fLineWidth / (iCn - 1) * i, fCenterY2, argP.GetChild(i));
                }
            }
        }

        private void CreatePerson(float x1, float y1)
        {
            #region 竖线 + 姓名框 2
            Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();
            //nodeInfo.MyPerson = argSon;

            //// 竖线X1，X2 和 横线相同
            //// 竖线Y1：= 横线Y1：
            float fSLineX11 = x1;
            float fSLineY11 = y1 + FTConfig.fHeight;

            //// 竖线Y2：中点右移动横线宽度
            //float fSLineY2 = fCenterY2 + FTConfig.fHeight;
            g.DrawLine(new Pen(Color.Red, 1), fSLineX11, y1, fSLineX11, fSLineY11);
            DrawCircular(g, fSLineX11, y1, 8);

            //g.draw
            g.DrawString("子", new Font("宋体", 12), new SolidBrush(Color.DarkOrchid), (Int32)fSLineX11, (Int32)y1, m_strFormat);

            //nodeInfo = new NodeInfo();
            //nodeInfo.MyPerson.Key = "0102";

            int iD22_X1 = (Int32)fSLineX11 - FTConfig.iPWidth / 2;
            int iD22_Y1 = (Int32)fSLineY11;
            CreateRec(iD22_X1, iD22_Y1, g, nodeInfo);

            g.DrawString("妻 李氏", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1, iD22_Y1, m_strFormat);
            g.DrawString("夫 李三", new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), iD22_X1 + FTConfig.iPWidth / 2, iD22_Y1, m_strFormat);

            #endregion
        }

        /// <summary>
        /// 创建竖线和姓名框
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        private void CreatePerson(Graphics g, float x1, float y1, Person argSon)
        {
            #region 竖线 + 姓名框 2
            //Graphics g = this.CreateGraphics();
            NodeInfo nodeInfo = new NodeInfo();
            nodeInfo.MyPerson = argSon;

            //// 竖线X1，X2 和 横线相同
            //// 竖线Y1：= 横线Y1：
            float fSLineX11 = x1;
            float fSLineY11 = y1 + FTConfig.fHeight;

            //// 竖线Y2：中点右移动横线宽度
            //float fSLineY2 = fCenterY2 + FTConfig.fHeight;
            DrawLine(fSLineX11, y1, fSLineX11, fSLineY11, g);
            DrawCircular(g, fSLineX11, y1, 8);

            //g.draw
            DrawString(argSon.Idx + "子", (Int32)fSLineX11, (Int32)y1, g);

            //nodeInfo = new NodeInfo();
            //nodeInfo.MyPerson.Key = "0102";

            int iD22_X1 = (Int32)fSLineX11 - FTConfig.iPWidth / 2;
            int iD22_Y1 = (Int32)fSLineY11;
            CreateRec(iD22_X1, iD22_Y1, g, nodeInfo);

            DrawString("妻 " + argSon.PartnerName, iD22_X1, iD22_Y1, g);
            DrawString("夫 " + argSon.Name, iD22_X1 + FTConfig.iPWidth / 2, iD22_Y1, g);

            #endregion

            if (argSon.GetChildCount() > 0)
            {
                CreateFamilyTree(g, argSon, false, iD22_X1, iD22_Y1);
            }
        }

        /// <summary>
        /// 画圆点
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y2"></param>
        /// <param name="argD"></param>
        private void DrawCircular(Graphics g, float x1, float y2, float argD)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y2 = y2 + ScrollOffset.Height;

            //Graphics g = this.CreateGraphics();
            for (int r = 0; r < argD / 2; r++)
            {
                //DrawEllipse(x1 - r, r * 2, y2 - r, r * 2, g);
                g.DrawEllipse(new Pen(Color.Blue, 1),   x1 - r, y2 - r, r * 2, r * 2);
                //g.DrawEllipse(new Pen(Color.Blue, 1), x1, y2, x2, y2);
            }
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
            ////控件边框线
            //DrawRectangle(0, 0, this.Width, this.Height, this.CreateGraphics());//m_personLst
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

        /// <summary>
        /// 判断点击点是否在点击区域
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 文本
        /// </summary>
        /// <param name="argText"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="g"></param>
        private void DrawString(String argText, int x1, int y1, Graphics g)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;
            // TODO
            g.DrawString(argText, new Font("宋体", 10), new SolidBrush(Color.DarkOrchid), x1, y1, m_strFormat);
        }

        /// <summary>
        /// 画线
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="g"></param>
        private void DrawLine(float x1, float y1, float x2, float y2, Graphics g)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;

            //x2 = x2 + ScrollOffset.Width;
            //y2 = y2 + ScrollOffset.Height;

            g.DrawLine(new Pen(Color.Red, 1), x1, y1, x2, y2);
        }

        /// <summary>
        /// 画椭圆
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="g"></param>
        private void DrawEllipse(float x1, float y1, float x2, float y2, Graphics g)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;

            //x2 = x2 + ScrollOffset.Width;
            //y2 = y2 + ScrollOffset.Height;

            g.DrawEllipse(new Pen(Color.Blue, 1), x1, y2, x2, y2);
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="argWidth"></param>
        /// <param name="argHeight"></param>
        /// <param name="g"></param>
        private void DrawRectangle(float x1, float y1, float argWidth, float argHeight, Graphics g)
        {
            //x1 = x1 + ScrollOffset.Width;
            //y1 = y1 + ScrollOffset.Height;

            g.DrawRectangle(new Pen(Color.Red, 2), x1, y1, argWidth, argHeight);
        }

        #region 滑动条被唤醒颜色
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("My我的属性")]
        [System.ComponentModel.Description("滑动条被唤醒的颜色")]
        [System.ComponentModel.DefaultValue(null)]
        public Color LineColor { get; set; }
        #endregion
    }
}
