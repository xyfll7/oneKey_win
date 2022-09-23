using Hardcodet.Wpf.TaskbarNotification;
using oneKey_win.utils;
using System.Windows;

namespace oneKey_win
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon? notifyIcon;
        private readonly Hotkey_init hotkey_Init = new();
      
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Current.MainWindow = new MainWindow();
            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            MessageBox.Show("推出");
            notifyIcon?.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("未捕获异常: " + e.Exception.Message, "异常：", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
