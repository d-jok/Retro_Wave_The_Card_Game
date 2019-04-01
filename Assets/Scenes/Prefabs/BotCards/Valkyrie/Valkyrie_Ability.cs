using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie_Ability : MonoBehaviour {

    bool check;
    int AbilityPower;

	void Start ()
    {
        check = true;
        AbilityPower = 0;
	}

    void Update()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true)
        {
            if (check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power + 2;
                FindObjectOfType<PowerCounter>().EnemyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
    }
}
