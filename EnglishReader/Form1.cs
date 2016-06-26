using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnglishReader
{
    public partial class Form1 : Form
    {
        bool isRunning = false;
        MyFile myFile = new MyFile();
        string fileName = "";
        Highlighter highliter;

        public Form1()
        {
            InitializeComponent();
            highliter = new Highlighter(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!isRunning)
            {
                buttonStartStop.Text = "STOP";
                isRunning = true;
                highliter.Start();
            }
            else
            {
                buttonStartStop.Text = "START";
                isRunning = false;
                highliter.Stop();
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ResizeFont();
        }

        private void 開くCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = myFile.OpenWithDialog();
            if (fileName != "")
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] bs = new byte[fs.Length];
                fs.Read(bs, 0, bs.Length);
                fs.Close();
                System.Text.Encoding enc = GetCode(bs);
                ResizeFont();
                richTextBox.Text = enc.GetString(bs);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //ドラッグされたものがファイルであれば受け取る
            if (myFile.isDropedFileAccessible(e))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            fileName = myFile.returnfilePath(e, 0);
            if (myFile.checkFileType(fileName))
            {
                ResizeFont();
                richTextBox.Text = File.ReadAllText(fileName, Encoding.Default);
            }
        }

        private void inputWPM_ValueChanged(object sender, EventArgs e)
        {
        }

        private void 終了CtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //終了のキャンセルを受け取るオブジェクト
            System.ComponentModel.CancelEventArgs cea =
                new System.ComponentModel.CancelEventArgs();
       
            Application.Exit(cea);
            if (cea.Cancel)
            {
                MessageBox.Show("終了できません. ",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 文字コードを判別する
        /// </summary>
        /// <remarks>
        /// Jcode.pmのgetcodeメソッドを移植したものです。
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// Jcode.pmのCopyright: Copyright 1999-2005 Dan Kogai
        /// </remarks>
        /// <param name="bytes">文字コードを調べるデータ</param>
        /// <returns>適当と思われるEncodingオブジェクト。
        /// 判断できなかった時はnull。</returns>
        public static System.Text.Encoding GetCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }

        /// <summary>
        /// richTextBoxのフォントサイズを変更する
        /// </summary>
        void ResizeFont()
        {
            Font baseFont = richTextBox.Font;
            float fontSize = (float)inputFontSize.Value;
            richTextBox.Font = new Font(baseFont.FontFamily, fontSize, baseFont.Style);
            this.Update();
        }

        class Highlighter : IHighlighter
        {
            Form1 form;
            int first, last;
            decimal wpm;
            Timer timer;

            public Highlighter(Form1 form)
            {
                this.form = form;
                first = 0;
                last = 0;
                timer = new Timer();
            }
            public void Start()
            {
                wpm = form.inputWPM.Value;
                int interval = (int)(60 / (double)wpm * 1000);
                form.richTextBox.Select(0, 0);
                timer.Tick += new EventHandler(Highlight);
                timer.Interval = interval;
                timer.Start();
            }
            public void Stop()
            {
                timer.Stop();
            }
            public void Reset()
            {
                timer.Stop();
                timer.Dispose();
                timer = new Timer();
                first = 0;
                last = 0;
                form.richTextBox.SelectAll();
                form.richTextBox.SelectionColor = Color.Black;
            }
            private void Highlight(object sender, EventArgs e)
            {
                bool isnotEnd = NextWord(ref first, ref last);
                if (!isnotEnd) this.Stop();
                else ChangeColor(first, last);
            }
            private bool NextWord(ref int first, ref int last)
            {
                string str = form.richTextBox.Text;
                if (str == "") return false;
                //スペースの次の文字までfirstを移動
                if (last == 0) first = 0;
                else
                {
                    first = last + 1;
                    if (first > form.richTextBox.Text.Length) return false;
                }
                while(true)
                {
                    char c = str[first];
                    if ((c != ' ') && (c != '\n') && (c != '\r')) break;
                    first++;
                }

                last = first;
                while(true)
                {
                    if (last >= str.Length) break;
                    char c = str[last];
                    if ((c == ' ') || (c == '\n') || (c == '\r'))
                    {
                        last--;
                        break;
                    }
                    last++;
                }
                Console.WriteLine("first:" + first + " last:" + last + " interval:"+ timer.Interval);
                return true;
            }
            private void ChangeColor(int first, int last)
            {
                if (form.checkBox.Checked)
                    form.richTextBox.SelectionColor = Color.White;
                else
                    form.richTextBox.SelectionColor = Color.Black;
                form.richTextBox.SelectionStart = first;
                form.richTextBox.SelectionLength = (last - first + 1);
                form.richTextBox.SelectionColor = Color.Red;
                form.Update();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            highliter.Reset();
            isRunning = false;
            buttonStartStop.Text = "START";
        }
    }
}
