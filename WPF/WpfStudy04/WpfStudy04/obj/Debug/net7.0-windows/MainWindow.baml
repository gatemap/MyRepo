   M S B A M L   `   `   `  ����E  AWpfStudy04, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfStudy04
WpfStudy04  5   	       WpfStudy04.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfStudy04     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��260* �6   �� 5      $
��540* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $	��40* �6    �� 5      $	��35* �6    �� 5      $
��361* �6    .+�5      � -   5         �Name$ 
buttonGrid��5      $��1��6'   .+�5      �� -   5        $��
10,5,152,5q�5      $��Favorite��6-   $��	10,1,10,1q�6@   $��90��6T   $��25��6_   6k   �� 5      -   5        $��	10,5,60,5q�5      $	��←��6,   $��	10,1,10,1q�68   $��40��6L   $��25��6W   $��Right=�6c   6   �� 5      -   5         ��Name$ forwardButton��5      $��	10,5,10,5q�60   $	��→��6C   $��	10,1,10,1q�6O   $��40��6c   $��25��6n   $��Right=�6z   ${�False��6�   6�   5      � 5      -   5        $ 	radioGrid��5      $��2��6&   $��1��67   .+�5      	� -   5         	�Name$ addRadioButton��5      $	��Add��66   $
��Left=�6D   $��	20,11,0,0q�6_   $	��Top=�6r    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ loadRadioButton��5      $
��Load��67   $
��Left=�6F   $��	85,11,0,0q�6a   $	��Top=�6t   5      � 5      $��3��6   $��2��6$   .+�5      �� -   5         ��Name$ listBox��5      $��15,15,15,15q�6+   5       5!      5"      � 5#   
   $��1��6    5$      �� 5%      $	��15* �6    �� 5&      $
��130* �6    .+�5(      � -	   5        $ urlGrid��5(      .+�5)      �� -
   5         ��Name$ 
urlTextBox��5)      $
��Left=�6.   $��	15,10,0,0q�6I   	 �� TextWrapping$
	 Wrap=�6\   $��https://��6p   $	��Top=�6�   $	��420��6�   $��25��6�   $��16(�6�   $��5,0,0,0q�6�   �� 5*      -   5        $
��Move��5*      $��60��6(   $��25��63   $��Right=�6?   $��Center=�6[   $��0,0,15,0q�6v   6�   5+      � 5,      -   5        $ browserGrid��5,      $��1��6(   .+�5-      (  "System.Windows.Controls.WebBrowser  -   5        
  Name$
 
webBrowser��5-      $��	5,0,15,15q�61   5.      5/      51      52      