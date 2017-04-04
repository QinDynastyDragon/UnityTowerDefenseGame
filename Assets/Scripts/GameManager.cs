using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

    public static bool GameIsOver;   // can call this in other script by, GameManager.gameIsOver  ,CAREFUL static variable will carry on to the next scene, which means, next time it will be true

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }


    // Update is called once per frame
    void Update () 
	{
        if (GameIsOver)
            return;

        //if (Input.GetKeyDown("e"))
        //{
        //    EndGame();
        //}

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }


}
