#pragma checksum "..\..\..\InfoFlightForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "045F67C25C0B6CF11E9DF8FCB273C0466C59415C"
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


namespace tspp_9_10_pr
{


    /// <summary>
    /// InfoFlightForm
    /// </summary>
    public partial class InfoFlightForm : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 9 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem LoadDataMenuItem;

#line default
#line hidden


#line 10 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SaveDataMenuItem;

#line default
#line hidden


#line 13 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem EditDataMenuItem;

#line default
#line hidden


#line 14 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AddDataMenuItem;

#line default
#line hidden


#line 17 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SelectXMenuItem;

#line default
#line hidden


#line 18 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SelectXYMenuItem;

#line default
#line hidden


#line 21 "..\..\..\InfoFlightForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FlightListDG;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/tspp_9-10_pr;component/infoflightform.xaml", System.UriKind.Relative);

#line 1 "..\..\..\InfoFlightForm.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.InfoFlightForm1 = ((tspp_9_10_pr.InfoFlightForm)(target));
                    return;
                case 2:
                    this.LoadDataMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 3:
                    this.SaveDataMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 4:
                    this.EditDataMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 5:
                    this.AddDataMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 6:
                    this.SelectXMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 7:
                    this.SelectXYMenuItem = ((System.Windows.Controls.MenuItem)(target));
                    return;
                case 8:
                    this.FlightListDG = ((System.Windows.Controls.DataGrid)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window InfoFlightForm1;
    }
}
