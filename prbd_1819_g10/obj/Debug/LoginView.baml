   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   H Dprbd_1819_g10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:prbd_1819_g10.Propertiesprbd_1819_g10.Properties 5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	      prbd_1819_g10.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   4p&clr-namespace:prbd_1819_g10.Properties     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	   	   -   5           PRBD_Framework.WindowBase   Name$  window��5   	   (  "prbd_1819_g10.Properties.Resources   LoginView_Title � Title# Z 5   	    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�5   G   $	��250��5   	   $	��200��6    � SizeToContent$ WidthAndHeight=�5   	    +� FocusedElement 5   	   ��  �� ElementName$ 	txtPseudo��.��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��2* �6   	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        
 ��Name$
 label��5         LoginView_UserName#��Z 6   $��Center=�6S   $��5q�6n   #   PRBD_Framework.ValidatedField  5   
   $��1��6   $��Center=�6+   .+�5      �� -   5         ��Name$ txtUserName��5       �� TextWrapping$
 Wrap=�6+   $��1��6?   ��5      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�5       �� 5#   
      LoginView_Password#��Z 6   $��1��6D   $��Center=�6Q   $��5q�6l     5$   
   $��1��6   $��1��6(   $��Center=�68   .+�5%      G� -   5         G�Name$ txtPassword��5%      #   PRBD_Framework.PasswordHelper   Attach . $��1��5(      $��1��6#   $��Center=�63      Password 5'      �� *
Password+$ PropertyChanged=�5(   3   5)      ]� 5,   
   $��2��6   $��2��6!   $��Center=�65   $��Center=�6P   $��10q�6m   .+�5-      �� -   5         ��Name$ 	btnCancel��5-         LoginView_Cancel#��Z 6(   $
��Left=�5.      $	��Top=�60   $��75��6H    �� IsCancel . $��0,0,10,0q�6c   ��5/      �� *Cancel+�� 50      -   5        $ btnLogin��50         LoginView_Login#��Z 6'   $
��Left=�51      $	��Top=�60   $��75��6H    �� 	IsDefault . $��10,0,0,0q�6d   ��52      �� *Login+53      ]� 56   
   $��3��6   $��2��6!   .+�57      �� $
��auto��6   $
��Wrap=�6&    �� TextAlignment$ Center=�6:   $��Center=�6Q   $	��220��6n   �� 58         LoginView_Message_1#�Z 6    �� 59       �� Command 6   �� *SignUp+.�68   ��    LoginView_Message_2#�Z 6<   6q    �� 5:         LoginView_Message_3#�Z 6   5;      5<      5=      5>      