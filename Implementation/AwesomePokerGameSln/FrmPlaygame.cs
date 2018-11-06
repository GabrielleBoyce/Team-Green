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

namespace AwesomePokerGameSln
{
    public partial class FrmPlaygame : Form
    {
        private Deck deck;
        private PictureBox[] playerCardPics;
        private PictureBox[] dealerCardPics;
        private Hand playerHand;
        private Hand dealerHand;
        private int round = 0;
        private bool playerFolded = false;
        private bool dealerFolded = false;
        private bool dealerDiscard = false; // MadG: Tells when the dealer is discarding
        private bool[] willDiscard = new bool[5];
        private Random rand = new Random();
        private Tuple<int, int>[] cards = new Tuple<int, int>[5];
        private Tuple<int, int>[] playerCards = new Tuple<int, int>[5]; // MadG: Saves the player's hand
        private Tuple<int, int>[] dealerCards = new Tuple<int, int>[5]; // MadG: Saves the dealer's hand
        private static Bitmap backgroundImage; // Gabrielle: the backgrounds 
        private int moneyPot = 0;
        private int dealerLastBet = 0;

        public FrmPlaygame()
        {
            InitializeComponent();
            playerCardPics = new PictureBox[5];
            for (int c = 1; c <= 5; c++)
            {
                playerCardPics[c - 1] = this.Controls.Find("picCard" + c.ToString(), true)[0] as PictureBox;
            }
            dealerCardPics = new PictureBox[5];
            for (int c = 1; c <= 5; c++)
            {
                dealerCardPics[c - 1] = this.Controls.Find("pictureBox" + c.ToString(), true)[0] as PictureBox;
            }

            this.pictureBox7.BackgroundImage = backgroundImage; // Gabrielle: setting the background
        }

        private void dealCards()
        {
            round = 0;

            deck.shuffleDeck();
            //Tuple<int, int>[] cards = new Tuple<int, int>[5];

            playerHand = new Hand(cards);
            refreshCardPics("player");

            playerCards = cards; // MadG: Saves the cards instance before reused for dealer

            cards = new CardType[5];
            dealerHand = new Hand(cards);
            hideDealerCards();
            refreshCardPics("dealer");

            lblHandType.Text = playerHand.getHandType().ToString();
            lblDealerHand.Text = dealerHand.getHandType().ToString();
            dealerCards = cards;

            turnBase();

            //label1.Text = "Money: " + Player.Instance.getTotalMoney(); // Josh: show player's total money
            // Player.Instance.sortMoney();
            //pictureBox6.Image = drawMoney();
            updateMoney(); // Gabrielle: Moved above lines to method since this will be used a lot 
        }

        public void refreshCardPics(String p)
        {
            int index = 0;
            if (p == "player")
            {
                foreach (PictureBox playerCardPic in playerCardPics)
                {
                    CardType card = deck.nextCard();
                    cards[index++] = card;
                    playerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
            }
            else if (p == "dealer")
            {
                foreach (PictureBox dealerCardPic in dealerCardPics)
                {
                    CardType card = deck.nextCard();
                    cards[index++] = card;
                    dealerCardPic.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
            }
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
            foreach (Chip chip in Player.Instance.getChips())
            {
                pen.Color = chip.getColor();
                rect = new Rectangle(xCount * 15, yCount * 15, 10, 10);
                myGraph.DrawRectangle(pen, rect);

                xCount++;
                if (xCount == 6)
                {
                    yCount++;
                    xCount = 0;
                }
            }
            return image;
        }

        private void FrmPlaygame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Player.Instance.savePlayerMoney(Player.Instance.getName(), Player.Instance.getMoney());
            Application.Exit(); // Gabrielle: Added this because it crashed every time I tried to close it 
                                //Adam: I think this comment info goes into the description when you merge branches and not in the code

        }

        // MadG: How the dealer thinks
        private void dealerThoughts()
        {
            if (round == 0)
            {
                int choice = rand.Next(10);
                if (choice < 9)
                {
                    if (choice == 1 || choice == 2 || choice == 3)
                    {
                        moneyPot += 5;
                        dealerLastBet = 5;
                    }
                    else if (choice == 4 || choice == 5 || choice == 6)
                    {
                        moneyPot += 10;
                        dealerLastBet = 10;
                    }
                    else
                    {
                        moneyPot += 15;
                        dealerLastBet = 15;
                    }
                }
                else
                {
                    dealerFolded = true;
                    dealFold.Visible = true;
                    turnBase();
                }
            }
            else if (round == 1)
            {
                //Have dealer select cards to discard randomly
                for (int i = 0; i < 5; i++)
                {
                    dealerDiscard = true;
                    int d = rand.Next(4); // MadG: less chance of discarding
                    if (d < 3)
                    {
                        willDiscard[i] = false;
                    }
                    else
                    {
                        willDiscard[i] = true;
                    }

                    discard(dealerHand);
                }
            }
            else if (round == 2)
            {
                int choice = rand.Next(10);
                if (choice < 9)
                {
                    if (choice == 1 || choice == 2 || choice == 3)
                    {
                        moneyPot += 5;
                        dealerLastBet = 5;
                    }
                    else if (choice == 4 || choice == 5 || choice == 6)
                    {
                        moneyPot += 10;
                        dealerLastBet = 10;
                    }
                    else
                    {
                        moneyPot += 15;
                        dealerLastBet = 15;
                    }
                }
                else
                {
                    dealerFolded = true;
                    dealFold.Visible = true;
                    turnBase();
                }
            }
            else if (round == 3)
            { //  Gabrielle: Added this cuz the game wouldn't end at the third round
                winLose();
            }
            prizePool.Text = "Prize Pool: " + moneyPot;
        }
        // MadG: Keeps up with turns (maybe can remove?)
        private void turnBase()
        {
            if (!playerFolded && !dealerFolded)
            {
                switch (round)
                {
                    case 0:
                        //Place bets
                        dealerThoughts();
                        break;
                    case 1:
                        //Discard/Redraw
                        dealerThoughts();
                        break;
                    case 3:
                        //Place bets
                        dealerThoughts();
                        break;
                }
            }
            else
            {
                winLose();
            }
        }

        // MadG: Moved discard logic to its own method
        private void discard(Hand x)
        {
            cards = new Tuple<int, int>[5];
            if (!dealerDiscard)
            {
                if (picHilight1.Visible)
                {
                    picHilight1.Visible = !picHilight1.Visible;
                    CardType card = deck.nextCard();
                    cards[0] = card;
                    picCard1.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[0] = playerCards[0];
                }

                if (picHilight2.Visible)
                {
                    picHilight2.Visible = !picHilight2.Visible;
                    CardType card = deck.nextCard();
                    cards[1] = card;
                    picCard2.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[1] = playerCards[1];
                }

                if (picHilight3.Visible)
                {
                    picHilight3.Visible = !picHilight3.Visible;
                    CardType card = deck.nextCard();
                    cards[2] = card;
                    picCard3.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[2] = playerCards[2];
                }

                if (picHilight4.Visible)
                {
                    picHilight4.Visible = !picHilight4.Visible;
                    CardType card = deck.nextCard();
                    cards[3] = card;
                    picCard4.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[3] = playerCards[3];
                }

                if (picHilight5.Visible)
                {
                    picHilight5.Visible = !picHilight5.Visible;
                    CardType card = deck.nextCard();
                    cards[4] = card;
                    picCard5.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[4] = playerCards[4];
                }

                x = new Hand(cards);
                playerHand = x;
                lblHandType.Text = x.getHandType().ToString();
            }
            else
            {
                if (willDiscard[0])
                {
                    CardType card = deck.nextCard();
                    cards[0] = card;
                    pictureBox1.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[0] = dealerCards[0];
                }

                if (willDiscard[1])
                {
                    CardType card = deck.nextCard();
                    cards[1] = card;
                    pictureBox2.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[1] = dealerCards[1];
                }

                if (willDiscard[2])
                {
                    CardType card = deck.nextCard();
                    cards[2] = card;
                    pictureBox3.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[2] = dealerCards[2];
                }

                if (willDiscard[3])
                {
                    CardType card = deck.nextCard();
                    cards[3] = card;
                    pictureBox4.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[3] = dealerCards[3];
                }

                if (willDiscard[4])
                {
                    CardType card = deck.nextCard();
                    cards[4] = card;
                    pictureBox5.BackgroundImage = CardImageHelper.cardToBitmap(card);
                }
                else
                {
                    cards[4] = dealerCards[4];
                }

                x = new Hand(cards);
                dealerHand = x;
                lblDealerHand.Text = x.getHandType().ToString();
                dealerDiscard = false;
            }
        }

        private void winLose()
        {
            // MadG: Logic for winning, losing, drawing
            if (!dealerFolded && !playerFolded)
            {
                if (playerHand.getHandScore() > dealerHand.getHandScore())
                {
                    lblWinLose.Text = "LOSE...";
                }
                else if (playerHand.getHandScore() == dealerHand.getHandScore())
                {
                    lblWinLose.Text = "DRAW!";
                    Player.Instance.addMoney(moneyPot / 2); // MadG: Drawing splits the pot, though I'm pretty sure that's not how it is normally
                    updateMoney();
                }
                else if (playerHand.getHandScore() < dealerHand.getHandScore())
                {
                    lblWinLose.Text = "WIN!";
                    Player.Instance.addMoney(moneyPot);
                    updateMoney();
                }
            }
            else if (dealerFolded)
            {
                //Player.Instance.setMoney(Player.Instance.getMoney() + moneyPot);
                Player.Instance.addMoney(moneyPot);
                updateMoney();
                lblWinLose.Text = "WIN!";
            }
            else if (playerFolded)
            {
                lblWinLose.Text = "FOLDED";
            }

            showDealerCards();

            lblWinLose.Visible = true;
            lblDealerHand.Visible = true;
        }

        private void FrmPlaygame_Load(object sender, EventArgs e)
        {
            deck = new Deck();
            dealCards();
        }

        //Resets everything
        private void button1_Click(object sender, EventArgs e)
        { // Redeal
            lblWinLose.Visible = false;
            lblDealerHand.Visible = false;
            playerFolded = false;
            dealerFolded = false;
            dealFold.Visible = false;
            moneyPot = 0;
            willDiscard = new bool[5];
            dealerDiscard = false;
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

        private void button3_Click(object sender, EventArgs e) // MadG: Discard button
        {
            if (round == 1)
            {
                //Discard cards and redraw
                round++;
                turnBase();
                discard(playerHand);

                dealerThoughts();
            }
        }

        private void picCard1_Click(object sender, EventArgs e)
        {
            if (round == 1)
            {
                picHilight1.Visible = !picHilight1.Visible;
            }
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            if (round == 1)
            {
                picHilight2.Visible = !picHilight2.Visible;
            }
        }

        private void picCard3_Click(object sender, EventArgs e)
        {
            if (round == 1)
            {
                picHilight3.Visible = !picHilight3.Visible;
            }
        }

        private void picCard4_Click(object sender, EventArgs e)
        {
            if (round == 1)
            {
                picHilight4.Visible = !picHilight4.Visible;
            }
        }

        private void picCard5_Click(object sender, EventArgs e)
        {
            if (round == 1)
            {
                picHilight5.Visible = !picHilight5.Visible;
            }
        }

        // Gabrielle : View Rules button displays rules in play game
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules viewRules = new Rules();
            viewRules.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Raise
        {
            if (round == 0 || round == 2)
            {
                // Raise money
                round++;
                turnBase();
                moneyPot += dealerLastBet + 5;
                prizePool.Text = "Prize Pool: " + moneyPot;
                Player.Instance.takeMoney(dealerLastBet + 5);
                updateMoney();
            }
            if (round == 3)
            {
                winLose();
            }
        }

        private void button4_Click(object sender, EventArgs e) // Fold
        {
            if (round == 0 || round == 2)
            {
                // Fold and Lose
                playerFolded = true;
                round++;
                turnBase();
            }

        }

        private void button5_Click(object sender, EventArgs e) // Gabrielle: Call
        {
            if (round == 0)
            {
                Player.Instance.takeMoney(moneyPot);
                updateMoney();
                moneyPot = moneyPot + moneyPot;
                prizePool.Text = "Prize Pool: " + moneyPot;
                round++;
                turnBase();
            }
            if (round == 2)
            {
                // Gabrielle: Waiting on bet logic to be implemented for the dealer
                Player.Instance.takeMoney(dealerLastBet);
                updateMoney();
                moneyPot = moneyPot + dealerLastBet;
                prizePool.Text = "Prize Pool: " + moneyPot;

                round++;
                turnBase();


            }
        }

        public void hideDealerCards()
        {
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
        }

        public void showDealerCards()
        {
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        public static void change_background(Bitmap newimage) // Gabrielle: Changes the background image
        {
            backgroundImage = newimage;
        }

        public void updateMoney()
        {
            label1.Text = "Money: " + Player.Instance.getTotalMoney(); // Josh: show player's total money
            Player.Instance.sortMoney();
            pictureBox6.Image = drawMoney();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
