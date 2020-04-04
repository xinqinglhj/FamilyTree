using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class NodeInfo
    {
        public Point[] MyPoints = new Point[2];
        public Person MyPerson = new Person();
        public Rectangle MyRegion = new Rectangle();

        public NodeInfo()
        {

        }
    }
}
