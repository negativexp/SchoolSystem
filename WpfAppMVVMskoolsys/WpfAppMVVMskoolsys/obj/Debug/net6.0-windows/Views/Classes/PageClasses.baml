   M S B A M L   `   `   `  ����M  IWpfAppMVVMskoolsys, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WpfAppMVVMskoolsys.Views.Classes WpfAppMVVMskoolsys.Views.Classes  5      ]3clr-namespace:WpfAppMVVMskoolsys.ViewModels.Classes%WpfAppMVVMskoolsys.ViewModels.Classes  5      2    ,WpfAppMVVMskoolsys.Views.Classes.PageClasses   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:WpfAppMVVMskoolsys.Views.Classes     5      Bvm3clr-namespace:WpfAppMVVMskoolsys.ViewModels.Classes     5      -   5          N� Title$  PageClasses��5
       � DataContext 5      9  3WpfAppMVVMskoolsys.ViewModels.Classes.PageClassesVM  5   
   .��5      ]� .+�5   
   ��    BorderTitle#��[  6   $	��Top=�66   ._�5      ]� .+�5      ��   TextBlockTitle#��[ 6   $��Classes��6D   $
��Left=�6S   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��Right=�5      .+�5      ��   ButtonTemplate#��[ 6   $��Refresh��6E   ��6W   �� *RefreshCommand+�� 5      #��[ 6   $��Delete��6E   ��6V   �� *DeleteClassCommand+��5   V   ��  �� ElementName$ DataGridClasses���� 5      #��[ 6   $	��Add��6E   ��6S   �� *ShowCreateWindowCommand+5      5      5      �� 5    
     BorderContent#��[ 6   ._�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridClasses��5&      
������ $��0q�5!   1      CanUserAddRows$ False��5#         
IsReadOnly$
 True��5$         AutoGenerateColumns$ False��5%      ��5"      �� *_classRecord.ClassRecords+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5)      $	 
Class Name��6)   $
 * 6[    6=   �� *	ClassName+6[     5*      $	 Grade��6)   $
 * 6R    68   �� *Grade+6R     5+      $	 Root Teacher��6)   $
 * 6_    6?   �� *RootTeacher+6_     5,      $	 Amount of Students��6)   $
 * 6h    6E   �� *Students.Count+6h   5.      5/      50      51      