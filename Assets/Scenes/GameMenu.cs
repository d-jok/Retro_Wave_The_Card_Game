using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

    public GameObject star;
    public GameObject Tap_Exit;
    public bool OpenMenu = false;
    public bool Exit = false;

    // Use this for initialization
    void Start ()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && OpenMenu == false)
        {
            OpenMenu = true;
            star.transform.position = new Vector3(0, 50, 40);
            Tap_Exit.transform.position = new Vector3(-1, 50, 39);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && OpenMenu == true)
        {
            star.transform.position = new Vector3(-35, 50, 40);
            Tap_Exit.transform.position = new Vector3(-35, 50, 39);
            OpenMenu = false;
        }
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
            case "Exit":
                SceneManager.LoadScene("Assets/Scenes/main menu.unity");
                break;
        }
    }
}
