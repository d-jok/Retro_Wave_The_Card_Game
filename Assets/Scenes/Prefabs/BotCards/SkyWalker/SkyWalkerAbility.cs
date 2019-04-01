using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyWalkerAbility : MonoBehaviour {

    public GameObject Shield;
    bool check;
    int AbilityPower;

    void Start()
    {
        Shield.SetActive(false);
        check = true;
        AbilityPower = 0;
    }

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true)
        {
            Shield.SetActive(true);
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
