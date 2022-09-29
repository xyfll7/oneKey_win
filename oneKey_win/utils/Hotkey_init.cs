using GlobalHotKey;
using System.Diagnostics;
using System.Windows.Input;
using WindowsInput;

namespace oneKey_win.utils
{
    internal class HotKeyConfig
    {
        public Key key { get; set; }
        public ModifierKeys modifierKeys { get; set; }
        public string HotKeyName
        {
            get { return $"{modifierKeys} + {key}"; }
            set {  }
        }
        public string? url { get; set; }
        public bool isTrans { get; set; } = false;
        private HotKeyManager hotKeyManager { get; set; } = new();
        public HotKeyConfig init()
        {
            this.hotKeyManager.Register(this.key, this.modifierKeys);
            this.hotKeyManager.KeyPressed += HotKeyManagerPressed;
            return this;
        }

        private void HotKeyManagerPressed(object? sender, KeyPressedEventArgs e)
        {
            var sim = new InputSimulator();
            sim.Keyboard.Sleep(this.isTrans ? 1000 : 0).ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C).Sleep(this.isTrans ? 50 : 0);
            string str = Helper_funcs.ClipboardGetText();
            Process.Start(new ProcessStartInfo { FileName = $"{ this.url}{str}", UseShellExecute = true });
        }
    }
}