using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium_Practice_
{
    class Seaweed
    {
        static Random rnd = new Random();
        public string name = "S";
        public int EnergyCurrent = rnd.Next(100,200);
        public int EnergyIncrease;
        public static int EnergyMax = 200;
        public void Grow()
        {
            EnergyCurrent = EnergyCurrent + EnergyIncrease;
            if (EnergyCurrent > EnergyMax)
            {
                EnergyCurrent = EnergyMax;
            }
                
        }

    }
}
