   M S B A M L   `   `   `  ����S  OTourismOfficeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:TourismOfficeApplication.Converters#TourismOfficeApplication.Converters  5      O,clr-namespace:TourismOfficeApplication.ViewsTourismOfficeApplication.Views  5      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 6I   3    -TourismOfficeApplication.Views.ClientListView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H
converters1clr-namespace:TourismOfficeApplication.Converters     5      >local,clr-namespace:TourismOfficeApplication.Views     5      dloadingspinnercontrolBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     6I     � 	Resources  5         BooleanToVisibiltyConverter<   6TourismOfficeApplication.Converters.AddNumberConverter  AddNumberConverter  StateMessage � DataContext �� 	Converter  ErrorMessage��%m  &	        &	      &	 *     7   &	 �     7   �� 5   
   6'     5   
   5      �� 5   
   
���"�"� 5      �� *StatusMessageViewModel+��5      �� *	Message+y�5      �� *
HasMessage+8   �� 5   
   
���  �� 5      �� *ErrorMessageViewModel+��5      �� *	Message+y�5      �� *
HasMessage+8   5"      .��5$      � -   5        $��GridContainer��5$       � RowDefinitions 5&   
   �� 5'      $
��auto �6   �� 5(      �� 5)      $
��auto �6    � ColumnDefinitions 5+   
   �� 5,      �� 5-      .+�5/   
   �� $��0��50      $��Stretch=�51      .+�53      ]� $��5q�54      $
��True��55      .+�56      �� .��6   Search6    �� 58      -   5        $��ComboBoxSearchCategory��5;      $��Right=�59       �� SelectedValue$ 	FirstName��5:      $
��auto��5<      $	��Top=�5=      ��58      �� *GetPropertiesNames+5?      �� 5A      $��Bottom=�6   .+�5B      �� #���  6%   �� 5C      #���  6%   5D      �� 5E      -   5        $��SearchQueryTextBox��5F      $��30��5G      .��5H      5J      5K      �� 5Q      $��
البحث��6   $��Right=�5R      ��5S      �� *SearchCommand+��5U      `� 5V       `� 	Converter 5W      F   @TourismOfficeApplication.Converters.MultiCategorySearchConverter  5X      .1�5Z      ��  �� ElementName$ SearchQueryTextBox��6"    �� Path$
 Text�6C   �� 5[      $ ComboBoxSearchCategory��6"   $ SelectedItem�6G   5\      5^      �� 5`      	 �� Orientation$	 
Horizontal=�6   .+�5a      �� $	 
Horizontal=�6   .+�5b      �� .��6   عدد العناصر6)   �� 5c      $��25��68   ��6   �� *
PageSize+6H   5d      5f      5g      � 5h   
   $��1��6   $��2��6   ��5i      �� 5j      
 �� 
TargetType"
 �6    �� Triggers 5k      �� 5l       �� Binding 6&   �� *	IsLoading+ �� Value	 false6D   .a�5m      ��  �� Property � y� �� Value$ Visible=�6;   5n      .�5p      ��  � y�$ 	Collapsed=�63   5q       5t      �� 5u      $��* �6    �� 5v      $
��auto �6    .+�5x      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridContainer��5      $��0��5z         CanUserAddRows$ False��5{      $��2��5|         AutoGenerateColumns$ False��5~      ��5}      �� *	Clients+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *ID+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
 Name��6-      CellTemplate 5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *    �� StringFormat$ {0} {1}��67   .1�5�   .   �� $ 	FirstName�66   �� 5�   .   $ LastName�66   5�   +   5�   #   5�      5�        5�       5�      �� 5�      .R�5�   "   �� $��Show Details��5�   )   ��5�   )   �� * DataContext.ShowDetailsCommand+ �� RelativeSource ��  �� AncestorType UserControl��5�   )   �� 5�   )   5�      5�        5�       5�      �� 5�      .R�5�   "   �� $
��Edit��5�   )   ��5�   )   �� *DataContext.EditClientCommand+ ��  UserControl��5�   )   �� 5�   :   5�      5�      5�      ]� 5�      $��1��6   $
��True��5�      .+�5�      �� $
��Left=�5�      ��5�      `� 5�       5�        5�   "   .1�5�      �� $ Clients�6&   �� 5�      $ CurrentPage�6&   �� 5�      $ 
PagesCount�6&   5�      ��5�      �� 5�      $ MoveNextCommand�6"   $
��Next��5�   &   5�      �� 5�      $��Right=�5�      ��5�      `� 5�       5�        5�   "   .1�5�      �� $ Clients�6&   �� 5�      $ CurrentPage�6&   �� 5�      $ 
PagesCount�6&   5�      ��5�      �� 5�      $ MovePrevoiusCommand�6"   $��Previous��5�   &   5�      �� 5�      ��6   �� *Clients.Count+6=   �� 5�      $��1q�6   
���   �._�5�      �� .+�5�      �� .��6    CurrentPage:6.   �� 5�      ��6$   �� *CurrentPage+# [  �� ConverterParameter$ 1��5�      5�      �� 5�      ��6   �� *
PagesCount+5�      5�      *  $LoadingSpinnerControl.LoadingSpinner  5�   
   -   5        $��LoadingSpinner��5�      $��1��5�      $��2��5�      $��Center=�5�         	Thickness$ 2Q�5�         	IsLoading 5�      �� *	IsLoading+5�      5�      5�      