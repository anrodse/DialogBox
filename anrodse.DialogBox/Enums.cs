using System;
using System.Collections.Generic;
using System.Text;

namespace anrodse.Forms
{
	/// <summary>
	/// DialogBox icons
	/// </summary>
	public enum DialogBoxIcon
	{
		None = 0,
		Hand = 16,
		Stop = 16,
		Error = 16,
		Question = 32,
		Exclamation = 48,
		Warning = 48,
		Asterisk = 64,
		Information = 64,
	}

	/// <summary>
	/// Results that can be returned from DialogBox
	/// </summary>
	public enum DialogBoxResult
	{
		None = 0,
		Ok = 1,
		Cancel = 2,
		Abort = 3,
		Retry = 4,
		Ignore = 5,
		Yes = 6,
		No = 7,

		IgnoreAll = 10,
		Timeout = 11,
	}

	/// <summary>
	/// Results that can be returned when DialogBox times out
	/// </summary>
	public enum DialogBoxTimeoutResult
	{
		/// <summary>
		/// On timeout, default button is set as result
		/// </summary>
		Default,

		/// <summary>
		/// On timeout, cancel/no button is set as result. If no cancel/no button
		/// available, the default button is set as the result.
		/// </summary>
		Cancel,

		/// <summary>
		/// On timeout, Timeout is set as result. Default value.
		/// </summary>
		Timeout
	}


	/// <summary>
	/// Standard DialogBox buttons
	/// </summary>
	public enum DialogBoxButtonOp
	{
		None = 0,
		Ok = 1,
		Cancel = 2,
		Yes = 4,
		No = 8,
		Abort = 16,
		Retry = 32,
		Ignore = 64,
		IgnoreAll = 128,
	}

	/// <summary>
	/// Standard DialogBox buttons
	/// </summary>
	public enum DialogBoxButtons
	{
		None = 0,
		Ok = 1,
		OkCancel = 3,
		YesNo = 12,
		YesNoCancel = 14,
		RetryCancel = 34,
		AbortRetryIgnore = 112,
		AbortRetryIgnoreIgnoreAll = 240,
	}
}
