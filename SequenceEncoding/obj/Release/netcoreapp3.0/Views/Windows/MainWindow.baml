   M S B A M L   `   `   `  ���� K  GSequenceEncoding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SequenceEncodingSequenceEncoding  !    SequenceEncoding.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:SequenceEncoding       � Title$  Encoding��$	��450��$	��800�� � 
ResizeMode$ NoResize=� � Icon$6 0pack://Application:,,,/Services/Images/image.ico��.��� .+�� $	��450��$	��800��.+��� $��0,0,-1,0q� J� RenderTransformOrigin$ 0.512,0.338&����� .���  � Color$ #5879DB�� � Offset$	 0.5Q�� $ #2F4175��� $ #6287F5��$ 1Q��� $��Diagram��$��604,131,86,279q�$��40��$	��110��$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ 90.249Q�T� � $	��100��$	��350��$��279,100,171,250q� � ColumnDefinitions �� $	��82* ��� $	��93* �.+��� $	��100��$
��auto��$��Disabled=�$
��Auto=�$��False��$��2��.���� $	��100������ *	Drawing+���� .R���  ��Name$ Graphic��$��Center=�$	��200������ *CanvasWidth+��L� 	 j� TileMode$
	 Tile=�
 j� Viewport$
 -10,-10,20,20� j� ViewportUnits$ Absolute=� L� Drawing �  � Geometry ��  �� Rect$ 	0,0,60,60�
 � Pen >�  >� Brush
 ����� >� 	Thickness$ 1Q����� .R��� 
�������$��2��	 �� X1 �� *From.X+	 �� Y1 �� *From.Y+	 �� X2 �� *To.X+	 �� Y2 �� *To.Y+��  �� Orientation$ 
Horizontal=�$��40��$��10,34,0,376q�$	��770��$
��Left=�.+��� $��Decimal Code���� -    ��Name$ DecimalCodeBox��$
��Left=�$	��700������ *DecimalString+�� $ 
Horizontal=�$��40��$	��790��$��Center=�$��0,225,0,185q�.+��� $��Binary Code���� -   $ BinaryCodeBox��$	��630��$��25 0 0 0q�$
��Left=����� *BinaryString+�� $��Execute��$��40��$��376,344,266,66q�$
��Bold"����#328EA8
����������� *ExecuteConversion+	� -    	�Name$	 NPZ��$��30��$��225,288,422,132q�$��Not return to zero��$ 
0.439,0.58&� 	� 	GroupName$ Encoding�� d� 	IsChecked �� *SelectedNRZ+	� -   $	 BPC��$��30��$��Bipolar Pulse Coding��$��79,288,568,132q�$ Encoding�� �� *SelectedBPC+	� -   $	 AMI��$��30��$��360,288,287,132q�$��Bipolar AMI��$ 
0.439,0.58&�$ Encoding�� �� *SelectedAMI+	� -   $ 
Manchester��$��30��$��469,288,178,132q�$��Manchester Code��$ 
0.439,0.58&�$ Encoding�� �� *SelectedManchester+	� -   $ 	Potential��$��30��$��602,288,45,132q�$��Potential 2B1Q��$ 
0.439,0.58&�$ Encoding�� �� *Selected2B1Q+