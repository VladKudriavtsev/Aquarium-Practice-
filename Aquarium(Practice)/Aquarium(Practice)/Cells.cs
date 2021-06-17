using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium_Practice_
{
    class Cells
    {
        public string[,] aquarium = new string[45, 15];
        static Random rnd = new Random();
        public int m;
        public int n;
        public int rows;
        public int columns;

        
        public void create()
        {
            rows = aquarium.GetUpperBound(0) + 1;
            columns = aquarium.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    aquarium[i, j] = "~";
                }
            }
        }
        public void show()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{aquarium[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        protected void spBarricades()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0 || i == rows - 1)
                    {
                        aquarium[i, j] = "B";
                    }
                    if (j == 0 || j == columns - 1)
                    {
                        aquarium[i, j] = "B";
                    }
                }
            }
        }
        
        public void spawn(string name)
        {
            spBarricades();
            while (true)
            {
                
                m = rnd.Next(0, 45);
                n = rnd.Next(0, 15);
                if (aquarium[m, n] == "~")
                {
                    aquarium[m, n] = name;
                    break;
                }
                
            }
        }
        
    }
}
