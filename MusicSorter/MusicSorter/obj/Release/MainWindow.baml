   M S B A M L   `   `   `  ���� F  BMusicSorter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicSorterMusicSorter  )clr-namespace:MusicTaggerMusicTagger      MusicSorter.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:MusicSorter     +musicclr-namespace:MusicTagger     -     �Name$  window�� � Title$ 
MainWindow��$	��450��$	��525�����#2f3237 � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	 ��Name
 �� RadiusX �� RadiusY j� Stretch j� ViewportUnits j� Viewport j� TileMode L� Drawing � Brush � Geometry � FillRule �� Rect   RectengleStyle �� MergedDictionaries �� Source��  �� $! /Resources/Music Label.xaml?��� $$ /Resources/musicBlackLogo.xaml?�%  '�       &	  �    �� " �.���  � �� �� " �.R��    CommonStates��.   Determinate��  Indeterminate��.+��� $	 
PART_Track��
������ 
���   �$
 10��$ 10���� $	 PART_Indicator��$
��Left=�
���   �$
 10��$ 10����L� $ UniformToFill=�$ Absolute=�$ 	0,0,10,10�$
 Tile=� I� ��� 
 �   � � $ Nonzero=�.���� $ 0,0,100,100�� 
 ����  � $ Nonzero=�.���� $ 30,0,100,100��� " ����  � ��
 ��ح�.��� .+���   	MusicLogo#��[ $��50��$��50��$��249,27,220,248q�� $	��525��$	��300��$��Bottom=� � RowDefinitions �� �� �� ��  � ColumnDefinitions �� �� .+��� .+��� $��30(�$��Source path��$��45��#��� ��$��Center=�$��Center=� �� Left$ 33��
 �� Top$ 20��z�T�  T� X$ 2Q� T� Y$ 2Q��� $ 33��$ 20��$��30(�$��Source path��$��30�����#2f3237$��Center=�$��Center=��� $��1��.+��� $��30(�$��Path to copy��$��45��#��� ��$��Center=�$��Center=�$ 33��$ 20��z�T� $ 2Q�$ 2Q��� $ 33��$ 20��$��30(�$��Path to copy��$��30�����#2f3237$��Center=�$��Center=��� $��2��.+��� $��20(�$��Sort your music by:��$��45��#��� ��$��Center=�$��Center=�$ 33��$ 20��z�T� $ 1Q�$ 1Q��� $ 33��$ 20��$��20(�$��Sort your music by:��$��30�����#2f3237$��Center=�$��Center=��� $��1�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ SelectedPath��$��30��$
��Left=�$��D:\Leva\Temp Music��$	��190��.���� $��10�� J� Opacity$ 0Q��� -     ��Name$  
BrowseSort��  
NiceButton#��[ $��50��$��30��$��Center=�$��Browse���� $��1��$��1��$ 
Horizontal=�.+��� -   $ 
PathToCopy��$��30��$
��Left=�$	��190��$��C:\Temp music to copy���� $��10��$ 0Q��� -   $  
BrowseCopy��#��[ $��50��$��30��$��Center=�$��Browse���� $��1��$��2��$ 
Horizontal=�$��Center=�$��Center=�.+��� -   ! ��Name$! GenreCheckBox������ $��Genre��
��������� $��50��$ 0Q��� -   $! YearCheckBox������ $
��Year��
��������� $��50��$ 0Q��� -   $! ArtistCheckBox������ $��Artist��
��������� -	   " ��Name$" ViewProgress��
���  ��# �� TextAlignment$# Center=�$��10(�$��2��$��
0,15,10,36q�$��3��� -
   $ �Name$$ SortProgress��$��
4,39,13,14q�$��3��% � Minimum$% 0Q�& J� RenderTransformOrigin$& 0.5,0.5&�$��2��' � Value' �� *MyVar+�� -   $  
ButtonToOk��#��[ $��2��$��OK��$��20��$��50��$��1��$��2��$��112,65,101,65q��� -   $  ButtonToCancel��#��[ $��2��$��Cancel��$��20��$��50��$��101,65,111,65q�$��2��