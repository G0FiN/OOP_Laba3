using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        { Work(); }

        public static void Work()
        {
            string[] FilesNames = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in FilesNames)
            {
                try
                {
                    Bitmap bmp = new Bitmap(file);
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipY);
                    string newName = file.Split('\\')[10].Split('.')[0] + "-mirored.gif";
                    bmp.Save(newName, ImageFormat.Gif);
                }
                catch (ArgumentException)
                { MessageBox.Show(file.Split('\\')[10] + " не являеться картинкой"); }
            }
        }
    }
}
