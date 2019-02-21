using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    [HideInInspector]
    public bool EndCheck = false;

    private void OnMouseUp()
    {
        FindObjectOfType<GameProcess>().End = true;
        FindObjectOfType<GameProcess>().BotTurn = true;
        Debug.Log("5100");
    }

    void Update()
    {
        if(EndCheck == false)
        {
            Debug.Log("End");
            this.transform.position = new Vector3(30.18f, 50, 49.4f);
        }
        else
        {
            this.transform.position = new Vector3(30, 50, 49);
        }
    }

}
