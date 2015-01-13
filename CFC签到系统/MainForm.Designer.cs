namespace CFC签到系统
{
    partial class mainFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrom));
            this.picBoxInfo = new System.Windows.Forms.PictureBox();
            this.btn = new System.Windows.Forms.Button();
            this.lblShowInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxInfo
            // 
            this.picBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxInfo.BackgroundImage")));
            this.picBoxInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoxInfo.Location = new System.Drawing.Point(133, 71);
            this.picBoxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxInfo.Name = "picBoxInfo";
            this.picBoxInfo.Size = new System.Drawing.Size(383, 510);
            this.picBoxInfo.TabIndex = 0;
            this.picBoxInfo.TabStop = false;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.SystemColors.Menu;
            this.btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn.BackgroundImage")));
            this.btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn.Location = new System.Drawing.Point(503, 640);
            this.btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(91, 79);
            this.btn.TabIndex = 1;
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // lblShowInfo
            // 
            this.lblShowInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowInfo.Font = new System.Drawing.Font("华文琥珀", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblShowInfo.Location = new System.Drawing.Point(133, 71);
            this.lblShowInfo.Name = "lblShowInfo";
            this.lblShowInfo.Size = new System.Drawing.Size(383, 141);
            this.lblShowInfo.TabIndex = 2;
            this.lblShowInfo.Text = "CFC Studio\r\n签到系统";
            this.lblShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblShowInfo.Visible = false;
            this.lblShowInfo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(-3, -1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 40);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "CFC Studio   签到系统";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(636, 745);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblShowInfo);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.picBoxInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFC签到系统";
            this.VisibleChanged += new System.EventHandler(this.mainFrom_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxInfo;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label lblShowInfo;
        private System.Windows.Forms.Label lblTitle;


    }
}

