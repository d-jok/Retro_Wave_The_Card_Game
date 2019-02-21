using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour {

    public GameObject ButtonExit;
    public GameObject ButtonPlayAgain;

    private void Start()
    {
        ButtonExit.SetActive(false);
        ButtonPlayAgain.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Assets/Scenes/main menu.unity");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Assets/Scenes/Game.unity");
    }

}
