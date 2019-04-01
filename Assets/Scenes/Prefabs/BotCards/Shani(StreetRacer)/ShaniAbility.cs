﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaniAbility : MonoBehaviour {

    int AbilityPower;
    public GameObject NOS;
    bool check;

    void Start()
    {
        check = true;
        NOS.SetActive(false);
        AbilityPower = 0;
    }

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true)
        {
            NOS.SetActive(true);
            if (check == true)
            {
                UpPower();
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }

    private void UpPower()
    {
        AbilityPower = Random.Range(2, 10);
        FindObjectOfType<PowerCounter>().EnemyCounter(AbilityPower);
        check = false;
    }
}
