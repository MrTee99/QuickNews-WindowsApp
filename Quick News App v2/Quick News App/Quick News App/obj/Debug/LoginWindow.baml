   M S B A M L   `   `   `  ����E  AQuick News, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Quick_News_App.Custom_User_Controls#Quick_News_App.Custom_User_Controls  5   	        Quick_News_App.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:Quick_News_App.Custom_User_Controls     5   	   -   5        $��_this��5        � WindowStyle$
  None=�5	       � 
ResizeMode$ NoResize=�6    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterOwner=�5      $��Vintage Whiskey)�5       � Title$ LoginWindow��5   	   $	��400��6   $	��350��6*   .��5      ��    BG_MainForm#��[  6
   ._�5      � ��5      �� 5        MainBackgorundImage �� ImageSource# �  6    j� Stretch$ UniformToFill=�6E    � RowDefinitions 5      �� 5      $��35 �6   �� 5      $��* �6   .+�5      � -   5          BG_TitleBar#��[ 5   
    5       �� 5!      $��3 �6   �� 5"      $��* �6   �� 5#      $��2 �6    � ColumnDefinitions 5&      �� 5'      $��5 �6   �� 5(      �� 5)      �� 5*      �� 5+      �� 5,      $��5 �6   .+�50      �� $��1��51      $��1��6   $��3��6#   $��Quick News - Login��52      $��25(�6    $��Black"�6.   
�������$��Center=�54      $
��Left=�6!   $��0 0 0 3q�55      �� 58      $��1��6   $��4��6   	 �� Orientation$	 
Horizontal=�6.   $��Right=�6G   .+�5:      6   0Quick_News_App.Custom_User_Controls.CustomButton  -   5        
  Name$
 btn_Exit��5:      6   0Quick_News_App.Custom_User_Controls.CustomButton   Click$ btn_Exit_Click��6,      CusBtn_CornerRadius$ 2��5;         CusBtn_Margin$ 0 0 0 2q�5<         CusBtn_Padding$ 8 0 8 0q�6#      CusBtn_Foreground
 �����   CusBtn_Background
 �  ��   CusBtn_Hover �#b30000   CusBtn_Content$ X��5>      $��Black"�6   $��15(�61   $��Segoe UI)�6?   5@      5B      � 5D      $��1��6
    5F      �� 5G      $��10 �6   �� 5H      $��* �6   �� 5I      $��10 �6    5L      �� 5M      $��15 �6   �� 5N      �� 5O      �� 5P      �� 5Q      �� 5R      �� 5S      �� 5T      �� 5U      �� 5V      $��10 �6   .+�5Z      �� -   5         ��Name$ img_Logo��5Z      $��1��6   $��1��6.   $��2��6;   $��Center=�5[   	   $��Center=�6$     
LogoSource#���  5\   	   5]      �� 5`      $��1��6   $��3��6!   $��4��6.   $	 Vertical=�5a      $��Center=�5b      $��0 10 0 0q�6#   .+�5e      � $��Center=�6   .+�5f      �� $��40��6   
�������$��3��5g        TextBoxColor_Stroke#���  6*    �� RadiusX$ 10��5h   	    �� RadiusY$ 10��6   $
��10 0q�6#   �� 5i      -   5         ��Name$ input_LoginUsername��5i      $	��490��5j   	   $��30��6   $
��20 0q�5k   	   $	��0 5q�6    �� CharacterCasing$ Upper=�6%   $��20(�5l   	   $��DemiBold"�6   
������   TextBoxColor_Text#���  5m   "   $��0q�5n   	   
������ 6   �� 5o       J� IsHitTestVisible .  $��Username��5p   	   $��Center=�5q   	   $
��Left=�6$   $
��20 0q�5r   	     TextBoxColor_Placeholder#���  6   $��20(�5s   	   $��DemiBold"�6   ��5t   	   �� 5u   
    �� 
TargetType" ��6   .�5v      ��  �� Property � y� �� Value$ 	Collapsed=�6(    �� Triggers 5w      �� 5x       �� Binding 6   �� *Text+ �� ElementName$ input_LoginUsername�� �� Value  6R   .a�5y      ��  � y�$ Visible=�6*   5z      5|      5~   	   5      � 5�      $��Center=�6   $��0 10 0 0q�6)   .+�5�      �� $��40��6   
�������$��3��5�      #���  6*   $ 10��5�   	   $ 10��6   $
��10 0q�6#   G� 5�      -   5          G�Name$  input_LoginPassword��5�      $	��490��5�   	   $��30��6   $
��20 0q�5�   	   $	��0 5q�6   $��20(�5�   	   $��DemiBold"�6   
������ #���  5�   "   $��0q�5�   	   
������ 5�   	   �� 5�      -   5        ! ��Name$! txt_passPlaceholder��5�       .  $��Password��5�   	   $��Center=�5�   	   $
��Left=�6$   $
��20 0q�5�   	   #���  6   $��20(�5�   	   $��DemiBold"�6   5�      5�      �� 5�      $��1��6   $��7��6!   $	 Vertical=�6.   .+�5�        -   5        $
 	btn_Login��5�      $ btn_Login_Click��6-   $ 10��5�      $
 80 6q�5�      $��0 7 0 0q�6"   $��Center=�5�      $��Center=�6&     CustomButtonColor#��[ 5�      $ Login��5�      $��20(�6"   $��Black"�60   5�      5�      5�      5�      5�      