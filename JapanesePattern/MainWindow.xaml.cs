using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using System.Text.RegularExpressions;

namespace JapanesePattern
{
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] loopedData;
        private int loopedWidth = 0;
        private int loopedHeight = 0;
        private string materialName = "shippo_L.png";
        private Dictionary<string, string> materialDictionary = new Dictionary<string, string>();
        PatternController drawPattern;

        public MainWindow()
        {
            this.InitializeComponent();

            drawPattern = new PatternController();
            Uri materialUri = GetUri(materialName);
            ChangeMaterialImage(materialUri);
            InitializeMaterialDictionary();
            InitializeComboBox();
        }

        /// <summary>
        /// 表示する素材を変更する
        /// </summary>
        /// <param name="uri">表示する素材のUri</param>
        private void ChangeMaterialImage(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage(uri);
            DisplayMaterial.Source = bitmapImage;
        }

        /// <summary>
        /// 画像の名前からUriを取得する
        /// </summary>
        /// <param name="name">画像の名前</param>
        /// <returns>画像のUri</returns>
        private Uri GetUri(string name)
        {
            return new Uri("images/" + name, UriKind.Relative);
        }

        /// <summary>
        /// 柄の名称をキーに、画像の名前を値にした辞書を作成する
        /// </summary>
        private void InitializeMaterialDictionary()
        {
            materialDictionary.Add("七宝①(大)", "shippo_L.png");
            materialDictionary.Add("七宝①(小)", "shippo_S.png");
            materialDictionary.Add("七宝②(大)", "shippo_L_2.png");
            materialDictionary.Add("七宝②(小)", "shippo_S_2.png");
            materialDictionary.Add("亀甲①(大)", "kikko_L.png");
            materialDictionary.Add("亀甲①(小)", "kikko_S.png");
            materialDictionary.Add("亀甲②(大)", "kikko_L_2.png");
            materialDictionary.Add("亀甲②(小)", "kikko_S_2.png");
            materialDictionary.Add("市松(大)", "ichimatsu_L.png");
            materialDictionary.Add("市松(小)", "ichimatsu_S.png");
            materialDictionary.Add("麻の葉(大)", "asanoha_L.png");
            materialDictionary.Add("麻の葉(小)", "asanoha_S.png");
            materialDictionary.Add("青海波①(大)", "seigaiha_L.png");
            materialDictionary.Add("青海波①(小)", "seigaiha_S.png");
            materialDictionary.Add("青海波②(大)", "seigaiha_L_2.png");
            materialDictionary.Add("青海波②(小)", "seigaiha_S_2.png");
            materialDictionary.Add("三崩し(大)", "sankuzushi_L.png");
            materialDictionary.Add("三崩し(小)", "sankuzushi_S.png");
            materialDictionary.Add("菱(大)", "hishi_L.png");
            materialDictionary.Add("菱(小)", "hishi_S.png");
            materialDictionary.Add("武田菱(大)", "takedabishi_L.png");
            materialDictionary.Add("武田菱(小)", "takedabishi_S.png");
            materialDictionary.Add("籠目(大)", "kagome_L.png");
            materialDictionary.Add("籠目(小)", "kagome_S.png");
            materialDictionary.Add("檜垣(大)", "higaki_L.png");
            materialDictionary.Add("檜垣(小)", "higaki_S.png");
            materialDictionary.Add("網目文(大)", "amimemon_L.png");
            materialDictionary.Add("網目文(小)", "amimemon_S.png");
            materialDictionary.Add("矢絣①(大)", "yagasuri_L.png");
            materialDictionary.Add("矢絣①(小)", "yagasuri_S.png");
            materialDictionary.Add("矢絣②(大)", "yagasuri_L_2.png");
            materialDictionary.Add("矢絣②(小)", "yagasuri_S_2.png");
            materialDictionary.Add("翁格子(大)", "okinagoushi_L.png");
            materialDictionary.Add("翁格子(小)", "okinagoushi_S.png");
            materialDictionary.Add("一の字繋ぎ(大)", "ichinojitsunagi_L.png");
            materialDictionary.Add("一の字繋ぎ(小)", "ichinojitsunagi_S.png");
            materialDictionary.Add("鱗模様①(大)", "urokomoyou_L.png");
            materialDictionary.Add("鱗模様①(小)", "urokomoyou_S.png");
            materialDictionary.Add("鱗模様②(大)", "urokomoyou_L_2.png");
            materialDictionary.Add("鱗模様②(小)", "urokomoyou_S_2.png");
            materialDictionary.Add("子持ち縞①(大)", "komochijima_L.png");
            materialDictionary.Add("子持ち縞①(小)", "komochijima_S.png");
            materialDictionary.Add("子持ち縞②(大)", "komochijima_L_2.png");
            materialDictionary.Add("子持ち縞②(小)", "komochijima_S_2.png");
            materialDictionary.Add("釘抜(大)", "kuginuki_L.png");
            materialDictionary.Add("釘抜(小)", "kuginuki_S.png");
            materialDictionary.Add("釘抜繋ぎ(大)", "kuginukitsunagi_L.png");
            materialDictionary.Add("釘抜繋ぎ(小)", "kuginukitsunagi_S.png");
            materialDictionary.Add("分銅繋ぎ(大)", "fundoutsunagi_L.png");
            materialDictionary.Add("分銅繋ぎ(小)", "fundoutsunagi_S.png");
            materialDictionary.Add("曲輪繋ぎ(大)", "kuruwatsunagi_L.png");
            materialDictionary.Add("曲輪繋ぎ(小)", "kuruwatsunagi_S.png");
            materialDictionary.Add("井桁(大)", "igeta_L.png");
            materialDictionary.Add("井桁(小)", "igeta_S.png");
        }

        /// <summary>
        /// 素材を選択するコンボボックスを初期化する
        /// </summary>
        private void InitializeComboBox()
        {
            foreach (string value in materialDictionary.Keys)
            {
                ComboMaterial.Items.Add(value);
            }
        }

        /// <summary>
        /// コンボボックスの値が変更されたら、表示/使用する素材を書き換える
        /// </summary>
        /// <param name="sender">コンボボックス</param>
        /// <param name="e"></param>
        public void OnSelectionChangedComboMaterial(object sender, SelectionChangedEventArgs e)
        {
            string selectedDictionaryKey = ComboMaterial.SelectedValue.ToString();
            string selectedFileName = materialDictionary[selectedDictionaryKey];
            materialName = selectedFileName;
            Uri materialUri = GetUri(selectedFileName);
            ChangeMaterialImage(materialUri);
        }

        /// <summary>
        /// 表示ボタンを押したら、byte配列を用意して画像を表示する
        /// </summary>
        /// <param name="sender">ボタン</param>
        /// <param name="e">Args</param>
        public void OnClickButtonShowImage(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmapImage = (BitmapImage)DisplayMaterial.Source;
            SetLoopNumsFromTextbox(drawPattern);
            SetnextColorFromRectangle(drawPattern);
            loopedData = drawPattern.GetDataInBytes(bitmapImage);
            loopedWidth = drawPattern.GetloopedWidth();
            loopedHeight = drawPattern.GetloopedHeight();

            drawPattern.ChangeImage(loopedData, DisplayImage);

            bool isRedText = false;
            if (loopedWidth > DisplayImage.Width || loopedHeight > DisplayImage.Height)
            {
                isRedText = true;
            }
            ChangeExplainText(loopedWidth, loopedHeight, isRedText);
        }

        /// <summary>
        /// DisplayImage上部の説明テキストを変更する
        /// </summary>
        /// <param name="loopedWidth">画像の幅</param>
        /// <param name="loopedHeight">画像の高さ</param>
        /// <param name="isRedText">赤文字にするか</param>
        private void ChangeExplainText(int loopedWidth, int loopedHeight, bool isRedText)
        {
            if (isRedText)
            {
                ExplainText.Text = "画像はこの下に表示されます。\n画像サイズが大きいため、縮小して表示しています。";
                ExplainText.Text += "\nサイズ:(横:" + loopedWidth + "ピクセル, 縦:" + loopedHeight + "ピクセル)";
                SolidColorBrush brush = new SolidColorBrush(Colors.Red);
                ExplainText.Foreground = brush;
                DisplayImage.Stretch = Stretch.Uniform;
            }
            else
            {
                ExplainText.Text = "画像はこの下に表示されます。";
                ExplainText.Text += "\nサイズ:(横:" + loopedWidth + "ピクセル, 縦:" + loopedHeight + "ピクセル)";
                SolidColorBrush brush = new SolidColorBrush(Colors.Black);
                ExplainText.Foreground = brush;
                DisplayImage.Stretch = Stretch.None;
            }
        }

        /// <summary>
        /// 縦横の繰り返し数をテキストボックスからintにキャストする
        /// </summary>
        /// <param name="textbox">繰り返し数を提供するテキストボックス</param>
        /// <returns>くり返し数。キャストに失敗したら-1を返す。</returns>
        private int GetloopNum(TextBox textbox)
        {
            try
            {
                int parsedNum = int.Parse(textbox.Text);
                if (parsedNum > 30 || parsedNum < 1)
                {
                    throw new Exception("繰り返し数に指定できるのは1~30です");
                }
                return parsedNum;
            }
            catch (SystemException e)
            {
                ShowMessageBox("画像の繰り返し回数は半角数字のみで入力してください");
                return -1;
            }
            catch (Exception e)
            {
                ShowMessageBox(e.Message);
                return -1;
            }
        }

        /// <summary>
        /// 縦横の繰り返し数をインスタンスにセットする
        /// </summary>
        /// <param name="pc">セットされるインスタンス</param>
        private void SetLoopNumsFromTextbox(PatternController pc)
        {
            int loopNumWidth = GetloopNum(BoxLoopWidth);
            int loopNumHeight = GetloopNum(BoxLoopHeight);
            if (loopNumWidth == -1)
            {
                loopNumWidth = 1;
                BoxLoopWidth.Text = "1";
            }
            if (loopNumHeight == -1)
            {
                loopNumHeight = 1;
                BoxLoopHeight.Text = "1";
            }
            pc.SetloopNumWidth(loopNumWidth);
            pc.SetloopNumHeight(loopNumHeight);
        }

        /// <summary>
        /// 長方形から指定する色を取得してインスタンスにセットする
        /// </summary>
        /// <param name="pc">セットされるインスタンス</param>
        private void SetnextColorFromRectangle(PatternController pc)
        {
            byte[] colorBytesFore = GetBytesFromRectangle(RectangleShowsForeColor);
            byte[] colorBytesBack = GetBytesFromRectangle(RectangleShowsBackColor);
            bool equalFlag = false;
            for (int i = 0; i < colorBytesFore.Length - 1; i++)
            {
                if (colorBytesBack[i] != colorBytesFore[i])
                {
                    equalFlag = false;
                }
            }
            if (equalFlag) // RGCすべての値が等しかった場合
            {
                ShowMessageBox("前景色と背景色は同じ色に指定できません");
            }
            else
            {
                pc.SetnextRGBAOfForeGround(colorBytesFore);
                pc.SetnextRGBAOfBackGround(colorBytesBack);
            }
        }

        /// <summary>
        /// 長方形のRGB値を取得する
        /// </summary>
        /// <param name="rectangle">RGBを取得する長方形</param>
        /// <returns>RGB値(Aは255){R, G, B, 255}</returns>
        private byte[] GetBytesFromRectangle(Rectangle rectangle)
        {
            SolidColorBrush brush = (SolidColorBrush)rectangle.Fill;
            Color color = brush.Color;
            byte[] colorBytes = { color.R, color.G, color.B, 255 };
            return colorBytes;
        }

        /// <summary>
        /// 入力値が不適切な場合に警告を表示する
        /// </summary>
        /// <param name="str">警告メッセージ</param>
        private void ShowMessageBox(string str)
        {
            System.Windows.MessageBox.Show(str);
        }

        /// <summary>
        /// 保存ボタンを押したときに呼ばれる
        /// </summary>
        /// <param name="sender">ボタン</param>
        /// <param name="e">Args</param>
        public void OnClickButtonSave(object sender, RoutedEventArgs e)
        {
            if (loopedData != null)
            {
                FileController fileController = new FileController();
                BitmapSource source = (BitmapSource)DisplayImage.Source;
                fileController.PickFileAndSaveFile(source);
            }
        }

        /// <summary>
        /// モザイク加工ボタンを押したときに呼ばれる
        /// </summary>
        /// <param name="sender">ボタン</param>
        /// <param name="e">Args</param>
        public void OnClickButtonPutMosaic(object sender, RoutedEventArgs e)
        {
            if (loopedData != null)
            {
                loopedData = drawPattern.PutMosaic(loopedData, 70);
                drawPattern.ChangeImage(loopedData, DisplayImage);
            }
        }

        /// <summary>
        /// ぼかし加工ボタンを押したときに呼ばれる。画像を表示してから1回までしかぼかさない。
        /// </summary>
        /// <param name="sender">ボタン</param>
        /// <param name="e">Args</param>
        public void OnClickButtonPutGradation(object sender, RoutedEventArgs e)
        {
            if (loopedData != null)
            {
                loopedData = drawPattern.PutGradation(loopedData, 40);
                drawPattern.ChangeImage(loopedData, DisplayImage);
            }
        }

        /// <summary>
        /// テキストボックスの入力値を数値のみ受け付ける
        /// </summary>
        /// <param name="sender">テキストボックス</param>
        /// <param name="e">Args</param>
        public void OnBoxTextChanging(object sender, TextChangedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            int position = box.SelectionStart;
            string inputtedStr = new string(box.Text.Where(char.IsDigit).ToArray());
            box.SelectionStart = position;
            if (new Regex("[0-9]*").IsMatch(inputtedStr))
            {
                box.Text = inputtedStr;
            }
        }

        /// <summary>
        /// カラーピッカーの色が変更されたら、長方形の色も変更する
        /// </summary>
        /// <param name="sender">カラーピッカー</param>
        /// <param name="e">Args</param>
        public void OnPickerColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var picker = (ColorPicker)sender;
            Color color = (Color)picker.SelectedColor;
            SolidColorBrush brush = new SolidColorBrush(color);
            if(RadioForForeColor != null)
            {
                if (RadioForForeColor.IsChecked == true)
                {
                    RectangleShowsForeColor.Fill = brush;
                }
                else
                {
                    RectangleShowsBackColor.Fill = brush;
                }
            }
        }

        /// <summary>
        /// 長方形横のラジオボタンを変更した場合、カラーピッカーの色も変更する
        /// </summary>
        /// <param name="sender">チェックされたラジオボタン</param>
        /// <param name="e">Args</param>
        public void OnChangeColorRadio(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (ColorPicker != null && RectangleShowsForeColor != null)
            {
                if (button.Name == "RadioForForeColor")
                {
                    SolidColorBrush brush = (SolidColorBrush)RectangleShowsForeColor.Fill;
                    ColorPicker.SelectedColor = brush.Color;
                }
                else if (button.Name == "RadioForBackColor")
                {
                    SolidColorBrush brush = (SolidColorBrush)RectangleShowsBackColor.Fill;
                    ColorPicker.SelectedColor = brush.Color;
                }
            }
        }
    }
}

