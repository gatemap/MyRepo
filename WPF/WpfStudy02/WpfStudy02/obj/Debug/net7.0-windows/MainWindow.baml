   M S B A M L   `   `   `  ����E  AWpfStudy02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfStudy02
WpfStudy02  5   	       WpfStudy02.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfStudy02     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��Open csv��5
      $
��Left=�6$   $	��Top=�6?   $	��100��6W   $��30��6f   $��	20,15,0,0q�6u   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ personDataList��5      $	��200��6+   $��	0,60,0,60q�6;   $	��400��6N      AutoGenerateColumns$ False��6^      CanUserAddRows$ False��6z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 이름��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$
 name�6O     5      $ 나이��6%   $ 70 6N    61   �� $	 age�6N     5      $ 설명��6%   $	 300 6O    61   �� $
 note�6O   5      �� 5   
   -   5        	 ��Name$	 filePathLabel��5      $��FilePath��6'   $
��Left=�6:   $��
145,17,0,0q�6U   $	��Top=�6i   $	��150��6�   $��30��6�   �� 5   
   -   5        $��Get Data��5      $��Right=�6$   $	��Top=�6@   $	��100��6X   $��30��6g   $��	0,15,20,0q�6v   6�   5      5      