   M S B A M L   `   `   `  ���� J  FJapanesePattern, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:JapanesePatternJapanesePattern       JapanesePattern.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:JapanesePattern     X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  かんたん和風文様��$	��700��$
��1000�� � Icon$ images/icon.png��.��� $	��900��$	��750�� � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��6* � � RowDefinitions �� $��9* ��� $	��25* ��� $��5* ��� $��6* ��� $	��45* �.+��� $��0��$��0��$��3�� �� Orientation$ 
Horizontal=�.+��� $ Vertical=�.+��� $��色を選択できます��$��Center=�$��
10,10,10,0q�$��15(�#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ ColorPicker��$
��Left=�$��Center=�   SelectedColor SaddleBrown J� RenderTransformOrigin$ 0.0,0.0&�$��10,10,10,10q�   DisplayColorAndName$
 True��z��� 	 �� ScaleX$
	 0.85Q�
 �� ScaleY$

 0.85Q��� $ 
Horizontal=�.+�	� -    	�Name$ RadioForForeColor�� 	� 	GroupName$ SelectColorChanged�� d� 	IsChecked$
 trueY�$��
10,10,0,10q�$��Center=��� $ Vertical=�.+��� -    ��Name$ ForeText��$��	前景色�� �� Left$ 30��$��16(�$��Right=��� -    ��Name$ RectangleShowsForeColor��$��40��$��40��
���E��$��10,0,0,0q��� $ 
Horizontal=�.+�	� -   $ RadioForBackColor��$ SelectColorChanged��$��
10,10,5,10q�$��Center=��� $ Vertical=�.+��� -   $ BackText��$��	後景色��$ 30��$��16(�$��Right=��� -   $ RectangleShowsBackColor��$��40��$��40��
�������$��5,0,0,0q��� -   $ ExplainText��$0��*画像はこの下に表示されます。��$��3��$��0��$��2��$��Center=�$	��Top=�$��18(�$��80�� �� TextAlignment$ Center=�$��10,10,10,10q��� $��2��$��0��$��3��$ 
Horizontal=�.+��� -	    ��Name$ ButtonShowImage��$��表示��$��10,0,0,0q�$��Center=� ^� ToolTip$ 画像を表示します��$��5,5,5,5q��� -
   $ 
ButtonSave��$��保存��$��10,0,0,0q�$��Center=�$ 画像を保存します��$��5,5,5,5q��� -   $ ButtonPutMosaic��$��モザイク加工��$��10,0,0,0q�$��Center=�$* $細かいモザイクを施します��$��5,5,5,5q��� -   $ ButtonPutGradation��$��	ぼかす��$��10,0,0,0q�$��Center=�$ 画像をぼかす��$��5,5,5,5q��� -    ��Name$ ComboMaterial��$��
10,0,10,10q�$	��140�� �� Text$ 素材を変更する�� �� 
IsReadOnly$
 True��$��3��$��0��$��3��$��30�� �� 
IsEditable$
 True��$��16(��� -    ��Name$ DisplayMaterial��$	��Top=�$
��None=�$	��200��$��0,20,0,0q�$��4��$��0��$��2��$��2���� $��4��$��2��$��2��$ Vertical=�.+��� -   $ 	WidthText��$��くり返し数(横)��$	��Top=�$��
10,0,10,10q�$��15(��� -    ��Name$ BoxLoopWidth��$��60��$��30��$��5�� �� TextWrapping$
 Wrap=�$	��Top=�$��18(��� -   $ 
HeightText��$��くり返し数(縦)��$	��Top=�$��15(�$��10,10,10,10q��� -   $ BoxLoopHeight��$��60��$��30��$��5��$
 Wrap=�$	��Top=�$��18(��� -   $ DisplayImage��$	��650��$	��550��$��1��$��3��$��5��$
��None=�$	��Top=�$��0,30,0,0q�