   M S B A M L   `   `   `  ����E  AQuick News, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Quick_News_App.Custom_User_Controls#Quick_News_App.Custom_User_Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   BG_MainForm �� Property �� Value  Form_BackgroundColor �� Color  Form_BorderColor  BG_TitleBar  FG_TextBlock  	TextColor  FG_Headline_TextBlock  HeadlineTextColor  FG_Category_TextBlock 	 CategoryTextColor6    0Quick_News_App.Custom_User_Controls.CustomButton 
 CustomButtonColor  ButtonColor_Normal  ButtonColor_Hover  ButtonColor_TextF   @Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder  CustomTextboxColor  TextBoxColor_Hint  TextBoxColor_Outline � Color  TextBoxColor_ForegroundF   @Quick_News_App.Custom_User_Controls.CustomRoundedButtonWithImage  RoundImageButtonColor?   9Quick_News_App.Custom_User_Controls.CustomButtonWithImage  NormalImageButtonColor ! ComboBoxNormalBackgroundBrush # ComboBoxDisabledForegroundBrush # ComboBoxDisabledBackgroundBrush  ComboBoxDisabledBorderBrush �� Opacity �� 
TargetType   ComboBoxToggleButtonTemplate � ColumnDefinitions  TextBoxColor_Stroke �� CornerRadius	 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect
   ShadowDepth   
BlurRadius �� Triggers P� Property P� Value �� 
TargetName  ComboBoxFlatStyle �� 	ClickMode d� 	IsChecked �� Path �� RelativeSource �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
IsReadOnly �� 
IsReadOnly � AllowsTransparency �� IsDropDownOpen J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  ComboBoxItemColor_Hover-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;local1clr-namespace:Quick_News_App.Custom_User_Controls  5      %  &	        &	     &	 m    &	 �    &	 A    &	
 �    &	 �    &	 ,    &	 �    &	 �    &	 �    &	 �    &	     (�� ;    5z      * SystemColors.HighlightBrushKey+)&	 i    7  7  7  7  7  7  &	      7  7  '�� �    �� 5      "  ��6	   .�5      ��  �@��CornerRadius$ 5��6#   �� 5       � ��$ 8q�6&   �� 5       � �� 5	      �� 5
      # �  6   5      �� 5       � �� 5      �� 5      # �  6   5      5      �� 5      "  �6	   .�5      ��  � �� 5      �� 5      # �  6   5      5      �� 5      "  ��6	   .�5      ��  � �� 5      �� 5      # �  6   5!      5"      �� 5$      "  ��6	   .�5%      ��  � �� 5&      �� 5'      # �  6   5)      5*      �� 5,      "  ��6	   .�5-      ��  � �� 5.      �� 5/      # � 	 6   51      52      �� 54      "    6	   .�55      ��  �@  CusBtn_Background 56      �� 57      # �  6   59      �� 5:       �@  CusBtn_Hover 5;      �� 5<      # �  6   5>      �� 5?       �@  CusBtn_Foreground 5@      �� 5A      # �  6   5C      5D      �� 5F      "   6	   .�5G      ��  �@ PlaceholderColor 5H      �� 5I      # �  6   5K      �� 5L       �@ OutlineNormal 5M      
� 5N      .��5O      � # �  6   5P      5R      �� 5S       �@ ForegroundNormal 5T      
� 5U      .��5V      � # �  6   5W      5Y      5Z      �� 5\      "   6	   .�5]      ��  �@ BackgroundColor 5^      �� 5_      # �  6   5a      �� 5b       �@ 
HoverColor 5c      �� 5d      # �  6   5f      5g      �� 5i      "   6	   .�5j      ��  �@ BackgroundColor 5k      �� 5l      # �  6   5n      �� 5o       �@ 
HoverColor 5p      �� 5q      # �  6   5s      5t      �� 5v      $ White��69   �� 5w      $
 #888��6;   �� 5x      $
 #eee��6;   �� 5y      $
 #888��67   �� 5z      $ Black��6E   $	 0.3Q�6S   �� 5|      " d�6   .R�5}      �  5~      �� 5      �� 5�      $��20 �6   .+�5�      �� $��ButtonBorder��6P   $��1��6   #���  6   $ 	0 10 10 0��5�      $��0q�6!   8��  5�      �� 5�      $��Border��6    $��2��6   #���  5�      $ 10��5�      $��3q�6   8�� 	 5�        5�      $
 0Q�6   $ 2Q�6(   5�      F� 5�      $��Arrow��6
   $��1��6   =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=�5�   	   #���  6&   $��0 0 12 0q�6S   $��Center=�5�   	   5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ ButtonBorder��6)    � ��
 �����6C   5�      P� 5�       �@d�	IsChecked$
 TrueY�6/   . �5�      �� $ ButtonBorder��6)    � ��
 �����6C   �� 5�      $ Arrow��6#    � �� �	#FF8D979E66   5�      P� 5�       � {� .  . �5�      �� $ Border��6)   8   � ��6=   �� 5�      $ ButtonBorder��6)   8   � ��6C   �� 5�      $ ButtonBorder��6+   8   � ��6E   �� 5�      8   � ��6/   �� 5�      $ Arrow��6#    � �� �#99966   5�      5�      �� 5�      "  ��6	   .�5�      ��  �@��
IsEditable .  6!   �� 5�       �@��IsTextSearchEnabled . 6*   �� 5�      ! �@��IsTextSearchCaseSensitive .  60   �� 5�       � ��$	 100��6   �� 5�       � ��$ 3q�6   �� 5�       � ��$ Center=�6(   �� 5�       � ��$ Stretch=�6*   �� 5�       �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 6=   �� 5�       � ��$
 Auto=�6A   �� 5�       � ��$
 Auto=�6?   �� 5�       � �� . 64   �� 5�       � ��
 �   �6-   �� 5�       �@��IsDropDownOpen .  6%   �� 5�       �@�FocusVisualStyle 68   Z� �� 5�       � �� 5�      �� 5�      " ��6   .R�5�      � .+�5�      d� $��ToggleButton��6   $��2��6)   $ Press=�5�   
   |�.  8��   5�   
   �� $ IsDropDownOpen� �� *TemplatedParent+$ TwoWay=�5�   
   �� 5�      $��ContentSite��6   $��10, 3, 23, 3q�6,    .  $
��Left=�5�      $��Center=�66   #��z 5�      #��z 5�      #��z��5�      �� 5�      $��PART_EditableTextBox��6   $��3, 3, 23, 3q�6,   # z 5�      $y�Hidden=�5�      
������ $
��Left=�5�      $��Center=�6-   |�. .��5�   $   ��5�   	   �� 5�   
   " ��6   .R�5�      �� $��PART_ContentHost��6   $ 4��6*   |�.  6;   5�      .��5�      5�   	   � 5�      $��Popup��6   $��Bottom=�6   |�.   . #��z 5�      $��Slide=�5�      .��5�   	   � $��DropDown��6    . #��z 5�   	   #��z 5�   	   
������ .+�5�   
   �� $��DropDownBorder��6   
�������$��
0, 1, 0, 0q�6:   $ 10��5�   
   $��5q�6   #���  5�   
   	 5�        5�      $
 0Q�6   $ 2Q�6-   5�      �� 5�   
   $��4q�6    . .��5�      �� $ 	Contained=�6   5�      5�   
   5�   	   5�       5�      P� 5�       �@��HasItems .  . �5�   	   �� $ DropDownBorder��66    � ��$ 95��6R   5�   	   P� 5�       � {� .  . �5�   	   �� 8   � ��62   5�   	   P� 5�       �@��
IsGrouping . . �5�   	   ��  � �� .  69   5�   	   P� 5�       �@��
IsEditable . . �5�   	   ��  �@ 	IsTabStop .  68   �� 5�   	   $ PART_EditableTextBox��60    � y�$ Visible=�6R   �� 5�   	   $ ContentSite��60    � y�$ Hidden=�6I   5�   	   5�      5�      5�      �� 5�      "  ��6	   �5�      �� 5�       � ��# �  6"   �� 5       � ��$ 20(�6    �� 5      � ��$	 6 2q�6   5     5     