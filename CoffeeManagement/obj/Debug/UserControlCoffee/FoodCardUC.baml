   M S B A M L   `   `   `  ����K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CoffeeManagement.UserControlCoffee"CoffeeManagement.UserControlCoffee  5      3    -CoffeeManagement.UserControlCoffee.FoodCardUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:CoffeeManagement.UserControlCoffee     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5        $��
foodCardUC��5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+   CommandParameter 6D   ��  �� ElementName$ 
foodCardUC��5      .��5      &   MaterialDesignThemes.Wpf.Flipper  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6   	   FrontContent	 5   
   #  MaterialDesignThemes.Wpf.Card  5      
���`���.��5      � 
 � RowDefinitions
 5      �� 5       $	��100 �6(   67   �� 5!      $��35 �6(   66   �� 5"      $��25 �6(   66   �� 5#      $
��auto �6(   68   .+�5%      �� $��0��6   $��3q�6)   ��64   �� *ProductImage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5&      �� 5'      $��1��6   $��11(�6+   
������  �� TextAlignment$ Center=�6S   $��Center=�6�    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   ��6j   �� *ProductName+$ TwoWay=�$ PropertyChanged=�6�   �� 5)      $��2��6   $��13(�6)   $��Center=�6�   $��Center=�6�   
�������$
��Bold"�6�   ��67   �� *ProductPrice+$ TwoWay=�$ PropertyChanged=�6�   �� 5+      -   5         ��Name$ btnFlip1��5,   Y   $��3��5+      $��3q�6*     MaterialDesignRaisedButton#��[ 65      FlipCommand#��Z 5,   !   $��Chọn��5-   !    5.        5/      $ Click��6-   . 50   "      68   �� *Btn1ClickCommand+ 6]   �� $ 
foodCardUC��51      53      55      56         BackContent 58   
     59      $	��200��6"   $	��170��6/   .��5:      � $��3q�6   
 5;      �� 5<      $
��auto �6(   68   �� 5=      6*   �� 5>      $
��auto �6(   68   .+�5@      �� $��0��6!    �� Orientation$ 
Horizontal=�6.   $	��0 5q�6G   .+�5A      �� -   5        $ btnFlip2��5A   ]    & "MaterialDesignToolForegroundButton#��[ 6!   #��Z 5B   !   $
��Left=�6Y   .��5C      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ 	ArrowLeft=�66   $��Right=�6G    5D        5E   "   $ Click��61   . 5F   &      6<   �� *Btn2ClickCommand+ 6a   �� $ 
foodCardUC��5G   #   5I      �� 5J      -   5        )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Số lượng��5J   "   $��15 0 0 0q�6L    % !MaterialDesignFloatingHintTextBox#��[ 5L   "   $��Center=�6]   ��5K   "   �� *ProductAmount+$ TwoWay=�$ PropertyChanged=�5L   ]   5M      �� 5N      $��1��6    ! MaterialDesignOutlinedTextBox#��[ 6+   $��Center=�6b   $	��110��6~   $	��3 0q�6�    . $
 Wrap=�5P   +   " �� VerticalScrollBarVisibility$
 Auto=�6?   $ Ghi chú...��6b   ��5O      �� *Note+$ TwoWay=�$ PropertyChanged=�5P   b   � 5Q      $��2��6   .+�5R      �� $��25��6!   $	��100��6-   $��Center=�69   $	��0 5q�6T   ��5S   !   �� *SelectCommand+��6C   �� $ 
foodCardUC��.��5T      	  $ Check=�66   5U      5V      5W      5X      5Z      5[      