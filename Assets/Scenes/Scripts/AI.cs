using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{

    public List<int> choice = new List<int>();
    string[] TabAI = new string[9];

    /* L'ordinateur recherche la meilleure case pour poser un rond*/
    public int getBestPosition()
    {
        // Récup du tableau
        string[] source = GameObject.Find("GameManager").GetComponent<GameManagerScript>().Tab;
        Array.Copy(source, TabAI, source.Length);

        choice.Clear();

        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
            {
                choice.Add(i);
            }
        }

        // Coup gagnant

        for(int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
            {
                TabAI[i] = "O";
                if (haveAChanceToWin("O"))
                {
                    return i;
                }
                TabAI[i] = string.Empty;
            }
            
        }

        // Coup gagnant adversaire

        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
            {
                TabAI[i] = "X";
                if (haveAChanceToWin("X"))
                {
                    return i;
                }
                TabAI[i] = string.Empty;
            }

        }

        //Aléatoire
        return choice[UnityEngine.Random.Range(0, choice.Count)];
    }

    /* Vérifie si l'ordi ou le joueur s'apprête à gagner*/
    bool haveAChanceToWin(string p)
    {
        if (TabAI[0] == p && TabAI[1] == p && TabAI[2] == p ||
             TabAI[3] == p && TabAI[4] == p && TabAI[5] == p ||
             TabAI[6] == p && TabAI[7] == p && TabAI[8] == p ||
             TabAI[0] == p && TabAI[3] == p && TabAI[6] == p ||
             TabAI[1] == p && TabAI[4] == p && TabAI[7] == p ||
             TabAI[2] == p && TabAI[5] == p && TabAI[8] == p ||
             TabAI[0] == p && TabAI[4] == p && TabAI[8] == p ||
             TabAI[2] == p && TabAI[4] == p && TabAI[6] == p)
        {
            return true;
        }
        return false;
    }
}
