   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1     WpfApplication1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     /localclr-namespace:WpfApplication1     a ]Xceed.Wpf.DataGrid, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c65xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  ` \Xceed.Wpf.Toolkit, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5esri*http://schemas.esri.com/arcgis/client/2009    � Title$  
MainWindow�� � WindowStartupLocation$ CenterScreen=�$��869.858��$��698.439�� � Icon$ logo.ico�� � 	Resources ��%    .��� $��0,0,0,0q�
�������    ExpanderControlTemplate1 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels d�Name	 d� 	IsChecked
 �� Mode �� RelativeSource �Name �� Orientation F�Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value ��Name �� ContentStringFormat �� ContentStringFormat��%  &	        �� " 9�.R��� $ ExpanderBorder��#��z��#��z��$ 3�� . ���� ._�]� .+�d� $ 
HeaderSite��$��Right=�#��z��#��z��$	��Top=�#��z��#��z��#��z��#��z��#��z��#��z��#��z��$��1q�$��0��$��0��#��z��#��z��	 �� *
IsExpanded+$
 TwoWay=� �� *TemplatedParent+���� " d�.R�� $ 
ToggleGrid��.+��� $ 
Horizontal=�.+��� $ ToggleBoder1��$��30��$��30�����	#FF5A83CF$ 60,0,0,0���� $ ToggleBoder2��$��30��$��30�����	#FF5A83CF$ 0,60,0,0���� $��30��$��60��.+�F� $ 
TogglePath��"���� $� @x}р����� р�@x}	
�������$��3�� P�  �@d�	IsChecked$
 TrueY�. ��� $ 
TogglePath�� � ��" �� $� ��� р��@x}р���� 	P�  �@J�IsMouseOver . . ��� $ ToggleBoder1�� � �� �	#FF3C7FB1�� $ ToggleBoder2�� � �� �	#FF3C7FB1P�  � �� . . ��� $ ToggleBoder1�� � �� �	#FF3C7FB1�� $ ToggleBoder2�� � �� �	#FF3C7FB1P�  � {� .  . ��� $ ToggleBoder1�� � ��
 ���� �� $ ToggleBoder2�� � ��
 ���� �� $ 
ExpandSite��#��z��#��z��# z $��Bottom=�|�.  #��z��#��z��$y�	Collapsed=�#��z�� P�  �@9�
IsExpanded . . ��� $ 
ExpandSite�� � y�$ Visible=�P�  �@9�
IsExpanded .  . ��� $ ExpanderBorder�� Z�  � ��P�  �@9�ExpandDirection$ Up=�. ��� $ 
ExpandSite�� � ��$	 Top=��� $ 
HeaderSite�� � ��$ Bottom=�P�  � {� .  . ��� # � �� � ���� # � �� � ��.+�]� $��Stretch=�$��Stretch=�$��	0,0,0,301q�.+�9� -    9�Name$ expander��$	��Top=� 9� 
IsExpanded . #���   ���	#FF272020.��� ���	#FFE5E5E5$��77��$��1,0,-1,0q�.+�F� -   $ leftCornerBorder��"����        � �     �     � 	$
��Left=�$	��Top=�$��0,0,0,0q�$��0�����#fff���#000 .  K� ZIndex$ 1��A� $
��Left=�$	��Top=�$��5��$��5��
���  ��$ 2���� -    ��Name$ 
btnRequest��$��请求��$
��Left=�$��	20,10,0,0q�$	��Top=�$��16(�$��60��$��24���� -   $ 
btnJson2Dt��$��jason转DataTable��$��
125,10,0,0q�$	��Top=�$��16(�$	��155��$��24��$
��Left=��� -   $ btnClear��$��清空��$
��Left=�$��
321,10,0,0q�$	��Top=�$��60��$��16(�$��24���� -   $ btnSerialize��$��	序列化��$��16(�$
��Left=�$��
386,10,0,0q�$	��Top=�$��75�� J� RenderTransformOrigin$ 1.013,-0.867&��� -   $ btnWebService��$��请求WEB服务��$
��Left=�$��	20,39,0,0q�$	��Top=�$	��114��$��16(�$��24���� -   $ btnTime��$��设置本地时间��$��16(�$
��Left=�$��
205,40,0,0q�$	��Top=�$	��117���� -	   $ 	btnImport��$��生成excel��$��16(�$
��Left=�$��
427,40,0,0q�$	��Top=�$	��117���� -
   $��Button��$
��Left=�$��
565,12,0,0q�$	��Top=�$��75���� -   $��DBtest��$
��Left=�$��
667,12,0,0q�$	��Top=�$��75��$��22���� -   $��TimeOutActivity��$
��Left=�$��
622,40,0,0q�$	��Top=�$	��120��$��30��&   System.Windows.Controls.DataGrid  -     Name$
 grid��$	��Top=�$	��126��   EnableRowVirtualization .    CanUserResizeColumns .     CanUserResizeRows  . �� -   ! ��Name$! richTextBox��$��16(�$��Visible=�$	��856��$��	0,0,0,-88q�. �/� (  "System.Windows.Controls.WebBrowser  -   "  Name$" 
WebBrowser��$	��187��$	��Top=�$	��Top=�$
��Auto��$��10,471,86,0q�