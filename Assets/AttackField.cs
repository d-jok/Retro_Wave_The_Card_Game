using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackField : MonoBehaviour {

    [HideInInspector]
    public bool yes = false;
    [HideInInspector]
    public bool MouseDown = false;
    [HideInInspector]
    public float FieldPosX = -16, FieldPosY = 46, FieldPosZ = 48;

    [HideInInspector]
    public int CardCount = 0;

    [HideInInspector]
    public bool FieldFull = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        yes = true;
        //Debug.Log("IN");
        //GetComponent<MeshRenderer>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        yes = false;
        //Debug.Log("OUT");
    }
    
}
