using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    private GameManagerScript gmScript;

    private void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    /* Remplace le texte vide par un X sur le bouton pressé par la joueur
     * Puis vérifie l'état de la partie (gagné, match nul, perdu)
     * Si la partie n'est pas terminé, c'est au tour de l'ordi
     * Sinon on affiche le panel de GameOver on appelle la méthode liée au statut de la partie */

    public void WriteX()
    {
        GetComponentInChildren<Text>().text = "X";
        GetComponent<Button>().interactable = false;
        gmScript.Tab[int.Parse(gameObject.name)] = "X";

        if (gmScript.isWinner("X"))
        {
            gmScript.gameOverPanel.SetActive(true);
        }
        else if (gmScript.isTabFull())
        {
            Debug.Log("Match Nul");
            gmScript.colorNullBlue();
            gmScript.gameOverPanel.SetActive(true);
        }
        else
        {
            
            gmScript.ComputerPlay();
        } 
    }
}
