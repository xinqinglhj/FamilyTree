namespace FamilyTreeTest
{
    partial class Form1
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
            this.familyTreeV21 = new FamilyTree.FamilyTreeV2();
            this.familyTreeV31 = new FamilyTree.FamilyTreeV3();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // familyTreeV21
            // 
            this.familyTreeV21.AutoScroll = true;
            this.familyTreeV21.AutoScrollMinSize = new System.Drawing.Size(600, 800);
            this.familyTreeV21.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.familyTreeV21.Location = new System.Drawing.Point(97, 18);
            this.familyTreeV21.Name = "familyTreeV21";
            this.familyTreeV21.Size = new System.Drawing.Size(786, 386);
            this.familyTreeV21.TabIndex = 1;
            this.familyTreeV21.Load += new System.EventHandler(this.familyTreeV21_Load);
            // 
            // familyTreeV31
            // 
            this.familyTreeV31.AutoScroll = true;
            this.familyTreeV31.AutoScrollMinSize = new System.Drawing.Size(800, 600);
            this.familyTreeV31.Location = new System.Drawing.Point(12, 12);
            this.familyTreeV31.Name = "familyTreeV31";
            this.familyTreeV31.Size = new System.Drawing.Size(379, 305);
            this.familyTreeV31.TabIndex = 0;
            this.familyTreeV31.Visible = false;
            this.familyTreeV31.Load += new System.EventHandler(this.familyTreeV31_Load_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 547);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.familyTreeV21);
            this.Controls.Add(this.familyTreeV31);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FamilyTree.FamilyTreeV3 familyTreeV31;
        private FamilyTree.FamilyTreeV2 familyTreeV21;
        private System.Windows.Forms.Button button1;
    }
}

