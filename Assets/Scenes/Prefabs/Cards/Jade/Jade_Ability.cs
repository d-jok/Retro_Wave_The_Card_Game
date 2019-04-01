using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jade_Ability : MonoBehaviour {

    int AbilityPower;
    int NewPower;
    bool check;

    void Start()
    {
        check = true;
    }

    void Update()
    {
        if (GetComponent<CardMove>().AbilityCheck == true)
        {
            if(check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power + 6;
                FindObjectOfType<PowerCounter>().MyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }
}
