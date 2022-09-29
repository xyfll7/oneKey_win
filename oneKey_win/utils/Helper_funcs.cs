using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace oneKey_win.utils
{
    internal class Helper_funcs
    {
        public static string GetHotKeyString(KeyEventArgs e)
        {
            // Don't let the event pass further
            // because we don't want standard textbox shortcuts working
            e.Handled = true;

            // Get modifiers and key data
            var modifiers = Keyboard.Modifiers;
            var key = e.Key;

            // When Alt is pressed, SystemKey is used instead
            if (key == Key.System)
            {
                key = e.SystemKey;
            }

            // Pressing delete, backspace or escape without modifiers clears the current value
            if (modifiers == ModifierKeys.None &&
                (key == Key.Delete || key == Key.Back || key == Key.Escape))
            {
                return "";
            }

            // If no actual key was pressed - return
            if (key == Key.LeftCtrl ||
                key == Key.RightCtrl ||
                key == Key.LeftAlt ||
                key == Key.RightAlt ||
                key == Key.LeftShift ||
                key == Key.RightShift ||
                key == Key.LWin ||
                key == Key.RWin ||
                key == Key.Clear ||
                key == Key.OemClear ||
                key == Key.Apps)
            {
                return "";
            }
            return $"{modifiers}+{key}";
        }
        public static string ClipboardGetText()
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
