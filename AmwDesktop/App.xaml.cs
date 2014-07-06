using System.Windows;
using AirMedia.Core.Log;
using AirMedia.Core.Requests.Controller;
using System.Windows.Navigation;

namespace AmwDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static RequestManager RequestManager { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AmwLog.Init(new AmwLogImpl());

            RequestManager = new ThreadPoolRequestManager();
            RequestManager.Init(RequestManager);
        }
    }
}
