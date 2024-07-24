using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace MiniMusic
{
    partial class WebForm
    {
        private System.ComponentModel.IContainer components = null;
        private WebView2 webView21;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebForm));
            this.webView21 = new WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = Color.White;
            this.webView21.Dock = DockStyle.Fill;
            this.webView21.Location = new Point(0, 0);
            this.webView21.Margin = new Padding(4, 4, 4, 4);
            this.webView21.Name = "webView21";
            this.webView21.Size = new Size(1067, 554);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // WebForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1067, 554);
            this.Controls.Add(this.webView21);
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "WebForm";
            this.Text = "MiniMusic";
            this.Load += new EventHandler(this.WebForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
