﻿#pragma checksum "..\..\..\Add\CrewElement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "ADCC8DD9E3FF2FABA252BD085D1A277FC757D557E305A36F4C1959D936098803"
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
using WpfApp1.Add;


namespace WpfApp1.Add {
    
    
    /// <summary>
    /// CrewElement
    /// </summary>
    public partial class CrewElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox crewID;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox crewPlaneID;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox crewFIO;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox crewPosition;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox crewBirthYear;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox crewExperience;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddImageButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddCrewMemberButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridCrew;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Add\CrewElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image crewPhoto;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/add/crewelement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Add\CrewElement.xaml"
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
            
            #line 11 "..\..\..\Add\CrewElement.xaml"
            ((WpfApp1.Add.CrewElement)(target)).Loaded += new System.Windows.RoutedEventHandler(this.CrewElement_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.crewID = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\Add\CrewElement.xaml"
            this.crewID.LostFocus += new System.Windows.RoutedEventHandler(this.crewID_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.crewPlaneID = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\Add\CrewElement.xaml"
            this.crewPlaneID.LostFocus += new System.Windows.RoutedEventHandler(this.crewPlaneID_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.crewFIO = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Add\CrewElement.xaml"
            this.crewFIO.LostFocus += new System.Windows.RoutedEventHandler(this.crewFIO_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.crewPosition = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.crewBirthYear = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\..\Add\CrewElement.xaml"
            this.crewBirthYear.LostFocus += new System.Windows.RoutedEventHandler(this.crewBirthYear_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.crewExperience = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Add\CrewElement.xaml"
            this.crewExperience.LostFocus += new System.Windows.RoutedEventHandler(this.crewExperience_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddImageButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Add\CrewElement.xaml"
            this.AddImageButton.Click += new System.Windows.RoutedEventHandler(this.AddImageButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AddCrewMemberButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Add\CrewElement.xaml"
            this.AddCrewMemberButton.Click += new System.Windows.RoutedEventHandler(this.AddCrewMemberButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.DataGridCrew = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.crewPhoto = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

