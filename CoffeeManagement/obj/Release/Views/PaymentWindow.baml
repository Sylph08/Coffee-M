   M S B A M L   `   `   `  ���� K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CoffeeManagement.ViewsCoffeeManagement.Views  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem *    $CoffeeManagement.Views.PaymentWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:CoffeeManagement.Views     6sys&clr-namespace:System;assembly=mscorlib     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��paymentWindow��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=� � Title$ Thanh toán hóa đơn��$	��700��$	��650��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+   CommandParameter �� 	 �� ElementName$	 paymentWindow��
 � 	Resources
 ��%�   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)(��      */-SystemParameters.HorizontalScrollBarHeightKey+)X�7Q�X�7Q�.��#  MaterialDesignThemes.Wpf.Card  $��5q�
�������.��� -   $��GridMain�� � RowDefinitions �� $
��auto ��� $��* ��� $
��1.5* ��� $
��auto �.+�� $��0��$	��0 3q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� .+�� $��0�� � ColumnDefinitions �� �� .+��� $��0�� �� Orientation$ 
Horizontal=�$	��0 3q�.+��� $��Người bán:����  �� 
IsReadOnly .  �� AcceptsReturn .  �� TextWrapping$
 Wrap=�$	��210������ *Seller+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��Thời gian:����  .  . $
 Wrap=�$	��210������ *
WhatTime+� $��1�� �� �� .+��� $��0��$ 
Horizontal=�$	��0 3q�.+��� $��Hình thức mua:����  .  . $
 Wrap=�$	��200������ *Where+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��Khách hàng:����  .  . $
 Wrap=�$	��200������ *Who+� $��2�� �� �� .+��� $��0��$ 
Horizontal=�$	��0 3q�.+��� $��Tổng tiền hàng:����  . ���� *Total+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��Phải thanh toán:����  . ���� *	HowMuch+� -   $��CusMoney��$��3�� �� �� .+��� $��0��$ 
Horizontal=�$	��0 3q�.+��� $��Tiền khách đưa:����  . ���� *
InputMoney+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��Tiền trả lại:����  . ���� *OutputMoney+� $��4�� �� �� .+��� $��0��$ 
Horizontal=�$	��0 3q�.+��� $��Điểm cộng:����  . ���� *
AddPoint+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��Điểm trừ:����  . ���� *
SubPoint+� $��5�� �� �� .+��� $��0��$ 
Horizontal=�$	��0 3q�.+��� $��Trạng thái:����  . ���� *IsPaid+�� $��1��$ 
Horizontal=�$	��0 3q�.+��� $��	Ghi chú:����  . ���� *Note+�� $3��-Các chương trình khuyến mãi áp dụng��$��1��$	��0 3q�.���� $
��Auto=�$
��Auto=�
�������.���� ���� *ListPromoAndBill+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� View �� .P��� $	��STT�� �� DisplayMemberBinding �� *Id+�� $��Mã chương trình�� �� *PromotionId+�� $��Tên chương trình�� �� *PromotionName+�� $��Danh sách sản phẩm��$��2��$	��0 3q�.���� $
��Auto=�$
��Auto=�
�������.���� ���� *ListBillInfo+ �� .P��� $	��STT�� �� *Id+�� $��
Tên hàng�� �� *ProductName+�� $��Số lượng�� �� *
Quantity+�� $��
Đơn giá�� �� *Price+�� $��Thành tiền�� �� *	IntoMoney+�� $��SP khuyến mãi�� �� *IsGift+� -   $��
ActionGrid��$��3��$	��0 3q�.+���  $  MaterialDesignFlatAccentBgButton#��[ $��Chấp nhận��$	��200������ *AcceptCommand+���� $	 paymentWindow��