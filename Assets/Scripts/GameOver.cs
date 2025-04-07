using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText; // Arraste o texto de pontuação da UI para este campo
    private PointManager pointManager;

    void Start()
    {
        pointManager = FindAnyObjectByType<PointManager>();
        gameObject.SetActive(false); // Desativa a tela inicialmente
    }

    public void ShowScreen()
    {
        if (pointManager != null)
        {
            // Usa pointManager.score para acessar a variável correta
            scoreText.text = "Final Score: " + pointManager.score;
            scoreText.color = Color.yellow;
        }
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Cave_1");
    }
}