using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMove : MonoBehaviour
{

    Vector3 Pos;
    Vector3 CardPos;

    private int Power;

    float FieldPosX;
    float FieldPosY;
    float FieldPosZ;

    bool MouseDown = false;
    bool CardCheck = true;

    [HideInInspector]
    public bool CardOnField = false;   //if card on battle field

    void Start()
    {
        CardOnField = true;
    }

    void Update()
    {
        if (CardOnField == true && FindObjectOfType<GameProcess>().Pass == false && FindObjectOfType<GameProcess>().YourTurn == true)
        {
            Vector3 Cursor = Input.mousePosition;   //begin of card move
            Cursor.z = 60;
            Cursor = Camera.main.ScreenToWorldPoint(Cursor);
            Cursor.z = 48;


            if (MouseDown == true)
            {
                this.transform.position = Cursor;   //end of card move
            }
            
        }
    }

    void OnMouseDown()
    {
        MouseDown = true;
        Pos = this.transform.position;
    }

    void OnMouseUp()
    {
        MouseDown = false;
        LineUp();         
    }

    public void LineUp()
    {
        

        if (CardOnField == true)
        {
            if (FindObjectOfType<AttackField>().yes == true && FindObjectOfType<AttackField>().FieldFull == false)
            {
                this.transform.position = new Vector3(FindObjectOfType<AttackField>().FieldPosX, FindObjectOfType<AttackField>().FieldPosY, FindObjectOfType<AttackField>().FieldPosZ);

                FindObjectOfType<CardManager>().PlayedСards_Player[FindObjectOfType<AttackField>().CardCount] = this.gameObject.GetComponent<CardInfo>().id;


                FindObjectOfType<GameProcess>().YourTurn = false;

                FindObjectOfType<AttackField>().CardCount++;

                Debug.Log(FindObjectOfType<AttackField>().CardCount);

                Power = GetComponent<CardInfo>().Power; //get power of card
                //Debug.Log(Power);

                if (FindObjectOfType<AttackField>().CardCount <= 9)
                {
                    FindObjectOfType<AttackField>().FieldPosX += 4.5f;

                    if (FindObjectOfType<AttackField>().CardCount >= 9)
                    {
                        FindObjectOfType<AttackField>().FieldFull = true;
                    }

                    //game process(end; pass)
                    if (FindObjectOfType<AttackField>().CardCount < 8 && FindObjectOfType<Enemy_Enter>().CardCount < 8 
                        || FindObjectOfType<GameProcess>().EnemyPass == false)
                    {
                        FindObjectOfType<End>().EndCheck = true;    //ERROR!!!!!!!!
                        FindObjectOfType<Pass>().PassCheck = false;
                    }
                    else if(FindObjectOfType<AttackField>().CardCount == 8 && FindObjectOfType<Enemy_Enter>().CardCount == 7 
                        || FindObjectOfType<GameProcess>().EnemyPass == true)
                    {
                        FindObjectOfType<Pass>().PassCheck = false;
                        FindObjectOfType<End>().EndCheck = false;
                        //FindObjectOfType<GameProcess>().Pass = true;
                    }
                }

                FindObjectOfType<PowerCounter>().MyCounter(Power);
            }

            //Card Return Back In Hand
            if (FindObjectOfType<AttackField>().yes == false || FindObjectOfType<AttackField>().FieldFull == true)
            {
                this.transform.position = Pos;
                //this.transform.position = Vector3.MoveTowards(transform.position, Pos, 0.5f);
                CardCheck = false;

                if (this.transform.position == Pos)
                {
                    CardCheck = true;
                }
            }
            else
            {
                CardCheck = false;
                CardOnField = false;
            }
            FindObjectOfType<AttackField>().yes = false;
        }
           
    }


    /* void OnMouseEnter()
     {
         if (CardCheck == true)
         {
             CardPos = this.transform.position;
             CardPos.y += 1;
             this.transform.position = CardPos;
         }
     }

     void OnMouseExit()
     {
         if (CardCheck == true)
         {
             CardPos.y -= 1;
             this.transform.position = CardPos;
         }
     }*/
}
