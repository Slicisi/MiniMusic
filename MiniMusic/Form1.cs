using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniMusic
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> musicServices = new Dictionary<string, string>()
        {
            { "Spotify", "https://open.spotify.com" },
            { "Apple Music", "https://music.apple.com" },
            { "YouTube Music", "https://music.youtube.com" },
            { "Deezer", "https://www.deezer.com" },
            { "Amazon Music", "https://music.amazon.com" }
        };

        private List<WebForm> openWebForms = new List<WebForm>();

        public Form1()
        {
            InitializeComponent();
            InitializeContextMenu();
            InitializeNotifyIcon();

            // Überprüfen, ob das Programm bereits im Autostart ist, und hinzufügen, falls nicht
            if (!IsProgramInStartup())
            {
                StartupManager.SetStartup(true);
            }
        }

        private void InitializeContextMenu()
        {
            foreach (var service in musicServices)
            {
                var item = new ToolStripMenuItem(service.Key);
                item.Click += (sender, e) => OpenService(service.Value);
                contextMenuStrip1.Items.Add(item);
            }

            var addItem = new ToolStripMenuItem("Add Service");
            addItem.Click += (sender, e) => AddService();
            contextMenuStrip1.Items.Add(addItem);

            var showAllWindowsItem = new ToolStripMenuItem("Show All Windows");
            showAllWindowsItem.Click += (sender, e) => ShowAllWebForms();
            contextMenuStrip1.Items.Add(showAllWindowsItem);

            var exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += (sender, e) => Application.Exit();
            contextMenuStrip1.Items.Add(exitItem);
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon1.Icon = new Icon("icon.ico");
            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;

            notifyIcon1.DoubleClick += (sender, e) =>
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            };
        }

        private void OpenService(string url)
        {
            ShowWebForm(url);
        }

        private void ShowWebForm(string url)
        {
            WebForm webForm = new WebForm(url);
            webForm.StartPosition = FormStartPosition.Manual;
            webForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - webForm.Width, Screen.PrimaryScreen.WorkingArea.Height - webForm.Height);
            webForm.TopMost = true;
            webForm.FormClosed += (s, e) => openWebForms.Remove(webForm);
            openWebForms.Add(webForm);
            webForm.Show();
        }

        private void AddService()
        {
            using (var addForm = new AddServiceForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var serviceName = addForm.ServiceName;
                    var serviceUrl = addForm.ServiceUrl;
                    musicServices[serviceName] = serviceUrl;

                    var item = new ToolStripMenuItem(serviceName);
                    item.Click += (sender, e) => OpenService(serviceUrl);
                    contextMenuStrip1.Items.Insert(contextMenuStrip1.Items.Count - 1, item);
                }
            }
        }

        private void ShowAllWebForms()
        {
            foreach (var webForm in openWebForms)
            {
                webForm.Show();
                webForm.WindowState = FormWindowState.Normal;
            }
        }

        private bool IsProgramInStartup()
        {
            string exePath = Application.ExecutablePath;
            string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
            {
                if (key != null)
                {
                    string currentPath = (string)key.GetValue("MiniMusic");
                    return string.Equals(currentPath, exePath, StringComparison.OrdinalIgnoreCase);
                }
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Eventuelle zusätzliche Initialisierung, die beim Laden des Formulars ausgeführt werden soll
        }
    }
}
