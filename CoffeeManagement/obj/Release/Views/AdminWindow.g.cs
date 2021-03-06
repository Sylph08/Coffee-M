#pragma checksum "..\..\..\Views\AdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F3C21BEE8E13A8E690455B2DFE032CBAA40007AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CoffeeManagement.Views;
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


namespace CoffeeManagement.Views {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CoffeeManagement.Views.AdminWindow adminWindow;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProductCB;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TableCB;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CustomerCB;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EmployeeCB;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BillCB;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ReportCB;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridRow1;
        
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
            System.Uri resourceLocater = new System.Uri("/CoffeeManagement;component/views/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AdminWindow.xaml"
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
            this.adminWindow = ((CoffeeManagement.Views.AdminWindow)(target));
            return;
            case 2:
            this.ProductCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\Views\AdminWindow.xaml"
            this.ProductCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProductCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TableCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\Views\AdminWindow.xaml"
            this.TableCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TableCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CustomerCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 71 "..\..\..\Views\AdminWindow.xaml"
            this.CustomerCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CustomerCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EmployeeCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\..\Views\AdminWindow.xaml"
            this.EmployeeCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EmployeeCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BillCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 90 "..\..\..\Views\AdminWindow.xaml"
            this.BillCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BillCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ReportCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 99 "..\..\..\Views\AdminWindow.xaml"
            this.ReportCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ReportCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GridRow1 = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

