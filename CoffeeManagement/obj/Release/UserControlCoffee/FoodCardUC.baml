   M S B A M L   `   `   `  ���� K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CoffeeManagement.UserControlCoffee"CoffeeManagement.UserControlCoffee  3    -CoffeeManagement.UserControlCoffee.FoodCardUC   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:CoffeeManagement.UserControlCoffee     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��
foodCardUC��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���  .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+   CommandParameter ��  �� ElementName$ 
foodCardUC��.��&   MaterialDesignThemes.Wpf.Flipper  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�	   FrontContent	 #  MaterialDesignThemes.Wpf.Card  
���`���.��� 
 � RowDefinitions
 �� $	��100 ��� $��35 ��� $��25 ��� $
��auto �.+��� $��0��$��3q����� *ProductImage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��11(�
������  �� TextAlignment$ Center=�$��Center=� �� AcceptsReturn .  �� TextWrapping$
 Wrap=����� *ProductName+$ TwoWay=�$ PropertyChanged=��� $��2��$��13(�$��Center=�$��Center=�
�������$
��Bold"����� *ProductPrice+$ TwoWay=�$ PropertyChanged=��� -    ��Name$ btnFlip1��$��3��$��3q�  MaterialDesignRaisedButton#��[    FlipCommand#��Z $��Chọn��   $ Click��.    �� *Btn1ClickCommand+ �� $ 
foodCardUC��   BackContent   $	��200��$	��170��.��� $��3q�
 �� $
��auto ��� �� $
��auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$	��0 5q�.+��� -   $ btnFlip2�� & "MaterialDesignToolForegroundButton#��[ #��Z $
��Left=�.��'	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ 	ArrowLeft=�$��Right=�   $ Click��.    �� *Btn2ClickCommand+ �� $ 
foodCardUC���� -   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Số lượng��$��15 0 0 0q� % !MaterialDesignFloatingHintTextBox#��[ $��Center=����� *ProductAmount+$ TwoWay=�$ PropertyChanged=��� $��1�� ! MaterialDesignOutlinedTextBox#��[ $��Center=�$	��110��$	��3 0q� . $
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$ Ghi chú...������ *Note+$ TwoWay=�$ PropertyChanged=�� $��2��.+��� $��25��$	��100��$��Center=�$	��0 5q����� *SelectCommand+���� $ 
foodCardUC��.��	  $ Check=�