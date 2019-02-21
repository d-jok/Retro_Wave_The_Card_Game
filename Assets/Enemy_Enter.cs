using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_Enter : MonoBehaviour {

    public bool yes = false;

    [HideInInspector]
    public float FieldPosX = -16, FieldPosY = 54, FieldPosZ = 48;

    public int CardCount = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        yes = true;
        //Debug.Log("Enemy IN");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        yes = false;
        //Debug.Log("Enemy OUT");
    }
}
