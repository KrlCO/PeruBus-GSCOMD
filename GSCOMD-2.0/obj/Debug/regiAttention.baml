   M S B A M L   `   `   `  ����E  AGSCOMD-2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GSCOMD_2._0GSCOMD_2._0  5          GSCOMD_2._0.regiAttention   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:GSCOMD_2._0     5        N� Title$  regiAttention��5      $	��496��6   .��5
      � -   5         �Name$ grdAtte��5
      
�������$��-18,-7,18,10q�6/    � RowDefinitions 5   
   �� 5      $
��495* �6   �� 5      $��8* �6   .+�5   
   �� -   5        $��CboTipoComida��5      $
��Left=�6(   $��	25,10,0,0q�6C   $	��Top=�6V   $	��235��6n   $��Consolas)�6z   $��11(�6�   $��30��6�   6�   �� 5   
   -   5        $��
BtnGenerar��5      $��	Registrar��6#   $
��Left=�67   $��350,410,0,0q�6R   $	��Top=�6g   $��76��6   $��27��6�    J� RenderTransformOrigin$ -0.079,-1.778&�6�   �� 5   
   -   5        $��CboCategoria��5      $
��Left=�6'   $��
297,10,0,0q�6B   $	��Top=�6V   $	��224��6n   $��Consolas)�6z   $��11(�6�   $��30��6�   6�   �� 5   
   -   5        $��Cancelar��5      $
��Left=�6$   $��446,410,0,0q�6?   $	��Top=�6T   $��75��6l   $��27��6w   6�   �� 5   
   -   5         ��Name$ 	btnCargar��5      $��CARGAR DATOS��6$   $
��Left=�6;   $��
220,76,0,0q�6V   $	��Top=�6j   $	��115��6�   6�   � 5   
   $��25,119,0,94q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgComidas��5         AutoGenerateColumns .     HeadersVisibility$ Column=�5         CanUserAddRows .  	   
IsReadOnly	 . 
   RowHeaderWidth$
 0Q�5      $��10q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Descripción��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Description+6^     5!      $
 Cant��6)   $ 50 6T    67   �� *
Quantity+6T     5"      $
 Subv��6)   $ 50 6Q    67   �� *Grant+6Q     5#      $ Efect��6)   $ 70 6Q    68   �� *Cash+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ 50 6-      CellTemplate 5%      �� 5&      .R�5'   "   �� -   5        $	��❌��5'   )   
���  ��
�������$
��Bold"�5*   !   $��30��5+   !   5,   !   5-      5/      51      � 54      $��10q�6   $��Bottom=�6    � ColumnDefinitions 55      �� 56      $��* �6'   �� 57      $
��Auto �6'   .+�5:      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5;      �� $��Cantidad��6    $��16(�60   $
��Bold"�6>   $��27��6P   $	��Top=�6\   �� 5<      -	   5         ��Name$ imQuan��5<       $��20(�60   $
��Bold"�6>   
����  �$��10,0,0,0q�6b   5=      �� 5?      $��1��6   $ 
Horizontal=�6-   .+�5@      �� $��Total (S/.)��6    $��16(�63   $
��Bold"�6A   �� 5A      -
   5        $ imAtte��5A       $��20(�60   $
��Bold"�6>   
��� � �$��10,0,0,0q�6c   5B      5C      5D      5F      5G      