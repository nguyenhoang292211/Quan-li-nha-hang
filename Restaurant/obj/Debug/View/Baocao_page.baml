   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Restaurant.ViewRestaurant.View  5      ` \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart 5	      !    Restaurant.View.Baocao_page   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHMyMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      )localclr-namespace:Restaurant.View  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      bmyChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart  5	        N� Title$  Baocao_page��5
       N� 
FontFamily$X Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5      $��14(�5      $��Medium"�5         MaterialDesignBody#���   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��6* �6   �� 5      $��5* �6   .+�5   
   � $��0��6   .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�64   .+�5      �� $��	15,20,0,0q�5      $��Quản lí món ăn ��5      $��Montserrat SemiBold)�5       $��23(�5!      $��
ExtraBlack"�5"      ���	#DD0000005#      5$      �� 5%      $��5,5,20,5q�5&      $��Right=�5'      $ 
Horizontal=�5(      .+�5)      �� -   5         ��Name$ Refresh��5*      $��Right=�5+      
����d� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5.       � ToolTip$2 ,MaterialDesignFloatingActionMiniAccentButton��5/      .��50      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��51      $��24��52         Kind$ Update=�53      54      55      58      � 59   
   $��1��6    � ColumnDefinitions 5:      �� 5;      $��1* �6#   �� 5<      $��3* �6#   �� 5=      $��2* �6#   .+�5@      �� $��0��6   .+�5A      �� -   5         ��Name$ cmbBy��5B      $
��10,0q�5C      
���   �$��Montserrat Medium)�5E      $��14(�5F      	 �� 
IsEditable	 .  & "MaterialDesignFloatingHintComboBox#��[ 5I      (  "System.Windows.Controls.DatePicker  5J      -   5        $��editFromDate��5K      $��2��5L      $	��170��5M      $��	10,15,5,0q�5N      $
��Left=�5O      $	��Top=�5P      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Từ ngày��5Q      $��Sitka Subheading)�5R      $��14(�5S      $
��Bold"�5T       ( $MaterialDesignFloatingHintDatePicker#��[ 5V        5W      -   5        $��
editToDate��5X      $��2��5Y      $	��170��5Z      $��	10,15,5,0q�5[      $
��Left=�5\      $	��Top=�5]      $
 Đến ngày��5^      $��Sitka Subheading)�5_      $��14(�5`      $
��Bold"�5a      #��[ 5c      5f      � 5j      $��1��6   .+�5m      -  'De.TorstenMandelkow.MetroChart.PieChart  -   5          Name$ pieChart��5n      $
��auto��5o      $	��220��5p      $��0q�5q      
������ .  (De.TorstenMandelkow.MetroChart.ChartBase   ChartSubTitle$ Tính trên giai đoạn��5s         
ChartTitle$+ %Tỉ lệ phần trăm về doanh thu��5t      $��Sitka Subheading)�5u      $��3��5v         Series 5x      0  *De.TorstenMandelkow.MetroChart.ChartSeries  -   5        $��	pieChart1��5y         DisplayMember$
 Name��5z         SeriesTitle$ Tỷ trọng bán��5{         ValueMember$ TotalRevenue��5|      5~      5�      � 5�      $��2��6    5�      �� 5�      $
��auto �6$   �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��0��5�      $��	15,15,0,5q�5�      $��Thống kê trong ngày��5�      $��Montserrat SemiBold)�5�      $��16(�5�      $��
ExtraBlack"�5�      ���	#DD0000005�      � 5�      $��1��6   .+�5�      �� $��5,5,0,5q�5�      
������  �� RadiusX$ 20��5�       �� RadiusY$ 20��5�      
���   �5�      �� 5�      $ 
Horizontal=�6!   .+�5�      A� $��43��5�      $��43��5�      $��20,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      ��5�      �� 5�   "    �� ImageSource$ Icons/fish.png��6-   5�      �� 5�      -   5        $��
tblNumBill��5�      $��1��5�      $��75��5�       �� Padding$ 15q�5�      $
��Left=�5�      $��Center=�5�      $��Montserrat SemiBold)�5�      $��16(�5�      $��Medium"�5�      ��5�      �� *Revenue.NumBill+�� 5�      $��1��5�      $ 15q�5�      $
��Left=�5�      $��Center=�5�      $��Montserrat SemiBold)�5�      $��16(�5�      $��Medium"�5�      $��Tổng số hóa đơn��5�      5�      5�      � 5�      $��2��6   .+�5�      �� $��5,5,0,5q�5�      ���#cce6ff$ 20��5�      $ 20��5�      
���   �5�      �� 5�      $ 
Horizontal=�6!   .+�5�      A� $��43��5�      $��43��5�      $��20,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      ��5�      �� 5�   "   $ Icons/money.png��6-   5�      �� 5�      -   5        $��
tblRevenue��5�      $��1��5�      $��75��5�      $ 15q�5�      $
��Left=�5�      $��Center=�5�      $��Montserrat SemiBold)�5�      $��16(�5�      $��Medium"�5�      ��5�      �� *Revenue.TotalRevenue+�� 5�      $��1��5�      $ 15q�5�      $
��Left=�5�      $��Center=�5�      $��Montserrat SemiBold)�5�      $��16(�5�      $��Medium"�5�      $��Doanh thu trong ngày��5�      5�      5�      � 5�      $��3��6   .+�5�      �� $��5,5,0,5q�5�      ���#66b3ff$ 20��5�      $ 20��5�      
���   �5�      �� 5�      $��4,4,0,0q�6!   $ 
Horizontal=�62   .+�5�      A� $��43��5�      $��43��5�      $��20,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      ��5      �� 5  "   $ Icons/phone.png��6-   5     �� 5     -	   5        $��
tblBooking��5     $��1��5     $��75��5	     $ 15q�5
     $
��Left=�5     $��Center=�5     $��Montserrat SemiBold)�5     $��16(�5     $��Medium"�5     ��5     �� *Revenue.NumBooking+�� 5     $��1��5     $ 15q�5     $
��Left=�5     $��Center=�5     $��Montserrat SemiBold)�5     $��16(�5     
�������$��Medium"�5     $��Đặt trước��5     5     5     � 5     $��4��6   .+�5     �� $��5,5,0,5q�5      ���#0080ff$ 20��5"     $ 20��5#     
���   �5$     �� 5&     $ 
Horizontal=�6!   .+�5(     A� $��50��5)     $��47��5*     $��20,0,0,0q�5+     $
��Left=�5,     $��Center=�5-     ��5.     �� 5/  "   $ Icons/shopping-cart.png��6-   51     �� 54     -
   5        $��	tblCancel��55     $��1��56     $��75��57     $ 15q�58     $
��Left=�59     $��Center=�5:     $��Montserrat SemiBold)�5;     $��16(�5<     $��Medium"�5=     ��5>     �� *Revenue.NumCancel+�� 5@     $��1��5A     $ 15q�5B     $
��Left=�5C     $��Center=�5D     $��Montserrat SemiBold)�5E     $��16(�5F     $��Medium"�5G     $��Hóa đơn đã hủy��5H     5I     5J     5K     5N     � 5O  
   $��2��6    5P     �� 5R     $��3* �6#   �� 5S     $��1* �6#   .+�5W     9  3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  $��2��5X     $��10q�5Y     
������ $9 3So sánh tỉ lệ bán được theo số lượng��5[     $��Sitka Subheading)�5\     $��3��5]      5_       -   5        $��columnChart1��5`     $
 Name��5a     $  ��5b     $ Number��5c     5e     5g     5h     5i     