   M S B A M L   `   `   `  ����E  AGSCOMD-2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GSCOMD_2._0GSCOMD_2._0  5   	       GSCOMD_2._0.MainWindow   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GSCOMD_2._0     5   	     � Title$  GSCOMD��5   	   $	��527��6   $	��965��6%   .��5	      � $��0,0,0,0q�6    J� RenderTransformOrigin$	 0,0&�6   $	��496��68   $��Bottom=�6E    � ColumnDefinitions 5
   
   �� 5      $	��18* �6   �� 5      $
��273* �6   �� 5      $	��396 �6   .+�5   
   �� -   5         ��Name$ txtCodeTrab��5      $
��Left=�6'   $��24��6B   $��	30,56,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��Center=�6�   $	��150��6�   $��2��6�   $��Consolas)�6�   $��11(�6  �� 5   
   $��Codigo Trabajador:��6   $��	30,30,0,0q�6-   $	��Top=�6@   $��26��6X   $��Consolas)�6d   $
��Left=�6z   $	��150��6�   $��2��6�   $
��Bold"�6�   �� 5   
   -   5        $ txtNombTrab��5      $
��Left=�6'   $��36��6B   $��
30,120,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $��Center=�6�   $	��150��6�   $��2��6�   $��Consolas)�6�   $��11(�6�   {�.   �� 
IsReadOnly . 6  �� 5   
   $��	Comensal:��6   $
��Left=�6$   $��	30,94,0,0q�6?   $	��Top=�6R   $��26��6j   $	��150��6v   $��2��6�   $��Consolas)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ btnValidacion��5      $��VALIDAR��6(   $��30,217,216,0q�6:   $	��Top=�6P   $��2��6h   $��33��6x   $ 	0.52,0.03&�6�   $��Consolas)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Cancelar��6   $
��Left=�6$   $��158,354,0,0q�6?   $	��Top=�6T   $��75��6l   $��2��6w   $��20��6�   �� 5   
   -   5        $��
btnReporte��5      $��Reporte��6#   $
��Left=�65   $��291,354,0,0q�6P   $	��Top=�6e   $��75��6}   $��2��6�   $��20��6�   6�   �� 5   
   
���   �$��1q�6%   $��2��69   $��Right=�5      $	��Top=�6)   $	��220��5      $	��160��6   $��	0,30,30,0q�6&   ._�5      �� -   5         ��Name$ imgTrab��5      $ 0.894,0.502&�6%   5      �� 5   
   -   5         ��Name$ lblAsig��5      $�� ��6!   $��2��6,   $
��Left=�6<   $��
30,170,0,0q�6W   $	��Top=�6k   $��Center=�6�   $��Center=�6�   $	��150��6�   $ 0.511,1.231&�6�   $��30��6�   $��Consolas)�6  $
��Bold"�6  
������ 6-   � 5   
   -   5        	  �Name$	 frmAtte��5      
  � NavigationUIVisibility$
 Hidden=�6!   $�� ��6A   $ 
1.46,-0.18&�6L   $��1��6�   $��Right=�6�   $	��526��6�   $��	0,30,0,10q�6�   5!      5"      