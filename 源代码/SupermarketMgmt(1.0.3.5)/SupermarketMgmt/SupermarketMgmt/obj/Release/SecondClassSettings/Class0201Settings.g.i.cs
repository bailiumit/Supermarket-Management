﻿#pragma checksum "..\..\..\SecondClassSettings\Class0201Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8D060B3953E92B07FBA01FE699AF4151"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using System.Windows.Forms.Integration;
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


namespace GUI.SecondClassSettings {
    
    
    /// <summary>
    /// Class0201Settings
    /// </summary>
    public partial class Class0201Settings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemName_TextBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Code_TextBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Condition_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BuyingPrice_TextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SellingPrice_TextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Remark_TextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nationality_TextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/SupermarketMgmt;component/secondclasssettings/class0201settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
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
            this.ItemName_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Code_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Condition_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\SecondClassSettings\Class0201Settings.xaml"
            this.Condition_ComboBox.Loaded += new System.Windows.RoutedEventHandler(this.Condition_ComboBox_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BuyingPrice_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SellingPrice_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Remark_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Nationality_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

