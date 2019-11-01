using System;
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
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.None, DialogBoxIcon.Error, 1).ToString();
		}

		private void btnOkCancel_Click(object sender, EventArgs e)
		{
			string mensajeLargo =
									"Texto largooooooooooooooooooooo \r\n" +
									"Líena nueva\r\n" +
									"Última línea\r\n";

			txtRes.Text = Forms.DialogBox.Show(mensajeLargo, "Titulo DialogBox", DialogBoxButtons.OkCancel, DialogBoxIcon.Stop).ToString();
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
				defaultButton: 1
				).ToString();
		}

		private void btnAbortRetryIgnore_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.AbortRetryIgnore).ToString();
		}

		private void btnAbortRetryIgnoreIgnoreAll_Click(object sender, EventArgs e)
		{
			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", DialogBoxButtons.AbortRetryIgnoreIgnoreAll, defaultButton: 2).ToString();
		}

		private void btnNone_Click(object sender, EventArgs e)
		{
			string mensajeLargo = "Línea 1\r\n" +
										"Texto largooooooooooooooooooooo jejejejs fas fda rojwe asodfha uisdjkfhasjlfh awrjlshvujawsdn ñojlqwkeafjlasdnvm,ansd jlgahwrljs erjl hgeroljgjsld,nasfjlf nower herjl jler gjlse nfgjklsdf klsdb gksdf jklsfdgjkls fjksl hgjksdf hjksd hjklsd fhgjksfgsfz sdgasf fs jejejejs fas fda rojwe asodfha uisdjkfhasjlfh awrjlshvujawsdn ñojlqwkeafjlasdnvm,ansd jlgahwrljs erjl hgeroljgjsld,nasfjlf nower herjl jler gjlse nfgjklsdf klsdb gksdf jklsfdgjkls fjksl hgjksdf hjksd hjklsd fhgjksfgsfz sdgasf fs jejejejs fas fda rojwe asodfha uisdjkfhasjlfh awrjlshvujawsdn ñojlqwkeafjlasdnvm,ansd jlgahwrljs erjl hgeroljgjsld,nasfjlf nower herjl jler gjlse nfgjklsdf klsdb gksdf jklsfdgjkls fjksl hgjksdf hjksd hjklsd fhgjksfgsfz sdgasf fs \r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Líena nueva\r\n" +
										"Última línea\r\n";

			txtRes.Text = Forms.DialogBox.Show(mensajeLargo, "Titulo DialogBox", DialogBoxButtons.None).ToString();
		}

		private void btnCustom1y2_Click(object sender, EventArgs e)
		{
			DialogBox.DialogButton[] btns = new DialogBox.DialogButton[] { new DialogBox.DialogButton("Custom 1 (Ok)", DialogBoxResult.Ok), new DialogBox.DialogButton("Custom 2 (Cancel)", DialogBoxResult.Cancel) };

			txtRes.Text = Forms.DialogBox.Show("Test de DialogBox", "Titulo DialogBox", btns).ToString();
		}
	}
}
