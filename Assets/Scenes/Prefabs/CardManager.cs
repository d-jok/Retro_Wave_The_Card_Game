using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public GameObject[] BotCards;
    public GameObject[] PlayerCards;
    //public GameObject[] rec;
    [HideInInspector]
    public string[] PlayedСards_Player, PlayedСards_Bot;
    [HideInInspector]
    public GameObject[] BotTemp, PlayerTemp;

    void Start ()
    {
        PlayedСards_Player = new string[PlayerCards.Length];
        PlayedСards_Bot = new string[BotCards.Length];

        /*rec = new GameObject[BotCards.Length];
        for (int i = 0; i < BotCards.Length; i++)
        {
            rec[i] = BotCards[i];
        }*/
        
	}
	
}
