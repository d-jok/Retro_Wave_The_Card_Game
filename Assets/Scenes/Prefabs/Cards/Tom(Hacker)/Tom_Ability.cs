using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tom_Ability : MonoBehaviour {

    public int AbilityPower;
    bool check;

	void Start ()
    {
        check = true;
	}
	
	void Update ()
    {
		if(GetComponent<CardMove>().AbilityCheck == true && check == true)
        {
            GetComponent<CardInfo>().Power += AbilityPower;
            FindObjectOfType<PowerCounter>().MyCounter(GetComponent<CardInfo>().Power);
            check = false;
        }
	}
}
