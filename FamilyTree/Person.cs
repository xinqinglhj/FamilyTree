using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    /// <summary>
    /// 个人信息
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 主键（身份证号）
        /// </summary>
        public String Key;

        /// <summary>
        /// 父母
        /// </summary>
        public Person ParentsNode;

        /// <summary>
        /// 孩子（复数）
        /// </summary>
        public ArrayList ChildNodes = new ArrayList();

        /// <summary>
        /// 配偶
        /// </summary>
        public Person Partner;

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name;

        /// <summary>
        /// 排行
        /// </summary>
        public String Idx;

        /// <summary>
        /// 配偶姓名
        /// </summary>
        public String PartnerName;

        /// <summary>
        /// 年龄
        /// </summary>
        public String Age;

        /// <summary>
        /// 性别
        /// </summary>
        public ESex Sex;

        /// <summary>
        /// 生日
        /// </summary>
        public String Birthday;

        /// <summary>
        /// 忌日
        /// </summary>
        public String DateOfDeath;

        /// <summary>
        /// 孩子的数量
        /// </summary>
        /// <returns></returns>
        public int GetChildCount()
        {
            if (ChildNodes != null)
            {
                return ChildNodes.Count;
            }

            return 0;
        }

        /// <summary>
        /// 得到指定孩子
        /// </summary>
        /// <param name="argIdx"></param>
        /// <returns></returns>
        public Person GetChild(int argIdx)
        {
            if (ChildNodes != null && argIdx < ChildNodes.Count)
            {
                return (Person)ChildNodes[argIdx];
            }

            return null;
        }
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum ESex
    {
        /// <summary>
        /// 女
        /// </summary>
        F,

        /// <summary>
        /// 男
        /// </summary>
        M
    }
}
