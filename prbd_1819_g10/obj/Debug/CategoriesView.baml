   M S B A M L   `   `   `  ����H  Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:prbd_1819_g10prbd_1819_g10  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5      C&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties  5	      "    prbd_1819_g10.CategoriesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:prbd_1819_g10     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      4p&clr-namespace:prbd_1819_g10.Properties     5	      -   5        $  PRBD_Framework.UserControlBase   Name$
  root��5
      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��10q�6   $	��150��6   $
��auto��6,      AutoGenerateColumns .     SelectionMode$ Single=�6�   ��6U   �� *
Categories+ �� SelectedItem 6x   �� *SelectedCategory+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      (   "prbd_1819_g10.Properties.Resources    CategoriesView_NameHeader,  &System.Windows.Controls.DataGridColumn   Header# Z 6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6_   �� 
 �� Path$

 Name�6     5      #   CategoriesView_NbBooksHeader# Z 6%    . 	 6b   �� *	NbBooks+6~   5      � 5   
   $��1��6   .+�5      �� -   5         ��Name$ txtCat��5      $	��200��6&   ��62   �� *CategoryName+ �� UpdateSourceTrigger$ PropertyChanged=� �� 
IsReadOnly 6t   �� *
IsNotAdmin+�� 5      -   5         ��Name$ btnAdd��5         CategoriesView_Add#��Z 6%   $
��auto��6q   $��10,0,0,0q�6~   $	��5,1q�6�   ��6Y   �� *Add+y�6�   �� *	IsAdmin+   	BoolToVis �� 	Converter# [  �� 5      -   5        $ 	btnUpdate��5         CategoriesView_Update#��Z 6(   $
��auto��6z   $��10,0,0,0q�6�   $	��5,1q�6�   ��6_   �� *Update+y�6�   �� *	IsAdmin+# [  �� 5      -   5        $ 	btnCancel��5         CategoriesView_Cancel#��Z 6(   $
��auto��6z   $��10,0,0,0q�6�   $	��5,1q�6�   ��6_   �� *Cancel+y�6�   �� *	IsAdmin+# [  �� 5      -   5        $ 	btnDelete��5         CategoriesView_Delete#��Z 6(   $
��auto��6z   $��10,0,0,0q�6�   $	��5,1q�6�   ��6_   �� *Delete+y�6�   �� *	IsAdmin+# [  5      5!      5"      