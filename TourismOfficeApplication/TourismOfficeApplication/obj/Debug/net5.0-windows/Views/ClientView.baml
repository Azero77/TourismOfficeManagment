   M S B A M L   `   `   `  ����S  OTourismOfficeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TourismOfficeApplication.ViewsTourismOfficeApplication.Views  5      Y1clr-namespace:TourismOfficeApplication.Validators#TourismOfficeApplication.Validators  5      Y1clr-namespace:TourismOfficeApplication.Converters#TourismOfficeApplication.Converters  5      /    )TourismOfficeApplication.Views.ClientView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TourismOfficeApplication.Views     5      H
validators1clr-namespace:TourismOfficeApplication.Validators     5      H
converters1clr-namespace:TourismOfficeApplication.Converters     5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � 	Resources 5   
      ValidatorTextBoxA  ;TourismOfficeApplication.Converters.GenderPropertyConverter  GenderConverter �� 
TargetType �� Property �� Value��%�  &	        &	 $    '�� 7    7   �� 5      .R�5      �� .��5      ]� $
��True��6    .+�5      �� $��3��5       $��Right=�5!      
���  ��$��12(�5#      ��5$      �� *ErrorContent+6=   �� 5%      $��2q�5&      
���  ��._�5(      �� 5*      5+      5,      5-      5.        50      61   �� 51      " ��6   .�52      ��  �@=�ErrorTemplate8   53      54      56      .+�58   
   � -   5        $��PropertiesContainer��58      $��3��59       5;      �� 5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A        5D      �� 5E      $
��auto �6#   �� 5F      $��* �6#    z� SharedSizeGroup$ 
WidthGroup��6-   �� 5G      $��* �6#   .+�5J      �� $	��ID:��6   $��0��5K      $��0��5L      6&   �� 5M      ${�False��5N      $��0��5P      $��1��5Q      ��5O      �� *ID+5Q      �� 5T      $��	FirstName��5V      $��1��5W      $��0��5X      �� 5Y      $��1��5[      $��1��5\      ��5Z      �� *	FirstName+.��5]      5^      �� 5b      $��LastName��5c      $��2��5d      $��0��5e      �� 5f      $��2��5g      $��1��5h      ��5i      �� *
LastName+�� 5l      $��Gender��5m      $��3��5n      $��0��5o      �� 5u      $��3��5v      $��1��5w       �� SelectedValuePath$ Content��5y       �� SelectedValue 5x      �� *Gender+	 �� 	Converter#	 [ .@�5z      �� $��Gender��6   ${�False��60   �� 5{      $
��Male��6   �� 5|      $��Female��6   5}      �� 5�      $��Identity Path��5�      $��0��5�      $��4��5�      �� 5�      $��4��5�      $��1��5�      ��5�      �� *IdentityPath+�� 5�      $��5��5�      $��0��5�      $��NationalNumber��5�      �� 5�      $��5��5�      $��1��5�      ��5�      �� *NationalNumber+5�      ]� 5�   
   $��1��6   $��30q�5�      .+�5�      �� $
��Left=�6   $��Cancel��5�      ��5�      �� *CancelCommand+69   �� 5�      $��Right=�6   $��Confirm��5�      $��Right=�5�      {�5�      �� *
CanConfirm+��5�      �� *EditClientCommand+��5�      �� 5�   3   5�      �� 5�   
   $��0��6   $
��Left=�5�      $��	30 0 0 10q�5�      $��2��5�      $��Delete��5�      {�5�      �� *IsUpdateCommand+��5�      �� *DeleteClientCommand+��5�      �� 5�      5�      5�      