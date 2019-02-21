using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour {

    public int Power;
    public string Description;
    public TextMesh TextPower;
    public string id;

    private void Start()
    {
        string count;
        //TextPower = GetComponent<TextMesh>();

        count = Power.ToString();
        TextPower.text = count;
    }
}
