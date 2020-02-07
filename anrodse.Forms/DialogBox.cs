using System.Windows.Forms;

namespace anrodse.Forms
{
	public class DialogBox
	{

		#region static

		public static DialogBoxResult Show(string text)
		{ return Show((IWin32Window)null, text, "", DialogBoxButtons.Ok); }
		public static DialogBoxResult Show(IWin32Window owner, string text)
		{ return Show(owner, text, "", DialogBoxButtons.Ok); }

		public static DialogBoxResult Show(string text, string caption)
		{ return Show((IWin32Window)null, text, caption, DialogBoxButtons.Ok); }
		public static DialogBoxResult Show(IWin32Window owner, string text, string caption)
		{ return Show(owner, text, caption, DialogBoxButtons.Ok); }

		public static DialogBoxResult Show(string title, string text, string caption)
		{ return Show((IWin32Window)null, text, caption, DialogBoxButtons.Ok, title: title); }
		public static DialogBoxResult Show(IWin32Window owner, string title, string text, string caption)
		{ return Show(owner, text, caption, DialogBoxButtons.Ok, title: title); }

		public static DialogBoxResult Show(string title, string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show((IWin32Window)null, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }
		public static DialogBoxResult Show(IWin32Window owner, string title, string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(owner, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }

		public static DialogBoxResult Show(string title, string text, string caption = "", DialogButton[] buttons = null, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(null, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }
		public static DialogBoxResult Show(IWin32Window owner, string title, string text, string caption = "", DialogButton[] buttons = null, DialogBoxIcon icon = DialogBoxIcon.None, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(owner, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }

		public static DialogBoxResult Show(string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, string title = null, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(null, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }
		public static DialogBoxResult Show(string text, string caption = "", DialogButton[] buttons = null, DialogBoxIcon icon = DialogBoxIcon.None, string title = null, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{ return Show(null, text, caption, buttons, icon, title, defaultButton, timeOut, timeoutResult, disable); }

		#region Constructores

		public static DialogBoxResult Show(IWin32Window owner, string text, string caption = "", DialogBoxButtons buttons = DialogBoxButtons.Ok, DialogBoxIcon icon = DialogBoxIcon.None, string title = null, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{
			DialogBoxForm dg = new DialogBoxForm()
			{
				Title = title,
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

		public static DialogBoxResult Show(IWin32Window owner, string text, string caption = "", DialogButton[] buttons = null, DialogBoxIcon icon = DialogBoxIcon.None, string title = null, int defaultButton = 1, int timeOut = 0, DialogBoxTimeoutResult timeoutResult = DialogBoxTimeoutResult.Timeout, int disable = 0)
		{
			DialogBoxForm dg = new DialogBoxForm()
			{
				Title = title,
				Message = text,
				Caption = caption,
				Image = icon,
				DefaultButton = defaultButton,
				Timeout = timeOut,
				TimeoutResult = timeoutResult,
				Disable = disable,
			};

			if (buttons == null) buttons = new DialogButton[] { new DialogButton("Ok", DialogBoxResult.Ok) };

			foreach (DialogButton btn in buttons)
			{
				dg.AddButton(btn.Text, btn.Result);
			}

			return dg.ShowDialog(owner);
		}

		#endregion Constructores

		#endregion static

		#region Clases auxiliares

		public class DialogButton
		{
			public string Text { get; set; }

			public DialogBoxResult Result { get; set; }

			public DialogButton(string text, DialogBoxResult result)
			{
				Text = text;
				Result = result;
			}

		}

		#endregion Clases auxiliares

	}
}
