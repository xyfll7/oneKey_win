using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hardcodet.Wpf.TaskbarNotification;
using oneKey_win.utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace oneKey_win
{
    [ObservableObject]
    internal partial class MyTrayPopup_ViewModel
    {
        [ObservableProperty]
        private List<HotKeyConfig> observableObj = new()
        {
            new HotKeyConfig()
            { key = Key.B, modifierKeys = ModifierKeys.Control, url = "https://www.baidu.com/s?wd=",}.init(),
            new HotKeyConfig()
            { key = Key.G, modifierKeys = ModifierKeys.Control, url = "https://www.google.com.hk/search?q=", }.init(),
            new HotKeyConfig()
            { key = Key.B, modifierKeys = ModifierKeys.Control | ModifierKeys.Alt, url = "https://fanyi.baidu.com/#zh/en/",isTrans = true}.init(),
            new HotKeyConfig()
            { key = Key.G, modifierKeys = ModifierKeys.Control | ModifierKeys.Alt, url = "https://translate.google.cn/?hl=zh-CN&sl=en&tl=zh-CN&op=translate&text=",isTrans = true}.init(),
        };
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
