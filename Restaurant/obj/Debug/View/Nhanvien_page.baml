   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Restaurant.ViewRestaurant.View  5      #    Restaurant.View.Nhanvien_page   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Restaurant.View     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHMyMaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      e aDevExpress.Xpf.Controls.v20.1, Version=20.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aDdxnav8http://schemas.devexpress.com/winfx/2008/xaml/navigation  5      $	��580��5
      $
��1180��6     N� Title$  Nhanvien_page��5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��6* �6   �� 5      $
��1.3* �6   .+�5   
   �� $��0��6   $��	15 20 0 0q�5      $��Montserrat SemiBold)�5      $��23(�5      $��
ExtraBlack"�5      ���	#DD000000$��Quản lí nhân viên��5   '   ]� 5   
   $��1��6   .+�5      �� -   5         ��Name$ 	cmbfilter��5      $
��15 0q�5      
���   �$	��200��5       �� 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#��[  5!      $��Montserrat Medium)�5"      $��14(�66   5$      �� 5%      $��30 5 5 5q�5&      $	��700��6'   
���   �$��1q�5(       �� CornerRadius$ 15��5)      $��40��5*      ._�5,      �� -   5         ��Name$ txbfindstaff��5,      
������ $	��680��5.      
���iii�$	��Top=�50      $
��Left=�51      $��14(�52      $��0 3 0 0q�53      
������ )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm nhân viên��55      $��Montserrat Medium)�56      57      5:      '  !MaterialDesignThemes.Wpf.PackIcon  5<         Kind$ Magnify=�5=      $��22��5>      $��22��5?      $��
-30 20 5 5q�5@      �� 5A      $��45��6   ���	#FF2C2C2C$	��180��5C      
���W�.�$ 18��5E      $��3 0 0 0q�5F      $��1q�5G      ._�5H      �� -   5         ��Name$ btnadd��5H      
������ $��0q�5J      $��Montserrat SemiBold)�5K      $��Normal"�5L      $��16(�5M      $��45��5N      
�������$��Thêm nhân viên��5P      ���	#FF33ADF35S      	 � 	Resources	 5T      
 �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%  '��       �� 5U      "
 ��6    5V      P� 5W       �@J�IsMouseOver . . �5X   "   ��  � ��
 �����6O   �� 5Y   "    �@��CornerRadius$ 18��6A   6N   �� 5Z   "    � ��
 �����6P   �� 5[   "    � ��$ 1q�6D   6P   5\      5^      5_       J� Effect 5a      3  -System.Windows.Media.Effects.DropShadowEffect  5b         Color$
 Gray��5c   %      	Direction$	 270Q�5d   %      ShadowDepth$ 3Q�5e   %      
BlurRadius$ 5Q�5f   %   5h      5j      �� 5k   
   -   5         ��Name$ 	listStaff��5o      $��2��5k      $
��20 0q�6    $��1q�5l      
���   �
������ $��Montserrat SemiBold)�5p      	 5q       �� RelativeSource �� Path �� 
TargetType ]� Thumb ]� IncreaseRepeatButton J� Opacity ]� DecreaseRepeatButton��%"  '��       '��     '��     �� 5r      "
 ��6   .�5s      ��  � ��$ Cambria)�63   �� 5t       � ��
 ���_�63   �� 5u       � ��$ 16(�61   �� 5v       � ��$ CharacterEllipsis=�65   �� 5w       �@�ToolTip 60   ��  �� *Self+$
 Text�5x      �� 5y      "
 ��6   .�5z      ��  � �� �#2C459A63   �� 5{       � ��$ 15(�61   �� 5|       � ��$ DemiBold"�63   6F   �� 5}       �@�ToolTip 5~   %   ��  �� *Self+$
 Text�5      �� 5�      "
 ��6   .�5�      ��  � ��$ 2,50,0,8q�6/   �� 5�       �@��IsFlicksEnabled .  6?   �� 5�       � ��
 ���� 63   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   ]� ��. |�.   5�   &   n� 5�   *   $��8��60   
��� � �6:    5�   &   �� 5�   *   $��ScrollBar.PageDownCommand��67   $ 0Q�6[   |�.  6g    5�   &   �� 5�   *   $��ScrollBar.PageUpCommand��67   $ 0Q�6Y   |�.  6e   5�   #   5�      5�      5�      5�       �� View 5�      �� 5�       �� AllowsColumnReorder . .P�5�      ��  �� Width$	 120��6%     �� DisplayMemberBinding  61   �� *Id+! �� HeaderTemplate! 5�      �� 5�      .R�5�   "   �� $
��Left=�6)   ._�5�   &   �� $��ID��6,   5�   #   5�      5�      �� 5�      $	 200��6%     61   �� *Name+! 5�      �� 5�      .R�5�   "   �� ._�5�   &   �� $��Tên NV��6,   5�   #   5�      5�      �� 5�      $	 150��6%     61   �� *Phone+! 5�      �� 5�      .R�5�   "   �� $��Điện thoại��6(   5�      5�      �� 5�      $	 120��6&     63   �� *Sex+! 5�      �� 5�      .R�5�   "   �� ._�5�   &   �� $��Giới tính��6,   5�   #   5�      5�      �� 5�      $	 200��6&     63   �� *	Address+! 5�      �� 5�      .R�5�   "   �� ._�5�   &   �� $��Địa chỉ��6,   5�   #   5�      5�      �� 5�      $	 150��6&     63   �� *Level+! 5�      �� 5�      .R�5�   "   �� ._�5�   &   �� $��Chức vụ��6,   5�   #   5�      5�      �� 5�      $	 120��6&     63   �� *Salary+! 5�      �� 5�      .R�5�   "   �� ._�5�   &   �� $��Lương��6,   5�   #   5�      5�      5�      5�      � 5�   
   -   5        " �Name$" Progressbar��5�      
���/��� % !MaterialDesignCircularProgressBar#��[ 5�      $��404,267,756,292q�5�   +   $y�Visible=�5�      {�. # � Triggers# 5�      :� 5�      $ :� RoutedEvent$$ Loaded��6   .[�5�      �� .��5�      �� .��5�      W� % �� TargetProperty$% Value�6.   & W� From$& 0X�5�   .   	' W� To$	' 100X�5�   .   ( g� Duration$( 0:0:1D�5�   .   ) g� RepeatBehavior$) Forever��5�   .   5�      5�      5�      5�      ]� 5�   
   $��3��6   $��10 0 0 0q�5�      	 5      ��%�   '��       �� 5     "
 ��6    5     P� 5      �@J�IsMouseOver . . �5     ��  � ��
 ��  �6J   5     5     5     .+�5	     �� $��15(�6   $��30��5
     $��
30,10,30,5q�5     
���   �$��Montserrat Medium)�5     .��64   Nhân viên đang làm việc6M   �� 5     -   5        $��txbamountstaff��5     $
��10 0q�5     $��15(�5     $��40��5     * �� 
IsReadOnly* . 
���   �.��5  )   156-   �� 5     -   5        $ cmbFilter_amountstaff��5     $	��200��5     $��14(�5     
������ $��1q�5     $��10 7 0 7q�5     
�������$
��Left=�5      . #��[  5     $��20,16,20,23q�5     .@�5      �� + �� 
IsSelected+ . $��
Tất cả��61   �� 5!     $��Doing��6   �� 5"     $��Undoing��6   63   5$     �� 5&     $��3��5'     $��Right=�5(     
����d�
�����_�$ 35��5+     $��70��5,     $��
0,6,-490,0q�5-     $��70��5.     $��1q�5/     $	��Top=�50     ._�53     �� -   5        $ 	btndelete��53     
������ $��0q�55     $��Montserrat SemiBold)�56     $��Normal"�57     $��	0 -05 0 0q�58     
����������	#FF33ADF3.��5;       -	   5        $ Delete=�5;  0   $��32��5<  0   $��60��6<   $��Center=�5>  0   5@     5A      5B       5C     $
 Gray��5D  %   $	 270Q�5E  %   $ 3Q�5F  %   $ 5Q�5G  %   5I     �� 5J     $��3��5K     $��Right=�5L     
����d�
�����_�$ 35��5O     $��70��5P     $��70��5Q     $��0 0 50 0q�5R     $��1q�5S     ._�5T     �� -
   5        $ btnedit��5T     
������ $��0q�5V     $��Montserrat SemiBold)�5W     $��Normal"�5X     $��	0 -05 0 0q�5Y     
����������	#FF33ADF3.��5^       -   5        $
 Edit=�5^  0   $��32��5_  0   $��60��6<   $��Center=�5`  $   5c     5d      5e       5f     $
 Gray��5g  %   $	 270Q�5h  %   $ 3Q�5i  %   $ 5Q�5j  %   5l     5n     � 5p  
   -   5        , �Name$, editNv_form��5t     $��3��5p     $��1��5q     ���#212226$
 0.93Q�5s     $��328,0,334,62q�5t  *   $	��417��6@   $��Bottom=�6M   	 5u     ��%h  ']�       '�� Q     �� 5w     "
 ]�6   .�5x     ��  � ��$ Bottom=�6:   6K   5z     �� 5{     "
 ��6   .�5|     ��  � ��$ 5 15 5 0q�6/   6B   �� 5}      � ��
 �����6I   �� 5~      � ��$ Center=�6:   6K   �� 5      � ��$ 1q�68   6D   �� 5�      �@��CornerRadius$ 7��65   6A   5�     5�      5�     �� 5�     $
��1.1* �6    �� 5�     �� 5�     �� 5�     �� 5�     $
��2.2* �6    �� 5�     - � ColumnDefinitions- 5�     �� 5�     $��3* �6#   �� 5�     $��7* �6#   .+�5�     ]� $��1��6   $��0��6(   .+�5�     �� $��70��6   ._�5�     �� -   5        $ txbId��5�     
�������$��14(�5�     $��Montserrat Light)�5�     $��Center=�5�     $��3 2 0 2q�5�     $ ID��5�     5�     �� 5�     ._�5�     �� -   5        $ txbname��5�     
�������$��14(�5�     $��Montserrat Light)�5�     $��3 2 0 2q�5�     $ Ten nhanvien��5�     5�     5�     ]� 5�     $��1��6   $��1��6(   .+�5�     �� $	��118��6   $��0 0 20 0q�5�     ._�5�     �� -   5        $ txbphone��5�     $��14(�5�     $��Montserrat Light)�5�     $��3 2 0 2q�5�     
�������$ Số điện thoại��5�     $��0,0,-1,0q�6O   5�     �� 5�     -   5        . ��Name$. 	chbgender��5�     $��14(�5�     
�������/ d� 	IsChecked$
/ TrueY�5�     .��6-   Nam5�     �� 5�     -   5        $ 
cmbmanager��5�     $��20 0 0 0q�5�     $��13(�5�     $��5 0 0 10q�5�     $��Montserrat Light)�5�     
�����_�$
��Left=�5�     
�������$	��134��5�      . 0 �� Text$0 manager��5�     #��[  5�     5�     5�     ]� 5�     $��1��6   $��2��6(   .+�5�     �� $��	05 0 10 0q�6   ._�5�     �� -   5        $ 
txbaddress��5�     $��15(�5�     $��Montserrat Light)�5�     $��3 2 0 2q�5�     
�������$ Địa chỉ��5�     5�     5�     ]� 5�     $��1��6   $��3��6(   .+�5�     �� -   5        $ cmbposition��5�     $��0 0 0 5q�5�     $��12(�5�     $��Montserrat Light)�5�     
�����_�$
��Left=�5�     
�������$	��134��5�      . #��[  5�     5�     �� 5�     $	��190��6   $��	13 0 20 0q�5�     ._�5�     �� -   5        $ 	txbsalary��5�     $��14(�5�     $
��Bold"�5�     $��Montserrat Light)�5�     $��3 2 0 2q�5�     
�������$��5,0,9,0q�5�     $ Lương��5�     5�     5�     �� 5�     $��1��6   $��4��6%   $��5,9,5,0q�5�     $	��110��6&   $ 0��5�     $	��0.6q�5�     ._�5�     �� $	��5 5q�6   .+�5�     �� 
�������$��12(�5      $��2 0 0 0q�5     $��Montserrat Light)�5     .��67   Thông tin tài khoản5     �� 5     $��	5 0  10 0q�5     $ 1��5     ._�5     �� -   5        $ txbusername��5  "   $��14(�5	     $��Montserrat Light)�5
     $��3 2 0 2q�5     
�������$ 	User name��5     5     �� 5     $��5 5 10 0q�5     $ 1��5     ._�5     �� -   5        $ txbpass��5  "   $��14(�5     $��Montserrat Light)�5     $��3 2 0 2q�5     
�������$ Password��5     5     5     5     �� 5     -   5        $ cmbstate��5     $��4��5     $��Bottom=�5     $��0 0 10 5q�5     $��15(�5     $��5 0 5 0q�5      $��Montserrat Light)�5!     
�����_�$��Right=�5#     
�������$	��100��5%     {�.  $0 Doing��5'      . #��[  5)     @�5*     �� 5+     .��6#   Doing6*   �� 5,     .��6#   	Undoing6,   5/     ]� 51     $��1��6   $��5��6(   $
��10 7q�65   	 52     ��%�   '��       �� 53     "
 ��6    54     P� 55      �@J�IsMouseOver . . �56  "   ��  � ��
 �   �6O   �� 57  "    � ��
 �����6P   �� 58  "    � ��$ 1q�6D   6P   59     5;     5<     .+�5=     �� $��43��6   $
��Left=�5>     ���	#FF2C2C2C$	��150��5@     
�����_�$ 18��5B     $��3 0 0 0q�5C     $��1q�5D     ._�5E     �� -   5        $ btnSave��5F     
������ $��0q�5H     $��Montserrat SemiBold)�5I     $��Normal"�5J     $��16(�5K     $��35��5L     
�������$
��Lưu��5M  ,   ���	#FF33ADF36R    5N       5O     $
 Gray��5P  %   $	 270Q�5Q  %   $ 3Q�5R  %   $ 5Q�5S  %   5U     �� 5V     $��43��6   $��Right=�5W     ���	#FF2C2C2C$	��150��5Y     
�����_�$ 18��5[     $��3 0 10 0q�5\     $��1q�5]     ._�5`     �� -   5        $ 	btnCancel��5c     
������ $��0q�5b     $��Montserrat SemiBold)�5d     $��Normal"�5e     $��16(�5f     $��35��5g     
�������$��Hủy��5h  ,   ���	#FF33ADF36R    5i       5j     $
 Gray��5k  %   $	 270Q�5l  %   $ 3Q�5m  %   $ 5Q�5n  %   5p     5q     �� 5r     $	��130��6   $	��160��5s     $��0��6"   $��3��5t     ._�5u     �� -   5        1 ��Name$1 	img_staff��5u     5w     5x     �� 5y     $��43��6   $��Center=�5z     ���#F58240$	��120��5|     
�����_�$ 18��5~     $��0 0 0 10q�5     $��1q�5�     $��3��5�     ._�5�     �� -   5        $ btnload_img��5�     
������ $��0q�5�     $��Montserrat SemiBold)�5�     $��Normal"�5�     $��16(�5�     $��45��5�     
�������$��Tải ảnh��5�  ,   ���	#FF33ADF36>   5�     5�     5�     5�     