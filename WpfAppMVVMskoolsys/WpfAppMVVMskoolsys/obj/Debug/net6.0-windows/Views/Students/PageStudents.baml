   M S B A M L   `   `   `  ����M  IWpfAppMVVMskoolsys, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WpfAppMVVMskoolsys.Views.Students!WpfAppMVVMskoolsys.Views.Students  5      _4clr-namespace:WpfAppMVVMskoolsys.ViewModels.Students&WpfAppMVVMskoolsys.ViewModels.Students  5      4    .WpfAppMVVMskoolsys.Views.Students.PageStudents   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:WpfAppMVVMskoolsys.Views.Students     5      Cvm4clr-namespace:WpfAppMVVMskoolsys.ViewModels.Students     5      -   5          N� Title$  PageStudents��5
       � DataContext 5      ;  5WpfAppMVVMskoolsys.ViewModels.Students.PageStudentsVM  5   
   .��5   
   ]� .+�5   
   ��    BorderTitle#��[  6   $	��Top=�66   ._�5      ]� .+�5      ��   TextBlockTitle#��[ 6   $��Students��6D   $
��Left=�6T   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��Right=�5      .+�5      ��   ButtonTemplate#��[ 6   $��Refresh��6E   �� 5      #��[ 6   $��Delete��6E   ��6V   �� *DeleteStudentCommand+��5   V   ��  �� ElementName$ DataGridStudents���� 5      #��[ 6   $	��Add��6E   ��6S   �� *ShowCreateWindowCommand+5      5      5      �� 5    
     BorderContent#��[ 6   ._�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridStudents��5&      
������ $��0q�5!   1      CanUserAddRows$ False��5"         
IsReadOnly$
 True��5$         AutoGenerateColumns$ False��5%      ��5#      �� *_studentRecord.StudentRecords+   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5)      $	 	Full Name��6)   $
 * 6Y    6<   �� *
FullName+6Y     5*      $	 Phone Number��6)   $
 * 6_    6?   �� *PhoneNumber+6_     5+      $	 Birthday��6)   $
 * 6X    6;   �� *
Birthday+6X     5,      $	 Mothers Name��6)   $
 * 6_    6?   �� *MothersName+6_     5-      $	 Fathers Name��6)   $
 * 6_    6?   �� *FathersName+6_   5/      50      51      52      