   M S B A M L   `   `   `  ����E  AQuick News, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Quick_News_App.Custom_User_Controls#Quick_News_App.Custom_User_Controls  5      F    @Quick_News_App.Custom_User_Controls.CustomRoundedButtonWithImage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Quick_News_App.Custom_User_Controls     5      -   5          >�Name$  _this��5       � 	Resources 5       �� 
TargetType   hoverDetectorEllipseStyle �� Property �� Value �� Triggers P� Property P� Value  ellipseStyle �� ElementName	 �� FallbackValue
 �� Binding �� Value��%l  &	        &	 �     �� 5      " A�6
   .�5      ��  � ��
 ���� 6    5      P� 5       �@J�IsMouseOver . . �5      ��  �@J�Opacity$ 0Q�6!   5      5      �� 5      " A�6
   .�5      ��  � �� 6   �� *BackgroundColor+$ _this��$		 Red�� 5      �� 5      
 6   �� *	Opacity+$ usedForHoverTrigger�� 06O   .a�5      ��  � �� 6   �� *
HoverColor+$ _this��$
	 Blue��5      P� 5       �@J�IsMouseOver . . �5      ��  � �� 6   �� *
HoverColor+$ _this��$
	 Blue��5      5!      5$      .��5&      � .+�5'      A� #��[ 6   �� 5(      -   5         ��Name$	 img��5(   
   $
��fill=�6   ��6&   �� *ImageSource+$ _this����6X   �� *EllipsePadding+$ _this��$	 10��A� 5)      -   5         A�Name$ usedForHoverTrigger��5)      #��[  6)   5*      5,      