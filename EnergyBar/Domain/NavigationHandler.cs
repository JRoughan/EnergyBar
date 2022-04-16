using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace EnergyBar.Domain
{
    public static class NavigationHandler
    {
        public static void RegisterGlobalHyperlinkHandler()
        {
            EventManager.RegisterClassHandler(typeof(Hyperlink), Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(LaunchBrowser));
        }

        private static void LaunchBrowser(object sender, RequestNavigateEventArgs e)
        {
            var psi = new ProcessStartInfo(e.Uri.ToString()) { UseShellExecute = true };
            Process.Start(psi);
        }
    }
}