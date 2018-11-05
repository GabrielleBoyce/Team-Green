using AwesomePokerGameSln.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomePokerGameSln
{
    public partial class Preferences : Form
    {

        public Preferences()
        {
            InitializeComponent();
        }

        private void image_handler(String resourcename)
        {
            FrmPlaygame.change_background(Resources.ResourceManager.GetObject(resourcename) as Bitmap);
        }

        private void button1_Click(object sender, EventArgs e) // Gabrielle: Classic
        {
            image_handler("Background_Red");
        }

        private void button2_Click(object sender, EventArgs e) // Gabrielle: Catastrophe
        {
            image_handler("Background_Cats");
        }

        private void button3_Click(object sender, EventArgs e) // Gabrielle: Oasis
        {
            image_handler("Background_Blue");
        }

        private void button4_Click(object sender, EventArgs e) // Gabrielle: Scholarly
        {
            image_handler("Background_Green");
        }

        private void button5_Click(object sender, EventArgs e) // Gabrielle: Wooden
        {
            image_handler("Background_Wood");
        }

        private void button6_Click(object sender, EventArgs e) // Gabrielle: Oranges
        {
            image_handler("Background_Orange");
        }

        private void button7_Click(object sender, EventArgs e) // Gabrielle: Stargaze
        {
            image_handler("Background_Stars");
        }

        private void button8_Click(object sender, EventArgs e) // Gabrielle: Concrete
        {
            image_handler("Background_Gray");
        }
    }
}
