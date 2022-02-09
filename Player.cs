using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public string name;
        public int position = 0;
        public bool jailed = false;
        public int nbTourInJail = 0;

        public Player(string name, int position, bool jailed, int nbTourInJail) //Default Values
        {
            this.name = name;
            this.position = position;
            this.jailed = jailed;
            this.nbTourInJail = nbTourInJail;
        }

        public Player(string name)
        {
            this.name = name;
        }

        public string GetSetName
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int GetSetPosition
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public bool GetSetJailed
        {
            get { return this.jailed; }
            set { this.jailed = value; }
        }

        public int GetSetNbTourInJail
        {
            get { return this.nbTourInJail; }
            set { this.nbTourInJail = value; }
        }

        public void toString()
        {
            Console.WriteLine("Name: " + this.name + "\nPosition: " + this.position + "\nJailed: " + this.jailed + "\nNb of Tour in Jail: " + this.nbTourInJail);
        }
    }
}
