using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parzival_Ability : MonoBehaviour {

    bool check;
    int AbilityPower;

    private void Start()
    {
        check = true;
        AbilityPower = 0;
    }

    private void Update()
    {
        if (GetComponent<CardMove>().AbilityCheck == true)
        {
            if (check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power;
                FindObjectOfType<PowerCounter>().MyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }

}
