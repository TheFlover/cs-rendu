using System;

namespace Morpion
{
    public class Controles
    {
        static public bool VerifTouche(int[,] grille, int touche)
        {
            int x, y, compteur = 0;
            for (y = 0; y < 3; y++)
            {
                for (x = 0; x < 3; x++)
                {
                    compteur++;
                    if (compteur == touche)
                    {
                        if (grille[y,x] == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}