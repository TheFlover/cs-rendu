using System;

namespace Morpion
{
    public class Affichage
    {
        static public void Afficher(int[,] grille, Joueur joueur)
        {
            int x, y, compteur = 0;

            Console.Clear();
            Console.Write("\n\n		Au tour de " + joueur.Name + "		Appuyez sur une de ces touches\n");
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
            Console.Write("\n		+---+---+---+			+---+---+---+\n\n\n");
        }
    }
}
