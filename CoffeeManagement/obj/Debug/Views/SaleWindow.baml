   M S B A M L   `   `   `  ����K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CoffeeManagement.ViewsCoffeeManagement.Views  5   	   W0clr-namespace:CoffeeManagement.UserControlCoffee"CoffeeManagement.UserControlCoffee  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   '    !CoffeeManagement.Views.SaleWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CoffeeManagement.Views     5   	   ?uc0clr-namespace:CoffeeManagement.UserControlCoffee     5	   	   6sys&clr-namespace:System;assembly=mscorlib     5
   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��
saleWindow��5   	      MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � WindowStartupLocation$ CenterScreen=�5   	    
 SaleVM � DataContext# [ 5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � Title$ 
SaleWindow��5   	   $	��720��6   $
��1280��6)   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadCommand+   CommandParameter 6D   ��  �� ElementName$ 
saleWindow��5        5    
   $ Closed��6   .	 5!        
 6$   �� *ClosedWindowCommand+ 6L   �� $ 
saleWindow��5"        5#   
   $ ContentRendered��6   .	 5$        
 6$   �� *ContentRenderedCommand+ 6O   �� $ 
saleWindow��5%       � 	Resources 5'      ��%�   (��       5(      *,*SystemParameters.VerticalScrollBarWidthKey+)(��      5)      */-SystemParameters.HorizontalScrollBarHeightKey+)X�5(   
   7Q�6V   X�5)   
   7Q�6Y   5*      .��5+      �  � RowDefinitions 5,   
   �� 5-      $
��auto �6   6,   �� 5.      6   .+�50   
   � $��0��6    51        52      $ MouseLeftButtonDown��6!   .	 53        
 6,   �� *MouseMoveWindowCommand+ 6W   �� $ 
saleWindow��54      .+�56      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�6'   $��20��69   .��57      ]� .+�58      �� $��Right=�6!   
������  �� Orientation$ 
Horizontal=�6Q    59       �� 
TargetType �� Property �� Value��%   '��       �� 5:      " ��6$   .�5;   "   ��  � ��$ 2q�6;   6G   �� 5<   "    � ��$ 20��6:   6G   5=      5>      .+�5?      ��  � ToolTip$ 	Thu nhỏ��5@       c� OverflowMode$ Always=�6+   
���������5?   !   �� *MinimizeWindowCommand+��6K   �� $ 
saleWindow��.��5A      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�66   $	��Top=�6L   $��Center=�6d   5B      �� 5C      $ 	Phóng to��5D      $ AsNeeded=�6,   
���������5C   !   �� *MaximizeWindowCommand+��6K   �� $ 
saleWindow��.��5E        $ WindowMaximize=�66   $��Center=�6L   $��Center=�6g   5F      �� 5G      $ Đóng��5H      $ AsNeeded=�6,   
��� E����5G   !   �� *CloseWindowCommand+��6H   �� $ 
saleWindow��.��5I        $ WindowClose=�66   $��Center=�6I   $��Center=�6d   5J      5K      �� 5L      $
��Left=�6!   $ 
Horizontal=�67   .+�5M      '  !MaterialDesignThemes.Wpf.PopupBox  $��0 -3 0 0q�62   $	��Top=�6D      PopupContent. 5N      �� .+�5O   "   �� $��Đổi mật khẩu��6)   ��6@   �� *ChangePasswordCommand+5P      5Q      #	  MaterialDesignThemes.Wpf.Chip	  5R      $��20��6.   
�������  PrimaryHueLightBrush 	  IconBackground# �  6w    " PrimaryHueLightForegroundBrush 	  IconForeground# �  6�   ��6L   �� *LoginEmployee.FullName+ 	  Icon 5S        5T   "   $ Account=�6:   5V      5W      5Y      5Z      5[      #
  MaterialDesignThemes.Wpf.Card
  5\   
   $��1��6   .��5]      �  � ColumnDefinitions 5^      �� 5_      6)   �� 5`      6)   .+�5b      
  $��5q�6&   $��0��61   .��5c      �  5d      �� 5e      $
��auto �6,   6<   �� 5f      $
��auto �6,   6<   �� 5g      6.   .+�5i      �� $��Hình thức mua��6#   $��5q�6:   $��0��6E   .��5j      �� $ 
Horizontal=�6)   .+�5k   "   	�  	� 	GroupName$ groupBuy��6.   $��3 0 70 0q�6C   $��	Mang về��6U    d� 	IsChecked 6g   �� *BringHomeChecked+	� 5l   "   -   5        $��AtStore��5l   C   $ groupBuy��6.   $��Sử dụng tại quán��6R    6m   �� *AtStoreChecked+�� 5m   "   $��60 0 0 0q�6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Chọn phòng��6=   -  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode . .  (MaterialDesignThemes.Wpf.TextFieldAssist    HasClearButton  . ! �� DisplayMemberPath$! DisplayName��5o   +   {�5n   +   �� " �� Path$" 	IsChecked�$ AtStore����5o   K   �� *
RoomList+# �� SelectedItem# 5p   '   �� *RoomSelected+$ �� Mode$$ TwoWay=�% �� UpdateSourceTrigger$% PropertyChanged=��� 5q   "   $��60 0 0 0q�6+   $ Chọn bàn��6=    .   . $! DisplayName��5s   +   {�5r   +   �� $" 	IsChecked�$ AtStore����5s   K   �� *	TableList+# 5t   '   �� *TableSelected+$$ TwoWay=�$% PropertyChanged=�5u      5v      �� 5w      $��Khách hàng��6#   $��5q�67   $��1��6B   .��5x      �  5y   "   �� 5z   &   $
��auto �67   6F   �� 5{   &   69   .+�5}   "   �� $��0��6-   .+�5~   &   	� $ groupCustomer��62   $��3q�6L   $��Khách vãng lai��6W    6p   �� *NonMemberChecked+	� 5   &   -   5        $��
IsMemberRB��5   W   $ groupCustomer��62   $��3q�6L   $��Thành viên��6i    6~   �� *IsMemberChecked+5�   #   � 5�   "   $��1��6'   {�67   �� $" 	IsChecked�$ 
IsMemberRB�� 5�   &   �� 5�   *   6=   �� 5�   *   $
��auto �6;   6J   .+�5�   &   � $��0��60   & � Orientation$& 
Horizontal=�6@   .+�5�   *   �� -   5        ' ��Name$' txbPhone��5�   h   $ Số điện thoại��5�   2   $��10 0 0 0q�6a     .  % !MaterialDesignFloatingHintTextBox#��[ 5�   )   $��Center=�5�   )   ��5�   d   �� *Phone+$$ TwoWay=�$% PropertyChanged=�5�   h   �� 5�   *   -   5        $��CusName��5�   c   $ 	Họ tên��6)   $��10 0 0 0q�6Q   #��[ 5�   )   $��Center=�5�   )   ��5�   2   �� *CustomerDisplayName+$$ TwoWay=�$% PropertyChanged=�5�   )   �� 5�   *   -   5        $��CusID��5�   �   $ Số CMT��5�   )   $��10 0 0 0q�6Q   #��[ 5�   )   $��Center=�5�   )   ��5�   2   �� *
CustomerID+$$ TwoWay=�$% PropertyChanged=�5�   )   �� 5�   *   -   5        $��CusType��5�   x   $��
10 0 0 -12q�5�   3   $ Phân loại��6G    . $! DisplayName��5�   /   ��6O   �� *CustomerTypeList+# 5�   /   �� *CustomerTypeSelected+$$ TwoWay=�$% PropertyChanged=��� 5�   *   -   5        $��CusPoint��5�   d   $ Số điểm��5�   )   $��10 0 0 0q�6R   ( �� 
IsReadOnly( . #��[ 5�   )   |�.  $��Center=�5�   )   ��5�   2   �� *CurrentPoint+$$ TwoWay=�$% PropertyChanged=�5�   )   5�   '   �� 5�   &   $��1��6-    * &MaterialDesignFloatingActionMiniButton#��[ 6=   $ Thêm mới��6}   $��32��6�   $��32��6�   $��5q�5�   -   $��Center=�6_   $��Center=�6z   ��68   �� *AddCustomerCommand+.��5�   *     $
 Plus=�6B   $��30��6N   $��30��6Z   5�   '   5�   #   5�      5�      �� 5�      $��Danh sách sản phẩm��6#   $��5q�6?   $��2��6J   .��5�      �  5�   "   �� 5�   &   $��50 �64   6B   �� 5�   &   66   .+�5�   "   � $��0��6'   .+�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��
10 0 10 -5q�63   $ Chọn thực đơn��6G   $
��auto��6v    . $! DisplayName��5�   /     . ��6O   �� *
MealList+# 5�   /   �� *MealSelected+$$ TwoWay=�$% PropertyChanged=��� 5�   *   $��
20 0 10 -5q�63   $ Chọn nhóm hàng��6G   $
��auto��6w    . $! DisplayName��5�   +     . ��6K   �� *ProductTypeList+# 5�   /   �� *ProductTypeSelected+$$ TwoWay=�$% PropertyChanged=�6�   �� 5�   *   $	��200��62   $��
100,0,0,10q�6>   #��[ 5�   .   $��Center=�6k     . ��5�   R   �� *SearchContent+$$ OneWayToSource=�$% PropertyChanged=�.��5�   �    5�   .   �� 5�   2   $ 
Horizontal=�6=   $��-2 0 0 0q�5�   1   .+�5�   6     $��13��6N   $��13��6Y   $ Magnify=�6e   �� 5�   6   $��13(�6@   $��Tìm kiếm món ăn��5�   -   5�   3   .��5�   N   5�   +   5�   '   5�   #   � 5�   "   $��1��6'   .+�5�   &   
  $��10q�6:   .��5�   *   �� $
��Auto=�67   .��5�   .   � -	   5        $��foodList��5�   8   $��Center=�6H   5�   +   5�   '   5�   #   5�      5�      5�      5�      
  5�      $��5q�6&   $��1��61   .��5�      �  5�      �� 5�      $
��1.5* �6,   6<   �� 5�      $
��auto �6,   6<   �� 5�      $��* �6,   69   �� 5�      $
��auto �6,   6<   .+�5�      �� $��0��6!    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6.   $ Tạo mới hóa đơn��6t   $��40��6�   $��40��6�   $
��10 0q�5�   -   $	��Top=�6^   $��Right=�6v   ) K� ZIndex$) 2��6�   ��6;   �� *NewBillCommand+.��5�        $
 Plus=�66   $��30��6B   $��30��6N   5�      �� 5�      $��0��6#   $��Các món đang chọn��60   $��5q�6K   $) 1��6V   .��5�      �  5�   "   �� 5�   &   $
��auto �64   6D   �� 5�   &   66   .+�5�   "   
  $��0��66   $��0 0 0 5q�6C   .��5�   &   �  5�   *   �� 5�   .   6A   �� 5�   .   $
��auto �6?   6N   .+�5�   *   � $��0��64   .+�5�   .   �� $	 STT��66   $��5 0 10 5q�6[   ( . |�.  #��[ 5�   2   $��Center=�6m   ��5�   2   �� *Id+$$ TwoWay=�$% PropertyChanged=�5�   m   �� 5�   .   $ 
Tên hàng��66   $��5 0 10 5q�6`   ( . |�.  #��[ 5�   2   $��Center=�6m   ��5�   2   �� *ProductName+$$ TwoWay=�$% PropertyChanged=�5�   m   �� 5�   .   -
   5        $ Số lượng��5�   6   $��	10 0 10 5q�6`   #��[ 5�   2   $��Center=�6m   ��5�   2   �� *
Quantity+$$ TwoWay=�$% PropertyChanged=�5�   m   �� 5�   .   -   5        $ 
Đơn giá��5�   6   $��	10 0 10 5q�6_   #��[ 5�   2   $��Center=�6m   ��5�   2   �� *Price+$$ TwoWay=�$% PropertyChanged=�5�   m   �� 5�   .   -   5        $ Thành tiền��5�   6   $��	10 0 10 5q�6b   #��[ 5�   2   $��Center=�6m   ��5�   2   �� *	IntoMoney+$$ TwoWay=�$% PropertyChanged=�5�   m   �� 5�   .   $ Ghi chú��66   $��	10 0 10 5q�6_   #��[ 5�   2   $��Center=�6m   ��5�   2   �� *Note+$$ TwoWay=�$% PropertyChanged=�5�   m   5�   +   �� 5�   *   $��1��65   $ 
Horizontal=�6E   .+�5�   .   �� $��5 0 0 0q�65   $��24��6F   ��6R   �� *SaveProductCommand+��6y   0  *MaterialDesignThemes.Wpf.PackIconExtension  *Check+�� 5�   .   $	��5 0q�65   $��24��6B   ��6N   �� *DeleteProductCommand+��6w     *Delete+5�   +   5�   '   5�   #   �� 5�   "   -   5        $��ScrollBuyList��5�   �   $��1��6/   $
��Auto=�6<   $
��Auto=�6_   .��5�   &   �� -   5        $��BuyList��5�   �   ��6/   �� *BuyListGrid+# 6S   �� *BuySelectedItem+$$ TwoWay=�$% PropertyChanged=�* �� View* 5�   *   �� 5   .   .P�5  2   �� $	��STT��6A   + �� DisplayMemberBinding+ 6N   �� *Id+6t   �� 5  2   $��
Tên hàng��6A   + 6S   �� *ProductName+6�   �� 5  2   $��Số lượng��6A   + 6S   �� *
Quantity+6   �� 5  2   $��
Đơn giá��6A   + 6R   �� *Price+6{   �� 5  2   $��Thành tiền��6A   + 6U   �� *	IntoMoney+6�   �� 5  2   $��Ghi chú��6A   + 6R   �� *Note+6z   5  /   5	  '   5
  #   5     5     � 5     $��1��6   $	��5 0q�6,    5     �� 5  "   65   �� 5  "   65   �� 5  "   $
��auto �63   6B   .+�5     �� $��0��6%   $��0 0 5 0q�65    $	  MaterialDesignRaisedAccentButton#��[	 6G   $�� Áp dụng khuyến mãi��6�   $��24��6�   $��Right=�5  H   $	��250��6d   ��6%   �� *ApplyPromotion+6d   �� 5     $��1��6%   $��5 0 0 0q�65    "
 MaterialDesignRaisedDarkButton#��[
 6F   $��Xóa bỏ khuyến mãi��6~   $��24��6�   $
��Left=�5  J   $	��250��6e   ��6%   �� *RejectPromotion+6e   �� 5     $��2��6%   $	��5 0q�65   $��24��6B   $. (Danh sách chương trình khuyến mãi��5  %   $��Center=�6~   ��5  N     *FormatListNumbered+��5  Q   �� *ShowListPromotionCommand+6~   5     �� 5     $ ��Sản phẩm khuyến mãi��6#   $��2��6@   $��5q�6M   .��5     �� -   5        $��ScrollGiftList��5  �   $��1��6+   $
��Auto=�68   $
��Auto=�6[   .��5  "   �� ��6+   �� *GiftListGrid+# 6P   �� *GiftSelectedItem+$$ TwoWay=�$% PropertyChanged=�* 5  &   �� 5  *   .P�5   .   �� $	��STT��6=   + 6J   �� *Id+6p   �� 5!  .   $��
Tên hàng��6=   + 6O   �� *ProductName+6~   �� 5"  .   $��Số lượng��6=   + 6O   �� *
Quantity+6{   �� 5#  .   $��
Đơn giá��6=   + 6N   �� *Price+6w   �� 5$  .   $��Thành tiền��6=   + 6Q   �� *	IntoMoney+6~   �� 5%  .   $��Ghi chú��6=   + 6N   �� *Note+6v   5&  +   5(  #   5)     5*     � 5+     $��3��6    5,     �� 5-  "   62   �� 5.  "   62   .+�50     � $��0��6(   $��Center=�65   .+�51  "   �� -   5        $��txbPointAdd��51  c   $
��10 0q�6*   $ Điểm cộng��68   ( . #��[ 52  "   $��Center=�6]   ��53  &   �� *
PointAdd+$$ TwoWay=�$% PropertyChanged=��� 54  "   -   5        $��txbPointSub��55  x   $
��10 0q�54  *   $ Trừ điểm thẻ��6\   #��[ 55  "   $��Center=�6]   ��56  &   �� *
PointSub+$$ TwoWay=�$% PropertyChanged=��� 57  "   $
��10 0q�6*   $ TỔNG TIỀN��68   ( . #��[ 58  "   $��Center=�6]   ��59  &   �� *OriginBillValue+$$ TwoWay=�$% PropertyChanged=��� 5:  "   $
��10 0q�6*   $ PHẢI THANH TOÁN��68   $
��Bold"�6i   #��[ 5;  "   $��Center=�6]   ��5<  &   �� *TrueBillValue+$$ TwoWay=�$% PropertyChanged=��� 5=  "   -   5        $
��10 0q�5=  *   $ Tiền khách đưa��6\   #��[ 5>  "   $��Center=�6]   ��5?  &   �� *	MoneyIn+$$ TwoWay=�$% PropertyChanged=��� 5@  "   -   5        $
��10 0q�5@  *   $ Tiền trả lại��6\   ( . #��[ 5A  "   $��Center=�6]   $��	UltraBold"�6x   ��5B  &   �� *
MoneyOut+$$ TwoWay=�$% PropertyChanged=�5C     � 5D     $��1��6#    5E  "   �� 5F  &   69   �� 5G  &   69   .+�5I  "   �� $��0��6*   $	��5 3q�6:   $ Ghi chú hóa đơn��6G   , �� AcceptsReturn, . - �� TextWrapping$
- Wrap=�5J  ?   $	��290��6S   #��[ 5K  "   $��Center=�6]   ��5L  &   �� *NotePromotion+$$ TwoWay=�$% PropertyChanged=��� 5M  "   $��1��6)   $	��5 0q�6:   $��THANH TOÁN��6G   $��26��6\   ���	#FF07E8E4#��[	 5N  !   ���	#FF00EAE6$��Center=�5O  )   ��5N  [   �� *
PayCommand+5O  )   5P     5R     5T     5U     5V     5W     5X     5Z     