using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour {

    public GameObject VS;
    public GameObject IconVS;

    [HideInInspector]
    public GameObject[] NewCards;

    //Player Cordinates
    float x, y, z;
    //Bot Cordinates
    float x1, y1, z1;

    [HideInInspector]
    public bool Pass = false, EnemyPass = false, End = false, YourTurn = false, BotTurn = false, CardDelete = false;

    [HideInInspector]
    public bool EndOfRound = false;

    private string[] CardOnField;

    [HideInInspector]
    public int RoundCount, BotCardCount, PlayerCardCount;

    [HideInInspector]
    int Wins, i, k, EnemyWins, PlayerWins;

    int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    int[] mixArray;

    public Text Info;   //Information in the end of round

    // Use this for initialization
    void Start()
    {
        mixArray = new int[FindObjectOfType<CardManager>().PlayerCards.Length];
        x = -22.5f;
        y = 35; //34
        z = 48;

        k = 0;

        x1 = -22.5f;
        y1 = 65;
        z1 = 48;

        FindObjectOfType<Bot>().StartCount = 0;

        Wins = 0;
        i = 0;

        EnemyWins = 0;
        PlayerWins = 0;

        RoundCount = 1;
        Round1();
    }

    private void Update()
    {
        if (EnemyPass == true && Pass == true)
        {
            //Process();
            StartCoroutine("RoundEnd");
        }

        if (EnemyWins == 2 || PlayerWins == 2)
        {
            Wins = 2;
            TheEnd();
        }

        if (Pass == true && EnemyPass == true)
            EndOfRound = true;
    }

    void Round1()
    {
        StartCoroutine("Begin");
    }

    void Round2()
    {
        StartCoroutine("NewRound");
    }

    void Round3()
    {
        if (PlayerWins == 1 && EnemyWins == 1)
            StartCoroutine("NewRound");
    }

    void TheEnd()
    {
        CardOnField = new string[FindObjectOfType<Bot>().Count];

        for (int j = 0; j < CardOnField.Length; j++)
        {
            CardOnField[j] = FindObjectOfType<Bot>().CardsOnField[j];
        }

        if (Wins == 2)
        {
            GameObject[] CurrentCard = GameObject.FindGameObjectsWithTag(CardOnField[i]);

            foreach (GameObject EnemyCards in CurrentCard)
            {
                Destroy(EnemyCards);
                i++;
                Debug.Log(i);
            }

            if (FindObjectOfType<PowerCounter>().MyCurrentPower > FindObjectOfType<PowerCounter>().EnemyCurrentPower)
                Info.text = "Victory";
            if (FindObjectOfType<PowerCounter>().MyCurrentPower < FindObjectOfType<PowerCounter>().EnemyCurrentPower)
                Info.text = "Defeat";
            if (FindObjectOfType<PowerCounter>().MyCurrentPower == FindObjectOfType<PowerCounter>().EnemyCurrentPower)
                Info.text = "Draw";

            FindObjectOfType<EndGame>().ButtonExit.SetActive(true);
            FindObjectOfType<EndGame>().ButtonPlayAgain.SetActive(true);

            Wins = 0;
        }
    }

    IEnumerator Begin() //Starting!!!!!!!!!!
    {
        VS.SetActive(true);
        yield return new WaitForSeconds(3); //Waiting VS
        VS.SetActive(false);
        IconVS.SetActive(true);

        //Round 1
        Info.text = "Round 1";
        yield return new WaitForSeconds(2f);
        Info.text = "";
        //Round1Check = false;

        //Distribution of Cards / Раздача карт
        mixArray = Mix(numbers);    //Random

        FindObjectOfType<Bot>().StartCount = 10;

        //Your Cards
        for (int i = 0; i < FindObjectOfType<CardManager>().PlayerCards.Length; i++)
        {
            //int card = mixArray[i];
            Instantiate(FindObjectOfType<CardManager>().PlayerCards[mixArray[i]], new Vector3(x + k, y, z), Quaternion.Euler(0, 0, 180));  //Your Cards
            k += 5;
        }

        k = 0;

        //Bot Cards
        for (int i = 0; i < FindObjectOfType<CardManager>().BotCards.Length; i++)
        {
            //int card = mixArray[i];
            Instantiate(FindObjectOfType<CardManager>().BotCards[mixArray[i]], new Vector3(x1 + k, y1, z1), Quaternion.Euler(0, 180, 180));   //Bot Cards
            k += 5;
        }

        FirstMove();
    }

    IEnumerator NewRound()
    {
        CardDelete = false;

        FindObjectOfType<Bot>().StartCount = 0;

        int number = FindObjectOfType<CardManager>().BotCards.Length - FindObjectOfType<Bot>().Count;

        NewCards = new GameObject[number];
        Debug.Log(number);

        Info.text = "Round 2";

        yield return new WaitForSeconds(3);
        Info.text = "";

        k = 0;
        FindObjectOfType<PowerCounter>().MyCurrentPower = 0;
        FindObjectOfType<PowerCounter>().MyPower.text = "0";
        FindObjectOfType<AttackField>().CardCount = 0;
        FindObjectOfType<AttackField>().FieldPosX = -16;
        FindObjectOfType<AttackField>().FieldFull = false;

        FindObjectOfType<PowerCounter>().EnemyCurrentPower = 0;
        FindObjectOfType<PowerCounter>().EnemyPower.text = "0";
        FindObjectOfType<Enemy_Enter>().CardCount = 0;
        FindObjectOfType<Bot>().Count = 0;
        //FindObjectOfType<CardManager>().BotTemp = new GameObject[FindObjectOfType<CardManager>().BotTemp.Length - FindObjectOfType<Bot>().Count];

        FindObjectOfType<Bot>().EndPoint = new Vector3(-16, 54, 48);

        /*for (int i = 0; i < FindObjectOfType<Bot>().New.Length; i++)
        {
            Debug.Log(FindObjectOfType<Bot>().New[i]);
        }*/

        //Bot Cards
        for (int i = 0; i < FindObjectOfType<CardManager>().BotCards.Length; i++)
        {
            int Flag = 0;
            for (int j = 0; j < FindObjectOfType<CardManager>().PlayedСards_Bot.Length; j++)
            {
                if (FindObjectOfType<CardManager>().PlayedСards_Bot[j] == FindObjectOfType<CardManager>().BotCards[i].GetComponent<CardInfo>().id)
                {
                    Flag = 1;
                }
            }
            if (Flag == 0)
            {
                /*FindObjectOfType<CardManager>().BotTemp[s] = FindObjectOfType<CardManager>().BotCards[i];
                s++;*/
                Instantiate(FindObjectOfType<CardManager>().BotCards[i], new Vector3(x1 + k, y1, z1), Quaternion.Euler(0, 180, 180));  //Bot Cards
                k += 5;
                FindObjectOfType<Bot>().StartCount++;
            }
        }

        k = 0;

        //Player Cards
        for (int i = 0; i < FindObjectOfType<CardManager>().PlayerCards.Length; i++)
        {
            int Flag = 0;
            for (int j = 0; j < FindObjectOfType<CardManager>().PlayedСards_Player.Length; j++)
            {
                if (FindObjectOfType<CardManager>().PlayedСards_Player[j] == FindObjectOfType<CardManager>().PlayerCards[i].GetComponent<CardInfo>().id)
                {
                    Flag = 1;
                }
            }
            if (Flag == 0)
            {
                Instantiate(FindObjectOfType<CardManager>().PlayerCards[i], new Vector3(x + k, y, z), Quaternion.Euler(0, 0, 180));  //Player Cards
                k += 5;
            }
        }
        
    }

    IEnumerator RoundEnd()
    {
        Pass = false;
        EnemyPass = false;

        RoundCount++;
        CardDelete = true;

        if (FindObjectOfType<PowerCounter>().MyCurrentPower > FindObjectOfType<PowerCounter>().EnemyCurrentPower)
        { 
            PlayerWins += 1;

            if (RoundCount == 2)
            {
                Info.text = "You Win";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round2();
            }
            else if (RoundCount == 3)
            {
                Info.text = "You Win";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round3();
            }
        }
        else if(FindObjectOfType<PowerCounter>().MyCurrentPower < FindObjectOfType<PowerCounter>().EnemyCurrentPower)
        {
            EnemyWins++;

            if (RoundCount == 2)
            {
                Info.text = "You Lose";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round2();
            }
            else if (RoundCount == 3)
            {
                Info.text = "You Lose";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round3();
            }
        }
        else if (FindObjectOfType<PowerCounter>().MyCurrentPower == FindObjectOfType<PowerCounter>().EnemyCurrentPower)
        {
            PlayerWins++;
            EnemyWins++;
           
            if (RoundCount == 2)
            {
                Info.text = "Draw";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round2();
            }
            else if (RoundCount == 3)
            {
                Info.text = "Draw";
                yield return new WaitForSeconds(3);
                Info.text = "";

                Round3();
            }
        }     
    }

    //Random of Numbers
    int[] Mix(int[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            int currentValue = num[i];
            int randomIndex = Random.Range(i, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = currentValue;
        }
        return num;

    }

    //Random of Tags
    public string[] MixString(string[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            string currentValue = num[i];
            int randomIndex = Random.Range(i, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = currentValue;
            //Debug.Log(num[i]);
        }
        return num;
    }

    //Random First Step!!!!
    void FirstMove()
    {
        int move;
        move = Random.Range(1, 10);

        if (move >= 5)
        {
            End = false;    //Your turn
            YourTurn = true;
        }
        else
        {
            End = true;     //Enemy turn
            BotTurn = true;
        }
    }

}
