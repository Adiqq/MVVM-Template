   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      e aGalaSoft.MvvmLight.Extras, Version=4.4.32.39728, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7jKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.ExtrasGalaSoft.MvvmLight.Command 5      P LMVVM Template Project, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Apex.ControlsApex.Controls 5      -   'MVVM_Template_Project.Views.Random_View   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      _commandKclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras     5      )aclr-namespace:Apex.Controls     5      -   5        $��Mvvm_Template_Demo��5	        � DataContext  5      �� *	Random_VM+   Locator �� Source# [  .��5      �� .+�5      ��   MyDefaultBorderTemplate#��[ 6   ._�5      � .+�5        Apex.Controls.ApexGrid     Columns$ Auto,*,Auto��6   .+�5      ��   MyTextBlockTemplate#��[ 6   $��
My Enums: ��6@   $��5q�5   
   �� 5      -   5        $��	Cmb_Names��5       �� IsTextSearchEnabled .  �� 
IsEditable .  $��0��5   
   $��1��6   $��5q�6'   $��1��5   
    �� SelectedIndex$ 0��6   ��5   "   �� *EnumCollection+5      5       5!      5"      �� 5&      #��[ 6   ._�5'      � .+�5(        $ Auto,*,Auto��6      Rows$< 6Auto,Auto,Auto,auto,auto,auto,auto,auto,auto,auto,auto��5)   	   .+�5-      �� #��[ 6   $��Random people:��5.   
   $��5q�5/   
   $��3��6   &   System.Windows.Controls.DataGrid  52      -   5        $��Dtgd_People��52         AutoGenerateColumns .     CanUserAddRows .  $��1��56      $��3��6   $	��210��57      	   GridLinesVisibility$	 
Horizontal=�6   ��53      �� *PeopelCollection+
   Columns
 58   	   0  *System.Windows.Controls.DataGridTextColumn  59   
   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5:         
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 59      �� *Name+5:        5;   
   $ Phone��5<       .  5;      �� *Phone+5<        5=   
   $ 
BirthDate ��5>       .  5=      �� *	BirthDate+5>       4  .System.Windows.Controls.DataGridTemplateColumn  5?   
   $ A Color��6!    .    CellTemplate 5@      �� 5A      .R�5B      � ��6   �� *	SomeColor+5C      5E      .   (System.Windows.Interactivity.Interaction   Triggers 5K   	   /   )System.Windows.Interactivity.EventTrigger  5L   
      	EventName$ MouseDoubleClick��6   .	   (System.Windows.Interactivity.TriggerBase 	  Actions. 5M      /
  )GalaSoft.MvvmLight.Command.EventToCommand
   
  Command 6"   �� *ListBoxDoubleClick_Command+ 
  CommandParameter 5N      ��  �� ElementName$ Dtgd_People�� �� Path$ SelectedItem�5O      5Q   	   �� 5R      #��[ 6   $=��7Double click on the listbox to pop up a message dialog.��5S   
   $��2��5T   
   $��0��6   $��5q�6'   $��3��62   �� 5[      -   5        $��Txtblk_Command1��5[      #��[ 5\   
   $��Names to refresh: ��67   $��7��5]   
   $��0��6   $��5q�6'   �� 5_      -   5        $��Cmb_NamesAmount��5_       .  $��7��5a   
   $��1��6   $��5q�6'   $ 0��5b   
   ��6   �� *RefreshNamesOptions+�� 5d      -   5        $��Txtblk_Command2��5d      #��[ 5e   
   $��(must be bigger than 3) ��67   $��8��5f   
   $��0��6   $��5q�6'   �� 5h      $��Refresh names command��6   $��8��5i   	   $��1��6   $��5q�5j   	   $��5q�6   $��Right=�5k   	    �� 	IsDefault . ��5l   	   �� $ RefreshPeople_Command���5m   	   �� $ Cmb_NamesAmount��$ SelectedItem�5n   	   5p      5q      5r      5s      5t      