using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hardcodet.Wpf.TaskbarNotification;
using oneKey_win.utils;
using System.Windows;
using System.Windows.Input;

namespace oneKey_win
{
    /// <summary>
    /// Provides bindable properties and commands for the NotifyIcon. In this sample, the
    /// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
    /// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
    /// </summary>
    [ObservableObject]
    public partial class NotifyIconViewModel
    {
        [RelayCommand]
        private static void ExitApplication() 
        {
            Application.Current.Shutdown();
        }
     
        [ObservableProperty]
        private string oneKeyBD_value = "Ctrl+B";
        [RelayCommand]
        private void OneKeyBD(KeyEventArgs e)
        {
            OneKeyBD_value = Helper_funcs.GetHotKeyString(e);
        }
        [RelayCommand]
        private static void OneKeyBD_focus(object e)
        {
            
            
            var OneKeyBD_value = e;
        }
        [ObservableProperty]
        private string oneKeyGG_value = "Ctrl+G";
        [RelayCommand]
        private void OneKeyGG(KeyEventArgs e)
        {
            var notifyIcon =(TaskbarIcon?)Application.Current.Properties["notifyIcon"];
            notifyIcon?.ShowBalloonTip("sss", "sss", notifyIcon.Icon);
            OneKeyGG_value = Helper_funcs.GetHotKeyString(e);
        }
    }
}
