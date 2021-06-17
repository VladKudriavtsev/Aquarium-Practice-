using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium_Practice_
{
    class Fish
    {
        //Fish stats
        static Random rnd = new Random();
        public string name;
        public int _Age_Current = rnd.Next(1, 20);
        int _Age_Max = 35;
        protected int _Age_BeginMature = 10;
        protected int _Age_EndMature = 30;
        public int EnergyCurrent = rnd.Next(40, 100);
        public int EnergyMax = 100;
        public int EnergyDecrease = 5;
        public bool isMale;
        protected bool isPregnant;
        int PregnancyCurrent;
        int PregnancyLength = 5;
        int ChildCount;
        int ChildMax;
        public int m;
        public int n;
        public int ud;
        public int lr;
        public int ch;
        public bool isDead = false;

        //Fish name
        public void addname()
        {
            if (isDead == false && _Age_Current != _Age_Max)
            {
                if (isMale == true && name.Contains("M") == false)
                {
                    name = name + "M";
                }
                else if (isMale == false && name.Contains("F") == false)
                {
                    name = name + "F";
                }
                if (_Age_Current < _Age_BeginMature && name.Contains("1") == false)
                {
                    name = name + "1";
                }
                else if (_Age_Current >= _Age_BeginMature - 1 && _Age_Current < _Age_EndMature && name.Contains("2") == false)
                {
                    if (name.Contains("1") == true)
                    {
                        name = name.Replace("1", "2");
                    }
                    else
                    {
                        name = name + "2";
                    }
                }
                else if (_Age_Current >= _Age_EndMature - 1 && name.Contains("3") == false)
                {
                    if (name.Contains("2") == true)
                    {
                        name = name.Replace("2", "3");
                    }
                    else
                    {
                        name = name + "3";
                    }


                }
                if (isMale == false)
                {
                    if (isPregnant == true && name.Contains("+") == false)
                    {
                        name = name + "+";
                    }
                    else
                    {
                        if (name.Contains("-") == false)
                        {
                            name = name + "-";
                        }

                    }
                }
            }
            else if (name.Contains("X") == false)
            {
                isDead = true;
                name = name + "X";
                EnergyDecrease = 2;
            }


        }
        //Fish move
        public void direct()
        {
            while (isDead == false)
            {
                ud = rnd.Next(-1, 2);
                lr = rnd.Next(-1, 2);
                ch = rnd.Next(1, 3);
                if (ud != 0 && lr != 0)
                {
                    break;
                }

            }
        }
        public void move()
        {
            if (EnergyCurrent <= 0 && name.Contains("X") == false)
            {
                EnergyCurrent = 0;
                isDead = true;
                name = name + "X";
            }
            if (isDead == false)
            {
                if (ch == 1)
                {
                    m = m + ud;
                }
                else if (ch == 2)
                {
                    n = n + lr;
                }
            }
        }
        public void cyclic()
        {
            if (EnergyCurrent <= 0 && name.Contains("X") == false)
            {
                EnergyCurrent = 0;
                isDead = true;
                name = name + "X";
            }
            if (EnergyCurrent != 0 || name.Contains("X") == false)
            {
                EnergyCurrent = EnergyCurrent - EnergyDecrease;
            }
            if (isDead == false)
            {
                _Age_Current++;
            }
            Console.WriteLine($"----------------------------------------------------\n Name:{name}\nCurrent age:{_Age_Current}\nCurrent energy: {EnergyCurrent}");

        }
    }
}
