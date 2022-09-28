using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hardcodet.Wpf.TaskbarNotification;
using oneKey_win.utils;
using System;
using System.Windows;
using System.Windows.Input;

namespace oneKey_win
{
    [ObservableObject]
    internal partial class MyTrayPopup_ViewModel
    {
        private readonly Hotkey_init hotkey_Init = new();
        public MyTrayPopup_ViewModel()
        {
           
        }
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
            var notifyIcon = (TaskbarIcon?)Application.Current.Properties["notifyIcon"];
            notifyIcon?.ShowBalloonTip("sss", "sss", notifyIcon.Icon);
            OneKeyGG_value = Helper_funcs.GetHotKeyString(e);
        }
    }
}
