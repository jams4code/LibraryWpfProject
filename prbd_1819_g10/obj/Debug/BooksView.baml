   M S B A M L   `   `   `  ����H  Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:prbd_1819_g10prbd_1819_g10  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5      C&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties  5          prbd_1819_g10.BooksView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:prbd_1819_g10     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      4p&clr-namespace:prbd_1819_g10.Properties     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      -   5        $  PRBD_Framework.UserControlBase   Name$
  root��5       � 	Resources 5         UnknownBook �� 	UriSource��%;   &	        �� 5   
   $ /images/unknownbook.jpg?�6*   5      .��5      �  � RowDefinitions 5   
   �� 5      $��1 �6   �� 5      $
��auto �6   �� 5      $	��10* �6   �� 5      $��40 �6   .+�5   
   � $��
10,1,10,10q�6   $��1��6#    � ColumnDefinitions 5      �� 5      �� 5      $
��auto �6#   $��41��60    5      �� 5      $��20 �6    �� 5      $
��auto �6    .+�5       �� (   "prbd_1819_g10.Properties.Resources   BooksView_Filter#��Z 6   $��0��6F   $��5,0,0,0q�6V   �� 5!      $��14(�6S   $��	69,0,36,0q�6a   $��2��6t   ��6   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�6t   �� 5"         BooksView_Clear#��Z 6   $��1��6F   $��10,0,0,0q�6v   ��6V   �� *ClearFilter+6v   �� 5#      $��1��6      BooksView_Category#��Z 6!   $��0��6U   $��5,0,0,0q�6e   $��0,5,0,-5q�6w   �� 5$      $��1��6   $��2��6$   $��69,5,0,0q�68   	 �� SelectedIndex$	 0��6m   ��6J   �� *
Categories+
 �� SelectedValue
 6   �� *SelectedCategory+$ PropertyChanged=�5%      �� 5&   
   -   5         ��Name$ listView��5&      
������  �� SelectionMode$ Single=�6^   $��Disabled=�6u   $��2��6�   ��6&   �� *Books+.  (System.Windows.Interactivity.Interaction   Triggers 5'      /  )System.Windows.Interactivity.EventTrigger  5(         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5)      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *DisplayBookDetails+   CommandParameter 5*   $   ��  �� ElementName$ listView�� �� Path$ SelectedItem�5+      ��5-      �� 5.      .R�5/      � 50      ��52      �� 53      .R�54      ��  �� CornerRadius$ 5��6   $��1q�6.   
�������._�55      �� $
��auto��6%   $	��110��63   $��10q�6?   .+�56      �� $��14(�6(    �� TextAlignment$ Center=�67   ��6N   �� *Isbn+�� 57      $��14(�6(   $
��Wrap=�66   $
��Bold"�6J   $ Center=�6\   ��6s   �� *Title+�� 58      $��14(�6(   $
��Wrap=�66   $ Center=�6J   ��6a   �� *Author+�� 59      $��14(�6(   $
��Wrap=�66   $ Center=�6J   ��6a   �� *Editor+ �� StringFormat$ ({0})���� 5:       �� BitmapScalingMode$
 Fant=�6�   $��UniformToFill=�6�   ��6%   �� *AbsolutePicturePath+ �� 	Converter .  (PRBD_Framework.UriToCachedImageConverter   �� TargetNullValue# [  6�   �� 5;      $��Center=�6N   ��6+   �� *
Categories+��5<   "   �� 5=   &   .R�5>   *   �� �� 5?   .    �� Command 68   �� *	SelectCat+$
 root�� �� CommandParameter 6g   �� .�6�   .�5@   2   �� $��Center=�6R   ��6<   �� *Name+6R   5A   /   5B   +   5C   '   5E      �� 5F      $��14(�6(   $
��Wrap=�66   $ Center=�6J   ��6a   �� *NumAvailableCopies+$  {0} copies available���� 5G       ��Name$ 
btnAddBask��6%   $��Add to basket��69   ��6Q   �� *AddToBasket+$
 root����6�   �� 5H      5I      5J      5L      �� 5M   
   -   5        $ btnNew��5M         BooksView_NewBook#��Z 6!   $
��Left=�6p   $��
10,10,0,10q�6�   $��3��6�   $	��5,1q�6�   $
��auto��6�   ��6T   �� *	NewBook+6�   5N      5O      