namespace WindowsApplication1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textTimeWin = new System.Windows.Forms.TextBox();
            this.TimeZoneRadio = new System.Windows.Forms.RadioButton();
            this.TimeMovingRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textRatio1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textPrev = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textNext = new System.Windows.Forms.TextBox();
            this.textQ = new System.Windows.Forms.TextBox();
            this.baseVol = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.basePrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baseVolRadio = new System.Windows.Forms.RadioButton();
            this.PrevQRadio = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textRatio2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textK = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gzRadio1 = new System.Windows.Forms.RadioButton();
            this.gzRadio2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "时间窗(秒)";
            // 
            // textTimeWin
            // 
            this.textTimeWin.Location = new System.Drawing.Point(110, 348);
            this.textTimeWin.Name = "textTimeWin";
            this.textTimeWin.Size = new System.Drawing.Size(64, 21);
            this.textTimeWin.TabIndex = 4;
            this.textTimeWin.Text = "60";
            // 
            // TimeZoneRadio
            // 
            this.TimeZoneRadio.AutoSize = true;
            this.TimeZoneRadio.Checked = true;
            this.TimeZoneRadio.Location = new System.Drawing.Point(30, 20);
            this.TimeZoneRadio.Name = "TimeZoneRadio";
            this.TimeZoneRadio.Size = new System.Drawing.Size(95, 16);
            this.TimeZoneRadio.TabIndex = 5;
            this.TimeZoneRadio.TabStop = true;
            this.TimeZoneRadio.Text = "时间区间观察";
            this.TimeZoneRadio.UseVisualStyleBackColor = true;
            // 
            // TimeMovingRadio
            // 
            this.TimeMovingRadio.AutoSize = true;
            this.TimeMovingRadio.Location = new System.Drawing.Point(141, 20);
            this.TimeMovingRadio.Name = "TimeMovingRadio";
            this.TimeMovingRadio.Size = new System.Drawing.Size(71, 16);
            this.TimeMovingRadio.TabIndex = 6;
            this.TimeMovingRadio.Text = "移动观察";
            this.TimeMovingRadio.UseVisualStyleBackColor = true;
            this.TimeMovingRadio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "全局参数";
            // 
            // textRatio1
            // 
            this.textRatio1.Location = new System.Drawing.Point(110, 285);
            this.textRatio1.Name = "textRatio1";
            this.textRatio1.Size = new System.Drawing.Size(64, 21);
            this.textRatio1.TabIndex = 8;
            this.textRatio1.Text = "0.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "比率   r1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "前m秒";
            // 
            // textPrev
            // 
            this.textPrev.Location = new System.Drawing.Point(110, 382);
            this.textPrev.Name = "textPrev";
            this.textPrev.Size = new System.Drawing.Size(64, 21);
            this.textPrev.TabIndex = 11;
            this.textPrev.Text = "60";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "后n秒";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textNext
            // 
            this.textNext.Location = new System.Drawing.Point(252, 382);
            this.textNext.Name = "textNext";
            this.textNext.Size = new System.Drawing.Size(69, 21);
            this.textNext.TabIndex = 13;
            this.textNext.Text = "60";
            this.textNext.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textQ
            // 
            this.textQ.Location = new System.Drawing.Point(107, 19);
            this.textQ.Name = "textQ";
            this.textQ.Size = new System.Drawing.Size(64, 21);
            this.textQ.TabIndex = 15;
            this.textQ.Text = "5";
            this.textQ.TextChanged += new System.EventHandler(this.textQ_TextChanged);
            // 
            // baseVol
            // 
            this.baseVol.Location = new System.Drawing.Point(107, 51);
            this.baseVol.Name = "baseVol";
            this.baseVol.Size = new System.Drawing.Size(64, 21);
            this.baseVol.TabIndex = 19;
            this.baseVol.Text = "0";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(191, 54);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(41, 12);
            this.labelPrice.TabIndex = 20;
            this.labelPrice.Text = "基准价";
            // 
            // basePrice
            // 
            this.basePrice.Location = new System.Drawing.Point(238, 51);
            this.basePrice.Name = "basePrice";
            this.basePrice.Size = new System.Drawing.Size(65, 21);
            this.basePrice.TabIndex = 21;
            this.basePrice.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TimeMovingRadio);
            this.groupBox1.Controls.Add(this.TimeZoneRadio);
            this.groupBox1.Location = new System.Drawing.Point(49, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 44);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "观察条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baseVolRadio);
            this.groupBox2.Controls.Add(this.PrevQRadio);
            this.groupBox2.Controls.Add(this.basePrice);
            this.groupBox2.Controls.Add(this.labelPrice);
            this.groupBox2.Controls.Add(this.baseVol);
            this.groupBox2.Controls.Add(this.textQ);
            this.groupBox2.Location = new System.Drawing.Point(49, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 84);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选条件";
            // 
            // baseVolRadio
            // 
            this.baseVolRadio.AutoSize = true;
            this.baseVolRadio.Location = new System.Drawing.Point(30, 52);
            this.baseVolRadio.Name = "baseVolRadio";
            this.baseVolRadio.Size = new System.Drawing.Size(59, 16);
            this.baseVolRadio.TabIndex = 23;
            this.baseVolRadio.Text = "基准量";
            this.baseVolRadio.UseVisualStyleBackColor = true;
            // 
            // PrevQRadio
            // 
            this.PrevQRadio.AutoSize = true;
            this.PrevQRadio.Checked = true;
            this.PrevQRadio.Location = new System.Drawing.Point(30, 20);
            this.PrevQRadio.Name = "PrevQRadio";
            this.PrevQRadio.Size = new System.Drawing.Size(71, 16);
            this.PrevQRadio.TabIndex = 22;
            this.PrevQRadio.TabStop = true;
            this.PrevQRadio.Text = "天移动量";
            this.PrevQRadio.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "r2";
            // 
            // textRatio2
            // 
            this.textRatio2.Location = new System.Drawing.Point(211, 285);
            this.textRatio2.Name = "textRatio2";
            this.textRatio2.Size = new System.Drawing.Size(67, 21);
            this.textRatio2.TabIndex = 25;
            this.textRatio2.Text = "0.5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "k";
            // 
            // textK
            // 
            this.textK.Location = new System.Drawing.Point(110, 316);
            this.textK.Name = "textK";
            this.textK.Size = new System.Drawing.Size(64, 21);
            this.textK.TabIndex = 27;
            this.textK.Text = "1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gzRadio2);
            this.groupBox3.Controls.Add(this.gzRadio1);
            this.groupBox3.Location = new System.Drawing.Point(51, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 66);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "沽扎判定条件";
            // 
            // gzRadio1
            // 
            this.gzRadio1.AutoSize = true;
            this.gzRadio1.Checked = true;
            this.gzRadio1.Location = new System.Drawing.Point(28, 20);
            this.gzRadio1.Name = "gzRadio1";
            this.gzRadio1.Size = new System.Drawing.Size(173, 16);
            this.gzRadio1.TabIndex = 0;
            this.gzRadio1.TabStop = true;
            this.gzRadio1.Text = "P结束价>P开盘价，为“沽”";
            this.gzRadio1.UseVisualStyleBackColor = true;
            // 
            // gzRadio2
            // 
            this.gzRadio2.AutoSize = true;
            this.gzRadio2.Location = new System.Drawing.Point(28, 42);
            this.gzRadio2.Name = "gzRadio2";
            this.gzRadio2.Size = new System.Drawing.Size(239, 16);
            this.gzRadio2.TabIndex = 1;
            this.gzRadio2.Text = "max（P最高价、P收盘价)>= P开盘价为沽";
            this.gzRadio2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 458);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textRatio2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textNext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPrev);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textRatio1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTimeWin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stock ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTimeWin;
        private System.Windows.Forms.RadioButton TimeZoneRadio;
        private System.Windows.Forms.RadioButton TimeMovingRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRatio1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPrev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textNext;
        private System.Windows.Forms.TextBox textQ;
        private System.Windows.Forms.TextBox baseVol;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox basePrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton PrevQRadio;
        private System.Windows.Forms.RadioButton baseVolRadio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textRatio2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton gzRadio2;
        private System.Windows.Forms.RadioButton gzRadio1;
    }
}

