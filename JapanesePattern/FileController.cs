using System;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;

namespace JapanesePattern
{
    /// <summary>
    /// ファイル保存を行う
    /// </summary>
    class FileController
    {
        /// <summary>
        /// 画像の保存先を選択し、画像を保存する
        /// </summary>
        /// <param name="bitmapSource">画像</param>
        public void PickFileAndSaveFile(BitmapSource bitmapSource)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFileDialog.InitialDirectory = pathToDesktop;
            saveFileDialog.FileName = "image.jpg";
            saveFileDialog.Filter = "JPEG(*.jpg*)|*.jpg|PNG(*.png*)|*.png";
            var result = saveFileDialog.ShowDialog() ?? false;

            if (result)
            {
                SaveFile(bitmapSource, saveFileDialog.FileName);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 画像を保存する
        /// </summary>
        /// <param name="bitmapSource">画像</param>
        /// <param name="filePath">保存先のファイルパス</param>
        /// <returns></returns>
        private void SaveFile(BitmapSource bitmapSource, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(fileStream);
            }
        }
    }
}
