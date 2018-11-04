﻿using AwesomePokerGameSln.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardType = System.Tuple<int, int>;

namespace AwesomePokerGameSln {
    public partial class FrmPlaygame : Form {
        private Deck deck;
        private PictureBox[] playerCardPics;
        private PictureBox[] dealerCardPics;
        private Hand playerHand;
        private Hand dealerHand;
        private int round = 0;

        public FrmPlaygame() {
            InitializeComponent();
            playerCardPics = new PictureBox[5];
            for (int c = 1; c <= 5; c++) {
                playerCardPics[c - 1] = this.Controls.Find("picCard" + c.ToString(), true)[0] as PictureBox;
            }
            dealerCardPics = new PictureBox[5];
            for (int c = 1; c <= 5; c++) {
                dealerCardPics[c - 1] = this.Controls.Find("pictureBox" + c.ToString(), true)[0] as PictureBox;
            }
        }

        private void dealCards() {

            deck.shuffleDeck();
            Tuple<int, int>[] cards = new Tuple<int, int>[5]; 

            int index = 0;
            playerHand = new Hand(cards);
            foreach (PictureBox playerCardPic in playerCardPics) {
                CardType card = deck.nextCard();
                //CardType card = new CardType(index, inde);
                cards[index++] = card;
                playerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card, playerHand.isHidden());
            }

            cards = new CardType[5];
            index = 0;
            dealerHand = new Hand(cards);

            // Josh: TEST hide dealer's cards
            //dealerHand.setHidden(true);

            foreach (PictureBox dealerCardPic in dealerCardPics) {
                CardType card = deck.nextCard();
                //CardType card = new CardType(index, inde);
                cards[index++] = card;
                dealerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card, dealerHand.isHidden());
            }
            lblHandType.Text = playerHand.getHandType().ToString();

            while (true)
            {
                if (round == 0)
                {
                    //Place bets

                    round++;
                }
                break;
            }

            // MadG: Logic for winning, losing, drawing
            if (playerHand.getHandScore() > dealerHand.getHandScore()) {
                lblWinLose.Text = "LOSE...";
            }
            else if (playerHand.getHandScore() == dealerHand.getHandScore()) {
                lblWinLose.Text = "DRAW!";
            }
            else {
                lblWinLose.Text = "WIN!";
            }

            label1.Text = "Money: " + Player.Instance.getTotalMoney(); // Josh: show player's total money
            Player.Instance.sortMoney();
            pictureBox6.Image = drawMoney();
        }

        // Used to show all the player's poker chips
        private Bitmap drawMoney()
        {
            Bitmap image = new Bitmap(100, 100);
            Graphics myGraph = Graphics.FromImage(image);
            Rectangle rect = new Rectangle(0, 0, 60, 60);
            Pen pen = new Pen(Color.Red);

            int xCount = 0;
            int yCount = 0;
            foreach(Chip chip in Player.Instance.getChips())
            {
                pen.Color = chip.getColor();
                rect = new Rectangle(xCount * 15, yCount * 15, 10, 10);
                myGraph.DrawRectangle(pen, rect);

                xCount++;
                if(xCount == 6)
                {
                    yCount++;
                    xCount = 0;
                }
            }
            return image;
        }

        private void FrmPlaygame_FormClosed(object sender, FormClosedEventArgs e) {
            Player.Instance.savePlayerMoney(Player.Instance.getName(), Player.Instance.getMoney());
            Application.Exit(); // Gabrielle: Added this because it crashed every time I tried to close it 
            //Adam: I think this comment info goes into the description when you merge branches and not in the code

    }

    private void FrmPlaygame_Load(object sender, EventArgs e) {
      deck = new Deck();
      dealCards();
    }

    private void button1_Click(object sender, EventArgs e) {
      dealCards();
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gamblingAddictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gabrielle : gambling addiction form generated when "Gambling Addiction?" is clicked
            frmGamblingAddiction gamblingAddictionForm = new frmGamblingAddiction();
            gamblingAddictionForm.Show();
        }
            // Gabrielle: send a report form generated when "Send A Report" is clicked
        private void sendAReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport reportForm = new frmReport();
            reportForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dealCards();
        }

        private void picCard1_Click(object sender, EventArgs e)
        {
            picHilight1.Visible = !picHilight1.Visible;
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            picHilight2.Visible = !picHilight2.Visible;
        }

        private void picCard3_Click(object sender, EventArgs e)
        {
            picHilight3.Visible = !picHilight3.Visible;
        }

        private void picCard4_Click(object sender, EventArgs e)
        {
            picHilight4.Visible = !picHilight4.Visible;
        }

        private void picCard5_Click(object sender, EventArgs e)
        {
            picHilight5.Visible = !picHilight5.Visible;
        }

        // Gabrielle : View Rules button displays rules in play game
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules viewRules = new Rules();
            viewRules.Show();
        }
    }
}
