﻿#pragma checksum "..\..\RedactingBook.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95353A327AA0FD578460385B502B87CDE33C292C9A71C73C3F9089CDE90CF07F"
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


namespace OOP_Lab4_5 {
    
    
    /// <summary>
    /// RedactingBook
    /// </summary>
    public partial class RedactingBook : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid addingGrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookAuthor;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox genre;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid durationGrid;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox in_stock;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock minutes;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rating;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addPhotoButton;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image preview;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addFilmButton;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\RedactingBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/OOP_Lab4-5;component/redactingbook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RedactingBook.xaml"
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
            this.addingGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.bookName = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\RedactingBook.xaml"
            this.bookName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox1_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bookAuthor = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\RedactingBook.xaml"
            this.bookAuthor.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox2_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.genre = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\RedactingBook.xaml"
            this.genre.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox3_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.durationGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.in_stock = ((System.Windows.Controls.TextBox)(target));
            
            #line 97 "..\..\RedactingBook.xaml"
            this.in_stock.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox4_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.minutes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.rating = ((System.Windows.Controls.TextBox)(target));
            
            #line 114 "..\..\RedactingBook.xaml"
            this.rating.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox5_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.addPhotoButton = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\RedactingBook.xaml"
            this.addPhotoButton.Click += new System.Windows.RoutedEventHandler(this.addPhotoButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.preview = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            this.addFilmButton = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\RedactingBook.xaml"
            this.addFilmButton.Click += new System.Windows.RoutedEventHandler(this.addBookButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\RedactingBook.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

