using System;

namespace Aquarium_Practice_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Cells aq = new Cells();
            aq.create();

            //Barricades

            Console.WriteLine("Enter count of barricades:");
            int Barricades = Convert.ToInt32(Console.ReadLine());

            //Seaweeds
            Console.WriteLine("Enter count of seaweeds:");
            int Seaweeds = Convert.ToInt32(Console.ReadLine());


            //Seaweed energy
            Console.WriteLine("Enter Energy(EnergyMax = 200) Increase per iteration for seaweed:");
            int SEnergyAdd = Convert.ToInt32(Console.ReadLine());


            Seaweed S = new Seaweed();

            S.EnergyIncrease = SEnergyAdd;

            Barricade B = new Barricade();

            //Barricades spawn
            for (int i = 0; i < Barricades;  i++)
            {
                aq.spawn(B.name);
            }
            //Seaweed spawn
            for (int i = 0; i < Seaweeds; i++)
            {
                aq.spawn(S.name);
            }

            //Predator 1
            Fish P1 = new Predator();
            P1.isMale = true;
            aq.spawn(P1.name);

            P1.m = aq.m;
            P1.n = aq.n;

            //Predator 2
            Fish P2 = new Predator();
            P2.isMale = false;
            aq.spawn(P2.name);

            P2.m = aq.m;
            P2.n = aq.n;

            //Herbivore 1
            Fish H1 = new Herbivore();
            H1.isMale = false;
            aq.spawn(H1.name);

            H1.m = aq.m;
            H1.n = aq.n;

            //Herbivore 2
            Fish H2 = new Herbivore();
            H2.isMale = false;
            aq.spawn(H2.name);

            H2.m = aq.m;
            H2.n = aq.n;

            //Herbivore 3
            Fish H3 = new Herbivore();
            H3.isMale = true;
            aq.spawn(H3.name);

            H3.m = aq.m;
            H3.n = aq.n;

            //Herbivore 4
            Fish H4 = new Herbivore();
            H4.isMale = true;
            aq.spawn(H4.name);

            H4.m = aq.m;
            H4.n = aq.n;


            while (true)
            {
                //Change name for fish 
                P1.addname();
                P2.addname();
                H1.addname();
                H2.addname();
                H3.addname();
                H4.addname();


                //Seaweed grow
                S.Grow();


                //Predator 1 move-----------------------------------------------------------------------------------------------
                while (true)
                {
                    P1.direct();
                    if (P1.ch == 1 && aq.aquarium[P1.m + P1.ud, P1.n] != B.name )
                    {
                        aq.aquarium[P1.m, P1.n] = "~";
                        P1.move();
                        aq.aquarium[P1.m, P1.n] = P1.name;
                    }
                    else if (P1.ch == 2 && aq.aquarium[P1.m, P1.n + P1.lr] != B.name )
                    {
                        aq.aquarium[P1.m, P1.n] = "~";
                        P1.move();
                        aq.aquarium[P1.m, P1.n] = P1.name;
                    }
                    else
                    {
                        continue;
                    }
                    P1.cyclic();
                    break;
                }
                
                //Predator 2 move-----------------------------------------------------------------------------------------------
                while (true)
                {
                    P2.direct();
                    if (P2.ch == 1 && aq.aquarium[P2.m + P2.ud, P2.n] != B.name)
                    {
                        aq.aquarium[P2.m, P2.n] = "~";
                        P2.move();
                        aq.aquarium[P2.m, P2.n] = P2.name;
                    }
                    else if (P2.ch == 2 && aq.aquarium[P2.m, P2.n + P2.lr] != B.name)
                    {
                        aq.aquarium[P2.m, P2.n] = "~";
                        P2.move();
                        aq.aquarium[P2.m, P2.n] = P2.name;
                    }
                    else
                    {
                        continue;
                    }
                    P2.cyclic();
                    break;
                }
                //Herbivore 1 move------------------------------------------------------------------------------------------------
                while (true)
                {
                    H1.direct();
                    if (H1.ch == 1 && aq.aquarium[H1.m + H1.ud, H1.n] != B.name)
                    {
                        aq.aquarium[H1.m, H1.n] = "~";
                        H1.move();
                        aq.aquarium[H1.m, H1.n] = H1.name;
                    }
                    else if (H1.ch == 2 && aq.aquarium[H1.m, H1.n + H1.lr] != B.name)
                    {
                        aq.aquarium[H1.m, H1.n] = "~";
                        H1.move();
                        aq.aquarium[H1.m, H1.n] = H1.name;
                    }
                    else
                    {
                        continue;
                    }
                    //Seaweed eat
                    if (aq.aquarium[H1.m-1,H1.n] == S.name || aq.aquarium[H1.m + 1, H1.n] == S.name || aq.aquarium[H1.m, H1.n + 1] == S.name || aq.aquarium[H1.m, H1.n - 1] == S.name)
                    {
                        int eat = H1.EnergyMax - H1.EnergyCurrent;

                        if (S.EnergyCurrent > eat)
                        {
                            H1.EnergyCurrent = H1.EnergyMax;
                            S.EnergyCurrent = S.EnergyCurrent - eat;
                        }
                        else if (S.EnergyCurrent < eat)
                        {
                            H1.EnergyCurrent = H1.EnergyCurrent + S.EnergyCurrent;
                            S.EnergyCurrent = 0;
                        }
                            
                    }
                    H1.cyclic();
                    break;
                }
                //Herbivore 2 move------------------------------------------------------------------------------------------------
                while (true)
                {
                    H2.direct();
                    if (H2.ch == 1 && aq.aquarium[H2.m + H2.ud, H2.n] != B.name)
                    {
                        aq.aquarium[H2.m, H2.n] = "~";
                        H2.move();
                        aq.aquarium[H2.m, H2.n] = H2.name;
                    }
                    else if (H2.ch == 2 && aq.aquarium[H2.m, H2.n + H2.lr] != B.name)
                    {
                        aq.aquarium[H2.m, H2.n] = "~";
                        H2.move();
                        aq.aquarium[H2.m, H2.n] = H2.name;
                    }
                    else
                    {
                        continue;
                    }
                    //Seaweed eat
                    if (aq.aquarium[H2.m - 1, H2.n] == S.name || aq.aquarium[H2.m + 1, H2.n] == S.name || aq.aquarium[H2.m, H2.n + 1] == S.name || aq.aquarium[H2.m, H2.n - 1] == S.name)
                    {
                        int eat = H2.EnergyMax - H2.EnergyCurrent;

                        if (S.EnergyCurrent > eat)
                        {
                            H2.EnergyCurrent = H2.EnergyMax;
                            S.EnergyCurrent = S.EnergyCurrent - eat;
                        }
                        else if (S.EnergyCurrent < eat)
                        {
                            H2.EnergyCurrent = H2.EnergyCurrent + S.EnergyCurrent;
                            S.EnergyCurrent = 0;
                        }

                    }
                    H2.cyclic();
                    break;
                }
                //Herbivore 3 move------------------------------------------------------------------------------------------------
                while (true)
                {
                    H3.direct();
                    if (H3.ch == 1 && aq.aquarium[H3.m + H3.ud, H3.n] != B.name)
                    {
                        aq.aquarium[H3.m, H3.n] = "~";
                        H3.move();
                        aq.aquarium[H3.m, H3.n] = H3.name;
                    }
                    else if (H3.ch == 2 && aq.aquarium[H3.m, H3.n + H3.lr] != B.name)
                    {
                        aq.aquarium[H3.m, H3.n] = "~";
                        H3.move();
                        aq.aquarium[H3.m, H3.n] = H3.name;
                    }
                    else
                    {
                        continue;
                    }
                    //Seaweed eat
                    if (aq.aquarium[H3.m - 1, H3.n] == S.name || aq.aquarium[H3.m + 1, H3.n] == S.name || aq.aquarium[H3.m, H3.n + 1] == S.name || aq.aquarium[H3.m, H3.n - 1] == S.name)
                    {
                        int eat = H3.EnergyMax - H3.EnergyCurrent;

                        if (S.EnergyCurrent > eat)
                        {
                            H3.EnergyCurrent = H3.EnergyMax;
                            S.EnergyCurrent = S.EnergyCurrent - eat;
                        }
                        else if (S.EnergyCurrent < eat)
                        {
                            H3.EnergyCurrent = H3.EnergyCurrent + S.EnergyCurrent;
                            S.EnergyCurrent = 0;
                        }

                    }
                    H3.cyclic();
                    break;
                }
                //Herbivore 4 move------------------------------------------------------------------------------------------------
                while (true)
                {
                    H4.direct();
                    if (H4.ch == 1 && aq.aquarium[H4.m + H4.ud, H4.n] != B.name)
                    {
                        aq.aquarium[H4.m, H4.n] = "~";
                        H4.move();
                        aq.aquarium[H4.m, H4.n] = H4.name;
                    }
                    else if (H4.ch == 2 && aq.aquarium[H4.m, H4.n + H4.lr] != B.name)
                    {
                        aq.aquarium[H4.m, H4.n] = "~";
                        H4.move();
                        aq.aquarium[H4.m, H4.n] = H4.name;
                    }
                    else
                    {
                        continue;
                    }
                    //Seaweed eat
                    if (aq.aquarium[H4.m - 1, H4.n] == S.name || aq.aquarium[H4.m + 1, H4.n] == S.name || aq.aquarium[H4.m, H4.n + 1] == S.name || aq.aquarium[H4.m, H4.n - 1] == S.name)
                    {
                        int eat = H4.EnergyMax - H4.EnergyCurrent;

                        if (S.EnergyCurrent > eat)
                        {
                            H4.EnergyCurrent = H4.EnergyMax;
                            S.EnergyCurrent = S.EnergyCurrent - eat;
                        }
                        else if (S.EnergyCurrent < eat)
                        {
                            H4.EnergyCurrent = H4.EnergyCurrent + S.EnergyCurrent;
                            S.EnergyCurrent = 0;
                        }

                    }
                    H4.cyclic();
                    break;
                }
                aq.show();

                //Condition to end iterations
                if (P1.isDead == true && P2.isDead == true && H1.isDead == true && H2.isDead == true && H3.isDead == true && H4.isDead == true)
                {
                    Console.WriteLine("<<<<<<<<<<<<<<<<<<<< All creatures was dead >>>>>>>>>>>>>>>>>>>>>>>>.");
                    break;
                }
                Console.WriteLine("Press Enter for next iteration");
                string nxt = Convert.ToString(Console.ReadLine());
            }

            
        }
    }
}
