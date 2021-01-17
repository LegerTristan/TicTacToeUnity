using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayGameOver : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Relance la partie lorsque le joueur clique sur n'importe quelle bouton
        if (Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
