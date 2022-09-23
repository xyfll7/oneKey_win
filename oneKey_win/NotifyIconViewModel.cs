using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private void ExitApplication() 
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
    }
}
