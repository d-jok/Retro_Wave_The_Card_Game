using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMashine_Ability : MonoBehaviour {

    bool check;
    public GameObject LowCharge;

	void Start ()
    {
        check = true;
	}
	

	void Update ()
    {
		if(GetComponent<CardMove>().AbilityCheck == true && check == true)
        {
            GetComponent<CardInfo>().Power /= 2;
            FindObjectOfType<PowerCounter>().MyCounter(GetComponent<CardInfo>().Power);

            LowCharge.SetActive(true);

            check = false;
        }
	}
}
