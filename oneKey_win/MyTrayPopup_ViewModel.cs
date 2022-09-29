using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using oneKey_win.utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace oneKey_win
{
    [ObservableObject]
    internal partial class MyTrayPopup_ViewModel
    {
        [ObservableProperty]
        private ObservableCollection<HotKeyConfig> observableObj = new()
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
        // 新增快捷键
        [RelayCommand]
        private void AddHotKey(KeyEventArgs e)
        {
            var hotKey_key = Helper_funcs.GetHotKey_Key(e);
            if (hotKey_key != null)
            {
                ObservableObj.Add(new HotKeyConfig()
                { key = hotKey_key.Value.Item2, modifierKeys = hotKey_key.Value.Item1, url = "https://www.qq.com/", }.init());
            };

        }
        // 退出
        [RelayCommand]
        private static void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
