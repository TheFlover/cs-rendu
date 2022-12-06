using System;

namespace Morpion
{
    public class Affichage
    {
        static public void Afficher(int[,] grille, Joueur[] joueurs, int joueurEnCours)
        {
            int x, y, compteur = 0;

            Console.Clear();
            Console.Write("\n   Score " + joueurs[0].Name + " = " + joueurs[0].Score + "\n");
            Console.Write("   Score " + joueurs[1].Name + " = " + joueurs[1].Score + "\n\n");
            Console.Write("		Au tour de " + joueurs[joueurEnCours].Name + "		Appuyez sur une de ces touches\n");
            for (y = 0; y < 3; y++)
            {
                Console.Write("\n		+---+---+---+			+---+---+---+\n		|");
                for(x = 0; x < 3; x++)
                {
                    if (grille[y,x] == 1)
                    {
                        Console.Write(" O |");
                    }
                    else
                    {
                        if (grille[y,x] == 2)
                        {
                            Console.Write(" X |");
                        }
                        else
                        {
                            if (grille[y,x] == 0)
                            {
                                Console.Write("   |");
                            }
                        }
                    }
                }
                Console.Write("			|");
                for (x = 0; x < 3; x++)
                {
                    compteur++;
                    Console.Write(" " + compteur + " |");
                }
            }
            Console.Write("\n		+---+---+---+			+---+---+---+\n\n");
        }
    }
}
