﻿#pragma checksum "..\..\ProjectProperties.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6F96A2EBDA5FB80D56CB4753C6DC4AB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using UILayer;


namespace UILayer {
    
    
    /// <summary>
    /// ProjectProperties
    /// </summary>
    public partial class ProjectProperties : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        /// <summary>
        /// textBoxProjectName Name Field
        /// </summary>
        
        #line 28 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox textBoxProjectName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DeleteProject;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Chapters;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox FileList;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ImportFile;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Author;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateOfCreating;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateOfPublishing;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Words;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\ProjectProperties.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Symbols;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UILayer;component/projectproperties.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProjectProperties.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\ProjectProperties.xaml"
            ((UILayer.ProjectProperties)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxProjectName = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\ProjectProperties.xaml"
            this.textBoxProjectName.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxProjectName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteProject = ((System.Windows.Controls.Image)(target));
            
            #line 30 "..\..\ProjectProperties.xaml"
            this.DeleteProject.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.DeleteProject_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Chapters = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.FileList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.ImportFile = ((System.Windows.Controls.TextBlock)(target));
            
            #line 56 "..\..\ProjectProperties.xaml"
            this.ImportFile.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ImportFile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.label = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Author = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.DateOfCreating = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.DateOfPublishing = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.Words = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.Symbols = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 44 "..\..\ProjectProperties.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.textBoxFileName_LostFocus);
            
            #line default
            #line hidden
            
            #line 44 "..\..\ProjectProperties.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.textBoxFileName_KeyUp);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 46 "..\..\ProjectProperties.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.DelFile_MouseUp);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
