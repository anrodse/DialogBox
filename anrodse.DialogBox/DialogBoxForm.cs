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

		private const int TIMER_TOCK = 250;
		private const int TEXT_MAX_WIDTH = 600;
		private const int TEXT_MAX_HEIGHT = 600;

		#endregion Constantes

		#region Propiedades

		public DialogBoxResult Result { get; set; }

		public int Timeout { get; set; }

		public DialogBoxTimeoutResult TimeoutResult { get; set; }

		public int Disable { get; set; }

		public string Message { get { return lblMensaje.Text; } set { lblMensaje.Text = value; } }

		public string Caption { private get; set; }

		public Icon Icono { get; private set; }

		public DialogBoxIcon Image { private get; set; }

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
			if (this.components == null) this.components = new System.ComponentModel.Container();

			PlayBeep();
			SetButtons();
			SetImage();
			SetFormWidth();
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

		#region Imagen

		private void SetImage()
		{
			switch (Image)
			{
				//case DialogBoxIcon.Hand:
				//	Icono = SystemIcons.Hand;
				//	break;
				//case DialogBoxIcon.Stop:
				//	Icono = SystemIcons.Stop;
				//	break;
				case DialogBoxIcon.Error:
					Icono = SystemIcons.Error;
					break;
				case DialogBoxIcon.Question:
					Icono = SystemIcons.Question;
					break;
				//case DialogBoxIcon.Warning:
				//	Icono = SystemIcons.Warning;
				//	break;
				case DialogBoxIcon.Exclamation:
					Icono = SystemIcons.Exclamation;
					break;
				//case DialogBoxIcon.Information:
				//	Icono = SystemIcons.Information;
				//	break;
				case DialogBoxIcon.Asterisk:
					Icono = SystemIcons.Asterisk;
					break;

				case DialogBoxIcon.None:
					Icono = null;
					break;
			}

			if (Image != DialogBoxIcon.None) { imgIcono.Image = new Icon(Icono, 32, 32).ToBitmap(); }
			else { pnIcono.Width = 0; }
		}

		#endregion Imagen

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

		#region Tamaño

		private void SetFormWidth()
		{
			Size btnsSize = GetButtonsSize();
			Size textSize = GetTextSize();
			Size imagSize = GetImageSize();

			int width = Math.Max(btnsSize.Width, textSize.Width + imagSize.Width);
			int height = Math.Max(imagSize.Height, textSize.Height) + btnsSize.Height + 74; // Mínimo 80, padding más bordes

			this.Size = new Size(width, height);
		}

		private Size GetImageSize()
		{
			if (Image == DialogBoxIcon.None) return new Size(0, 0);
			return new Size(pnIcono.Width, Math.Min(pnIcono.Height, 32));
		}

		private Size GetTextSize()
		{
			using (Graphics g = this.CreateGraphics())
			{
				SizeF strRectSizeF = g.MeasureString(lblMensaje.Text, lblMensaje.Font, new SizeF(TEXT_MAX_WIDTH, TEXT_MAX_HEIGHT));

				//if (strRectSizeF.Height > 40) lblMensaje.TextAlign = ContentAlignment.TopLeft;

				return new Size((int)Math.Ceiling(strRectSizeF.Width), (int)Math.Ceiling(strRectSizeF.Height) + 20);
			}
		}

		private Size GetButtonsSize()
		{
			int width = 0;

			foreach (Control ctr in pnFooter.Controls)
			{
				width += ctr.Width;
			}

			return new Size(width + 20, pnFooter.Height);
		}

		#endregion Tamaño

		#region Temporizadores

		private Timer timerTimeout = null;
		private Timer timerDisable = null;

		private void StartTimers()
		{
			Text = Caption;

			StartDisableTimer();
			StartTimeoutTimer();
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
					timerDisable.Interval = TIMER_TOCK;
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
					timerTimeout.Interval = TIMER_TOCK;
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

				Disable -= TIMER_TOCK;
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

				Timeout -= TIMER_TOCK;
			}
			finally
			{
				ResumeLayout();
			}
		}

		private void SetTimerCaption(int tiempo, string[] symbols)
		{
			int t = (int)tiempo / 1000;
			int tick = (int)tiempo / TIMER_TOCK;
			string ico = symbols[tick % symbols.Length];

			Text = $"{Caption}    ⟨ {t.ToString().PadLeft(2, ' ')} {ico} ⟩";
		}

		#endregion Temporizadores

		#region Métodos Extra

		private void PlayBeep()
		{
			if (AlertSound && Image != DialogBoxIcon.None)
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
