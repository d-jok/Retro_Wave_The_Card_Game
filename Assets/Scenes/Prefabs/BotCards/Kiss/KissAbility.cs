using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KissAbility : MonoBehaviour {

    int AbilityPower;
    bool check;

    void Start()
    {
        check = true;
    }

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true && check == true)
        {
            AbilityPower = Random.Range(0, 5);
            GetComponent<CardInfo>().Power += AbilityPower;
            FindObjectOfType<PowerCounter>().EnemyCounter(GetComponent<CardInfo>().Power);
            check = false;
        }
    }
}
