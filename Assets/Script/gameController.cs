using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject gameOverscreen;
    public GameObject winScreen;

    private void Start()
    {
        darah.playerMati += GameOverScene;
        piala.playerMenang += winScene;
        gameOverscreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void winScene()
    {
            winScreen.SetActive(true); 
    }
    void GameOverScene()
    {
        gameOverscreen.SetActive(true);

    }

}
