using FamilyTree;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void familyTree1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Key = "01";
            p.Name = "李 三";
            p.PartnerName = "李氏";

            for (int i = 1; i <= 3; i++)
            {
                Person child = new Person();
                child.Key = "010" + i;
                child.Idx = Convert.ToString(i) ;
                child.Name = "李 三" + i;
                child.PartnerName = "李氏" + i;

                //for (int m = 1; m <= 2; m++)
                //{
                if (i == 1 || i ==3)
                {
                    Person child1 = new Person();
                    child1.Key = "010" + i + "0" + i;
                    child1.Idx = Convert.ToString(i);
                    child1.Name = "李 三子" + i;
                    child1.PartnerName = "李氏子" + i;

                    child.ChildNodes.Add(child1);

                    child1 = new Person();
                    child1.Key = "010" + i + "0" + i;
                    child1.Idx = Convert.ToString(i);
                    child1.Name = "李 三子" + i;
                    child1.PartnerName = "李氏子" + i;

                    child.ChildNodes.Add(child1);
                }

                //}

                p.ChildNodes.Add(child);
            }

            familyTreeV31.FTData = p;
            familyTreeV21.FTData = p;
        }

        private void familyTree2_Load(object sender, EventArgs e)
        {
            //familyTree2.ChildClick += FamilyTree2_ChildClick;
        }

        private void FamilyTree2_ChildClick(object sender, EventArgs e)
        {
            NodeInfo ni = sender as NodeInfo;
            MessageBox.Show("你点击的编号：" + ni.MyPerson.Key);
        }

        private void familyTreeV31_Load(object sender, EventArgs e)
        {
            familyTreeV31.ChildClick += FamilyTreeV31_ChildClick;
        }

        private void FamilyTreeV31_ChildClick(object sender, EventArgs e)
        {
            NodeInfo ni = sender as NodeInfo;
            MessageBox.Show("你点击的编号：" + ni.MyPerson.Key);
        }

        private void familyTreeV31_Load_1(object sender, EventArgs e)
        {
            familyTreeV31.ChildClick += FamilyTreeV31_ChildClick;

            familyTreeV31.Width = 1000;
            familyTreeV31.Height = 1000;
        }

        private void familyTreeV21_Load(object sender, EventArgs e)
        {
            familyTreeV21.ChildClick += FamilyTreeV31_ChildClick;

            familyTreeV21.Width = 1000;
            //familyTreeV21.Height = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FTPrintDocument ftp = new FTPrintDocument();
            ftp.ShowDialog();

             
        }
    }
}
