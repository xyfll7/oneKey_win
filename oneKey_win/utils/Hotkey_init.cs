using GlobalHotKey;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using WindowsInput;

namespace oneKey_win.utils
{
    internal class Hotkey_init
    {

        private HotKeyManager hotKeyManager_B = new HotKeyManager();
        private HotKeyManager hotKeyManager_G = new HotKeyManager();
        private HotKeyManager hotKeyManager_B_T = new HotKeyManager();
        private HotKeyManager hotKeyManager_G_T = new HotKeyManager();
        public Hotkey_init()
        {
            var hotKeyB = hotKeyManager_B.Register(Key.B, ModifierKeys.Control);
            var hotKeyG = hotKeyManager_G.Register(Key.G, ModifierKeys.Control);
            var hotKeyB_T = hotKeyManager_B_T.Register(Key.B, ModifierKeys.Control | ModifierKeys.Alt);
            var hotKeyG_T = hotKeyManager_G_T.Register(Key.G, ModifierKeys.Control | ModifierKeys.Alt);
            hotKeyManager_B.KeyPressed += HotKeyManagerPressed_B;
            hotKeyManager_G.KeyPressed += HotKeyManagerPressed_G;
            hotKeyManager_B_T.KeyPressed += HotKeyManagerPressed_B_T;
            hotKeyManager_G_T.KeyPressed += HotKeyManagerPressed_G_T;
        }


        private void HotKeyManagerPressed_B(object? sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.B)
            {
                var sim = new InputSimulator();
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
                string str = ClipboardGetText();
                Process.Start(new ProcessStartInfo { FileName = $"https://www.baidu.com/s?wd={str}", UseShellExecute = true });
            }
        }
        private void HotKeyManagerPressed_G(object? sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.G)
            {
                var sim = new InputSimulator();
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
                string str = ClipboardGetText();
                Process.Start(new ProcessStartInfo { FileName = $"https://www.google.com.hk/search?q={str}", UseShellExecute = true });
            }
        }

        private void HotKeyManagerPressed_B_T(object? sender, KeyPressedEventArgs e)
        {
            var sim = new InputSimulator();
            sim.Keyboard.Sleep(1000).ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(50);
            string str = ClipboardGetText();
            Process.Start(new ProcessStartInfo { FileName = $"https://fanyi.baidu.com/#zh/en/{str}", UseShellExecute = true });
        }
        private void HotKeyManagerPressed_G_T(object? sender, KeyPressedEventArgs e)
        {
            var sim = new InputSimulator();
            sim.Keyboard.Sleep(1000).ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(50);
            string str = ClipboardGetText();
            Process.Start(new ProcessStartInfo { FileName = $"https://translate.google.cn/?hl=zh-CN&sl=zh-CN&tl=en&text={str}&op=translate", UseShellExecute = true });
        }

        private string ClipboardGetText()
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
