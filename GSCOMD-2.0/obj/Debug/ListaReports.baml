   M S B A M L   `   `   `  ����E  AGSCOMD-2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GSCOMD_2._0GSCOMD_2._0  5   	       GSCOMD_2._0.ListaReports   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GSCOMD_2._0     5   	     � Title$  ListaReports��5   	   $	��500��6   $	��850��6+   ���#F0F0F0.��5
      � $��
10,10,10,0q�6   $	��449��6   $	��Top=�6,   .+�5   
   �� $��📊 REPORTE DE VENTAS��6   $��18(�5      $
��Bold"�6   $��Center=�5      $	��Top=�5      $��0,10,0,0q�5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgLista��5      $��Stretch=�5      $��	0,50,0,79q�61      AutoGenerateColumns .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�5         CanUserResizeColumns .    CanUserSortColumns .  �� TextAlignment$ Center=�5       � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType	 �� Property
 �� Value��%  '        �� 5      "  6   .�5      �� 	 � ��$
 14(�61   �� 5      	 � ��$

 Bold"�63   �� 5      	 � ��

 �����63   �� 5       	 � ��
 �#007ACC63   �� 5!      	 � ��$
 Center=�6C   �� 5"      	 � ��$
 5q�60   5#      5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ F. Emisión��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *FECHA_EMISION+ �� StringFormat$ {0:yyyy-MM-dd}��6z     5(      $ 	T. Comida��6%   $ * 6Y    68   �� *NO_TIPO_COMI+6Y     5)      $ 
Categoría��6%   $ * 6T    68   �� *	NO_CATE+6T     5*      $ Asignación��6%   $ * 6R    69   �� *ASIG+6R     5+      $ Subvención��6%   $ * 6U    69   �� *	IM_SUBV+6U     5,      $ Cantidad��6%   $ * 6S    67   �� *	NU_CANT+6S     5-      $ 	Sub Total��6%   $ * 6Y    68   �� *IM_SUBV_TOTA+6Y     5.      $ Efectivo��6%   $ * 6S    67   �� *	IM_EFEC+6S     5/      $ Total��6%   $ * 6P    64   �� *	IM_TOTA+6P   51      �� 53   
   $��Desde:��6   $
��Left=�6!   $��	0,394,0,0q�6<   $	��Top=�6O   $
��Bold"�6g   (  "System.Windows.Controls.DatePicker  54   
   -   5        $��FechIni��54      $
��Left=�6[   $��
49,395,0,0q�6v   $	��Top=�6�   $	��148��6�   �� 56   
   $��Hasta:��6   $
��Left=�6!   $��232,394,0,0q�6<   $	��Top=�6Q   $
��Bold"�6i     57   
   -   5        $��FechFin��57      $
��Left=�6[   $��277,395,0,0q�6v   $	��Top=�6�   $	��148��6�   �� 59   
   -   5        $��btnExportar��59      $��📥 Exportar��6$   $��Right=�5:      $��
0,393,35,0q�6-   $	��Top=�5;      $	��120��6)   $��30��65   $��14(�5<      $
��Bold"�6   ���#28A745
�������5>      �� 5@   
   -   5        $��btnImprimir��5@      $��🖨️ Imprimir��6$   $��Segoe UI Emoji)�5A      $��Right=�5B      $��0,393,175,0q�6-   $	��Top=�5C      $	��120��6)   $��30��65   $��14(�5D      $
��Bold"�6   ���#007acc
�������5F      5G      5H      