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

            int[,] grilleMorpion = new int[3, 3] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            bool partie = true;
            while(partie == true)
            {
                bool tour = false;
                Affichage.Afficher(grilleMorpion, joueur1);
                while (tour == false)
                {
                    
                    joueur1.AppuiTouche();
                    tour = Controles.VerifTouche(grilleMorpion, joueur1.Touche);
                    if(tour == true)
			        {
                        int x, y, compteurTouche = 0;
                        for (y = 0; y < 3; y++)
                        {
                            for (x = 0; x < 3; x++)
                            {
                                compteurTouche++;
                                if (compteurTouche == joueur1.Touche)
                                {
                                    grilleMorpion[y,x] = joueur1.Numero;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("La touche est invalide");
                    }
                }
            }
        }
    }
}