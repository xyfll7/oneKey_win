using GlobalHotKey;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WindowsInput;
using static System.Net.WebRequestMethods;

namespace oneKey_win.utils
{
    internal class HotKeyConfig
    {
        internal HotKeyConfig(int index)
        {
            this.index = index;
        }
        internal int index;
        internal Key key;
        internal ModifierKeys modifierKeys;
        internal string? url;
        internal bool isTrans = false;
    }
    internal class Hotkey_init
    {
        private List<HotKeyManager> hotKeyManagers = new();
        private List<HotKeyConfig> hotKeys = new()
        {
            new HotKeyConfig(0)
            {
                key = Key.B,
                modifierKeys = ModifierKeys.Control,
                url = "https://www.baidu.com/s?wd=",
            },
            new HotKeyConfig(1)
            {
                key = Key.G,
                modifierKeys = ModifierKeys.Control,
                url = "https://www.google.com.hk/search?q=",
            },
            new HotKeyConfig(2)
            {
                key = Key.B,
                modifierKeys = ModifierKeys.Control | ModifierKeys.Alt,
                url = "https://fanyi.baidu.com/#zh/en/",
                isTrans = true
            },
            new HotKeyConfig(3)
            {
                key = Key.G,
                modifierKeys = ModifierKeys.Control | ModifierKeys.Alt,
                url = "https://translate.google.cn/?hl=zh-CN&sl=en&tl=zh-CN&op=translate&text=",
                isTrans = true
            },
        };
        public Hotkey_init()
        {
            foreach (var hotkey in hotKeys)
            {
                hotKeyManagers.Add(new HotKeyManager());
                hotKeyManagers[hotkey.index].Register(hotkey.key,hotkey.modifierKeys);
                hotKeyManagers[hotkey.index].KeyPressed += HotKeyManagerPressed;
            }
        }
       
        private void HotKeyManagerPressed(object? sender, KeyPressedEventArgs e)
        {
            foreach (var hotkey in hotKeys)
            {
               if(hotkey.key == e.HotKey.Key && hotkey.modifierKeys == e.HotKey.Modifiers)
                {
                    var sim = new InputSimulator();
                    sim.Keyboard.Sleep(hotkey.isTrans ? 1000 : 0).ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(hotkey.isTrans ? 50 : 0);
                    string str = ClipboardGetText();
                    Process.Start(new ProcessStartInfo { FileName = $"{hotkey.url}{str}", UseShellExecute = true });
                }
            }
        }

        private static string ClipboardGetText()
        {
            Thread.Sleep(50);
            string str = "";
            if (Clipboard.ContainsText())
            {
                try { str = Clipboard.GetText(); }
                catch (COMException) { }
                finally
                {
                    Thread.Sleep(20);
                    try { str = Clipboard.GetText(); }
                    catch (COMException) { str = "剪切板被占用"; }
                }
            }
            return str.Trim().Replace("  ", "");
        }
    }
}