using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebView2_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomWebBrowserView : View
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
          propertyName: "Source",
          returnType: typeof(string),
          declaringType: typeof(string),
          defaultValue: "");

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public CustomWebBrowserView()
        {
            InitializeComponent();
        }
    }
}