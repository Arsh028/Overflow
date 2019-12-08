using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject Playbutton;
    public GameObject Instrbutton;
    public GameObject quitbutton;
    public GameObject text;
    public GameObject backmenubutton;
    public void Playgame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exitgame()
    {
        Application.Quit();
    }
    public void backmenuu()
    {
        SceneManager.LoadScene("menu");
    }
    public void InstructionButton()
    {
        Playbutton.SetActive(false);
        Instrbutton.SetActive(false);
        quitbutton.SetActive(false);
        text.SetActive(true);
        backmenubutton.SetActive(true);
    }
}
