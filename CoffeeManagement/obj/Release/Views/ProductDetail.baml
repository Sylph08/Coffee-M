   M S B A M L   `   `   `  ���� K  GCoffeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CoffeeManagement.ViewsCoffeeManagement.Views  C&clr-namespace:CoffeeManagement.GarbageCoffeeManagement.Garbage  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem *    $CoffeeManagement.Views.ProductDetail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:CoffeeManagement.Views     ;validate&clr-namespace:CoffeeManagement.Garbage     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  0sys&clr-namespace:System;assembly=mscorlib  -   $��productDetailWindow��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���    ProductDetailVM � DataContext# [  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$ Thông tin sản phẩm��$	��365��$	��900��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoadCommand+
   CommandParameter
 ��  �� ElementName$ productDetailWindow��.��� -   $��GirdMain�� � RowDefinitions �� $
��auto ��� .+�� -   $��GridRow0��$��0�� � ColumnDefinitions �� �� .+�#  MaterialDesignThemes.Wpf.Card  $��5q�$��0��.���� $
��Auto=�$
��Auto=�.���� $��5q�.+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��$��5q�.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  % !MaterialDesignFloatingHintTextBox#��[ $	��410������ *DisplayName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.����  �� Orientation$ 
Horizontal=�.+��� -   $��
mealTypeCB��$��	5 10 10 5q� . $	��140�� �� DisplayMemberPath$ DisplayName��$ Thực đơn��   HintOpacity$	 .26Q����� *MealTypeList+ �� SelectedItem �� *SelectedMealType+$ TwoWay=�$ PropertyChanged=�   $ SelectionChanged��.   	 �� *LoadProductTypeCommand+�� $��	20 10 5 5q� . $	��200��$ DisplayName��$ Nhóm hàng��$	 .26Q�{���  �� Path$ SelectedValue�$ 
mealTypeCB������ *ProductTypeList+ �� *SelectedProductType+$ TwoWay=�$ PropertyChanged=�   $ SelectionChanged��.   	 �� *$"LoadMealTypeFromProductTypeCommand+�� $ 
Horizontal=�.+��� -   $ Giá mua��$��5q� . #��[ $��Center=�$	��170������ *
BuyValue+$ TwoWay=�$ PropertyChanged=��� -   $ 	Giá bán��$��40 5 5 5q� . #��[ $��Center=�$	��170������ *	SellValue+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� -   $! Lượng tồn nhỏ nhất��$��5q� . #��[ $��Center=�$	��170������ *MinimumQuantity+$ TwoWay=�$ PropertyChanged=��� -   $ Tồn kho hiện tại��$��40 5 5 5q� . #��[ $��Center=�$	��170������ *CurrentQuantity+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� $��	5 10 10 5q� . $	��140��$ DisplayName��$ 
Đơn vị��$	 .26Q����� *
UnitList+ �� *SelectedUnit+$ TwoWay=�$ PropertyChanged=��� $��	20 10 5 5q� . $	��200��$ DisplayName��$ Trạng thái��$	 .26Q����� *	StateList+ �� *SelectedState+$ TwoWay=�$ PropertyChanged=��� $ Ghi chú��$��5q� . #��[ $��Center=����� *Note+$ TwoWay=�$ PropertyChanged=�  -	   $��PictureCard��$��1��$��5q�$	��275��$	��436��.���� -
   $��productImage��$��Stretch=�$��Stretch=�$��5q�$ Ảnh sản phẩm��$��Uniform=����� *SelectedImage+   $ MouseLeftButtonDown��.   	 �� *LoadImageCommand+
 �� $ productImage��� $��1�� �� �� .+�� $��0��.+��� -   $��
SaveButton�� $  MaterialDesignRaisedAccentButton#��[ $��0q�$��50��$��Center=� � ToolTip$
 Lưu��
������ 
������ $��Center=����� *SaveCommand+���� $ productDetailWindow��.��'	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ ContentSave=�$��25��$��25��$��Center=��� -   $��
EditButton��$��50��$ Chỉnh sửa��
������ 
������ #��[ $��	10 0 10 0q�$��Center=�$
��Left=����� *EditCommand+���� $ productDetailWindow��.��	  $ ClipboardEdit=�$��22��$��30��$��Center=�� $��1��.+��� $ 
Horizontal=�$��Center=�.+��� -    ��Name$ 
LoadImgBtn��$��0q�$��50��$ Tải ảnh��
������ 
������ #��[ $��Center=����� *LoadImageCommand+���� $ productImage��.��	  $ ImageSearch=�$��22��$��30��$��Center=��� -   $ DeleteImgBtn��$��50��$ 
Xóa ảnh��$��	10 0 10 0q�$��Center=�
������ 
������ #��[ ���� *DeleteImageCommand+���� $ productImage��.��	  $ DeleteVariant=�$��25��$��25��$��Center=�