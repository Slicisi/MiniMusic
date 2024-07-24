using System;
using System.Windows.Forms;

namespace MiniMusic
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Erstelle und zeige das Hauptformular nicht
            Form1 mainForm = new Form1();
            Application.Run(); // Diese Zeile sorgt dafür, dass die Anwendung läuft, ohne das Hauptformular zu zeigen
        }
    }
}