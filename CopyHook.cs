using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Havoc__Copy_That
{
    public partial class CopyHook : Form
    {
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        public CopyHook()
        {
            InitializeComponent();

            // Register for clipboard change notifications
            NativeMethods.AddClipboardFormatListener(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Check for clipboard update message
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                MessageBox.Show("Clipboard content changed!");

                // Check if the clipboard contains files
                if (Clipboard.ContainsFileDropList())
                {
                    StringCollection files = Clipboard.GetFileDropList();
                    foreach (string file in files)
                    {
                        MessageBox.Show("Pasted file: " + file);
                        // Perform actions with the pasted file here
                    }
                }
            }
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AddClipboardFormatListener(IntPtr hwnd);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CopyHook());
        }
    }
}
