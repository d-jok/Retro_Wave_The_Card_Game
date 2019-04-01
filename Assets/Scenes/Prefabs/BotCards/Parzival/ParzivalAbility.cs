using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParzivalAbility : MonoBehaviour {

    bool check;
    int AbilityPower;

    private void Start()
    {
        check = true;
        AbilityPower = 0;
    }

    private void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true)
        {
            if (check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power;
                FindObjectOfType<PowerCounter>().EnemyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }
}
