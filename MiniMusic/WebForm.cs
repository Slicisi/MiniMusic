using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace MiniMusic
{
    public partial class WebForm : Form
    {
        private string url;

        public WebForm(string url)
        {
            this.url = url;
            InitializeComponent();
        }

        private async void WebForm_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.Navigate(url);
        }
    }
}