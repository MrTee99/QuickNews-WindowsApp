﻿#pragma checksum "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F1BBF76F837109445D331AA981FAFB06F15D839B948CBC7C5AFCA6431179920D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quick_News_App.Custom_User_Controls;
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


namespace Quick_News_App.Custom_User_Controls {
    
    
    /// <summary>
    /// ThemeToggleSwitch
    /// </summary>
    public partial class ThemeToggleSwitch : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Switch;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Back;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Dot;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel txt_DarkMode;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel txt_LightMode;
        
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
            System.Uri resourceLocater = new System.Uri("/Quick News;component/custom%20user%20controls/themetoggleswitch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
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
            this.Switch = ((System.Windows.Controls.Grid)(target));
            
            #line 10 "..\..\..\Custom User Controls\ThemeToggleSwitch.xaml"
            this.Switch.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Switch_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Back = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.Dot = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.txt_DarkMode = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.txt_LightMode = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

