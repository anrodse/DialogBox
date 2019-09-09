using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace anrodse.Forms
{
	internal partial class DialogBoxForm : Form
	{

		#region Campos

		private const int timerTock = 250;
		private Timer timerTimeout = null;
		private Timer timerDisable = null;

		#endregion Campos

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

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

		#region Eventos

		private void DialogBoxForm_Load(object sender, EventArgs e)
		{
			SetButtons();
			PlayBeep();

			Text = Caption;

			StartTimer();
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
				Clipboard.SetText(GetBoxMessaje());
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		private string GetBoxMessaje()
		{
			string sep = "------------------------\r\n";
			string txt = sep
					+ Caption + "\r\n"
					+ sep
					+ Message + "\r\n"
					+ sep
					+ GetButtonsText() + "\r\n" + sep;

			return txt;
		}

		private string GetButtonsText()
		{
			string txt = String.Empty;
			foreach (Control button in pnFooter.Controls)
			{
				txt = ((button as DialogBoxButton)?.Text ?? "") + "  ";
			}

			return txt;
		}

		private void btn_Click(object sender, EventArgs e)
		{
			if (sender is DialogBoxButton btn)
				if (btn.Value != DialogBoxResult.None)
					SetResultAndClose(btn.Value);
		}

		#endregion Eventos

		#region Start

		private void PlayBeep()
		{
			if (AlertSound && image != DialogBoxIcon.None)
			{
				SystemSounds.Beep.Play();
			}
		}

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

		private void StartTimer()
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
					timerDisable.Interval = timerTock;
					timerDisable.Start();
					timerDisable_Tick(null, null);
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

					foreach (Control c in pnFooter.Controls)
					{
						if (c is DialogBoxButton btn) btn.Enabled = true;
					}

					timerDisable?.Stop();
					StartTimeoutTimer();
				}
				else
				{
					int t = (int)Disable / 1000;
					Text = $"{Caption}    [ ⊘ {t} ]";
				}

				Disable -= timerTock;
			}
			finally
			{
				ResumeLayout();
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
					timerTimeout.Interval = timerTock;
					timerTimeout.Start();
					timerTimeout_Tick(null, null);
				}
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
						case DialogBoxTimeoutResult.Timeout:
							SetResultAndClose(DialogBoxResult.Timeout);
							break;
					}
				}
				else
				{
					int t = (int)Timeout / timerTock;
					string ico = (t % 3 == 0) ? "🕑" : (t % 2 == 0) ? "🕓" : "🕗";

					Text = $"{Caption}    [ {ico} {(int)Timeout / 1000} ]";
				}

				Timeout -= timerTock;
			}
			finally
			{
				ResumeLayout();
			}
		}

		#endregion Start

		private void SetResultAndClose(DialogBoxResult result)
		{
			Result = result;

			DialogResult = DialogResult.OK; // si (FormBorderStyle == FixedDialog) -> Cierra
		}

	}
}

// r.tsw_h
