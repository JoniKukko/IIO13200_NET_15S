   M S B A M L   `   `   `  ����N  JTehtava8Valipalaute, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Tehtava8ValipalauteTehtava8Valipalaute  5   	   $    Tehtava8Valipalaute.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Tehtava8Valipalaute     5   	     � Title$   Tehtävä 8 - Välipalaute��5   	   $	��700��6)   $	��450��66   $��Verdana)�6B   $��12(�6W    � 
ResizeMode$ NoResize=�6e   .��5	      � .+�5   
   �� $��Anna palaute��6   $
��Bold"�6'   $��	10,10,0,0q�69   �� 5   
   -   5         ��Name$ feedbackListbutton��5      $��
300,10,0,0q�6-   $��
Palautteet��6A   6V   �� 5   
   $	��Pvm��6   $��	10,40,0,0q�6   �� 5   
   -   5         ��Name$ textbox_date��5      $��
100,40,0,0q�6(   �� 5   
   $
��Nimi��6   $��	10,70,0,0q�6   �� 5   
   -   5        $ textbox_name��5      $��
100,70,0,0q�6(   �� 5   
   $��Olen oppinut��6   $��
10,100,0,0q�6'   �� 5   
   -   5        $ textbox_learned��5      $��100,100,0,0q�6+   $��90��6@    �� TextWrapping$
 Wrap=�6L    �� AcceptsReturn . 6`   �� 5   
   $��Haluan oppia��6   $��
10,200,0,0q�6'   �� 5   
   -   5        $ textbox_wanttolearn��5      $��100,200,0,0q�6/   $��90��6D   $
 Wrap=�6P    . 6d   �� 5   
   $��Hyvää��6   $��
10,300,0,0q�6    �� 5   
   -   5        $ textbox_good��5      $��100,300,0,0q�6(   $��90��6=   $
 Wrap=�6I    . 6]   �� 5   
   $��Parannettavaa��6   $��
10,400,0,0q�6(   �� 5   
   -   5        $ textbox_bad��5      $��100,400,0,0q�6'   $��90��6<   $
 Wrap=�6H    . 6\   �� 5!   
   $��Muuta��6   $��
10,500,0,0q�6    �� 5"   
   -   5        $ textbox_other��5"      $��100,500,0,0q�6)   $��90��6>   $
 Wrap=�6J    . 6^   �� 5$   
   -	   5        $ button_send��5$      $��Lähetä palaute��6&   $��100,600,0,0q�6?   6T   5'      5(      