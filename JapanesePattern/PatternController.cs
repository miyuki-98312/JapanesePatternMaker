using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JapanesePattern
{
    class PatternController
    {
        private int loopNumWidth = 5;
        private int loopNumHeight = 6;
        private int originalStride = 0;
        private byte[] preRGBAOfBackGround = { 255, 255, 255, 255 };
        private byte[] nextRGBAOfBackGround = null;
        private byte[] nextRGBAOfForeGround = null;
        private FormatConvertedBitmap convertedBitmap;

        /// <summary>
        /// ループ後の画像幅を取得する
        /// </summary>
        /// <returns>ループ後の画像幅</returns>
        public int GetloopedWidth()
        {
            return convertedBitmap.PixelWidth * loopNumWidth;
        }

        /// <summary>
        /// ループ後の画像の高さを取得する
        /// </summary>
        /// <returns>ループ後の画像の高さ</returns>
        public int GetloopedHeight()
        {
            return convertedBitmap.PixelHeight * loopNumHeight;
        }

        /// <summary>
        /// 横方向のループ回数を指定する
        /// </summary>
        /// <param name="num">横方向のループ回数</param>
        public void SetloopNumWidth(int num)
        {
            loopNumWidth = num;
        }

        /// <summary>
        /// 縦方向のループ回数を指定する
        /// </summary>
        /// <param name="num">縦方向のループ回数</param>
        public void SetloopNumHeight(int num)
        {
            loopNumHeight = num;
        }

        /// <summary>
        /// 変更後の背景色を設定する
        /// </summary>
        /// <param name="bytes">背景色(RGBA)</param>
        public void SetnextRGBAOfBackGround(byte[] bytes)
        {
            nextRGBAOfBackGround = bytes;
        }

        /// <summary>
        /// 変更後の前景色を設定する
        /// </summary>
        /// <param name="bytes">前景色(RGBA)</param>
        public void SetnextRGBAOfForeGround(byte[] bytes)
        {
            nextRGBAOfForeGround = bytes;
        }

        /// <summary>
        /// Imageの画像を変更する
        /// </summary>
        /// <param name="dataInBytes">変更後画像のbyte配列</param>
        /// <param name="DisplayImage">Image</param>
        public void ChangeImage(byte[] dataInBytes, Image DisplayImage)
        {
            int loopedStride = originalStride * loopNumWidth;
            BitmapSource bitmapSource = BitmapSource.Create(
                GetloopedWidth(),GetloopedHeight(), 96, 96, PixelFormats.Pbgra32,
                null, dataInBytes, loopedStride);
            DisplayImage.Source = bitmapSource;
        }

        /// <summary>
        /// bitmapImageをループし、色を変更する
        /// </summary>
        /// <param name="bitmapImage">softwareBitmap</param>
        /// <returns>変更後画像のByte配列</returns>
        public byte[] GetDataInBytes(BitmapImage bitmapImage)
        {
            convertedBitmap = new FormatConvertedBitmap(bitmapImage, PixelFormats.Pbgra32, null, 0);
            int originalWidth = convertedBitmap.PixelWidth;
            int originalHeight = convertedBitmap.PixelHeight;
            byte[] originalDataInBytes = new byte[originalWidth * originalHeight * 4];
            originalStride = (originalWidth * convertedBitmap.Format.BitsPerPixel + 7) / 8;
            convertedBitmap.CopyPixels(originalDataInBytes, originalStride, 0);

            int sumLength = 4 * originalHeight * originalWidth * loopNumWidth * loopNumHeight;
            int sumLengthByOneLine = 4 * originalHeight * originalWidth * loopNumWidth;
            byte[] loopedData = new byte[sumLength];

            for (int m = 0; m < loopNumHeight; m++)
            {
                int offsetByOneLine = m * sumLengthByOneLine;
                for (int i = 0; i < originalHeight; i++)
                {
                    for (int j = 0; j < originalWidth; j++)
                    {
                        int indexByPixel = originalStride * i + 4 * j;
                        for (int k = 0; k < loopNumWidth; k++)
                        {
                            //               1行分のデータがmコ +          元画像左上隅から何番目のピクセルか         + 変更後画像の左から何番目の画像を描画するか
                            int indexForLoop = offsetByOneLine + (i * loopNumWidth * originalStride) + j * 4 + (k * originalStride);
                            if ((originalDataInBytes[indexByPixel + 0] == preRGBAOfBackGround[2]) ||
                                (originalDataInBytes[indexByPixel + 1] == preRGBAOfBackGround[1]) ||
                                (originalDataInBytes[indexByPixel + 2] == preRGBAOfBackGround[0]))
                            {
                                loopedData[indexForLoop + 0] = nextRGBAOfBackGround[2];
                                loopedData[indexForLoop + 1] = nextRGBAOfBackGround[1];
                                loopedData[indexForLoop + 2] = nextRGBAOfBackGround[0];
                                loopedData[indexForLoop + 3] = nextRGBAOfBackGround[3];
                            }
                            else
                            {
                                loopedData[indexForLoop + 0] = nextRGBAOfForeGround[2];
                                loopedData[indexForLoop + 1] = nextRGBAOfForeGround[1];
                                loopedData[indexForLoop + 2] = nextRGBAOfForeGround[0];
                                loopedData[indexForLoop + 3] = nextRGBAOfForeGround[3];
                            }
                        }
                    }
                }
            }
            return loopedData;
        }

        /// <summary>
        /// モザイク処理を施す
        /// </summary>
        /// <param name="preBytes">変更前画像のByte配列</param>
        /// <param name="thickness">モザイクの強さ</param>
        /// <returns>変更後画像のByte配列</returns>
        public byte[] PutMosaic(byte[] preBytes, int thickness)
        {
            Random random = new Random();
            for (int i = 0; i < preBytes.Length; i = i + 4)
            {
                double mosaicValue = random.NextDouble() * thickness;
                for (int k = 0; k < 4; k++)
                {
                    if (preBytes[i + k] + mosaicValue > 255)
                    {
                        preBytes[i + k] = 255;
                    }
                    else
                    {
                        preBytes[i + k] += Convert.ToByte(mosaicValue);
                    }
                }
            }
            return preBytes;
        }

        /// <summary>
        /// 画像をぼかす
        /// </summary>
        /// <param name="preBytes">画像のByte配列</param>
        /// <param name="window">ぼかしを行うしきい値</param>
        /// <returns>画像のByte配列</returns>
        public byte[] PutGradation(byte[] preBytes, int window)
        {
            for (int i = 0; i < preBytes.Length - 4; i = i + 4)
            {
                // 横方向にぼかす
                int diff = 0;
                for (int k = 0; k < 4; k++)
                {
                    diff += Math.Abs(preBytes[i + k] - preBytes[i + 4 + k]);
                }
                if (diff > window)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int ave = (preBytes[i + 4 + k] + preBytes[i + k]) / 2;
                        preBytes[i + k] = (byte)ave;
                        preBytes[i + 4 + k] = (byte)ave;
                    }
                }
                // 縦方向にぼかす
                int loopedStride = GetloopedWidth() * 4;
                if (i > loopedStride)
                {
                    diff = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        diff += Math.Abs(preBytes[i + k] - preBytes[i - loopedStride + k]);
                    }
                    if (diff > window)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            int ave = (preBytes[i - loopedStride + k] + preBytes[i + k]) / 2;
                            preBytes[i + k] = (byte)ave;
                            preBytes[i - loopedStride + k] = (byte)ave;
                        }
                    }
                }
            }
            return preBytes;
        }
    }
}
