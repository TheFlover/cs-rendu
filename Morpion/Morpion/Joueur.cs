using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Joueur
{
	public int Score  { get; set; }
    public string Name { get; set; }
    public int Numero { get; set; }
    public int Touche { get; set; }
    public Joueur()
    {
        this.Score = 0;
        this.Name = "Joueur";
        this.Numero = 0;
        this.Touche = 0;
    }

    public void AppuiTouche()
    {
        this.Touche = 0;
        while (this.Touche == 0)
        {
            Console.Write($"\n{this.Name}, tapes une touche entre 1 et 9 : ");
            this.Touche = int.Parse(Console.ReadLine());
            if ((this.Touche > 9) || (this.Touche < 1))
            {
                Console.Write("\nLa touche doit etre entre 1 et 9.");
                this.Touche = 0;
            }
        }
    }
}
