using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomAbility : MonoBehaviour {

    public int AbilityPower;
    bool check;

    void Start()
    {
        check = true;
    }

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true && check == true)
        {
            GetComponent<CardInfo>().Power += AbilityPower;
            FindObjectOfType<PowerCounter>().EnemyCounter(GetComponent<CardInfo>().Power);
            check = false;
        }
    }
}
