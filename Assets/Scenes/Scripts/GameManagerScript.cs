using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public string[] Tab = new string[9];
    public GameObject gameOverPanel;

    private AI ai = new AI();

    private void Start()
    {
        int turn = Random.Range(0, 2);
        if (turn == 0)
        {
            ComputerPlay();
        }
    }

    /* L'oridinateur joue son tour.
     * Il vérifie la présence ou non d'un coup gagnat pour lui ou son adversaire
     * Si l'un des deux est vraie, il va jouer en conséquence et soit gagner, soit bloquer son adversaire
     * Sinon il choisit un emplcament aléatoire du tableau et pose un rond
     * Enfin, on contrôle à nouveau si l'un des deux joueurs à gagner, et le cas échéant on colorie les cases gagnantes
     * Sinon on vérifie s'il y a match nulle, et dans le dernier cas, c'ets de nouveau au tour du joueur de jouer*/

    public void ComputerPlay()
    { 
        int button = ai.getBestPosition();

        Button btn = GameObject.Find(button.ToString()).GetComponent<Button>();
        btn.interactable = false;
        btn.GetComponentInChildren<Text>().text = "O";

        Tab[button] = "O";

        if (isWinner("O"))
        {
            gameOverPanel.SetActive(true);
            return;
        }

        if (isTabFull())
        {
            Debug.Log("Match Nul");
            colorNullBlue();
            gameOverPanel.SetActive(true);
            return;
        }
    }

    /* Vérifie chaque possibilité de victoire (vertical, horizontal, diagonal)
     * S'il y a une occurence on retourne true, sinon false*/

    public bool isWinner(string letter)
    {
        if (Tab[0] == letter && Tab[1] == letter && Tab[2] == letter) {
            colorWinnersCase(0, 1, 2);
            return true;
        }

        if (Tab[3] == letter && Tab[4] == letter && Tab[5] == letter)
        {
            colorWinnersCase(3, 4, 5);
            return true;
        }

        if (Tab[6] == letter && Tab[7] == letter && Tab[8] == letter)
        {
            colorWinnersCase(6, 7, 8);
            return true;
        }

        if (Tab[0] == letter && Tab[3] == letter && Tab[6] == letter)
        {
            colorWinnersCase(0, 3, 6);
            return true;
        }

        if (Tab[1] == letter && Tab[4] == letter && Tab[7] == letter)
        {
            colorWinnersCase(1, 4, 7);
            return true;
        }

        if (Tab[2] == letter && Tab[5] == letter && Tab[8] == letter)
        {
            colorWinnersCase(2, 5, 8);
            return true;
        }

        if (Tab[0] == letter && Tab[4] == letter && Tab[8] == letter)
        {
            colorWinnersCase(0, 4, 8);
            return true;
        }

        if (Tab[2] == letter && Tab[4] == letter && Tab[6] == letter)
        {
            colorWinnersCase(2, 4, 6);
            return true;
        }
        return false;
    }

    /*Colorie les cases du gagnant en rouge*/

    public void colorWinnersCase(int case1, int case2, int case3)
    {
        GameObject.Find(case1.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
        GameObject.Find(case2.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
        GameObject.Find(case3.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
    }

    /* Colorie toutes les cases en bleu pour signifier un match nulle*/

    public void colorNullBlue()
    {
        for(int i = 0; i < Tab.Length; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.blue;
        }
    }

    /* Vérifie s'il reste des chaînes de caractères vides dans le tableau*/

    public bool isTabFull()
    {
        for (int i = 0; i < Tab.Length; i++)
        {
            if (Tab[i] == string.Empty)
            {
                return false;
            }
        }
        return true;
    }
}
