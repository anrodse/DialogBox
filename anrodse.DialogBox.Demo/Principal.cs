using anrodse.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace anrodse.Forms.Demo
{
	public partial class Principal : Form
	{
		public Principal()
		{
			InitializeComponent();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.None).ToString();
		}

		private void btnOkCancel_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.OkCancel, icon: DialogBoxIcon.Asterisk).ToString();
		}

		private void btnRetryCancel_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.RetryCancel).ToString();
		}

		private void btnYesNo_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.YesNo).ToString();
		}

		private void btnYesNoCancel_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox",
				"Titulo DialogBox",
				DialogBoxButtons.YesNoCancel,
				timeOut: 10000,
				disable: 2000,
				defaultButton: MessageBoxDefaultButton.Button1
				).ToString();
		}

		private void btnAbortRetryIgnore_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.AbortRetryIgnore).ToString();
		}

		private void btnAbortRetryIgnoreIgnoreAll_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.AbortRetryIgnoreIgnoreAll).ToString();
		}

		private void btnNone_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.None).ToString();
		}
	}
}
