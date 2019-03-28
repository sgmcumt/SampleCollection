using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapOperation
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            PicOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            PicMirror.SizeMode = PictureBoxSizeMode.Zoom;
        }
        Bitmap OrignalBitmap = null;
        private MirrorImage Operation = new MirrorImage();
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog
            {
                Title = "打开图片",
                Filter = "图片|*.tif;*.png;*.jpg|所有文件|*.*"
            };
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                OrignalBitmap = (Bitmap)Image.FromFile(openDlg.FileName);
                PicOriginal.Image = OrignalBitmap;
            }
        }

        private void BtnHorizonal_Click(object sender, EventArgs e)
        {
            //Bitmap bitmap = (Bitmap)PicOriginal.Image;
            PicMirror.Image = Operation.HorizontalMirror(OrignalBitmap);
        }

        private void BtnVertical_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)PicOriginal.Image;
            PicMirror.Image = Operation.VerticalMirror(bitmap);
        }
    }
}
