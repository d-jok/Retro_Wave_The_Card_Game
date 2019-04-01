using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detective_Ability : MonoBehaviour {

    int AbilityPower;
    bool check;

	void Start ()
    {
        AbilityPower = 0;
        check = true;
	}

	void Update ()
    {
		if(GetComponent<CardInfo>().AbilityCheck == true)
        {
            if (check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power + 5;
                FindObjectOfType<PowerCounter>().EnemyCounter(AbilityPower);
                check = false;
            }
            GetComponent<CardInfo>().Power = AbilityPower;
        }
	}
}
