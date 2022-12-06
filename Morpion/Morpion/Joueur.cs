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
        Console.Write($"A {this.Name} de saisir un nombre entre 1 et 9 : ");
        while (this.Touche == 0)
        {
            try
            {
                this.Touche = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.Write("Vous n'avez pas saisi un nombre entier.\nSaisissez le nombre : ");
                continue;
            }
            if ((this.Touche > 9) || (this.Touche < 1))
            {
                Console.Write("Vous n'avez pas saisi un nombre entre 1 et 9.\nSaisissez le nombre : ");
                this.Touche = 0;
            }
        }
    }
}
