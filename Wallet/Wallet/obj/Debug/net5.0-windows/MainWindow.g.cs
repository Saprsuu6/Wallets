﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BA58508454B98DDEFBE64C1A7CCC70D1A685B9FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Wallet.Classes;


namespace Wallet {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Name;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Surename;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Cards;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EmptyList;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NotExists;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Currency;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem UAH;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem USD;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem GBR;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem EUR;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem RUB;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Search;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardNumberSearch;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Pay;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Reason;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Money;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wallet;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\MainWindow.xaml"
            ((Wallet.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\MainWindow.xaml"
            ((Wallet.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Surename = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.PhoneNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 63 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cards = ((System.Windows.Controls.ListBox)(target));
            
            #line 72 "..\..\..\MainWindow.xaml"
            this.Cards.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cards_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EmptyList = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.NotExists = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            
            #line 86 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\MainWindow.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Currency = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.UAH = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 13:
            this.USD = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 14:
            this.GBR = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 15:
            this.EUR = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 16:
            this.RUB = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 17:
            this.Search = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 18:
            this.CardNumberSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\MainWindow.xaml"
            this.CardNumberSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CardNumberSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.Pay = ((System.Windows.Controls.Button)(target));
            
            #line 122 "..\..\..\MainWindow.xaml"
            this.Pay.Click += new System.Windows.RoutedEventHandler(this.Pay_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.Reason = ((System.Windows.Controls.TextBox)(target));
            
            #line 124 "..\..\..\MainWindow.xaml"
            this.Reason.GotFocus += new System.Windows.RoutedEventHandler(this.Reason_GotFocus);
            
            #line default
            #line hidden
            
            #line 124 "..\..\..\MainWindow.xaml"
            this.Reason.LostFocus += new System.Windows.RoutedEventHandler(this.Reason_LostFocus);
            
            #line default
            #line hidden
            
            #line 124 "..\..\..\MainWindow.xaml"
            this.Reason.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Reason_TextChanged);
            
            #line default
            #line hidden
            return;
            case 21:
            this.Money = ((System.Windows.Controls.TextBox)(target));
            
            #line 125 "..\..\..\MainWindow.xaml"
            this.Money.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Money_TextChanged);
            
            #line default
            #line hidden
            
            #line 126 "..\..\..\MainWindow.xaml"
            this.Money.GotFocus += new System.Windows.RoutedEventHandler(this.Reason_GotFocus);
            
            #line default
            #line hidden
            
            #line 126 "..\..\..\MainWindow.xaml"
            this.Money.LostFocus += new System.Windows.RoutedEventHandler(this.Reason_LostFocus);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 130 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 131 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

