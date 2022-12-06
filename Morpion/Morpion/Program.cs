

//nomme l'interface

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Title = "Morpion";
        
        bool partie = true;
        int[,] grilleMorpion = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        Joueur joueur1 = new Joueur();
        joueur1.Name = "Florian";
        joueur1.Numero = 1;
        joueur1.Score = 0;

        Joueur joueur2 = new Joueur();
        joueur2.Name = "Nicolas";
        joueur2.Numero = 2;
        joueur2.Score = 0;

        joueur2.AppuiTouche();
        Console.WriteLine(joueur2.Touche);
    }
}