   M S B A M L   `   `   `  ���� K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CoffeeManagement.UserControlCoffee"CoffeeManagement.UserControlCoffee  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 2    ,CoffeeManagement.UserControlCoffee.ProductUC   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Blocal0clr-namespace:CoffeeManagement.UserControlCoffee     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  0sys&clr-namespace:System;assembly=mscorlib  -   $��	productUC��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���    	ProductVM � DataContext# [ .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+   CommandParameter ��  �� ElementName$ 	productUC��	 � 	Resources	 ��%�   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)(��      */-SystemParameters.HorizontalScrollBarHeightKey+)X�7Q�X�7Q�.��#  MaterialDesignThemes.Wpf.Card  $��10q�  PrimaryHueLightBrush#���   " PrimaryHueLightForegroundBrush#���  $��5q�.��� 
 � ColumnDefinitions
 �� $��7* ��� $��2* �.+�� $��0�� � RowDefinitions �� �� $
��auto �.+�  $��0��$��5q�$��Stretch=�.���� $
��Auto=�$
��Auto=�.���� -   $��ListViewProduct������ *
ListGrid+ �� SelectedItem �� *SelectedItem+ �� Mode$ TwoWay=�   $ MouseDoubleClick��.    �� *DoubleClickListViewCommand+ �� $ ListViewProduct�� �� View �� .P��� $��Đang chọn�� �� CellTemplate �� .R��� {�.   d� 	IsChecked ��  �� Path$ 
IsSelected� �� RelativeSource �� *FindAncestor+ �� AncestorType" ����  �� Width$	 110��$��	Mã hàng�� �� DisplayMemberBinding �� *Id+�� $��
Tên hàng�� �� *DisplayName+�� $��Nhóm hàng�� �� *ProductType.DisplayName+�� $	 110��$��Giá mua�� �� *
BuyValue+�� $	 110��$��	Giá bán�� �� *	SellValue+�� $	 110��$!��Lượng tồn nhỏ nhất�� �� *MinimumQuantity+�� $	 110��$��	Tồn kho�� �� *CurrentQuantity+�� $	 110��$��
Đơn vị�� �� *Unit.DisplayName+�� $	 110��$��Trạng thái�� �� *	IsTrading+�� $��Ghi chú�� �� *Note+  $��1��$��5q�.��� $��Center=�$��0��.+��� $��Center=�$��Thêm��$��5q�$	��100������ *
AddCommand+�� $
��Xóa��$��5q�$	��100������ *DeleteCommand+  $��1��$��5q�.���� $
��Auto=�.���� .+��� $��Tìm kiếm��$��3q�.���� $
��Auto=�.���� .+��� -   $��SearchListCB��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . $��3q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm theo������ *
SearchList+ �� *SelectedSearchList+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $ Nội dung tìm kiếm�� . $��3q� % !MaterialDesignFloatingHintTextBox#��[ $��Center=����� *SearchContent+$ OneWayToSource=�$ PropertyChanged=��� $��Loại thực đơn��$��3q�$	��150��.���� $
��Auto=�$
��Auto=�.���� -   $��
mealTypeSP��.	  (MaterialDesignThemes.Wpf.ScrollBarAssist 	  ButtonsVisibility$ Visible=�.+��� -   $��allMealType��$��
Tất cả������ *MealTypeCommand+���� $ allMealType���� -   $��productTypeGB��$��Nhóm hàng��$��3q�$	��200��.���� $
��Auto=�$
��Auto=�.���� -   $��	proTypeSP��$ Visible=�.+��� -   $��allProductType��$��
Tất cả������ *ProductTypeCommand+���� $ allProductType���� $��Giá mua��$��3q�.���� $
��Auto=�$
��Auto=�.���� -	   $��
buyValueSP��$ Visible=�.+�	� -
   $��NoneBuyValue��$
��None�� 	� 	GroupName$ BuyValue������ *RadioButtonCommand+���� $ NoneBuyValue��	� -   $��AscBuyValue��$��Tăng dần��$ BuyValue������ *RadioButtonCommand+���� $ AscBuyValue��	� -   $��DecBuyValue��$��Giảm dần��$ BuyValue������ *RadioButtonCommand+���� $ DecBuyValue���� $��	Giá bán��$��3q�.���� $
��Auto=�$
��Auto=�.���� -   $��sellValueSP��$ Visible=�.+�	� -   $��NoneSellValue��$
��None��$ 	SellValue������ *RadioButtonCommand+���� $ NoneSellValue��	� -   $��AscSellValue��$��Tăng dần��$ 	SellValue������ *RadioButtonCommand+���� $ AscSellValue��	� -   $��DecSellValue��$��Giảm dần��$ 	SellValue������ *RadioButtonCommand+���� $ DecSellValue���� $��	Tồn kho��$��3q�.���� $
��Auto=�$
��Auto=�.���� -   $��	wareHouse��$ Visible=�.+�	� -   $��NoneWH��$
��None��$ InWarehouse������ *RadioButtonCommand+���� $ NoneWH��	� -   $��MaxWH��$��Nhiều nhất��$ InWarehouse������ *RadioButtonCommand+���� $ MaxWH��	� -   $��MinWH��$��
Ít nhất��$ InWarehouse������ *RadioButtonCommand+���� $ MinWH���� $��Trạng thái��$��3q�$	��150��.���� $
��Auto=�$
��Auto=�.���� -   $��Trade��$ Visible=�.+�	� -   $��	NoneState��$��
Tất cả��$ State������ *RadioButtonCommand+���� $ 	NoneState��	� -   $��TradingState��$��Đang kinh doanh��$ State������ *RadioButtonCommand+���� $ TradingState��	� -   $��NotTradingState��$��Ngừng kinh doanh��$ State������ *RadioButtonCommand+���� $ NotTradingState��