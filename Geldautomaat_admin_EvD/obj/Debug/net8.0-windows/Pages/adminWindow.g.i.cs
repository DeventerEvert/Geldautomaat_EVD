﻿#pragma checksum "..\..\..\..\Pages\adminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2AC5D1C7CDF2E9036C2A0CC07907FAFB7CD97849"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Geldautomaat_admin_EvD.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Geldautomaat_admin_EvD.Pages {
    
    
    /// <summary>
    /// adminWindow
    /// </summary>
    public partial class adminWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image bankLogo;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label adminLabel;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox rekeningListBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBoxBlocked;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox rekeningListBoxBlocked;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button klantBtn;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rekeningBtn;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Pages\adminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logOut;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Geldautomaat_admin_EvD;component/pages/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\adminWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bankLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.adminLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\..\Pages\adminWindow.xaml"
            this.searchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rekeningListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 67 "..\..\..\..\Pages\adminWindow.xaml"
            this.rekeningListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.rekeningListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.searchBoxBlocked = ((System.Windows.Controls.TextBox)(target));
            
            #line 92 "..\..\..\..\Pages\adminWindow.xaml"
            this.searchBoxBlocked.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBoxBlocked_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rekeningListBoxBlocked = ((System.Windows.Controls.ListBox)(target));
            
            #line 104 "..\..\..\..\Pages\adminWindow.xaml"
            this.rekeningListBoxBlocked.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.rekeningListBoxBlocked_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 122 "..\..\..\..\Pages\adminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addRekening_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 135 "..\..\..\..\Pages\adminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteRekening_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.klantBtn = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\..\Pages\adminWindow.xaml"
            this.klantBtn.Click += new System.Windows.RoutedEventHandler(this.klantBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.rekeningBtn = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\..\..\Pages\adminWindow.xaml"
            this.rekeningBtn.Click += new System.Windows.RoutedEventHandler(this.rekeningBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.logOut = ((System.Windows.Controls.Button)(target));
            
            #line 168 "..\..\..\..\Pages\adminWindow.xaml"
            this.logOut.Click += new System.Windows.RoutedEventHandler(this.logOut_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

