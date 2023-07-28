using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : HuyMonoBehaviour
{
    [SerializeField] protected DistanceScore distanceScore;
    [SerializeField] public Transform startBackground;
    [SerializeField] public Transform gameoverBackground;

    [SerializeField] protected TextMeshProUGUI distanceScoreText;

    protected override void Start()
    {
        base.Start();
        Time.timeScale = 0f;
    }

    protected virtual void Update()
    {
        this.DistanceScoreText();
        this.SetScreen();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDistanceScore();
    }

    protected virtual void LoadDistanceScore()
    {
        if (this.distanceScore != null) return;
        this.distanceScore = GameObject.Find("DistanceCounting").GetComponent<DistanceScore>();
    }

    public virtual void PauseIsClicked()
    {
        Time.timeScale = 0f;
    }

    public virtual void PlayButtonIsClicked()
    {
        this.distanceScore.distanceCount = 0f;
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

    protected virtual void DistanceScoreText()
    {
        this.distanceScoreText.text = distanceScore.distanceCount.ToString() + "m";
    }

    public virtual void MenuButtonIsClicked()
    {
        SceneManager.LoadScene(0);
    }

    protected virtual void SetScreen()
    {
        Screen.SetResolution(540, 960, FullScreenMode.Windowed);
    }
}
