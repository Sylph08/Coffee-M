﻿#pragma checksum "..\..\..\UserControlCoffee\TableUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A85340EAAAB4BB857C7BD8870434901A32D16449"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CoffeeManagement.UserControlCoffee;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using System.Windows.Interactivity;
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


namespace CoffeeManagement.UserControlCoffee {
    
    
    /// <summary>
    /// TableUC
    /// </summary>
    public partial class TableUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\UserControlCoffee\TableUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CoffeeManagement.UserControlCoffee.TableUC tableUC;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\UserControlCoffee\TableUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchListCB;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\UserControlCoffee\TableUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextbox;
        
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
            System.Uri resourceLocater = new System.Uri("/CoffeeManagement;component/usercontrolcoffee/tableuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlCoffee\TableUC.xaml"
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
            this.tableUC = ((CoffeeManagement.UserControlCoffee.TableUC)(target));
            return;
            case 2:
            
            #line 52 "..\..\..\UserControlCoffee\TableUC.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchListCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.searchTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

