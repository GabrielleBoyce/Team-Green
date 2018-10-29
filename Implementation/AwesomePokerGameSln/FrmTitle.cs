using AwesomePokerGameSln.Properties;
using AwesomePokerGameSln.Code;
using System;
using System.Windows.Forms;

namespace AwesomePokerGameSln {
  public partial class FrmTitle : Form {
    public FrmTitle() {
      InitializeComponent();
    }

    private void btnQuit_Click(object sender, EventArgs e) {
            Application.Exit();
    }

    private void btnViewRuleBook_Click(object sender, EventArgs e) {
      if (btnViewRuleBook.Text.StartsWith("View", true, null)) {
        picRulebook.Visible = true;
        btnViewRuleBook.Text = "Close Rule Book";
      }
      else {
        picRulebook.Visible = false;
        btnViewRuleBook.Text = "View Rule Book";
      }
    }

    private void btnNewGame_Click(object sender, EventArgs e) {
      FrmPlaygame frmPlaygame = new FrmPlaygame();
      frmPlaygame.Show();
      Hide();
    }
  }
}
