   M S B A M L   `   `   `  ����H  Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:prbd_1819_g10prbd_1819_g10  5      C&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5	          prbd_1819_g10.RentalsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:prbd_1819_g10     5      4p&clr-namespace:prbd_1819_g10.Properties     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5	      -   5        $  PRBD_Framework.UserControlBase   Name$
  root��5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $	��150��6   $��10q�6       AutoGenerateColumns .  ��6,   �� *	Rentals+ �� SelectedItem 6h   �� *SelectedRental+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Rental Date��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
RentalDate+6Y     5      $
 User��6%    .  63   �� *User.UserName+6U     5      $ #Items��6%    .  65   �� *	NbItems+6Q     5      $ #Open��6%    .  64   �� *NumOpenItems+6U   5        5   
   $��1��6    .     CanUserAddRows .  ��6"   �� *RentalItems+ 5        5      $
 Book��6%    .  63   �� *RentalItem.TitleBook+6\     5      $ Return Date��6%    .  6:   �� *RentalItem.ReturnDate+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5       $ Actions��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6:   
   
Visibility
 6F   �� *	IsAdmin+ �� ElementName$
 root��   	BoolToVis �� 	Converter# [     CellTemplate 5!      �� 5"      .R�5#      ��  �� Orientation$ 
Horizontal=�6)   $	��100��6B   y�6N   �� *	IsAdmin+$
 root��# [  .+�5$   "   ��  ��Name$ Return��6)   $��50��69   $��Return��6�   ��6D   �� *Return+$
 root����6p   �� y�6�   �� *IsNotReturned+# [  �� 5%   "   $ Cancel��6)   $��50��69   $��Cancel��6�   ��6D   �� *Cancel+$
 root����6p   �� y�6�   �� *
IsReturned+# [  �� 5&   "   $��50��6)   ��64   �� *Delete+$
 root����6`   �� .��6}   Delete6�   5'      5(      5*      5-      5.      5/      