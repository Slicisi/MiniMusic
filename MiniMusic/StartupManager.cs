using Microsoft.Win32;
using System;
using System.Windows.Forms;

public static class StartupManager
{
    public static void SetStartup(bool enable)
    {
        string exePath = Application.ExecutablePath; // Holen Sie sich den Pfad zur ausführbaren Datei
        string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"; // Registrierungspfad für Startprogramme
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true)) // Öffnen des Schlüssels
        {
            if (enable)
            {
                key.SetValue("MiniMusic", exePath); // Füge einen neuen Eintrag hinzu
            }
            else
            {
                key.DeleteValue("MiniMusic", false); // Entferne den Eintrag
            }
        } // Schließe den Schlüssel
    }
}
