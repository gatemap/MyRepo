   M S B A M L   `   `   `  ����E  AWpfStudy01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfStudy01
WpfStudy01  5   	       WpfStudy01.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfStudy01     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         NoMouseOverButtonTemplate �� 
TargetType �� Triggers P� Property P� Value �� Value �� Property��%.  &	        �� 5
   
   " ��6<   .R�5      �� #��z��6   #��z��5      #��z��5      ._�5      �� #��z��6#   #��z��5      5       5      P� 5       � {�$ False��5   
   . �5      �� # Z�5       � ���� 5      # Z
�5       � ��5      5      5      .��5      � .+�5   
   �� $
��Left=�6   $��
252,47,0,0q�6/   $
��Wrap=�6C   $A��;Select a message option and then choose the Display button.��6W   $	��Top=�6�   	� 5   
   -   5         	�Name$ HelloButton��5      $��Hello��6+   	 d� 	IsChecked$
	 TrueY�6;   $
��Left=�6L   $��297,161,0,0q�6g   $	��Top=�6|   	� 5    
   -   5        $ GoodbyeButton��5       $��Goodbye��6-   $
��Left=�6?   $��488,161,0,0q�6Z   $	��Top=�6o   �� 5!   
   -   5        $��Display��5!      $
��Left=�6#   $��377,270,0,0q�6>   $	��Top=�6S   $��75��6k   6v   �� 5"   
   -   5        
 ��Name$
 	testImage��5"      $
��Left=�6#   $	��200��6>   $��557,202,0,0q�6K   $	��Top=�6`   $	��200��6x   $$��/Resources/방긋로아콘.jpg��6�   �� 5#   
   -   5        $
��Left=�5#      $��462,378,0,0q�6,   $	��Top=�6A   $��95��6Y   $��Show Picture��6�   �� 5$   
   -   5         ��Name$ changeButton��5$      $��Image Change��6'   
������ $	��325��6y   $	��145��6�   ��5%      �� 5&       �� ImageSource$ /Resources/love.png��6    j� Stretch$ UniformToFill=�6?   5(      5*      5+      