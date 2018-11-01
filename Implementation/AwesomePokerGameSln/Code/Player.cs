using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePokerGameSln.Code
{
    //(lazy) Singleton Class
    class Player
    {

        private static Player instance;
        private int money;
        private string name;

        private List<Chip> chips;

        private Player()
        {
            name = "guest";
            money = 500;

            chips = new List<Chip>();
            addChip(5);
            addChip(10);
            addChip(5);
            addChip(10);
            addChip(5);
            addChip(10);
            addChip(100);
            addChip(25);
            addChip(10);
            addChip(100);
            addChip(25);
            addChip(10);
            addChip(100);
            addChip(25);
            addChip(10);
            addChip(100);
            addChip(25);
        }

        //get instance
        public static Player Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }

        public int getMoney()
        {
            return money;
        }

        public void setMoney(int amount)
        {
            money = amount;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }


        //get name and money amount stored in Settings.settings
        public Dictionary<string, int> getPlayerInfo()
        {
            Dictionary<string, int> playerMoneyDict = new Dictionary<string, int>(); //map money to player name

            string playerInfo = Properties.Settings.Default.playerInfo.ToString();
            string[] players = playerInfo.Split(',');

            foreach (string player in players)
            {
                if (player == "") continue; //takes care of last comma from split
                string[] playerMoney = player.Split(' ');
                playerMoneyDict.Add(playerMoney[0], Int32.Parse(playerMoney[1]));
            }

            return playerMoneyDict;

        }

        //Add a player to the Settings.settings
        public void addPlayer(string name, string money)
        {
            Properties.Settings.Default.playerInfo = Properties.Settings.Default.playerInfo + "," + name + " " + money;
            //Properties.Settings.Default.playerInfo = "Adam 500";
            Properties.Settings.Default.Save();
        }

        //saves money amount to Settings.settings
        public void savePlayerMoney(string name, int money)
        {
            Dictionary<string, int> playerMoneyDict = getPlayerInfo();
            string saveInfo = "";

            //go thru dictionary and build string; also change money amount for target
            foreach(KeyValuePair<string, int> player in playerMoneyDict)
            {
                if (player.Key == "guest")
                    continue;
                else if (player.Key == name)
                    saveInfo = saveInfo + player.Key + " " + money.ToString() + ","; 
                else
                    saveInfo = saveInfo + player.Key + " " + player.Value.ToString() + ",";
            }

            //write string to settings
            Properties.Settings.Default.playerInfo = saveInfo;
            Properties.Settings.Default.Save();
        }

        public void addChip(int value)
        {
            chips.Add(new Chip(value));
        }

        public int getTotalMoney()
        {
            int money = 0;
            foreach(Chip chip in chips)
            {
                money += chip.getValue();
            }
            return money;
        }

        public List<Chip> getChips()
        {
            return chips;
        }

        public void sortMoney()
        {
            List<Chip> sortedList = new List<Chip>();
            for(int i = 0; i < 5; i++)
            {
                int lookingFor = 0;
                if(i == 0)
                {
                    lookingFor = 1;
                }
                else if(i == 1)
                {
                    lookingFor = 5;
                }
                else if(i == 2)
                {
                    lookingFor = 10;
                }
                else if(i == 3)
                {
                    lookingFor = 25;
                }
                else if(i == 4)
                {
                    lookingFor = 100;
                }
                foreach (Chip chip in chips)
                {
                    if(chip.getValue() == lookingFor)
                    {
                        sortedList.Add(chip);
                    }
                }
            }
            chips = sortedList;
        }
    }
}
