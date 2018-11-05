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
            money = 513;

            // Josh: converts player's money to chips
            convertMoneyToChips(money);
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

        // Pass in the VALUE of the poker chip you want to convert and this method will:
        // remove the higher valued one from the list
        // add the appropriate amount of lesser valued chips
        public void convertChip(int val)
        {
            // See if you can remove that chip
            Boolean removed = false;
            for(int i = 0; i < chips.Count; i++)
            {
                if(val == chips[i].getValue())
                {
                    chips.Remove(chips[i]);
                    removed = true;
                    break;
                }
            }

            if (removed)
            {
                // Add the appropriate amount of lesser valued chips
                if(val == 100)
                {
                    chips.Add(new Chip(25));
                    chips.Add(new Chip(25));
                    chips.Add(new Chip(25));
                    chips.Add(new Chip(25));
                }
                else if(val == 25)
                {
                    chips.Add(new Chip(10));
                    chips.Add(new Chip(10));
                    chips.Add(new Chip(5));
                }
                else if(val == 10)
                {
                    chips.Add(new Chip(5));
                    chips.Add(new Chip(5));
                }
                else if(val == 5)
                {
                    chips.Add(new Chip(1));
                    chips.Add(new Chip(1));
                    chips.Add(new Chip(1));
                    chips.Add(new Chip(1));
                    chips.Add(new Chip(1));
                }
                else
                {
                    Console.WriteLine("ERROR: Can not convert chip.");
                }
            }
        }

        // Gives the player the smallest number of chips based on their money
        public void convertMoneyToChips(int money)
        {
            chips = new List<Chip>();
            Boolean converting = true;
            int valAttempt = 100;
            while (converting)
            {
                if(money >= valAttempt){
                    chips.Add(new Chip(valAttempt));
                    money -= valAttempt;
                }
                else if(money > 0)
                {
                    if(valAttempt == 100)
                    {
                        valAttempt = 25;
                    }
                    else if(valAttempt == 25)
                    {
                        valAttempt = 10;
                    }
                    else if(valAttempt == 10)
                    {
                        valAttempt = 5;
                    }
                    else if(valAttempt == 5)
                    {
                        valAttempt = 1;
                    }
                }
                else
                {
                    converting = false;
                }
            }
        }
    }
}
