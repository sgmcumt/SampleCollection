namespace BitmapOperation
{
    partial class FrmMain
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
            this.PicOriginal = new System.Windows.Forms.PictureBox();
            this.PicMirror = new System.Windows.Forms.PictureBox();
            this.BtnHorizonal = new System.Windows.Forms.Button();
            this.BtnVertical = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMirror)).BeginInit();
            this.SuspendLayout();
            // 
            // PicOriginal
            // 
            this.PicOriginal.Location = new System.Drawing.Point(150, 12);
            this.PicOriginal.Name = "PicOriginal";
            this.PicOriginal.Size = new System.Drawing.Size(551, 596);
            this.PicOriginal.TabIndex = 0;
            this.PicOriginal.TabStop = false;
            // 
            // PicMirror
            // 
            this.PicMirror.Location = new System.Drawing.Point(757, 12);
            this.PicMirror.Name = "PicMirror";
            this.PicMirror.Size = new System.Drawing.Size(592, 596);
            this.PicMirror.TabIndex = 1;
            this.PicMirror.TabStop = false;
            // 
            // BtnHorizonal
            // 
            this.BtnHorizonal.Location = new System.Drawing.Point(12, 175);
            this.BtnHorizonal.Name = "BtnHorizonal";
            this.BtnHorizonal.Size = new System.Drawing.Size(119, 38);
            this.BtnHorizonal.TabIndex = 2;
            this.BtnHorizonal.Text = "水平镜像";
            this.BtnHorizonal.UseVisualStyleBackColor = true;
            this.BtnHorizonal.Click += new System.EventHandler(this.BtnHorizonal_Click);
            // 
            // BtnVertical
            // 
            this.BtnVertical.Location = new System.Drawing.Point(12, 246);
            this.BtnVertical.Name = "BtnVertical";
            this.BtnVertical.Size = new System.Drawing.Size(119, 38);
            this.BtnVertical.TabIndex = 3;
            this.BtnVertical.Text = "垂直镜像";
            this.BtnVertical.UseVisualStyleBackColor = true;
            this.BtnVertical.Click += new System.EventHandler(this.BtnVertical_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(12, 113);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(119, 38);
            this.BtnLoad.TabIndex = 4;
            this.BtnLoad.Text = "加载图片";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 628);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnVertical);
            this.Controls.Add(this.BtnHorizonal);
            this.Controls.Add(this.PicMirror);
            this.Controls.Add(this.PicOriginal);
            this.Name = "FrmMain";
            this.Text = "图像操作";
            ((System.ComponentModel.ISupportInitialize)(this.PicOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicMirror)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicOriginal;
        private System.Windows.Forms.PictureBox PicMirror;
        private System.Windows.Forms.Button BtnHorizonal;
        private System.Windows.Forms.Button BtnVertical;
        private System.Windows.Forms.Button BtnLoad;
    }
}

