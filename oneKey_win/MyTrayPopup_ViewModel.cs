using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oneKey_win.utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace oneKey_win
{
    [ObservableObject]
    internal partial class MyTrayPopup_ViewModel
    {
        [ObservableProperty]
        private ObservableCollection<HotKeyConfig> hotKeyCollection = new()
        {
            
            new HotKeyConfig()
            { key = Key.O, modifierKeys = ModifierKeys.Control, url = "https://dict.eudic.net/dicts/en/",}.init(),
            new HotKeyConfig()
            { key = Key.Y, modifierKeys = ModifierKeys.Control, url = "https://dict.youdao.com/result?lang=en&word=",}.init(),
            new HotKeyConfig()
            { key = Key.B, modifierKeys = ModifierKeys.Control, url = "https://www.bing.com/search?&mkt=zh-CN&q=",}.init(),
            new HotKeyConfig()
            { key = Key.G, modifierKeys = ModifierKeys.Control, url = "https://translate.google.com/?hl=zh-CN&sl=auto&tl=en&op=translate&text=", }.init(),
            new HotKeyConfig()
            { key = Key.G, modifierKeys = ModifierKeys.Control | ModifierKeys.Alt, url = " https://www.google.com.hk/search?q=",isTrans = true}.init(),
        };
        [RelayCommand]
        private void ChangeHotKey(ItemTappedEventArgs e)
        {
                var hotkey = Helper_funcs.GetHotKey_Key(e.keyEventArgs);
                if (hotkey != null)
                {
                    HotKeyCollection[0].Dispose();
                    var a = HotKeyCollection;
                    HotKeyCollection[0] = new HotKeyConfig()
                    {
                        key = hotkey.Value.Item2,
                        modifierKeys = hotkey.Value.Item1,
                        url = "https://www.qq.com/s?wd="
                    }.init();
            }
        }
        // 新增快捷键
        [RelayCommand]
        private void AddHotKey()
        {
            HotKeyCollection.Add(new HotKeyConfig()
            { key = Key.None, modifierKeys = ModifierKeys.None, url = "", });
        }
        // 退出
        [RelayCommand]
        private static void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }

    public class ItemTappedEventArgs 
    {
        public  KeyEventArgs? keyEventArgs { get; set; }
        public  HotKeyConfig? hotKeyConfig { get; set; }
    }
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemTappedEventArgs() { keyEventArgs = value as KeyEventArgs, hotKeyConfig = parameter as HotKeyConfig };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
