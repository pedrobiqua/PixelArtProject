using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour
{
    [Header("Pontuação do Personagem")]
    public int pontuacaoTotal;
    public Text scoreText;
    public GameObject gameOver;

    public static GameContoller instance;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScoreText()
    {
        scoreText.text = pontuacaoTotal.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true); //Seta algo que estava desativado para true
    }

    public void RestartGame(string name)
    {
        SceneManager.LoadScene(name);
    }
}
