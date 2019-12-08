using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject HighScoreText;
    public GameObject RestartButton;
    public GameObject BackButton;
    public GameManager Backtomenubutton;
    public Text Highscoredisplaytext;
    public Text ScoreText;
    public GameObject Levelup;
    public GameObject ball;
    public GameObject LooseText;
    public GameObject Bounceincreasedtext;
    public GameObject delaydecreasedtext;
    bool GameEndsBitch = false;
    int score = 0;
    public float delay = 0.7f;
    public float bounce=0.6f;
    int k;
    int HighScore = 0;
    public int countertimes=0;
    public Rigidbody2D rb;
    public PhysicsMaterial2D bouncy;
    public void Start()
    {
        ScoreText.text = "" + score;
        InvokeRepeating("instantiatee", 1f, delay);
        HighScore = PlayerPrefs.GetInt("HighScore");
        Highscoredisplaytext.text = "" + HighScore;
    }
    public void instantiatee()
    {
        var RandomPos = new Vector2(Random.Range(-6.24f, 6.24f), Random.Range(-10.6f, 9.5f));
        for(int t=0;t<=countertimes;t++)
        {
            Instantiate(ball, RandomPos, Quaternion.identity);
        }
    }
    public void ScoreUp()
    {
        if (GameEndsBitch==false)
        {
            if (score != 0 && score % 8 == 0)
            {
                if (delay >= 0.5)
                {
                    Debug.Log("delay decreased");
                    Levelup.SetActive(true);
                    Mathf.Round(delay);
                    delay -= 0.04f;
                    Invoke("removeLevelup", 0.6f);
                    delaydecreasedtext.SetActive(true);
                    Invoke("removedelaydecreasedtext", 0.7f); 
                }
                else
                {
                    Debug.Log("current bounciness=" + bounce);
                    Mathf.Round(bounce);
                    bounce += 0.02f;
                    bouncy.bounciness = bounce;
                    Mathf.Round(bounce);
                    Debug.Log("bounce increased to:" + bounce);
                    Levelup.SetActive(true);
                    Invoke("removeLevelup", 0.7f);
                    Bounceincreasedtext.SetActive(true);
                    Invoke("removeincreasedbouncetext", 0.7f);
                    if (bounce >= 0.7)
                    {
                        Debug.Log("increased bounce=" + bounce);
                        delay = 0.8f;

                    }
                }
            }
            if(score!=0 && score%14==0)
            { countertimes++; }
            if (k == 0)
            {
                if (score > PlayerPrefs.GetInt("Highscore",HighScore))
                {
                    k = 1;
                    HighScore = score;
                    PlayerPrefs.SetInt("HighScore", score);
                    DisplayHighScore();
                    Invoke("RemoveDisplayHighScore", 1.5f);
                }
            }
            if (k == 1)
            {
                PlayerPrefs.SetInt("Highscore", score);
            }
            score++;
            Debug.Log("score=" + score);
            ScoreText.text = "" + score;
        }
    }
    public void removedelaydecreasedtext()
    {
        delaydecreasedtext.SetActive(false);
    }
    public void removeincreasedbouncetext()
    {
        Bounceincreasedtext.SetActive(false);
    }
    public void removeLevelup()
    {
        Levelup.SetActive(false);
    }
    public void DisplayHighScore()
    {
        HighScoreText.SetActive(true);
    }
    public void RemoveDisplayHighScore()
    {
        HighScoreText.SetActive(false);
    }
    public void Restart()
    {
        countertimes = 0;
        k = 0;
        bounce = 0.6f;
        GameEndsBitch = false;
        SceneManager.LoadScene("Game");
    }
    public void Back()
    {
        countertimes = 0;
        bounce = 0.6f;
        k = 0;
        GameEndsBitch = false;
        SceneManager.LoadScene("Menu");
    }
    public void GameHasEnded()
    {
        countertimes = 0;
        k = 0;
        GameEndsBitch = true;
        CancelInvoke("instantiatee");
        LooseText.SetActive(true);
        RestartButton.SetActive(true);
        BackButton.SetActive(true);
    }
}
