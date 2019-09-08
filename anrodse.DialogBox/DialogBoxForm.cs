using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace anrodse.Forms
{
	internal partial class DialogBoxForm : Form
	{

		#region Propiedades

		public DialogBoxResult Result { get; set; }

		public int Timeout { get; set; }

		public DialogBoxTimeoutResult TimeoutResult { get; set; }

		public int Disable { get; set; }

		public string Message { get { return lblMensaje.Text; } set { lblMensaje.Text = value; } }

		public string Caption { get { return Text; } set { Text = value; } }

		public DialogBoxIcon Image { set { setImage(value); } }

		private void setImage(DialogBoxIcon icon)
		{
			if (icon != DialogBoxIcon.None) throw new Exception("No definido");
		}

		public MessageBoxDefaultButton DefaultButton { get; set; }

		public bool AlertSound { get; set; } = true;

		#endregion Propiedades

		public DialogBoxForm()
		{
			InitializeComponent();

			Result = DialogBoxResult.Cancel;
		}

		public new DialogBoxResult ShowDialog()
		{
			return DialogBoxResult.Ok;
		}

		public new DialogBoxResult ShowDialog(IWin32Window owner)
		{
			base.ShowDialog(owner);

			return Result;
		}

		#region Eventos

		private void DialogBoxForm_Load(object sender, EventArgs e)
		{
			SetButtons();
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

		private void SetResultAndClose(DialogBoxResult result)
		{
			Result = result;

			DialogResult = DialogResult.OK; // si (FormBorderStyle == FixedDialog) -> Cierra
		}

	}
}

// r.tsw_h
