using AwesomePokerGameSln.Code;
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
            foreach (PictureBox playerCardPic in playerCardPics) {
                CardType card = deck.nextCard();
                //CardType card = new CardType(index, inde);
                cards[index++] = card;
                playerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card);
            }
            playerHand = new Hand(cards);
            cards = new CardType[5];
            index = 0;
            foreach (PictureBox dealerCardPic in dealerCardPics) {
                CardType card = deck.nextCard();
                //CardType card = new CardType(index, inde);
                cards[index++] = card;
                dealerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card);
            }
            dealerHand = new Hand(cards);
            lblHandType.Text = playerHand.getHandType().ToString(); // MadG: I don't know why but player is dealer now

            // MadG: Logic for winning, losing, drawing
            if (playerHand.getHandScore() > dealerHand.getHandScore()) { // MadG: Logic is technically backwards due to player = dealer
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
    }
}
