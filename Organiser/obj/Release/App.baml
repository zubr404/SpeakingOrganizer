   M S B A M L   `   `   `  ����   	Organiser    Organiser.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       �� 	Resources     BackgroundElement �� Color  BackgroundButton  BacgroundGridBack  BackgroundDataGrid  BackgroundRowStaticBrush  ForeGroundMy  FontFamilyMy % !ColumnHeaderForegroundStaticBrush  RowBackgroundSelectedBrush 	 ForegroundStaticBrush 
 ForegroundStaticBrush1  ForegroundSelectedBrush  ForegroundSelectedBrush1  ForegroundBrushWhite  BackgroundGray  BackLightGray  WhiteLight5  	BlueBrush  LinGradBrush �� 
StartPoint �� EndPoint � Color � Offset  ButtonStateNormal  ButtonStateMouseOver  ButtonStatePressed  ButtonMy �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Name   Transitions%  System.Windows.VisualTransition	   To   GeneratedDuration   States   System.Windows.VisualState   Name   
Storyboard �� 
TargetName �� TargetProperty g� Duration	 W� To ��Name J� Opacity  TimeUpDownTextBox  ListBoxStyle&   System.Windows.Media.TextOptions �� 	Resources  TextboxStyle  
WrapStyle13  -System.Windows.Media.Effects.DropShadowEffect   Opacity   	Direction  	WrapStyle  ButtonDisappearsStyle �� Triggers :� RoutedEvent �� KeyTime �� Value  W� From! g� AutoReverse  ScrollBarLineButtonStyle" � Points " ScrollBarLineButtonBottomStyle  ScrollBarPageButtonStyle   ScrollBarThumbStyle ! VerticalScrollBar# � RowDefinitions$ ]� DecreaseRepeatButton% ]� Thumb& ]� IncreaseRepeatButton " ColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader # ColumnHeaderStyle2 $ RowHeaderStyle1:  4System.Windows.Controls.Primitives.DataGridRowHeader % DataGridRowStyle1)	  #System.Windows.Controls.DataGridRow' P� Property( P� Value & DataGridCellStyle1*
  $System.Windows.Controls.DataGridCell ' ColumnElementStyle ( BorderStyle ) sbPanelLeftColapsed) O� Value* O� KeyTime * sbPanelLeftMax + sbPanelSetColapsed , sbPanelSetMax - sbColapsedTaskDetails . sbMaximizeTaskDetails / DropDownButtonStyle+ g� 	BeginTime	, �� To- � ColumnDefinitions. �� CornerRadius 0 ControlDarkColor/ J� RenderTransformOrigin0 �� Stretch(  "System.Windows.Controls.DatePicker 1 
CalendarMy1 �� Padding2 �Name3 ��Name:  4System.Windows.Controls.Primitives.DatePickerTextBox4  Name5 J� IsHitTestVisible6 �� RadiusY7 �� RadiusX8 �Name9 � AllowsTransparency: � 	StaysOpen; � PlacementTarget< �� ElementName 2 CurrentBackgroundColor 3 SelectedBackgroundColor 4 SelectedStrokeColor 5 ControlMediumColor 6 ControlBackMouseOverColor 7 ControlStrokeMouseOverColor 8 
GlyphColor 9 GlyphMouseOver : ForegroundOn ; ForegroundOff < BorderLightColor = BorderDarkColor:  4System.Windows.Controls.Primitives.CalendarDayButton > CalendarDayButtonStyle= R� KeyTime> R� Value  System.Windows.Visibility? ��Name@ F�Name7  1System.Windows.Controls.Primitives.CalendarButton ? CalendarButtonStyle @ PreviousButtonTemplateA � Cursor A NextButtonTemplate B HeaderButtonTemplate C CalendarItemStyle5  /System.Windows.Controls.Primitives.CalendarItemB � 	ResourcesC � 	Resources D Key E DisabledColorD �� TriggersE �� 
TargetNameF �� ValueG �� BindingH �� RelativeSourceI �� AncestorType&   System.Windows.Controls.CalendarJ ��NameK  NameL   CalendarItemStyle��%�G  &	        &	      &	 &     &	 ;     &	 P     &	 e     &	 v     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	     &	 &    &	 ;    &	 P    &	 e    &	 �    &	 �    &	     &	     7  7  &	 �    7  7  7   &	 �    7  7  &	 3    7   7  7  7  7  &	 �    7  &	 \    7  &	 �    7  &	 �    7  &	     7  &	 �    &	  �    7  &	! m    7  7  7   7  7  '�� �    7 ! &	" �    7  7  7  &	# �    7  7  &	$ c    7  7  7  &	%     7  &	& �    7  &	' x    &	( �    7  &	)     &	* o    &	+ �    &	, I    &	- �    &	. M    &	/ �    '  #    7  7  7 / 7   &	2 H'    &	3 ['    &	4 n'    &	5 }'    &	0 �'    &	6 �'    &	7 �'    &	8 �'    &	9 �'    &	: �'    &	; �'    &	< �'    &	= 	(    &	> (    &	?  1    &	@ w6    &	A '8    7 9 &	B �9    &	C H;    7  7 @ 7 B 7 A 7 E 7 E &	1 �B    7 ? 7 > 7 C �� $ White���� $ 	#FF616161���� $ 	#FF6A6A6A���� $ 	#FF444E5A���� $ 	#26FFFFFF���� $ Black��*�Segoe UI)��� $ 	#FFF1A85F���� $
 Gray���� $ 	#FF8AB6E6���� $ 	#FFC8DFF9���� $ 	#FFB6D9FF���� $
 Blue���� $ 	#FFDEDEDE���� $ 	#FF404040���� $ 	#FFC9C9C9���� $ 	#0CFFFFFF���� $ 	#FF7AB2F0���� $ 0.5,0&�$ 0.5,1&�.��� $ 	#05FFFFFF��$	 0.0Q�� $ 	#20FFFFFF��$	 0.5Q�� $ 	#05FFFFFF��$	 1.0Q���	#00FFFFFF����	White����Red���� " ��.���  � �� Z� ��  � ��
 �   ���  � ��$ 0q���  � ��8   ��  � ��8  ��  � ��$ 11(���  � ��$ Light"���  �@J�SnapsToDevicePixels .  ��  � �� �� "	 ��.R��� $
 RootElement��#��z��#��z��#��z��   $ CommonStates��   $ Pressed��$ 0:0:0.1D�  $ 	MouseOver��$ 0:0:0.1D�  $ Normal��$ 0:0:0.1D�.   $ Normal��  $ 	MouseOver��. �� .��W� $ BackGrid��$ Opacity�$ 0:0:0.1D�$
 0.08X�  $ Pressed��. �� .��W� $ BackGrid��$ Opacity�$ 0:0:0.1D�$
 0.15X�._�� .+��� $ BackGrid��
���   �$ 0Q��� #��z��#��z��$��0q��� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��8   ��  � ��$ Light"���  � ��8  ��  � ��8  ��  � ��$ 0q���  �@J�SnapsToDevicePixels . �� " ��.���  � �� Z� ��  � ��8   ��  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 13(���  �@ TextFormattingMode$ Ideal=���  � ��$	 0.1q���  � ��
 ����� ���� $ White��(��       *$"SystemColors.HighlightTextBrushKey+)�� $ 	#3FFFFFFF��(��       * SystemColors.HighlightBrushKey+)�� $ 	#3FFFFFFF��(��       *SystemColors.ControlBrushKey+)�� " ��.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 0q���  � ��8  ��  �@��
CaretBrush8  �� " �.���  � ��8   ��  � ��$ 	10,10,0,0q���  � ��$	 150����  �@J�Effect   $	 0.3Q�$	 311Q��� " �.���  � ��8   ��  � ��$ 	10,10,0,0q���  � ��$	 150���� " ��.���  � ��$ 24����  � ��$ 42����  � �� �	#FFA8A8A8��  � ��8   ��  � ��$ Light"���  � ��$ 11(���  � ��$ 0q���  � ��$ 1q���  � �� �	#00B4B4B4��  � ��$ Center=���  � ��$ Center=���  �@�UseLayoutRounding . ��  � {� .  :� $ Label.MouseEnter��[��� .���� .���� $1 +(Label.BorderBrush).(SolidColorBrush.Color)�.g��� $ 0:0:1��$ 	#FFB4B4B4��:� $ Label.MouseLeave��[��� .���� .���� $1 +(Label.BorderBrush).(SolidColorBrush.Color)�.g��� $ 0:0:1��$ 	#00B4B4B4��:� $ Label.MouseLeftButtonDown��[��� .���� .��W� $ Opacity�$  1X�$ 0X�! . $ 0:0:2D��� " ��.���  � |� .  ��  � �� �� "	 ��.R��� $��18��.+�� 8��  '" �   ��- ��� ��� ��� @T� ��- �� " ��.���  � |� .  ��  � �� �� "	 ��.R��� $��18��.+�� 8��  '" �   ��- ��- @T� ��� ��� ��- �� " ��.���  � �� .  ��  � |� .  ��  � �� �� "	 ��.R��� 
������ �� " n�.���  � �� .  ��  � |� .  ��  � ��$ 1,0,1,0q���  � �� �� "	 n�.R��� 8��  $��2q��� "	 ��.R�� # �� $��18���� $��* ��� $��18��.+��� $��0��$��18��8��  $��ScrollBar.LineUpCommand��]� $��
PART_Track��$��1����. $ �� $��ScrollBar.PageUpCommand��8�� % n� 8�� & �� $��ScrollBar.PageDownCommand��8�� �� $��3��$��18��8�� $��ScrollBar.LineDownCommand���� " ��.���  � ��8   �� "  .���  � ��$
 Auto����  � ��8   ��  � ��8  ��  � ��$
 Left=���  � ��$ 13(���  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 5,2.5,5,2.5q��� "  .���  � ��$
 Auto����  � ��
 ���� ��  � ��8   ��  � ��$ Center=���  � ��$ 13(���  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 5,2.5,0,2.5q��� "  .���  � ��$
 Auto����  � ��8   ��  � ��8  ��  � ��$ 13(���  � ��8  ��  � ��$ 
ExtraLight"���  � ��$ 10,5,0,5q��� " 	 .���  � �� Z� ��  � ��$ 13(���  � ��8   ��  � ��$ 
ExtraLight"� P� ' �@J�IsMouseOver( . �� " 
 .���  � ��
 ���� ��  � ��
 �   ���  � ��8   ��  � ��$
 0.01q� P� ' �@J�IsMouseOver( . . ���  � ��
 �����P� ' �@
 
IsSelected( . . ���  � ��$ 1q��� " ��.���  � ��$ 20q���  � ��$
 Wrap=��� " ��.���  � ��8   ��  � ��
 �������  � ��$
 0.55q��� .��U� $ Width�.\��� $	) 260Q�$* 0:0:0���� $) 60Q�$* 0:0:0.1���� $) 45Q�$* 0:0:1���� .��U� $ Width�.\��� $) 45Q�$* 0:0:0���� $	) 245Q�$* 0:0:0.1���� $	) 260Q�$* 0:0:1���� .��U� $ Width�.\��� $	) 360Q�$* 0:0:0���� $) 15Q�$* 0:0:0.1���� $) 0Q�$* 0:0:1���� .��U� $ Width�.\��� $) 0Q�$* 0:0:0���� $	) 335Q�$* 0:0:0.1���� $	) 360Q�$* 0:0:1���� .��W� $	  700X�$ 0X�$ 0:0:1D�$ BorderTaskDetails��$ Width�W� $	  700X�$ 0X�$ 0:0:1D�$ BorderTaskDetails��$ Height��� .��W� $  0X�$	 700X�$ 0:0:1D�$ BorderTaskDetails��$ Width�W� $  0X�$	 700X�$ 0:0:1D�$ BorderTaskDetails��$ Height��� " ��.���  � �� �� "	 ��.R��    CommonStates��   $ 0D�  $ 0:0:0.1D�$ 	MouseOver��  $ 0:0:0.1D�$ Pressed��.   
Normal��  	MouseOver��. �� .���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 0��$ 	#F2FFFFFF���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)�.g��� $ 0��$ 	#CCFFFFFF���� $ 0D�$, 	#FF448DCAX�$1 +(Border.Background).(SolidColorBrush.Color)�$ 
Background���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)�.g��� $ 0��$ 	#7FFFFFFF��  Pressed��. �� .���� $+ 0X�$ 00:00:00.001D�$ 
Background��$1 +(Border.Background).(SolidColorBrush.Color)�.g��� $ 0��$ 	#FF448DCA��U� $+ 0X�$ 00:00:00.001D�$ (UIElement.Opacity)�$ 	Highlight��.\��� $* 0��$) 1Q��� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $ 0��$ 	#F4FFFFFF���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $ 0��$ 	#EAFFFFFF���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)�.g��� $ 0��$ 	#C6FFFFFF���� $+ 0X�$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)�.g��� $ 0��$ 	#6BFFFFFF��  Disabled��.+�� ���	#11FFFFFF$��LeftToRight=�$��Center=�$��18��$��0q�$��Center=�$��19��- �� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* �# �� $	��23* ��� $	��19* ��� $	��19* ��� $	��19* �.+��� $
 	Highlight��$��1q�$��4��$. 0,0,1,1��$��-1q�$ 1Q�$��0��$��4������ $ Black���� $
 
Background�����	#FFFFFFFF$��1q�$��4��$. .5��$��0,-1,0,0q�$ 1Q�$��1��$��3������ # � 0 �� $
 BackgroundGradient��
�������$��1q�$��4��$. .5��$��0,1,0,0q�$ 1Q�$��1��$��3������ $
 .7,1&�$
 .7,0&�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#F9FFFFFF��$ 0.375Q�� $ 	#E5FFFFFF��$ 0.625Q�� $ 	#C6FFFFFF��$ 1Q��� $��4��$��1��$��1������ $
 Gray������ $ White��F� 
��� � �$��1��$��0��$��3��$��4��$��Center=�$��Center=�$/ 0.5,0.5&�$��4,3,4,3q�$
0 Fill=�����p�[� 4ZX�k� @Q�F� 4ZX�k� @џF� {2� �u� {2� �u�  )� �*� &"@pg� �*� &"@� � ��*�"@��� yh���#@h/��@�#@,� j����"@Sn#� l�H@�/"@��� ����k�!@�[� 4ZX�k� @p�� 4ZX�k� @Q�L4ZX�k� @Q�L�:��"@QH � �:��"@�H � ��� �U+� L�� ����E0@�=� ��� �=� ��	�=� �0ݒ� 5N=� ����� �� �b� �� ��� Ӧ� ��� �u"9��Up0@�� "9��Up0@S�n� "9��Up0@�$� Ӹ� ��� H~� �� {�� �\�� �� ��� [�� �� [�� �y�[�� ���I� ��� Ӭ�J"� sc,� ~T�~O0@c,� Ӷ�� c,� @�� �P� � � /�� ��� �� 	A� $��4�����	#FFFFFFFF$��Center=�$��3��$��0��$��Center=�$��3���� $
 DisabledVisual�����	#B2FFFFFF$��1q�$��4��$. 	0,0,.5,.5��$ 0Q�$��0��$��4���� "  .���  � ��8   ��  �@ IsTodayHighlighted . ��  �@ SelectedDateFormat$ Short=���  � ��$ 1q���  � ��$	 0.5q���  � ��$ Stretch=���  � ��8  ��  � ��$ Light"���  �@ CalendarStyle# � 1 ��  � �� �� "	  .R��� #��z��#1 z������ $ White������ $ Transparent��   CommonStates��.   
Normal��  Disabled��. �� .��W� $ 0D�$ 1X�$ Opacity�$ PART_DisabledVisual��._�� $2 	PART_Root��#��z��#��z��- �� $��* ��� $
��Auto �.+��� $3 PART_Button��$��1��#��z��|�.  $
��Left=�$��3,0,3,0q�$��0��8�� $	��Top=�  $4 PART_TextBox��$��0��8�� #��z��#|�z|�$��Stretch=�$��0��$��Stretch=�� $2 PART_DisabledVisual��$��2��$��0��5 .  $ 0Q�$��0��- �� $��* ��� $
��Auto �.+��� $��0�����	#A5FFFFFF$6 1��$��0��$7 1���� $��1�����	#A5FFFFFF$��18��$��3,0,3,0q�$6 1��$��0��$7 1��$��19��� $8 
PART_Popup��9 . $��Bottom=�: .  ; �� $< PART_TextBox����	#265B7BB2����	#265B7BB2����	Black����	#FF7381F9����	#FF211AA9���� ��	Black����Gray����	Black����	Black����	#FFB9B9B9����	#FFCCCCCC����	#FF444444���� "  .���  � ��$ 35����  � ��$ 35����  � ��$ 11(���  � ��$ Center=���  � ��$ Center=���  � �� �� "	  .R��    $ CommonStates��   $ 0:0:0.1D�.   $ Normal��  $ 	MouseOver��. �� .��W� $ HighlightBackground��$ Opacity�$	 0.5X�$ 0D�  $ Pressed��. �� .��W� $ HighlightBackground��$ Opacity�$	 0.5X�$ 0D�  $ Disabled��. �� .��W� $ HighlightBackground��$ Opacity�$ 0X�$ 0D�W� $ 
NormalText��$ Opacity�$	 .35X�$ 0D�  $ SelectionStates��   $ 0D�.   $ 
Unselected��  $ Selected��. �� .��W� $ SelectedBackground��$ Opacity�$	 .75X�$ 0D�  $ CalendarButtonFocusStates��   $ 0D�.   $ CalendarButtonFocused��. �� .��T� $ DayButtonFocusVisual��$ 
Visibility�$ 0D�..�i� $= 0��>  Visible=�  $ CalendarButtonUnfocused��. �� .��T� $ DayButtonFocusVisual��$ 
Visibility�$ 0D�..�i� $= 0��>  	Collapsed=�  $ ActiveStates��   $ 0D�.   $ Active��  $ Inactive��. �� .���� $ 0D�$ 
NormalText��$6 0(TextElement.Foreground).(SolidColorBrush.Color)�#, � ;   $ 	DayStates��   $ 0D�.   $ 
RegularDay��  $ Today��. �� .��W� $ TodayBackground��$ Opacity�$ 1X�$ 0D��� $ 0D�$ 
NormalText��$6 0(TextElement.Foreground).(SolidColorBrush.Color)�$	, RedX�  $ BlackoutDayStates��   $ 0D�.   $ 	NormalDay��  $ BlackoutDay��. �� .��W� $ 0D�$ Blackout��$ Opacity�$ .2X�.+��� $ TodayBackground��$7 1��$6 1��$ 0Q����� # � 2 �� $ SelectedBackground��$7 1��$6 1��$ 0Q����� # � 3 ���� # � 4 �� #��z��#��z��#��z���� $ HighlightBackground��$7 1��$6 1��$ 0Q����� # � 6 ���� # � 7 �� $? 
NormalText��#��z��#��z��$��5,1,5,1q����� # � : F� $@ Blackout��$ 0Q�$��3q�$��Stretch=�$��Stretch=�$/ 0.5,0.5&����	#FF000000$
0 Fill=�}�����5 �Z @�J� �Q2� �J� �̉� iV� �A�� �J� �W�� �J� ѷ�� #�� �>8� 7T�K�� 7T�� � ��� ћ�� 7T����G @7T��� �D� 	�� $ DayButtonFocusVisual��$y�	Collapsed=�5 .  $7 1��$6 1������ # � 3 �� "  .���  � ��$ 50����  � ��$ 50����  � ��$ 13(���  � ��$ Light"���  � ��$ Center=���  � ��$ Center=���  � �� �� "	  .R��    $ CommonStates��   $ 0:0:0.1D�.   $ Normal��  $ 	MouseOver��. �� .��W� $ 
Background��$ Opacity�$ .5X�$ 0D�  $ Pressed��. �� .��W� $ 
Background��$ Opacity�$ .5X�$ 0D�  $ SelectionStates��   $ 0D�.   $ 
Unselected��  $ Selected��. �� .��W� $ SelectedBackground��$ Opacity�$	 .75X�$ 0D�  $ ActiveStates��   $ 0D�.   $ Active��  $ Inactive��. �� .���� $ 0D�$ 
NormalText��$M G(TextElement.Foreground).                       (SolidColorBrush.Color)�$, 	#FF777777X�  $ CalendarButtonFocusStates��   $ 0D�.   $ CalendarButtonFocused��. �� .��T� $ 0D�$ CalendarButtonFocusVisual��$ 
Visibility�..�i� $= 0��>  Visible=�  $ CalendarButtonUnfocused��.+��� $ SelectedBackground��$7 1��$6 1��$ 0Q����� # � 2 �� $ 
Background��$7 1��$6 1��$ 0Q����� # � 3 �� $? 
NormalText��#��z��#��z��$��1,0,1,1q����� # � : �� $ CalendarButtonFocusVisual��$y�	Collapsed=�5 .  $7 1��$6 1������ # � 4 ��  � �� �� # � 5 �� "	 ��.R�� $
A Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$
 path��$* $(Shape.Fill).(SolidColorBrush.Color)�#, � 9   Disabled��. �� .��W� $ 0D�$ .5X�$" (Shape.Fill).(Brush.Opacity)�$
 path��.+�� 
������ .+�F� $
@ path��$��	14,-6,0,0q�$
0 Fill=�$
��Left=�$��10��$��Center=�$��6��"�����5���Ѱ�5h�W��<�h�	���� # � 8 �� "	 ��.R�� $
A Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�8,   $* $(Shape.Fill).(SolidColorBrush.Color)�$
 path��  Disabled��. �� .��W� $ 0D�$ .5X�$" (Shape.Fill).(Brush.Opacity)�$
 path��.+�� 
������ .+�F� $
@ path��"����xT��!��xT���S�h4 	$��Right=�$��10��$��	0,-6,14,0q�$
0 Fill=�$��Center=�$��6������ # � 8 �� "	 ��.R�� $
A Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�#, � 9 $6 0(TextElement.Foreground).(SolidColorBrush.Color)�$ buttonContent��  Disabled��. �� .��W� $ 0D�$ .5X�$ Opacity�$ buttonContent��.+��� $? buttonContent��$��1,4,1,9q�#��z��#��z��#���  $��17(�#��z��#��z���� "  .���  � ��$ 0,3,0,3q���  � �� �� "	  B ���� (��       **(CalendarItem.DayTitleTemplateResourceKey+).R��� 
���   �$��Light"�$��15(�8��  $��0,6,0,6q�$��Center=�$��Center=����� .R�� $2 	PART_Root��C ���� DisabledColorD $ 	#A5FFFFFF��   CommonStates��.   
Normal��  Disabled��. �� .��W� $ 0D�$ 1X�$ Opacity�$ PART_DisabledVisual��.+��� #��z��#��z��#��z��$. 1��._��� ���	#FFFFFFFF$	��0.1q�$. 1��._�� C ��- �� $
��Auto ��� $
��Auto ��� $
��Auto �# �� $
��Auto ��� $��* �.+��� $3 PART_PreviousButton��8�� |�.  $
��Left=�$��0��$��0��$��20��$��28���� $3 PART_HeaderButton��$��Light"�|�.  $��13(�$��Center=�$��Center=�$��1��$��0��8�� �� $3 PART_NextButton��|�.  $��Right=�$��2��$��0��8�� $��20��$��28��� $2 PART_MonthView��$y�Visible=�$��3��$��1��$��6,-1,6,6q�$��Center=�- �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �# �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �� $2 PART_YearView��$y�Hidden=�$��3��$��1��$��Center=�$��6,-3,7,6q�- �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �# �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $ PART_DisabledVisual��8�� $ 0Q�$6 2��$7 2��$
0 Fill=�8�� $��1��$y�	Collapsed=�D P� ' � {�( .  . ��� $E PART_DisabledVisual�� � y�$ Visible=��� $
F Year��G �� *DisplayMode+H �� *FindAncestor+"I  .a��� $E PART_MonthView�� � y�$ Hidden=��� $E PART_YearView�� � y�$ Visible=��� $F Decade��G �� *DisplayMode+H �� *FindAncestor+"I  .a��� $E PART_MonthView�� � y�$ Hidden=��� $E PART_YearView�� � y�$ Visible=��� "  .���  �@ CalendarButtonStyle8   ��  �@ CalendarDayButtonStyle8  ��  �@ CalendarItemStyle8  ��  � �� �	#FF333333��  � �� Z� ��  � �� �� $	 0,1&�$	 0,0&�.��� # � < $ 0Q�� # � = $ 1Q���  � ��$	 0.1q���  � �� �� "	  .R��� $J 	PART_Root��$��Center=�.+�  $K PART_CalendarItem��#��z��#��z��#��z��#��zL 