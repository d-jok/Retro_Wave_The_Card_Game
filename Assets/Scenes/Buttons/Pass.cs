using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour {

    [HideInInspector]
    public bool PassCheck = false;

    private void OnMouseUp()
    {
        FindObjectOfType<GameProcess>().Pass = true;

        if(FindObjectOfType<AttackField>().CardCount < 10) //ETENTION!!!!!
            FindObjectOfType<GameProcess>().BotTurn = true;
        //FindObjectOfType<Bot>().Move();
        //FindObjectOfType<CardMove>().CardOnField = false;
    }

    void Update()
    {
        if (PassCheck == true)
        {
            Debug.Log("Pass");
            this.transform.position = new Vector3(30, 50, 49);
        }
        else
        {
            this.transform.position = new Vector3(30.18f, 50, 49.4f);
        }
    }

}
