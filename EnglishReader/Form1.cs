using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    {
namespace EnglishReader
{
    public partial class Form1 : Form
    {
        decimal font_size=12, wpm=80 ;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wpm = inputWPM.Value;
            font_size = inputFontSize.Value;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void 開くCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void 終了CtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CancelEventArgsオブジェクトの作成
            System.ComponentModel.CancelEventArgs cea =
                new System.ComponentModel.CancelEventArgs();
       
            Application.Exit(cea);
            if (cea.Cancel) Console.WriteLine("終了できません.");
        }

    }
}
