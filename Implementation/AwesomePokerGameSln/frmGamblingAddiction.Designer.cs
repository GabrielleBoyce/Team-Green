namespace AwesomePokerGameSln
{
    partial class frmGamblingAddiction
    {
        /*
         * Gabrielle: The form for gambling addiction that pops up when "Gambling Addiction? is clicked
         *  from the tool bar 
         **/
         
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HotlineNumber = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AwesomePokerGameSln.Properties.Resources.Background_Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(885, 490);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HotlineNumber
            // 
            this.HotlineNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HotlineNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.HotlineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.HotlineNumber.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HotlineNumber.Location = new System.Drawing.Point(0, 0);
            this.HotlineNumber.Name = "HotlineNumber";
            this.HotlineNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HotlineNumber.Size = new System.Drawing.Size(885, 36);
            this.HotlineNumber.TabIndex = 1;
            this.HotlineNumber.Text = "The National helpline is: 1-800-522-4700";
            this.HotlineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox1.Location = new System.Drawing.Point(0, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(885, 452);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "\r\n\r\n\r\nThe National Problem Gamling Helpline Network is here to help. \r\n\r\nYou are " +
    "not alone. \r\n\r\nText or call.\r\n\r\n24/7. 100% Confidential.\r\n\r\n";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox2.Location = new System.Drawing.Point(0, 452);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(885, 36);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "To voice chat, please visit www.npcgambling.org/chat ";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmGamblingAddiction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 488);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HotlineNumber);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmGamblingAddiction";
            this.Text = "National Helpline";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox HotlineNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}