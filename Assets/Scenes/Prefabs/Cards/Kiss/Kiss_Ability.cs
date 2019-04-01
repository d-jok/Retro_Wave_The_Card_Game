using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiss_Ability : MonoBehaviour {

    int AbilityPower;
    bool check;

	void Start ()
    {
        check = true;
	}
	
	void Update ()
    {
        if (GetComponent<CardMove>().AbilityCheck == true && check == true)
        {
            AbilityPower = Random.Range(0, 5);
            GetComponent<CardInfo>().Power += AbilityPower;
            FindObjectOfType<PowerCounter>().MyCounter(GetComponent<CardInfo>().Power);
            check = false;
        }
    }
}
