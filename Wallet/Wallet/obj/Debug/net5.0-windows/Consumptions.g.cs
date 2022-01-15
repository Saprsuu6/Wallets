﻿#pragma checksum "..\..\..\Consumptions.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "198B74078365E342EFD50B196A64857991CD2AB7"
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
using Wallet;


namespace Wallet {
    
    
    /// <summary>
    /// Consumptions
    /// </summary>
    public partial class Consumptions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ConsumptionsList;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EmptyList;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NotFound;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Descending;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Ascending;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Search;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReasonSearch;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MoneySearch;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CurrencySearch;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateSearch;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateStart;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Consumptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateEnd;
        
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
            System.Uri resourceLocater = new System.Uri("/Wallet;component/consumptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Consumptions.xaml"
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
            this.ConsumptionsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.EmptyList = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.NotFound = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Descending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 60 "..\..\..\Consumptions.xaml"
            this.Descending.Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Ascending = ((System.Windows.Controls.RadioButton)(target));
            
            #line 63 "..\..\..\Consumptions.xaml"
            this.Ascending.Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Search = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 7:
            this.ReasonSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\Consumptions.xaml"
            this.ReasonSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ReasonSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MoneySearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\Consumptions.xaml"
            this.MoneySearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MoneySearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CurrencySearch = ((System.Windows.Controls.ComboBox)(target));
            
            #line 83 "..\..\..\Consumptions.xaml"
            this.CurrencySearch.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CurrencySearch_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DateSearch = ((System.Windows.Controls.DatePicker)(target));
            
            #line 94 "..\..\..\Consumptions.xaml"
            this.DateSearch.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateSearch_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DateStart = ((System.Windows.Controls.DatePicker)(target));
            
            #line 98 "..\..\..\Consumptions.xaml"
            this.DateStart.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DateEnd = ((System.Windows.Controls.DatePicker)(target));
            
            #line 99 "..\..\..\Consumptions.xaml"
            this.DateEnd.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 107 "..\..\..\Consumptions.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

