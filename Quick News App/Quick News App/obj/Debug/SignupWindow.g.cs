﻿#pragma checksum "..\..\SignupWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BC3097402B45C1CB894ACA8951939362213C8E5D2A96F09536254671A2EB54EB"
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


namespace Quick_News_App {
    
    
    /// <summary>
    /// SignupWindow
    /// </summary>
    public partial class SignupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomButton btn_Exit;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img_Logo;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder input_SignupUsername;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder input_SignupEmail;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder input_SignupPassword;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\SignupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Quick_News_App.Custom_User_Controls.CustomButton btn_Signup;
        
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
            System.Uri resourceLocater = new System.Uri("/Quick News App;component/signupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SignupWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 29 "..\..\SignupWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DragWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Exit = ((Quick_News_App.Custom_User_Controls.CustomButton)(target));
            return;
            case 3:
            this.img_Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.input_SignupUsername = ((Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder)(target));
            return;
            case 5:
            this.input_SignupEmail = ((Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder)(target));
            return;
            case 6:
            this.input_SignupPassword = ((Quick_News_App.Custom_User_Controls.CustomTextBoxWithPlaceholder)(target));
            return;
            case 7:
            this.btn_Signup = ((Quick_News_App.Custom_User_Controls.CustomButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

