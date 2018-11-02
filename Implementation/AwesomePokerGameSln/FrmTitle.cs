using AwesomePokerGameSln.Properties;
using AwesomePokerGameSln.Code;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

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

    //action for when selectPlayer is clicked
    private void selectPlayer_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> playerInfo = Player.Instance.getPlayerInfo();
            int numberOfPlayers = playerInfo.Keys.Count;
            FrmSelectPlayer frmselectPlayer = new FrmSelectPlayer();
            Button[] playerChoiceButton = new Button[numberOfPlayers];

            //go through the players and create a button for each one
            int i = 0;
            foreach(KeyValuePair<string,int> player in playerInfo)
            {
                int index = i; //important for selecting player (DONT USE i when refering to certian button)
                playerChoiceButton[i] = new System.Windows.Forms.Button();
                playerChoiceButton[i].Text = player.Key + " with $" + player.Value;
                playerChoiceButton[i].Width = frmselectPlayer.Width;
                playerChoiceButton[i].Click += (NewSender, args) => playerChoiceButton_Click(playerChoiceButton[index], 
                    index,player.Key,player.Value, frmselectPlayer);

                if (i >= 1)
                {
                    playerChoiceButton[i].Location = new System.Drawing.Point(0, playerChoiceButton[i - 1].Height * i);
                }
                i++;
            }
            
            //add all the buttons to the form
            for (int j = 0; j<numberOfPlayers; j++)
            {
                frmselectPlayer.Controls.Add(playerChoiceButton[j]);
            }
            
            frmselectPlayer.Show();

        }
    
    //anon button click action; Changes Player instance to reflect selected character
    private void playerChoiceButton_Click(Button playerChoice, int index, string name, int money, FrmSelectPlayer frmSelectPlayer)
        {
            Player.Instance.setName(name);
            Player.Instance.setMoney(money);
            frmSelectPlayer.Hide();
        }
    
    //add player click action (still needs logic; will add later)
    private void addPlayer_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ADD PLAYER");
            frmAddplayer addPlayer = new frmAddplayer();
            addPlayer.Show();
        }

        // Gabrielle:  gambling addiction form generated when "Gambling Addiction?" is clicked
        private void gamblingAddictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGamblingAddiction gamblingAddictionForm = new frmGamblingAddiction();
            gamblingAddictionForm.Show();
        }
    }
}
