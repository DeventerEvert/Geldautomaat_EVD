﻿#pragma checksum "..\..\..\..\Pages\addAccount.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16ACCBA1125516A235A8EC4F40A1733273DA1020"
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
    /// addAccount
    /// </summary>
    public partial class addAccount : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addUser;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addRekeningnummer;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addPincode;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addVoornaam;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addAchternaam;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addContact;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addAdres;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\Pages\addAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Geldautomaat_admin_EvD;component/pages/addaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\addAccount.xaml"
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
            this.addUser = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\Pages\addAccount.xaml"
            this.addUser.Click += new System.Windows.RoutedEventHandler(this.addUser_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addRekeningnummer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.addPincode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.addVoornaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.addAchternaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.addContact = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.addAdres = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 152 "..\..\..\..\Pages\addAccount.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
