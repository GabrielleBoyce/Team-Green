namespace AwesomePokerGameSln
{
    partial class FrmNameTaken
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
            this.labelNameTaken = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNameTaken
            // 
            this.labelNameTaken.AutoSize = true;
            this.labelNameTaken.Location = new System.Drawing.Point(203, 218);
            this.labelNameTaken.Name = "labelNameTaken";
            this.labelNameTaken.Size = new System.Drawing.Size(367, 25);
            this.labelNameTaken.TabIndex = 0;
            this.labelNameTaken.Text = "That name is taken. Try Another one.";
            // 
            // FrmNameTaken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNameTaken);
            this.Name = "FrmNameTaken";
            this.Text = "FrmNameTaken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameTaken;
    }
}