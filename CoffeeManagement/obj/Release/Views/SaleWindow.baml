   M S B A M L   `   `   `  ���� K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CoffeeManagement.ViewsCoffeeManagement.Views  W0clr-namespace:CoffeeManagement.UserControlCoffee"CoffeeManagement.UserControlCoffee  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem '    !CoffeeManagement.Views.SaleWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:CoffeeManagement.Views     ?uc0clr-namespace:CoffeeManagement.UserControlCoffee     6sys&clr-namespace:System;assembly=mscorlib     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��
saleWindow��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=� 
 SaleVM � DataContext# [  � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Title$ 
SaleWindow��$	��720��$
��1280��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase	   Actions.	 6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 �� *LoadCommand+   CommandParameter ��  �� ElementName$ 
saleWindow��  $ Closed��.	   
 �� *ClosedWindowCommand+ �� $ 
saleWindow��  $ ContentRendered��.	   
 �� *ContentRenderedCommand+ �� $ 
saleWindow�� � 	Resources ��%�   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)(��      */-SystemParameters.HorizontalScrollBarHeightKey+)X�7Q�X�7Q�.���  � RowDefinitions �� $
��auto ��� .+�� $��0��   $ MouseLeftButtonDown��.	   
 �� *MouseMoveWindowCommand+ �� $ 
saleWindow��.+�(  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=�$��20��.��]� .+��� $��Right=�
������  �� Orientation$ 
Horizontal=�  �� 
TargetType �� Property �� Value��%B   '��       �� " ��.���  � ��$ 2q���  � ��$ 20��.+���  � ToolTip$ 	Thu nhỏ�� c� OverflowMode$ Always=�
����������� *MinimizeWindowCommand+���� $ 
saleWindow��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�$	��Top=�$��Center=��� $ 	Phóng to��$ AsNeeded=�
����������� *MaximizeWindowCommand+���� $ 
saleWindow��.��  $ WindowMaximize=�$��Center=�$��Center=��� $ Đóng��$ AsNeeded=�
��� E������ *CloseWindowCommand+���� $ 
saleWindow��.��  $ WindowClose=�$��Center=�$��Center=��� $
��Left=�$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PopupBox  $��0 -3 0 0q�$	��Top=�   PopupContent. �� .+��� $��Đổi mật khẩu������ *ChangePasswordCommand+#	  MaterialDesignThemes.Wpf.Chip	  $��20��
�������  PrimaryHueLightBrush 	  IconBackground# �   " PrimaryHueLightForegroundBrush 	  IconForeground# �  ���� *LoginEmployee.FullName+ 	  Icon   $ Account=�#
  MaterialDesignThemes.Wpf.Card
  $��1��.���  � ColumnDefinitions �� �� .+�
  $��5q�$��0��.���  �� $
��auto ��� $
��auto ��� .+��� $��Hình thức mua��$��5q�$��0��.���� $ 
Horizontal=�.+�	�  	� 	GroupName$ groupBuy��$��3 0 70 0q�$��	Mang về�� d� 	IsChecked �� *BringHomeChecked+	� -   $��AtStore��$ groupBuy��$��Sử dụng tại quán�� �� *AtStoreChecked+�� $��60 0 0 0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Chọn phòng��-  'MaterialDesignThemes.Wpf.ComboBoxAssist   ClassicMode . .  (MaterialDesignThemes.Wpf.TextFieldAssist    HasClearButton  . ! �� DisplayMemberPath$! DisplayName��{��� " �� Path$" 	IsChecked�$ AtStore������ *
RoomList+# �� SelectedItem# �� *RoomSelected+$ �� Mode$$ TwoWay=�% �� UpdateSourceTrigger$% PropertyChanged=��� $��60 0 0 0q�$ Chọn bàn�� .   . $! DisplayName��{��� $" 	IsChecked�$ AtStore������ *	TableList+# �� *TableSelected+$$ TwoWay=�$% PropertyChanged=��� $��Khách hàng��$��5q�$��1��.���  �� $
��auto ��� .+��� $��0��.+�	� $ groupCustomer��$��3q�$��Khách vãng lai�� �� *NonMemberChecked+	� -   $��
IsMemberRB��$ groupCustomer��$��3q�$��Thành viên�� �� *IsMemberChecked+� $��1��{��� $" 	IsChecked�$ 
IsMemberRB�� �� �� $
��auto �.+�� $��0��& � Orientation$& 
Horizontal=�.+��� -   ' ��Name$' txbPhone��$ Số điện thoại��$��10 0 0 0q�  .  % !MaterialDesignFloatingHintTextBox#��[ $��Center=����� *Phone+$$ TwoWay=�$% PropertyChanged=��� -   $��CusName��$ 	Họ tên��$��10 0 0 0q�#��[ $��Center=����� *CustomerDisplayName+$$ TwoWay=�$% PropertyChanged=��� -   $��CusID��$ Số CMT��$��10 0 0 0q�#��[ $��Center=����� *
CustomerID+$$ TwoWay=�$% PropertyChanged=��� -   $��CusType��$��
10 0 0 -12q�$ Phân loại�� . $! DisplayName������ *CustomerTypeList+# �� *CustomerTypeSelected+$$ TwoWay=�$% PropertyChanged=��� -   $��CusPoint��$ Số điểm��$��10 0 0 0q�( �� 
IsReadOnly( . #��[ |�.  $��Center=����� *CurrentPoint+$$ TwoWay=�$% PropertyChanged=��� $��1�� * &MaterialDesignFloatingActionMiniButton#��[ $ Thêm mới��$��32��$��32��$��5q�$��Center=�$��Center=����� *AddCustomerCommand+.��  $
 Plus=�$��30��$��30���� $��Danh sách sản phẩm��$��5q�$��2��.���  �� $��50 ��� .+�� $��0��.+��� $ 
Horizontal=�.+��� $��
10 0 10 -5q�$ Chọn thực đơn��$
��auto�� . $! DisplayName��  . ���� *
MealList+# �� *MealSelected+$$ TwoWay=�$% PropertyChanged=��� $��
20 0 10 -5q�$ Chọn nhóm hàng��$
��auto�� . $! DisplayName��  . ���� *ProductTypeList+# �� *ProductTypeSelected+$$ TwoWay=�$% PropertyChanged=��� $	��200��$��
100,0,0,10q�#��[ $��Center=�  . ���� *SearchContent+$$ OneWayToSource=�$% PropertyChanged=�.�� �� $ 
Horizontal=�$��-2 0 0 0q�.+�  $��13��$��13��$ Magnify=��� $��13(�$��Tìm kiếm món ăn��.��� $��1��.+�
  $��10q�.���� $
��Auto=�.��� -	   $��foodList��$��Center=�
  $��5q�$��1��.���  �� $
��1.5* ��� $
��auto ��� $��* ��� $
��auto �.+��� $��0�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $ Tạo mới hóa đơn��$��40��$��40��$
��10 0q�$	��Top=�$��Right=�) K� ZIndex$) 2������ *NewBillCommand+.��  $
 Plus=�$��30��$��30���� $��0��$��Các món đang chọn��$��5q�$) 1��.���  �� $
��auto ��� .+�
  $��0��$��0 0 0 5q�.���  �� �� $
��auto �.+�� $��0��.+��� $	 STT��$��5 0 10 5q�( . |�.  #��[ $��Center=����� *Id+$$ TwoWay=�$% PropertyChanged=��� $ 
Tên hàng��$��5 0 10 5q�( . |�.  #��[ $��Center=����� *ProductName+$$ TwoWay=�$% PropertyChanged=��� -
   $ Số lượng��$��	10 0 10 5q�#��[ $��Center=����� *
Quantity+$$ TwoWay=�$% PropertyChanged=��� -   $ 
Đơn giá��$��	10 0 10 5q�#��[ $��Center=����� *Price+$$ TwoWay=�$% PropertyChanged=��� -   $ Thành tiền��$��	10 0 10 5q�#��[ $��Center=����� *	IntoMoney+$$ TwoWay=�$% PropertyChanged=��� $ Ghi chú��$��	10 0 10 5q�#��[ $��Center=����� *Note+$$ TwoWay=�$% PropertyChanged=��� $��1��$ 
Horizontal=�.+��� $��5 0 0 0q�$��24������ *SaveProductCommand+��0  *MaterialDesignThemes.Wpf.PackIconExtension  *Check+�� $	��5 0q�$��24������ *DeleteProductCommand+��  *Delete+�� -   $��ScrollBuyList��$��1��$
��Auto=�$
��Auto=�.���� -   $��BuyList������ *BuyListGrid+# �� *BuySelectedItem+$$ TwoWay=�$% PropertyChanged=�* �� View* �� .P��� $	��STT��+ �� DisplayMemberBinding+ �� *Id+�� $��
Tên hàng��+ �� *ProductName+�� $��Số lượng��+ �� *
Quantity+�� $��
Đơn giá��+ �� *Price+�� $��Thành tiền��+ �� *	IntoMoney+�� $��Ghi chú��+ �� *Note+� $��1��$	��5 0q� �� �� �� $
��auto �.+��� $��0��$��0 0 5 0q� $	  MaterialDesignRaisedAccentButton#��[	 $�� Áp dụng khuyến mãi��$��24��$��Right=�$	��250������ *ApplyPromotion+�� $��1��$��5 0 0 0q� "
 MaterialDesignRaisedDarkButton#��[
 $��Xóa bỏ khuyến mãi��$��24��$
��Left=�$	��250������ *RejectPromotion+�� $��2��$	��5 0q�$��24��$. (Danh sách chương trình khuyến mãi��$��Center=���  *FormatListNumbered+���� *ShowListPromotionCommand+�� $ ��Sản phẩm khuyến mãi��$��2��$��5q�.���� -   $��ScrollGiftList��$��1��$
��Auto=�$
��Auto=�.���� ���� *GiftListGrid+# �� *GiftSelectedItem+$$ TwoWay=�$% PropertyChanged=�* �� .P��� $	��STT��+ �� *Id+�� $��
Tên hàng��+ �� *ProductName+�� $��Số lượng��+ �� *
Quantity+�� $��
Đơn giá��+ �� *Price+�� $��Thành tiền��+ �� *	IntoMoney+�� $��Ghi chú��+ �� *Note+� $��3�� �� �� .+�� $��0��$��Center=�.+��� -   $��txbPointAdd��$
��10 0q�$ Điểm cộng��( . #��[ $��Center=����� *
PointAdd+$$ TwoWay=�$% PropertyChanged=��� -   $��txbPointSub��$
��10 0q�$ Trừ điểm thẻ��#��[ $��Center=����� *
PointSub+$$ TwoWay=�$% PropertyChanged=��� $
��10 0q�$ TỔNG TIỀN��( . #��[ $��Center=����� *OriginBillValue+$$ TwoWay=�$% PropertyChanged=��� $
��10 0q�$ PHẢI THANH TOÁN��$
��Bold"�#��[ $��Center=����� *TrueBillValue+$$ TwoWay=�$% PropertyChanged=��� -   $
��10 0q�$ Tiền khách đưa��#��[ $��Center=����� *	MoneyIn+$$ TwoWay=�$% PropertyChanged=��� -   $
��10 0q�$ Tiền trả lại��( . #��[ $��Center=�$��	UltraBold"����� *
MoneyOut+$$ TwoWay=�$% PropertyChanged=�� $��1�� �� �� .+��� $��0��$	��5 3q�$ Ghi chú hóa đơn��, �� AcceptsReturn, . - �� TextWrapping$
- Wrap=�$	��290��#��[ $��Center=����� *NotePromotion+$$ TwoWay=�$% PropertyChanged=��� $��1��$	��5 0q�$��THANH TOÁN��$��26�����	#FF07E8E4#��[	 ���	#FF00EAE6$��Center=����� *
PayCommand+