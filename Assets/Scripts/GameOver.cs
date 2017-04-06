using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // (0) or ("MainScene") is the same, we use SceneManager.GetActiveScene().buildIndex for the current scene, in case we have changed the scene name or number
    }

    public void Menu ()
    {
        Debug.Log("Go to menu");
    }

}
