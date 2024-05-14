using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject loseUI;

    public int score;

    public Text InGameScoreText;

    public GameObject winUI;

    public Text loseScoreText, winScoreText;



    // Start is called before the first frame update
    void Start()
    {   
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }
     public void StartApp() 
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "Your Score" + score;
        InGameScoreText.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LevelEnd()
    {

        loseUI.SetActive(true);
        loseScoreText.text = "Your Score" + score;
        InGameScoreText.gameObject.SetActive(false);
    }

    public void AddScore(int pointValue)
    {
        score += pointValue;
        InGameScoreText.text = "Score: " + score;
    }
   

    public void AppQuit() 
    {
        Application.Quit();
    }

}
