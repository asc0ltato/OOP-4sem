   M S B A M L   `   `   `  ����E  AOOP_Lab4-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:OOP_Lab4_5
OOP_Lab4_5  5          OOP_Lab4_5.ViewAllBooks   5   	   R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      (localclr-namespace:OOP_Lab4_5    5        � Title$)  #Управление книгами��5      $	��528��6(   $
��1000��65   $	��528��5	      $
��1000��6    � WindowStartupLocation$ CenterScreen=�6-    � Icon$K EC:\Users\user\Desktop\ООП\OOP_Lab4-5\OOP_Lab4-5\Resources\icon.png��5
       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Find��5      6(     5   
   -   5        $	 New��5      6'     5   
   -   5        $ Paste��5      6)     5   
   -   5        $ Delete��5      6*     5   
   -   5        $ Refresh��5      6+     5   
   -   5        $	 Cut��5      6'   .��5      � -   5        $��mainGrid��5         BlackAndWhite#���   6    � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $
��3.5* �6   6.   .+�5    
   � -   5        $��leftMenu��5       $��1��6   $��0��6,    5"      �� 5#      $
��0.8* �6    60   �� 5$      $
��1.2* �6    60   �� 5%      $��1* �6    6.   �� 5&      $��1* �6    6.   �� 5'      $��1* �6    6.   �� 5(      $��1* �6    6.   �� 5)      $
��1.4* �6    60   .+�5,      �� -	   5        $��
undoButton��5,      $��40��6'   $��40��62   $
��Left=�6>   $��60 0 0 0q�5-      $��0��6   
������ $��0q�6E   .��5.      �� $K��EC:\Users\user\Desktop\ООП\OOP_Lab4-5\OOP_Lab4-5\Resources\undo.png��6   $��3q�6d   5/      �� 51      -
   5        $��
redoButton��51      $��40��6'   $��40��62   $��Right=�6>   $��0 0 60 0q�52      $��0��6   
������ $��0q�6E   .��53      �� $K��EC:\Users\user\Desktop\ООП\OOP_Lab4-5\OOP_Lab4-5\Resources\redo.png��6   $��3q�6d   54         OOP_Lab4_5.UserControl1  56      -   5          Name$ 	searchBox��56   -   $��25��6!   $��1��57      $	��Top=�6"   $��	41,0,32,0q�6:   �� 58      -   5        $��searchButton��58      $��1��6*     ButtonStyle#��[ 67    
 search#���  6\     templateSearch#���  6   $
��Find��6�   $��	0 0 0 -40q�6�   �� 59      -   5        $��	addButton��59      $��2��6&   #��[ 63     
addingBook#���  6X     templateAdd#���  6   $	��New��6�   $��0 0 0 5q�6�   �� 5:      -   5        $��redactButton��5:      $��3��6)   #��[ 66    
 redact#���  6[     templateRedact#���  6~   $��Paste��6�   $��0 0 0 5q�6�   �� 5;      -   5        $��deleteButton��5;      $��4��6)   #��[ 66    
 delete#���  6[    	 templateDel#��� 	 6~   $��Delete��6�   $��0 0 0 5q�6�   �� 5<      -   5        $��
showButton��5<      $��5��6'   #��[ 64    
 showAll#��� 
 6Y     templateAll#���  6}   $��Refresh��6�   $��0 0 0 5q�6�   �� 5>      -   5        $��comboBoxFilterSelect��5>      $��6��63     ComboBoxStyle#��[ 6@   $��Center=�6g   $	��Top=�6�   $��0 10 0 0q�6�   .@�5?      ��   genRoman#���  6   6F   �� 5@        	genComedy#���  6   6G   �� 5A        genDrama#���  6   6F   �� 5B        genMelodrama#���  6   6J   �� 5C        genFantastic#���  6   6J   �� 5D        
genFantasy#���  6   6H   �� 5E        genThriller#���  6   6I   �� 5F        	genHorror#���  6   6G   �� 5G       
 genWar#���  6   6D   �� 5H        genKids#���  6   6E   5I      �� 5K      -   5        $��filterButton��5K      $��7��6)   #��[ 66    
 filter#���  6[     templateFilter#���  6~   $	��Cut��6�   $��Bottom=�6�   $��0 0 0 10q�6�   5L      �� 5O   
   -   5        $
��back��5O      $��40��60   $��40��6;   $
��Left=�6G   $��10q�6b   $��5q�6n    �� IsCancel . ��6�   Z� ��6�   Z� .��5P      �� $��/Resources/srt.png��6   62   5Q      �� 5S   
   $��/Resources/banner.png��6   $��0��6/     logoShowOnLoad#���  6<   $��103,10,326,10q�6e   $��1��6|   �� 5U   
   -   5        $��	tableView��5U      $��1��6$   $��1��61   	 �� View	 5V      �� 5W      .P�5X      �� 
 �� Width$	
 246��6&     bookName#���  62    �� CellTemplate 5Y      �� 5Z      .R�5[   "   �� $
��Wrap=�6C   $��16(�6W   ���#99aab5$��30,0,0,0q�6z   ��6,   �� *Title+6�   5\      5^      �� 5`      $	
 246��6&    
 author#���  62    5a      �� 5b      .R�5c   "   �� $
��Wrap=�6D   $��16(�6X   ���#99aab5$��30,0,0,0q�6{   ��6,   �� *Author+6�   5d      5f      �� 5h      $	
 247��6&    	 photo#���  62    5i      �� 5j      .R�5k   "   �� $��80��6A   $��80��6L   $��80 0 0 0q�6X   $��Center=�6j   ��6(   �� *Photo+6�   5l      5n      5p      5r      5s      5t      