   M S B A M L   `   `   `  ����J  FLauncherUpdater, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LauncherUpdaterLauncherUpdater  5   	        LauncherUpdater.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LauncherUpdater     5   	   -   5          � Title$  Updater��5   	   $	��200��6   $	��390��6&    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��5      $��2��6"   $��0��5      $��2��6%   .+�5      �� $��Versions��6   .��5      �� $ 
Horizontal=�6   .+�5      �� $��Server Version:��6   $��14(�5      �� 5      -   5        $��
Server_Ver��5       $��
No Version��5      $
��Bold"�5      $��14(�5      5       �� 5!      $��Client Version:��6   $��14(�5"      �� 5#      -   5        $��
Client_Ver��5&      $��
No Version��5#      $
��Bold"�5$      $��14(�5%      5&      5'      5(      �� 5)      $��Status��6   .��5*      �� $ 
Horizontal=�6   .+�5+      �� $��Server:��6   $��14(�5,      �� 5-      -   5        $��Server_Status��50      $��
No Version��5-      $
��Bold"�5.      $��14(�5/      50      51      52      53      �� 54   
   -   5        $��Start_Launcher��5:      $��Start Launcher��54      $��Center=�55      $��Center=�56      $��2��57      $��1��6   $	��130��58      $��30��59      5:   '   �� 5;   
   -   5        $��Update_Launcher��5A      $��Update��5;      $��Center=�5<      $��Center=�5=      $��2��5>      $��0��6   $	��130��5?      $��30��5@      5A   (   5B      5C      