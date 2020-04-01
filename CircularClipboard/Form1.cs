using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
namespace CircularClipboard
{
	public partial class Form1 : Form
	{
		private const int WmKeydown = 0x0100;
		private const int VkControl = 0x11;

		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

		public Form1()
		{
			InitializeComponent();
			var UniqueHotkeyId = 1;
			var HotKeyCode = (int)Keys.F9;
			var F9Registered = RegisterHotKey(
				this.Handle, UniqueHotkeyId, 0x0000, HotKeyCode
			);

			if (F9Registered)
			{
				Console.WriteLine("Global Hotkey F9 was successfully registered");
			}
			else
			{
				Console.WriteLine("Global Hotkey F9 couldn't be registered !");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0312)
			{
				var id = m.WParam.ToInt32();

				if (id == 1)
				{
					MessageBox.Show("F9 Was pressed !");
				}
			}
			base.WndProc(ref m);
		}
	}
}
