   M S B A M L   `   `   `  ����D  @PruebaWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PruebaWpf	PruebaWpf  5   	       PruebaWpf.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PruebaWpf     5   	     � Title$  Ventana��5   	   $	��450��6   $	��800��6&   .��5	      � -   5         �Name$ ventanaP��5	       � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ Panel��5      $��1��6$   $��1��61   .+�5      �� $��HOLAA��6   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Enviar��5      $��
0,10,10,20q�6*   $��70��6>   $	��150��6J   6V   �� 5      -   5        $��	NO enviar��5      $��
10,10,0,20q�6-   $��70��6A   $	��150��6M   6Y   5      5      �� 5   
   $��15q�6   $��2��6!   $��1��6.   .+�5      �� .��6   
Opciones6   �� 5      -   5        $��MarcarTodas��5       d� IsThreeState . .��5   W   	Agregar5!      �� 5"      $��15q�6   .+�5#      �� -   5        $	��Op1��5#      .��6T   
Opcion 16^   �� 5$      -   5        $	��Op2��5$      .��6T   
Opcion 26^   �� 5%      -   5        $	��Op3��5%      .��6T   
Opcion 36^   �� 5&      -	   5        $	��Op4��5&      .��6T   
Opcion 46^   5'      5(      �� 5*   
   -
   5        $��	TextValor��5*   ;   $��0��6   $��1��6   $	��100��6/   $��40��6L   ��6X   ��  �� ElementName$ SliderValor�� �� Path$ Value�	 �� Mode$	 TwoWay=��� 5+   
   -   5        $��SliderValor��5+      $��3��6$   $��1��61   
 � Minimum$
 0Q�6A    � Maximum$	 100Q�6M   5,      5-      