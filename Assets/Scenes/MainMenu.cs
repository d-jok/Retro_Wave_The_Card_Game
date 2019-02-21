using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public AudioSource audio;

    public bool Play = false;
    public bool Settings = false;
    public bool Exit = false;
    public bool Exit1 = false;
    public bool audioCheck = true;

   
    void Start ()
    {
       /* camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;*/
    }
      
    void Update ()
    {

    }

    private void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.white;
    }

    void OnMouseUp()
    {

        switch (gameObject.name)
        {
            case "New Game":
                SceneManager.LoadScene("Assets/Scenes/Game.unity");
                break;

            case "Settings":
                //Debug.Log("Drag ended!");
                camera1.enabled = false;
                camera2.enabled = true;
                break;

            case "Exit":
                camera1.enabled = false;
                camera3.enabled = true;
                break;

            case "Sound":
                if (audioCheck == true)
                {
                    audio.Stop();
                    audioCheck = false;
                }
                else if(audioCheck == false)
                {
                    audio.Play();
                    audioCheck = true;
                }
                break;

            case "Exit1":
                camera1.enabled = true;
                camera2.enabled = false;
                break;

            case "Yes":
                Application.Quit();
                break;
            case "No":
                camera3.enabled = false;
                camera1.enabled = true;
                break;
        }

    }

}
