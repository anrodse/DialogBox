using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace anrodse.Forms.Demo
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.Run(new Principal());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Excepcion: " + ex.Message + "\r\n" + ex.StackTrace);
			}
		}

	}
}
