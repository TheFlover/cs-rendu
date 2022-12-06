using System.ComponentModel.DataAnnotations;

namespace Morpion
{
    public enum Symbole 
    {
        SPACE,
        CROIX,
        ROND
    }

    public static class Affichage
    {
        public static string GetSymbole(string nom)
        {
            switch (nom)
            {
                case "SPACE":
                    return " ";

                case "CROIX":
                    return "X";

                case "ROND":
                    return "O";

                default:
                    return " ";
            }
        }

        public static void Afficher(int[,] grille, Joueur[] joueurs, int joueurEnCours)
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
                    string test = GetSymbole(((Symbole)grille[y,x]).ToString());
                    Console.Write(" " + test + " |");
                    // if (grille[y,x] == 1)
                    // {
                    //     Console.Write(" O |");
                    // }
                    // else
                    // {
                    //     if (grille[y,x] == 2)
                    //     {
                    //         Console.Write(" X |");
                    //     }
                    //     else
                    //     {
                    //         if (grille[y,x] == 0)
                    //         {
                    //             Console.Write("   |");
                    //         }
                    //     }
                    // }
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
