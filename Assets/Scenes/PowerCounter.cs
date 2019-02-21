using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCounter : MonoBehaviour {

    public Text MyPower, EnemyPower;

    [HideInInspector]
    public int MyCurrentPower, EnemyCurrentPower;

    public void MyCounter(int NewPower)
    {
        string count;

        MyCurrentPower += NewPower;
        count = MyCurrentPower.ToString();
        MyPower.text = count;
    }

    public void EnemyCounter(int NewPower)
    {
        string count;

        EnemyCurrentPower += NewPower;
        count = EnemyCurrentPower.ToString();
        EnemyPower.text = count;
    }

}
