using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFileUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF,*.JFIF) | *.BMP;*.JPG;*.GIF;*.PNG;*.TIFF,*.JFIF";
            var result = fileDialog.ShowDialog();
            if(result==DialogResult.OK)
            {
                var filepath = fileDialog.FileName;
                txtBox1.Text = filepath;
                
                PictureBox imageControl = new PictureBox();
                imageControl.Height = 500;
                imageControl.Width = 500;

                Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Bitmap myBitmap = new Bitmap(filepath);
                Image myThumbnail = myBitmap.GetThumbnailImage(400, 300,myCallback, IntPtr.Zero);
                imageControl.Image = myThumbnail;

                pictureBox1.Controls.Add(imageControl);
            }

        }
    }
}
