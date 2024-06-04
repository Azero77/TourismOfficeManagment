﻿#pragma checksum "..\..\..\..\Views\ClientListView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D178011C7E9A4AE4DDBDBB71BD35245D73EFDA97"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LoadingSpinnerControl;
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
using TourismOfficeApplication.Converters;
using TourismOfficeApplication.Views;


namespace TourismOfficeApplication.Views {
    
    
    /// <summary>
    /// ClientListView
    /// </summary>
    public partial class ClientListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Views\ClientListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridContainer;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\ClientListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxSearchCategory;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Views\ClientListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchQueryTextBox;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\Views\ClientListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LoadingSpinnerControl.LoadingSpinner LoadingSpinner;
        
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
            System.Uri resourceLocater = new System.Uri("/TourismOfficeApplication;component/views/clientlistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ClientListView.xaml"
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
            this.GridContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ComboBoxSearchCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.SearchQueryTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 99 "..\..\..\..\Views\ClientListView.xaml"
            ((System.Windows.Controls.DataGrid)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.DataGrid_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LoadingSpinner = ((LoadingSpinnerControl.LoadingSpinner)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

