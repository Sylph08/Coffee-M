   M S B A M L   `   `   `  ����K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CoffeeManagement.ViewsCoffeeManagement.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   *    $CoffeeManagement.Views.PaymentWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CoffeeManagement.Views     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5        $��paymentWindow��5   	      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Thanh toán hóa đơn��5   	   $	��700��6$   $	��650��61   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+   CommandParameter 6D   �� 	 �� ElementName$	 paymentWindow��5      
 � 	Resources
 5      ��%�   (��       5      *,*SystemParameters.VerticalScrollBarWidthKey+)(��      5      */-SystemParameters.HorizontalScrollBarHeightKey+)X�5   
   7Q�6V   X�5   
   7Q�6Y   5       .��5!      #  MaterialDesignThemes.Wpf.Card  $��5q�6   
�������.��5"   
   � -   5        $��GridMain��5"       � RowDefinitions 5#      �� 5$      $
��auto �6    60   �� 5%      $��* �6    6-   �� 5&      $
��1.5* �6    60   �� 5'      $
��auto �6    60   .+�5)      � $��0��6   $	��0 3q�6     5*      �� 5+      $
��auto �6$   64   �� 5,      $
��auto �6$   64   �� 5-      $
��auto �6$   64   �� 5.      $
��auto �6$   64   �� 5/      $
��auto �6$   64   �� 50      6&   .+�52      � $��0��6    � ColumnDefinitions 53      �� 54      6-   �� 55      6-   .+�57      �� $��0��6!    �� Orientation$ 
Horizontal=�61   $	��0 3q�6J   .+�58      �� $��Người bán:��6    �� 59       �� 
IsReadOnly .  �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6a   $	��210��6u   ��6"   �� *Seller+6�   5:      �� 5;      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5<      �� $��Thời gian:��6    �� 5=       .  . $
 Wrap=�6c   $	��210��6w   ��6"   �� *
WhatTime+6�   5>      5?      � 5@      $��1��6    5A      �� 5B      6-   �� 5C      6-   .+�5E      �� $��0��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5F      �� $��Hình thức mua:��6    �� 5G       .  . $
 Wrap=�6`   $	��200��6t   ��6"   �� *Where+6�   5H      �� 5I      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5J      �� $��Khách hàng:��6    �� 5K       .  . $
 Wrap=�6^   $	��200��6r   ��6"   �� *Who+6�   5L      5M      � 5N      $��2��6    5O      �� 5P      6-   �� 5Q      6-   .+�5S      �� $��0��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5T      �� $��Tổng tiền hàng:��6    �� 5U       . ��6"   �� *Total+6M   5V      �� 5W      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5X      �� $��Phải thanh toán:��6    �� 5Y       . ��6"   �� *	HowMuch+6O   5Z      5[      � 5\      -   5        $��CusMoney��5\   $   $��3��6    5]      �� 5^      6-   �� 5_      6-   .+�5a      �� $��0��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5b      �� $��Tiền khách đưa:��6    �� 5c       . ��6"   �� *
InputMoney+6R   5d      �� 5e      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5f      �� $��Tiền trả lại:��6    �� 5g       . ��6"   �� *OutputMoney+6S   5h      5i      � 5j      $��4��6    5k      �� 5l      6-   �� 5m      6-   .+�5o      �� $��0��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5p      �� $��Điểm cộng:��6    �� 5q       . ��6"   �� *
AddPoint+6P   5r      �� 5s      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5t      �� $��Điểm trừ:��6    �� 5u       . ��6"   �� *
SubPoint+6P   5v      5w      � 5x      $��5��6    5y      �� 5z      6-   �� 5{      6-   .+�5}      �� $��0��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5~      �� $��Trạng thái:��6    �� 5       . ��6"   �� *IsPaid+6N   5�      �� 5�      $��1��6!   $ 
Horizontal=�61   $	��0 3q�6J   .+�5�      �� $��	Ghi chú:��6    �� 5�       . ��6"   �� *Note+6L   5�      5�      5�      �� 5�      $3��-Các chương trình khuyến mãi áp dụng��6   $��1��6D   $	��0 3q�6Q   .��5�      �� $
��Auto=�6   $
��Auto=�6B   
�������.��5�      �� ��6   �� *ListPromoAndBill+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� View 5�      �� 5�      .P�5�   "   �� $	��STT��61    �� DisplayMemberBinding 6>   �� *Id+6d   �� 5�   "   $��Mã chương trình��61    6J   �� *PromotionId+6y   �� 5�   "   $��Tên chương trình��61    6K   �� *PromotionName+6|   5�      5�      5�      5�      �� 5�      $��Danh sách sản phẩm��6   $��2��63   $	��0 3q�6@   .��5�      �� $
��Auto=�6   $
��Auto=�6B   
�������.��5�      �� ��6   �� *ListBillInfo+ 5�      �� 5�      .P�5�   "   �� $	��STT��61    6>   �� *Id+6d   �� 5�   "   $��
Tên hàng��61    6C   �� *ProductName+6r   �� 5�   "   $��Số lượng��61    6C   �� *
Quantity+6o   �� 5�   "   $��
Đơn giá��61    6B   �� *Price+6k   �� 5�   "   $��Thành tiền��61    6E   �� *	IntoMoney+6r   �� 5�   "   $��SP khuyến mãi��61    6H   �� *IsGift+6r   5�      5�      5�      5�      � 5�      -   5        $��
ActionGrid��5�   -   $��3��6   $	��0 3q�6    .+�5�      ��  $  MaterialDesignFlatAccentBgButton#��[ 6   $��Chấp nhận��6S   $	��200��6g   ��5�      �� *AcceptCommand+��6;   �� $	 paymentWindow��5�      5�      5�      5�      