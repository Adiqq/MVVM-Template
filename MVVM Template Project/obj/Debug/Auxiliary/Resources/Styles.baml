   M S B A M L   `   `   `  ����P  LMVVM Template Project, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullg8clr-namespace:MVVM_Template_Project.Auxiliary.Converters*MVVM_Template_Project.Auxiliary.Converters  5      g8clr-namespace:MVVM_Template_Project.Auxiliary.Converters*MVVM_Template_Project.Auxiliary.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F    @MVVM_Template_Project.Auxiliary.Converters.ErrorContentConverter   ErrConv  FlashErrorIcon  g� 	BeginTime �� TargetProperty R� KeyTime  System.Windows.Visibility   Hidden R� Value   Visible  myErrorTemplate �� 
TargetType �� Property �� Value	 � ToolTip
 �� ElementName �� Path �� 	Converter �� EndPoint �� 
StartPoint � Color � Offset � Triggers :� RoutedEvent �� Triggers P� Property P� Value �� Self �� RelativeSource �� BasedOn  MyDefaultBorderTemplate  MyLabelTemplate  MyButtonTemplate  MyTextBlockTemplate�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      G
converters8clr-namespace:MVVM_Template_Project.Auxiliary.Converters  5      CmyConv8clr-namespace:MVVM_Template_Project.Auxiliary.Converters  5      %�	  &	        &	      &	 �    7   7  7  7   '�� I    7  '�� k    7  '�� �    7  &	 �    &	 �    &	 2    &	 �       5	      62   �� 5      .��5      T� $  00:00:00X�6"   $ (UIElement.Visibility)�5      ..�5      i� $ 00:00:00��6   # Z 6/   i� 5      $ 00:00:00.7500000��6   # Z 67   i� 5      $ 00:00:01.5000000��6   # Z 67   i� 5      $ 00:00:02.2500000��6   # Z 67   i� 5      $ 00:00:03.0000000��6   # Z 67   i� 5      $ 00:00:03.7500000��6   # Z 67   5      5      �� 5      " ��6!   .�5      ��  �@=�ErrorTemplate 5      �� 5       .R�5!      ]� ��. .+�5"      A� $��Right=�6   $��18��5&   
   $��18��6   $��	-25,0,0,0q�5'   
   $��1��5(   
   
���  ��	 5#   
   �� $
 	myControl��$( "AdornedElement.(Validation.Errors)�8   ��5)      �� 5*   
   $ 1,0.5&�6   $ 0,0.5&�6/   .��5+      � $ 	#FFFA0404��6   $ 0Q�6*   � 5,      $ 	#FFC9C7C7��6   $ 1Q�6*   5-       5/   	   :� 50   
   $ FrameworkElement.Loaded��6   .[�51      �� 8�� 6   52      54   	   �� 55      $��Right=�6   
�������$
��11pt(�59   	   $��	-15,2,0,0q�5:   	   $
��Bold"�6   	 56   	   �� $
 	myControl��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�! 5;   	   :� 5<   
   $ FrameworkElement.Loaded��6   .[�5=      �� 8�� 6   5>      5@   	   �� 5A      
���  ��$��1q�6!   ._�5B   	   �� $��	myControl��6#   5C   	   5D      5E      5G       5H      P� 5I       �@=�HasError . . �5J      ��  �@�ToolTip 5K      �� # Z $ (Validation.Errors)�8  5N      5P      �� 5i      " ��6	   8   6   �� 5j      " ��6	   8   6   �� 5k      " ��6	   8   6   �� 5p      " ��6)   .�5q      ��  �@��CornerRadius$ 5��6#   �� 5r       � ��$ 2q�6   �� 5s       � ��
 ��� �6"   �� 5t       � ��$ 3q�6&   �� 5u       �@��Padding$ 5q�6   �� 5v       � ��
 �p�6!   5w      �� 5y      " ��6	   .�5z      ��  � ��
 � ���6!   �� 5{       � ��$ 5q�6   6)   5|      �� 5~      " ��6	   .�5      ��  � ��
 ��  �6!   �� 5�       � ��
 ��İ�6:   �� 5�       � ��$ 5q�6   6)   5�      �� 5�      " ��6	   .�5�      ��  � ��
 ����6!   �� 5�       � ��$	 5 2q�6   6+   5�      5�      