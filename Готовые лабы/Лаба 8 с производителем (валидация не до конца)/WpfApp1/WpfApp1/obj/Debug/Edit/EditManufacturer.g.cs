﻿#pragma checksum "..\..\..\Edit\EditManufacturer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9E71FC44531609FB303518B2DE4600797C735D93AC0C8A03A5CD2A3DDA7C3EA9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1.Edit;


namespace WpfApp1.Edit {
    
    
    /// <summary>
    /// EditManufacturer
    /// </summary>
    public partial class EditManufacturer : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Edit\EditManufacturer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox manufacturerID;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Edit\EditManufacturer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox manufacturerParameter;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Edit\EditManufacturer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox manufacturerNewParameter;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Edit\EditManufacturer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ElementToEditButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Edit\EditManufacturer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridManufacturer;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/edit/editmanufacturer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Edit\EditManufacturer.xaml"
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
            this.manufacturerID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.manufacturerParameter = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.manufacturerNewParameter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ElementToEditButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Edit\EditManufacturer.xaml"
            this.ElementToEditButton.Click += new System.Windows.RoutedEventHandler(this.ElementToEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGridManufacturer = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

