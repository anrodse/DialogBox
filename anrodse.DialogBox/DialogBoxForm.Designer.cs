namespace anrodse.Forms
{
	partial class DialogBoxForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBoxForm));
			this.pnIcono = new System.Windows.Forms.Panel();
			this.pnFooter = new System.Windows.Forms.Panel();
			this.lblMensaje = new System.Windows.Forms.Label();
			this.pnBody = new System.Windows.Forms.Panel();
			this.pnBody.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnIcono
			// 
			this.pnIcono.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnIcono.Location = new System.Drawing.Point(10, 10);
			this.pnIcono.Name = "pnIcono";
			this.pnIcono.Padding = new System.Windows.Forms.Padding(10);
			this.pnIcono.Size = new System.Drawing.Size(49, 49);
			this.pnIcono.TabIndex = 0;
			// 
			// pnFooter
			// 
			this.pnFooter.BackColor = System.Drawing.SystemColors.Control;
			this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnFooter.Location = new System.Drawing.Point(0, 69);
			this.pnFooter.Name = "pnFooter";
			this.pnFooter.Padding = new System.Windows.Forms.Padding(9);
			this.pnFooter.Size = new System.Drawing.Size(184, 42);
			this.pnFooter.TabIndex = 1;
			// 
			// lblMensaje
			// 
			this.lblMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblMensaje.Location = new System.Drawing.Point(59, 10);
			this.lblMensaje.Name = "lblMensaje";
			this.lblMensaje.Padding = new System.Windows.Forms.Padding(10);
			this.lblMensaje.Size = new System.Drawing.Size(115, 49);
			this.lblMensaje.TabIndex = 2;
			this.lblMensaje.Text = "label1";
			this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnBody
			// 
			this.pnBody.Controls.Add(this.lblMensaje);
			this.pnBody.Controls.Add(this.pnIcono);
			this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnBody.Location = new System.Drawing.Point(0, 0);
			this.pnBody.Name = "pnBody";
			this.pnBody.Padding = new System.Windows.Forms.Padding(10);
			this.pnBody.Size = new System.Drawing.Size(184, 69);
			this.pnBody.TabIndex = 3;
			// 
			// DialogBoxForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(184, 111);
			this.Controls.Add(this.pnBody);
			this.Controls.Add(this.pnFooter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(200, 13);
			this.Name = "DialogBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.DialogBoxForm_Load);
			this.pnBody.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnIcono;
		private System.Windows.Forms.Panel pnFooter;
		private System.Windows.Forms.Label lblMensaje;
		private System.Windows.Forms.Panel pnBody;
	}
}