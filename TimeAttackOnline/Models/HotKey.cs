using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Progressive.TimeAttackOnline.Models
{
    /// <summary>
    /// グローバルホットキーを登録するクラス。
    /// 使用後は必ずDisposeすること。
    /// </summary>
    public class HotKey : IDisposable
    {
        HotKeyForm form;
        /// <summary>
        /// ホットキーが押されると発生する。
        /// </summary>
        public event EventHandler Pushed;

        /// <summary>
        /// ホットキーを指定して初期化する。
        /// 使用後は必ずDisposeすること。
        /// </summary>
        /// <param name="modKey">修飾キー</param>
        /// <param name="key">キー</param>
        public HotKey(ModifyKey modKey, Keys key)
        {
            form = new HotKeyForm(modKey, key, raiseHotKeyPush);
        }

        private void raiseHotKeyPush()
        {
            if (Pushed != null)
            {
                Pushed(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            form.Dispose();
        }

        private class HotKeyForm : Form
        {
            [DllImport("user32.dll")]
            extern static int RegisterHotKey(IntPtr HWnd, int ID, ModifyKey MOD_KEY, Keys KEY);

            [DllImport("user32.dll")]
            extern static int UnregisterHotKey(IntPtr HWnd, int ID);

            const int WM_HOTKEY = 0x0312;
            int id;
            IntPtr handle;
            ThreadStart proc;

            public HotKeyForm(ModifyKey modKey, Keys key, ThreadStart proc)
            {
                this.proc = proc;
                for (int i = 0x0000; i <= 0xbfff; i++)
                {
                    if (RegisterHotKey(this.Handle, i, modKey, key) != 0)
                    {
                        id = i;
                        handle = Handle;
                        break;
                    }
                }
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == WM_HOTKEY)
                {
                    if ((int)m.WParam == id)
                    {
                        proc();
                    }
                }
            }

            protected override void Dispose(bool disposing)
            {
                UnregisterHotKey(handle, id);
                base.Dispose(disposing);
            }

            protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
            {
                base.OnClosing(e);
            }
        }
    }

    /// <summary>
    /// HotKeyクラスの初期化時に指定する修飾キー
    /// </summary>
    public enum ModifyKey : int
    {
        Undefined = 0x0000,
        Alt = 0x0001,
        Control = 0x0002,
        Shift = 0x0004,
    }
}
