﻿#pragma checksum "..\..\..\View\Update.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72DFE0AE58017850BCE23753640FDBBE5ABD0E6EE407AAA9F99F2F95D207D090"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SP_LAUNCHER_MAIN_WPF.View;
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


namespace SP_LAUNCHER_MAIN_WPF.View {
    
    
    /// <summary>
    /// Update
    /// </summary>
    public partial class Update : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DOWNLOADLAUNCHERTEXT;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\Update.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label _1STEPDOWNLOAD;
        
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
            System.Uri resourceLocater = new System.Uri("/SP-LAUNCHER-MAIN-WPF;component/view/update.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Update.xaml"
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
            
            #line 10 "..\..\..\View\Update.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseUp);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\View\Update.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Window_MouseMove);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\View\Update.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\..\View\Update.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DOWNLOADLAUNCHERTEXT = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this._1STEPDOWNLOAD = ((System.Windows.Controls.Label)(target));
            
            #line 13 "..\..\..\View\Update.xaml"
            this._1STEPDOWNLOAD.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseUp);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\View\Update.xaml"
            this._1STEPDOWNLOAD.MouseMove += new System.Windows.Input.MouseEventHandler(this.Window_MouseMove);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\View\Update.xaml"
            this._1STEPDOWNLOAD.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 17 "..\..\..\View\Update.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
