   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  J FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1     WpfApplication1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     /localclr-namespace:WpfApplication1     a ]Xceed.Wpf.DataGrid, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c65xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  ` \Xceed.Wpf.Toolkit, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  
MainWindow�� � WindowStartupLocation$ CenterScreen=�$	��800��$	��600�� � Icon$ logo.ico�� � 	Resources ��%    .��� .+�]� ��. .+�9� -    9�Name$ expander��$��	工具栏��$	��Top=� 9� 
IsExpanded . .��� ���	#FFE5E5E5$��77��.+��� -    ��Name$ 
btnRequest��$��请求��$
��Left=�$��	20,10,0,0q�$	��Top=�$��16(�$��60��$��24���� -   $ 
btnJson2Dt��$��jason转DataTable��$��
125,10,0,0q�$	��Top=�$��16(�$	��155��$��24��$
��Left=��� -   $ btnClear��$��清空��$
��Left=�$��
321,10,0,0q�$	��Top=�$��60��$��16(�$��24���� -    ��Name$ 	textBlock��$
��Left=�$��	489,6,0,0q�$
��Wrap=�$�� ��$	��Top=�$��47��$	��198���� -   $ btnSerialize��$��	序列化��$��16(�$
��Left=�$��
386,10,0,0q�$	��Top=�$��75�� J� RenderTransformOrigin$ 1.013,-0.867&��� -   $ btnWebService��$��请求WEB服务��$
��Left=�$��	20,39,0,0q�$	��Top=�$	��114��$��16(�$��24���� -   $ btnTime��$��设置本地时间��$��16(�$
��Left=�$��
205,40,0,0q�$	��Top=�$	��117��&   System.Windows.Controls.DataGrid  -	   	  Name$
	 grid��$	��Top=�$	��204��
   EnableRowVirtualization
 . �� -
    ��Name$ richTextBox��$��16(�$��Visible=�$��0,5,0,0q�. �/� %  Xceed.Wpf.Toolkit.BusyIndicator  -     Name$
 busy��   IsBusy .     BusyContent$ 下载数据中......��$�� ��$��0,265,0,241q�#  Xceed.Wpf.Toolkit.ChildWindow  -     Name$ childWindow��0  *Xceed.Wpf.Toolkit.Primitives.WindowControl   WindowBackground
 ��  �   
ResizeMode$ NoResize=�   IsModal .     Left$ 75Q�
   Top$ 50Q�$��91,329,295,35q�$ 0.546,0.729&�.���� .+��� $��This is a Child Window�� �� Padding$ 10q�$	��224��%  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ _maskedTextBox��   Mask$ (000)000-00000��#  Xceed.Wpf.Toolkit.SplitButton  $
��test��(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ 	waterText��$��27��$	��311��.��   	Watermark ��  �� Orientation$ 
Horizontal=�.+��� $��Enter First Name��$��4,0,0,0q�$��20��.��