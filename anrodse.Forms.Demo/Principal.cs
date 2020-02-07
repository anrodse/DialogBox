using System;
using System.Windows.Forms;

namespace anrodse.Forms.Demo
{
	public partial class Principal : Form
	{
		public Principal()
		{
			InitializeComponent();

			txtMensaje.Text = textoCorto;
		}

		#region Propiedades

		string textoCorto = "TEST: Mensaje de prueba";
		string textoMedio = "Texto largooooooooooooooooooooo \r\n" +
									"Línea nueva\r\n" +
									"Última línea\r\n";
		string textoLargo = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\r\nSed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?\r\nÚltima línea\r\n";

		#endregion Propiedades

		#region Eventos

		#region Eventos Texto

		private void btnTextoVacio_Click(object sender, EventArgs e)
		{
			txtMensaje.Text = "";
		}


		private void btnTextoCorto_Click(object sender, EventArgs e)
		{
			txtMensaje.Text = textoCorto;
		}

		private void btnTextoMedio_Click(object sender, EventArgs e)
		{
			txtMensaje.Text = textoMedio;
		}

		private void btnTextoLargo_Click(object sender, EventArgs e)
		{
			txtMensaje.Text = textoLargo;
		}

		#endregion Eventos Texto

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.Ok);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.OK);
		}

		private void btnOkCancel_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.OkCancel);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.OKCancel);
		}

		private void btnRetryCancel_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.RetryCancel);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.RetryCancel);
		}

		private void btnYesNo_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.YesNo);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.YesNo);
		}

		private void btnYesNoCancel_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.YesNoCancel);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.YesNoCancel);
		}

		private void btnAbortRetryIgnore_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.AbortRetryIgnore);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.AbortRetryIgnore);
		}

		private void btnAbortRetryIgnoreIgnoreAll_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.AbortRetryIgnoreIgnoreAll);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.AbortRetryIgnore);
		}

		private void btnNone_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked) txtRes.Text = ShowDialogBox(DialogBoxButtons.None);
			else txtRes.Text = ShowMessageBox(MessageBoxButtons.OK);
		}


		private void btnCustom1y2_Click(object sender, EventArgs e)
		{
			if (!chkWinforms.Checked)
			{
				DialogBox.DialogButton[] btns = new DialogBox.DialogButton[] { new DialogBox.DialogButton("Custom 1 (Ok)", DialogBoxResult.Ok), new DialogBox.DialogButton("Custom 2 (Cancel)", DialogBoxResult.Cancel) };
				txtRes.Text = Forms.DialogBox.Show(txtMensaje.Text, txtCaption.Text, btns, GetDialogBoxIcon(), GetTitleText(), 1, timeOut: GetTimeout(), disable: GetDeshabilitado()).ToString();
			}
		}

		#endregion Eventos

		private string ShowDialogBox(DialogBoxButtons btns)
		{
			return Forms.DialogBox.Show(GetMessage(), txtCaption.Text, btns, GetDialogBoxIcon(), GetTitleText(), 1, timeOut: GetTimeout(), disable: GetDeshabilitado()).ToString();
		}

		private string ShowMessageBox(MessageBoxButtons btns)
		{
			return System.Windows.Forms.MessageBox.Show(GetMessage(), txtCaption.Text, MessageBoxButtons.OK, GetWinformsIcon(), defaultButton: MessageBoxDefaultButton.Button1).ToString();
		}

		private string GetMessage()
		{
			if (String.IsNullOrEmpty(txtMensaje.Text)) return null;

			return txtMensaje.Text;
		}

		private MessageBoxIcon GetWinformsIcon()
		{
			if (rdAsterisk.Checked) { return MessageBoxIcon.Asterisk; }
			else if (rdQuestion.Checked) { return MessageBoxIcon.Question; }
			else if (rdError.Checked) { return MessageBoxIcon.Error; }
			else if (rdExclamation.Checked) { return MessageBoxIcon.Exclamation; }
			else { return MessageBoxIcon.None; }
		}

		private DialogBoxIcon GetDialogBoxIcon()
		{
			if (rdAsterisk.Checked) { return DialogBoxIcon.Asterisk; }
			else if (rdQuestion.Checked) { return DialogBoxIcon.Question; }
			else if (rdError.Checked) { return DialogBoxIcon.Error; }
			else if (rdExclamation.Checked) { return DialogBoxIcon.Exclamation; }
			else { return DialogBoxIcon.None; }
		}

		private string GetTitleText()
		{
			if (chkTitle.Checked) return txtTitle.Text;
			else return "";
		}

		private int GetTimeout()
		{
			int.TryParse(txtTimeout.Text, out int res);
			return res;
		}

		private int GetDeshabilitado()
		{
			int.TryParse(txtDeshabilitado.Text, out int res);
			return res;
		}

	}
}
