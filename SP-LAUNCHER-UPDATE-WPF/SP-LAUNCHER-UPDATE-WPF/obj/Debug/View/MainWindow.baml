   M S B A M L   `   `   `  ����Q  MSP-LAUNCHER-UPDATE-WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SP_LAUNCHER_UPDATE_WPFSP_LAUNCHER_UPDATE_WPF  5   	   '    !SP_LAUNCHER_UPDATE_WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SP_LAUNCHER_UPDATE_WPF     5   	     � Title$  SKANIE PROJECT - UPDATE��5   	   $	��800��6)   $	��800��66    � WindowStartupLocation$ CenterScreen=�6B    � 
ResizeMode$ NoResize=�6g    � WindowStyle$
 None=�6}   ���#0F1923.��5	      � -   5        .+�5
   
   �� -   5        $
��Left=�5
      $��80��6/   $	��Top=�6;   $	��800��6S   ���	#FFEF49586�   �� 5   
   -   5         ��Name$ _1STEPDOWNLOAD��5      $��обновление��6(   $
��Left=�6=   $��	15,15,0,0q�6X   $	��Top=�6k    
  Hatten#��[  6�   $��32(�6�   ���	#FF0F19236�   �� 5   
   -   5        $
��Left=�5      $��30��6+   $��
740,25,0,0q�67   $	��Top=�6K   $��30��6c   $#��/View/Res/Icon/icon_close.png��6n    � Cursor$
 Hand��6�   �� 5   
   -   5        $
��Left=�5      $��21��6+   $��
690,30,0,0q�67   $	��Top=�6K   $��30��6c   $.��(/View/Res/Icon/icon _chevron bottom_.png��6n   $
 Hand��6�   �� 5   
   $
��Left=�6   $	��720��6/   $	��Top=�6<   $��5��6T   ���	#FFEF4958$��0,80,0,0q�6o   �� 5   
   $
��Left=�6   $	��720��6/   $	��Top=�6<   $��5��6T   ���	#FFEF4958$��
795,80,0,0q�6o   �� 5   
   $��Center=�6   $��5��61   $	��Top=�6<   $	��790��6T   ���	#FFEF4958$��	0,795,0,0q�6q   �� 5   
   -   5        $ DOWNLOAD_START��5      $-��'обновление началось! ��6(   $
��Left=�6H   $	��Top=�6c   #��[  6{   $��40(�6�   ���	#FFEF4958$��121,370,0,0q�6�   �� 5   
   -   5        $ WAITFORDOWNLOAD��5      $���{Ожидайте завершения обновления, 
 это может занять некоторое время.��6)   $
��Left=�6{   $	��Top=�6�   #��[  6�   $��20(�6�   ���	#FFEF4958$��187,421,0,0q�6�   $��64��6  $��Center=�6  � 5   
   -   5         �Name$ PROGRESSBAR��5      $
��Left=�6+   $��25��6F   $��100,485,0,0q�6R   $	��Top=�6g   $	��600��6   ���	#FFEF4958���	#FFEF4958���	#FF1D27326�   5      5      