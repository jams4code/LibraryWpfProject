   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      H Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:prbd_1819_g10prbd_1819_g10 5	      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5
      C&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties 5      "   prbd_1819_g10.BookDetailView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Iwpf9http://schemas.microsoft.com/netfx/2007/xaml/presentation     5      6sys&clr-namespace:System;assembly=mscorlib     5      X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      'localclr-namespace:prbd_1819_g10  5	      <f4clr-namespace:PRBD_Framework;assembly=PRBD_Framework  5
      .p&clr-namespace:prbd_1819_g10.Properties  5      -   5        $  PRBD_Framework.UserControlBase   Name$
  root��5      $	��835��6    � 	Resources 5         UnknownBook �� 	UriSource  	BoolToVis��%X   &	        &	 1     �� 5   
   $ /images/unknownbook.jpg?�6*   �� 5   
   6'   5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      .+�5%   
   �� (  "prbd_1819_g10.Properties.Resources   BookDetailView_Isbn#��Z 6   #  PRBD_Framework.ValidatedField  5&   
   $��1��6   $��Center=�6+   $��	0,4,200,4q�6F   .+�5'      �� -   5         ��Name$ txtIsbn��5'      ��6'   �� *Isbn+ �� UpdateSourceTrigger$ PropertyChanged=�{�5(      �� *IsNotMemeber+5)      �� 5,   
      BookDetailView_Title#��Z 6   $��1��6F     5-   
   $��1��6   $��1��6+   $��Center=�68   $��	0,4,200,4q�6S   .+�5.      �� -   5        $ txtTitle��5.      ��6(   �� *Title+$ PropertyChanged=�{�5/      �� *IsNotMemeber+50      �� 53   
   	   BookDetailView_Author#��Z	 6   $��2��6G     54   
   $��1��6   $��2��6+   $��Center=�68   $��	0,4,200,4q�6S   .+�55      �� -   5        $ 	txtAuthor��55      ��6)   �� *Author+$ PropertyChanged=�{�56      �� *IsNotMemeber+57      �� 5:   
   
   BookDetailView_Editor#��Z
 6   $��3��6G     5;   
   $��1��6   $��3��6+   $��Center=�68   $��	0,4,200,4q�6S   .+�5<      �� -   5        $ 	txtEditor��5<      ��6)   �� *Editor+$ PropertyChanged=�{�5=      �� *IsNotMemeber+5>      �� 5A   
      BookDetailView_Category#��Z 6   $��4��6I   �� 5C   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��
10,5,10,10q�6K   .+�5D      �� ��6   �� *CategoriesList+{�6B   �� *IsNotMemeber+��5E      �� 5F      .R�5G      �� $ 
Horizontal=�6%   5H      ��5J      �� 5K      .R�5L      �� $	��5 0q�6@   ��6#   �� *
Cat.Name+ d� 	IsChecked 6N   �� *	IsChecked+��6n   �� *Check+ �� ElementName$
 root����6�   �� {�6�   �� *IsNotMemeber+5M      5O      5P      �� 5S   
      BookDetailView_Picture#��Z 6   $��5��6H   � 5U   
   $��5��6   $��1��6    5V      �� 5W      $
��auto �6#   �� 5X      $
��auto �6#   �� 5Y      $
��auto �6#   .+�5\      �� -   5         ��Name$	 img��5\      $��0��6!   $��50��61   $	��250��6?   $	��250��6N   $	��Top=�6^    �� BitmapScalingMode$
 Fant=�5^      $��0,5,5,0q�6;   $	��201��6L   ��5]      �� *PicturePath+ �� 	Converter .  (PRBD_Framework.UriToCachedImageConverter   �� FallbackValue# [   �� TargetNullValue# [  5^   L   �� 5`      $��5q�6   $��1��6$   $
��Left=�64   .+�5a      �� -   5         ��Name$ btnLoad��5a         BookDetailView_Load#��Z 6*   $��75��6_   $	��Top=�6j   $��0,0,0,5q�6�   ��6�   �� *	LoadImage+{�6�   �� *IsNotMemeber+�� 5b      -   5        $ btnClear��5b         BookDetailView_Clear#��Z 6+   $��75��6a   $	��Top=�6l   $��0,0,0,5q�6�   ��6�   �� *
ClearImage+{�6�   �� *IsNotMemeber+5c      �� 5d      -	   5         ��Name$ copies��5d      $��10q�6)   $��2��65   $��Right=�6E   y�6a   �� *
IsNotNew+# [ .+�5e      �� $��Book Copies��6   $
��Wrap=�6/   $��16(�6C   $
��Bold"�6Q    �� TextAlignment$ Center=�6c   &   System.Windows.Controls.DataGrid  5f         
IsReadOnly . $	��175��6.   $	��400��6;      AutoGenerateColumns .  ��6c   �� *
BookCopies+{�6�   �� *IsNotMemeber+   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
BookCopyId+  5i      $ Acquisition Date��6-    6G   �� *AcquisitionDate+  5j      $ 	Rented by��6-    6@   �� *
NameRenter+5l      � 5m      $	��400��6   $��5q�6(   {�63   �� *IsNotMemeber+.+�5n      �� $��Date:��6   &	   Xceed.Wpf.Toolkit.DateTimePicker	  5o      &
   Xceed.Wpf.Toolkit.DateTimeUpDown 
  Format$ FullDateTime=�6*   $
��auto��6@   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]    Value  6M   �� *AddCopiesDate+{�6m   �� *IsNotMemeber+�� 5p      $
��Qty:��6   $��5,0,0,0q�6+   %  Xceed.Wpf.Toolkit.IntegerUpDown  5q      -
   5        $��myUpDownControl��5q   )   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   DefaultValue$! 1X�6@   "   Minimum$" 1X�6Q   #   Value# 6]   �� *
NbCopies+{�6x   �� *IsNotMemeber+�� 5r      -   5        $ txtAddCopies��5r      $	��Add��63   $��50��6_   $��10,0,0,0q�6j   ��6A   �� *	AddCopies+{�6|   �� *IsNotMemeber+5s      5t      5u      � 5x   
   $��6��6   $
��Left=�6!   $��Bottom=�6<   $��1��6W   $
��auto��6g   {�6t   �� *IsNotMemeber+.+�5y      �� -   5        $ 	btnCancel��5y      $   BookDetailView_Cancel#��Z$ 6(   $
��auto��6z   $	��5,1q�6�   ��6_   �� *Cancel+{�6�   �� *IsNotMemeber+�� 5z      -   5        $ btnSave��5z      %   BookDetailView_Save#��Z% 6&   $
��auto��6t   $��10,0,0,0q�6�   $	��5,1q�6�   ��6[   �� *Save+{�6�   �� *IsNotMemeber+�� 5{      -   5        $ 	btnDelete��5{      &   BookDetailView_Delete#��Z& 6(   $
��auto��6z   $��10,0,0,0q�6�   $	��5,1q�6�   ��6_   �� *Delete+{�6�   �� *IsNotMemeber+5|      5}      5~      