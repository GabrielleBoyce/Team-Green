using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomePokerGameSln
{
    public partial class frmAddplayer : Form
    {
        public frmAddplayer()
        {
            InitializeComponent();
        }

        private void AddPlayer_Click(object sender, EventArgs e)
        {
            Dictionary<string,int> savedPlayers = AwesomePokerGameSln.Code.Player.Instance.getPlayerInfo();
            //check for illegal character
            if (addPlayerText.Text.Contains(" ") || !Regex.IsMatch(addPlayerText.Text.Trim(), @"^[a-zA-Z]+$"))
            {
                this.Hide();
                FrmIllegalChar badChar = new FrmIllegalChar();
                badChar.Show();
            }
            //check if name is taken
            else if (savedPlayers.Keys.Contains(addPlayerText.Text))
            {
                this.Hide();
                FrmNameTaken takenName = new FrmNameTaken();
                takenName.Show();
            }
            //username is legal
            else
            {
                this.Hide();
                AwesomePokerGameSln.Code.Player.Instance.addPlayer(addPlayerText.Text.Trim(), "500");
            }

        }
    }
}
