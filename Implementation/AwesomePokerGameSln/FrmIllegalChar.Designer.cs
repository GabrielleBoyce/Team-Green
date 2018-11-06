namespace AwesomePokerGameSln
{
    partial class FrmIllegalChar
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
            this.labelIllegalChar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelIllegalChar
            // 
            this.labelIllegalChar.AutoSize = true;
            this.labelIllegalChar.Location = new System.Drawing.Point(41, 187);
            this.labelIllegalChar.Name = "labelIllegalChar";
            this.labelIllegalChar.Size = new System.Drawing.Size(685, 25);
            this.labelIllegalChar.TabIndex = 0;
            this.labelIllegalChar.Text = "Please only use text. Numbers and special characters are not allowed.";
            // 
            // FrmIllegalChar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelIllegalChar);
            this.Name = "FrmIllegalChar";
            this.Text = "FrmIllegalChar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIllegalChar;
    }
}