// Form1.Designer.cs
using System.Drawing;

namespace MiniMusic
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);

            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = new Icon("icon.ico");
            this.notifyIcon1.Text = "MiniMusic";
            this.notifyIcon1.Visible = true;

            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                // Hier die Einträge hinzufügen
            });
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
        }
    }
}
