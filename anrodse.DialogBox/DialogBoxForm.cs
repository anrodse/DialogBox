using System;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace anrodse.Forms
{
	internal partial class DialogBoxForm : Form
	{

		#region Deshabilitar control

		enum MenuItem { SC_CLOSE = 0xF060 }

		[DllImport("user32")]
		public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32")]
		public static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);

		private void EnableMenuItem(MenuItem ctrl, bool enabled)
		{
			EnableMenuItem(GetSystemMenu(this.Handle, false), (uint)ctrl, enabled ? 0u : 1u);
		}

		#endregion Boton cerrar

		#region Constantes

		private const int TimerTock = 250;

		#endregion Constantes

		#region Propiedades

		public DialogBoxResult Result { get; set; }

		public int Timeout { get; set; }

		public DialogBoxTimeoutResult TimeoutResult { get; set; }

		public int Disable { get; set; }

		public string Message { get { return lblMensaje.Text; } set { lblMensaje.Text = value; } }

		public string Caption { private get; set; }

		public Icon Icono { get; private set; }

		private DialogBoxIcon image;
		public DialogBoxIcon Image
		{
			set
			{
				image = value;
				setImage();
			}
		}

		private void setImage()
		{
			//if (icon != DialogBoxIcon.None) throw new Exception("No definido");
		}

		public MessageBoxDefaultButton DefaultButton { get; set; }

		public bool AlertSound { get; set; } = true;

		#endregion Propiedades

		#region Constructor

		public DialogBoxForm()
		{
			InitializeComponent();

			Result = DialogBoxResult.Cancel;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) components.Dispose();

				timerTimeout?.Stop();
				timerTimeout = null;

				timerDisable?.Stop();
				timerDisable = null;

			}
			base.Dispose(disposing);
		}

		#endregion Constructor

		#region Eventos

		private void DialogBoxForm_Load(object sender, EventArgs e)
		{
			SetButtons();
			PlayBeep();

			Text = Caption;

			StartTimers();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if ((int)keyData == (int)(Keys.Alt | Keys.F4))
			{
#warning return Cancel button result
				SetResultAndClose(DialogBoxResult.Cancel);
			}

			if ((int)keyData == (int)(Keys.Control | Keys.Insert))
			{
				Clipboard.SetText(GetDialogAsString());
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void btn_Click(object sender, EventArgs e)
		{
			if (sender is DialogBoxButton btn)
				if (btn.Value != DialogBoxResult.None)
					SetResultAndClose(btn.Value);
		}

		#endregion Eventos

		#region ShowDialog

		public new DialogBoxResult ShowDialog()
		{
			base.ShowDialog();

			return Result;
		}

		public new DialogBoxResult ShowDialog(IWin32Window owner)
		{
			base.ShowDialog(owner);

			return Result;
		}

		#endregion ShowDialog

		#region Botones

		private void SetButtons()
		{
			foreach (Control ctr in pnFooter.Controls)
			{
				if (ctr is DialogBoxButton btn)
					btn.Click += btn_Click;
			}
		}

		internal void AddButtons(DialogBoxButtons buttons)
		{
			DialogBoxButtonOp btn = (DialogBoxButtonOp)buttons;

			// Sin botones, poner solo Ok
			if (btn == DialogBoxButtonOp.None)
			{ AddButton("Aceptar", DialogBoxResult.Ok); return; }

			// Poner botones seleccionados
			if ((btn & DialogBoxButtonOp.Ok) == DialogBoxButtonOp.Ok)
				AddButton("Aceptar", DialogBoxResult.Ok);

			if ((btn & DialogBoxButtonOp.Yes) == DialogBoxButtonOp.Yes)
				AddButton("Si", DialogBoxResult.Yes);

			if ((btn & DialogBoxButtonOp.No) == DialogBoxButtonOp.No)
				AddButton("No", DialogBoxResult.No);

			if ((btn & DialogBoxButtonOp.Abort) == DialogBoxButtonOp.Abort)
				AddButton("Anular", DialogBoxResult.Abort);

			if ((btn & DialogBoxButtonOp.Retry) == DialogBoxButtonOp.Retry)
				AddButton("Reintentar", DialogBoxResult.Retry);

			if ((btn & DialogBoxButtonOp.Ignore) == DialogBoxButtonOp.Ignore)
				AddButton("Omitir", DialogBoxResult.Ignore);

			if ((btn & DialogBoxButtonOp.IgnoreAll) == DialogBoxButtonOp.IgnoreAll)
				AddButton("Omitir todos", DialogBoxResult.IgnoreAll);

			if ((btn & DialogBoxButtonOp.Cancel) == DialogBoxButtonOp.Cancel)
				AddButton("Cancelar", DialogBoxResult.Cancel);
		}

		private void AddButton(string button, DialogBoxResult result)
		{
			pnFooter.Controls.Add(new Label() { Text = "", Width = 10, Dock = DockStyle.Right });
			pnFooter.Controls.Add(new DialogBoxButton() { Text = button, Value = result, Dock = DockStyle.Right });
		}

		#endregion Botones

		#region Temporizadores

		private Timer timerTimeout = null;
		private Timer timerDisable = null;

		private void StartTimers()
		{
			if (Disable > 0)
			{
				StartDisableTimer();
			}
			else if (Timeout > 0)
			{
				StartTimeoutTimer();
			}
		}

		private void StartDisableTimer()
		{
			if (Disable > 0)
			{
				foreach (Control c in pnFooter.Controls)
				{
					if (c is DialogBoxButton btn) btn.Enabled = false;
				}

				if (timerDisable == null)
				{
					timerDisable = new Timer(this.components);
					timerDisable.Tick += new EventHandler(timerDisable_Tick);
				}

				if (!timerDisable.Enabled)
				{
					timerDisable.Interval = TimerTock;
					timerDisable.Start();
					timerDisable_Tick(null, null);
				}
			}
		}

		private void StartTimeoutTimer()
		{
			if (Timeout > 0)
			{
				if (timerTimeout == null)
				{
					timerTimeout = new Timer(this.components);
					timerTimeout.Tick += new EventHandler(timerTimeout_Tick);
				}

				if (!timerTimeout.Enabled)
				{
					timerTimeout.Interval = TimerTock;
					timerTimeout.Start();
					timerTimeout_Tick(null, null);
				}
			}
		}

		private void timerDisable_Tick(object sender, EventArgs e)
		{
			try
			{
				SuspendLayout();

				if (Disable <= 0)
				{
					Text = Caption;
					EnableMenuItem(MenuItem.SC_CLOSE, true);

					foreach (Control c in pnFooter.Controls)
					{
						if (c is DialogBoxButton btn) btn.Enabled = true;
					}

					timerDisable?.Stop();
					StartTimeoutTimer();
				}
				else
				{
					EnableMenuItem(MenuItem.SC_CLOSE, false);
					SetTimerCaption(Disable, new string[] { "⦵", "⦸", "⦶", "⊘" });
				}

				Disable -= TimerTock;
			}
			finally
			{
				ResumeLayout();
			}
		}

		private void timerTimeout_Tick(object sender, EventArgs e)
		{
			try
			{
				SuspendLayout();

				if (Timeout <= 0)
				{
					Text = Caption;

					timerTimeout.Stop();

					switch (TimeoutResult)
					{
						case DialogBoxTimeoutResult.Default:
							//	defaultBtn.PerformClick();
							break;

						case DialogBoxTimeoutResult.Cancel:
							//	if (!GetCancelBtn())
							//	{
							//		SetResultAndClose(DialogBoxResult.Cancel);
							//	}
							//	else
							//	{
							//		defaultBtn.PerformClick();
							//	}
							break;

						case DialogBoxTimeoutResult.Timeout:
							SetResultAndClose(DialogBoxResult.Timeout);
							break;
					}
				}
				else
				{
					SetTimerCaption(Timeout, new string[] { "🕑", "🕓", "🕗", "🕙" });
				}

				Timeout -= TimerTock;
			}
			finally
			{
				ResumeLayout();
			}
		}

		private void SetTimerCaption(int tiempo, string[] symbols)
		{
			int t = (int)tiempo / 1000;
			int tick = (int)tiempo / TimerTock;
			string ico = symbols[tick % symbols.Length];

			Text = $"{Caption}    ⟨ {t.ToString().PadLeft(2, ' ')} {ico} ⟩";
		}

		#endregion Temporizadores

		#region Métodos Extra

		private void PlayBeep()
		{
			if (AlertSound && image != DialogBoxIcon.None)
			{
				SystemSounds.Beep.Play();
			}
		}

		private void SetResultAndClose(DialogBoxResult result)
		{
			Result = result;
			DialogResult = DialogResult.OK; // si (FormBorderStyle == FixedDialog) -> Cierra
		}

		private string GetDialogAsString()
		{
			string sep = "------------------------\r\n";

			string buttonsText = String.Empty;
			foreach (Control button in pnFooter.Controls)
			{
				buttonsText = ((button as DialogBoxButton)?.Text ?? "") + "  ";
			}

			return sep + Caption + "\r\n"
					+ sep + Message + "\r\n"
					+ sep + buttonsText + "\r\n" + sep;
		}

		#endregion Métodos Extra

	}
}

// r.tsw_h
