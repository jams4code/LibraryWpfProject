   M S B A M L   `   `   `  ����H  Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:prbd_1819_g10prbd_1819_g10  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5      C&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties  5          prbd_1819_g10.BasketView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:prbd_1819_g10     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      4p&clr-namespace:prbd_1819_g10.Properties     5      -   5        $  PRBD_Framework.UserControlBase   Name$
  root��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � y�6   �� *	IsAdmin+ �� ElementName$
 root��   	BoolToVis �� 	Converter# [  .+�5   
   �� (   "prbd_1819_g10.Properties.Resources   BasketView_Label#��Z 6   $��
5,15,10,20q�6B   �� 5      $��75��6   $��20��6"   $��0,5,5,5q�6.    �� DisplayMemberPath$ UserName��6�    �� 
IsEditable .   �� SelectedItem 6?   �� *SelectedUser+��6e   �� *Users+|�6�   �� *	IsAdmin+5      � 5   
   y�6   �� *
IsNotAdmin+$
 root��# [  .+�5      ��    BasketView_Label_User#��Z 6   $��
5,15,10,20q�6K   5      &   System.Windows.Controls.DataGrid  5   
   $��1��6   $	��100��6    	   AutoGenerateColumns	 .  ��6-   �� *Books+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5          BasketView_HeaderColTitle,  &System.Windows.Controls.DataGridColumn   Header# Z 6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6k   �� *Title+  5      !   BasketView_HeaderColAuthor# Z 6%   $	 100 6`    6l   �� *Author+4  .System.Windows.Controls.DataGridTemplateColumn  5       "   BasketView_HeaderColActions# Z 6)   $	 100 6e      CellTemplate 5!      �� 5"      .R�5#      �� $��50��6%   ��60   �� *DeleteRental+$
 root����6b   �� .��6   Delete6�   5$      5&      5)      � 5+   
   $��5,20,5,5q�6   $��2��6&   .+�5,      �� -   5         ��Name$ 
btnConfirm��5,         BasketView_Confirm#��Z 6)   $
��auto��6y   $	��5,1q�6�   ��6]   �� *	Confirm+6�   �� 5-      -   5        $ btnClear��5-         BasketView_Clear#��Z 6'   $
��auto��6s   $��10,0,0,0q�6�   $	��5,1q�6�   ��6Y   �� *Clear+6�   5.      5/      50      