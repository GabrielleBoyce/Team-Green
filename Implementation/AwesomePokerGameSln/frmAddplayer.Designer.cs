namespace AwesomePokerGameSln
{
    partial class frmAddplayer
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
            this.addPlayerText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addplayerlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addPlayerText
            // 
            this.addPlayerText.Location = new System.Drawing.Point(104, 211);
            this.addPlayerText.MaxLength = 15;
            this.addPlayerText.Name = "addPlayerText";
            this.addPlayerText.Size = new System.Drawing.Size(291, 31);
            this.addPlayerText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddPlayer_Click);
            // 
            // addplayerlabel
            // 
            this.addplayerlabel.AutoSize = true;
            this.addplayerlabel.Location = new System.Drawing.Point(146, 157);
            this.addplayerlabel.Name = "addplayerlabel";
            this.addplayerlabel.Size = new System.Drawing.Size(207, 25);
            this.addplayerlabel.TabIndex = 2;
            this.addplayerlabel.Text = "Enter Player\'s Name";
            // 
            // frmAddplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addplayerlabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addPlayerText);
            this.Name = "frmAddplayer";
            this.Text = "frmAddplayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addPlayerText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label addplayerlabel;
    }
}