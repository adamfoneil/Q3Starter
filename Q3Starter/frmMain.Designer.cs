namespace Q3Starter
{
	partial class frmMain
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
			this.tbGameExe = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbBasePath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbMaps = new System.Windows.Forms.CheckedListBox();
			this.cbProfile = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nudFragLimit = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.btnPlay = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudFragLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// tbGameExe
			// 
			this.tbGameExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbGameExe.Location = new System.Drawing.Point(105, 387);
			this.tbGameExe.Name = "tbGameExe";
			this.tbGameExe.Size = new System.Drawing.Size(498, 21);
			this.tbGameExe.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 390);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Game Exe:";
			// 
			// tbBasePath
			// 
			this.tbBasePath.Location = new System.Drawing.Point(105, 8);
			this.tbBasePath.Name = "tbBasePath";
			this.tbBasePath.Size = new System.Drawing.Size(579, 21);
			this.tbBasePath.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "BaseQ3 Path:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(58, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Maps:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(429, 89);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(255, 255);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// lbMaps
			// 
			this.lbMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbMaps.FormattingEnabled = true;
			this.lbMaps.Location = new System.Drawing.Point(105, 89);
			this.lbMaps.Name = "lbMaps";
			this.lbMaps.Size = new System.Drawing.Size(307, 292);
			this.lbMaps.TabIndex = 7;
			this.lbMaps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbMaps_ItemCheck);
			this.lbMaps.SelectedIndexChanged += new System.EventHandler(this.lbMaps_SelectedIndexChanged);
			// 
			// cbProfile
			// 
			this.cbProfile.FormattingEnabled = true;
			this.cbProfile.Location = new System.Drawing.Point(105, 35);
			this.cbProfile.Name = "cbProfile";
			this.cbProfile.Size = new System.Drawing.Size(201, 21);
			this.cbProfile.TabIndex = 8;
			this.cbProfile.SelectedIndexChanged += new System.EventHandler(this.cbProfile_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(51, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Profile:";
			// 
			// nudFragLimit
			// 
			this.nudFragLimit.Location = new System.Drawing.Point(105, 62);
			this.nudFragLimit.Name = "nudFragLimit";
			this.nudFragLimit.Size = new System.Drawing.Size(70, 21);
			this.nudFragLimit.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(31, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Frag Limit:";
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPlay.Location = new System.Drawing.Point(609, 385);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 12;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(696, 420);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nudFragLimit);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbProfile);
			this.Controls.Add(this.lbMaps);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbBasePath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbGameExe);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Q3Starter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudFragLimit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbGameExe;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbBasePath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.CheckedListBox lbMaps;
		private System.Windows.Forms.ComboBox cbProfile;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudFragLimit;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnPlay;
	}
}

