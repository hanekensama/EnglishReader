using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishReader
{
    class MyFile
    {
        // fileNumは複数ドロップされた時、何番目のファイルパスを読み込むかを決める。
        // ファイルパスは配列で入って来る。普通は最初のだから0を指定。
        public string returnfilePath(DragEventArgs e, int fileNum)
        {
            string[] dragFilePathArr = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string filePath = dragFilePathArr[fileNum];
            return filePath;
        }

        public bool checkFileType(string filePath)
        {
            //読み込みを許可するファイルの拡張子を指定 (app.config に定義した方が本当は便利。)
            string[] extnArray = { "txt", "cs", "vb", "htm", "html", "xml", "csv", "js", "vbs", "wsh" };
            foreach (string extn in extnArray)
            {
                int dotLen = extn.Length;
                if (extn == filePath.Substring(filePath.Length - dotLen, dotLen))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDropedFileAccessible(DragEventArgs e)
        {
            //ドラッグされたのがファイルであるか確認
            if ((e.Data.GetDataPresent(DataFormats.FileDrop)))
            {
                //ドラッグされたデータを受け取る
                return true;
            }
            else
            {
                //ドラッグされたデータを受け取らない
                return false;
            }
        }
    }
