namespace IncrememtalPublish
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
            this.txt_publish = new System.Windows.Forms.TextBox();
            this.txt_physical = new System.Windows.Forms.TextBox();
            this.txt_update = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_version = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_publish
            // 
            this.txt_publish.Location = new System.Drawing.Point(122, 26);
            this.txt_publish.Name = "txt_publish";
            this.txt_publish.Size = new System.Drawing.Size(611, 21);
            this.txt_publish.TabIndex = 0;
            this.txt_publish.Text = "E:\\发布\\m.yiche.com";
            this.txt_publish.TextChanged += new System.EventHandler(this.txt_publish_TextChanged);
            // 
            // txt_physical
            // 
            this.txt_physical.Location = new System.Drawing.Point(122, 53);
            this.txt_physical.Name = "txt_physical";
            this.txt_physical.Size = new System.Drawing.Size(611, 21);
            this.txt_physical.TabIndex = 1;
            this.txt_physical.Text = "E:\\work\\bitauto\\爱易车\\src\\iBitauto.root\\iBitauto2.0-develop\\m.qichetong.com";
            this.txt_physical.TextChanged += new System.EventHandler(this.txt_physical_TextChanged);
            // 
            // txt_update
            // 
            this.txt_update.Location = new System.Drawing.Point(122, 77);
            this.txt_update.Name = "txt_update";
            this.txt_update.Size = new System.Drawing.Size(611, 21);
            this.txt_update.TabIndex = 2;
            this.txt_update.Text = "E:\\myproject\\msbuild\\copy";
            this.txt_update.TextChanged += new System.EventHandler(this.txt_update_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "发布地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "站点地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "更新地址：";
            // 
            // txt_version
            // 
            this.txt_version.Location = new System.Drawing.Point(122, 104);
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size(611, 21);
            this.txt_version.TabIndex = 6;
            this.txt_version.Text = "387736";
            this.txt_version.TextChanged += new System.EventHandler(this.txt_version_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "起始版本号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "编译并生成更新包";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(614, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "不编译生成更新包";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_update);
            this.Controls.Add(this.txt_physical);
            this.Controls.Add(this.txt_publish);
            this.Name = "Form1";
            this.Text = "增量更新包生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_publish;
        private System.Windows.Forms.TextBox txt_physical;
        private System.Windows.Forms.TextBox txt_update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_version;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

