   M S B A M L   `   `   `  ����>  :NBA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NBA.viewNBA.view  5   	   $    NBA.view.ActualizaEquipoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NBA.view     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Actualizar equipo��5	   	   $	��250��6#   $	��300��60    � 	Resources 5       �� Source�� 5   
   $ 
Style.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��0, 10q�6K   .+�5      �� $��70��6   .��6   Nombre6'   �� 5      -   5        $��nombreTextBox��5      $	��200��6+   $��10, 0q�67   5      �� 5!   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Right=�6K   .+�5"      �� -   5        $��10q�5"   1   .��6=   	Aceptar6F   �� 5#      -   5        $��10q�5#   2   .��6>   
Cancelar6H   5$      5%      5&      