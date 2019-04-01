using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakerMan_Ability : MonoBehaviour {

    public int AbilityPower;
    bool check;

    void Start()
    {
        check = true;
    }

    void Update ()
    {
        if (GetComponent<CardInfo>().AbilityCheck == true && check == true)
        {
            if (Random.Range(0, 10) > 5)
            {
                GetComponent<CardInfo>().Power += AbilityPower;
                FindObjectOfType<PowerCounter>().EnemyCounter(GetComponent<CardInfo>().Power);
            }
            else if (Random.Range(0, 10) <= 5)
            {
                GetComponent<CardInfo>().Power -= AbilityPower;
                FindObjectOfType<PowerCounter>().EnemyCounter(GetComponent<CardInfo>().Power);
            }
            check = false;
        }
    }
}
