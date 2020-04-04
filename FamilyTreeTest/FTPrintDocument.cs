using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTreeTest
{
    public partial class FTPrintDocument : Form
    {
        public FTPrintDocument()
        {
            InitializeComponent();
        }

        private void FTPrintDocument_Load(object sender, EventArgs e)
        {
            
            printPreviewDialog1.ShowDialog();

            //printDialog1.ShowDialog();

            //pageSetupDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //显示内容
            string text = "In document_PrintPage method.";
            //设置字体
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 35, System.Drawing.FontStyle.Regular);
            e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 0, 0);

            for (int i = 1;i < 2500; i=i +40)
            {
                e.Graphics.DrawString(text + i, printFont, System.Drawing.Brushes.Black, 0, i);
            }
            
        }
    }
}
