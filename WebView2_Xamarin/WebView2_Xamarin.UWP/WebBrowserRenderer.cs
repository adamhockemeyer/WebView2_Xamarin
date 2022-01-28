using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebView2_Xamarin;
using WebView2_Xamarin.UWP;
using Windows.Foundation;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomWebBrowserView), typeof(WebBrowserRenderer))]
namespace WebView2_Xamarin.UWP
{
    public class WebBrowserRenderer : ViewRenderer<CustomWebBrowserView, WebView2>
    {
        WebView2 webView;

        public WebBrowserRenderer() : base()
        {

        }

        protected async override void OnElementChanged(ElementChangedEventArgs<CustomWebBrowserView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                webView = new WebView2();
                webView.CoreWebView2Initialized += WebView_CoreWebView2Initialized;
                webView.Source = new Uri(e.NewElement.Source);
                this.SetNativeControl(webView);
                await webView.EnsureCoreWebView2Async();

            }
        }

        private void WebView_CoreWebView2Initialized(WebView2 sender, CoreWebView2InitializedEventArgs args)
        {
            this.webView.CoreWebView2.Navigate(sender.Source.ToString());
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(CustomWebBrowserView.SourceProperty))
            {
                this.webView.Source = new Uri(Element.Source);
                this.webView.CoreWebView2.Navigate(Element.Source);
            }
        }
    }
}
