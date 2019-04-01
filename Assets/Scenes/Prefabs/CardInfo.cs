using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour {

    public int Power;
    public string Description;
    public TextMesh TextPower;
    public string id;
    public Transform popuptext;
    public static string textstatus = "off";
    [HideInInspector]
    public bool check = true, AbilityCheck;

    private void Start()
    {
        AbilityCheck = false;
    }

    private void Update()
    {
        string count;
        count = Power.ToString();
        TextPower.text = count;
    }

    private void OnMouseEnter()
    {
        if(textstatus == "off" && check == true)
        {
            popuptext.GetComponent<TextMesh>().text = Description;
            textstatus = "on";
            Instantiate(popuptext, new Vector3(transform.position.x, transform.position.y + 4.5f, 45), popuptext.rotation);
        }
    }

    private void OnMouseExit()
    {
        if (textstatus == "on")
        {
            textstatus = "off";
        }
    }

    private void OnMouseDown()
    {
        textstatus = "off";
        check = false;
    }

    private void OnMouseUp()
    {
        textstatus = "on";
        check = true;
    }
}
