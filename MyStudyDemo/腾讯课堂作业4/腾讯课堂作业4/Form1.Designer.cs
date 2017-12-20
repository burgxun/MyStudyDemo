namespace 腾讯课堂作业4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.frontLbl1 = new System.Windows.Forms.Label();
            this.frontLbl2 = new System.Windows.Forms.Label();
            this.frontLbl3 = new System.Windows.Forms.Label();
            this.frontLbl4 = new System.Windows.Forms.Label();
            this.frontLbl5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.behindLbl1 = new System.Windows.Forms.Label();
            this.behindLbl2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnd);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "大乐透开奖程序";
            // 
            // frontLbl1
            // 
            this.frontLbl1.AutoSize = true;
            this.frontLbl1.BackColor = System.Drawing.Color.Red;
            this.frontLbl1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frontLbl1.Location = new System.Drawing.Point(6, 44);
            this.frontLbl1.Name = "frontLbl1";
            this.frontLbl1.Size = new System.Drawing.Size(29, 20);
            this.frontLbl1.TabIndex = 0;
            this.frontLbl1.Text = "00";
            // 
            // frontLbl2
            // 
            this.frontLbl2.AutoSize = true;
            this.frontLbl2.BackColor = System.Drawing.Color.Red;
            this.frontLbl2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frontLbl2.Location = new System.Drawing.Point(69, 43);
            this.frontLbl2.Name = "frontLbl2";
            this.frontLbl2.Size = new System.Drawing.Size(29, 20);
            this.frontLbl2.TabIndex = 1;
            this.frontLbl2.Text = "00";
            // 
            // frontLbl3
            // 
            this.frontLbl3.AutoSize = true;
            this.frontLbl3.BackColor = System.Drawing.Color.Red;
            this.frontLbl3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frontLbl3.Location = new System.Drawing.Point(129, 43);
            this.frontLbl3.Name = "frontLbl3";
            this.frontLbl3.Size = new System.Drawing.Size(29, 20);
            this.frontLbl3.TabIndex = 2;
            this.frontLbl3.Text = "00";
            // 
            // frontLbl4
            // 
            this.frontLbl4.AutoSize = true;
            this.frontLbl4.BackColor = System.Drawing.Color.Red;
            this.frontLbl4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frontLbl4.Location = new System.Drawing.Point(189, 43);
            this.frontLbl4.Name = "frontLbl4";
            this.frontLbl4.Size = new System.Drawing.Size(29, 20);
            this.frontLbl4.TabIndex = 3;
            this.frontLbl4.Text = "00";
            // 
            // frontLbl5
            // 
            this.frontLbl5.AutoSize = true;
            this.frontLbl5.BackColor = System.Drawing.Color.Red;
            this.frontLbl5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.frontLbl5.Location = new System.Drawing.Point(251, 44);
            this.frontLbl5.Name = "frontLbl5";
            this.frontLbl5.Size = new System.Drawing.Size(29, 20);
            this.frontLbl5.TabIndex = 4;
            this.frontLbl5.Text = "00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.frontLbl3);
            this.groupBox2.Controls.Add(this.frontLbl5);
            this.groupBox2.Controls.Add(this.frontLbl1);
            this.groupBox2.Controls.Add(this.frontLbl4);
            this.groupBox2.Controls.Add(this.frontLbl2);
            this.groupBox2.Location = new System.Drawing.Point(6, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 99);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "前区号码";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.behindLbl2);
            this.groupBox3.Controls.Add(this.behindLbl1);
            this.groupBox3.Location = new System.Drawing.Point(339, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 99);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "后区号码";
            // 
            // behindLbl1
            // 
            this.behindLbl1.AutoSize = true;
            this.behindLbl1.BackColor = System.Drawing.Color.Blue;
            this.behindLbl1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.behindLbl1.Location = new System.Drawing.Point(22, 43);
            this.behindLbl1.Name = "behindLbl1";
            this.behindLbl1.Size = new System.Drawing.Size(32, 21);
            this.behindLbl1.TabIndex = 0;
            this.behindLbl1.Text = "00";
            // 
            // behindLbl2
            // 
            this.behindLbl2.AutoSize = true;
            this.behindLbl2.BackColor = System.Drawing.Color.Blue;
            this.behindLbl2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.behindLbl2.Location = new System.Drawing.Point(92, 43);
            this.behindLbl2.Name = "behindLbl2";
            this.behindLbl2.Size = new System.Drawing.Size(32, 21);
            this.behindLbl2.TabIndex = 1;
            this.behindLbl2.Text = "00";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(89, 200);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(261, 200);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 30);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 296);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "·Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label behindLbl2;
        private System.Windows.Forms.Label behindLbl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label frontLbl3;
        private System.Windows.Forms.Label frontLbl5;
        private System.Windows.Forms.Label frontLbl1;
        private System.Windows.Forms.Label frontLbl4;
        private System.Windows.Forms.Label frontLbl2;
    }
}

