using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashley_Ability : MonoBehaviour {

    int AbilityPower;
    int NewPower;
    bool check;

    void Start ()
    {
        check = true;
       // AbilityPower = GetComponent<CardInfo>().Power + 4;      
    }

	void Update ()
    {
		if(GetComponent<CardMove>().AbilityCheck == true)
        {
            GetComponent<CardInfo>().Power = AbilityPower;
            if(check == true)
            {
                AbilityPower = GetComponent<CardInfo>().Power + 4;
                FindObjectOfType<PowerCounter>().MyCounter(AbilityPower);
                check = false;
            }
        }
	}
}
