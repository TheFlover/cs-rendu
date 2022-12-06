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
        static public bool TestVictoire(int[,] grille, int Numero)
        {
            int i;
            if ((grille[0,0] == Numero) && (grille[1,1] == Numero) && (grille[2,2] == Numero))
            {
                return true;
            }
            if ((grille[0,2] == Numero) && (grille[1,1] == Numero) && (grille[2,0] == Numero))
            {
                return true;
            }
            for (i = 0; i < 3; i++)
            {
                if ((grille[i,0] == Numero) && (grille[i,1] == Numero) && (grille[i,2] == Numero))
                {
                    return true;
                }
            }
            for (i = 0; i < 3; i++)
            {
                if ((grille[0,i] == Numero) && (grille[1,i] == Numero) && (grille[2,i] == Numero))
                {
                    return true;
                }
            }
            return false;
        }

        static public bool TestEgalite(int[,] grille)
        {
            int x, y;
            for (y = 0; y < 3; y++)
            {
                for (x = 0; x < 3; x++)
                {
                    if (grille[y,x] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}