namespace anrodse.Forms.Demo
{
	partial class Principal
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOk = new System.Windows.Forms.Button();
			this.txtRes = new System.Windows.Forms.TextBox();
			this.lblRes = new System.Windows.Forms.Label();
			this.btnOkCancel = new System.Windows.Forms.Button();
			this.btnRetryCancel = new System.Windows.Forms.Button();
			this.btnYesNo = new System.Windows.Forms.Button();
			this.btnYesNoCancel = new System.Windows.Forms.Button();
			this.btnAbortRetryIgnore = new System.Windows.Forms.Button();
			this.btnAbortRetryIgnoreIgnoreAll = new System.Windows.Forms.Button();
			this.btnNone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(48, 32);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// txtRes
			// 
			this.txtRes.Location = new System.Drawing.Point(308, 136);
			this.txtRes.Name = "txtRes";
			this.txtRes.Size = new System.Drawing.Size(100, 20);
			this.txtRes.TabIndex = 1;
			// 
			// lblRes
			// 
			this.lblRes.AutoSize = true;
			this.lblRes.Location = new System.Drawing.Point(244, 139);
			this.lblRes.Name = "lblRes";
			this.lblRes.Size = new System.Drawing.Size(58, 13);
			this.lblRes.TabIndex = 2;
			this.lblRes.Text = "Resultado:";
			// 
			// btnOkCancel
			// 
			this.btnOkCancel.Location = new System.Drawing.Point(129, 32);
			this.btnOkCancel.Name = "btnOkCancel";
			this.btnOkCancel.Size = new System.Drawing.Size(75, 23);
			this.btnOkCancel.TabIndex = 0;
			this.btnOkCancel.Text = "Ok Cancel";
			this.btnOkCancel.UseVisualStyleBackColor = true;
			this.btnOkCancel.Click += new System.EventHandler(this.btnOkCancel_Click);
			// 
			// btnRetryCancel
			// 
			this.btnRetryCancel.Location = new System.Drawing.Point(210, 32);
			this.btnRetryCancel.Name = "btnRetryCancel";
			this.btnRetryCancel.Size = new System.Drawing.Size(92, 23);
			this.btnRetryCancel.TabIndex = 0;
			this.btnRetryCancel.Text = "Retry Cancel";
			this.btnRetryCancel.UseVisualStyleBackColor = true;
			this.btnRetryCancel.Click += new System.EventHandler(this.btnRetryCancel_Click);
			// 
			// btnYesNo
			// 
			this.btnYesNo.Location = new System.Drawing.Point(308, 32);
			this.btnYesNo.Name = "btnYesNo";
			this.btnYesNo.Size = new System.Drawing.Size(75, 23);
			this.btnYesNo.TabIndex = 0;
			this.btnYesNo.Text = "Yes No";
			this.btnYesNo.UseVisualStyleBackColor = true;
			this.btnYesNo.Click += new System.EventHandler(this.btnYesNo_Click);
			// 
			// btnYesNoCancel
			// 
			this.btnYesNoCancel.Location = new System.Drawing.Point(389, 32);
			this.btnYesNoCancel.Name = "btnYesNoCancel";
			this.btnYesNoCancel.Size = new System.Drawing.Size(96, 23);
			this.btnYesNoCancel.TabIndex = 0;
			this.btnYesNoCancel.Text = "Yes No Cancel";
			this.btnYesNoCancel.UseVisualStyleBackColor = true;
			this.btnYesNoCancel.Click += new System.EventHandler(this.btnYesNoCancel_Click);
			// 
			// btnAbortRetryIgnore
			// 
			this.btnAbortRetryIgnore.Location = new System.Drawing.Point(141, 70);
			this.btnAbortRetryIgnore.Name = "btnAbortRetryIgnore";
			this.btnAbortRetryIgnore.Size = new System.Drawing.Size(116, 23);
			this.btnAbortRetryIgnore.TabIndex = 0;
			this.btnAbortRetryIgnore.Text = "Abort Retry Ignore";
			this.btnAbortRetryIgnore.UseVisualStyleBackColor = true;
			this.btnAbortRetryIgnore.Click += new System.EventHandler(this.btnAbortRetryIgnore_Click);
			// 
			// btnAbortRetryIgnoreIgnoreAll
			// 
			this.btnAbortRetryIgnoreIgnoreAll.Location = new System.Drawing.Point(263, 70);
			this.btnAbortRetryIgnoreIgnoreAll.Name = "btnAbortRetryIgnoreIgnoreAll";
			this.btnAbortRetryIgnoreIgnoreAll.Size = new System.Drawing.Size(147, 23);
			this.btnAbortRetryIgnoreIgnoreAll.TabIndex = 0;
			this.btnAbortRetryIgnoreIgnoreAll.Text = "Abort Retry Ignore IgnoreAll";
			this.btnAbortRetryIgnoreIgnoreAll.UseVisualStyleBackColor = true;
			this.btnAbortRetryIgnoreIgnoreAll.Click += new System.EventHandler(this.btnAbortRetryIgnoreIgnoreAll_Click);
			// 
			// btnNone
			// 
			this.btnNone.Location = new System.Drawing.Point(60, 70);
			this.btnNone.Name = "btnNone";
			this.btnNone.Size = new System.Drawing.Size(75, 23);
			this.btnNone.TabIndex = 0;
			this.btnNone.Text = "None";
			this.btnNone.UseVisualStyleBackColor = true;
			this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
			// 
			// Principal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 181);
			this.Controls.Add(this.lblRes);
			this.Controls.Add(this.txtRes);
			this.Controls.Add(this.btnAbortRetryIgnoreIgnoreAll);
			this.Controls.Add(this.btnAbortRetryIgnore);
			this.Controls.Add(this.btnYesNoCancel);
			this.Controls.Add(this.btnYesNo);
			this.Controls.Add(this.btnRetryCancel);
			this.Controls.Add(this.btnOkCancel);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnOk);
			this.Name = "Principal";
			this.Text = "Principal";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtRes;
		private System.Windows.Forms.Label lblRes;
		private System.Windows.Forms.Button btnOkCancel;
		private System.Windows.Forms.Button btnRetryCancel;
		private System.Windows.Forms.Button btnYesNo;
		private System.Windows.Forms.Button btnYesNoCancel;
		private System.Windows.Forms.Button btnAbortRetryIgnore;
		private System.Windows.Forms.Button btnAbortRetryIgnoreIgnoreAll;
		private System.Windows.Forms.Button btnNone;
	}
}