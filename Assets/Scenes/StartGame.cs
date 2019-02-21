using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public GameObject[] objects;
    //public GameObject VS;
    //public GameObject IconVS;
    //Vector3 EndPoint = new Vector3(-22.5f, 36, 48);
    //int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] numbers = {0, 1, 2, 3, 4};
    int[] mixArray;

    //Your Cordinates
    float x, y, z;
    //Bot Cordinates
    float x1, y1, z1;

    int k = 0;

    void Start ()
    {
        x = -22.5f;
        y = 34; //34
        z = 48;

        k = 0;

        x1 = -22.5f;
        y1 = 65;
        z1 = 48;

        StartCoroutine("Begin");
    }

	void Update ()
    {

    }

    void FirstMove()
    {
        int move;
        move = Random.Range(1, 10);
        //Debug.Log(move+"ksdfs");

        if(move >= 5)
        {
            FindObjectOfType<GameProcess>().End = false;    //Your turn
            FindObjectOfType<GameProcess>().YourTurn = true;
            //FindObjectOfType<GameProcess>().Process();
        }
        else
        {
            FindObjectOfType<GameProcess>().End = true;     //Enemy turn
            FindObjectOfType<GameProcess>().BotTurn = true;
            //FindObjectOfType<GameProcess>().Process();
        }
    }

    int[] Mix(int [] num)
    {
        for(int i = 0; i < num.Length; i++)
        {
            int currentValue = num[i];
            int randomIndex = Random.Range(i, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = currentValue;
        }
        return num;     
       
    }

    public string[] MixString(string[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            string currentValue = num[i];
            int randomIndex = Random.Range(i, num.Length);
            num[i] = num[randomIndex];
            num[randomIndex] = currentValue;
            Debug.Log(num[i]);
        }
        return num;

    }

    IEnumerator Begin()
    {
        //VS.SetActive(true);
        yield return new WaitForSeconds(3); //Waiting VS
        //VS.SetActive(false);
        //IconVS.SetActive(true);

        mixArray = Mix(numbers);    //your cards

        //Your Cards
        for (int i = 0; i < objects.Length; i++)
        {
            int card = mixArray[i];
            Instantiate(objects[card], new Vector3(x + k, y, z), Quaternion.Euler(0, 0, 180));  //Your Cards
            k += 5;
        }

        k = 0;

        //Bot Cards
        for (int i = 0; i < FindObjectOfType<Bot>().CardsInHand.Length; i++)
        {
            int card = mixArray[i];
            Instantiate(FindObjectOfType<Bot>().CardsInHand[card], new Vector3(x1 + k, y1, z1), Quaternion.Euler(0, 0, 180));   //Bot Cards
            k += 5;
        }

        FirstMove();
    }

}
