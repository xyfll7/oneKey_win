using GlobalHotKey;
using System.Diagnostics;
using System.Windows.Input;
using WindowsInput;

namespace oneKey_win.utils
{
    public class HotKeyConfig
    {
        public Key key { get; set; }
        public ModifierKeys modifierKeys { get; set; }
        public HotKeyConfig HotKeyObj
        { get { return this; } }
        public string HotKeyName
        { get { return modifierKeys == ModifierKeys.None ? "键入新快捷键" : $"{modifierKeys} + {key}"; } }
        public string? url { get; set; }
        public bool isTrans { get; set; } = false;
        private HotKeyManager hotKeyManager { get; set; } = new();
        public HotKeyConfig init()
        {
            hotKeyManager.Register(key, modifierKeys);
            hotKeyManager.KeyPressed += HotKeyManagerPressed;
            return this;
        }
        public void Dispose()
        {
            hotKeyManager.Dispose();
        }

        private void HotKeyManagerPressed(object? sender, KeyPressedEventArgs e)
        {
            var sim = new InputSimulator();
            sim.Keyboard.Sleep(isTrans ? 1000 : 0).ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(isTrans ? 50 : 0);
            string str = Helper_funcs.ClipboardGetText();
            Process.Start(new ProcessStartInfo { FileName = $"{url}{str}", UseShellExecute = true });
        }
    }
}