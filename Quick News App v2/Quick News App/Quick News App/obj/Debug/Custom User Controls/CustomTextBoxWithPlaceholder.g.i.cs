﻿#pragma checksum "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FBEB679449A7A0692E1BB41B8BE0EB88122EFC1A7D08CB556CD9C83B577C24E2"
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
    /// CustomTextBoxWithPlaceholder
    /// </summary>
    public partial class CustomTextBoxWithPlaceholder : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder _this;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PlaceholderText;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Input;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordInput;
        
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
            System.Uri resourceLocater = new System.Uri("/Quick News;component/custom%20user%20controls/customtextboxwithplaceholder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
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
            this._this = ((Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder)(target));
            return;
            case 2:
            this.PlaceholderText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Input = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PasswordInput = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 161 "..\..\..\Custom User Controls\CustomTextBoxWithPlaceholder.xaml"
            this.PasswordInput.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordInput_PasswordChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
