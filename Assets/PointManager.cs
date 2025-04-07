using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject victoryScreen;
    // Start is called before the first frame update
    private int winScore = 1000;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        if (score >= winScore)
        {
            ShowVictoryScreen();
        }
    }

    void ShowVictoryScreen()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true); // Ativa a tela de Game Over
            Time.timeScale = 0f; // Pausa o jogo
        }
    }
}