using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public float strokes;
    public float par;
    public bool gameActive;
    public GameObject scorePanel;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        strokes = 0;
        par = 5;
        gameActive = true;
    }

    
    void Update()
    {
        if(!gameActive)
        {
            scoreText.text = "Score: " + strokes;
            scorePanel.gameObject.SetActive(true);
        }
    }

    public void replayRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MinigolfMenu");
    }
}
