   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Restaurant
Restaurant  5   	   C&clr-namespace:Restaurant.MyUserControlRestaurant.MyUserControl  5   	       Restaurant.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Restaurant     5   	   7myUC&clr-namespace:Restaurant.MyUserControl     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHMyMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ 
MainWindow��5   	   $	��650��6   $
��1260��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5         sbShowLeftMenu �� TargetProperty t� From	 t� To g� DecelerationRatio	 g� Duration  sbHideLeftMenu��%"  &	        &	 �     �� 5   
   .��5      t� $ Margin�6!   $ 
-150,0,0,0X�6D   $ 0,0,0,0X�6V   $ .9Q�6c   $	 0:0:1D�6z   6�   5      �� 5   
   .��5      t� $ Margin�6!   $ 0,0,0,0X�6D   $ 
-150,0,0,0X�6S   $ .9Q�6c   $	 0:0:1D�6z   6�   5      5      .��5      � ���#f5f5f5
 � ColumnDefinitions
 5   
   �� 5      $��0.062* �6   60   �� 5      6!    � RowDefinitions 5   
   �� 5       $��52 �6   6*   �� 5!      6   .+�5#   
   �� $��0��6   $��2��5$      $��0��5%      $��2��5&      .+�5'      #   Restaurant.MyUserControl.Info  #   Restaurant.MyUserControl.Info   Loaded$ Info_Loaded_1��6%   $��50��6   5(      5)      �� 5,   
   -   5         ��Name$ spLeft��5,       K� ZIndex$ 2��6%   ���#151619  spSlideLeft#��[ 5.      $	��220��5/      $��2��6%   $��2��50      $��
-150 0 0 0q�6*   $
��Left=�51      .+�52      �� $	��140��6   .+�54      �� $��60��6   $��60��6%   $��
30 15 0 20q�55       �� CornerRadius$ 20��56      $
��Left=�57      ._�59      �� $��View/Images/admin1.jpg��6   $
��Fill=�5:      6.   5;      �� 5<      $��35��6   $	��120��6%   
�������$��1q�5>      $ 20��5?      $��20 0 0 0q�5@      $
��Left=�5A      ._�5B      �� 
�������$��16(�5C      $��Center=�5D      .��6@   Admin5F      5G      �� 5H      -   5         ��Name$ 
adminlabel��5J      
���iii�$��60��5I      $��55��6$   $ 28��5K      $��150 -60 0 10q�5L      $y�Hidden=�5M      ._�5N      �� $��Center=�6   $��Bottom=�5O      $��15(�5P      $
��Bold"�5Q      
�������$��0,0,0,13q�5S      .��6.   Admin65   5T      5V      ]� 5X      -   5         ]�Name$ banhang_dock��5X        dockmenu#��[ 6.   .+�5Y      �� -   5         ��Name$ enterBHpage��5Y   $   $	��140��6     	MenuLabel#���  5Z      $��
Bán hàng��5[      5]      �� 5^      $��View/Images/home.png��6   $��35��5_      $��35��6'   $��Center=�5`      $��Center=�5a      $��14,10,10,10q�5b      64   5c      ]� 5d      #��[ 6   .+�5f      �� -   5        $ enterMApage��5g   9   $	��140��5f      $��Center=�5g      #���  5h       $��Món ăn��5j       $��Center=�5k      5l   #   �� 5t      $��View/Images/food.png��6   $��35��5u      $��35��6'   $��Center=�5v      $��Center=�5w      $��14,10,10,10q�5x      65   5y      ]� 5z      #��[ 6   .+�5{      �� -   5        $ enterKHpage��5|   1   $	��140��5{      #���  6$   $��Khách hàng��5|      $��Center=�5}      $��Source Sans Pro)�5~      6;   �� 5      $��View/Images/customer.png��6   $��35��5�      $��35��6'   $��Center=�5�      $��Center=�5�      $��14,10,10,10q�5�      65   5�      ]� 5�      #��[ 6   .+�5�      �� -   5        $ enterNVpage��5�   %   $	��140��6   #���  5�      $��Nhân viên��5�      $��Center=�5�      $��Source Sans Pro)�5�      5�   =   �� 5�      $��View/Images/manager.png��6   $��35��5�      $��35��6#   $��Center=�5�      $��Center=�5�      $��14,10,10,10q�5�      61   5�      ]� 5�      #��[ 6   .+�5�      �� #���  6   $	��140��5�      $��Khuyến mãi��5�      $��Center=�5�      $��Source Sans Pro)�5�      67   �� 5�      $��View/Images/voucher.png��6   $��35��5�      $��35��6#   $��Center=�5�      $��Center=�5�      $��14,10,10,10q�5�      61   5�      ]� 5�      #��[ 6   .+�5�      �� -	   5        $ enterBillpage��5�   3   #���  5�      $	��140��5�      $��Chi tiết hóa đơn��6$   $��Center=�5�      $��17(�5�      $��Source Sans Pro)�5�      67   �� 5�      $#��View/Images/chitiethoadon.png��6   $��35��6?   $��35��5�      $��Center=�5�      $��Center=�5�      $��14,10,10,10q�5�      61   5�      ]� 5�      #��[ 6   .+�5�      �� -
   5        $ enterDTpage��5�   8   #���  5�      $	��140��5�      $��	Doanh thu��6$   $��Center=�5�      $��Source Sans Pro)�5�      67   �� 5�      $��View/Images/bar-chart.png��6   $��35��5�      $��35��6#   $��Center=�5�      $��Center=�5�      $��14,10,10,10q�5�      61   5�      5�      �� 5�   
   $��1��6   $��1��6%   
�������.+�5�       � -   5          �Name$ 	showFrame��5�        � NavigationUIVisibility$ Hidden=�5�      5�      5�      5�      