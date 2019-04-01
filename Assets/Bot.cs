using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

    [HideInInspector]
    public string[] Tags, CardsOnField;

    public string[] New;

    public int Count, StartCount;

    public GameObject[] CardsInHand;

    public string card;

    private int Power;

    [HideInInspector]
    public Vector3 EndPoint = new Vector3(-16, 54, 48);

    int i = 0;

    private void Start()
    {
        Tags = new string[10] { "Jade", "Valkyrie", "Detective", "Shani", "Tom", "SkyWalker", "HakerMan", "Kiss", "Parzival", "Ezgi" };
        Tags = FindObjectOfType<GameProcess>().MixString(Tags);
        CardsOnField = new string[Tags.Length];
        New = new string[Tags.Length];
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (//FindObjectOfType<PowerCounter>().EnemyCurrentPower >= FindObjectOfType<PowerCounter>().MyCurrentPower &&
            FindObjectOfType<GameProcess>().Pass == true || Count >= 10 || FindObjectOfType<Enemy_Enter>().CardCount == 8 || i == StartCount)
        {
            Debug.Log("sjdjfgapdsofjpo");
            FindObjectOfType<GameProcess>().EnemyPass = true;
            FindObjectOfType<GameProcess>().BotTurn = false;
            FindObjectOfType<GameProcess>().End = false;
        }

        if (FindObjectOfType<GameProcess>().End == true || FindObjectOfType<GameProcess>().BotTurn == true)
        {
            //FindObjectOfType<GameProcess>().Process();
            Debug.Log("gett");
            GameObject[] CurrentCard = GameObject.FindGameObjectsWithTag(Tags[i]);
            //FindObjectOfType<Enemy_Enter>().CardCount++;

            foreach (GameObject CurrentCards in CurrentCard)
            {
                CurrentCards.transform.rotation = Quaternion.Euler(0, 0, 180);
                CurrentCards.transform.position = Vector3.MoveTowards(CurrentCards.transform.position, EndPoint, 0.5f);
                CardsOnField[i] = Tags[i];

                //FindObjectOfType<CardManager>().PlayedСards_Bot[i] = CurrentCards.GetComponent<CardInfo>().id;
                FindObjectOfType<CardManager>().BotTemp.Add(CurrentCards.GetComponent<CardInfo>().id);  //List

                if (CurrentCards.transform.position == EndPoint)
                {
                    Power = CurrentCards.GetComponent<CardInfo>().Power;
                    //FindObjectOfType<PowerCounter>().EnemyCounter(Power);
                    CurrentCards.GetComponent<CardInfo>().AbilityCheck = true;

                    FindObjectOfType<GameProcess>().End = false;
                    EndPoint.x += 4.5f;
                    i++;
                    
                    Count = i;

                    FindObjectOfType<Enemy_Enter>().CardCount++;    //ihfdig
                    FindObjectOfType<End>().EndCheck = false;
                    FindObjectOfType<Pass>().PassCheck = true;

                    Debug.Log(i);
                    //if (i == Tags.Length || FindObjectOfType<GameProcess>().Pass == true)

                    if (FindObjectOfType<GameProcess>().Pass != true)
                    {
                        FindObjectOfType<GameProcess>().BotTurn = false;
                        FindObjectOfType<GameProcess>().YourTurn = true;
                    }
                }
            }
        }

        if (//FindObjectOfType<PowerCounter>().EnemyCurrentPower >= FindObjectOfType<PowerCounter>().MyCurrentPower &&
            FindObjectOfType<GameProcess>().Pass == true || Count >= 10 || FindObjectOfType<Enemy_Enter>().CardCount == 8 || i == StartCount)
        {
            Debug.Log("sjdjfgapdsofjpo");
            FindObjectOfType<GameProcess>().EnemyPass = true;
            FindObjectOfType<GameProcess>().BotTurn = false;
            FindObjectOfType<GameProcess>().End = false;
        }

    }
}
