using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JadeAbility : MonoBehaviour {

    int AbilityPower;
    int NewPower;
    bool check;

    void Start()
    {
        check = true;
    }

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true)
        {
            if (check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power + 6;
                FindObjectOfType<PowerCounter>().EnemyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }
}
