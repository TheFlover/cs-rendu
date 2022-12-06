using System;

namespace Morpion
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Morpion";
            Console.Clear();

            Joueur joueur1 = new Joueur();
            joueur1.Numero = 1;
            Console.Write("Entrez le nom du joueur 1 : ");
            string? input = Console.ReadLine();
            joueur1.Name = string.IsNullOrEmpty(input) ? "Joueur 1" : input;

            Joueur joueur2 = new Joueur();
            joueur2.Numero = 2;
            Console.Write("Entrez le nom du joueur 2 : ");
            input = Console.ReadLine();
            joueur2.Name = string.IsNullOrEmpty(input) ? "Joueur 2" : input;

            Joueur[] joueurs = new Joueur[2] {joueur1, joueur2};
            int joueurEnCours = 0;

            int[,] grilleMorpion = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            
            bool jeu = true;
            while(jeu == true)
            {
                
                bool partie = false;

                Affichage.Afficher(grilleMorpion, joueurs, joueurEnCours);
                Console.Write($"Pour jouer tapez : J\nPour quitter tapez : Q\n\nJ ou Q : ");
                input = Console.ReadLine();
                if (input == "J")
                {
                    partie = true;
                    grilleMorpion = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                }
                else if (input == "Q")
                {
                    Environment.Exit(0);
                }
                
                while(partie == true)
                {
                    bool tour = true;
                    Affichage.Afficher(grilleMorpion, joueurs, joueurEnCours);
                    while (tour == true)
                    {
                        joueurs[joueurEnCours].AppuiTouche();
                        if(Controles.VerifTouche(grilleMorpion, joueurs[joueurEnCours].Touche) == true)
                        {
                            int x, y, compteurTouche = 0;
                            for (y = 0; y < 3; y++)
                            {
                                for (x = 0; x < 3; x++)
                                {
                                    compteurTouche++;
                                    if (compteurTouche == joueurs[joueurEnCours].Touche)
                                    {
                                        grilleMorpion[y,x] = joueurs[joueurEnCours].Numero;

                                        if (Controles.TestVictoire(grilleMorpion, joueurs[joueurEnCours].Numero) == true)
                                        {
                                            joueurs[joueurEnCours].Score += 1;
                                            Affichage.Afficher(grilleMorpion, joueurs, joueurEnCours);
                                            Console.Write("Victoire de " + joueurs[joueurEnCours].Name + " !!!\n\n");
                                            partie = false;
                                        }
                                        else if (Controles.TestEgalite(grilleMorpion) == true)
                                        {
                                            Affichage.Afficher(grilleMorpion, joueurs, joueurEnCours);
                                            Console.Write("Egalitee...\n");
                                            partie = false;
                                        }
                                    }
                                }
                            }

                            //Changement de joueur
                            joueurEnCours = (joueurEnCours == 0 ? 1 : 0);
                            tour = false;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez choisi une case deja rempli.");
                        }
                    }
                }
            }
        }
    }
 }
