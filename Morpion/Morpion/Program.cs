using System;

namespace Morpion
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Morpion";
            
            Joueur joueur1 = new Joueur();
            joueur1.Name = "Florian";
            joueur1.Numero = 1;
            joueur1.Score = 0;

            Joueur joueur2 = new Joueur();
            joueur2.Name = "Nicolas";
            joueur2.Numero = 2;
            joueur2.Score = 0;

            int[,] grilleMorpion = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            
            

            Affichage.Afficher(grilleMorpion, joueur1);

            joueur2.AppuiTouche();
            Console.WriteLine(joueur2.Touche);
        }
    }
}