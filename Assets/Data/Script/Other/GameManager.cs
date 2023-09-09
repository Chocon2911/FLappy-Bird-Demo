using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : HaoMonoBehaviour
{
  
    [SerializeField] public Transform startBackground;
    [SerializeField] public Transform gameoverBackground;

    [SerializeField] protected TextMeshProUGUI ScoreText;
    [SerializeField] protected TextMeshProUGUI ScoreEndText;
    [SerializeField] protected TextMeshProUGUI HighScoreText;

    private int highScore=0;

    protected override void Start()
    {
        base.Start();
        Time.timeScale = 0f;
       
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore =PlayerPrefs.GetInt("HighScore");
        }
        
    }

    protected virtual void Update()
    {
        this.GameScoreText();
        GameEndScoreText();


    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDistanceScore();
    }

    protected virtual void LoadDistanceScore()
    {
       
      
    }

    public virtual void PauseIsClicked()
    {
        Time.timeScale = 0f;
    }

    public virtual void PlayButtonIsClicked()
    {
       
        Time.timeScale = 1f;
        startBackground.gameObject.SetActive(false);
    }

    public virtual void QuitButtonIsClicked()
    {
        Application.Quit();
    }

    public virtual void RestartButtonIsClicked()
    {
        Time.timeScale = 1f;
        gameoverBackground.gameObject.SetActive(false);
    }

    protected virtual void GameScoreText()
    {
        this.ScoreText.text = Score.score.ToString()+"";
    }
    protected virtual void GameEndScoreText()
    {   if(Score.score >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score.score);
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        this.ScoreEndText.text = "Diem : "+Score.score.ToString() ;
        this.HighScoreText.text="HighScore : "+highScore.ToString() ;
      
    }

    public virtual void MenuButtonIsClicked()
    {
        Score.score = 0;
        SceneManager.LoadScene(0);
       
    }

    
}
