   M S B A M L   `   `   `  ����C  ?Semaforo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SemaforoSemaforo  5   	       Semaforo.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Semaforo     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��	SEMÁFORO��6   $��0��6$   $��1��61   $��10q�6A   $��45(�5       �� TextAlignment$ Center=�6"   
����  �69   �� 5   
   -   5        $��
PanelRadio��5   2   $��1��6   $��1��6"   .+�5      	� -   5        $��RBred��5      $��5, 18, 5, 5q�6'   .��5      �� 
���  ��$��20(�6-   Rojo6A   5      	� 5      -   5        $��RBOrange��5      $��5, 18, 5, 5q�6*   .��5      �� 
��� ���$��20(�60   	Naranja6G   5      	� 5      -   5        $��RBVerde��5      $��5, 18, 5, 5q�6)   .��5      �� 
��� � �$��20(�6/   Verde6D   5      5       �� 5!   
   $��1��6   $��0��6"   .+�5"      � $��1��6   .+�5#      �� $��/semaforo.png��6   $	��200��6/   $	��200��6;   A� 5$      -   5        $��eRojo��5$      $��35��6'   $��35��62   
���  ��$��100,0,100,150q�5%      $y�Visible=�61   A� 5&      -   5        $��eAmbar��5&      $��35��6(   $��35��63   
��� ���$��100,0,100,73q�5'      $y�Visible=�60   A� 5(      -   5        $��eVerde��5(      $��35��6(   $��35��63   
��� � �$��100,3,100,0q�5)      $y�Visible=�6/   5*      5+      5,      5-      