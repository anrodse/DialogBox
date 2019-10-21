using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace anrodse.Forms
{
	public class DialogBox
	{
		#region static

		public static DialogBoxResult Show(string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 0, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(null, text, caption, buttons, icon, defaultButton, timeOut, timeoutResult, disable); }

		public static DialogBoxResult Show(IWin32Window owner, string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 0, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{
			DialogBoxForm dg = new DialogBoxForm()
			{
				Message = text,
				Caption = caption,
				Image = icon,
				DefaultButton = defaultButton,
				Timeout = timeOut,
				TimeoutResult = timeoutResult,
				Disable = disable,
			};

			dg.AddButtons(buttons);

			return dg.ShowDialog(owner);
		}

		#endregion static

	}
}
